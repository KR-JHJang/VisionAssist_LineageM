
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTop));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnJob1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnJob2 = new System.Windows.Forms.Button();
            this.btnJob3 = new System.Windows.Forms.Button();
            this.btnJob4 = new System.Windows.Forms.Button();
            this.btnJob5 = new System.Windows.Forms.Button();
            this.btnJob6 = new System.Windows.Forms.Button();
            this.btnJob7 = new System.Windows.Forms.Button();
            this.btnJob8 = new System.Windows.Forms.Button();
            this.btnJob9 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnJob9);
            this.groupBox1.Controls.Add(this.btnJob8);
            this.groupBox1.Controls.Add(this.btnJob7);
            this.groupBox1.Controls.Add(this.btnJob6);
            this.groupBox1.Controls.Add(this.btnJob5);
            this.groupBox1.Controls.Add(this.btnJob4);
            this.groupBox1.Controls.Add(this.btnJob3);
            this.groupBox1.Controls.Add(this.btnJob2);
            this.groupBox1.Controls.Add(this.btnJob1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "직업 선택";
            // 
            // btnJob1
            // 
            this.btnJob1.BackColor = System.Drawing.Color.Transparent;
            this.btnJob1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJob1.FlatAppearance.BorderSize = 0;
            this.btnJob1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJob1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJob1.ForeColor = System.Drawing.Color.Black;
            this.btnJob1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnJob1.ImageIndex = 0;
            this.btnJob1.ImageList = this.imageList1;
            this.btnJob1.Location = new System.Drawing.Point(8, 15);
            this.btnJob1.Name = "btnJob1";
            this.btnJob1.Size = new System.Drawing.Size(62, 88);
            this.btnJob1.TabIndex = 7;
            this.btnJob1.Tag = "1";
            this.btnJob1.Text = "마법사";
            this.btnJob1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJob1.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Mage.png");
            this.imageList1.Images.SetKeyName(1, "Gunner.png");
            this.imageList1.Images.SetKeyName(2, "DarkElf.png");
            this.imageList1.Images.SetKeyName(3, "Elf.png");
            this.imageList1.Images.SetKeyName(4, "Berserker.png");
            this.imageList1.Images.SetKeyName(5, "DarkKnight.png");
            this.imageList1.Images.SetKeyName(6, "HolyKnight.png");
            this.imageList1.Images.SetKeyName(7, "Knight.png");
            this.imageList1.Images.SetKeyName(8, "Prince.png");
            // 
            // btnJob2
            // 
            this.btnJob2.BackColor = System.Drawing.Color.Transparent;
            this.btnJob2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJob2.FlatAppearance.BorderSize = 0;
            this.btnJob2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJob2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJob2.ForeColor = System.Drawing.Color.Black;
            this.btnJob2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnJob2.ImageIndex = 1;
            this.btnJob2.ImageList = this.imageList1;
            this.btnJob2.Location = new System.Drawing.Point(76, 15);
            this.btnJob2.Name = "btnJob2";
            this.btnJob2.Size = new System.Drawing.Size(62, 88);
            this.btnJob2.TabIndex = 7;
            this.btnJob2.Tag = "2";
            this.btnJob2.Text = "총사";
            this.btnJob2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJob2.UseVisualStyleBackColor = true;
            // 
            // btnJob3
            // 
            this.btnJob3.BackColor = System.Drawing.Color.Transparent;
            this.btnJob3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJob3.FlatAppearance.BorderSize = 0;
            this.btnJob3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJob3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJob3.ForeColor = System.Drawing.Color.Black;
            this.btnJob3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnJob3.ImageIndex = 2;
            this.btnJob3.ImageList = this.imageList1;
            this.btnJob3.Location = new System.Drawing.Point(144, 15);
            this.btnJob3.Name = "btnJob3";
            this.btnJob3.Size = new System.Drawing.Size(62, 88);
            this.btnJob3.TabIndex = 7;
            this.btnJob3.Tag = "3";
            this.btnJob3.Text = "다크엘프";
            this.btnJob3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJob3.UseVisualStyleBackColor = false;
            // 
            // btnJob4
            // 
            this.btnJob4.BackColor = System.Drawing.Color.Transparent;
            this.btnJob4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJob4.FlatAppearance.BorderSize = 0;
            this.btnJob4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJob4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJob4.ForeColor = System.Drawing.Color.Black;
            this.btnJob4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnJob4.ImageIndex = 3;
            this.btnJob4.ImageList = this.imageList1;
            this.btnJob4.Location = new System.Drawing.Point(212, 15);
            this.btnJob4.Name = "btnJob4";
            this.btnJob4.Size = new System.Drawing.Size(62, 88);
            this.btnJob4.TabIndex = 7;
            this.btnJob4.Tag = "4";
            this.btnJob4.Text = "요정";
            this.btnJob4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJob4.UseVisualStyleBackColor = true;
            // 
            // btnJob5
            // 
            this.btnJob5.BackColor = System.Drawing.Color.Transparent;
            this.btnJob5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJob5.FlatAppearance.BorderSize = 0;
            this.btnJob5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJob5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJob5.ForeColor = System.Drawing.Color.Black;
            this.btnJob5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnJob5.ImageIndex = 7;
            this.btnJob5.ImageList = this.imageList1;
            this.btnJob5.Location = new System.Drawing.Point(280, 15);
            this.btnJob5.Name = "btnJob5";
            this.btnJob5.Size = new System.Drawing.Size(62, 88);
            this.btnJob5.TabIndex = 7;
            this.btnJob5.Tag = "5";
            this.btnJob5.Text = "기사";
            this.btnJob5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJob5.UseVisualStyleBackColor = true;
            // 
            // btnJob6
            // 
            this.btnJob6.BackColor = System.Drawing.Color.Transparent;
            this.btnJob6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJob6.FlatAppearance.BorderSize = 0;
            this.btnJob6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJob6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJob6.ForeColor = System.Drawing.Color.Black;
            this.btnJob6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnJob6.ImageIndex = 5;
            this.btnJob6.ImageList = this.imageList1;
            this.btnJob6.Location = new System.Drawing.Point(348, 15);
            this.btnJob6.Name = "btnJob6";
            this.btnJob6.Size = new System.Drawing.Size(62, 88);
            this.btnJob6.TabIndex = 7;
            this.btnJob6.Tag = "6";
            this.btnJob6.Text = "암흑기사";
            this.btnJob6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJob6.UseVisualStyleBackColor = true;
            // 
            // btnJob7
            // 
            this.btnJob7.BackColor = System.Drawing.Color.Transparent;
            this.btnJob7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJob7.FlatAppearance.BorderSize = 0;
            this.btnJob7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJob7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJob7.ForeColor = System.Drawing.Color.Black;
            this.btnJob7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnJob7.ImageIndex = 6;
            this.btnJob7.ImageList = this.imageList1;
            this.btnJob7.Location = new System.Drawing.Point(416, 15);
            this.btnJob7.Name = "btnJob7";
            this.btnJob7.Size = new System.Drawing.Size(62, 88);
            this.btnJob7.TabIndex = 7;
            this.btnJob7.Tag = "7";
            this.btnJob7.Text = "신성검사";
            this.btnJob7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJob7.UseVisualStyleBackColor = true;
            // 
            // btnJob8
            // 
            this.btnJob8.BackColor = System.Drawing.Color.Transparent;
            this.btnJob8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJob8.FlatAppearance.BorderSize = 0;
            this.btnJob8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJob8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJob8.ForeColor = System.Drawing.Color.Black;
            this.btnJob8.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnJob8.ImageIndex = 4;
            this.btnJob8.ImageList = this.imageList1;
            this.btnJob8.Location = new System.Drawing.Point(484, 15);
            this.btnJob8.Name = "btnJob8";
            this.btnJob8.Size = new System.Drawing.Size(62, 88);
            this.btnJob8.TabIndex = 7;
            this.btnJob8.Tag = "8";
            this.btnJob8.Text = "광전사";
            this.btnJob8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJob8.UseVisualStyleBackColor = true;
            // 
            // btnJob9
            // 
            this.btnJob9.BackColor = System.Drawing.Color.Transparent;
            this.btnJob9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJob9.FlatAppearance.BorderSize = 0;
            this.btnJob9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJob9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJob9.ForeColor = System.Drawing.Color.Black;
            this.btnJob9.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnJob9.ImageIndex = 8;
            this.btnJob9.ImageList = this.imageList1;
            this.btnJob9.Location = new System.Drawing.Point(552, 15);
            this.btnJob9.Name = "btnJob9";
            this.btnJob9.Size = new System.Drawing.Size(62, 88);
            this.btnJob9.TabIndex = 7;
            this.btnJob9.Tag = "9";
            this.btnJob9.Text = "군주";
            this.btnJob9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnJob9.UseVisualStyleBackColor = true;
            // 
            // frmTop
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTop";
            this.Size = new System.Drawing.Size(1260, 116);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnJob1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnJob2;
        private System.Windows.Forms.Button btnJob9;
        private System.Windows.Forms.Button btnJob8;
        private System.Windows.Forms.Button btnJob7;
        private System.Windows.Forms.Button btnJob6;
        private System.Windows.Forms.Button btnJob5;
        private System.Windows.Forms.Button btnJob4;
        private System.Windows.Forms.Button btnJob3;
    }
}
