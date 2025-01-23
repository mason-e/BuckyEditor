namespace BuckyEditor
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mapScreen = new System.Windows.Forms.PictureBox();
            this.activeBlock = new System.Windows.Forms.PictureBox();
            this.lbActiveBlock = new System.Windows.Forms.Label();
            this.pnView = new System.Windows.Forms.Panel();
            this.lbCoords = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bttOpen = new System.Windows.Forms.ToolStripButton();
            this.bttSave = new System.Windows.Forms.ToolStripButton();
            this.bttReload = new System.Windows.Forms.ToolStripButton();
            this.bttBlocks = new System.Windows.Forms.ToolStripButton();
            this.bttShowNei = new System.Windows.Forms.ToolStripButton();
            this.bttGridlines = new System.Windows.Forms.ToolStripButton();
            this.bttShowAddress = new System.Windows.Forms.ToolStripButton();
            this.x025ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x05ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLayer1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnBlocks = new System.Windows.Forms.Panel();
            this.blocksScreen = new System.Windows.Forms.PictureBox();
            this.pnElements = new System.Windows.Forms.Panel();
            this.pnViewScroll = new System.Windows.Forms.Panel();
            this.lbChangePt = new System.Windows.Forms.Label();
            this.lbChangePalette = new System.Windows.Forms.Label();
            this.lbChangeScreen = new System.Windows.Forms.Label();
            this.btPatternPrev = new System.Windows.Forms.Button();
            this.btPalettePrev = new System.Windows.Forms.Button();
            this.btScreenPrev = new System.Windows.Forms.Button();
            this.btPatternNext = new System.Windows.Forms.Button();
            this.btPaletteNext = new System.Windows.Forms.Button();
            this.btScreenNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeBlock)).BeginInit();
            this.pnView.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnBlocks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blocksScreen)).BeginInit();
            this.pnElements.SuspendLayout();
            this.pnViewScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapScreen
            // 
            this.mapScreen.Location = new System.Drawing.Point(3, 2);
            this.mapScreen.Name = "mapScreen";
            this.mapScreen.Size = new System.Drawing.Size(381, 244);
            this.mapScreen.TabIndex = 4;
            this.mapScreen.TabStop = false;
            this.mapScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.mapScreen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapScreen_MouseClick);
            this.mapScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapScreen_MouseDown);
            this.mapScreen.MouseLeave += new System.EventHandler(this.mapScreen_MouseLeave);
            this.mapScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapScreen_MouseMove);
            this.mapScreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapScreen_MouseUp);
            // 
            // activeBlock
            // 
            this.activeBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.activeBlock.Location = new System.Drawing.Point(3, 16);
            this.activeBlock.Name = "activeBlock";
            this.activeBlock.Size = new System.Drawing.Size(64, 64);
            this.activeBlock.TabIndex = 5;
            this.activeBlock.TabStop = false;
            // 
            // lbActiveBlock
            // 
            this.lbActiveBlock.AutoSize = true;
            this.lbActiveBlock.Location = new System.Drawing.Point(3, 0);
            this.lbActiveBlock.Name = "lbActiveBlock";
            this.lbActiveBlock.Size = new System.Drawing.Size(49, 13);
            this.lbActiveBlock.TabIndex = 16;
            this.lbActiveBlock.Text = "Active: ()";
            // 
            // pnView
            // 
            this.pnView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnView.AutoScroll = true;
            this.pnView.Controls.Add(this.mapScreen);
            this.pnView.Location = new System.Drawing.Point(3, 3);
            this.pnView.Name = "pnView";
            this.pnView.Size = new System.Drawing.Size(669, 375);
            this.pnView.TabIndex = 53;
            // 
            // lbCoords
            // 
            this.lbCoords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCoords.AutoSize = true;
            this.lbCoords.Location = new System.Drawing.Point(5, 499);
            this.lbCoords.Name = "lbCoords";
            this.lbCoords.Size = new System.Drawing.Size(64, 13);
            this.lbCoords.TabIndex = 56;
            this.lbCoords.Text = "Coords:(0,0)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttOpen,
            this.bttSave,
            this.bttReload,
            this.bttBlocks,
            this.bttShowNei,
            this.bttGridlines,
            this.bttShowAddress});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1073, 27);
            this.toolStrip1.TabIndex = 57;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bttOpen
            // 
            this.bttOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttOpen.Image = ((System.Drawing.Image)(resources.GetObject("bttOpen.Image")));
            this.bttOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttOpen.Name = "bttOpen";
            this.bttOpen.Size = new System.Drawing.Size(24, 24);
            this.bttOpen.Text = "Open";
            this.bttOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // bttSave
            // 
            this.bttSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttSave.Image = ((System.Drawing.Image)(resources.GetObject("bttSave.Image")));
            this.bttSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttSave.Name = "bttSave";
            this.bttSave.Size = new System.Drawing.Size(24, 24);
            this.bttSave.Text = "Save";
            this.bttSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // bttReload
            // 
            this.bttReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttReload.Image = ((System.Drawing.Image)(resources.GetObject("bttReload.Image")));
            this.bttReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttReload.Name = "bttReload";
            this.bttReload.Size = new System.Drawing.Size(24, 24);
            this.bttReload.Text = "Reload";
            this.bttReload.Click += new System.EventHandler(this.bttReload_Click);
            // 
            // bttBlocks
            // 
            this.bttBlocks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttBlocks.Image = ((System.Drawing.Image)(resources.GetObject("bttBlocks.Image")));
            this.bttBlocks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttBlocks.Name = "bttBlocks";
            this.bttBlocks.Size = new System.Drawing.Size(24, 24);
            this.bttBlocks.Text = "Edit Blocks";
            this.bttBlocks.Click += new System.EventHandler(this.btSubeditor_Click);
            // 
            // bttShowNei
            // 
            this.bttShowNei.Checked = true;
            this.bttShowNei.CheckOnClick = true;
            this.bttShowNei.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bttShowNei.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttShowNei.Image = ((System.Drawing.Image)(resources.GetObject("bttShowNei.Image")));
            this.bttShowNei.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttShowNei.Name = "bttShowNei";
            this.bttShowNei.Size = new System.Drawing.Size(24, 24);
            this.bttShowNei.Text = "Show neighboring screens ";
            this.bttShowNei.CheckedChanged += new System.EventHandler(this.cbShowNeighbors_CheckedChanged);
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
            this.bttGridlines.Text = "Gridlines";
            this.bttGridlines.CheckedChanged += new System.EventHandler(this.cbShowGridlines_CheckedChanged);
            // 
            // bttShowAddress
            // 
            this.bttShowAddress.CheckOnClick = true;
            this.bttShowAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttShowAddress.Image = ((System.Drawing.Image)(resources.GetObject("bttShowAddress.Image")));
            this.bttShowAddress.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttShowAddress.Name = "bttShowAddress";
            this.bttShowAddress.Size = new System.Drawing.Size(24, 24);
            this.bttShowAddress.ToolTipText = "Show Metatile Address";
            this.bttShowAddress.Click += new System.EventHandler(this.bttShowAddress_CheckedChanged);
            // 
            // x025ToolStripMenuItem
            // 
            this.x025ToolStripMenuItem.Name = "x025ToolStripMenuItem";
            this.x025ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.x025ToolStripMenuItem.Text = "x0.25";
            // 
            // x05ToolStripMenuItem
            // 
            this.x05ToolStripMenuItem.Name = "x05ToolStripMenuItem";
            this.x05ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.x05ToolStripMenuItem.Text = "x0.5";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(101, 22);
            this.toolStripMenuItem2.Text = "x1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(101, 22);
            this.toolStripMenuItem3.Text = "x2";
            // 
            // x3ToolStripMenuItem
            // 
            this.x3ToolStripMenuItem.Name = "x3ToolStripMenuItem";
            this.x3ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.x3ToolStripMenuItem.Text = "x3";
            // 
            // x4ToolStripMenuItem
            // 
            this.x4ToolStripMenuItem.Name = "x4ToolStripMenuItem";
            this.x4ToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.x4ToolStripMenuItem.Text = "x4";
            // 
            // tsLayer1
            // 
            this.tsLayer1.Name = "tsLayer1";
            this.tsLayer1.Size = new System.Drawing.Size(170, 26);
            this.tsLayer1.Text = "Layer 1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 26);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnBlocks);
            this.splitContainer1.Panel1.Controls.Add(this.pnElements);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.splitContainer1_Panel1_Resize);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnViewScroll);
            this.splitContainer1.Size = new System.Drawing.Size(1071, 520);
            this.splitContainer1.SplitterDistance = 373;
            this.splitContainer1.TabIndex = 5;
            // 
            // pnBlocks
            // 
            this.pnBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnBlocks.AutoScroll = true;
            this.pnBlocks.Controls.Add(this.blocksScreen);
            this.pnBlocks.Location = new System.Drawing.Point(3, 4);
            this.pnBlocks.Margin = new System.Windows.Forms.Padding(2);
            this.pnBlocks.Name = "pnBlocks";
            this.pnBlocks.Size = new System.Drawing.Size(193, 509);
            this.pnBlocks.TabIndex = 61;
            this.pnBlocks.SizeChanged += new System.EventHandler(this.pnBlocks_SizeChanged);
            // 
            // blocksScreen
            // 
            this.blocksScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blocksScreen.Location = new System.Drawing.Point(2, 2);
            this.blocksScreen.Margin = new System.Windows.Forms.Padding(2);
            this.blocksScreen.Name = "blocksScreen";
            this.blocksScreen.Size = new System.Drawing.Size(188, 270);
            this.blocksScreen.TabIndex = 5;
            this.blocksScreen.TabStop = false;
            this.blocksScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.blocksScreen_Paint);
            this.blocksScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blocksScreen_MouseDown);
            // 
            // pnElements
            // 
            this.pnElements.Controls.Add(this.lbCoords);
            this.pnElements.Controls.Add(this.lbActiveBlock);
            this.pnElements.Controls.Add(this.activeBlock);
            this.pnElements.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnElements.Location = new System.Drawing.Point(294, 0);
            this.pnElements.Name = "pnElements";
            this.pnElements.Size = new System.Drawing.Size(77, 518);
            this.pnElements.TabIndex = 5;
            // 
            // pnViewScroll
            // 
            this.pnViewScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnViewScroll.AutoScroll = true;
            this.pnViewScroll.Controls.Add(this.lbChangePt);
            this.pnViewScroll.Controls.Add(this.lbChangePalette);
            this.pnViewScroll.Controls.Add(this.lbChangeScreen);
            this.pnViewScroll.Controls.Add(this.btPatternPrev);
            this.pnViewScroll.Controls.Add(this.btPalettePrev);
            this.pnViewScroll.Controls.Add(this.btScreenPrev);
            this.pnViewScroll.Controls.Add(this.btPatternNext);
            this.pnViewScroll.Controls.Add(this.btPaletteNext);
            this.pnViewScroll.Controls.Add(this.btScreenNext);
            this.pnViewScroll.Controls.Add(this.pnView);
            this.pnViewScroll.Location = new System.Drawing.Point(3, 6);
            this.pnViewScroll.Margin = new System.Windows.Forms.Padding(2);
            this.pnViewScroll.Name = "pnViewScroll";
            this.pnViewScroll.Size = new System.Drawing.Size(675, 529);
            this.pnViewScroll.TabIndex = 5;
            // 
            // lbChangePt
            // 
            this.lbChangePt.AutoSize = true;
            this.lbChangePt.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChangePt.Location = new System.Drawing.Point(250, 487);
            this.lbChangePt.Name = "lbChangePt";
            this.lbChangePt.Size = new System.Drawing.Size(189, 22);
            this.lbChangePt.TabIndex = 66;
            this.lbChangePt.Text = "Pattern Table 1 of ?";
            // 
            // lbChangePalette
            // 
            this.lbChangePalette.AutoSize = true;
            this.lbChangePalette.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChangePalette.Location = new System.Drawing.Point(276, 453);
            this.lbChangePalette.Name = "lbChangePalette";
            this.lbChangePalette.Size = new System.Drawing.Size(129, 22);
            this.lbChangePalette.TabIndex = 65;
            this.lbChangePalette.Text = "Palette 1 of ?";
            // 
            // lbChangeScreen
            // 
            this.lbChangeScreen.AutoSize = true;
            this.lbChangeScreen.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChangeScreen.Location = new System.Drawing.Point(276, 420);
            this.lbChangeScreen.Name = "lbChangeScreen";
            this.lbChangeScreen.Size = new System.Drawing.Size(132, 22);
            this.lbChangeScreen.TabIndex = 64;
            this.lbChangeScreen.Text = "Screen 1 of ?";
            // 
            // btPatternPrev
            // 
            this.btPatternPrev.Image = ((System.Drawing.Image)(resources.GetObject("btPatternPrev.Image")));
            this.btPatternPrev.Location = new System.Drawing.Point(106, 484);
            this.btPatternPrev.Name = "btPatternPrev";
            this.btPatternPrev.Size = new System.Drawing.Size(64, 32);
            this.btPatternPrev.TabIndex = 63;
            this.btPatternPrev.UseVisualStyleBackColor = true;
            this.btPatternPrev.Click += new System.EventHandler(this.btPatternPrev_Click);
            // 
            // btPalettePrev
            // 
            this.btPalettePrev.Image = ((System.Drawing.Image)(resources.GetObject("btPalettePrev.Image")));
            this.btPalettePrev.Location = new System.Drawing.Point(106, 450);
            this.btPalettePrev.Name = "btPalettePrev";
            this.btPalettePrev.Size = new System.Drawing.Size(64, 32);
            this.btPalettePrev.TabIndex = 62;
            this.btPalettePrev.UseVisualStyleBackColor = true;
            this.btPalettePrev.Click += new System.EventHandler(this.btPalettePrev_Click);
            // 
            // btScreenPrev
            // 
            this.btScreenPrev.Image = ((System.Drawing.Image)(resources.GetObject("btScreenPrev.Image")));
            this.btScreenPrev.Location = new System.Drawing.Point(106, 417);
            this.btScreenPrev.Name = "btScreenPrev";
            this.btScreenPrev.Size = new System.Drawing.Size(64, 32);
            this.btScreenPrev.TabIndex = 61;
            this.btScreenPrev.UseVisualStyleBackColor = true;
            this.btScreenPrev.Click += new System.EventHandler(this.btScreenPrev_Click);
            // 
            // btPatternNext
            // 
            this.btPatternNext.Image = ((System.Drawing.Image)(resources.GetObject("btPatternNext.Image")));
            this.btPatternNext.Location = new System.Drawing.Point(509, 484);
            this.btPatternNext.Name = "btPatternNext";
            this.btPatternNext.Size = new System.Drawing.Size(64, 32);
            this.btPatternNext.TabIndex = 60;
            this.btPatternNext.UseVisualStyleBackColor = true;
            this.btPatternNext.Click += new System.EventHandler(this.btPatternNext_Click);
            // 
            // btPaletteNext
            // 
            this.btPaletteNext.Image = ((System.Drawing.Image)(resources.GetObject("btPaletteNext.Image")));
            this.btPaletteNext.Location = new System.Drawing.Point(509, 450);
            this.btPaletteNext.Name = "btPaletteNext";
            this.btPaletteNext.Size = new System.Drawing.Size(64, 32);
            this.btPaletteNext.TabIndex = 59;
            this.btPaletteNext.UseVisualStyleBackColor = true;
            this.btPaletteNext.Click += new System.EventHandler(this.btPaletteNext_Click);
            // 
            // btScreenNext
            // 
            this.btScreenNext.Image = ((System.Drawing.Image)(resources.GetObject("btScreenNext.Image")));
            this.btScreenNext.Location = new System.Drawing.Point(509, 417);
            this.btScreenNext.Name = "btScreenNext";
            this.btScreenNext.Size = new System.Drawing.Size(64, 32);
            this.btScreenNext.TabIndex = 58;
            this.btScreenNext.UseVisualStyleBackColor = true;
            this.btScreenNext.Click += new System.EventHandler(this.btScreenNext_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 573);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "-";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LocationChanged += new System.EventHandler(this.FormMain_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.mapScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeBlock)).EndInit();
            this.pnView.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnBlocks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.blocksScreen)).EndInit();
            this.pnElements.ResumeLayout(false);
            this.pnElements.PerformLayout();
            this.pnViewScroll.ResumeLayout(false);
            this.pnViewScroll.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox mapScreen;
        private System.Windows.Forms.PictureBox activeBlock;
        private System.Windows.Forms.Label lbActiveBlock;
        private System.Windows.Forms.Panel pnView;
        private System.Windows.Forms.Label lbCoords;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bttOpen;
        private System.Windows.Forms.ToolStripButton bttSave;
        private System.Windows.Forms.ToolStripButton bttBlocks;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnElements;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripButton bttShowNei;
        private System.Windows.Forms.ToolStripButton bttGridlines;
        private System.Windows.Forms.ToolStripMenuItem x3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x025ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x05ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsLayer1;
        private System.Windows.Forms.ToolStripButton bttReload;
        private System.Windows.Forms.Panel pnBlocks;
        private System.Windows.Forms.PictureBox blocksScreen;
        private System.Windows.Forms.Panel pnViewScroll;
        private System.Windows.Forms.Button btScreenNext;
        private System.Windows.Forms.Button btPatternPrev;
        private System.Windows.Forms.Button btPalettePrev;
        private System.Windows.Forms.Button btScreenPrev;
        private System.Windows.Forms.Button btPatternNext;
        private System.Windows.Forms.Button btPaletteNext;
        private System.Windows.Forms.Label lbChangePalette;
        private System.Windows.Forms.Label lbChangeScreen;
        private System.Windows.Forms.Label lbChangePt;
        private System.Windows.Forms.ToolStripButton bttShowAddress;
    }
}

