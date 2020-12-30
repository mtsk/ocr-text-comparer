using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace OcrTextComparer
{
    public partial class MainForm : Form
    {
        private string mScan1Path = "";
        private string mScan2Path = "";

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cmbLanguage.Items.AddRange(TesLanguages.Languages);
            cmbLanguage.SelectedItem = TesLanguages.Languages.First(l => l.LangCode == "eng");
        }

        private void chkSynchronizeMovement_CheckedChanged(object sender, EventArgs e)
        {
            compareControl.SynchronizeImagePanZoom = chkSynchronizeMovement.Checked;
            chkSynchronizeMovement.ImageKey = chkSynchronizeMovement.Checked ? "lock_lock.ico" : "lock_unlock.ico";
        }

        private void btnLoadScan1_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files(*.bmp, *.jpg , *.tif) | *.bmp;*.jpg;*.tif";
            openFileDialog.FilterIndex = 1;
            openFileDialog.FileName = "";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")  // Ak sa nieco vrati z opendialogu
            {
                mScan1Path = openFileDialog.FileName;
                btnLoadScan1.BackColor = Color.FromArgb(128, 0, 255, 0);
            }

            IsAllSet();
        }

        private void btnLoadScan2_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Image Files(*.bmp, *.jpg , *.tif) | *.bmp;*.jpg;*.tif";
            openFileDialog.FilterIndex = 1;
            openFileDialog.FileName = "";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")  // Ak sa nieco vrati z opendialogu
            {
                mScan2Path = openFileDialog.FileName;
                btnLoadScan2.BackColor = Color.FromArgb(128, 0, 255, 0);
            }

            IsAllSet();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            string langCode = ((TesLanguages.Language)cmbLanguage.SelectedItem).LangCode;
            string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            compareControl.LoadImages(mScan1Path, mScan2Path, Path.Combine(assemblyDir, "Data"), true);

            string tesdataPath = Path.Combine(assemblyDir, "..\\..\\..\\");
            compareControl.PerformOcr_Tes(tesdataPath, langCode);
        }

        private void cmbLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            IsAllSet();
        }

        private void IsAllSet()
        {
            if (!string.IsNullOrEmpty(mScan1Path) &&
                !string.IsNullOrEmpty(mScan2Path) &&
                cmbLanguage.SelectedIndex >= 0)
            {
                btnCompare.Enabled = true;
            }
            else
            {
                btnCompare.Enabled = false;
            }
        }
    }
}
