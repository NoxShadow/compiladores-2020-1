using Compiladores20201ProjetoCSharp.FrontEnd;
using ScintillaNET;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Compiladores20201ProjetoCSharp.FrontEnd
{
    public partial class MainLayout : Form
    {
        private const int BASE_WIDTH = 900;
        private const int BASE_TOOLBAR_BUTTON_WIDHT = 106;
        private const int BASE_TOOLBAR_BUTTON_HEIGHT = 63;
        private const int TOOLBAR_BUTTON_AMOUNT = 8;

        private readonly CompiladorControler controler;

        private int maxLineNumberCharLength;

        public MainLayout()
        {
            InitializeComponent();

            Resize += HandleResize;

            controler = new CompiladorControler(codeEditor, messageTextBox, statusTextBox);
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

        private void novoButton_Click(object sender, EventArgs e)
        {
            controler.New();
        }

        private void abrirButton_Click(object sender, EventArgs e)
        {
            controler.Open();
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            controler.Save();
        }

        private void copiarButton_Click(object sender, EventArgs e)
        {
            controler.Copy();
        }

        private void colarButton_Click(object sender, EventArgs e)
        {
            controler.Paste();
        }

        private void recortarButton_Click(object sender, EventArgs e)
        {
            controler.Cut();
        }

        private void equipeButton_Click(object sender, EventArgs e)
        {
            controler.Team();
        }

        private void compilarButton_Click(object sender, EventArgs e)
        {
            controler.Compile();
        }
    }
}
