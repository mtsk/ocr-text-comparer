using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ismaroik.ImageCompare.WinForms
{
    public partial class DoublePictureBox : UserControl
    {
        // indicates wheter controls are beign synchronized, serves to prevent cyclic calling of methods
        private bool mHandleSynchronizationEvents = true;

        public DoublePictureBox()
        {
            InitializeComponent();
        }

        #region Properties

        private bool mSynchronizeImagePanZoom;
        public bool SynchronizeImagePanZoom
        {
            get
            {
                return mSynchronizeImagePanZoom;
            }
            set
            {
                if(mSynchronizeImagePanZoom != value)
                {
                    if (value)
                    {
                        // do initial set-up of second control before syncing
                        db2.ZoomFactor = db1.ZoomFactor;
                        this.db2.Origin = new Point(hScrollBar1.Value, vScrollBar1.Value);
                    }

                    mSynchronizeImagePanZoom = value;
                }
            }
        }

        #endregion

        #region db1

        public System.Drawing.Image Image1
        {
            get { return db1.Image; }
            set
            {
                db1.Image = value;
                if (value == null)
                {
                    hScrollBar1.Enabled = false;
                    vScrollBar1.Enabled = false;
                    return;
                }
            }
        }

        public void Image1_Highlight(Rectangle rectInOriginalPic)
        {
            mHandleSynchronizationEvents = false;

            db1.NavigateTo(rectInOriginalPic);
            db1.DrawRect(rectInOriginalPic);
            db1.Invalidate();
            db1.Update();

            mHandleSynchronizationEvents = true;
        }

        private void db1_SetScrollPositions()
        {
            int DrawingWidth = db1.Image.Width;
            int DrawingHeight = db1.Image.Height;
            int OriginX = db1.Origin.X;
            int OriginY = db1.Origin.Y;
            int FactoredCtrlWidth = (int)(db1.Width / db1.ZoomFactor);
            int FactoredCtrlHeight = (int)(db1.Height / db1.ZoomFactor);
            hScrollBar1.Maximum = this.db1.Image.Width;
            vScrollBar1.Maximum = this.db1.Image.Height;

            if (FactoredCtrlWidth >= db1.Image.Width | db1.StretchImageToFit)
            {
                hScrollBar1.Enabled = false;
                hScrollBar1.Value = 0;
            }
            else
            {
                hScrollBar1.LargeChange = FactoredCtrlWidth;
                hScrollBar1.Enabled = true;
                hScrollBar1.Value = OriginX;
            }

            if (FactoredCtrlHeight >= db1.Image.Height | db1.StretchImageToFit)
            {
                vScrollBar1.Enabled = false;
                vScrollBar1.Value = 0;
            }
            else
            {
                vScrollBar1.Enabled = true;
                vScrollBar1.LargeChange = FactoredCtrlHeight;
                vScrollBar1.Value = OriginY;
            }            
        }

        private void ScrollBar1_ValueChanged(object sender, System.EventArgs e)
        {
            this.db1.Origin = new Point(hScrollBar1.Value, vScrollBar1.Value);

            if (mSynchronizeImagePanZoom && mHandleSynchronizationEvents)
            {
                mHandleSynchronizationEvents = false;

                this.db2.Origin = new Point(hScrollBar1.Value, vScrollBar1.Value);

                mHandleSynchronizationEvents = true;
            }
        }

        private void db1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (mSynchronizeImagePanZoom && mHandleSynchronizationEvents)
            {
                mHandleSynchronizationEvents = false;

                if (e.PropertyName == "ZoomFactor")
                {
                    db2.ZoomFactor = db1.ZoomFactor;
                }

                mHandleSynchronizationEvents = true;
            }
        }

        #endregion

        #region db2

        public System.Drawing.Image Image2
        {
            get { return db2.Image; }
            set
            {
                db2.Image = value;
                if (value == null)
                {
                    hScrollBar2.Enabled = false;
                    vScrollBar2.Enabled = false;
                    return;
                }
            }
        }

        public void Image2_Highlight(Rectangle rectInOriginalPic)
        {
            mHandleSynchronizationEvents = false;

            db2.NavigateTo(rectInOriginalPic);
            db2.DrawRect(rectInOriginalPic);
            db2.Invalidate();
            db2.Update();

            mHandleSynchronizationEvents = true;
        }

        private void db2_SetScrollPositions()
        {
            int DrawingWidth = db2.Image.Width;
            int DrawingHeight = db2.Image.Height;
            int OriginX = db2.Origin.X;
            int OriginY = db2.Origin.Y;
            int FactoredCtrlWidth = (int)(db2.Width / db2.ZoomFactor);
            int FactoredCtrlHeight = (int)(db2.Height / db2.ZoomFactor);
            hScrollBar2.Maximum = this.db2.Image.Width;
            vScrollBar2.Maximum = this.db2.Image.Height;

            if (FactoredCtrlWidth >= db2.Image.Width | db2.StretchImageToFit)
            {
                hScrollBar2.Enabled = false;
                hScrollBar2.Value = 0;
            }
            else
            {
                hScrollBar2.LargeChange = FactoredCtrlWidth;
                hScrollBar2.Enabled = true;
                hScrollBar2.Value = OriginX;
            }

            if (FactoredCtrlHeight >= db2.Image.Height | db2.StretchImageToFit)
            {
                vScrollBar2.Enabled = false;
                vScrollBar2.Value = 0;
            }
            else
            {
                vScrollBar2.Enabled = true;
                vScrollBar2.LargeChange = FactoredCtrlHeight;
                vScrollBar2.Value = OriginY;
            }
        }

        private void ScrollBar2_ValueChanged(object sender, System.EventArgs e)
        {
            this.db2.Origin = new Point(hScrollBar2.Value, vScrollBar2.Value);

            if (mSynchronizeImagePanZoom && mHandleSynchronizationEvents)
            {
                mHandleSynchronizationEvents = false;

                this.db1.Origin = new Point(hScrollBar2.Value, vScrollBar2.Value);

                mHandleSynchronizationEvents = true;
            }
        }

        private void db2_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (mSynchronizeImagePanZoom && mHandleSynchronizationEvents)
            {
                mHandleSynchronizationEvents = false;

                if (e.PropertyName == "ZoomFactor")
                {
                    db1.ZoomFactor = db2.ZoomFactor;
                }

                mHandleSynchronizationEvents = true;
            }
        }

        #endregion

        public void FitToScreen()
        {
            db1.FitToScreen();
            db2.FitToScreen();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            db1.Invalidate();
            db2.Invalidate();
        }
    }
}
