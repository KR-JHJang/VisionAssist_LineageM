using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Windows.Forms;

namespace VisionAssist.Forms.ImageSave
{
    public partial class frmImageSave : Form
    {
        private Mat gMatSource;
        internal Functions gFunc;
        public frmImageSave(Mat src)
        {
            InitializeComponent();

            gFunc = new Functions();

            gMatSource = src;
            picImage.Image = gMatSource.ToBitmap();
        }

        ~frmImageSave()
        {
            if(picImage.Image != null)
                picImage.Dispose();
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            gFunc.SaveImage(gMatSource);
        }
    }
}
