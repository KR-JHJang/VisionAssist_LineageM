using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionAssist.Properties;

namespace VisionAssist.Forms.ImageSave
{
    public partial class frmImageSave : Form
    {
        private ImageFunctions gImageFunctions;
        private Mat gMatSource;
        public frmImageSave(Mat src)
        {
            InitializeComponent();

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
            gImageFunctions.SaveImage(gMatSource);
        }
    }
}
