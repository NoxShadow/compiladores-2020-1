using System.Windows.Forms;

namespace Compiladores20201ProjetoCSharp.FrontEnd
{
    partial class MainLayout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainLayout));
            this.codeEditor = new ScintillaNET.Scintilla();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.novoButton = new System.Windows.Forms.ToolStripButton();
            this.abrirButton = new System.Windows.Forms.ToolStripButton();
            this.salvarButton = new System.Windows.Forms.ToolStripButton();
            this.copiarButton = new System.Windows.Forms.ToolStripButton();
            this.colarButton = new System.Windows.Forms.ToolStripButton();
            this.recortarButton = new System.Windows.Forms.ToolStripButton();
            this.compilarButton = new System.Windows.Forms.ToolStripButton();
            this.equipeButton = new System.Windows.Forms.ToolStripButton();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeEditor
            // 
            resources.ApplyResources(this.codeEditor, "codeEditor");
            this.codeEditor.AutoCAutoHide = false;
            this.codeEditor.AutoCCancelAtStart = false;
            this.codeEditor.EndAtLastLine = false;
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.ScrollWidth = 6000;
            this.codeEditor.UseTabs = true;
            this.codeEditor.TextChanged += new System.EventHandler(this.HandleLineNumber);
            this.codeEditor.MultipleSelection = false;
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
            // toolbar
            // 
            resources.ApplyResources(this.toolbar, "toolbar");
            this.toolbar.ImageScalingSize = new System.Drawing.Size(24, 32);
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoButton,
            this.abrirButton,
            this.salvarButton,
            this.copiarButton,
            this.colarButton,
            this.recortarButton,
            this.compilarButton,
            this.equipeButton});
            this.toolbar.Name = "toolbar";
            // 
            // novoButton
            // 
            resources.ApplyResources(this.novoButton, "novoButton");
            this.novoButton.Name = "novoButton";
            this.novoButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.novoButton.Click += new System.EventHandler(this.novoButton_Click);
            // 
            // abrirButton
            // 
            resources.ApplyResources(this.abrirButton, "abrirButton");
            this.abrirButton.Name = "abrirButton";
            this.abrirButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.abrirButton.Click += new System.EventHandler(this.abrirButton_Click);
            // 
            // salvarButton
            // 
            resources.ApplyResources(this.salvarButton, "salvarButton");
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.salvarButton.Click += new System.EventHandler(this.salvarButton_Click);
            // 
            // copiarButton
            // 
            resources.ApplyResources(this.copiarButton, "copiarButton");
            this.copiarButton.Name = "copiarButton";
            this.copiarButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.copiarButton.Click += new System.EventHandler(this.copiarButton_Click);
            // 
            // colarButton
            // 
            resources.ApplyResources(this.colarButton, "colarButton");
            this.colarButton.Name = "colarButton";
            this.colarButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.colarButton.Click += new System.EventHandler(this.colarButton_Click);
            // 
            // recortarButton
            // 
            resources.ApplyResources(this.recortarButton, "recortarButton");
            this.recortarButton.Name = "recortarButton";
            this.recortarButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.recortarButton.Click += new System.EventHandler(this.recortarButton_Click);
            // 
            // compilarButton
            // 
            resources.ApplyResources(this.compilarButton, "compilarButton");
            this.compilarButton.Name = "compilarButton";
            this.compilarButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.compilarButton.Click += new System.EventHandler(this.compilarButton_Click);
            // 
            // equipeButton
            // 
            resources.ApplyResources(this.equipeButton, "equipeButton");
            this.equipeButton.Name = "equipeButton";
            this.equipeButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.equipeButton.Click += new System.EventHandler(this.equipeButton_Click);
            // 
            // MainLayout
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.codeEditor);
            this.Name = "MainLayout";
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScintillaNET.Scintilla codeEditor;
        private TextBox statusTextBox;
        private TextBox messageTextBox;
        private ToolStrip toolbar;
        private ToolStripButton novoButton;
        private ToolStripButton abrirButton;
        private ToolStripButton salvarButton;
        private ToolStripButton copiarButton;
        private ToolStripButton colarButton;
        private ToolStripButton recortarButton;
        private ToolStripButton compilarButton;
        private ToolStripButton equipeButton;
    }
}

