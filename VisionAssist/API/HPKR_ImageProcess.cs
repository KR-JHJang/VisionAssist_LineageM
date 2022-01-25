using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VisionAssist.API;

namespace HPKR.API
{
    public struct VecLoc4d
    {
        public double minval;
        public double maxval;
        public OpenCvSharp.Point minloc;
        public OpenCvSharp.Point maxloc;
        public Mat retMat;

        public VecLoc4d(double minval, double maxval, OpenCvSharp.Point minloc, OpenCvSharp.Point maxloc, Mat retMat)
        {
            this.minval = minval;
            this.maxval = maxval;
            this.minloc = minloc;
            this.maxloc = maxloc;
            this.retMat = retMat;
        }
    }

    public struct VecLoc3d
    {
        public double minval;
        public double maxval;
        public OpenCvSharp.Point minloc;
        public OpenCvSharp.Point maxloc;

        public VecLoc3d(double minval, double maxval, OpenCvSharp.Point minloc, OpenCvSharp.Point maxloc)
        {
            this.minval = minval;
            this.maxval = maxval;
            this.minloc = minloc;
            this.maxloc = maxloc;
        }
    }

    public static class HPKR_StaticVariables
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr childWindowHandle, IntPtr parentWindowHandle);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        [DllImport("User32", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string IpClassName, string IpWindowName);
        [DllImport("user32")]
        public static extern IntPtr FindWindowEx(IntPtr hWnd1, int hWnd2, string lp1, string lp2);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcblt, int nFlags);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);
        [DllImport("user32.dll")]
        public static extern void SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern uint GetDpiForWindow(IntPtr hWnd);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
    }

    public class HPKR_ImageProcess : IDisposable
    {
        public Mat gImage;
        public Mat gSubImage;

        public int OriginWidth;
        public int OriginHeight;
        public int ScaleWidth;
        public int ScaleHeight;
        public int VisionWidth;
        public int VisionHeight;

        public Mat ConvertRgb2Gray(Mat src)
        {
            using(Mat result = new Mat())
            {
                Cv2.CvtColor(src, result, ColorConversionCodes.BGR2GRAY);
                return result.Clone();
            }
        }
        public void ConvertRgb2Gray(Mat src, out Mat result)
        {
            result = new Mat();
            Cv2.CvtColor(src, result, ColorConversionCodes.BGR2GRAY);
        }
        public Mat ConvertRgb2Hsv(Mat src)
        {
            Cv2.CvtColor(src, src, ColorConversionCodes.BGR2HSV);
            return src;
        }

        public VecLoc4d MinMaxLoc(Mat src)
        {
            OpenCvSharp.Point minloc, maxloc;
            double minval, maxval;
            Cv2.MinMaxLoc(src, out minval, out maxval, out minloc, out maxloc);

            return new VecLoc4d(minval, maxval, minloc, maxloc, src);
        }

        public VecLoc3d TemplateMatchingGetAllData(ref Mat area, ref Mat target)
        {
            Mat result = new Mat();
            Mat GrayMat = new Mat();
            Mat GrayArea = new Mat();

            Cv2.CvtColor(target, GrayMat, ColorConversionCodes.BGR2GRAY);
            Cv2.CvtColor(area, GrayArea, ColorConversionCodes.BGR2GRAY);

            Cv2.MatchTemplate(GrayMat, GrayArea, result, TemplateMatchModes.CCoeffNormed);

            // 이미지의 최대/ 최소 위치 취득
            OpenCvSharp.Point minloc, maxloc;
            // 이미지 매칭율 최대 / 최소 데이터 취득

            Cv2.MinMaxLoc(result, out var minval, out var maxval, out minloc, out maxloc);

            // 서치된 부분을 빨간 테두리로
            //Rect rect = new Rect(maxloc.X, maxloc.Y, target.Width, target.Height);
            //Cv2.Rectangle(GrayArea, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

            // 소수점 두번째 반올림
            maxval = Math.Round(maxval, 2);

            GrayMat.Release();
            GrayArea.Release();
            result.Release();

            return new VecLoc3d(minval, maxval, minloc, maxloc);
        }

        public double TemplateMatchingGetRatio(ref Mat area, ref Mat target)
        {
            double max = 0;

            using(Mat result = new Mat())
            using(Mat GrayMat = new Mat())
            using(Mat GrayArea = new Mat())
            {
                Cv2.CvtColor(target, GrayMat, ColorConversionCodes.BGR2GRAY);
                Cv2.CvtColor(area, GrayArea, ColorConversionCodes.BGR2GRAY);

                Cv2.MatchTemplate(GrayMat, GrayArea, result, TemplateMatchModes.CCoeffNormed);

                // 이미지의 최대/ 최소 위치 취득
                OpenCvSharp.Point minloc, maxloc;
                // 이미지 매칭율 최대 / 최소 데이터 취득

                Cv2.MinMaxLoc(result, out var minval, out var maxval, out minloc, out maxloc);

                // 서치된 부분을 빨간 테두리로
                //Rect rect = new Rect(maxloc.X, maxloc.Y, target.Width, target.Height);
                //Cv2.Rectangle(GrayArea, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

                // 소수점 두번째 반올림
                max = Math.Round(maxval, 2);
            }

            return max;
        }

        public double SimpleColorMatching(Mat src, Mat target, int BGR)
        {
            double ret = 0;

            Mat t1 = ConvertRgb2Hsv(src);
            Mat t2 = ConvertRgb2Hsv(target);

            for (int col = 0; col < src.Cols; col++)
            {
                for (int rows = 0; rows < src.Rows; rows++)
                {
                    Vec3b a1 = t1.At<Vec3b>(rows, col);
                    Vec3b a2 = t2.At<Vec3b>(rows, col);

                    switch(BGR)
                    {
                        case 0:
                            if (a1.Item0 == a2.Item0)
                            {
                                ret++;
                            }
                            break;
                        case 1:
                            if (a1.Item1 == a2.Item1)
                            {
                                ret++;
                            }
                            break;
                        case 2:
                            if (a1.Item2 == a2.Item2)
                            {
                                ret++;
                            }
                            break;
                    }


                }
            }

            double sum = (double)src.Cols * (double)src.Rows;
            double final = ((ret / sum) * 100);

            t1.Release();
            t2.Release();

            return final;
        }

        public double SimpleColorMatching(Mat src, Mat target)
        {
            double ret = 0;
            double final = 0;

            try
            {
                Mat t1 = ConvertRgb2Hsv(src);
                Mat t2 = ConvertRgb2Hsv(target);

                for (int col = 0; col < src.Cols; col++)
                {
                    for (int rows = 0; rows < src.Rows; rows++)
                    {
                        Vec3b a1 = t1.At<Vec3b>(rows, col);
                        Vec3b a2 = t2.At<Vec3b>(rows, col);

                        if (a1.Item0 == a2.Item0)
                        {
                            ret++;
                        }
                    }
                }

                double sum = (double)src.Cols * (double)src.Rows;
                final = ((ret / sum) * 100);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return final;
        }


        /// <summary>
        /// Mat 은 컬러로 넣을 것 자동으로 흑백 변환 후 Ratio 반환
        /// </summary>
        /// <param name="area"></param>
        /// <param name="target"></param>
        /// <returns>double Ratio</returns>
        public double TemplateMatchingRatio(Mat area, Mat target)
        {
            Mat result = new Mat();
            Mat GrayMat = new Mat();
            Mat GrayArea = new Mat();

            //Cv2.CvtColor(target, GrayMat, ColorConversionCodes.BGR2GRAY);
            //Cv2.CvtColor(area, GrayArea, ColorConversionCodes.BGR2GRAY);

            //Cv2.MatchTemplate(GrayMat, GrayArea, result, TemplateMatchModes.CCoeffNormed);
            Cv2.MatchTemplate(target, area, result, TemplateMatchModes.CCoeffNormed);

            // 이미지의 최대/ 최소 위치 취득
            OpenCvSharp.Point minloc, maxloc;
            // 이미지 매칭율 최대 / 최소 데이터 취득

            double minval, maxval;
            Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

            // 소수점 두번째 반올림
            maxval = Math.Round(maxval, 2);

            result.Release();
            GrayMat.Release();
            GrayArea.Release();
            area.Release();
            target.Release();

            return maxval;
        }

        public Mat ConvertColorNormalize(Mat src,
    Scalar hlower, Scalar hupper, int BGR)
        {
            Mat dest = ConvertRgb2Hsv(src);

            Mat[] mv = new Mat[3];
            //Mat Final = new Mat();
            Mat mask = new Mat();

            Scalar a = new Scalar((double)hlower, (double)0, (double)0);
            Scalar b = new Scalar((double)hupper, (double)0, (double)0);

            mask.SetTo(BGR);

            mv = Cv2.Split(dest);
            Cv2.InRange(mv[BGR], a, b, mask);

            Cv2.BitwiseAnd(src, mask.CvtColor(ColorConversionCodes.GRAY2BGR), src);

            ColorBlackMasking(src);
            switch(BGR)
            {
                case 0:
                    ColorNormalize(src, new Vec3b(255, 0, 0));
                    break;                    
                case 1:
                    ColorNormalize(src, new Vec3b(0, 255, 0));
                    break;
                case 2:
                    ColorNormalize(src, new Vec3b(0, 0, 255));
                    break;
            }

            
            //Cv2.CvtColor(src, src, ColorConversionCodes.HSV2BGR);

            return src;
        }

        public Mat ConvertColorNormalize(ref Mat src, 
            Scalar hlower, Scalar hupper)
        {
            Mat dest = ConvertRgb2Hsv(src);
            
            Mat[] mv = new Mat[3];
            Mat Final = new Mat();
            Mat mask = new Mat();

            Scalar a = new Scalar((double)hlower, (double)0, (double)0);
            Scalar b = new Scalar((double)hupper, (double)0, (double)0);

            mask.SetTo(0);

            mv = Cv2.Split(dest);
            Cv2.InRange(mv[0], a, b, mask);
            
            Cv2.BitwiseAnd(src, mask.CvtColor(ColorConversionCodes.GRAY2BGR), src);

            ColorBlackMasking(src);
            ColorNormalize(src, new Vec3b(255,0,0));
            //Cv2.CvtColor(src, src, ColorConversionCodes.HSV2BGR);

            //dest.Release();

            return src;
        }

        public Mat ColorNormalize(Mat src, Vec3b color)
        {
            for (int col = 0; col < src.Cols; col++)
            {
                for (int rows = 0; rows < src.Rows; rows++)
                {
                    Vec3b pt = src.At<Vec3b>(rows, col);

                    if (pt.Item0 != 0x00)
                    {
                        src.Set<Vec3b>(rows, col, color);
                    }
                }
            }

            return src;
        }

        public void FillColor(Mat src, Vec3b color)
        {
            Mat dest = ConvertRgb2Hsv(src);

            for (int col = 0; col < src.Cols; col++)
            {
                for (int rows = 0; rows < src.Rows; rows++)
                {
                    dest.Set<Vec3b>(rows, col, color);
                }
            }
        }

        /// <summary>
        /// 컬러가 0인 색상 기준으로 해당 위치부터 뒷 배열을 전부 0으로 변경
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public Mat ColorBlackMasking(Mat src)
        {
            for (int col = 0; col < src.Cols; col++)
            {
                for (int rows = 0; rows < src.Rows; rows++)
                {       
                    Vec3b pt = src.At<Vec3b>(rows, col);

                    if(pt.Item0 == 0x00)
                    {
                        for (int idx = col; idx < src.Cols; idx++)
                        {
                            src.Set<Vec3b>(rows, idx, new Vec3b(0, 0, 0));
                        }
                       
                        //break;
                    }
                }
            }

            return src;
        }

        public void ColorSetBlack()
        {

        }

        public OpenCvSharp.Size GetImageSize(Mat src)
        {
            return src.Size();
        }

        public Mat ImageCrop(Mat src, Rect rect)
        {
            if (rect.TopLeft == rect.BottomRight)
                return null;

            Mat subimage = src.SubMat(rect);

            return subimage;
        }

        public Mat ImageCrop(Bitmap src, Rect rect)
        {
            if (rect.TopLeft == rect.BottomRight)
                return null;

            Mat img = BitmapConverter.ToMat(src);
            Mat subimage = img.SubMat(rect);

            //Cv2.ImShow("test", subimage);

            return subimage;
        }

        public Rectangle DPIConverter(Rectangle R, IntPtr Handle)
        {
            uint dpi = HPKR_StaticVariables.GetDpiForWindow(Handle);

            Rectangle CalR = R;

            double dWidth = CalR.Width;
            double dHeight = CalR.Height;

            OriginWidth = CalR.Width;
            OriginHeight = CalR.Height;

            switch (dpi)
            {
                case 96:
                    break;
                case 120:
                    dWidth *= 1.25;
                    dHeight *= 1.25;
                    break;
                case 144:
                    dWidth *= 1.5;
                    dHeight *= 1.5;
                    break;
                case 192:
                    dWidth *= 2;
                    dHeight *= 2;
                    break;
            }

            CalR.Width = (int)dWidth;
            CalR.Height = (int)dHeight;

            ScaleWidth = CalR.Width;
            ScaleHeight = CalR.Height;

            return CalR;
        }

        public Mat ImageResize(Mat src, int width, int height)
        {
            Mat result = new Mat();
            Cv2.Resize(src, result, new OpenCvSharp.Size(width, height), 0, 0, InterpolationFlags.Cubic);

            return result;
        }

        public void DrawTextToImage(OpenCvSharp.Point p, Mat src, string msg, Scalar color)
        {
            double myFontScale = 1;
            src.PutText(msg, p, HersheyFonts.HersheySimplex, myFontScale, Scalar.Red, 1,
                LineTypes.AntiAlias);
        }

        protected virtual void Dispose(bool disposing)
        {
            gImage.Dispose();
            gSubImage.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
