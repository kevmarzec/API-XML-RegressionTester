using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using ScintillaNET;

namespace TestBuilder.Forms
{
    public partial class EditTest : Form
    {
        private Models.Test _test = null;

        public EditTest(Models.Test test = null)
        {
            InitializeComponent();

            _test = test;
            if(_test != null)
            {
                tbTitle.Text = _test.Name;
                tbCode.Text = _test.Script;
                Text = $"Edit Test: {_test.Name}";

                editParameters.SetParameters(test.Parameters.Select(p => (Models.Parameter)p).ToList());
            }
            
            // Configuring the default style with properties
            // we have common to every lexer style saves time.
            tbCode.StyleResetDefault();
            tbCode.Styles[Style.Default].Font = "Consolas";
            tbCode.Styles[Style.Default].Size = 10;
            tbCode.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            tbCode.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            tbCode.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            tbCode.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            tbCode.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            tbCode.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            tbCode.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            tbCode.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            tbCode.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            tbCode.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            tbCode.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            tbCode.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            tbCode.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            tbCode.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
            tbCode.Styles[Style.BraceLight].BackColor = Color.LightGray;
            tbCode.Styles[Style.BraceLight].ForeColor = Color.BlueViolet;
            tbCode.Styles[Style.BraceBad].ForeColor = Color.Red;

            tbCode.Lexer = Lexer.Cpp;
            tbCode.TextChanged += TbCode_TextChanged;
            tbCode.CharAdded += TbCode_CharAdded;
            tbCode.UpdateUI += TbCode_UpdateUI;

            // Set the keywords
            tbCode.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
            tbCode.SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void");
            
            TbCode_TextChanged(null, null);
        }

        int lastCaretPos = 0;

        private void TbCode_UpdateUI(object sender, UpdateUIEventArgs e)
        {
            // Has the caret changed position?
            var caretPos = tbCode.CurrentPosition;
            if (lastCaretPos != caretPos)
            {
                lastCaretPos = caretPos;
                var bracePos1 = -1;
                var bracePos2 = -1;

                // Is there a brace to the left or right?
                if (caretPos > 0 && IsBrace(tbCode.GetCharAt(caretPos - 1)))
                    bracePos1 = (caretPos - 1);
                else if (IsBrace(tbCode.GetCharAt(caretPos)))
                    bracePos1 = caretPos;

                if (bracePos1 >= 0)
                {
                    // Find the matching brace
                    bracePos2 = tbCode.BraceMatch(bracePos1);
                    if (bracePos2 == Scintilla.InvalidPosition)
                        tbCode.BraceBadLight(bracePos1);
                    else
                        tbCode.BraceHighlight(bracePos1, bracePos2);
                }
                else
                {
                    // Turn off brace matching
                    tbCode.BraceHighlight(Scintilla.InvalidPosition, Scintilla.InvalidPosition);
                }
            }
        }

        private static bool IsBrace(int c)
        {
            switch (c)
            {
                case '(':
                case ')':
                case '[':
                case ']':
                case '{':
                case '}':
                case '<':
                case '>':
                    return true;
            }

            return false;
        }

        private void TbCode_CharAdded(object sender, CharAddedEventArgs e)
        {
            // Find the word start
            var currentPos = tbCode.CurrentPosition;
            var wordStartPos = tbCode.WordStartPosition(currentPos, true);

            // Display the autocompletion list
            var lenEntered = currentPos - wordStartPos;
            if (lenEntered > 0)
            {
                if (!tbCode.AutoCActive)
                    tbCode.AutoCShow(lenEntered, "abstract as base break case catch checked continue default delegate Device do ECU else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override Parameter params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
            }
        }

        private int maxLineNumberCharLength;
        private void TbCode_TextChanged(object sender, EventArgs e)
        {
            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...
            var maxLineNumberCharLength = tbCode.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this.maxLineNumberCharLength)
                return;

            // Calculate the width required to display the last line number
            // and include some padding for good measure.
            const int padding = 2;
            tbCode.Margins[0].Width = tbCode.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            this.maxLineNumberCharLength = maxLineNumberCharLength;
        }

        public string TestName => tbTitle.Text.Trim();

        public string Script => tbCode.Text;

        public List<KeyValuePair<string, string>> Parameters => 
            editParameters
                .Parameters
                .ToList()
                .Select(p => new KeyValuePair<string, string>(p.Key, p.Value))
                .ToList();


        private void btnSave_Click(object sender, EventArgs e)
        {
            // validate
            if(tbTitle.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a title.");
                tbTitle.Focus();
                DialogResult = DialogResult.None;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void AddTest_Load(object sender, EventArgs e)
        {
            tbTitle.SelectAll();
            tbTitle.Focus();
        }
    }
}
