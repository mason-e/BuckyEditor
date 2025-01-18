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
            this.label2 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.ofOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.btClose = new System.Windows.Forms.Button();
            this.btConfigSelect = new System.Windows.Forms.Button();
            this.cbConfigName = new System.Windows.Forms.ComboBox();
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
            this.label1.Location = new System.Drawing.Point(10, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ROM file name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Config file name:";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(94, 58);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(324, 20);
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
            // btConfigSelect
            // 
            this.btConfigSelect.Location = new System.Drawing.Point(422, 20);
            this.btConfigSelect.Name = "btConfigSelect";
            this.btConfigSelect.Size = new System.Drawing.Size(32, 20);
            this.btConfigSelect.TabIndex = 2;
            this.btConfigSelect.Text = "...";
            this.btConfigSelect.UseVisualStyleBackColor = true;
            this.btConfigSelect.Click += new System.EventHandler(this.tbConfigName_Click);
            // 
            // cbConfigName
            // 
            this.cbConfigName.FormattingEnabled = true;
            this.cbConfigName.Location = new System.Drawing.Point(94, 20);
            this.cbConfigName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbConfigName.MaxDropDownItems = 32;
            this.cbConfigName.Name = "cbConfigName";
            this.cbConfigName.Size = new System.Drawing.Size(324, 21);
            this.cbConfigName.TabIndex = 1;
            // 
            // btRomSelect
            // 
            this.btRomSelect.Location = new System.Drawing.Point(422, 58);
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
            this.ClientSize = new System.Drawing.Size(470, 150);
            this.Controls.Add(this.btRomSelect);
            this.Controls.Add(this.cbConfigName);
            this.Controls.Add(this.btConfigSelect);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.OpenFileDialog ofOpenDialog;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btConfigSelect;
        private System.Windows.Forms.ComboBox cbConfigName;
        private System.Windows.Forms.Button btRomSelect;
    }
}