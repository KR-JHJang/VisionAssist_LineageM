using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            ReadData();
            RunThread();
        }

        private void ReadData()
        {
            checkBox1.Checked = Convert.ToBoolean(int.Parse(INIControl.IniRead("ControlParameter", "UseCheckBox1", GLOBAL.Path)));
            checkBox2.Checked = Convert.ToBoolean(int.Parse(INIControl.IniRead("ControlParameter", "UseCheckBox2", GLOBAL.Path)));
            checkBox3.Checked = Convert.ToBoolean(int.Parse(INIControl.IniRead("ControlParameter", "UseCheckBox3", GLOBAL.Path)));
            checkBox4.Checked = Convert.ToBoolean(int.Parse(INIControl.IniRead("ControlParameter", "UseCheckBox4", GLOBAL.Path)));

            int rdo1 = int.Parse(INIControl.IniRead("ControlParameter", "Box1SelectPosition", GLOBAL.Path));
            radioButtons1[rdo1].Checked = true;
            int rdo2 = int.Parse(INIControl.IniRead("ControlParameter", "Box2SelectPosition", GLOBAL.Path));
            radioButtons2[rdo2].Checked = true;
            int rdo3 = int.Parse(INIControl.IniRead("ControlParameter", "Box3SelectPosition", GLOBAL.Path));
            radioButtons3[rdo3].Checked = true;
            int rdo4 = int.Parse(INIControl.IniRead("ControlParameter", "Box4SelectPosition", GLOBAL.Path));
            radioButtons4[rdo4].Checked = true;
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
                    this.BeginInvoke(new Action(()=>
                    {
                        btnStart.Enabled = false;
                        btnStop.Enabled = true;
                    }));
                                    }
                else
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        btnStart.Enabled = true;
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

                            switch (idx)
                            {
                                case 0:
                                    if(int.Parse(INIControl.IniRead("ControlParameter", "Box1SelectPosition", GLOBAL.Path)) != i)
                                    {
                                        INIControl.IniWrite("ControlParameter", "Box1SelectPosition", i.ToString(), GLOBAL.Path);
                                    }
                                    break;
                                case 1:
                                    if (int.Parse(INIControl.IniRead("ControlParameter", "Box2SelectPosition", GLOBAL.Path)) != i)
                                    {
                                        INIControl.IniWrite("ControlParameter", "Box2SelectPosition", i.ToString(), GLOBAL.Path);
                                    }
                                    break;
                                case 2:
                                    if (int.Parse(INIControl.IniRead("ControlParameter", "Box3SelectPosition", GLOBAL.Path)) != i)
                                    {
                                        INIControl.IniWrite("ControlParameter", "Box3SelectPosition", i.ToString(), GLOBAL.Path);
                                    }
                                    break;
                                case 3:
                                    if (int.Parse(INIControl.IniRead("ControlParameter", "Box4SelectPosition", GLOBAL.Path)) != i)
                                    {
                                        INIControl.IniWrite("ControlParameter", "Box4SelectPosition", i.ToString(), GLOBAL.Path);
                                    }
                                    break;
                            }
                            
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            INIControl.IniWrite("ControlParameter", "UseCheckBox1", Convert.ToInt32(checkBox1.Checked).ToString(), GLOBAL.Path);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            INIControl.IniWrite("ControlParameter", "UseCheckBox2", Convert.ToInt32(checkBox2.Checked).ToString(), GLOBAL.Path);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            INIControl.IniWrite("ControlParameter", "UseCheckBox3", Convert.ToInt32(checkBox3.Checked).ToString(), GLOBAL.Path);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            INIControl.IniWrite("ControlParameter", "UseCheckBox4", Convert.ToInt32(checkBox4.Checked).ToString(), GLOBAL.Path);
        }

        private void btnOpenCaptureFolder_Click(object sender, EventArgs e)
        {
            string Path = $@"{Application.StartupPath}\Capture\";
            Process.Start(Path);
        }
    }
}
