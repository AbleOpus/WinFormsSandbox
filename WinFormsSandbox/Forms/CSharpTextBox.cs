using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using FastColoredTextBoxNS;

namespace WinFormsSandbox.Forms
{
    /// <summary>
    /// Represents a code-editor-styled text box control. Specifically used for C# code.
    /// </summary>
    class CSharpTextBox : FastColoredTextBox
    {
        private readonly TextStyle errorHighlightStyle = new TextStyle(Brushes.White, Brushes.Maroon, FontStyle.Regular);
        private int[] errorLines;

        public CSharpTextBox()
        {
            AddStyle(errorHighlightStyle);
            Language = Language.CSharp;
            base.Font = new Font("Consolas", 12f);
            LineNumberColor = Color.FromArgb(43, 145, 175);
            ShowFoldingLines = false;

            IndentBackColor = Color.White;
            base.BackColor = Color.White;
            base.ForeColor = Color.Black;
            CaretColor = Color.Black;
            ClearStyle(StyleIndex.All);
            SyntaxHighlighter.DarkTheme = false;
            SyntaxHighlighter.InitStyleSchema(Language);
            SyntaxHighlighter.HighlightSyntax(Language, Range);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SolidBrush brush = new SolidBrush(Color.FromArgb(90, 51, 152, 255));
            SelectionStyle = new SelectionStyle(brush);
        }

        protected override void OnTextChanged(TextChangedEventArgs args)
        {
            base.OnTextChanged(args);
            SetErrorLines(null);
            SyntaxHighlighter.CSharpSyntaxHighlight(Range);
        }

        /// <param name="disposing">true to release both managed and unmanaged resources; 
        /// false to release only unmanaged resources. </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                errorHighlightStyle.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Sets the error lines to highlight. This style is cleared once the text changes.
        /// </summary>
        public void SetErrorLines(int[] lines)
        {
            errorLines = lines;

            if (errorLines == null || errorLines.Length == 0)
            {
                Range.ClearStyle(errorHighlightStyle);
            }
            else
            {
                foreach (int errorLine in errorLines)
                {
                    // Value is offset around 1.
                    Range range = GetLine(errorLine - 1);
                    range.SetStyle(errorHighlightStyle);
                }
            }
        }
    }
}
