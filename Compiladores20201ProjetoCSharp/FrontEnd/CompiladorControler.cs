﻿using Compiladores20201ProjetoCSharp.Compilador;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace Compiladores20201ProjetoCSharp.FrontEnd
{
    public class CompiladorControler
    {
        private readonly Scintilla CodeEditor;
        private readonly TextBox MessageTextBox;
        private readonly TextBox StatusTextBox;
        private readonly OpenFileDialog OpenFileDialog = new OpenFileDialog()
        {
            FileName = "Selecione um arquivo de texto",
            Filter = "Text files (*.txt)|*.txt",
            Title = "Selecione ou crie um arquivo de texto"
        };

        private string path = string.Empty;

        public CompiladorControler(Scintilla codeEditor, TextBox messageTextBox, TextBox statusTextBox)
        {
            CodeEditor = codeEditor;
            MessageTextBox = messageTextBox;
            StatusTextBox = statusTextBox;
        }

        public void New()
        {
            CodeEditor.Text = string.Empty;
            ClearMessage();
            ClearPath();
        }

        public void Open()
        {
            if (SelectFilePath())
            {
                try
                {
                    using (var sr = new StreamReader(OpenFileDialog.FileName))
                    {
                        OpenFile(sr);
                    }
                }
                catch (SecurityException ex)
                {
                    MessageTextBox.Text = $"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}";
                }
            }
        }

        private bool SelectFilePath()
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
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

            CodeEditor.Text = code;
        }

        private void SetPath()
        {
            path = OpenFileDialog.FileName;
            StatusTextBox.Text = path;
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
                    MessageTextBox.Text = $"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}";
                }
            }
        }

        private void SaveFile()
        {
            var code = CodeEditor.Text;
            using (StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine(code);
            }

            ClearMessage();
        }

        public void Copy()
        {
            CodeEditor.Copy();
        }

        public void Paste()
        {
            CodeEditor.Paste();
        }

        public void Cut()
        {
            CodeEditor.Cut();
        }

        public void Compile()
        {
            var tokens = CreateTokenList();

            string message;

            try
            {
                var sintatico = new Sintatico();
                var lexico = new Lexico(CodeEditor.Text.Replace("\r", ""));

                sintatico.Parse(lexico, new Semantico());

                SaveCompiledCode(sintatico.semanticAnalyser.Codigo);

                message = "Programa compilado com sucesso";
            }
            catch (AnalysisError se)
            {
                message = $"Erro na linha {se.Line} - {se.Message}";
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            MessageTextBox.Text = message;
        }

        private void SaveCompiledCode(string codigo)
        {
            var nomeArquivo = "CodigoCompilado.il";

            if (File.Exists(nomeArquivo))
            {
                File.Delete(nomeArquivo);
            }

            using (FileStream fs = File.Create(nomeArquivo))
            {
                byte[] codigoByte = new UTF8Encoding(true).GetBytes(codigo);
                fs.Write(codigoByte, 0, codigoByte.Length);
            }
        }

        private List<Token> CreateTokenList()
        {
            var lexico = new Lexico(CodeEditor.Text.Replace("\r", ""));
            var tokens = new List<Token>();
            var linha = 0;

            try
            {
                var token = lexico.NextToken();

                while (token != null)
                {
                    tokens.Add(token);

                    token = lexico.NextToken();
                    if (token != null)
                    {
                        linha = token.Line;
                    }

                }
            }
            catch (LexicalError le)
            {
                tokens.Clear();
                tokens.Add(new Token(-9999, le.Message, le.Line, 0));
            }

            return tokens;
        }

        public void Team()
        {
            MessageTextBox.Text =
@"Débora Cristine Reinert,
João Victor Braun Quintino,
Nathan Reikdal Cervieri";
        }

        private void ClearMessage()
        {
            MessageTextBox.Text = string.Empty;
        }

        private void ClearPath()
        {
            StatusTextBox.Text = string.Empty;
            path = string.Empty;
        }
    }
}
