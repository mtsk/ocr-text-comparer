namespace ImageCompare.WinForms
{
    partial class DoublePictureBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.db1 = new ImageCompare.WinForms.DrawingBoard();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.db2 = new ImageCompare.WinForms.DrawingBoard();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.db1);
            this.splitContainer1.Panel1.Controls.Add(this.hScrollBar1);
            this.splitContainer1.Panel1.Controls.Add(this.vScrollBar1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.db2);
            this.splitContainer1.Panel2.Controls.Add(this.hScrollBar2);
            this.splitContainer1.Panel2.Controls.Add(this.vScrollBar2);
            this.splitContainer1.Size = new System.Drawing.Size(600, 272);
            this.splitContainer1.SplitterDistance = 299;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // db1
            // 
            this.db1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.db1.Image = null;
            this.db1.InitialImage = null;
            this.db1.Location = new System.Drawing.Point(0, 0);
            this.db1.Name = "db1";
            this.db1.Origin = new System.Drawing.Point(0, 0);
            this.db1.PanButton = System.Windows.Forms.MouseButtons.Left;
            this.db1.PanMode = true;
            this.db1.Size = new System.Drawing.Size(282, 255);
            this.db1.StretchImageToFit = false;
            this.db1.TabIndex = 0;
            this.db1.ZoomFactor = 1D;
            this.db1.ZoomOnMouseWheel = true;
            this.db1.SetScrollPositions += new ImageCompare.WinForms.DrawingBoard.SetScrollPositionsEventHandler(this.db1_SetScrollPositions);
            this.db1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.db1_PropertyChanged);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar1.Enabled = false;
            this.hScrollBar1.LargeChange = 20;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 255);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(282, 17);
            this.hScrollBar1.TabIndex = 3;
            this.hScrollBar1.ValueChanged += new System.EventHandler(this.ScrollBar1_ValueChanged);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Enabled = false;
            this.vScrollBar1.LargeChange = 20;
            this.vScrollBar1.Location = new System.Drawing.Point(282, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 255);
            this.vScrollBar1.TabIndex = 5;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.ScrollBar1_ValueChanged);
            // 
            // db2
            // 
            this.db2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.db2.Image = null;
            this.db2.InitialImage = null;
            this.db2.Location = new System.Drawing.Point(0, 0);
            this.db2.Name = "db2";
            this.db2.Origin = new System.Drawing.Point(0, 0);
            this.db2.PanButton = System.Windows.Forms.MouseButtons.Left;
            this.db2.PanMode = true;
            this.db2.Size = new System.Drawing.Size(284, 255);
            this.db2.StretchImageToFit = false;
            this.db2.TabIndex = 0;
            this.db2.ZoomFactor = 1D;
            this.db2.ZoomOnMouseWheel = true;
            this.db2.SetScrollPositions += new ImageCompare.WinForms.DrawingBoard.SetScrollPositionsEventHandler(this.db2_SetScrollPositions);
            this.db2.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.db2_PropertyChanged);
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar2.Enabled = false;
            this.hScrollBar2.LargeChange = 20;
            this.hScrollBar2.Location = new System.Drawing.Point(0, 255);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(284, 17);
            this.hScrollBar2.TabIndex = 3;
            this.hScrollBar2.ValueChanged += new System.EventHandler(this.ScrollBar2_ValueChanged);
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar2.Enabled = false;
            this.vScrollBar2.LargeChange = 20;
            this.vScrollBar2.Location = new System.Drawing.Point(284, 0);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 255);
            this.vScrollBar2.TabIndex = 4;
            this.vScrollBar2.ValueChanged += new System.EventHandler(this.ScrollBar2_ValueChanged);
            // 
            // ImageCompareControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ImageCompareControl";
            this.Size = new System.Drawing.Size(600, 272);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DrawingBoard db1;
        private DrawingBoard db2;
        internal System.Windows.Forms.HScrollBar hScrollBar1;
        internal System.Windows.Forms.HScrollBar hScrollBar2;
        internal System.Windows.Forms.VScrollBar vScrollBar2;
        internal System.Windows.Forms.VScrollBar vScrollBar1;
    }
}
