namespace BuckyEditor
{
    partial class OpenFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenFile));
            this.btOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.ofOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.btClose = new System.Windows.Forms.Button();
            this.btRomSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(12, 115);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(206, 23);
            this.btOpen.TabIndex = 0;
            this.btOpen.Text = "Open";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select ROM file:";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(12, 58);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(367, 20);
            this.tbFileName.TabIndex = 6;
            // 
            // ofOpenDialog
            // 
            this.ofOpenDialog.InitialDirectory = "\"\"";
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(224, 115);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(193, 23);
            this.btClose.TabIndex = 5;
            this.btClose.Text = "Cancel";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btRomSelect
            // 
            this.btRomSelect.Location = new System.Drawing.Point(385, 58);
            this.btRomSelect.Name = "btRomSelect";
            this.btRomSelect.Size = new System.Drawing.Size(32, 20);
            this.btRomSelect.TabIndex = 3;
            this.btRomSelect.Text = "...";
            this.btRomSelect.UseVisualStyleBackColor = true;
            this.btRomSelect.Click += new System.EventHandler(this.tbFileName_Click);
            // 
            // OpenFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 150);
            this.Controls.Add(this.btRomSelect);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OpenFile";
            this.Text = "Open File";
            this.Load += new System.EventHandler(this.OpenFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.OpenFileDialog ofOpenDialog;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btRomSelect;
    }
}