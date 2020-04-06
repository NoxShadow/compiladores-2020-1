using System.Windows.Forms;

namespace Compiladores20201ProjetoCSharp
{
    partial class mainLayout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainLayout));
            this.codeEditor = new ScintillaNET.Scintilla();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.novoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeEditor
            // 
            resources.ApplyResources(this.codeEditor, "codeEditor");
            this.codeEditor.EndAtLastLine = false;
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.ScrollWidth = 900;
            this.codeEditor.UseTabs = true;
            this.codeEditor.TextChanged += new System.EventHandler(this.HandleLineNumber);
            // 
            // statusTextBox
            // 
            resources.ApplyResources(this.statusTextBox, "statusTextBox");
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            // 
            // messageTextBox
            // 
            resources.ApplyResources(this.messageTextBox, "messageTextBox");
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoButton});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // novoButton
            // 
            resources.ApplyResources(this.novoButton, "novoButton");
            this.novoButton.Name = "novoButton";
            // 
            // mainLayout
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.codeEditor);
            this.Name = "mainLayout";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ScintillaNET.Scintilla codeEditor;
        private TextBox statusTextBox;
        private TextBox messageTextBox;
        private ToolStrip toolStrip1;
        private ToolStripButton novoButton;
    }
}

