using ScintillaNET;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Compiladores20201ProjetoCSharp
{
    public partial class MainLayout : Form
    {
        private const int BASE_WIDTH = 900;
        private const int BASE_TOOLBAR_BUTTON_WIDHT = 106;
        private const int BASE_TOOLBAR_BUTTON_HEIGHT = 63;
        private const int TOOLBAR_BUTTON_AMOUNT = 8;

        private int maxLineNumberCharLength;

        public MainLayout()
        {
            InitializeComponent();

            Resize += HandleResize;
        }

        private void HandleResize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            var newWidth = control.Size.Width;
            var widthDiference = newWidth - BASE_WIDTH;

            if (widthDiference % TOOLBAR_BUTTON_AMOUNT != 0)
            {
                widthDiference -= widthDiference % TOOLBAR_BUTTON_AMOUNT;
            }

            ResizeButtons(widthDiference);
        }

        private void ResizeButtons(int totalWidthDifference)
        {
            var offsetPerButton = totalWidthDifference / TOOLBAR_BUTTON_AMOUNT;

            var items = toolbar.Items;
            foreach (ToolStripItem item in items)
            {
                var newWidth = BASE_TOOLBAR_BUTTON_WIDHT + offsetPerButton;
                item.Size = new Size(newWidth, BASE_TOOLBAR_BUTTON_HEIGHT);
            }
        }

        private void HandleLineNumber(object sender, EventArgs e)
        {
            var scintilla = (Scintilla)sender;

            // Did the number of characters in the line number display change?
            // i.e. nnn VS nn, or nnnn VS nn, etc...
            var maxLineNumberCharLength = scintilla.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this.maxLineNumberCharLength)
                return;

            // Calculate the width required to display the last line number
            // and include some padding for good measure.
            const int padding = 2;
            scintilla.Margins[0].Width = scintilla.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            this.maxLineNumberCharLength = maxLineNumberCharLength;
        }

    }
}
