namespace ImageCompare.WinForms
{
    partial class CompareAreasPicker
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
            this.db1 = new ImageCompare.WinForms.DrawingBoard();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.splitContainer1.TabIndex = 1;
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
            this.db2.Size = new System.Drawing.Size(288, 255);
            this.db2.StretchImageToFit = false;
            this.db2.TabIndex = 0;
            this.db2.ZoomFactor = 1D;
            this.db2.ZoomOnMouseWheel = true;
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar2.Enabled = false;
            this.hScrollBar2.LargeChange = 20;
            this.hScrollBar2.Location = new System.Drawing.Point(0, 255);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(288, 17);
            this.hScrollBar2.TabIndex = 3;
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar2.Enabled = false;
            this.vScrollBar2.LargeChange = 20;
            this.vScrollBar2.Location = new System.Drawing.Point(288, 0);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 255);
            this.vScrollBar2.TabIndex = 4;
            // 
            // CompareAreasPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CompareAreasPicker";
            this.Size = new System.Drawing.Size(600, 272);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DrawingBoard db1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.HScrollBar hScrollBar1;
        internal System.Windows.Forms.VScrollBar vScrollBar1;
        private DrawingBoard db2;
        internal System.Windows.Forms.HScrollBar hScrollBar2;
        internal System.Windows.Forms.VScrollBar vScrollBar2;
    }
}
