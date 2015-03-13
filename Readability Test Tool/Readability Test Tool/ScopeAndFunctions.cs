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
    public partial class ScopeAndFunctions : Form
    {
        System.Collections.Generic.Dictionary<int,FunctionDetails> details;
        public ScopeAndFunctions(string title,System.Collections.Generic.Dictionary<int ,FunctionDetails> fun)
        {
            InitializeComponent();
            this.Text = title;
            details = fun;
            SetupFunctionsDetails();
        }
        private string FixReturnType(string type)
        {
            type = type.Trim();
            if (type == "public" || type == "private" || type == "protected")
                return "No Type It \nIs Constractor";
            else
                if(type.Contains('('))
                    return "No Type It \nIs Constractor";
                else
                    return type;
        }
        private void SetupFunctionsDetails()
        {
            for (int i = 0; i < details.Count; i++)
            {
                FunctionsDetails.Rows.Add();
                if (details[i + 1].FunctionName.Trim() == "")
                {
                    details[i + 1].FunctionName = details[i + 1].FunctionReturnType;
                    details[i + 1].FunctionReturnType = "No Type It \nIs Constractor";
                }
                FunctionsDetails[0, i].Value = details[i + 1].FunctionName;
                if (details[i + 1].Static)
                    FunctionsDetails[1, i].Value = "Yes";
                else
                    FunctionsDetails[1, i].Value = "No";

                details[i + 1].FunctionReturnType = FixReturnType(details[i + 1].FunctionReturnType);

                FunctionsDetails[2, i].Value = details[i + 1].FunctionReturnType;
                if (details[i + 1].FunctionAccessModifier == null)
                    details[i + 1].FunctionAccessModifier = "public";
                FunctionsDetails[3, i].Value = details[i + 1].FunctionAccessModifier;

                if (details[i + 1].Recursive)
                    FunctionsDetails[4, i].Value = "Yes";
                else
                    FunctionsDetails[4, i].Value = "No";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
