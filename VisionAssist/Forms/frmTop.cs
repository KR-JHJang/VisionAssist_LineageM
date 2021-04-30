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
using RestSharp;
using VisionAssist.API;

namespace VisionAssist.Forms
{


    public partial class frmTop : UserControl
    {
        public List<RadioButton> radioButtons1;
        public List<RadioButton> radioButtons2;
        public List<RadioButton> radioButtons3;
        public List<RadioButton> radioButtons4;

        public frmTop()
        {
            InitializeComponent();

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            //Idle이벤트를 없앤다.
            Application.Idle -= Application_Idle;

            SetBoxes();
            RunThread();
        }

        private void SetBoxes()
        {
            radioButtons1 = new List<RadioButton>
            {
                g1r1,
                g1r2,
                g1r3,
                g1r4,
                g1r5,
                g1r6,
                g1r7,
                g1r8,
                g1r9,
                g1r10
            };

            radioButtons2 = new List<RadioButton>
            {
                g2r1,
                g2r2,
                g2r3,
                g2r4,
                g2r5,
                g2r6,
                g2r7,
                g2r8,
                g2r9,
                g2r10
            };

            radioButtons3 = new List<RadioButton>
            {
                g3r1,
                g3r2,
                g3r3,
                g3r4,
                g3r5,
                g3r6,
                g3r7,
                g3r8,
                g3r9,
                g3r10
            };

            radioButtons4 = new List<RadioButton>
            {
                g4r1,
                g4r2,
                g4r3,
                g4r4,
                g4r5,
                g4r6,
                g4r7,
                g4r8,
                g4r9,
                g4r10
            };

            GLOBAL._tskillboxes = new List<Tskillbox>(4);
            GLOBAL._tskillboxes.Add(new Tskillbox(checkBox1, gbox1, radioButtons1));
            GLOBAL._tskillboxes.Add(new Tskillbox(checkBox2, gbox2, radioButtons2));
            GLOBAL._tskillboxes.Add(new Tskillbox(checkBox3, gbox3, radioButtons3));
            GLOBAL._tskillboxes.Add(new Tskillbox(checkBox4, gbox4, radioButtons4));
        }

        private void RunThread()
        {
            bgwRunFlag.RunWorkerAsync();
            bgwUseGroups.RunWorkerAsync();
            bgwCheckRadioButtonSelect.RunWorkerAsync();
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

        private void bgwUseGroups_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (GLOBAL._tskillboxes == null)
                    continue;

                foreach (var variable in GLOBAL._tskillboxes)
                {
                    this.Invoke(new Action(() =>
                    {
                        if (variable.checkBox.Checked)
                        {
                            variable.groupBox.Enabled = true;
                        }
                        else
                        {
                            variable.groupBox.Enabled = false;
                        }
                    }));
                }


                Thread.Sleep(100);
            }
        }

        private void bgwCheckRadioButtonSelect_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (GLOBAL._tskillboxes == null)
                    continue;

                for (int idx = 0; idx < GLOBAL._tskillboxes.Count; idx++)
                {
                    for (int i = 0; i < GLOBAL._tskillboxes[idx].RadioButtons.Count; i++)
                    {
                        if (GLOBAL._tskillboxes[idx].RadioButtons[i].Checked)
                        {
                            GLOBAL._tskillpos[idx] = i;

                            //System.Console.WriteLine(" GLOBAL._tskillboxes[{0}].SetSelectNum({1})", idx, i);
                            //System.Console.WriteLine(" GLOBAL._tskillpos[idx] = : {1}", idx, GLOBAL._tskillpos[idx]);
                            break;
                        }
                    }
                }

                Thread.Sleep(100);
            }
        }

        private void btnLoginKakaoTalk_Click(object sender, EventArgs e)
        {
            if (btnLoginKakaoTalk.Text == "Login KAKAO TALK")
            {
                frmKakaoTalk form = new frmKakaoTalk();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    btnLoginKakaoTalk.Text = "로그아웃";
                }
            }
            else
            {
                var client = new RestClient(KakaoHandle.HOST_API_URL);

                var request = new RestRequest("/v1/user/unlink", Method.POST);
                request.AddHeader("Authorization", "bearer " + KakaoHandle.ACCESS_TOKEN);

                if (client.Execute(request).IsSuccessful)
                {
                    btnLoginKakaoTalk.Text = "Login KAKAO TALK";
                }
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            KakaoHandle.sendTemplateMessageToMyself();
        }

        private void btnSendMsg2_Click(object sender, EventArgs e)
        {
            KakaoHandle.sendMessageToMyself("Test");
        }
    }
}
