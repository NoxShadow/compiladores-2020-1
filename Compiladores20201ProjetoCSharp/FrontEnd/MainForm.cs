﻿using Compiladores20201ProjetoCSharp.FrontEnd;
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
        private const int TOOLBAR_BUTTON_AMOUNT = 8;

        private readonly CompiladorControler controler;

        private int maxLineNumberCharLength;

        public MainLayout()
        {
            InitializeComponent();

            Resize += HandleResize;
            codeEditor.InsertCheck += BlackListCharacters;

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
                item.Size = new Size(newWidth, item.Size.Height);
            }
        }

        //Método copiado do guia da ferramente Scintilla
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

        private void MainLayout_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        controler.New();
                        break;
                    case Keys.O:
                        controler.Open();
                        break;
                    case Keys.S:
                        controler.Save();
                        break;
                }
            }
            else if (e.KeyCode == Keys.F9)
            {
                controler.Compile();
            }
            else if (e.KeyCode == Keys.F1)
            {
                controler.Team();
            }
        }

        private void BlackListCharacters(object sender, InsertCheckEventArgs e)
        {
            var blacklist = new string[3] { "\u000e", "\u000f", "\u0013" };

            foreach (var item in blacklist)
            {
                if (e.Text.Contains(item.ToString()))
                {
                    e.Text.Replace(item, "");
                }
                break;
            }

        }
    }
}
