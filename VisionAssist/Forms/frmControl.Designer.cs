﻿
namespace VisionAssist.Forms
{
    partial class frmControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblMatchingRatio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUserAttackEvade = new System.Windows.Forms.CheckBox();
            this.picboxUserAttack = new System.Windows.Forms.PictureBox();
            this.tbxVUpper = new System.Windows.Forms.TextBox();
            this.tbxVLower = new System.Windows.Forms.TextBox();
            this.tbxSUpper = new System.Windows.Forms.TextBox();
            this.tbxSLower = new System.Windows.Forms.TextBox();
            this.tbxUpper = new System.Windows.Forms.TextBox();
            this.tbxLower = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblMatchingRatioMP = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkRefillMP = new System.Windows.Forms.CheckBox();
            this.picboxMP = new System.Windows.Forms.PictureBox();
            this.trBarMP = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMatchingRatioHP = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAvoidHP = new System.Windows.Forms.CheckBox();
            this.chkRefillHP = new System.Windows.Forms.CheckBox();
            this.picboxHP = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trBarHP = new System.Windows.Forms.TrackBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.picboxColorBlue = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picboxColorRed = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGetPattern = new System.Windows.Forms.Button();
            this.picGetImage = new System.Windows.Forms.PictureBox();
            this.tbxSearchMessage = new System.Windows.Forms.TextBox();
            this.ttHP = new System.Windows.Forms.ToolTip(this.components);
            this.ttMP = new System.Windows.Forms.ToolTip(this.components);
            this.bgwExcuteEvade = new System.ComponentModel.BackgroundWorker();
            this.bgwSearchSkillPos = new System.ComponentModel.BackgroundWorker();
            this.bgwEvadeAttack = new System.ComponentModel.BackgroundWorker();
            this.bgwMP = new System.ComponentModel.BackgroundWorker();
            this.bgwHP = new System.ComponentModel.BackgroundWorker();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxUserAttack)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxMP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarMP)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarHP)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxColorBlue)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxColorRed)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGetImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage4);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabMain.Location = new System.Drawing.Point(0, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(230, 632);
            this.tabMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DimGray;
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.tbxVUpper);
            this.tabPage1.Controls.Add(this.tbxVLower);
            this.tabPage1.Controls.Add(this.tbxSUpper);
            this.tabPage1.Controls.Add(this.tbxSLower);
            this.tabPage1.Controls.Add(this.tbxUpper);
            this.tabPage1.Controls.Add(this.tbxLower);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(222, 606);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblMatchingRatio);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.chkUserAttackEvade);
            this.groupBox5.Controls.Add(this.picboxUserAttack);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 311);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(216, 69);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "공격회피";
            // 
            // lblMatchingRatio
            // 
            this.lblMatchingRatio.AutoSize = true;
            this.lblMatchingRatio.ForeColor = System.Drawing.Color.Lime;
            this.lblMatchingRatio.Location = new System.Drawing.Point(121, 47);
            this.lblMatchingRatio.Name = "lblMatchingRatio";
            this.lblMatchingRatio.Size = new System.Drawing.Size(41, 12);
            this.lblMatchingRatio.TabIndex = 3;
            this.lblMatchingRatio.Text = "0.00 %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(94, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "M.R";
            // 
            // chkUserAttackEvade
            // 
            this.chkUserAttackEvade.AutoSize = true;
            this.chkUserAttackEvade.Checked = true;
            this.chkUserAttackEvade.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserAttackEvade.ForeColor = System.Drawing.Color.Snow;
            this.chkUserAttackEvade.Location = new System.Drawing.Point(6, 20);
            this.chkUserAttackEvade.Name = "chkUserAttackEvade";
            this.chkUserAttackEvade.Size = new System.Drawing.Size(140, 16);
            this.chkUserAttackEvade.TabIndex = 2;
            this.chkUserAttackEvade.Text = "공격받을 시 회피하기";
            this.chkUserAttackEvade.UseVisualStyleBackColor = true;
            // 
            // picboxUserAttack
            // 
            this.picboxUserAttack.Location = new System.Drawing.Point(168, 16);
            this.picboxUserAttack.Name = "picboxUserAttack";
            this.picboxUserAttack.Size = new System.Drawing.Size(42, 47);
            this.picboxUserAttack.TabIndex = 1;
            this.picboxUserAttack.TabStop = false;
            // 
            // tbxVUpper
            // 
            this.tbxVUpper.Location = new System.Drawing.Point(6, 579);
            this.tbxVUpper.Name = "tbxVUpper";
            this.tbxVUpper.Size = new System.Drawing.Size(100, 21);
            this.tbxVUpper.TabIndex = 13;
            this.tbxVUpper.Text = "0";
            this.tbxVUpper.Visible = false;
            // 
            // tbxVLower
            // 
            this.tbxVLower.Location = new System.Drawing.Point(6, 551);
            this.tbxVLower.Name = "tbxVLower";
            this.tbxVLower.Size = new System.Drawing.Size(100, 21);
            this.tbxVLower.TabIndex = 12;
            this.tbxVLower.Text = "0";
            this.tbxVLower.Visible = false;
            // 
            // tbxSUpper
            // 
            this.tbxSUpper.Location = new System.Drawing.Point(6, 524);
            this.tbxSUpper.Name = "tbxSUpper";
            this.tbxSUpper.Size = new System.Drawing.Size(100, 21);
            this.tbxSUpper.TabIndex = 11;
            this.tbxSUpper.Text = "0";
            this.tbxSUpper.Visible = false;
            // 
            // tbxSLower
            // 
            this.tbxSLower.Location = new System.Drawing.Point(6, 496);
            this.tbxSLower.Name = "tbxSLower";
            this.tbxSLower.Size = new System.Drawing.Size(100, 21);
            this.tbxSLower.TabIndex = 10;
            this.tbxSLower.Text = "0";
            this.tbxSLower.Visible = false;
            // 
            // tbxUpper
            // 
            this.tbxUpper.Location = new System.Drawing.Point(6, 469);
            this.tbxUpper.Name = "tbxUpper";
            this.tbxUpper.Size = new System.Drawing.Size(100, 21);
            this.tbxUpper.TabIndex = 9;
            this.tbxUpper.Text = "0";
            this.tbxUpper.Visible = false;
            // 
            // tbxLower
            // 
            this.tbxLower.Location = new System.Drawing.Point(6, 441);
            this.tbxLower.Name = "tbxLower";
            this.tbxLower.Size = new System.Drawing.Size(100, 21);
            this.tbxLower.TabIndex = 8;
            this.tbxLower.Text = "0";
            this.tbxLower.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblMatchingRatioMP);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.chkRefillMP);
            this.groupBox4.Controls.Add(this.picboxMP);
            this.groupBox4.Controls.Add(this.trBarMP);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 190);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(216, 121);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MP";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // lblMatchingRatioMP
            // 
            this.lblMatchingRatioMP.AutoSize = true;
            this.lblMatchingRatioMP.ForeColor = System.Drawing.Color.Lime;
            this.lblMatchingRatioMP.Location = new System.Drawing.Point(168, 54);
            this.lblMatchingRatioMP.Name = "lblMatchingRatioMP";
            this.lblMatchingRatioMP.Size = new System.Drawing.Size(41, 12);
            this.lblMatchingRatioMP.TabIndex = 3;
            this.lblMatchingRatioMP.Text = "0.00 %";
            this.lblMatchingRatioMP.Click += new System.EventHandler(this.lblMatchingRatioMP_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(134, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "M.R";
            // 
            // chkRefillMP
            // 
            this.chkRefillMP.AutoSize = true;
            this.chkRefillMP.Checked = true;
            this.chkRefillMP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRefillMP.ForeColor = System.Drawing.Color.Snow;
            this.chkRefillMP.Location = new System.Drawing.Point(8, 53);
            this.chkRefillMP.Name = "chkRefillMP";
            this.chkRefillMP.Size = new System.Drawing.Size(88, 16);
            this.chkRefillMP.TabIndex = 3;
            this.chkRefillMP.Text = "마나 채우기";
            this.chkRefillMP.UseVisualStyleBackColor = true;
            this.chkRefillMP.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // picboxMP
            // 
            this.picboxMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.picboxMP.Location = new System.Drawing.Point(3, 17);
            this.picboxMP.Name = "picboxMP";
            this.picboxMP.Size = new System.Drawing.Size(210, 30);
            this.picboxMP.TabIndex = 2;
            this.picboxMP.TabStop = false;
            // 
            // trBarMP
            // 
            this.trBarMP.BackColor = System.Drawing.Color.DarkBlue;
            this.trBarMP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trBarMP.LargeChange = 1;
            this.trBarMP.Location = new System.Drawing.Point(3, 73);
            this.trBarMP.Minimum = 1;
            this.trBarMP.Name = "trBarMP";
            this.trBarMP.Size = new System.Drawing.Size(210, 45);
            this.trBarMP.TabIndex = 0;
            this.trBarMP.Value = 5;
            this.trBarMP.Scroll += new System.EventHandler(this.trBarMP_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblMatchingRatioHP);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.chkAvoidHP);
            this.groupBox3.Controls.Add(this.chkRefillHP);
            this.groupBox3.Controls.Add(this.picboxHP);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.trBarHP);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 187);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "HP";
            // 
            // lblMatchingRatioHP
            // 
            this.lblMatchingRatioHP.AutoSize = true;
            this.lblMatchingRatioHP.ForeColor = System.Drawing.Color.Lime;
            this.lblMatchingRatioHP.Location = new System.Drawing.Point(168, 52);
            this.lblMatchingRatioHP.Name = "lblMatchingRatioHP";
            this.lblMatchingRatioHP.Size = new System.Drawing.Size(41, 12);
            this.lblMatchingRatioHP.TabIndex = 4;
            this.lblMatchingRatioHP.Text = "0.00 %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(134, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "M.R";
            // 
            // chkAvoidHP
            // 
            this.chkAvoidHP.AutoSize = true;
            this.chkAvoidHP.Checked = true;
            this.chkAvoidHP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAvoidHP.ForeColor = System.Drawing.Color.Snow;
            this.chkAvoidHP.Location = new System.Drawing.Point(8, 120);
            this.chkAvoidHP.Name = "chkAvoidHP";
            this.chkAvoidHP.Size = new System.Drawing.Size(156, 16);
            this.chkAvoidHP.TabIndex = 6;
            this.chkAvoidHP.Text = "일정 체력 이하 회피하기";
            this.chkAvoidHP.UseVisualStyleBackColor = true;
            // 
            // chkRefillHP
            // 
            this.chkRefillHP.AutoSize = true;
            this.chkRefillHP.Checked = true;
            this.chkRefillHP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRefillHP.ForeColor = System.Drawing.Color.Snow;
            this.chkRefillHP.Location = new System.Drawing.Point(8, 51);
            this.chkRefillHP.Name = "chkRefillHP";
            this.chkRefillHP.Size = new System.Drawing.Size(88, 16);
            this.chkRefillHP.TabIndex = 6;
            this.chkRefillHP.Text = "체력 채우기";
            this.chkRefillHP.UseVisualStyleBackColor = true;
            // 
            // picboxHP
            // 
            this.picboxHP.Dock = System.Windows.Forms.DockStyle.Top;
            this.picboxHP.Location = new System.Drawing.Point(3, 17);
            this.picboxHP.Name = "picboxHP";
            this.picboxHP.Size = new System.Drawing.Size(210, 30);
            this.picboxHP.TabIndex = 1;
            this.picboxHP.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.DarkRed;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(3, 136);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(210, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Value = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trBarHP_Scroll);
            // 
            // trBarHP
            // 
            this.trBarHP.BackColor = System.Drawing.Color.DarkRed;
            this.trBarHP.LargeChange = 1;
            this.trBarHP.Location = new System.Drawing.Point(3, 67);
            this.trBarHP.Minimum = 1;
            this.trBarHP.Name = "trBarHP";
            this.trBarHP.Size = new System.Drawing.Size(210, 45);
            this.trBarHP.TabIndex = 0;
            this.trBarHP.Value = 5;
            this.trBarHP.Scroll += new System.EventHandler(this.trBarHP_Scroll);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(222, 606);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Setting";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(222, 606);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox6);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(222, 606);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Admin";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.picboxColorBlue);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 214);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(216, 53);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "MP";
            // 
            // picboxColorBlue
            // 
            this.picboxColorBlue.Dock = System.Windows.Forms.DockStyle.Top;
            this.picboxColorBlue.Location = new System.Drawing.Point(3, 17);
            this.picboxColorBlue.Name = "picboxColorBlue";
            this.picboxColorBlue.Size = new System.Drawing.Size(210, 30);
            this.picboxColorBlue.TabIndex = 2;
            this.picboxColorBlue.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picboxColorRed);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 53);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HP";
            // 
            // picboxColorRed
            // 
            this.picboxColorRed.Dock = System.Windows.Forms.DockStyle.Top;
            this.picboxColorRed.Location = new System.Drawing.Point(3, 17);
            this.picboxColorRed.Name = "picboxColorRed";
            this.picboxColorRed.Size = new System.Drawing.Size(210, 30);
            this.picboxColorRed.TabIndex = 2;
            this.picboxColorRed.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGetPattern);
            this.groupBox1.Controls.Add(this.picGetImage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pattern Getting";
            // 
            // btnGetPattern
            // 
            this.btnGetPattern.Location = new System.Drawing.Point(144, 21);
            this.btnGetPattern.Name = "btnGetPattern";
            this.btnGetPattern.Size = new System.Drawing.Size(69, 53);
            this.btnGetPattern.TabIndex = 1;
            this.btnGetPattern.Text = "Get Pattern";
            this.btnGetPattern.UseVisualStyleBackColor = true;
            this.btnGetPattern.Click += new System.EventHandler(this.btnGetPattern_Click);
            // 
            // picGetImage
            // 
            this.picGetImage.Location = new System.Drawing.Point(7, 21);
            this.picGetImage.Name = "picGetImage";
            this.picGetImage.Size = new System.Drawing.Size(130, 130);
            this.picGetImage.TabIndex = 0;
            this.picGetImage.TabStop = false;
            // 
            // tbxSearchMessage
            // 
            this.tbxSearchMessage.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tbxSearchMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbxSearchMessage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSearchMessage.ForeColor = System.Drawing.Color.Yellow;
            this.tbxSearchMessage.Location = new System.Drawing.Point(0, 0);
            this.tbxSearchMessage.Name = "tbxSearchMessage";
            this.tbxSearchMessage.ReadOnly = true;
            this.tbxSearchMessage.Size = new System.Drawing.Size(230, 22);
            this.tbxSearchMessage.TabIndex = 5;
            this.tbxSearchMessage.Text = "Ready ";
            this.tbxSearchMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ttHP
            // 
            this.ttHP.AutomaticDelay = 50;
            this.ttHP.ShowAlways = true;
            // 
            // ttMP
            // 
            this.ttMP.AutomaticDelay = 50;
            this.ttMP.ShowAlways = true;
            // 
            // bgwExcuteEvade
            // 
            this.bgwExcuteEvade.WorkerReportsProgress = true;
            this.bgwExcuteEvade.WorkerSupportsCancellation = true;
            this.bgwExcuteEvade.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwExcuteEvade_DoWork);
            // 
            // bgwSearchSkillPos
            // 
            this.bgwSearchSkillPos.WorkerReportsProgress = true;
            this.bgwSearchSkillPos.WorkerSupportsCancellation = true;
            this.bgwSearchSkillPos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSearchSkillPos_DoWork);
            // 
            // bgwEvadeAttack
            // 
            this.bgwEvadeAttack.WorkerReportsProgress = true;
            this.bgwEvadeAttack.WorkerSupportsCancellation = true;
            this.bgwEvadeAttack.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwEvadeAttack_DoWork);
            // 
            // bgwMP
            // 
            this.bgwMP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMP_DoWork);
            // 
            // bgwHP
            // 
            this.bgwHP.WorkerReportsProgress = true;
            this.bgwHP.WorkerSupportsCancellation = true;
            this.bgwHP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwHP_DoWork);
            // 
            // frmControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.tbxSearchMessage);
            this.Controls.Add(this.tabMain);
            this.Name = "frmControl";
            this.Size = new System.Drawing.Size(230, 654);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxUserAttack)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxMP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarMP)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarHP)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxColorBlue)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxColorRed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGetImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbxSearchMessage;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picGetImage;
        private System.Windows.Forms.Button btnGetPattern;
        private System.Windows.Forms.TrackBar trBarHP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolTip ttHP;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TrackBar trBarMP;
        private System.Windows.Forms.ToolTip ttMP;
        private System.Windows.Forms.PictureBox picboxHP;
        private System.Windows.Forms.PictureBox picboxMP;
        private System.ComponentModel.BackgroundWorker bgwExcuteEvade;
        private System.ComponentModel.BackgroundWorker bgwSearchSkillPos;
        private System.Windows.Forms.TextBox tbxUpper;
        private System.Windows.Forms.TextBox tbxLower;
        private System.Windows.Forms.TextBox tbxVUpper;
        private System.Windows.Forms.TextBox tbxVLower;
        private System.Windows.Forms.TextBox tbxSUpper;
        private System.Windows.Forms.TextBox tbxSLower;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox picboxUserAttack;
        private System.Windows.Forms.CheckBox chkUserAttackEvade;
        private System.Windows.Forms.Label lblMatchingRatio;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker bgwEvadeAttack;
        private System.ComponentModel.BackgroundWorker bgwMP;
        private System.Windows.Forms.CheckBox chkRefillMP;
        private System.Windows.Forms.Label lblMatchingRatioMP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picboxColorRed;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PictureBox picboxColorBlue;
        private System.Windows.Forms.Label lblMatchingRatioHP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRefillHP;
        private System.Windows.Forms.CheckBox chkAvoidHP;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.ComponentModel.BackgroundWorker bgwHP;
    }
}