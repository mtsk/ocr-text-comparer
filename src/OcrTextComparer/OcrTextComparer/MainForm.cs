using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OcrTextComparer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void chkSynchronizeMovement_CheckedChanged(object sender, EventArgs e)
        {
            compareControl.SynchronizeImagePanZoom = chkSynchronizeMovement.Checked;
            chkSynchronizeMovement.ImageKey = chkSynchronizeMovement.Checked ? "lock_lock.ico" : "lock_unlock.ico";
        }

        private void btnLoadScan1_Click(object sender, EventArgs e)
        {
            IsAllSet();
        }

        private void btnLoadScan2_Click(object sender, EventArgs e)
        {
            IsAllSet();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {

        }

        private void cmbLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            IsAllSet();
        }

        private void IsAllSet()
        {
            btnCompare.Enabled = true;
        }
    }
}
