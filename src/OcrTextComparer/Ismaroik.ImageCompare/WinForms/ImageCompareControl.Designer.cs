namespace Ismaroik.ImageCompare.WinForms
{
    partial class ImageCompareControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageCompareControl));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.iccScanImages = new Ismaroik.ImageCompare.WinForms.DoublePictureBox();
            this.rtbDiffText = new Ismaroik.ImageCompare.WinForms.PrintableRichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonPlus = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton100 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMinus = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iccScanImages);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rtbDiffText);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(500, 560);
            this.splitContainer2.SplitterDistance = 263;
            this.splitContainer2.TabIndex = 26;
            // 
            // iccScanImages
            // 
            this.iccScanImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iccScanImages.Image1 = null;
            this.iccScanImages.Image2 = null;
            this.iccScanImages.Location = new System.Drawing.Point(0, 0);
            this.iccScanImages.Name = "iccScanImages";
            this.iccScanImages.Size = new System.Drawing.Size(500, 263);
            this.iccScanImages.SynchronizeImagePanZoom = false;
            this.iccScanImages.TabIndex = 26;
            // 
            // rtbDiffText
            // 
            this.rtbDiffText.BackColor = System.Drawing.Color.White;
            this.rtbDiffText.DetectUrls = false;
            this.rtbDiffText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDiffText.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDiffText.Location = new System.Drawing.Point(0, 0);
            this.rtbDiffText.Name = "rtbDiffText";
            this.rtbDiffText.ReadOnly = true;
            this.rtbDiffText.Size = new System.Drawing.Size(500, 268);
            this.rtbDiffText.TabIndex = 22;
            this.rtbDiffText.Text = "";
            this.rtbDiffText.WordWrap = false;
            this.rtbDiffText.SelectionChanged += new System.EventHandler(this.rtbDiffText_SelectionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPlus,
            this.toolStripButton100,
            this.toolStripButtonMinus,
            this.toolStripLabel4,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 268);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(500, 25);
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonPlus
            // 
            this.toolStripButtonPlus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonPlus.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPlus.Image")));
            this.toolStripButtonPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPlus.Name = "toolStripButtonPlus";
            this.toolStripButtonPlus.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPlus.Text = "+";
            this.toolStripButtonPlus.Click += new System.EventHandler(this.toolStripButtonPlus_Click);
            // 
            // toolStripButton100
            // 
            this.toolStripButton100.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton100.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton100.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton100.Image")));
            this.toolStripButton100.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton100.Name = "toolStripButton100";
            this.toolStripButton100.Size = new System.Drawing.Size(29, 22);
            this.toolStripButton100.Text = "100";
            this.toolStripButton100.Click += new System.EventHandler(this.toolStripButton100_Click);
            // 
            // toolStripButtonMinus
            // 
            this.toolStripButtonMinus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonMinus.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMinus.Image")));
            this.toolStripButtonMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMinus.Name = "toolStripButtonMinus";
            this.toolStripButtonMinus.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMinus.Text = "-";
            this.toolStripButtonMinus.Click += new System.EventHandler(this.toolStripButtonMinus_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel4.Image")));
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(85, 22);
            this.toolStripLabel4.Text = "Text Zoom: ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
            // 
            // ImageCompareControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Name = "ImageCompareControl";
            this.Size = new System.Drawing.Size(500, 560);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private DoublePictureBox iccScanImages;
        private PrintableRichTextBox rtbDiffText;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPlus;
        private System.Windows.Forms.ToolStripButton toolStripButton100;
        private System.Windows.Forms.ToolStripButton toolStripButtonMinus;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
