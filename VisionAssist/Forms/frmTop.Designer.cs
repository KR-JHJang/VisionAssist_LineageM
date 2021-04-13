
namespace VisionAssist.Forms
{
    partial class frmTop
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
            this.grbMP = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.gtbHeal = new System.Windows.Forms.GroupBox();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton16 = new System.Windows.Forms.RadioButton();
            this.radioButton17 = new System.Windows.Forms.RadioButton();
            this.radioButton18 = new System.Windows.Forms.RadioButton();
            this.radioButton19 = new System.Windows.Forms.RadioButton();
            this.radioButton20 = new System.Windows.Forms.RadioButton();
            this.grbSkill1 = new System.Windows.Forms.GroupBox();
            this.radioButton31 = new System.Windows.Forms.RadioButton();
            this.radioButton32 = new System.Windows.Forms.RadioButton();
            this.radioButton33 = new System.Windows.Forms.RadioButton();
            this.radioButton34 = new System.Windows.Forms.RadioButton();
            this.radioButton35 = new System.Windows.Forms.RadioButton();
            this.radioButton36 = new System.Windows.Forms.RadioButton();
            this.radioButton37 = new System.Windows.Forms.RadioButton();
            this.radioButton38 = new System.Windows.Forms.RadioButton();
            this.radioButton39 = new System.Windows.Forms.RadioButton();
            this.radioButton40 = new System.Windows.Forms.RadioButton();
            this.grbEvade = new System.Windows.Forms.GroupBox();
            this.radioButton41 = new System.Windows.Forms.RadioButton();
            this.radioButton42 = new System.Windows.Forms.RadioButton();
            this.radioButton43 = new System.Windows.Forms.RadioButton();
            this.radioButton44 = new System.Windows.Forms.RadioButton();
            this.radioButton45 = new System.Windows.Forms.RadioButton();
            this.radioButton46 = new System.Windows.Forms.RadioButton();
            this.radioButton47 = new System.Windows.Forms.RadioButton();
            this.radioButton48 = new System.Windows.Forms.RadioButton();
            this.radioButton49 = new System.Windows.Forms.RadioButton();
            this.radioButton50 = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.bgwRunFlag = new System.ComponentModel.BackgroundWorker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.grbMP.SuspendLayout();
            this.gtbHeal.SuspendLayout();
            this.grbSkill1.SuspendLayout();
            this.grbEvade.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbMP
            // 
            this.grbMP.Controls.Add(this.radioButton10);
            this.grbMP.Controls.Add(this.radioButton5);
            this.grbMP.Controls.Add(this.radioButton9);
            this.grbMP.Controls.Add(this.radioButton4);
            this.grbMP.Controls.Add(this.radioButton8);
            this.grbMP.Controls.Add(this.radioButton3);
            this.grbMP.Controls.Add(this.radioButton7);
            this.grbMP.Controls.Add(this.radioButton2);
            this.grbMP.Controls.Add(this.radioButton6);
            this.grbMP.Controls.Add(this.radioButton1);
            this.grbMP.Location = new System.Drawing.Point(192, 20);
            this.grbMP.Name = "grbMP";
            this.grbMP.Size = new System.Drawing.Size(188, 60);
            this.grbMP.TabIndex = 2;
            this.grbMP.TabStop = false;
            this.grbMP.Text = "자동 마나 스킬 위치";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 15);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(29, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(41, 15);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(29, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(76, 15);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(29, 16);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.Text = "3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(111, 15);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(29, 16);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.Text = "4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(146, 15);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(29, 16);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.Text = "5";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(6, 37);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(29, 16);
            this.radioButton6.TabIndex = 0;
            this.radioButton6.Text = "6";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(41, 37);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(29, 16);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.Text = "7";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(76, 37);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(29, 16);
            this.radioButton8.TabIndex = 0;
            this.radioButton8.Text = "8";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(111, 37);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(29, 16);
            this.radioButton9.TabIndex = 1;
            this.radioButton9.Text = "9";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(146, 37);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(35, 16);
            this.radioButton10.TabIndex = 1;
            this.radioButton10.Text = "10";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // gtbHeal
            // 
            this.gtbHeal.Controls.Add(this.radioButton11);
            this.gtbHeal.Controls.Add(this.radioButton12);
            this.gtbHeal.Controls.Add(this.radioButton13);
            this.gtbHeal.Controls.Add(this.radioButton14);
            this.gtbHeal.Controls.Add(this.radioButton15);
            this.gtbHeal.Controls.Add(this.radioButton16);
            this.gtbHeal.Controls.Add(this.radioButton17);
            this.gtbHeal.Controls.Add(this.radioButton18);
            this.gtbHeal.Controls.Add(this.radioButton19);
            this.gtbHeal.Controls.Add(this.radioButton20);
            this.gtbHeal.Location = new System.Drawing.Point(3, 20);
            this.gtbHeal.Name = "gtbHeal";
            this.gtbHeal.Size = new System.Drawing.Size(183, 60);
            this.gtbHeal.TabIndex = 2;
            this.gtbHeal.TabStop = false;
            this.gtbHeal.Text = "자동 힐 스킬 위치";
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(146, 37);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(35, 16);
            this.radioButton11.TabIndex = 1;
            this.radioButton11.Text = "10";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // radioButton12
            // 
            this.radioButton12.AutoSize = true;
            this.radioButton12.Location = new System.Drawing.Point(146, 15);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(29, 16);
            this.radioButton12.TabIndex = 1;
            this.radioButton12.Text = "5";
            this.radioButton12.UseVisualStyleBackColor = true;
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(111, 37);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(29, 16);
            this.radioButton13.TabIndex = 1;
            this.radioButton13.Text = "9";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(111, 15);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(29, 16);
            this.radioButton14.TabIndex = 1;
            this.radioButton14.Text = "4";
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(76, 37);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(29, 16);
            this.radioButton15.TabIndex = 0;
            this.radioButton15.Text = "8";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton16
            // 
            this.radioButton16.AutoSize = true;
            this.radioButton16.Location = new System.Drawing.Point(76, 15);
            this.radioButton16.Name = "radioButton16";
            this.radioButton16.Size = new System.Drawing.Size(29, 16);
            this.radioButton16.TabIndex = 0;
            this.radioButton16.Text = "3";
            this.radioButton16.UseVisualStyleBackColor = true;
            // 
            // radioButton17
            // 
            this.radioButton17.AutoSize = true;
            this.radioButton17.Location = new System.Drawing.Point(41, 37);
            this.radioButton17.Name = "radioButton17";
            this.radioButton17.Size = new System.Drawing.Size(29, 16);
            this.radioButton17.TabIndex = 1;
            this.radioButton17.Text = "7";
            this.radioButton17.UseVisualStyleBackColor = true;
            // 
            // radioButton18
            // 
            this.radioButton18.AutoSize = true;
            this.radioButton18.Location = new System.Drawing.Point(41, 15);
            this.radioButton18.Name = "radioButton18";
            this.radioButton18.Size = new System.Drawing.Size(29, 16);
            this.radioButton18.TabIndex = 1;
            this.radioButton18.Text = "2";
            this.radioButton18.UseVisualStyleBackColor = true;
            // 
            // radioButton19
            // 
            this.radioButton19.AutoSize = true;
            this.radioButton19.Location = new System.Drawing.Point(6, 37);
            this.radioButton19.Name = "radioButton19";
            this.radioButton19.Size = new System.Drawing.Size(29, 16);
            this.radioButton19.TabIndex = 0;
            this.radioButton19.Text = "6";
            this.radioButton19.UseVisualStyleBackColor = true;
            // 
            // radioButton20
            // 
            this.radioButton20.AutoSize = true;
            this.radioButton20.Checked = true;
            this.radioButton20.Location = new System.Drawing.Point(6, 15);
            this.radioButton20.Name = "radioButton20";
            this.radioButton20.Size = new System.Drawing.Size(29, 16);
            this.radioButton20.TabIndex = 0;
            this.radioButton20.TabStop = true;
            this.radioButton20.Text = "1";
            this.radioButton20.UseVisualStyleBackColor = true;
            // 
            // grbSkill1
            // 
            this.grbSkill1.Controls.Add(this.radioButton31);
            this.grbSkill1.Controls.Add(this.radioButton32);
            this.grbSkill1.Controls.Add(this.radioButton33);
            this.grbSkill1.Controls.Add(this.radioButton34);
            this.grbSkill1.Controls.Add(this.radioButton35);
            this.grbSkill1.Controls.Add(this.radioButton36);
            this.grbSkill1.Controls.Add(this.radioButton37);
            this.grbSkill1.Controls.Add(this.radioButton38);
            this.grbSkill1.Controls.Add(this.radioButton39);
            this.grbSkill1.Controls.Add(this.radioButton40);
            this.grbSkill1.Location = new System.Drawing.Point(386, 20);
            this.grbSkill1.Name = "grbSkill1";
            this.grbSkill1.Size = new System.Drawing.Size(183, 60);
            this.grbSkill1.TabIndex = 2;
            this.grbSkill1.TabStop = false;
            this.grbSkill1.Text = "자동 공격 스킬 위치";
            // 
            // radioButton31
            // 
            this.radioButton31.AutoSize = true;
            this.radioButton31.Location = new System.Drawing.Point(146, 37);
            this.radioButton31.Name = "radioButton31";
            this.radioButton31.Size = new System.Drawing.Size(35, 16);
            this.radioButton31.TabIndex = 1;
            this.radioButton31.Text = "10";
            this.radioButton31.UseVisualStyleBackColor = true;
            // 
            // radioButton32
            // 
            this.radioButton32.AutoSize = true;
            this.radioButton32.Location = new System.Drawing.Point(146, 15);
            this.radioButton32.Name = "radioButton32";
            this.radioButton32.Size = new System.Drawing.Size(29, 16);
            this.radioButton32.TabIndex = 1;
            this.radioButton32.Text = "5";
            this.radioButton32.UseVisualStyleBackColor = true;
            // 
            // radioButton33
            // 
            this.radioButton33.AutoSize = true;
            this.radioButton33.Location = new System.Drawing.Point(111, 37);
            this.radioButton33.Name = "radioButton33";
            this.radioButton33.Size = new System.Drawing.Size(29, 16);
            this.radioButton33.TabIndex = 1;
            this.radioButton33.Text = "9";
            this.radioButton33.UseVisualStyleBackColor = true;
            // 
            // radioButton34
            // 
            this.radioButton34.AutoSize = true;
            this.radioButton34.Location = new System.Drawing.Point(111, 15);
            this.radioButton34.Name = "radioButton34";
            this.radioButton34.Size = new System.Drawing.Size(29, 16);
            this.radioButton34.TabIndex = 1;
            this.radioButton34.Text = "4";
            this.radioButton34.UseVisualStyleBackColor = true;
            // 
            // radioButton35
            // 
            this.radioButton35.AutoSize = true;
            this.radioButton35.Location = new System.Drawing.Point(76, 37);
            this.radioButton35.Name = "radioButton35";
            this.radioButton35.Size = new System.Drawing.Size(29, 16);
            this.radioButton35.TabIndex = 0;
            this.radioButton35.Text = "8";
            this.radioButton35.UseVisualStyleBackColor = true;
            // 
            // radioButton36
            // 
            this.radioButton36.AutoSize = true;
            this.radioButton36.Location = new System.Drawing.Point(76, 15);
            this.radioButton36.Name = "radioButton36";
            this.radioButton36.Size = new System.Drawing.Size(29, 16);
            this.radioButton36.TabIndex = 0;
            this.radioButton36.Text = "3";
            this.radioButton36.UseVisualStyleBackColor = true;
            // 
            // radioButton37
            // 
            this.radioButton37.AutoSize = true;
            this.radioButton37.Location = new System.Drawing.Point(41, 37);
            this.radioButton37.Name = "radioButton37";
            this.radioButton37.Size = new System.Drawing.Size(29, 16);
            this.radioButton37.TabIndex = 1;
            this.radioButton37.Text = "7";
            this.radioButton37.UseVisualStyleBackColor = true;
            // 
            // radioButton38
            // 
            this.radioButton38.AutoSize = true;
            this.radioButton38.Location = new System.Drawing.Point(41, 15);
            this.radioButton38.Name = "radioButton38";
            this.radioButton38.Size = new System.Drawing.Size(29, 16);
            this.radioButton38.TabIndex = 1;
            this.radioButton38.Text = "2";
            this.radioButton38.UseVisualStyleBackColor = true;
            // 
            // radioButton39
            // 
            this.radioButton39.AutoSize = true;
            this.radioButton39.Location = new System.Drawing.Point(6, 37);
            this.radioButton39.Name = "radioButton39";
            this.radioButton39.Size = new System.Drawing.Size(29, 16);
            this.radioButton39.TabIndex = 0;
            this.radioButton39.Text = "6";
            this.radioButton39.UseVisualStyleBackColor = true;
            // 
            // radioButton40
            // 
            this.radioButton40.AutoSize = true;
            this.radioButton40.Checked = true;
            this.radioButton40.Location = new System.Drawing.Point(6, 15);
            this.radioButton40.Name = "radioButton40";
            this.radioButton40.Size = new System.Drawing.Size(29, 16);
            this.radioButton40.TabIndex = 0;
            this.radioButton40.TabStop = true;
            this.radioButton40.Text = "1";
            this.radioButton40.UseVisualStyleBackColor = true;
            // 
            // grbEvade
            // 
            this.grbEvade.Controls.Add(this.radioButton41);
            this.grbEvade.Controls.Add(this.radioButton42);
            this.grbEvade.Controls.Add(this.radioButton43);
            this.grbEvade.Controls.Add(this.radioButton44);
            this.grbEvade.Controls.Add(this.radioButton45);
            this.grbEvade.Controls.Add(this.radioButton46);
            this.grbEvade.Controls.Add(this.radioButton47);
            this.grbEvade.Controls.Add(this.radioButton48);
            this.grbEvade.Controls.Add(this.radioButton49);
            this.grbEvade.Controls.Add(this.radioButton50);
            this.grbEvade.Location = new System.Drawing.Point(575, 20);
            this.grbEvade.Name = "grbEvade";
            this.grbEvade.Size = new System.Drawing.Size(188, 60);
            this.grbEvade.TabIndex = 3;
            this.grbEvade.TabStop = false;
            this.grbEvade.Text = "공격 회피 아이템 위치";
            // 
            // radioButton41
            // 
            this.radioButton41.AutoSize = true;
            this.radioButton41.Location = new System.Drawing.Point(146, 37);
            this.radioButton41.Name = "radioButton41";
            this.radioButton41.Size = new System.Drawing.Size(35, 16);
            this.radioButton41.TabIndex = 1;
            this.radioButton41.Text = "10";
            this.radioButton41.UseVisualStyleBackColor = true;
            // 
            // radioButton42
            // 
            this.radioButton42.AutoSize = true;
            this.radioButton42.Location = new System.Drawing.Point(146, 15);
            this.radioButton42.Name = "radioButton42";
            this.radioButton42.Size = new System.Drawing.Size(29, 16);
            this.radioButton42.TabIndex = 1;
            this.radioButton42.Text = "5";
            this.radioButton42.UseVisualStyleBackColor = true;
            // 
            // radioButton43
            // 
            this.radioButton43.AutoSize = true;
            this.radioButton43.Location = new System.Drawing.Point(111, 37);
            this.radioButton43.Name = "radioButton43";
            this.radioButton43.Size = new System.Drawing.Size(29, 16);
            this.radioButton43.TabIndex = 1;
            this.radioButton43.Text = "9";
            this.radioButton43.UseVisualStyleBackColor = true;
            // 
            // radioButton44
            // 
            this.radioButton44.AutoSize = true;
            this.radioButton44.Location = new System.Drawing.Point(111, 15);
            this.radioButton44.Name = "radioButton44";
            this.radioButton44.Size = new System.Drawing.Size(29, 16);
            this.radioButton44.TabIndex = 1;
            this.radioButton44.Text = "4";
            this.radioButton44.UseVisualStyleBackColor = true;
            // 
            // radioButton45
            // 
            this.radioButton45.AutoSize = true;
            this.radioButton45.Location = new System.Drawing.Point(76, 37);
            this.radioButton45.Name = "radioButton45";
            this.radioButton45.Size = new System.Drawing.Size(29, 16);
            this.radioButton45.TabIndex = 0;
            this.radioButton45.Text = "8";
            this.radioButton45.UseVisualStyleBackColor = true;
            // 
            // radioButton46
            // 
            this.radioButton46.AutoSize = true;
            this.radioButton46.Location = new System.Drawing.Point(76, 15);
            this.radioButton46.Name = "radioButton46";
            this.radioButton46.Size = new System.Drawing.Size(29, 16);
            this.radioButton46.TabIndex = 0;
            this.radioButton46.Text = "3";
            this.radioButton46.UseVisualStyleBackColor = true;
            // 
            // radioButton47
            // 
            this.radioButton47.AutoSize = true;
            this.radioButton47.Location = new System.Drawing.Point(41, 37);
            this.radioButton47.Name = "radioButton47";
            this.radioButton47.Size = new System.Drawing.Size(29, 16);
            this.radioButton47.TabIndex = 1;
            this.radioButton47.Text = "7";
            this.radioButton47.UseVisualStyleBackColor = true;
            // 
            // radioButton48
            // 
            this.radioButton48.AutoSize = true;
            this.radioButton48.Location = new System.Drawing.Point(41, 15);
            this.radioButton48.Name = "radioButton48";
            this.radioButton48.Size = new System.Drawing.Size(29, 16);
            this.radioButton48.TabIndex = 1;
            this.radioButton48.Text = "2";
            this.radioButton48.UseVisualStyleBackColor = true;
            // 
            // radioButton49
            // 
            this.radioButton49.AutoSize = true;
            this.radioButton49.Location = new System.Drawing.Point(6, 37);
            this.radioButton49.Name = "radioButton49";
            this.radioButton49.Size = new System.Drawing.Size(29, 16);
            this.radioButton49.TabIndex = 0;
            this.radioButton49.Text = "6";
            this.radioButton49.UseVisualStyleBackColor = true;
            // 
            // radioButton50
            // 
            this.radioButton50.AutoSize = true;
            this.radioButton50.Checked = true;
            this.radioButton50.Location = new System.Drawing.Point(6, 15);
            this.radioButton50.Name = "radioButton50";
            this.radioButton50.Size = new System.Drawing.Size(29, 16);
            this.radioButton50.TabIndex = 0;
            this.radioButton50.TabStop = true;
            this.radioButton50.Text = "1";
            this.radioButton50.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Red;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Yellow;
            this.btnStart.Location = new System.Drawing.Point(1039, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(132, 77);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Blue;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.Yellow;
            this.btnStop.Location = new System.Drawing.Point(1177, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 77);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // bgwRunFlag
            // 
            this.bgwRunFlag.WorkerReportsProgress = true;
            this.bgwRunFlag.WorkerSupportsCancellation = true;
            this.bgwRunFlag.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRunFlag_DoWork);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Tag = "1";
            this.checkBox1.Text = "사용";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(198, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Tag = "2";
            this.checkBox2.Text = "사용";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(392, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Tag = "3";
            this.checkBox3.Text = "사용";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(581, 3);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 16);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Tag = "4";
            this.checkBox4.Text = "사용";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // frmTop
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grbEvade);
            this.Controls.Add(this.grbSkill1);
            this.Controls.Add(this.gtbHeal);
            this.Controls.Add(this.grbMP);
            this.Name = "frmTop";
            this.Size = new System.Drawing.Size(1260, 85);
            this.grbMP.ResumeLayout(false);
            this.grbMP.PerformLayout();
            this.gtbHeal.ResumeLayout(false);
            this.gtbHeal.PerformLayout();
            this.grbSkill1.ResumeLayout(false);
            this.grbSkill1.PerformLayout();
            this.grbEvade.ResumeLayout(false);
            this.grbEvade.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grbMP;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox gtbHeal;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton12;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.RadioButton radioButton16;
        private System.Windows.Forms.RadioButton radioButton17;
        private System.Windows.Forms.RadioButton radioButton18;
        private System.Windows.Forms.RadioButton radioButton19;
        private System.Windows.Forms.RadioButton radioButton20;
        private System.Windows.Forms.GroupBox grbSkill1;
        private System.Windows.Forms.RadioButton radioButton31;
        private System.Windows.Forms.RadioButton radioButton32;
        private System.Windows.Forms.RadioButton radioButton33;
        private System.Windows.Forms.RadioButton radioButton34;
        private System.Windows.Forms.RadioButton radioButton35;
        private System.Windows.Forms.RadioButton radioButton36;
        private System.Windows.Forms.RadioButton radioButton37;
        private System.Windows.Forms.RadioButton radioButton38;
        private System.Windows.Forms.RadioButton radioButton39;
        private System.Windows.Forms.RadioButton radioButton40;
        private System.Windows.Forms.GroupBox grbEvade;
        private System.Windows.Forms.RadioButton radioButton41;
        private System.Windows.Forms.RadioButton radioButton42;
        private System.Windows.Forms.RadioButton radioButton43;
        private System.Windows.Forms.RadioButton radioButton44;
        private System.Windows.Forms.RadioButton radioButton45;
        private System.Windows.Forms.RadioButton radioButton46;
        private System.Windows.Forms.RadioButton radioButton47;
        private System.Windows.Forms.RadioButton radioButton48;
        private System.Windows.Forms.RadioButton radioButton49;
        private System.Windows.Forms.RadioButton radioButton50;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.ComponentModel.BackgroundWorker bgwRunFlag;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
    }
}
