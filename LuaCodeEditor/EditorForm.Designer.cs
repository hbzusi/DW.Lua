namespace LuaCodeEditor
{
    partial class EditorForm
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
            this.codeBox = new System.Windows.Forms.RichTextBox();
            this.parserStatusLabel = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // codeBox
            // 
            this.codeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeBox.Location = new System.Drawing.Point(0, 0);
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(265, 273);
            this.codeBox.TabIndex = 0;
            this.codeBox.Text = "";
            this.codeBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // parserStatusLabel
            // 
            this.parserStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.parserStatusLabel.AutoSize = true;
            this.parserStatusLabel.Location = new System.Drawing.Point(12, 276);
            this.parserStatusLabel.Name = "parserStatusLabel";
            this.parserStatusLabel.Size = new System.Drawing.Size(36, 13);
            this.parserStatusLabel.TabIndex = 1;
            this.parserStatusLabel.Text = "Empty";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(272, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(277, 325);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 351);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.parserStatusLabel);
            this.Controls.Add(this.codeBox);
            this.Name = "EditorForm";
            this.Text = "Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codeBox;
        private System.Windows.Forms.Label parserStatusLabel;
        private System.Windows.Forms.TreeView treeView1;
    }
}

