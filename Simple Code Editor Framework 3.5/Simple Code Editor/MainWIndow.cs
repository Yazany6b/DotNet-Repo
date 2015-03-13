using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simple_Code_Editor
{

    public partial class MainWindow : Form
    {
        AdvancedRichTextBox TextArea = new AdvancedRichTextBox();
        SupportedLanguage currentLanguage = SupportedLanguage.SQL;
        Settings settings;
        Dictionary<SupportedLanguage, Language> languages = new Dictionary<SupportedLanguage, Language>();
        public static Point CurrentLocation;
        public MainWindow()
        {
            InitializeComponent();
            CurrentLocation = Location;
            currentLanguage = SupportedLanguage.Ada;
            ViewPanel.Controls.Add(TextArea);
            TextArea.ParentLocation = this.Location;
            SetupStartUp();
            SaveFileDialogBox.FileName = string.Empty;
            Text = "Code Editor";
            UncheckAll();
            NoneMenuItem.Checked = true;
            TextArea.StopColoring = true;
        }
        public MainWindow(string file)
        {
            InitializeComponent();
            currentLanguage = SupportedLanguage.Ada;
            ViewPanel.Controls.Add(TextArea);
            TextArea.ParentLocation = this.Location;
            SetupStartUp();
            SetupTextAreaFromFile(file);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            CurrentLocation = Location;
            base.OnLocationChanged(e);
        }

        private void SetupTextAreaFromFile(string file)
        {
            Text = file;
            if (System.IO.Path.GetExtension(file).Equals(".ada", StringComparison.OrdinalIgnoreCase))
            {
                currentLanguage = SupportedLanguage.Ada;
                UncheckAll();
                ADAMenuItem.Checked = true;
            }
            else
                if (System.IO.Path.GetExtension(file).Equals(".sql", StringComparison.OrdinalIgnoreCase))
                {
                    currentLanguage = SupportedLanguage.SQL;
                    UncheckAll();
                    SQLMenuItem.Checked = true;
                }
                else
                    if (System.IO.Path.GetExtension(file).Equals(".java", StringComparison.OrdinalIgnoreCase))
                    {
                        currentLanguage = SupportedLanguage.Java;
                        UncheckAll();
                        JavaMenuItem.Checked = true;
                    }
                    else
                        if (System.IO.Path.GetExtension(file).Equals(".cpp", StringComparison.OrdinalIgnoreCase) || System.IO.Path.GetExtension(file).Equals(".h", StringComparison.OrdinalIgnoreCase) || System.IO.Path.GetExtension(file).Equals(".c", StringComparison.OrdinalIgnoreCase))
                        {
                            currentLanguage = SupportedLanguage.CPP;
                            UncheckAll();
                            CPPMenuItem.Checked = true;
                        }
                        else
                            if (System.IO.Path.GetExtension(file).Equals(".cs", StringComparison.OrdinalIgnoreCase))
                            {
                                currentLanguage = SupportedLanguage.CS;
                                UncheckAll();
                                CSMenuItem.Checked = true;
                            }
                            else
                                if (System.IO.Path.GetExtension(file).Equals(".scf", StringComparison.OrdinalIgnoreCase))
                                {
                                    GetPasswordForm form = new GetPasswordForm(file, true);
                                    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                    {
                                        TextArea.Text = SecureCodeFormat.GetText(file);
                                        currentLanguage = SecureCodeFormat.GetLanguage(file);
                                        SetupTextArea();
                                        return;
                                    }
                                    else
                                    {
                                        SaveFileDialogBox.FileName = string.Empty;
                                        Text = "Code Editor";
                                        UncheckAll();
                                        NoneMenuItem.Checked = true;
                                        TextArea.StopColoring = true;
                                        return;
                                    }
                                }
                                else
                                {
                                    UncheckAll();
                                    NoneMenuItem.Checked = true;
                                    System.IO.StreamReader srx = new System.IO.StreamReader(file);
                                    if (srx.BaseStream.CanRead)
                                    {
                                        TextArea.SetText(srx.ReadToEnd());
                                        SaveFileDialogBox.FileName = file;
                                        srx.Close();
                                    }
                                    TextArea.StopColoring = true;
                                    return;
                                }
            // System.Windows.Forms.MessageBox.Show("");
            // foreach (System.Windows.Forms.MenuItem mi in this.Menu.MenuItems)
            //     if (mi.Text.Equals(currentLanguage.ToString(),StringComparison.OrdinalIgnoreCase))
            //     {
            //         mi.Checked = true;
            //     }
            SetupTextArea();
            System.IO.StreamReader sr = new System.IO.StreamReader(file);
            if (sr.BaseStream.CanRead)
            {
                TextArea.SetText(sr.ReadToEnd());
                SaveFileDialogBox.FileName = file;
                sr.Close();
            }
        }

        private void SetupStartUp()
        {
            settings = Settings.Deserialize();
            if (settings == null)
            {
                settings = new Settings();
                settings.BackColor = TextArea.BackColor;
                settings.FontColor = TextArea.ForeColor;
                settings.Font = TextArea.Font;
                SetupADAList();
                SetupSQLList();
                SetupCPPList();
                SetupJavaList();
                SetupCSList();
                settings.Languages = languages;
                settings.WindowSize = Size;
                settings.WindowLocation = Location;
                TextArea.ResevedColor = System.Drawing.Color.Blue;
                TextArea.OperatorColor = System.Drawing.Color.DarkOrange;
                TextArea.DataTypeColor = System.Drawing.Color.DarkCyan;
                TextArea.FunctionColor = System.Drawing.Color.Navy;
            }
            else
            {
                TextArea.ResevedColor = settings.Languages[currentLanguage].KeywordsColors[KeywordType.DataType];
                TextArea.FunctionColor = settings.Languages[currentLanguage].KeywordsColors[KeywordType.Function];
                TextArea.OperatorColor = settings.Languages[currentLanguage].KeywordsColors[KeywordType.Operator];
                TextArea.DataTypeColor = settings.Languages[currentLanguage].KeywordsColors[KeywordType.DataType];
                TextArea.Font = settings.Font;
                TextArea.ForeColor = settings.FontColor;
                TextArea.BackColor = settings.BackColor;
                this.Size = settings.WindowSize;
                this.Location = settings.WindowLocation;
                TextArea.Keywords = settings.Languages[currentLanguage].Keywords;
                TextArea.CommentsColor = settings.Languages[currentLanguage].CommentsColor;
                TextArea.QuotationColor = settings.Languages[currentLanguage].QuotationsColor;
                TextArea.KeywordsFont = settings.Languages[currentLanguage].KeywordsFont;
                SetupTextArea();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            ViewPanel.Size = new Size(this.Width - (ViewPanel.Location.X+25),this.Height - (ViewPanel.Location.Y+47));
            TextArea.Size = new Size(ViewPanel.Width - 10, ViewPanel.Height - 10);
            TextArea.Location = new Point(1, 1);
            TextArea.Update();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            settings.BackColor = TextArea.BackColor;
            settings.FontColor = TextArea.ForeColor;
            settings.Font = TextArea.Font;
            if (WindowState != FormWindowState.Maximized && WindowState != FormWindowState.Minimized)
            {
                settings.WindowSize = Size;
                settings.WindowLocation = Location;
            }
            try
            {
                Settings.Serialize(settings);
            }
            catch { }
        }

        private void UncheckAll()
        {
            SQLMenuItem.Checked = false;
            CPPMenuItem.Checked = false;
            CSMenuItem.Checked = false;
            JavaMenuItem.Checked = false;
            ADAMenuItem.Checked = false;
            NoneMenuItem.Checked = false;
        }

        private void ResetCurrentLanguage()
        {
            settings.Languages[currentLanguage].KeywordsColors[KeywordType.DataType] = System.Drawing.Color.DarkCyan;
            settings.Languages[currentLanguage].KeywordsColors[KeywordType.Function] = System.Drawing.Color.Navy;
            settings.Languages[currentLanguage].KeywordsColors[KeywordType.Reseved] = System.Drawing.Color.Blue;
            settings.Languages[currentLanguage].KeywordsColors[KeywordType.Operator] = System.Drawing.Color.DarkOrange;
            settings.Languages[currentLanguage].CommentsColor = System.Drawing.Color.Green;
            settings.Languages[currentLanguage].QuotationsColor = System.Drawing.Color.Red;
            settings.Languages[currentLanguage].KeywordsFont = TextArea.Font;

            TextArea.DataTypeColor = System.Drawing.Color.DarkCyan;
            TextArea.FunctionColor = System.Drawing.Color.Navy;
            TextArea.ResevedColor = System.Drawing.Color.Blue;
            TextArea.OperatorColor = System.Drawing.Color.DarkOrange;

            TextArea.CommentsColor = System.Drawing.Color.Green;
            TextArea.QuotationColor = System.Drawing.Color.Red;
            TextArea.KeywordsFont = TextArea.Font;
        }

        private void SetupTextArea()
        {
            switch (currentLanguage)
            {
                case SupportedLanguage.SQL:
                    TextArea.ResevedColor = settings.Languages[SupportedLanguage.SQL].KeywordsColors[KeywordType.Reseved];
                    TextArea.FunctionColor = settings.Languages[SupportedLanguage.SQL].KeywordsColors[KeywordType.Function];
                    TextArea.OperatorColor = settings.Languages[SupportedLanguage.SQL].KeywordsColors[KeywordType.Operator];
                    TextArea.DataTypeColor = settings.Languages[SupportedLanguage.SQL].KeywordsColors[KeywordType.DataType];
                    TextArea.CommentsColor = settings.Languages[SupportedLanguage.SQL].CommentsColor;
                    TextArea.QuotationColor = settings.Languages[SupportedLanguage.SQL].QuotationsColor;
                    TextArea.NormalCommentSymbol = settings.Languages[SupportedLanguage.SQL].CommentsSymbol;
                    TextArea.FirstQuotationCharacter = settings.Languages[SupportedLanguage.SQL].FirstQuotationsCharacter;
                    TextArea.SecondQuotationCharacter = settings.Languages[SupportedLanguage.SQL].SecondQuotationsCharacter;
                    TextArea.KeywordsFont = settings.Languages[SupportedLanguage.SQL].KeywordsFont;
                    TextArea.Keywords = settings.Languages[SupportedLanguage.SQL].Keywords;
                    TextArea.Rules = settings.Languages[SupportedLanguage.SQL].Rules;
                    break;
                case SupportedLanguage.Ada:
                    TextArea.ResevedColor = settings.Languages[SupportedLanguage.Ada].KeywordsColors[KeywordType.Reseved];
                    TextArea.FunctionColor = settings.Languages[SupportedLanguage.Ada].KeywordsColors[KeywordType.Function];
                    TextArea.OperatorColor = settings.Languages[SupportedLanguage.Ada].KeywordsColors[KeywordType.Operator];
                    TextArea.DataTypeColor = settings.Languages[SupportedLanguage.Ada].KeywordsColors[KeywordType.DataType];
                    TextArea.CommentsColor = settings.Languages[SupportedLanguage.Ada].CommentsColor;
                    TextArea.QuotationColor = settings.Languages[SupportedLanguage.Ada].QuotationsColor;
                    TextArea.NormalCommentSymbol = settings.Languages[SupportedLanguage.Ada].CommentsSymbol;
                    TextArea.FirstQuotationCharacter = settings.Languages[SupportedLanguage.Ada].FirstQuotationsCharacter;
                    TextArea.SecondQuotationCharacter = settings.Languages[SupportedLanguage.Ada].SecondQuotationsCharacter;
                    TextArea.KeywordsFont = settings.Languages[SupportedLanguage.SQL].KeywordsFont;
                    TextArea.Keywords = settings.Languages[SupportedLanguage.Ada].Keywords;
                    TextArea.Rules = settings.Languages[SupportedLanguage.Ada].Rules;
                    break;
                case SupportedLanguage.CPP:
                    TextArea.ResevedColor = settings.Languages[SupportedLanguage.CPP].KeywordsColors[KeywordType.Reseved];
                    TextArea.FunctionColor = settings.Languages[SupportedLanguage.CPP].KeywordsColors[KeywordType.Function];
                    TextArea.OperatorColor = settings.Languages[SupportedLanguage.CPP].KeywordsColors[KeywordType.Operator];
                    TextArea.DataTypeColor = settings.Languages[SupportedLanguage.CPP].KeywordsColors[KeywordType.DataType];
                    TextArea.CommentsColor = settings.Languages[SupportedLanguage.CPP].CommentsColor;
                    TextArea.QuotationColor = settings.Languages[SupportedLanguage.CPP].QuotationsColor;
                    TextArea.NormalCommentSymbol = settings.Languages[SupportedLanguage.CPP].CommentsSymbol;
                    TextArea.FirstQuotationCharacter = settings.Languages[SupportedLanguage.CPP].FirstQuotationsCharacter;
                    TextArea.SecondQuotationCharacter = settings.Languages[SupportedLanguage.CPP].SecondQuotationsCharacter;
                    TextArea.KeywordsFont = settings.Languages[SupportedLanguage.SQL].KeywordsFont;
                    TextArea.Keywords = settings.Languages[SupportedLanguage.CPP].Keywords;
                    TextArea.Rules = settings.Languages[SupportedLanguage.CPP].Rules;
                    break;
                case SupportedLanguage.CS:
                    TextArea.ResevedColor = settings.Languages[SupportedLanguage.CS].KeywordsColors[KeywordType.Reseved];
                    TextArea.FunctionColor = settings.Languages[SupportedLanguage.CS].KeywordsColors[KeywordType.Function];
                    TextArea.OperatorColor = settings.Languages[SupportedLanguage.CS].KeywordsColors[KeywordType.Operator];
                    TextArea.DataTypeColor = settings.Languages[SupportedLanguage.CS].KeywordsColors[KeywordType.DataType];
                    TextArea.CommentsColor = settings.Languages[SupportedLanguage.CS].CommentsColor;
                    TextArea.QuotationColor = settings.Languages[SupportedLanguage.CS].QuotationsColor;
                    TextArea.NormalCommentSymbol = settings.Languages[SupportedLanguage.CS].CommentsSymbol;
                    TextArea.FirstQuotationCharacter = settings.Languages[SupportedLanguage.CS].FirstQuotationsCharacter;
                    TextArea.SecondQuotationCharacter = settings.Languages[SupportedLanguage.CS].SecondQuotationsCharacter;
                    TextArea.KeywordsFont = settings.Languages[SupportedLanguage.SQL].KeywordsFont;
                    TextArea.Keywords = settings.Languages[SupportedLanguage.CS].Keywords;
                    TextArea.Rules = settings.Languages[SupportedLanguage.CS].Rules;
                    break;
                case SupportedLanguage.Java:
                    TextArea.ResevedColor = settings.Languages[SupportedLanguage.Java].KeywordsColors[KeywordType.Reseved];
                    TextArea.FunctionColor = settings.Languages[SupportedLanguage.Java].KeywordsColors[KeywordType.Function];
                    TextArea.OperatorColor = settings.Languages[SupportedLanguage.Java].KeywordsColors[KeywordType.Operator];
                    TextArea.DataTypeColor = settings.Languages[SupportedLanguage.Java].KeywordsColors[KeywordType.DataType];
                    TextArea.CommentsColor = settings.Languages[SupportedLanguage.Java].CommentsColor;
                    TextArea.QuotationColor = settings.Languages[SupportedLanguage.Java].QuotationsColor;
                    TextArea.NormalCommentSymbol = settings.Languages[SupportedLanguage.Java].CommentsSymbol;
                    TextArea.FirstQuotationCharacter = settings.Languages[SupportedLanguage.Java].FirstQuotationsCharacter;
                    TextArea.SecondQuotationCharacter = settings.Languages[SupportedLanguage.Java].SecondQuotationsCharacter;
                    TextArea.KeywordsFont = settings.Languages[SupportedLanguage.SQL].KeywordsFont;
                    TextArea.Keywords = settings.Languages[SupportedLanguage.Java].Keywords;
                    TextArea.Rules = settings.Languages[SupportedLanguage.Java].Rules;
                    break;
            }

            TextArea.ResetColors();
        }

        private void SetupSQLList()
        {
            List<Keyword> keywords = new List<Keyword>();

            //reseved words
            keywords.Add(new Keyword("create")); keywords.Add(new Keyword("table")); keywords.Add(new Keyword("values"));
            keywords.Add(new Keyword("select")); keywords.Add(new Keyword("where")); keywords.Add(new Keyword("from"));
            keywords.Add(new Keyword("into"));
            keywords.Add(new Keyword("insert")); keywords.Add(new Keyword("having")); keywords.Add(new Keyword("group by"));
            keywords.Add(new Keyword("order by"));
            keywords.Add(new Keyword("declare")); keywords.Add(new Keyword("begin")); keywords.Add(new Keyword("end"));
            keywords.Add(new Keyword("if")); keywords.Add(new Keyword("loop")); keywords.Add(new Keyword("for"));
            keywords.Add(new Keyword("while")); keywords.Add(new Keyword("elseif")); keywords.Add(new Keyword("else"));
            keywords.Add(new Keyword("constraint")); keywords.Add(new Keyword("primary key")); keywords.Add(new Keyword("forign key"));
            keywords.Add(new Keyword("null")); keywords.Add(new Keyword("references")); keywords.Add(new Keyword("join"));
            keywords.Add(new Keyword("view")); keywords.Add(new Keyword("constant")); keywords.Add(new Keyword("DBMS_OUTPUT"));
            keywords.Add(new Keyword("then")); keywords.Add(new Keyword("fetch")); keywords.Add(new Keyword("open"));
            keywords.Add(new Keyword("close")); keywords.Add(new Keyword("when")); keywords.Add(new Keyword("reverse"));
            keywords.Add(new Keyword("return")); keywords.Add(new Keyword("elsif")); keywords.Add(new Keyword("check"));
            keywords.Add(new Keyword("unique")); keywords.Add(new Keyword("default")); keywords.Add(new Keyword("exit"));
            keywords.Add(new Keyword("sequence")); keywords.Add(new Keyword("function")); keywords.Add(new Keyword("procedure"));
            keywords.Add(new Keyword("delete")); keywords.Add(new Keyword("update")); keywords.Add(new Keyword("set"));
            keywords.Add(new Keyword("alter")); keywords.Add(new Keyword("modify"));
            keywords.Add(new Keyword("grant")); keywords.Add(new Keyword("public")); keywords.Add(new Keyword("all"));
            keywords.Add(new Keyword("exception")); keywords.Add(new Keyword("retrun"));
            keywords.Add(new Keyword("rename")); keywords.Add(new Keyword("add")); keywords.Add(new Keyword("drop"));
            keywords.Add(new Keyword("column")); keywords.Add(new Keyword("increment by"));
            keywords.Add(new Keyword("start with")); keywords.Add(new Keyword("dual")); 
            keywords.Add(new Keyword("revoke")); keywords.Add(new Keyword("sysdate")); //keywords.Add(new Keyword(""));
            keywords.Add(new Keyword("true")); keywords.Add(new Keyword("false"));

            //datatypes
            keywords.Add(new Keyword("double", KeywordType.DataType)); keywords.Add(new Keyword("float", KeywordType.DataType)); keywords.Add(new Keyword("varchar", KeywordType.DataType));
            keywords.Add(new Keyword("boolean", KeywordType.DataType)); keywords.Add(new Keyword("long", KeywordType.DataType));
            keywords.Add(new Keyword("date", KeywordType.DataType)); keywords.Add(new Keyword("int", KeywordType.DataType));
            keywords.Add(new Keyword("char", KeywordType.DataType)); keywords.Add(new Keyword("integer", KeywordType.DataType));
            keywords.Add(new Keyword("number", KeywordType.DataType)); keywords.Add(new Keyword("varchar2", KeywordType.DataType));
            keywords.Add(new Keyword("cursor", KeywordType.DataType)); keywords.Add(new Keyword("binary_integer", KeywordType.DataType));



            //function
            keywords.Add(new Keyword("to_char", KeywordType.Function)); keywords.Add(new Keyword("Count", KeywordType.Function));
            keywords.Add(new Keyword("to_date", KeywordType.Function)); keywords.Add(new Keyword("max", KeywordType.Function));
            keywords.Add(new Keyword("min", KeywordType.Function)); keywords.Add(new Keyword("sum", KeywordType.Function));
            keywords.Add(new Keyword("avg", KeywordType.Function)); keywords.Add(new Keyword("rtrim", KeywordType.Function));
            keywords.Add(new Keyword("ltrim", KeywordType.Function)); keywords.Add(new Keyword("lpad", KeywordType.Function));
            keywords.Add(new Keyword("rpad", KeywordType.Function)); keywords.Add(new Keyword("Count", KeywordType.Function));
            keywords.Add(new Keyword("mod", KeywordType.Function)); keywords.Add(new Keyword("to_number", KeywordType.Function));
            keywords.Add(new Keyword("to_months", KeywordType.Function)); keywords.Add(new Keyword("concat", KeywordType.Function));
            keywords.Add(new Keyword("floor", KeywordType.Function)); keywords.Add(new Keyword("abs", KeywordType.Function));
            keywords.Add(new Keyword("trunc", KeywordType.Function)); keywords.Add(new Keyword("ceil", KeywordType.Function));
            keywords.Add(new Keyword("round", KeywordType.Function)); keywords.Add(new Keyword("Set Serveroutput on", KeywordType.Function));
            keywords.Add(new Keyword("Set Serveroutput on size", KeywordType.Function)); keywords.Add(new Keyword("put_line", KeywordType.Function));
            keywords.Add(new Keyword("length", KeywordType.Function)); keywords.Add(new Keyword("substr", KeywordType.Function));



            //operators
            keywords.Add(new Keyword("between", KeywordType.Operator)); keywords.Add(new Keyword("like", KeywordType.Operator)); keywords.Add(new Keyword("distinct", KeywordType.Operator));
            keywords.Add(new Keyword("not null", KeywordType.Operator)); keywords.Add(new Keyword("not", KeywordType.Operator));
            keywords.Add(new Keyword("to", KeywordType.Operator)); keywords.Add(new Keyword("on", KeywordType.Operator));
            keywords.Add(new Keyword("and", KeywordType.Operator)); keywords.Add(new Keyword("or", KeywordType.Operator)); keywords.Add(new Keyword("in", KeywordType.Operator)); keywords.Add(new Keyword(":=", KeywordType.Operator));
            keywords.Add(new Keyword("||", KeywordType.Operator)); keywords.Add(new Keyword("as", KeywordType.Operator)); keywords.Add(new Keyword("type", KeywordType.Operator)); keywords.Add(new Keyword("rowtype", KeywordType.Operator));
            keywords.Add(new Keyword("(+)", KeywordType.Operator));
            
            Language lang = new Language();
            lang.Keywords = keywords;
            lang.KeywordsColors[KeywordType.DataType] = System.Drawing.Color.DarkCyan;
            lang.KeywordsColors[KeywordType.Function] = System.Drawing.Color.Navy;
            lang.KeywordsColors[KeywordType.Reseved] = System.Drawing.Color.Blue;
            lang.KeywordsColors[KeywordType.Operator] = System.Drawing.Color.DarkOrange;
            lang.CommentsSymbol = "--";
            lang.CommentsColor = System.Drawing.Color.Green;
            lang.FirstQuotationsCharacter = '"';
            lang.SecondQuotationsCharacter = '\'';
            lang.QuotationsColor = System.Drawing.Color.Red;
            lang.KeywordsFont = TextArea.Font;
            lang.Rules = RichTextBoxFinds.WholeWord;
            languages.Add(SupportedLanguage.SQL, lang);
        }

        private void SetupADAList()
        {
            List<Keyword> keywords = new List<Keyword>();

            //reseved words
            
            keywords.Add(new Keyword("abort")); keywords.Add(new Keyword("new")); keywords.Add(new Keyword("elsif"));
            keywords.Add(new Keyword("abstract")); keywords.Add(new Keyword("accept")); keywords.Add(new Keyword("entry"));
            keywords.Add(new Keyword("reverse")); keywords.Add(new Keyword("access"));
            keywords.Add(new Keyword("exception")); keywords.Add(new Keyword("select")); keywords.Add(new Keyword("subtype"));
            keywords.Add(new Keyword("aliased")); keywords.Add(new Keyword("exit")); keywords.Add(new Keyword("interface"));
            keywords.Add(new Keyword("others")); keywords.Add(new Keyword("begin")); keywords.Add(new Keyword("end"));
            keywords.Add(new Keyword("if")); keywords.Add(new Keyword("loop")); keywords.Add(new Keyword("for"));
            keywords.Add(new Keyword("while")); keywords.Add(new Keyword("synchronized")); keywords.Add(new Keyword("else"));
            keywords.Add(new Keyword("overriding")); keywords.Add(new Keyword("tagged"));
            keywords.Add(new Keyword("null")); keywords.Add(new Keyword("return"));
            keywords.Add(new Keyword("generic")); keywords.Add(new Keyword("package")); keywords.Add(new Keyword("terminate"));
            keywords.Add(new Keyword("goto")); keywords.Add(new Keyword("function")); keywords.Add(new Keyword("procedure"));
            keywords.Add(new Keyword("pragma")); keywords.Add(new Keyword("body")); keywords.Add(new Keyword("private"));
            keywords.Add(new Keyword("protected")); keywords.Add(new Keyword("task")); keywords.Add(new Keyword("case"));
            keywords.Add(new Keyword("until")); keywords.Add(new Keyword("constant")); keywords.Add(new Keyword("all"));
            keywords.Add(new Keyword("raise")); keywords.Add(new Keyword("range")); keywords.Add(new Keyword("delay"));
            keywords.Add(new Keyword("limited"));keywords.Add(new Keyword("delta"));
            keywords.Add(new Keyword("type")); keywords.Add(new Keyword("do")); keywords.Add(new Keyword("rem"));
            keywords.Add(new Keyword("digits")); keywords.Add(new Keyword("renames")); keywords.Add(new Keyword("requeue"));
            keywords.Add(new Keyword("use")); keywords.Add(new Keyword("case")); keywords.Add(new Keyword("with"));

            //DataTypes
            keywords.Add(new Keyword("Integer", KeywordType.DataType)); keywords.Add(new Keyword("Float", KeywordType.DataType));
            keywords.Add(new Keyword("Long", KeywordType.DataType)); keywords.Add(new Keyword("Double", KeywordType.DataType));
            keywords.Add(new Keyword("Boolean", KeywordType.DataType));
            keywords.Add(new Keyword("String", KeywordType.DataType)); keywords.Add(new Keyword("Record", KeywordType.DataType));
            keywords.Add(new Keyword("Array", KeywordType.DataType));


            //operators
            keywords.Add(new Keyword("is", KeywordType.Operator)); keywords.Add(new Keyword("and", KeywordType.Operator)); keywords.Add(new Keyword(":=", KeywordType.Operator));
            keywords.Add(new Keyword("then", KeywordType.Operator)); keywords.Add(new Keyword("when", KeywordType.Operator)); keywords.Add(new Keyword("=>", KeywordType.Operator));
            keywords.Add(new Keyword("abs", KeywordType.Operator)); keywords.Add(new Keyword(">=", KeywordType.Operator));
            keywords.Add(new Keyword("and", KeywordType.Operator)); keywords.Add(new Keyword("or", KeywordType.Operator)); keywords.Add(new Keyword("in", KeywordType.Operator));
            keywords.Add(new Keyword("xor", KeywordType.Operator)); keywords.Add(new Keyword("mod", KeywordType.Operator)); keywords.Add(new Keyword("<=", KeywordType.Operator));
            keywords.Add(new Keyword("out", KeywordType.Operator)); keywords.Add(new Keyword("at", KeywordType.Operator)); keywords.Add(new Keyword("of", KeywordType.Operator));
            keywords.Add(new Keyword("Fore", KeywordType.Operator)); keywords.Add(new Keyword("Exp", KeywordType.Operator)); keywords.Add(new Keyword("Aft", KeywordType.Operator));
            keywords.Add(new Keyword("/=", KeywordType.Operator)); keywords.Add(new Keyword("Item", KeywordType.Operator)); keywords.Add(new Keyword("Width", KeywordType.Operator));

            //Functions
            keywords.Add(new Keyword("Put_Line", KeywordType.Function)); keywords.Add(new Keyword("Get", KeywordType.Function));
            keywords.Add(new Keyword("New_Line", KeywordType.Function)); keywords.Add(new Keyword("Put", KeywordType.Function));

            Language lang = new Language();
            lang.Keywords = keywords;
            lang.KeywordsColors[KeywordType.DataType] = System.Drawing.Color.DarkCyan;
            lang.KeywordsColors[KeywordType.Function] = System.Drawing.Color.Navy;
            lang.KeywordsColors[KeywordType.Reseved] = System.Drawing.Color.Blue;
            lang.KeywordsColors[KeywordType.Operator] = System.Drawing.Color.DarkOrange;
            lang.CommentsSymbol = "--";
            lang.CommentsColor = System.Drawing.Color.Green;
            lang.FirstQuotationsCharacter = '"';
            lang.SecondQuotationsCharacter = '\'';
            lang.QuotationsColor = System.Drawing.Color.Red;
            lang.KeywordsFont = TextArea.Font;
            lang.Rules = RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord;
            languages.Add(SupportedLanguage.Ada, lang);
        }

        private void SetupCPPList()
        {
            List<Keyword> keywords = new List<Keyword>();
            keywords.Add(new Keyword("#include")); keywords.Add(new Keyword("using")); keywords.Add(new Keyword("namespace"));
            keywords.Add(new Keyword("typedef")); keywords.Add(new Keyword("class")); keywords.Add(new Keyword("continue"));
            keywords.Add(new Keyword("struct")); keywords.Add(new Keyword("union")); keywords.Add(new Keyword("private"));
            keywords.Add(new Keyword("public")); keywords.Add(new Keyword("protected")); keywords.Add(new Keyword("return"));
            keywords.Add(new Keyword("delete")); keywords.Add(new Keyword("typename")); keywords.Add(new Keyword("tempalte"));
            keywords.Add(new Keyword("case")); keywords.Add(new Keyword("switch")); keywords.Add(new Keyword("default"));
             keywords.Add(new Keyword("#pragma")); keywords.Add(new Keyword("break"));keywords.Add(new Keyword("goto"));
            keywords.Add(new Keyword("for")); keywords.Add(new Keyword("while")); keywords.Add(new Keyword("do"));
            keywords.Add(new Keyword("if")); keywords.Add(new Keyword("else")); keywords.Add(new Keyword("#pragam warning"));
            keywords.Add(new Keyword("new")); keywords.Add(new Keyword("gcnew")); keywords.Add(new Keyword("abstract"));
            keywords.Add(new Keyword("enum")); keywords.Add(new Keyword("value class")); keywords.Add(new Keyword("value struct"));
            keywords.Add(new Keyword("ref class")); keywords.Add(new Keyword("virtual")); keywords.Add(new Keyword("const"));
            keywords.Add(new Keyword("#import")); keywords.Add(new Keyword("#using")); keywords.Add(new Keyword("sizeof"));
            keywords.Add(new Keyword("internal")); keywords.Add(new Keyword("extern")); keywords.Add(new Keyword("interface class"));
            keywords.Add(new Keyword("#managed")); keywords.Add(new Keyword("#unmanaged")); keywords.Add(new Keyword("ref struct"));
            keywords.Add(new Keyword("delegate")); keywords.Add(new Keyword("event")); keywords.Add(new Keyword("sealed"));
            keywords.Add(new Keyword("disable")); keywords.Add(new Keyword("#pragma push")); keywords.Add(new Keyword("#pragma pop"));
            keywords.Add(new Keyword("#define")); keywords.Add(new Keyword("#undef"));
            keywords.Add(new Keyword("#if")); keywords.Add(new Keyword("#elsif")); keywords.Add(new Keyword("static"));
            keywords.Add(new Keyword("#endif")); keywords.Add(new Keyword("#else")); keywords.Add(new Keyword("__delegate"));
            keywords.Add(new Keyword("static_cast")); keywords.Add(new Keyword("dynamic_cast")); keywords.Add(new Keyword("__try_cast"));
            keywords.Add(new Keyword("safe_cast")); keywords.Add(new Keyword("property")); keywords.Add(new Keyword("nullptr"));
            keywords.Add(new Keyword("override")); keywords.Add(new Keyword("operator")); keywords.Add(new Keyword("__box"));
            keywords.Add(new Keyword("__try")); keywords.Add(new Keyword("__finally")); keywords.Add(new Keyword("generic"));
            keywords.Add(new Keyword("where")); keywords.Add(new Keyword("for each")); keywords.Add(new Keyword("initonly"));
            keywords.Add(new Keyword("__declspec")); keywords.Add(new Keyword("__clrcall")); keywords.Add(new Keyword("__stdcall"));
            keywords.Add(new Keyword("_stdcall")); keywords.Add(new Keyword("__fastcall")); keywords.Add(new Keyword("_fastcall"));
            keywords.Add(new Keyword("reinterpret_cast")); keywords.Add(new Keyword("const_cast"));
            keywords.Add(new Keyword("__unaligned")); keywords.Add(new Keyword("volatile"));
            keywords.Add(new Keyword("__assume")); keywords.Add(new Keyword("__based")); keywords.Add(new Keyword("__cdecl")); 
            keywords.Add(new Keyword("default")); keywords.Add(new Keyword("deprecated")); keywords.Add(new Keyword("dllimport"));
            keywords.Add(new Keyword("dllexport")); keywords.Add(new Keyword("__event")); keywords.Add(new Keyword("__except"));
            keywords.Add(new Keyword("explicit")); keywords.Add(new Keyword("true")); keywords.Add(new Keyword("false"));
            keywords.Add(new Keyword("finally")); keywords.Add(new Keyword("__gc")); keywords.Add(new Keyword("__hook"));
            keywords.Add(new Keyword("forceinline"));keywords.Add(new Keyword("template"));
            keywords.Add(new Keyword("__if_exists")); keywords.Add(new Keyword("inline")); keywords.Add(new Keyword("frind"));
            keywords.Add(new Keyword("frind as")); keywords.Add(new Keyword("__if_not_exists")); keywords.Add(new Keyword("__inline"));
            keywords.Add(new Keyword("__interface")); keywords.Add(new Keyword("__single_inheritance")); keywords.Add(new Keyword("__multiple_inheritance"));
            keywords.Add(new Keyword("mutable")); keywords.Add(new Keyword("naked")); keywords.Add(new Keyword("__nogc"));
            keywords.Add(new Keyword("__property")); keywords.Add(new Keyword("noinline")); keywords.Add(new Keyword("__noop"));
            keywords.Add(new Keyword("noreturn")); keywords.Add(new Keyword("nothrow")); keywords.Add(new Keyword("novtable"));
            keywords.Add(new Keyword("__pin")); keywords.Add(new Keyword("__raise")); keywords.Add(new Keyword("register"));
            keywords.Add(new Keyword("__sealed")); keywords.Add(new Keyword("selectany")); keywords.Add(new Keyword("__super"));
            keywords.Add(new Keyword("__unhook")); keywords.Add(new Keyword("__value"));


            keywords.Add(new Keyword("void", KeywordType.DataType)); keywords.Add(new Keyword("int", KeywordType.DataType));
            keywords.Add(new Keyword("double", KeywordType.DataType)); keywords.Add(new Keyword("unsigned", KeywordType.DataType));
            keywords.Add(new Keyword("float", KeywordType.DataType)); keywords.Add(new Keyword("long", KeywordType.DataType));
            keywords.Add(new Keyword("short", KeywordType.DataType)); keywords.Add(new Keyword("bool", KeywordType.DataType));
            keywords.Add(new Keyword("String", KeywordType.DataType)); keywords.Add(new Keyword("char", KeywordType.DataType));
            keywords.Add(new Keyword("__int32", KeywordType.DataType)); keywords.Add(new Keyword("__int8", KeywordType.DataType));
            keywords.Add(new Keyword("__int16", KeywordType.DataType)); keywords.Add(new Keyword("__int64", KeywordType.DataType));
            keywords.Add(new Keyword("__int128", KeywordType.DataType)); keywords.Add(new Keyword("wchar_t", KeywordType.DataType));
            keywords.Add(new Keyword("array", KeywordType.DataType)); keywords.Add(new Keyword("literal",KeywordType.DataType));
            keywords.Add(new Keyword("interior_ptr", KeywordType.DataType)); keywords.Add(new Keyword("pin_ptr", KeywordType.DataType));
            keywords.Add(new Keyword("__identifier", KeywordType.DataType)); keywords.Add(new Keyword("signed", KeywordType.DataType));
            keywords.Add(new Keyword("__m129i", KeywordType.DataType)); keywords.Add(new Keyword("__m64", KeywordType.DataType));
            keywords.Add(new Keyword("_m128", KeywordType.DataType)); keywords.Add(new Keyword("__m128d", KeywordType.DataType));
            keywords.Add(new Keyword("__w64", KeywordType.DataType)); keywords.Add(new Keyword("__wchar_t", KeywordType.DataType));

            
            keywords.Add(new Keyword("sizeof", KeywordType.Operator)); keywords.Add(new Keyword("cout", KeywordType.Operator));
            keywords.Add(new Keyword("cin", KeywordType.Operator)); keywords.Add(new Keyword("endl", KeywordType.Operator));
            keywords.Add(new Keyword("typeid", KeywordType.Operator)); keywords.Add(new Keyword("__alignof", KeywordType.Operator));

            keywords.Add(new Keyword("main", KeywordType.Function)); keywords.Add(new Keyword("_tmain", KeywordType.Function));
            keywords.Add(new Keyword("tmain", KeywordType.Function)); keywords.Add(new Keyword("dllmain", KeywordType.Function));
            keywords.Add(new Keyword("printf", KeywordType.Function));
            

            Language lang = new Language();
            lang.Keywords = keywords;
            lang.KeywordsColors[KeywordType.DataType] = System.Drawing.Color.DarkCyan;
            lang.KeywordsColors[KeywordType.Function] = System.Drawing.Color.Navy;
            lang.KeywordsColors[KeywordType.Reseved] = System.Drawing.Color.Blue;
            lang.KeywordsColors[KeywordType.Operator] = System.Drawing.Color.DarkOrange;
            lang.CommentsSymbol = "//";
            lang.CommentsColor = System.Drawing.Color.Green;
            lang.FirstQuotationsCharacter = '"';
            lang.SecondQuotationsCharacter = '\'';
            lang.QuotationsColor = System.Drawing.Color.Red;
            lang.KeywordsFont = TextArea.Font;
            lang.Rules = RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord;
            languages.Add(SupportedLanguage.CPP, lang);
        }

        private void SetupCSList()
        {
            List<Keyword> keywords = new List<Keyword>();
            keywords.Add(new Keyword("var")); keywords.Add(new Keyword("using")); keywords.Add(new Keyword("namespace"));
            keywords.Add(new Keyword("struct")); keywords.Add(new Keyword("private")); keywords.Add(new Keyword("class"));
            keywords.Add(new Keyword("public")); keywords.Add(new Keyword("protected")); keywords.Add(new Keyword("return"));
            keywords.Add(new Keyword("switch")); keywords.Add(new Keyword("object")); keywords.Add(new Keyword("case"));
            keywords.Add(new Keyword("for")); keywords.Add(new Keyword("while")); keywords.Add(new Keyword("do"));
            keywords.Add(new Keyword("break;")); keywords.Add(new Keyword("continue")); keywords.Add(new Keyword("override"));
            keywords.Add(new Keyword("if")); keywords.Add(new Keyword("else")); keywords.Add(new Keyword("select"));
            keywords.Add(new Keyword("virtual")); keywords.Add(new Keyword("new")); keywords.Add(new Keyword("static"));
            keywords.Add(new Keyword("this")); keywords.Add(new Keyword("stackalloc")); keywords.Add(new Keyword("#region"));
            keywords.Add(new Keyword("#if")); keywords.Add(new Keyword("#endregion")); keywords.Add(new Keyword("throw"));
            keywords.Add(new Keyword("try")); keywords.Add(new Keyword("catch")); keywords.Add(new Keyword("finally"));
            keywords.Add(new Keyword("interface")); keywords.Add(new Keyword("abstract"));keywords.Add(new Keyword("sealed"));
            keywords.Add(new Keyword("get {")); keywords.Add(new Keyword("set {")); keywords.Add(new Keyword("set;"));
            keywords.Add(new Keyword("get;")); keywords.Add(new Keyword("enum")); keywords.Add(new Keyword("const"));
            keywords.Add(new Keyword("readonly")); keywords.Add(new Keyword("internal")); keywords.Add(new Keyword("extern"));
            keywords.Add(new Keyword("unsafe")); keywords.Add(new Keyword("checked")); keywords.Add(new Keyword("unchecked"));
            keywords.Add(new Keyword("delegate")); keywords.Add(new Keyword("event")); keywords.Add(new Keyword("volatile"));
            keywords.Add(new Keyword("true")); keywords.Add(new Keyword("false"));
            
            keywords.Add(new Keyword("void",KeywordType.DataType)); keywords.Add(new Keyword("int",KeywordType.DataType));
            keywords.Add(new Keyword("double", KeywordType.DataType)); keywords.Add(new Keyword("ulong", KeywordType.DataType));
            keywords.Add(new Keyword("float",KeywordType.DataType)); keywords.Add(new Keyword("long",KeywordType.DataType));
            keywords.Add(new Keyword("short",KeywordType.DataType)); keywords.Add(new Keyword("bool",KeywordType.DataType));
            keywords.Add(new Keyword("string", KeywordType.DataType)); keywords.Add(new Keyword("uint", KeywordType.DataType));
            keywords.Add(new Keyword("ushort", KeywordType.DataType)); keywords.Add(new Keyword("char", KeywordType.DataType));
            keywords.Add(new Keyword("byte", KeywordType.DataType));
           
            keywords.Add(new Keyword("ascending", KeywordType.Operator)); keywords.Add(new Keyword("descending", KeywordType.Operator));
            keywords.Add(new Keyword("in", KeywordType.Operator)); keywords.Add(new Keyword("as", KeywordType.Operator));
            keywords.Add(new Keyword("is", KeywordType.Operator)); keywords.Add(new Keyword("from", KeywordType.Operator));
            keywords.Add(new Keyword("sizeof", KeywordType.Operator)); keywords.Add(new Keyword("typeof", KeywordType.Operator));

            
            Language lang = new Language();
            lang.Keywords = keywords;
            lang.KeywordsColors[KeywordType.DataType] = System.Drawing.Color.DarkCyan;
            lang.KeywordsColors[KeywordType.Function] = System.Drawing.Color.Navy;
            lang.KeywordsColors[KeywordType.Reseved] = System.Drawing.Color.Blue;
            lang.KeywordsColors[KeywordType.Operator] = System.Drawing.Color.DarkOrange;
            lang.CommentsColor = System.Drawing.Color.Green;
            lang.CommentsSymbol = "//";
            lang.FirstQuotationsCharacter = '"';
            lang.SecondQuotationsCharacter = '\'';
            lang.QuotationsColor = System.Drawing.Color.Red;
            lang.KeywordsFont = TextArea.Font;
            lang.Rules = RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord;
            languages.Add(SupportedLanguage.CS, lang);
        }

        private void SetupJavaList()
        {

            List<Keyword> keywords = new List<Keyword>();
            keywords.Add(new Keyword("instanceof")); keywords.Add(new Keyword("import")); keywords.Add(new Keyword("class"));
            keywords.Add(new Keyword("final")); keywords.Add(new Keyword("private"));
            keywords.Add(new Keyword("public")); keywords.Add(new Keyword("protected")); keywords.Add(new Keyword("return"));
            keywords.Add(new Keyword("switch")); keywords.Add(new Keyword("static")); keywords.Add(new Keyword("case"));
            keywords.Add(new Keyword("for")); keywords.Add(new Keyword("while")); keywords.Add(new Keyword("do"));
            keywords.Add(new Keyword("break")); keywords.Add(new Keyword("continue")); keywords.Add(new Keyword("goto"));
            keywords.Add(new Keyword("if")); keywords.Add(new Keyword("else")); keywords.Add(new Keyword("new"));
            keywords.Add(new Keyword("this")); keywords.Add(new Keyword("synchronized"));
            keywords.Add(new Keyword("try")); keywords.Add(new Keyword("catch")); keywords.Add(new Keyword("finally"));
            keywords.Add(new Keyword("throw")); keywords.Add(new Keyword("throws")); keywords.Add(new Keyword("interface"));
            keywords.Add(new Keyword("abstract")); keywords.Add(new Keyword("assert"));
            keywords.Add(new Keyword("true")); keywords.Add(new Keyword("false")); keywords.Add(new Keyword("super"));
            keywords.Add(new Keyword("implements")); keywords.Add(new Keyword("extends")); keywords.Add(new Keyword("enum"));

            keywords.Add(new Keyword("void", KeywordType.DataType)); keywords.Add(new Keyword("int", KeywordType.DataType));
            keywords.Add(new Keyword("double", KeywordType.DataType));keywords.Add(new Keyword("byte", KeywordType.DataType));
            keywords.Add(new Keyword("float", KeywordType.DataType)); keywords.Add(new Keyword("long", KeywordType.DataType));
            keywords.Add(new Keyword("short", KeywordType.DataType)); keywords.Add(new Keyword("boolean", KeywordType.DataType));
            keywords.Add(new Keyword("String", KeywordType.DataType));keywords.Add(new Keyword("char", KeywordType.DataType));
            
            

            keywords.Add(new Keyword("main", KeywordType.Function));

            Language lang = new Language();
            lang.Keywords = keywords;
            lang.KeywordsColors[KeywordType.DataType] = System.Drawing.Color.DarkCyan;
            lang.KeywordsColors[KeywordType.Function] = System.Drawing.Color.Navy;
            lang.KeywordsColors[KeywordType.Reseved] = System.Drawing.Color.Blue;
            lang.KeywordsColors[KeywordType.Operator] = System.Drawing.Color.DarkOrange;
            lang.CommentsSymbol = "//";
            lang.CommentsColor = System.Drawing.Color.Green;
            lang.FirstQuotationsCharacter = '"';
            lang.SecondQuotationsCharacter = '\'';
            lang.QuotationsColor = System.Drawing.Color.Red;
            lang.KeywordsFont = TextArea.Font;
            lang.Rules = RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord;
            languages.Add(SupportedLanguage.Java, lang);
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            switch (((System.Windows.Forms.ToolStripMenuItem)sender).MergeIndex)
            {
                case 1:
                    //open
                    OpenFileDialogBox.Multiselect = false;
                    OpenFileDialogBox.Filter = "Sql files (*.sql)|*.sql|C++ files (*.cpp;*.h;*.c)|*.cpp;*.h;*.c|C# files (*.cs)|*.cs|Java files (*.java)|*.java|Ada files (*.ada)|*.ada|Secure Codes (*.scf)|*.scf|All Files (*.*)|*.*";
                    if (OpenFileDialogBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.UseWaitCursor = true;
                        SetupTextAreaFromFile(OpenFileDialogBox.FileName);
                        this.UseWaitCursor = false;
                    }
                    break;
                case 2:
                    SaveFileDialogBox.Title = "Save File";
                    switch (currentLanguage)
                    {
                        case SupportedLanguage.Ada:
                            SaveFileDialogBox.Filter = "Ada files (*.ada)|*.ada|Secure Codes (*.scf)|*.scf";
                            break;
                        case SupportedLanguage.SQL:
                            SaveFileDialogBox.Filter = "Sql files (*.sql)|*.sql|Secure Codes (*.scf)|*.scf";
                            break;
                        case SupportedLanguage.Java:
                            SaveFileDialogBox.Filter = "Java files (*.java)|*.java|Secure Codes (*.scf)|*.scf";
                            break;
                        case SupportedLanguage.CPP:
                            SaveFileDialogBox.Filter = "C++ files (*.cpp;*.h;*.c)|*.cpp;*.h;*.c|Secure Codes (*.scf)|*.scf";
                            break;
                        case SupportedLanguage.CS:
                            SaveFileDialogBox.Filter = "C# files (*.cs)|*.cs|Secure Codes (*.scf)|*.scf";
                            break;
                    }
                    if (SaveFileDialogBox.FileName.Trim() == string.Empty)
                    {
                        if (SaveFileDialogBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            Text = SaveFileDialogBox.FileName;
                            if (System.IO.Path.GetExtension(SaveFileDialogBox.FileName).Equals(".scf", StringComparison.OrdinalIgnoreCase))
                            {
                                GetPasswordForm form = new GetPasswordForm(string.Empty,false);
                                form.ShowDialog();
                                SecureCodeFormat.Save(SaveFileDialogBox.FileName, TextArea.Text, form.Text, currentLanguage);
                                form.Text = "";
                            }
                            else
                            {
                                System.IO.StreamWriter sw = new System.IO.StreamWriter(SaveFileDialogBox.FileName);
                                sw.Write(TextArea.Text);
                                sw.Close();
                            }
                        }
                    }
                    else
                    {
                        if (System.IO.Path.GetExtension(SaveFileDialogBox.FileName).Equals(".scf", StringComparison.OrdinalIgnoreCase))
                        {
                            SecureCodeFormat.Save(SaveFileDialogBox.FileName, TextArea.Text,SecureCodeFormat.GetPassword(SaveFileDialogBox.FileName), currentLanguage);
                        }
                        else
                        {
                            System.IO.StreamWriter sw = new System.IO.StreamWriter(SaveFileDialogBox.FileName);
                            sw.Write(TextArea.Text);
                            sw.Close();
                        }
                    }
                    break;
                case 3:
                    SaveFileDialogBox.Title = "Save As";
                    SaveFileDialogBox.Filter = "Sql files (*.sql)|*.sql|C++ files (*.cpp;*.h;*.c)|*.cpp;*.h;*.c|C# files (*.cs)|*.cs|Java files (*.java)|*.java|Ada files (*.ada)|*.ada|Secure Codes (*.scf)|*.scf|All Files (*.*)|*.*";
                    if (SaveFileDialogBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Text = SaveFileDialogBox.FileName;
                        if (System.IO.Path.GetExtension(SaveFileDialogBox.FileName).Equals(".scf", StringComparison.OrdinalIgnoreCase))
                        {
                            GetPasswordForm form = new GetPasswordForm(string.Empty, false);
                            form.ShowDialog();
                            SecureCodeFormat.Save(SaveFileDialogBox.FileName, TextArea.Text, form.Text, currentLanguage);
                            form.Text = "";
                        }
                        else
                        {
                            System.IO.StreamWriter sw = new System.IO.StreamWriter(SaveFileDialogBox.FileName);
                            sw.Write(TextArea.Text);
                            sw.Close();
                        }
                    }
                    break;
                case 4:
                    System.Windows.Forms.Application.ExitThread();
                    break;
                case 5:
                    
                    if(TextArea.SelectedText != null)
                        TextArea.Copy();
                    break;
                case 6:
                    if (TextArea.SelectedText != null)
                        TextArea.Copy();
                    TextArea.SelectedText = string.Empty;
                    break;
                case 7:
                    TextArea.SelectedText = string.Empty;
                    break;
                case 8:
                    TextArea.PasteText(System.Windows.Forms.Clipboard.GetText());
                    break;
                case 9:
                    if (GetFont.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        TextArea.Font = GetFont.Font;
                    break;
                case 10:
                    
                    GetColor.Color = TextArea.ForeColor;
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        TextArea.ForeColor = GetColor.Color;
                    break;
                case 11:
                    GetColor.Color = TextArea.BackColor;
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        TextArea.BackColor = GetColor.Color;
                    break;
                case 12:
                    GetColor.Color = TextArea.ResevedColor;
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        if (GetColor.Color != TextArea.ForeColor)
                        {
                            TextArea.ResevedColor = GetColor.Color;
                            settings.Languages[currentLanguage].KeywordsColors[KeywordType.Reseved] = GetColor.Color;
                            TextArea.ResetColors();
                        }
                    break;
                case 13:
                    GetFont.Font = TextArea.KeywordsFont;
                    if (GetFont.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        TextArea.KeywordsFont = GetFont.Font;
                        settings.Languages[SupportedLanguage.SQL].KeywordsFont = GetFont.Font;
                        TextArea.ResetColors();
                    }
                    break;
                case 14:
                case 15:
                case 16:
                case 17:
                case 23:
                    TextArea.StopColoring = false;
                    UncheckAll();
                    ((ToolStripMenuItem)sender).Checked = true;
                    currentLanguage = (SupportedLanguage)((System.Windows.Forms.ToolStripMenuItem)sender).MergeIndex;
                    SetupTextArea();
                    break;
                case 18:
                    GetColor.Color = TextArea.CommentsColor;
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        if (GetColor.Color != TextArea.ForeColor)
                        {
                            TextArea.CommentsColor = GetColor.Color;
                            settings.Languages[currentLanguage].CommentsColor = GetColor.Color;
                            TextArea.ResetColors();
                        }
                    break;
                case 19:
                    GetColor.Color = TextArea.QuotationColor;
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        if (GetColor.Color != TextArea.ForeColor)
                        {
                            TextArea.QuotationColor = GetColor.Color;
                            settings.Languages[currentLanguage].QuotationsColor = GetColor.Color;
                            TextArea.ResetColors();
                        }
                    break;
                case 20:
                    GetColor.Color = TextArea.FunctionColor;
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        if (GetColor.Color != TextArea.ForeColor)
                        {
                            TextArea.FunctionColor = GetColor.Color;
                            settings.Languages[currentLanguage].KeywordsColors[KeywordType.Function] = GetColor.Color;
                            TextArea.ResetColors();
                        }
                    break;
                case 21:
                    GetColor.Color = TextArea.OperatorColor;
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        if (GetColor.Color != TextArea.ForeColor)
                        {
                            TextArea.OperatorColor = GetColor.Color;
                            settings.Languages[currentLanguage].KeywordsColors[KeywordType.Operator] = GetColor.Color;
                            TextArea.ResetColors();
                        }
                    break;

                case 24:
                    GetColor.Color = TextArea.DataTypeColor;
                    if (GetColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        if (GetColor.Color != TextArea.ForeColor)
                        {
                            TextArea.DataTypeColor = GetColor.Color;
                            settings.Languages[currentLanguage].KeywordsColors[KeywordType.DataType] = GetColor.Color;
                            TextArea.ResetColors();
                        }
                    break;

                case 25:
                    ResetCurrentLanguage();
                    TextArea.ResetColors();
                    break;

                case 22:
                    AboutWindow about = new AboutWindow();
                    about.ShowDialog();
                    break;

                case 26:
                    ResetCurrentLanguage();
                    TextArea.ResetColors();
                    break;
                case 27:
                    SettingsEditor ed = new SettingsEditor(ref settings);
                    ed.ShowDialog();
                    SetupTextArea();
                    break;
                case 28:
                    UncheckAll();
                    NoneMenuItem.Checked = true;
                    int selection = TextArea.SelectionStart;
                    int length = TextArea.SelectionLength;
                    TextArea.StopColoring = true;
                    TextArea.PaintControl = false;
                    TextArea.SelectAll();
                    TextArea.SelectionColor = TextArea.ForeColor;
                    TextArea.SelectionFont = TextArea.Font;
                    TextArea.SelectionLength = length;
                    TextArea.SelectionStart = selection;
                    TextArea.PaintControl = true;

                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }




    }
}
