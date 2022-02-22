using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionAssist.Properties;

namespace VisionAssist.Forms.ImageSave
{
    public class ImageFunctions
    {
        public void SaveImage(Mat src)
        {
            using (SaveFileDialog saveDlg = new SaveFileDialog())
            {
                saveDlg.InitialDirectory = Settings.Default.PathSaveImage;
                //saveDlg.Filter = "PNG(*.png)|*.png|JPG(*.jpg)|*.jpg|BMP(*.bmp)|*.bmp";
                saveDlg.Filter = "PNG(*.png)|*.png";
                saveDlg.Title = "Save Image";
                Mat dstImage;

                string filter = String.Empty;
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    filter = Path.GetExtension(saveDlg.FileName);

                    using (Bitmap default_image = (Bitmap)src.Clone())
                    {
                        switch (filter)
                        {
                            case ".png":
                                dstImage = BitmapConverter.ToMat(default_image);
                                dstImage.SaveImage(saveDlg.FileName, new ImageEncodingParam(ImwriteFlags.PngCompression, 1));
                                break;
                                //case ".jpg":
                                //    dstImage = BitmapConverter.ToMat(default_image);
                                //    dstImage.SaveImage(saveDlg.FileName, new ImageEncodingParam(ImwriteFlags.JpegQuality, 80));
                                //    break;
                                //case ".bmp":
                                //    default_image.Save(saveDlg.FileName, ImageFormat.Bmp);
                                //    break;
                        }

                        Settings.Default.PathSaveImage = Path.GetDirectoryName(saveDlg.FileName);
                        Settings.Default.Save();
                    }
                }
            }
        }
    }
}
