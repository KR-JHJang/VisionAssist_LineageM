
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControl));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblMatchingRatioEvade = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUserAttackEvade = new System.Windows.Forms.CheckBox();
            this.picboxUserAttack = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LedMP = new Sunny.UI.UILedDisplay();
            this.LedMaxMP = new Sunny.UI.UILedDisplay();
            this.lblMatchingRatioMP = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkRefillMP = new System.Windows.Forms.CheckBox();
            this.trBarMP = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LedHP = new Sunny.UI.UILedDisplay();
            this.LedMaxHP = new Sunny.UI.UILedDisplay();
            this.lblMatchingRatioHP = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAvoidHP = new System.Windows.Forms.CheckBox();
            this.chkRefillHP = new System.Windows.Forms.CheckBox();
            this.trBarHPEvade = new System.Windows.Forms.TrackBar();
            this.trBarHP = new System.Windows.Forms.TrackBar();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.picboxLoc = new System.Windows.Forms.PictureBox();
            this.picboxHP = new System.Windows.Forms.PictureBox();
            this.picboxMP = new System.Windows.Forms.PictureBox();
            this.picboxHPText = new System.Windows.Forms.PictureBox();
            this.chkHPTest = new System.Windows.Forms.CheckBox();
            this.tbxHPLower = new System.Windows.Forms.TextBox();
            this.tbxHPUpper = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.trBarMP)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBarHPEvade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarHP)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxMP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHPText)).BeginInit();
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
            this.groupBox5.Controls.Add(this.lblMatchingRatioEvade);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.chkUserAttackEvade);
            this.groupBox5.Controls.Add(this.picboxUserAttack);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 313);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(216, 69);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "공격회피";
            // 
            // lblMatchingRatioEvade
            // 
            this.lblMatchingRatioEvade.AutoSize = true;
            this.lblMatchingRatioEvade.ForeColor = System.Drawing.Color.Lime;
            this.lblMatchingRatioEvade.Location = new System.Drawing.Point(33, 46);
            this.lblMatchingRatioEvade.Name = "lblMatchingRatioEvade";
            this.lblMatchingRatioEvade.Size = new System.Drawing.Size(41, 12);
            this.lblMatchingRatioEvade.TabIndex = 3;
            this.lblMatchingRatioEvade.Text = "0.00 %";
            this.lblMatchingRatioEvade.Click += new System.EventHandler(this.lblMatchingRatioEvade_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "M.R";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.chkUserAttackEvade.CheckedChanged += new System.EventHandler(this.chkUserAttackEvade_CheckedChanged);
            // 
            // picboxUserAttack
            // 
            this.picboxUserAttack.Image = ((System.Drawing.Image)(resources.GetObject("picboxUserAttack.Image")));
            this.picboxUserAttack.Location = new System.Drawing.Point(168, 16);
            this.picboxUserAttack.Name = "picboxUserAttack";
            this.picboxUserAttack.Size = new System.Drawing.Size(42, 47);
            this.picboxUserAttack.TabIndex = 1;
            this.picboxUserAttack.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LedMP);
            this.groupBox4.Controls.Add(this.LedMaxMP);
            this.groupBox4.Controls.Add(this.lblMatchingRatioMP);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.chkRefillMP);
            this.groupBox4.Controls.Add(this.trBarMP);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(216, 121);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MP";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // LedMP
            // 
            this.LedMP.BackColor = System.Drawing.Color.Black;
            this.LedMP.CharCount = 5;
            this.LedMP.ForeColor = System.Drawing.Color.Cyan;
            this.LedMP.Location = new System.Drawing.Point(6, 13);
            this.LedMP.Name = "LedMP";
            this.LedMP.Size = new System.Drawing.Size(100, 34);
            this.LedMP.TabIndex = 11;
            this.LedMP.Text = "00000";
            // 
            // LedMaxMP
            // 
            this.LedMaxMP.BackColor = System.Drawing.Color.Black;
            this.LedMaxMP.CharCount = 5;
            this.LedMaxMP.ForeColor = System.Drawing.Color.Cyan;
            this.LedMaxMP.Location = new System.Drawing.Point(109, 13);
            this.LedMaxMP.Name = "LedMaxMP";
            this.LedMaxMP.Size = new System.Drawing.Size(100, 34);
            this.LedMaxMP.TabIndex = 12;
            this.LedMaxMP.Text = "00000";
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
            this.chkRefillMP.CheckedChanged += new System.EventHandler(this.chkRefillMP_CheckedChanged);
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
            this.groupBox3.Controls.Add(this.LedHP);
            this.groupBox3.Controls.Add(this.LedMaxHP);
            this.groupBox3.Controls.Add(this.lblMatchingRatioHP);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.chkAvoidHP);
            this.groupBox3.Controls.Add(this.chkRefillHP);
            this.groupBox3.Controls.Add(this.trBarHPEvade);
            this.groupBox3.Controls.Add(this.trBarHP);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(216, 189);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "HP";
            // 
            // LedHP
            // 
            this.LedHP.BackColor = System.Drawing.Color.Black;
            this.LedHP.CharCount = 5;
            this.LedHP.ForeColor = System.Drawing.Color.Yellow;
            this.LedHP.Location = new System.Drawing.Point(6, 13);
            this.LedHP.Name = "LedHP";
            this.LedHP.Size = new System.Drawing.Size(100, 34);
            this.LedHP.TabIndex = 10;
            this.LedHP.Text = "00000";
            // 
            // LedMaxHP
            // 
            this.LedMaxHP.BackColor = System.Drawing.Color.Black;
            this.LedMaxHP.CharCount = 5;
            this.LedMaxHP.ForeColor = System.Drawing.Color.Yellow;
            this.LedMaxHP.Location = new System.Drawing.Point(109, 13);
            this.LedMaxHP.Name = "LedMaxHP";
            this.LedMaxHP.Size = new System.Drawing.Size(100, 34);
            this.LedMaxHP.TabIndex = 10;
            this.LedMaxHP.Text = "00000";
            // 
            // lblMatchingRatioHP
            // 
            this.lblMatchingRatioHP.AutoSize = true;
            this.lblMatchingRatioHP.ForeColor = System.Drawing.Color.Lime;
            this.lblMatchingRatioHP.Location = new System.Drawing.Point(168, 54);
            this.lblMatchingRatioHP.Name = "lblMatchingRatioHP";
            this.lblMatchingRatioHP.Size = new System.Drawing.Size(41, 12);
            this.lblMatchingRatioHP.TabIndex = 4;
            this.lblMatchingRatioHP.Text = "0.00 %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(134, 54);
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
            this.chkAvoidHP.Location = new System.Drawing.Point(8, 122);
            this.chkAvoidHP.Name = "chkAvoidHP";
            this.chkAvoidHP.Size = new System.Drawing.Size(156, 16);
            this.chkAvoidHP.TabIndex = 6;
            this.chkAvoidHP.Text = "일정 체력 이하 회피하기";
            this.chkAvoidHP.UseVisualStyleBackColor = true;
            this.chkAvoidHP.CheckedChanged += new System.EventHandler(this.chkAvoidHP_CheckedChanged);
            // 
            // chkRefillHP
            // 
            this.chkRefillHP.AutoSize = true;
            this.chkRefillHP.Checked = true;
            this.chkRefillHP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRefillHP.ForeColor = System.Drawing.Color.Snow;
            this.chkRefillHP.Location = new System.Drawing.Point(8, 53);
            this.chkRefillHP.Name = "chkRefillHP";
            this.chkRefillHP.Size = new System.Drawing.Size(88, 16);
            this.chkRefillHP.TabIndex = 6;
            this.chkRefillHP.Text = "체력 채우기";
            this.chkRefillHP.UseVisualStyleBackColor = true;
            this.chkRefillHP.CheckedChanged += new System.EventHandler(this.chkRefillHP_CheckedChanged);
            // 
            // trBarHPEvade
            // 
            this.trBarHPEvade.BackColor = System.Drawing.Color.DarkRed;
            this.trBarHPEvade.LargeChange = 1;
            this.trBarHPEvade.Location = new System.Drawing.Point(3, 138);
            this.trBarHPEvade.Minimum = 1;
            this.trBarHPEvade.Name = "trBarHPEvade";
            this.trBarHPEvade.Size = new System.Drawing.Size(210, 45);
            this.trBarHPEvade.TabIndex = 0;
            this.trBarHPEvade.Value = 3;
            this.trBarHPEvade.Scroll += new System.EventHandler(this.trBarHPEvade_Scroll);
            // 
            // trBarHP
            // 
            this.trBarHP.BackColor = System.Drawing.Color.DarkRed;
            this.trBarHP.LargeChange = 1;
            this.trBarHP.Location = new System.Drawing.Point(3, 69);
            this.trBarHP.Minimum = 1;
            this.trBarHP.Name = "trBarHP";
            this.trBarHP.Size = new System.Drawing.Size(210, 45);
            this.trBarHP.TabIndex = 0;
            this.trBarHP.Value = 5;
            this.trBarHP.Scroll += new System.EventHandler(this.trBarHP_Scroll);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.picboxLoc);
            this.tabPage4.Controls.Add(this.picboxHP);
            this.tabPage4.Controls.Add(this.picboxMP);
            this.tabPage4.Controls.Add(this.picboxHPText);
            this.tabPage4.Controls.Add(this.chkHPTest);
            this.tabPage4.Controls.Add(this.tbxHPLower);
            this.tabPage4.Controls.Add(this.tbxHPUpper);
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
            // picboxLoc
            // 
            this.picboxLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.picboxLoc.Image = ((System.Drawing.Image)(resources.GetObject("picboxLoc.Image")));
            this.picboxLoc.Location = new System.Drawing.Point(3, 441);
            this.picboxLoc.Name = "picboxLoc";
            this.picboxLoc.Size = new System.Drawing.Size(216, 86);
            this.picboxLoc.TabIndex = 16;
            this.picboxLoc.TabStop = false;
            // 
            // picboxHP
            // 
            this.picboxHP.Dock = System.Windows.Forms.DockStyle.Top;
            this.picboxHP.Image = ((System.Drawing.Image)(resources.GetObject("picboxHP.Image")));
            this.picboxHP.Location = new System.Drawing.Point(3, 341);
            this.picboxHP.Name = "picboxHP";
            this.picboxHP.Size = new System.Drawing.Size(216, 100);
            this.picboxHP.TabIndex = 15;
            this.picboxHP.TabStop = false;
            // 
            // picboxMP
            // 
            this.picboxMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.picboxMP.Image = ((System.Drawing.Image)(resources.GetObject("picboxMP.Image")));
            this.picboxMP.Location = new System.Drawing.Point(3, 267);
            this.picboxMP.Name = "picboxMP";
            this.picboxMP.Size = new System.Drawing.Size(216, 74);
            this.picboxMP.TabIndex = 14;
            this.picboxMP.TabStop = false;
            // 
            // picboxHPText
            // 
            this.picboxHPText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picboxHPText.Image = ((System.Drawing.Image)(resources.GetObject("picboxHPText.Image")));
            this.picboxHPText.Location = new System.Drawing.Point(3, 560);
            this.picboxHPText.Name = "picboxHPText";
            this.picboxHPText.Size = new System.Drawing.Size(216, 43);
            this.picboxHPText.TabIndex = 13;
            this.picboxHPText.TabStop = false;
            // 
            // chkHPTest
            // 
            this.chkHPTest.AutoSize = true;
            this.chkHPTest.Location = new System.Drawing.Point(10, 535);
            this.chkHPTest.Name = "chkHPTest";
            this.chkHPTest.Size = new System.Drawing.Size(49, 16);
            this.chkHPTest.TabIndex = 12;
            this.chkHPTest.Text = "Test";
            this.chkHPTest.UseVisualStyleBackColor = true;
            this.chkHPTest.Visible = false;
            // 
            // tbxHPLower
            // 
            this.tbxHPLower.Location = new System.Drawing.Point(152, 533);
            this.tbxHPLower.Name = "tbxHPLower";
            this.tbxHPLower.Size = new System.Drawing.Size(61, 21);
            this.tbxHPLower.TabIndex = 10;
            this.tbxHPLower.Text = "0";
            this.tbxHPLower.Visible = false;
            // 
            // tbxHPUpper
            // 
            this.tbxHPUpper.Location = new System.Drawing.Point(89, 533);
            this.tbxHPUpper.Name = "tbxHPUpper";
            this.tbxHPUpper.Size = new System.Drawing.Size(61, 21);
            this.tbxHPUpper.TabIndex = 11;
            this.tbxHPUpper.Text = "0";
            this.tbxHPUpper.Visible = false;
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxUserAttack)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBarMP)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBarHPEvade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trBarHP)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxMP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxHPText)).EndInit();
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
        private System.Windows.Forms.TextBox tbxSearchMessage;
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
        private System.ComponentModel.BackgroundWorker bgwExcuteEvade;
        private System.ComponentModel.BackgroundWorker bgwSearchSkillPos;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox picboxUserAttack;
        private System.Windows.Forms.CheckBox chkUserAttackEvade;
        private System.Windows.Forms.Label lblMatchingRatioEvade;
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
        private System.Windows.Forms.TrackBar trBarHPEvade;
        private System.ComponentModel.BackgroundWorker bgwHP;
        private Sunny.UI.UILedDisplay LedMaxHP;
        private Sunny.UI.UILedDisplay LedHP;
        private Sunny.UI.UILedDisplay LedMP;
        private Sunny.UI.UILedDisplay LedMaxMP;
        private System.Windows.Forms.PictureBox picboxHPText;
        private System.Windows.Forms.CheckBox chkHPTest;
        private System.Windows.Forms.TextBox tbxHPLower;
        private System.Windows.Forms.TextBox tbxHPUpper;
        private System.Windows.Forms.PictureBox picboxHP;
        private System.Windows.Forms.PictureBox picboxMP;
        private System.Windows.Forms.PictureBox picboxLoc;
    }
}
