﻿
namespace VisionAssist
{
    partial class frmMain
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.cbxMaint = new System.Windows.Forms.CheckBox();
            this.cbxAppPlayer = new Sunny.UI.UIComboBox();
            this.chkDrawText = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxRealSizeHeight = new System.Windows.Forms.TextBox();
            this.tbxMouseStartPosY = new System.Windows.Forms.TextBox();
            this.tbxRealSizeWidth = new System.Windows.Forms.TextBox();
            this.tbxMouseEndPosY = new System.Windows.Forms.TextBox();
            this.tbxFormSizeHeight = new System.Windows.Forms.TextBox();
            this.tbxMouseStartPosX = new System.Windows.Forms.TextBox();
            this.tbxVisionSizeHeight = new System.Windows.Forms.TextBox();
            this.tbxMouseEndPosX = new System.Windows.Forms.TextBox();
            this.tbxFormSizeWidth = new System.Windows.Forms.TextBox();
            this.tbxVisionSizeWidth = new System.Windows.Forms.TextBox();
            this.tbxRealMouseY = new System.Windows.Forms.TextBox();
            this.tbxRealMouseX = new System.Windows.Forms.TextBox();
            this.tbxMouseY = new System.Windows.Forms.TextBox();
            this.tbxMouseX = new System.Windows.Forms.TextBox();
            this.pnlVision = new System.Windows.Forms.Panel();
            this.bgwSearchWindow = new System.ComponentModel.BackgroundWorker();
            this.bgwMousePosition = new System.ComponentModel.BackgroundWorker();
            this.bgwSizeChecker = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmnuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBottom.SuspendLayout();
            this.cmnuNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.DimGray;
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1030, 85);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(230, 654);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.DimGray;
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1260, 85);
            this.pnlTop.TabIndex = 4;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "exit-icon-png-close-0.png");
            this.imageList1.Images.SetKeyName(1, "main.png");
            this.imageList1.Images.SetKeyName(2, "SEO_Maintenance-512.png");
            this.imageList1.Images.SetKeyName(3, "SourceMeter.png");
            this.imageList1.Images.SetKeyName(4, "Spectormeter.png");
            this.imageList1.Images.SetKeyName(5, "gear-clipart-machine-gear-1.png");
            this.imageList1.Images.SetKeyName(6, "24-tv_101173.png");
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.DimGray;
            this.pnlBottom.Controls.Add(this.cbxMaint);
            this.pnlBottom.Controls.Add(this.cbxAppPlayer);
            this.pnlBottom.Controls.Add(this.chkDrawText);
            this.pnlBottom.Controls.Add(this.label2);
            this.pnlBottom.Controls.Add(this.label10);
            this.pnlBottom.Controls.Add(this.label6);
            this.pnlBottom.Controls.Add(this.label4);
            this.pnlBottom.Controls.Add(this.label9);
            this.pnlBottom.Controls.Add(this.label8);
            this.pnlBottom.Controls.Add(this.label7);
            this.pnlBottom.Controls.Add(this.label5);
            this.pnlBottom.Controls.Add(this.label3);
            this.pnlBottom.Controls.Add(this.label1);
            this.pnlBottom.Controls.Add(this.tbxRealSizeHeight);
            this.pnlBottom.Controls.Add(this.tbxMouseStartPosY);
            this.pnlBottom.Controls.Add(this.tbxRealSizeWidth);
            this.pnlBottom.Controls.Add(this.tbxMouseEndPosY);
            this.pnlBottom.Controls.Add(this.tbxFormSizeHeight);
            this.pnlBottom.Controls.Add(this.tbxMouseStartPosX);
            this.pnlBottom.Controls.Add(this.tbxVisionSizeHeight);
            this.pnlBottom.Controls.Add(this.tbxMouseEndPosX);
            this.pnlBottom.Controls.Add(this.tbxFormSizeWidth);
            this.pnlBottom.Controls.Add(this.tbxVisionSizeWidth);
            this.pnlBottom.Controls.Add(this.tbxRealMouseY);
            this.pnlBottom.Controls.Add(this.tbxRealMouseX);
            this.pnlBottom.Controls.Add(this.tbxMouseY);
            this.pnlBottom.Controls.Add(this.tbxMouseX);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 675);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1030, 64);
            this.pnlBottom.TabIndex = 6;
            this.pnlBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBottom_Paint);
            // 
            // cbxMaint
            // 
            this.cbxMaint.AutoSize = true;
            this.cbxMaint.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMaint.Location = new System.Drawing.Point(774, 34);
            this.cbxMaint.Name = "cbxMaint";
            this.cbxMaint.Size = new System.Drawing.Size(109, 21);
            this.cbxMaint.TabIndex = 4;
            this.cbxMaint.Text = "Maintenance";
            this.cbxMaint.UseVisualStyleBackColor = true;
            this.cbxMaint.CheckedChanged += new System.EventHandler(this.cbxMaint_CheckedChanged);
            // 
            // cbxAppPlayer
            // 
            this.cbxAppPlayer.DataSource = null;
            this.cbxAppPlayer.FillColor = System.Drawing.Color.White;
            this.cbxAppPlayer.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.cbxAppPlayer.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.cbxAppPlayer.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.cbxAppPlayer.ItemRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cbxAppPlayer.Items.AddRange(new object[] {
            "LDPlayer0",
            "LDPlayer1",
            "LDPlayer2",
            "LDPlayer3"});
            this.cbxAppPlayer.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cbxAppPlayer.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.cbxAppPlayer.Location = new System.Drawing.Point(896, 32);
            this.cbxAppPlayer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxAppPlayer.MinimumSize = new System.Drawing.Size(63, 0);
            this.cbxAppPlayer.Name = "cbxAppPlayer";
            this.cbxAppPlayer.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.cbxAppPlayer.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cbxAppPlayer.Size = new System.Drawing.Size(127, 29);
            this.cbxAppPlayer.Style = Sunny.UI.UIStyle.Red;
            this.cbxAppPlayer.TabIndex = 3;
            this.cbxAppPlayer.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbxAppPlayer.Watermark = "";
            this.cbxAppPlayer.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.cbxAppPlayer.SelectedIndexChanged += new System.EventHandler(this.cbxAppPlayer_SelectedIndexChanged);
            // 
            // chkDrawText
            // 
            this.chkDrawText.AutoSize = true;
            this.chkDrawText.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDrawText.Location = new System.Drawing.Point(676, 34);
            this.chkDrawText.Name = "chkDrawText";
            this.chkDrawText.Size = new System.Drawing.Size(92, 21);
            this.chkDrawText.TabIndex = 2;
            this.chkDrawText.Text = "Draw Text";
            this.chkDrawText.UseVisualStyleBackColor = true;
            this.chkDrawText.Visible = false;
            this.chkDrawText.CheckedChanged += new System.EventHandler(this.chkDrawText_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mouse Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(892, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "Select APP Player";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(673, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Real Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(137, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Real Pos Y";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(280, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Start Pos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(475, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Rect Size";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(280, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Form Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(475, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Vision Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(137, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Real Pos X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mouse X";
            // 
            // tbxRealSizeHeight
            // 
            this.tbxRealSizeHeight.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRealSizeHeight.Location = new System.Drawing.Point(796, 9);
            this.tbxRealSizeHeight.Name = "tbxRealSizeHeight";
            this.tbxRealSizeHeight.Size = new System.Drawing.Size(61, 22);
            this.tbxRealSizeHeight.TabIndex = 0;
            this.tbxRealSizeHeight.Text = "0000.0000";
            // 
            // tbxMouseStartPosY
            // 
            this.tbxMouseStartPosY.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMouseStartPosY.Location = new System.Drawing.Point(406, 33);
            this.tbxMouseStartPosY.Name = "tbxMouseStartPosY";
            this.tbxMouseStartPosY.Size = new System.Drawing.Size(61, 22);
            this.tbxMouseStartPosY.TabIndex = 0;
            this.tbxMouseStartPosY.Text = "0000.0000";
            // 
            // tbxRealSizeWidth
            // 
            this.tbxRealSizeWidth.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRealSizeWidth.Location = new System.Drawing.Point(732, 9);
            this.tbxRealSizeWidth.Name = "tbxRealSizeWidth";
            this.tbxRealSizeWidth.Size = new System.Drawing.Size(61, 22);
            this.tbxRealSizeWidth.TabIndex = 0;
            this.tbxRealSizeWidth.Text = "0000.0000";
            // 
            // tbxMouseEndPosY
            // 
            this.tbxMouseEndPosY.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMouseEndPosY.Location = new System.Drawing.Point(604, 33);
            this.tbxMouseEndPosY.Name = "tbxMouseEndPosY";
            this.tbxMouseEndPosY.Size = new System.Drawing.Size(61, 22);
            this.tbxMouseEndPosY.TabIndex = 0;
            this.tbxMouseEndPosY.Text = "0000.0000";
            // 
            // tbxFormSizeHeight
            // 
            this.tbxFormSizeHeight.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFormSizeHeight.Location = new System.Drawing.Point(406, 9);
            this.tbxFormSizeHeight.Name = "tbxFormSizeHeight";
            this.tbxFormSizeHeight.Size = new System.Drawing.Size(61, 22);
            this.tbxFormSizeHeight.TabIndex = 0;
            this.tbxFormSizeHeight.Text = "0000.0000";
            // 
            // tbxMouseStartPosX
            // 
            this.tbxMouseStartPosX.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMouseStartPosX.Location = new System.Drawing.Point(342, 33);
            this.tbxMouseStartPosX.Name = "tbxMouseStartPosX";
            this.tbxMouseStartPosX.Size = new System.Drawing.Size(61, 22);
            this.tbxMouseStartPosX.TabIndex = 0;
            this.tbxMouseStartPosX.Text = "0000.0000";
            // 
            // tbxVisionSizeHeight
            // 
            this.tbxVisionSizeHeight.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxVisionSizeHeight.Location = new System.Drawing.Point(604, 9);
            this.tbxVisionSizeHeight.Name = "tbxVisionSizeHeight";
            this.tbxVisionSizeHeight.Size = new System.Drawing.Size(61, 22);
            this.tbxVisionSizeHeight.TabIndex = 0;
            this.tbxVisionSizeHeight.Text = "0000.0000";
            // 
            // tbxMouseEndPosX
            // 
            this.tbxMouseEndPosX.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMouseEndPosX.Location = new System.Drawing.Point(540, 33);
            this.tbxMouseEndPosX.Name = "tbxMouseEndPosX";
            this.tbxMouseEndPosX.Size = new System.Drawing.Size(61, 22);
            this.tbxMouseEndPosX.TabIndex = 0;
            this.tbxMouseEndPosX.Text = "0000.0000";
            this.tbxMouseEndPosX.TextChanged += new System.EventHandler(this.tbxMouseEndPosX_TextChanged);
            // 
            // tbxFormSizeWidth
            // 
            this.tbxFormSizeWidth.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFormSizeWidth.Location = new System.Drawing.Point(342, 9);
            this.tbxFormSizeWidth.Name = "tbxFormSizeWidth";
            this.tbxFormSizeWidth.Size = new System.Drawing.Size(61, 22);
            this.tbxFormSizeWidth.TabIndex = 0;
            this.tbxFormSizeWidth.Text = "0000.0000";
            // 
            // tbxVisionSizeWidth
            // 
            this.tbxVisionSizeWidth.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxVisionSizeWidth.Location = new System.Drawing.Point(540, 9);
            this.tbxVisionSizeWidth.Name = "tbxVisionSizeWidth";
            this.tbxVisionSizeWidth.Size = new System.Drawing.Size(61, 22);
            this.tbxVisionSizeWidth.TabIndex = 0;
            this.tbxVisionSizeWidth.Text = "0000.0000";
            // 
            // tbxRealMouseY
            // 
            this.tbxRealMouseY.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRealMouseY.Location = new System.Drawing.Point(204, 33);
            this.tbxRealMouseY.Name = "tbxRealMouseY";
            this.tbxRealMouseY.Size = new System.Drawing.Size(61, 22);
            this.tbxRealMouseY.TabIndex = 0;
            this.tbxRealMouseY.Text = "0000.0000";
            // 
            // tbxRealMouseX
            // 
            this.tbxRealMouseX.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRealMouseX.Location = new System.Drawing.Point(204, 9);
            this.tbxRealMouseX.Name = "tbxRealMouseX";
            this.tbxRealMouseX.Size = new System.Drawing.Size(61, 22);
            this.tbxRealMouseX.TabIndex = 0;
            this.tbxRealMouseX.Text = "0000.0000";
            // 
            // tbxMouseY
            // 
            this.tbxMouseY.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMouseY.Location = new System.Drawing.Point(70, 33);
            this.tbxMouseY.Name = "tbxMouseY";
            this.tbxMouseY.Size = new System.Drawing.Size(61, 22);
            this.tbxMouseY.TabIndex = 0;
            this.tbxMouseY.Text = "0000.0000";
            // 
            // tbxMouseX
            // 
            this.tbxMouseX.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMouseX.Location = new System.Drawing.Point(70, 9);
            this.tbxMouseX.Name = "tbxMouseX";
            this.tbxMouseX.Size = new System.Drawing.Size(61, 22);
            this.tbxMouseX.TabIndex = 0;
            this.tbxMouseX.Text = "0000.0000";
            // 
            // pnlVision
            // 
            this.pnlVision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnlVision.Location = new System.Drawing.Point(30, 85);
            this.pnlVision.Name = "pnlVision";
            this.pnlVision.Size = new System.Drawing.Size(1000, 590);
            this.pnlVision.TabIndex = 7;
            this.pnlVision.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlVision_Paint);
            // 
            // bgwSearchWindow
            // 
            this.bgwSearchWindow.WorkerReportsProgress = true;
            this.bgwSearchWindow.WorkerSupportsCancellation = true;
            this.bgwSearchWindow.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSearchWindow_DoWork);
            // 
            // bgwMousePosition
            // 
            this.bgwMousePosition.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwMousePosition_DoWork);
            // 
            // bgwSizeChecker
            // 
            this.bgwSizeChecker.WorkerReportsProgress = true;
            this.bgwSizeChecker.WorkerSupportsCancellation = true;
            this.bgwSizeChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSizeChecker_DoWork);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 590);
            this.panel1.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmnuNotify;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Vision Assist";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cmnuNotify
            // 
            this.cmnuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.cmnuNotify.Name = "cmnuNotify";
            this.cmnuNotify.Size = new System.Drawing.Size(94, 26);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(93, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1260, 739);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlVision);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vision Assist ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.cmnuNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.Panel pnlVision;
        private System.ComponentModel.BackgroundWorker bgwSearchWindow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxMouseY;
        private System.Windows.Forms.TextBox tbxMouseX;
        private System.Windows.Forms.CheckBox chkDrawText;
        private System.ComponentModel.BackgroundWorker bgwMousePosition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxRealSizeHeight;
        private System.Windows.Forms.TextBox tbxRealSizeWidth;
        private System.Windows.Forms.TextBox tbxVisionSizeHeight;
        private System.Windows.Forms.TextBox tbxVisionSizeWidth;
        private System.ComponentModel.BackgroundWorker bgwSizeChecker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxFormSizeHeight;
        private System.Windows.Forms.TextBox tbxFormSizeWidth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxMouseStartPosY;
        private System.Windows.Forms.TextBox tbxMouseEndPosY;
        private System.Windows.Forms.TextBox tbxMouseStartPosX;
        private System.Windows.Forms.TextBox tbxMouseEndPosX;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private Sunny.UI.UIComboBox cbxAppPlayer;
        public System.Windows.Forms.TextBox tbxRealMouseY;
        public System.Windows.Forms.TextBox tbxRealMouseX;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cmnuNotify;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.CheckBox cbxMaint;
    }
}

