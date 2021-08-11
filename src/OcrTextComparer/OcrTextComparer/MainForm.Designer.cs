namespace OcrTextComparer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imlSyncStatesImages = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblScan2 = new System.Windows.Forms.Label();
            this.chkSynchronizeMovement = new System.Windows.Forms.CheckBox();
            this.lblScan1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnLoadScan2 = new System.Windows.Forms.Button();
            this.btnLoadScan1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.compareControl = new ImageCompare.WinForms.ImageCompareControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // imlSyncStatesImages
            // 
            this.imlSyncStatesImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSyncStatesImages.ImageStream")));
            this.imlSyncStatesImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSyncStatesImages.Images.SetKeyName(0, "lock_lock.ico");
            this.imlSyncStatesImages.Images.SetKeyName(1, "lock_unlock.ico");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblScan2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkSynchronizeMovement, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblScan1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(150, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(789, 35);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // lblScan2
            // 
            this.lblScan2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScan2.Location = new System.Drawing.Point(480, 0);
            this.lblScan2.Name = "lblScan2";
            this.lblScan2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblScan2.Size = new System.Drawing.Size(306, 32);
            this.lblScan2.TabIndex = 1;
            this.lblScan2.Text = "lblScan2";
            this.lblScan2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSynchronizeMovement
            // 
            this.chkSynchronizeMovement.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSynchronizeMovement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSynchronizeMovement.ImageIndex = 1;
            this.chkSynchronizeMovement.ImageList = this.imlSyncStatesImages;
            this.chkSynchronizeMovement.Location = new System.Drawing.Point(315, 3);
            this.chkSynchronizeMovement.Name = "chkSynchronizeMovement";
            this.chkSynchronizeMovement.Size = new System.Drawing.Size(159, 26);
            this.chkSynchronizeMovement.TabIndex = 28;
            this.chkSynchronizeMovement.Text = "Synchronized pan & zoom";
            this.chkSynchronizeMovement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkSynchronizeMovement.UseMnemonic = false;
            this.chkSynchronizeMovement.UseVisualStyleBackColor = true;
            this.chkSynchronizeMovement.CheckedChanged += new System.EventHandler(this.chkSynchronizeMovement_CheckedChanged);
            // 
            // lblScan1
            // 
            this.lblScan1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScan1.Location = new System.Drawing.Point(3, 0);
            this.lblScan1.Name = "lblScan1";
            this.lblScan1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblScan1.Size = new System.Drawing.Size(306, 32);
            this.lblScan1.TabIndex = 0;
            this.lblScan1.Text = "lblScan1";
            this.lblScan1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.panel1.Size = new System.Drawing.Size(150, 545);
            this.panel1.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btnCompare);
            this.groupBox1.Controls.Add(this.btnLoadScan2);
            this.groupBox1.Controls.Add(this.btnLoadScan1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(142, 545);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbLanguage);
            this.groupBox4.Location = new System.Drawing.Point(4, 152);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(134, 42);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Language";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DisplayMember = "LangName";
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(4, 17);
            this.cmbLanguage.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(126, 21);
            this.cmbLanguage.Sorted = true;
            this.cmbLanguage.TabIndex = 6;
            this.cmbLanguage.ValueMember = "LangCode";
            this.cmbLanguage.SelectedValueChanged += new System.EventHandler(this.cmbLanguage_SelectedValueChanged);
            // 
            // btnCompare
            // 
            this.btnCompare.Enabled = false;
            this.btnCompare.Image = ((System.Drawing.Image)(resources.GetObject("btnCompare.Image")));
            this.btnCompare.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCompare.Location = new System.Drawing.Point(4, 199);
            this.btnCompare.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(133, 88);
            this.btnCompare.TabIndex = 4;
            this.btnCompare.Text = "Compare";
            this.btnCompare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnLoadScan2
            // 
            this.btnLoadScan2.Location = new System.Drawing.Point(5, 68);
            this.btnLoadScan2.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadScan2.Name = "btnLoadScan2";
            this.btnLoadScan2.Size = new System.Drawing.Size(133, 46);
            this.btnLoadScan2.TabIndex = 3;
            this.btnLoadScan2.Text = "Load Image 2";
            this.btnLoadScan2.UseVisualStyleBackColor = true;
            this.btnLoadScan2.Click += new System.EventHandler(this.btnLoadScan2_Click);
            // 
            // btnLoadScan1
            // 
            this.btnLoadScan1.Location = new System.Drawing.Point(5, 17);
            this.btnLoadScan1.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadScan1.Name = "btnLoadScan1";
            this.btnLoadScan1.Size = new System.Drawing.Size(133, 46);
            this.btnLoadScan1.TabIndex = 2;
            this.btnLoadScan1.Text = "Load Image 1";
            this.btnLoadScan1.UseVisualStyleBackColor = true;
            this.btnLoadScan1.Click += new System.EventHandler(this.btnLoadScan1_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // compareControl
            // 
            this.compareControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compareControl.ImagesTextSplitterDistance = 227;
            this.compareControl.Location = new System.Drawing.Point(150, 35);
            this.compareControl.Name = "compareControl";
            this.compareControl.Size = new System.Drawing.Size(789, 510);
            this.compareControl.SynchronizeImagePanZoom = false;
            this.compareControl.TabIndex = 32;
            this.compareControl.TextDeleteColor = System.Drawing.Color.Red;
            this.compareControl.TextInsertColor = System.Drawing.Color.Green;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 545);
            this.Controls.Add(this.compareControl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imlSyncStatesImages;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblScan2;
        private System.Windows.Forms.CheckBox chkSynchronizeMovement;
        private System.Windows.Forms.Label lblScan1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnLoadScan2;
        private System.Windows.Forms.Button btnLoadScan1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private ImageCompare.WinForms.ImageCompareControl compareControl;
    }
}

