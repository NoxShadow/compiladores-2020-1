using ScintillaNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiladores20201ProjetoCSharp.FrontEnd
{
    public class CompiladorControler
    {
        private readonly Scintilla codeEditor;
        private readonly TextBox messageTextBox;
        private readonly TextBox statusTextBox;
        private readonly OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            FileName = "Selecione um arquivo de texto",
            Filter = "Text files (*.txt)|*.txt",
            Title = "Selecione ou crie um arquivo de texto"
        };

        private string path = string.Empty;

        public CompiladorControler(Scintilla codeEditor, TextBox messageTextBox, TextBox statusTextBox)
        {
            this.codeEditor = codeEditor;
            this.messageTextBox = messageTextBox;
            this.statusTextBox = statusTextBox;
        }

        public void New()
        {
            codeEditor.Text = string.Empty;
            ClearMessage();
            ClearPath();
        }

        public void Open()
        {
            if (SelectFilePath())
            {
                try
                {
                    using (var sr = new StreamReader(openFileDialog.FileName))
                    {
                        OpenFile(sr);
                    }
                }
                catch (SecurityException ex)
                {
                    messageTextBox.Text = $"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}";
                }
            }
        }

        private bool SelectFilePath()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SetPath();

                return true;
            }

            return false;
        }

        private void OpenFile(StreamReader sr)
        {
            var code = sr.ReadToEnd();

            ClearMessage();

            codeEditor.Text = code;
        }

        private void SetPath()
        {
            path = openFileDialog.FileName;
            statusTextBox.Text = path;
        }

        public void Save()
        {
            if (!string.IsNullOrEmpty(path))
            {
                SaveFile();
                return;
            }
            if (SelectFilePath())
            {
                try
                {
                    SaveFile();
                }
                catch (SecurityException ex)
                {
                    messageTextBox.Text = $"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}";
                }
            }
        }

        private void SaveFile()
        {
            var code = codeEditor.Text;
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine(code);
            }

            ClearMessage();
        }

        public void Copy()
        {
            codeEditor.Copy();
        }

        public void Paste()
        {
            codeEditor.Paste();
        }

        public void Cut()
        {
            codeEditor.Cut();
        }

        public void Compile()
        {
            messageTextBox.Text = "compilação de programas ainda não foi implementada";
        }

        public void Team()
        {
            messageTextBox.Text =
@"Débora Cristine Reinert,
João Victor Braun Quintino,
Nathan Reikdal Cervieri";
        }

        private void ClearMessage()
        {
            messageTextBox.Text = string.Empty;
        }

        private void ClearPath()
        {
            statusTextBox.Text = string.Empty;
            path = string.Empty;
        }
    }
}
