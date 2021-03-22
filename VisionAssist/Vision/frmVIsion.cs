using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using MinimizeCapture;
using System.Numerics;
using HPKR.API;
using VisionAssist.API;
using System.Diagnostics;

namespace VisionAssist.Vision
{
    public struct stAxis
    {
        public static OpenCvSharp.Size CvSize;
        public static Vector2 Center;
        public static Vector2 NowPosition;
        public static Vector2 NowRealPosition;

        public static Vector2 StartRangePos;
        public static Vector2 RangeSize;
    }

    public struct stBitmap
    {
        public static Bitmap gBitmap;

        public static void Dispose()
        {
            if(gBitmap != null)
                gBitmap.Dispose();
        }

        public static void SetBitmap(Bitmap src)
        {
            Dispose();
            gBitmap = src;
        }
    }

    public partial class frmVIsion : UserControl
    {
        private List<WindowSnap> lstSnap;
        private Rect gRect;
        public bool bDrawText = false;
        public bool VisionGetRun = false;
        private Thread Visiontrd = null;

        private Mat mat;
        private Mat FinalImage;

        private HPKR_ImageProcess gImageProcess = null;
        public frmVIsion()
        {
            InitializeComponent();
            GLOBAL.hfrmVision = this;

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            //Idle이벤트를 없앤다.
            Application.Idle -= Application_Idle;

            bgwShowVIsion.RunWorkerAsync();

            GLOBAL.VisionWidth = picVision.Width;
            GLOBAL.VisionHeight = picVision.Height;

            gImageProcess = new HPKR_ImageProcess();

            Process currentProcess = Process.GetCurrentProcess();

            foreach (ProcessThread processThread in currentProcess.Threads)
            {
                processThread.ProcessorAffinity = currentProcess.ProcessorAffinity;
            }
        }

        public void SetMousePosition(int X, int Y)
        {
            stAxis.NowPosition.X = X;
            stAxis.NowPosition.Y = Y;

            stAxis.NowRealPosition.X = (float)VisionMoveScalingWidth(X);
            stAxis.NowRealPosition.Y = (float)VisionMoveScalingHeight(Y);
        }

        public void SetMouseRangeStart(int X, int Y)
        {
            stAxis.StartRangePos.X = X;
            stAxis.StartRangePos.Y = Y;
        }

        public void SetMouseRangeEnd(int X, int Y)
        {
            stAxis.RangeSize.X = X;
            stAxis.RangeSize.Y = Y;
        }

        public Vector2 GetMousePosition()
        {
            return stAxis.NowPosition;
        }

        public void ShowDisplay()
        {
            if(lstSnap.Count == 0)
                return;
            
            Monitor.Enter(GLOBAL.monitorLock);

            if (lstSnap[lstSnap.Count - 1].Image != null)
            {
                if (picVision.Image != null)
                {
                    picVision.Image.Dispose();
                }

                picVision.Image = lstSnap[lstSnap.Count - 1].Image;
            }

            Monitor.Exit(GLOBAL.monitorLock);
        }

        public Rectangle DPIConverter(Rectangle R, IntPtr Handle)
        {
            uint dpi = GLOBAL.GetDpiForWindow(Handle);

            Rectangle CalR = R;

            double dWidth = CalR.Width;
            double dHeight = CalR.Height;

            GLOBAL.OriginWidth = CalR.Width;
            GLOBAL.OriginHeight = CalR.Height;

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

            GLOBAL.ScaleWidth = CalR.Width;
            GLOBAL.ScaleHeight = CalR.Height;

            return CalR;
        }

        public bool SearchWindow()
        {
            lstSnap = new List<WindowSnap>();
            lstSnap.AddRange(WindowSnap.GetAllWindows(true, true).ToArray());

            if (lstSnap.Count == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// LONG 매개 변수 구하기
        /// </summary>
        /// <param name="low">하위 워드</param>
        /// <param name="high">상위 워드</param>
        /// <returns>LONG 매개 변수</returns>

        public int GetLongParameter(int low, int high)
        {
            return ((high << 16) | (low & 0xffff));
        }

        public void GetImageFromPictureBox(Rect rect)
        {
            if(rect.TopLeft == rect.BottomRight)
                return;

            Bitmap Dummy = new Bitmap(picVision.Image);

            Mat test = gImageProcess.ImageCrop(Dummy, rect);

            Cv2.ImShow("test", test);

            test.Release();
            Dummy.Dispose();
        }

        public void ImageCapture(string target)
        {
            if(gImageProcess == null)
                return;

            if(!GLOBAL.GetPatternMode)
            {
                IntPtr main = GLOBAL.FindWindow(null, target);
                IntPtr sub = GLOBAL.FindWindowEx(main, 0, "RenderWindow", "TheRender");
                GLOBAL.TargetHandle = sub;

                //녹스앱플레이어를 쓴다면 //IntPtr c = FindWindowEx(b, 0, "Qt5QWindowIcon", "ScreenBoardClassWindow"); 
                Graphics gdata = Graphics.FromHwnd(sub);

                Rectangle rect = Rectangle.Round(gdata.VisibleClipBounds);
                rect = DPIConverter(rect, sub);
                
                stBitmap.SetBitmap(new Bitmap(rect.Width, rect.Height,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb));

                Graphics g = Graphics.FromImage(stBitmap.gBitmap);

                IntPtr hdc = g.GetHdc();
                bool ret = GLOBAL.PrintWindow(sub, hdc, 2);
                g.ReleaseHdc(hdc);
                ret = GLOBAL.DeleteDC(hdc);

                OpenCvSharp.Size size = new OpenCvSharp.Size(
                            picVision.Size.Width,
                            picVision.Size.Height);

                mat = BitmapConverter.ToMat(stBitmap.gBitmap);
                FinalImage = new Mat();

                Cv2.Resize(mat, FinalImage, size, 0, 0, InterpolationFlags.Cubic);
                Cv2.CvtColor(FinalImage, FinalImage, ColorConversionCodes.BGRA2BGR);

                if (bDrawText)
                {
                    /// Text Location
                    OpenCvSharp.Point myPoint;
                    myPoint.X = FinalImage.Width - 400;
                    myPoint.Y = FinalImage.Height - 10;

                    /// Font Face
                    int myFontFace = 2;

                    Vector2 Pos = GetMousePosition();
                    string frame = string.Format("Pos : {0}, {1}", Pos.X, Pos.Y);

                    ///// Font Scale
                    gImageProcess.DrawTextToImage(myPoint, FinalImage, frame, Scalar.Red);
                }

                Parallel.Invoke(
                    () => 
                    {                 
                        // HP
                        GLOBAL.hfrmControl.SetHPImagePos(FinalImage.SubMat(new Rect(64, 18, 150, 8)));
                    },
                    () =>
                    {
                        // MP
                        GLOBAL.hfrmControl.SetMPImagePos(FinalImage.SubMat(new Rect(64, 34, 150, 3)));
                    },
                    () =>
                    {
                        // Attack
                        GLOBAL.hfrmControl.SetAttackImagePos(FinalImage.SubMat(new Rect(837, 399, 42, 47)));
                    },
                    () =>
                    {
                        // Search Area
                        GLOBAL.hfrmControl.SetSearchSkillAreaImage(FinalImage.SubMat(new Rect(351, 488, 295, 74)), new Rect(351, 488, 295, 74));
                    },
                    () =>
                    {
                        // Search Item Area
                        GLOBAL.hfrmControl.SetSearchItemAreaImage(FinalImage.SubMat(new Rect(702, 489, 287, 74)),
                            new Rect(702, 489, 287, 74), (int)eLMImageList.SearchItemArea);
                    },
                    () =>
                    {
                        picVision.Image?.Dispose();
                        picVision.Image = FinalImage.ToBitmap();
                    }
                );



                mat.Release();
                FinalImage.Release();
                stBitmap.Dispose();
                g.Dispose();
                gdata.Dispose();

            }
        }

        private void bgwShowVIsion_DoWork(object sender, DoWorkEventArgs e)
        {
            //while(true)
            //{
            //    ShowDisplay();
            //    Thread.Sleep(50);
            //}
        }

        private void picVision_MouseDown(object sender, MouseEventArgs e)
        {
            if (GLOBAL.OriginWidth == 0 || GLOBAL.VisionWidth == 0)
                return;

            // 패턴 가져오기위해 이미지 그리기 멈춤
            if (GLOBAL.GetPatternMode)
            {
                gRect = new Rect(e.X, e.Y, 0, 0);
                SetMouseRangeStart(gRect.X, gRect.Y);
            }
            else
            {
                SetMousePosition(e.Location.X, e.Location.Y);

                int longParameter = GetLongParameter((int)stAxis.NowRealPosition.X, (int)stAxis.NowRealPosition.Y);
                GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONDOWN, 0, longParameter);
            }
        }

        private void picVision_MouseMove(object sender, MouseEventArgs e)
        {
            if (GLOBAL.OriginWidth == 0 || GLOBAL.VisionWidth == 0)
                return;

            // 패턴 가져오기위해 이미지 그리기 멈춤
            if (GLOBAL.GetPatternMode)
            {
                int width = e.Location.X - gRect.Location.X;
                int height = e.Location.X - gRect.Location.Y;

                gRect.Width = width;
                gRect.Height = height;

                gRect = new Rect(gRect.Left, gRect.Top,
                    Math.Min(e.X - gRect.Left, ClientRectangle.Width - gRect.Left),
                    Math.Min(e.Y - gRect.Top, ClientRectangle.Height - gRect.Top));

                // Paint 이벤트 발생
                picVision.Invalidate();
            }
            else
            {
                SetMousePosition(e.Location.X, e.Location.Y);

                int longParameter = GetLongParameter((int)stAxis.NowRealPosition.X, (int)stAxis.NowRealPosition.Y);
                GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_MOUSEMOVE, 0, longParameter);
            }
        }

        private void picVision_MouseUp(object sender, MouseEventArgs e)
        {
            if (GLOBAL.GetPatternMode)
            {
                GLOBAL.GetPatternMode = false;
                picVision.Cursor = Cursors.Default;

                int width = Math.Min(e.X - gRect.Left, ClientRectangle.Width - gRect.Left);
                int height = Math.Min(e.Y - gRect.Top, ClientRectangle.Height - gRect.Top);

                gRect = new Rect(gRect.Left, gRect.Top, width, height);

                GetImageFromPictureBox(gRect);
                SetMouseRangeEnd(width, height);

                picVision.Invalidate();
            }
            else
            {
                GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONUP, 1, GLOBAL.MK_LBUTTON);
            }
        }

        public decimal VisionMoveScalingWidth(float val)
        {
            val = (GLOBAL.OriginWidth * val) / GLOBAL.VisionWidth;
            //val = (GLOBAL.ScaleWidth * val) / GLOBAL.VisionWidth;

            //val *= (float)((decimal)GlobalHandle.frm_JOG.gUmac.gMTP.ScaleLensN3 * GlobalHandle.frm_JOG.gUmac.gMTP.ScaleStage);

            return (decimal)val;
        }

        public decimal VisionMoveScalingHeight(float val)
        {
            val = (GLOBAL.OriginHeight * val) / GLOBAL.VisionHeight;
            //val = (GLOBAL.ScaleHeight * val) / GLOBAL.VisionHeight;

            //val *= (float)((decimal)GlobalHandle.frm_JOG.gUmac.gMTP.ScaleLensN3 * GlobalHandle.frm_JOG.gUmac.gMTP.ScaleStage);

            return (decimal)val;
        }

        private void getImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GLOBAL.GetPatternMode = true;
            picVision.Cursor = Cursors.Cross;

        }

        private void picVision_Paint(object sender, PaintEventArgs e)
        {
            if(GLOBAL.GetPatternMode)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    Rectangle rct = new Rectangle(0, 0, 0, 0);
                    rct.X = gRect.X;
                    rct.Y = gRect.Y;
                    rct.Width = gRect.Width;
                    rct.Height = gRect.Height;

                    e.Graphics.DrawRectangle(pen, rct);
                    //e.Dispose();
                }
            }
            else
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    Rectangle rct = new Rectangle(0, 0, 0, 0);
                    e.Graphics.DrawRectangle(pen, rct);
                    //e.Dispose();
                }
            }
        }
    }
}
