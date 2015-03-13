using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Readability_Test_Tool
{
    public partial class ReportForm : Form
    {
        private int numberOfZeroValues = 0;
        private int numberOfNoneZeroValues = 0;
        //private CodeDetails _details;
        Dictionary<string, double> readbility;
        public ReportForm(string title, double[] wig, ref CodeDetails details)
        {
            InitializeComponent();
            this.Text = "The File : ( " + title + " ) Readability Test Result";
            label51.Text = "File Name : " + System.IO.Path.GetFileNameWithoutExtension(title);
            wights = wig;
            //_details = details;
            try
            {
                recursive_functions_count = details.RecursiveFunctions;
            }        
            catch { }
                //System.Windows.Forms.MessageBox.Show("1");
            try
            {
                arithmetic_formulas_count = details.ArithmaticFormuls;
            }
            catch { }
                // System.Windows.Forms.MessageBox.Show("2");
            try
            {
                inheritance_count = details.Inheritance;
            }
            catch { }
                // System.Windows.Forms.MessageBox.Show("3");
            try
            {
                if (details.Loops != null)
                    nested_loops_value = details.Loops.ReadabilityOfTheNestedLoops.NestedLoopValue;
                // System.Windows.Forms.MessageBox.Show("4");
                if (details.Loops != null)
                    do_while_count = details.Loops.ReadabilityOfTheNestedLoops.DoWhileLoopsValue;
                // System.Windows.Forms.MessageBox.Show("5");
                if (details.Loops != null)
                    for_count = details.Loops.ReadabilityOfTheNestedLoops.ForLoopsValue;
                // System.Windows.Forms.MessageBox.Show("6");
                if (details.Loops != null)
                    while_count = details.Loops.ReadabilityOfTheNestedLoops.WhileLoopsValue;
            }
            catch { }
                // System.Windows.Forms.MessageBox.Show("7");
            try
            {
                comments_count = details.Comments;
            }
            catch { }
                // System.Windows.Forms.MessageBox.Show("8");
            try
            {
                classes_count = details.Classes;
            }
            catch { }
                // System.Windows.Forms.MessageBox.Show("9");
            try
            {
                length_of_each_line_count = details.LengthOfLines;
            }
            catch { }
                // System.Windows.Forms.MessageBox.Show("10");
            try
            {
                white_lines_count = details.Spacing;
                // System.Windows.Forms.MessageBox.Show("11");
                indents_count = details.Indents;
                // System.Windows.Forms.MessageBox.Show("12");
                switch_count = details.Switch;
                // System.Windows.Forms.MessageBox.Show("13");
                short_scopes_count = details.Scopes;
                // System.Windows.Forms.MessageBox.Show("14");
                polymorphisms_count = details.Polymorphism;
                // System.Windows.Forms.MessageBox.Show("15");
                arrays_count = details.Arrays;
                // System.Windows.Forms.MessageBox.Show("16");
                meaningful_names_count = details.MeaningfulValue;
                // System.Windows.Forms.MessageBox.Show("17");
                identifier_name_length_count = details.IdentifiersLength;
                // System.Windows.Forms.MessageBox.Show("18");
                identifiers_frequency = details.IdentifiersFrequency;
                // System.Windows.Forms.MessageBox.Show("19");
                consistency_count = details.Consistancy;
                // System.Windows.Forms.MessageBox.Show("20");
                nested_if_count = details.NestedIfValue;
                // System.Windows.Forms.MessageBox.Show("21");
                iF_else_count = details.IFS;
            }
            catch { }
           // System.Windows.Forms.MessageBox.Show("22");
            //System.Windows.Forms.MessageBox.Show(details.Loops.ReadabilityOfTheNestedLoops.NumberOfWhileLoops.ToString(),"Code Volume");

        }
        //double spaceing_value = 0;
        double do_while_count = 0;
        double arithmetic_formulas_count = 0;
        double recursive_functions_count = 0;
        double for_count = 0;
        double length_of_each_line_count = 0;
        double nested_loops_value = 0;
        double comments_count = 0;
        double white_lines_count = 0;
        double indents_count = 0;
        double switch_count = 0;
        double short_scopes_count = 0;
        double polymorphisms_count = 0;
        double meaningful_names_count = 0;
        double identifier_name_length_count = 0;
        double iF_else_count = 0;
        double while_count = 0;
        double arrays_count = 0;
        double classes_count = 0;
        double inheritance_count = 0;
        double nested_if_count = 0;
        double identifiers_frequency = 0;
        double consistency_count = 0;
        private void Form3_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Load");
            readbility = new Dictionary<string, double>();
            readbility.Add("Meaningful Names", wights[0]);
            readbility.Add("Comments", wights[1]);
            readbility.Add("Indents", wights[2]);
            readbility.Add("Scopes", wights[3]);
            readbility.Add("Length Of Each Line", wights[4]);
            readbility.Add("Identifier Name Length", wights[5]);
            readbility.Add("Arithmetic Formulas", wights[6]);
            readbility.Add("Identifiers Frequency", wights[7]);
            readbility.Add("IF-Else", wights[8]);
            readbility.Add("Nested If", wights[9]);
            readbility.Add("Switchs", wights[10]);
            readbility.Add("For Loops", wights[11]);
            readbility.Add("While Loops", wights[12]);
            readbility.Add("Do While", wights[21]);//0.070123499
            readbility.Add("Nested Loops", wights[13]);
            readbility.Add("Recursive Functions", wights[14]);
            readbility.Add("Arrays", wights[15]);
            readbility.Add("Classes", wights[16]);
            readbility.Add("Inheritance", wights[17]);
            readbility.Add("Polymorphism", wights[18]);
            readbility.Add("Spacing", wights[19]);
            readbility.Add("Consistency", wights[20]);

            label38.Text = takesub((readbility["Meaningful Names"] * (meaningful_names_count)).ToString());

            label4.Text = takesub((readbility["Comments"] * (comments_count)).ToString());

            label10.Text = takesub((readbility["Indents"] * (indents_count)).ToString());

            label6.Text = takesub((readbility["Scopes"] * (short_scopes_count)).ToString());

            label22.Text = takesub((readbility["Length Of Each Line"] * (length_of_each_line_count)).ToString());

            label20.Text = takesub((readbility["Identifier Name Length"] * (identifier_name_length_count)).ToString());

            label18.Text = takesub((readbility["Arithmetic Formulas"] * (arithmetic_formulas_count)).ToString());

            label8.Text = takesub((readbility["Identifiers Frequency"] * (identifiers_frequency)).ToString());

            label14.Text = takesub((readbility["IF-Else"] * (iF_else_count)).ToString());

            label12.Text = takesub((readbility["Nested If"] * (nested_if_count)).ToString());

            label34.Text = takesub((readbility["Switchs"] * (switch_count)).ToString());

            label16.Text = takesub((readbility["Consistency"] * (consistency_count)).ToString());

            label32.Text = takesub((readbility["For Loops"] * (for_count)).ToString());

            label30.Text = takesub((readbility["While Loops"] * (while_count)).ToString());

            label26.Text = takesub((readbility["Nested Loops"] * nested_loops_value).ToString());

            label24.Text = takesub((readbility["Recursive Functions"] * (recursive_functions_count)).ToString());

            label47.Text = takesub((readbility["Arrays"] * (arrays_count)).ToString());

            label43.Text = takesub((readbility["Classes"] * (classes_count)).ToString());

            label41.Text = takesub((readbility["Inheritance"] * (inheritance_count)).ToString());

            label39.Text = takesub((readbility["Polymorphism"] * (polymorphisms_count)).ToString());

            label36.Text = takesub((readbility["Spacing"] * (white_lines_count)).ToString());

            label2.Text = takesub((readbility["Do While"] * (do_while_count)).ToString());


            double sum = 0.0;
            FormulateOutput();
            foreach (Control ctr in this.panel2.Controls)
            {
                if (ctr.TabIndex % 2 == 0)
                {
                    double value;
                    double.TryParse(ctr.Text, out value);
                    if (value >= 0)
                    {
                        if (value != 0)
                            numberOfNoneZeroValues++;
                        if (value == 0)
                            numberOfZeroValues++;
                        //if (ctr.TabIndex == 16 || ctr.TabIndex == 30 || ctr.TabIndex == 18 || ctr.TabIndex == 20)
                          //  sum += (1.0 - value);
                        //else
                            sum += value;

                    }
                }
                if (ctr.TabIndex == 55)
                {
                    double x;
                    double.TryParse(label10.Text, out x);
                    if (x == 0)
                    {
                        numberOfZeroValues++;
                        label10.Text = "Zero";
                        label10.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        numberOfNoneZeroValues++;
                        label10.ForeColor = Color.DarkGreen;
                    }
                }
            }
            if (label10.Text == "Zero")
                numberOfZeroValues++;
            else
                numberOfNoneZeroValues++;
            try
            {
                label56.Text = numberOfZeroValues.ToString();
                label57.Text = numberOfNoneZeroValues.ToString();
                if (numberOfNoneZeroValues == 0)
                    numberOfNoneZeroValues = 1;
                label49.Text = sum.ToString();
            }
            catch { }
            //label60.Text = sum.ToString();
            //label60.ForeColor = System.Drawing.Color.DarkBlue;
            CalculateZeros();
            SetupLabelMessages();
        }

        private void CalculateZeros()
        {
            int zeros = 0;
            double temp;
            int notZeros = 0;
            foreach (Control lable in panel2.Controls)
            {
                if (lable.TabIndex % 2 == 0)
                {
                    double.TryParse(lable.Text, out temp);
                    if (temp == 0.000)
                    {
                        zeros++;
                        lable.Text = "Zero";
                        lable.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        notZeros++;
                        lable.ForeColor = Color.DarkGreen;
                    }
                }
                label56.Text = zeros.ToString();
                label57.Text = notZeros.ToString();
            }
            if (recursive_functions_count == 0)
            {
                label24.Text = "Zero";
                label24.ForeColor = Color.DarkRed;
            }
            else
                if (recursive_functions_count == 1)
                {
                    label24.ForeColor = Color.DarkGreen;
                }
        }
        private void FormulateOutput()
        {
            foreach (Control ctr in this.panel2.Controls)
            {
                if (ctr.Name.StartsWith("label"))
                {
                    double num;
                    double.TryParse(ctr.Text, out num);
                    if (num != 0)
                    {
                        int i = ctr.Text.IndexOf('.');

                        try
                        {
                            if (!ctr.Text.Equals("NaN") && !ctr.Text.Equals("Infin") && !ctr.Text.Equals("0") && !ctr.Text.Equals("Inf"))
                            {
                                ctr.Text = ctr.Text.Substring(0, i + 4);
                                ctr.ForeColor = System.Drawing.Color.DarkGreen;
                            }
                            else
                            {
                                ctr.Text = "Zero";
                                ctr.ForeColor = System.Drawing.Color.DarkRed;
                                int x;
                                int.TryParse(label56.Text, out x);
                                x++;
                                label56.Text = x.ToString();
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        if (ctr.Text.Equals("NaN") || ctr.Text.Equals("Infin") || ctr.Text.Equals("0") || ctr.Text.Equals("Inf"))
                        {
                            ctr.Text = "Zero";
                            int x;
                            int.TryParse(label56.Text, out x);
                            x++;
                            label56.Text = x.ToString();
                            ctr.ForeColor = System.Drawing.Color.DarkRed;
                        }
                    }
                }
            }
        }
        public double getlabelValue(string label)
        {
            try
            {
                return double.Parse(label);
            }
            catch
            {
                return 0.0;
            }
        }
        public string takesub(string x)
        {
            try
            {
                return x.Substring(0, 5);
            }
            catch { return x; }
        }

        private void label49_TextChanged(object sender, EventArgs e)
        {
            double x;
            int unknown;
            //double.TryParse(label49.Text.Substring(0, label49.Text.IndexOf('%')), out x);
            double.TryParse(label49.Text, out x);
            unknown = (int)x;
            if (unknown > 0 && unknown <= 4)
            {
                panel1.BackgroundImage = global::Readability_Test_Tool.Properties.Resources._25P;
                //label52.Text = "Hard To Read";
                label52.ForeColor = System.Drawing.Color.DarkRed;
            }
            else
                if (unknown > 4 && unknown <= 8)
                {
                    panel1.BackgroundImage = global::Readability_Test_Tool.Properties.Resources._50P;
                    //label52.Text = "Hard To Read";
                    label52.ForeColor = System.Drawing.Color.DarkRed;
                }
                else
                    if (unknown > 8 && unknown <= 12)
                    {
                        panel1.BackgroundImage = global::Readability_Test_Tool.Properties.Resources._75P;
                        // label52.Text = "Easy To Read";
                        label52.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                    else
                        if (unknown > 12)
                        {
                            panel1.BackgroundImage = global::Readability_Test_Tool.Properties.Resources._100P;
                            //label52.Text = "Easy To Read";
                            label52.ForeColor = System.Drawing.Color.DarkGreen;
                        }
                        else
                        {
                            panel1.BackgroundImage = global::Readability_Test_Tool.Properties.Resources._0P;
                            //label52.Text = "No Readability";
                            label49.Text = "0";
                            label52.ForeColor = System.Drawing.Color.Black;
                        }
            label49.Location = new Point((panel1.Width / 2) - (label49.Text.Length * (int)label49.Font.Size / 2), label49.Location.Y);
        }
        System.Threading.Tasks.Task x;
        private void GetSrarted()
        {
            this.Height += 20;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height += 30;

            button1.Location = new Point(button1.Location.X, this.Height - 25 - button1.Height);
        }
        private void GetSrartedHide()
        {
            this.Height -= 20;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            for (int i = 0; i < 1000000; i++) ;
            this.Height -= 30;
            button1.Location = old;
        }
        bool show = false;
        Point old;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!show)
            {
                old = button1.Location;
                show = true;
                panel2.Visible = false;
                x = System.Threading.Tasks.Task.Factory.StartNew(GetSrarted);
                x.Wait();
                button1.Text = "Hide Details";
                panel2.Visible = true;
            }
            else
            {
                show = false;
                x = System.Threading.Tasks.Task.Factory.StartNew(GetSrartedHide);
                x.Wait();
                button1.Text = "Show Details";
            }
        }

        private void MouseEnterLabel(object o, EventArgs e)
        {
            ((Label)o).ForeColor = Color.DarkBlue;
            ((Label)o).Cursor = System.Windows.Forms.Cursors.Help;
        }
        private void MouseLeaveLabel(object o, EventArgs e)
        {
            if(((Label)o).Text != "Zero")
                ((Label)o).ForeColor = Color.DarkGreen;
            else
                ((Label)o).ForeColor = Color.DarkRed;
            ((Label)o).Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void MouseClickLabel(object o, EventArgs e)
        {
            MessageView view = new MessageView(Statics.Messages[((Label)o).TabIndex] + string.Format("\n\r\n\r The Final Value in The Report Is Multipled By {0} ", readbility[GetStringLabelText(((Label)o).TabIndex)]));
            view.Text = GetStringLabelText(((Label)o).TabIndex) +" Value Compution";
            view.ShowDialog();
        }
        private string GetStringLabelText(int index)
        {
            foreach (Control x in panel2.Controls)
            {
                if (x.TabIndex % 2 != 0)
                {
                    if (x.TabIndex == index - 1)
                        return x.Text;
                }
            }
            return "";
        }
        private void SetupLabelMessages()
        {
            
            if (!Statics.EnableMessages)
                return;
            foreach (Control x in panel2.Controls)
            {
                if (x is Label)
                {
                    if (x.TabIndex % 2 == 0)
                    {
                        if (Statics.Messages.ContainsKey(x.TabIndex))
                        {
                            x.MouseEnter += new EventHandler(MouseEnterLabel);
                            x.MouseLeave += new EventHandler(MouseLeaveLabel);
                            x.Click += new EventHandler(MouseClickLabel);
                        }
                    }
                }
            }

        }
    }
}
