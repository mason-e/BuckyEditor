﻿namespace BuckyEditor
{
    partial class BlockEdit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlockEdit));
            this.paletteMap = new System.Windows.Forms.PictureBox();
            this.mapScreen = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSubpalette = new System.Windows.Forms.ComboBox();
            this.subpalSprites = new System.Windows.Forms.ImageList(this.components);
            this.mapObjects = new System.Windows.Forms.FlowLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbPalette = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbActive = new System.Windows.Forms.PictureBox();
            this.btSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbActive = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bttSave = new System.Windows.Forms.ToolStripButton();
            this.bttGridlines = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.paletteMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbActive)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // paletteMap
            // 
            this.paletteMap.Location = new System.Drawing.Point(15, 52);
            this.paletteMap.Name = "paletteMap";
            this.paletteMap.Size = new System.Drawing.Size(256, 16);
            this.paletteMap.TabIndex = 0;
            this.paletteMap.TabStop = false;
            // 
            // mapScreen
            // 
            this.mapScreen.Location = new System.Drawing.Point(15, 95);
            this.mapScreen.Name = "mapScreen";
            this.mapScreen.Size = new System.Drawing.Size(256, 256);
            this.mapScreen.TabIndex = 6;
            this.mapScreen.TabStop = false;
            this.mapScreen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapScreen_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pallete:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "View with subpallete:";
            // 
            // cbSubpalette
            // 
            this.cbSubpalette.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbSubpalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubpalette.FormattingEnabled = true;
            this.cbSubpalette.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbSubpalette.Location = new System.Drawing.Point(118, 68);
            this.cbSubpalette.Name = "cbSubpalette";
            this.cbSubpalette.Size = new System.Drawing.Size(90, 21);
            this.cbSubpalette.TabIndex = 9;
            this.cbSubpalette.SelectedIndexChanged += new System.EventHandler(this.cbSubpalette_SelectedIndexChanged);
            // 
            // subpalSprites
            // 
            this.subpalSprites.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.subpalSprites.ImageSize = new System.Drawing.Size(64, 16);
            this.subpalSprites.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mapObjects
            // 
            this.mapObjects.AutoScroll = true;
            this.mapObjects.Location = new System.Drawing.Point(290, 35);
            this.mapObjects.Name = "mapObjects";
            this.mapObjects.Size = new System.Drawing.Size(370, 444);
            this.mapObjects.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(162, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "(change view)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Palette";
            // 
            // cbPalette
            // 
            this.cbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPalette.FormattingEnabled = true;
            this.cbPalette.Location = new System.Drawing.Point(45, 51);
            this.cbPalette.Name = "cbPalette";
            this.cbPalette.Size = new System.Drawing.Size(111, 21);
            this.cbPalette.TabIndex = 17;
            this.cbPalette.SelectedIndexChanged += new System.EventHandler(this.VisibleOnlyChange_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Blocks";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Active:";
            // 
            // pbActive
            // 
            this.pbActive.Location = new System.Drawing.Point(255, 68);
            this.pbActive.Name = "pbActive";
            this.pbActive.Size = new System.Drawing.Size(16, 16);
            this.pbActive.TabIndex = 14;
            this.pbActive.TabStop = false;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(0, 0);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tiles:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Palette:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(292, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "No:";
            // 
            // lbActive
            // 
            this.lbActive.AutoSize = true;
            this.lbActive.Location = new System.Drawing.Point(271, 68);
            this.lbActive.Name = "lbActive";
            this.lbActive.Size = new System.Drawing.Size(13, 13);
            this.lbActive.TabIndex = 28;
            this.lbActive.Text = "()";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttSave,
            this.bttGridlines});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(668, 25);
            this.toolStrip1.TabIndex = 29;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bttSave
            // 
            this.bttSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttSave.Image = ((System.Drawing.Image)(resources.GetObject("bttSave.Image")));
            this.bttSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(24, 24);
            this.bttSave.ToolTipText = "Save";
            this.bttSave.Click += new System.EventHandler(this.bttSave_Click);
            // 
            // bttGridlines
            // 
            this.bttGridlines.Checked = true;
            this.bttGridlines.CheckOnClick = true;
            this.bttGridlines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bttGridlines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttGridlines.Image = ((System.Drawing.Image)(resources.GetObject("bttGridlines.Image")));
            this.bttGridlines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttGridlines.Name = "bttGridlines";
            this.bttGridlines.Size = new System.Drawing.Size(24, 24);
            this.bttGridlines.ToolTipText = "Gridlines";
            this.bttGridlines.CheckedChanged += new System.EventHandler(this.bttGridlines_CheckedChanged);
            // 
            // BlockEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 515);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lbActive);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.paletteMap);
            this.Controls.Add(this.pbActive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mapObjects);
            this.Controls.Add(this.cbSubpalette);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mapScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BlockEdit";
            this.Text = "Blocks Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BlockEdit_FormClosing);
            this.Load += new System.EventHandler(this.BlockEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paletteMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbActive)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox paletteMap;
        private System.Windows.Forms.PictureBox mapScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSubpalette;
        private System.Windows.Forms.ImageList subpalSprites;
        private System.Windows.Forms.FlowLayoutPanel mapObjects;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbActive;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbPalette;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbActive;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bttSave;
        private System.Windows.Forms.ToolStripButton bttGridlines;
    }
}