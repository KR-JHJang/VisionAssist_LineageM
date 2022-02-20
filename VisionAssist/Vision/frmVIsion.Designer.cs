
namespace VisionAssist.Vision
{
    partial class frmVIsion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVIsion));
            this.picVision = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stripTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSetMousePosition = new System.Windows.Forms.ToolStripMenuItem();
            this.getImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwShowVIsion = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.picVision)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picVision
            // 
            this.picVision.ContextMenuStrip = this.contextMenuStrip1;
            this.picVision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picVision.Location = new System.Drawing.Point(0, 0);
            this.picVision.Name = "picVision";
            this.picVision.Size = new System.Drawing.Size(960, 540);
            this.picVision.TabIndex = 0;
            this.picVision.TabStop = false;
            this.picVision.Paint += new System.Windows.Forms.PaintEventHandler(this.picVision_Paint);
            this.picVision.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picVision_MouseDown);
            this.picVision.MouseEnter += new System.EventHandler(this.picVision_MouseEnter);
            this.picVision.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picVision_MouseMove);
            this.picVision.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picVision_MouseUp);
            this.picVision.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.picVision_PreviewKeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripTitle,
            this.tsSetMousePosition,
            this.getImageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(210, 82);
            // 
            // stripTitle
            // 
            this.stripTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.stripTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.stripTitle.Enabled = false;
            this.stripTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stripTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.stripTitle.Image = ((System.Drawing.Image)(resources.GetObject("stripTitle.Image")));
            this.stripTitle.Name = "stripTitle";
            this.stripTitle.Size = new System.Drawing.Size(209, 26);
            this.stripTitle.Text = "Vision Control";
            this.stripTitle.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // tsSetMousePosition
            // 
            this.tsSetMousePosition.Name = "tsSetMousePosition";
            this.tsSetMousePosition.Size = new System.Drawing.Size(209, 26);
            this.tsSetMousePosition.Text = "Set Mouse Position";
            this.tsSetMousePosition.Click += new System.EventHandler(this.tsSetMousePosition_Click);
            // 
            // getImageToolStripMenuItem
            // 
            this.getImageToolStripMenuItem.Name = "getImageToolStripMenuItem";
            this.getImageToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.getImageToolStripMenuItem.Text = "Get Image";
            this.getImageToolStripMenuItem.Click += new System.EventHandler(this.getImageToolStripMenuItem_Click);
            // 
            // bgwShowVIsion
            // 
            this.bgwShowVIsion.WorkerReportsProgress = true;
            this.bgwShowVIsion.WorkerSupportsCancellation = true;
            this.bgwShowVIsion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwShowVIsion_DoWork);
            // 
            // frmVIsion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.picVision);
            this.DoubleBuffered = true;
            this.Name = "frmVIsion";
            this.Size = new System.Drawing.Size(960, 540);
            ((System.ComponentModel.ISupportInitialize)(this.picVision)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgwShowVIsion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stripTitle;
        private System.Windows.Forms.ToolStripMenuItem getImageToolStripMenuItem;
        public System.Windows.Forms.PictureBox picVision;
        private System.Windows.Forms.ToolStripMenuItem tsSetMousePosition;
    }
}
