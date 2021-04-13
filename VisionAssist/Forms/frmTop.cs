using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionAssist.Forms
{
    public partial class frmTop : UserControl
    {
        public frmTop()
        {
            InitializeComponent();

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            //Idle이벤트를 없앤다.
            Application.Idle -= Application_Idle;

            RunThread();
        }

        private void RunThread()
        {
            bgwRunFlag.RunWorkerAsync();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            GLOBAL.Run();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            GLOBAL.Stop();
        }

        private void bgwRunFlag_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (GLOBAL.IsRun())
                {
                    btnStart.Invoke(new Action(() =>
                    {
                        btnStart.Enabled = false;
                    }));

                    btnStop.Invoke(new Action(() =>
                    {
                        btnStop.Enabled = true;
                    }));
                }
                else
                {
                    btnStart.Invoke(new Action(() =>
                    {
                        btnStart.Enabled = true;
                    }));

                    btnStop.Invoke(new Action(() =>
                    {
                        btnStop.Enabled = false;
                    }));
                }

                Thread.Sleep(100);
            }
        }
    }
}
