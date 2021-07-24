﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionAssist.API;
using VisionAssist.Forms;
using VisionAssist.Vision;

namespace VisionAssist
{
    public partial class frmMain : Form
    {
        private Point MousePoint;
        private frmVIsion gfrmVision;
        private frmControl gfrmControl;
        private frmTop gfrmTop;

        private bool isWindowMoving;

        private bool bFindWindow = false;
        public frmMain()
        {
            InitializeComponent();
                        
            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            //Idle이벤트를 없앤다.
            Application.Idle -= Application_Idle;

            isWindowMoving = false;

            SyncForm(this);
            LoadForm();

            bgwSearchWindow.RunWorkerAsync();
            bgwMousePosition.RunWorkerAsync();
            bgwSizeChecker.RunWorkerAsync();

            ReadData();
        }

        private void ReadData()
        {
            GLOBAL.SelectAppPlayer = cbxAppPlayer.SelectedIndex = int.Parse(INIControl.IniRead("Player", "SelectApp", GLOBAL.Path));            
        }

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            MousePoint = new Point(e.X, e.Y);
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            isWindowMoving = true;

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (MousePoint.X - e.X),
                    this.Top - (MousePoint.Y - e.Y));
            }

            isWindowMoving = false;
        }

        public void LoadForm()                          
        {
            IntPtr Parenthandle;

            gfrmVision = new frmVIsion();
            Parenthandle = pnlVision.Handle;

            pnlVision.Invoke(new Action(delegate
            {
                GLOBAL.SetParent(gfrmVision.Handle, Parenthandle);
                GLOBAL.SetWindowPos(gfrmVision.Handle, IntPtr.Zero, 0, 0, pnlVision.Width, pnlVision.Height, 0);
            }));

            gfrmControl = new frmControl();
            Parenthandle = pnlRight.Handle;

            pnlVision.Invoke(new Action(delegate
            {
                GLOBAL.SetParent(gfrmControl.Handle, Parenthandle);
                GLOBAL.SetWindowPos(gfrmControl.Handle, IntPtr.Zero, 0, 0, pnlRight.Width, pnlRight.Height, 0);
            }));

            gfrmTop = new frmTop();
            Parenthandle = pnlTop.Handle;

            pnlVision.Invoke(new Action(delegate
            {
                GLOBAL.SetParent(gfrmTop.Handle, Parenthandle);
                GLOBAL.SetWindowPos(gfrmTop.Handle, IntPtr.Zero, 0, 0, pnlTop.Width, pnlTop.Height, 0);
            }));

        }

        public static void SyncForm(frmMain Handler)
        {
            GLOBAL.hfrmMain = Handler;
        }

        private void btnLoadPlayer_Click(object sender, EventArgs e)
        {
            //gfrmVision.ImageCapture("LDPlayer");
        }

        private void bgwSearchWindow_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                if(GLOBAL.SelectAppPlayer == int.MinValue)
                    continue;

                if(isWindowMoving == false)
                {
                    switch(GLOBAL.SelectAppPlayer)
                    {
                        case 0:
                            gfrmVision.ImageCapture("LDPlayer");
                            break;
                        case 1:
                            gfrmVision.ImageCapture("BlueStacks");
                            break;
                        case 2:
                            gfrmVision.ImageCapture(cbxAppPlayer.Text);
                            break;
                        case 3:
                            gfrmVision.ImageCapture("리니지M l " + cbxAppPlayer.Text);
                            break;
                    }
                }
            }
        }

        private void chkDrawText_CheckedChanged(object sender, EventArgs e)
        {
            if(chkDrawText.Checked)
            {
                GLOBAL.hfrmVision.bDrawText = true;
            }
            else
            {
                GLOBAL.hfrmVision.bDrawText = false;
            }
        }

        private void bgwMousePosition_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                this.BeginInvoke(new Action(()=>
                {
                    tbxMouseX.Text = stAxis.NowPosition.X.ToString();
                    tbxMouseY.Text = stAxis.NowPosition.Y.ToString();
                    tbxRealMouseX.Text = stAxis.NowRealPosition.X.ToString();
                    tbxRealMouseY.Text = stAxis.NowRealPosition.Y.ToString();
                    tbxMouseStartPosX.Text = stAxis.StartRangePos.X.ToString();
                    tbxMouseStartPosY.Text = stAxis.StartRangePos.Y.ToString();
                    tbxMouseEndPosX.Text = stAxis.RangeSize.X.ToString();
                    tbxMouseEndPosY.Text = stAxis.RangeSize.Y.ToString();
                }));

                Thread.Sleep(200);
            }
        }

        private void bgwSizeChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                this.BeginInvoke(new Action(() =>
                {
                    tbxVisionSizeHeight.Text = GLOBAL.ScaleHeight.ToString();
                    tbxVisionSizeWidth.Text = GLOBAL.ScaleWidth.ToString();
                    tbxRealSizeWidth.Text = GLOBAL.OriginWidth.ToString();
                    tbxRealSizeHeight.Text = GLOBAL.OriginHeight.ToString();
                    tbxFormSizeWidth.Text = GLOBAL.VisionWidth.ToString();
                    tbxFormSizeHeight.Text = GLOBAL.VisionHeight.ToString();
                }));               

                Thread.Sleep(200);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void tbxMouseEndPosX_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlVision_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbxAppPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GLOBAL.SelectAppPlayer = cbxAppPlayer.SelectedIndex;
            INIControl.IniWrite("Player", "SelectApp", cbxAppPlayer.SelectedIndex.ToString(), GLOBAL.Path);
        }
    }
}
