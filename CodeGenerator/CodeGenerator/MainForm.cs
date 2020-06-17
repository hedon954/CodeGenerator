using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using FastColoredTextBoxNS;
using ICSharpCode.TextEditor.Document;

namespace CodeGenerator
{
   
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        

        Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);


        private void fastColoredTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //clear style of changed range
            e.ChangedRange.ClearStyle(GreenStyle);
            //comment highlighting
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FastColoredTextBoxNS.Range range = new FastColoredTextBoxNS.Range(fastColoredTextBox1);
            fastColoredTextBox1.SyntaxHighlighter.CSharpSyntaxHighlight(range);

            fastColoredTextBox1.CollapseBlock(fastColoredTextBox1.Selection.Start.iLine,
               fastColoredTextBox1.Selection.End.iLine);
        }

        
    }
}
