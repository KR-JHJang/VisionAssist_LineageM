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
using System.Runtime.Remoting.Messaging;
using VisionAssist.Forms;

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
            gBitmap?.Dispose();
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

        private Mat mat = new Mat();
        private Mat FinalImage = new Mat();
        private Mat FinalCopy;

        private bool isImageRun;

        private frmUserPosition gfrm;

        private HPKR_ImageProcess gImageProcess = null;

        private static OpenCvSharp.Size Picsize;

        private Mat mControlVision;

        private static object _imageLock = new object();

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

            mControlVision = new Mat();
            mControlVision.Dispose();

            Picsize =  new OpenCvSharp.Size(
                picVision.Size.Width,
                picVision.Size.Height);

            //bgwShowVIsion.RunWorkerAsync();
            bgwImageWork.RunWorkerAsync();

            GLOBAL.VisionWidth = picVision.Width;
            GLOBAL.VisionHeight = picVision.Height;

            gImageProcess = new HPKR_ImageProcess();

            Process currentProcess = Process.GetCurrentProcess();

           // foreach (ProcessThread processThread in currentProcess.Threads)
           // {
           //     processThread.ProcessorAffinity = currentProcess.ProcessorAffinity;
           // }
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
                lock (_imageLock)
                {
                    IntPtr main = GLOBAL.FindWindow(null, target);
                    IntPtr sub = IntPtr.Zero;
                    IntPtr sub2 = IntPtr.Zero;
                    IntPtr sub3 = IntPtr.Zero;
                    IntPtr sub4 = IntPtr.Zero;

                    switch (GLOBAL.SelectAppPlayer)
                    {
                        case 0:
                            // LD Player
                            sub = GLOBAL.FindWindowEx(main, 0, "RenderWindow", "TheRender");
                            break;
                        case 1:
                            // 블루스택
                            sub = GLOBAL.FindWindowEx(main, 0, "WindowsForms10.Window.8.app.0.2fc056_r6_ad1", "BlueStacks Android PluginAndroid");
                            break;
                        case 2:
                            // 블루스택
                            sub = GLOBAL.FindWindowEx(main, 0, "plrNativeInputWindowClass", "plrNativeInputWindow");
                            break;
                        case 3:
                            // 블루스택
                            sub = GLOBAL.FindWindowEx(main, 0, "CEFBrowseWindowWndClass", "");
                            sub2 = GLOBAL.FindWindowEx(sub, 0, "CefBrowserWindow", "리니지M ");
                            sub3 = GLOBAL.FindWindowEx(sub2, 0, "Chrome_WidgetWin_0", "리니지M ");
                            sub4 = GLOBAL.FindWindowEx(sub3, 0, "Intermediate D3D Window", "");
                            break;
                    }

                    if (main == IntPtr.Zero)
                        return;

                    if (sub == IntPtr.Zero)
                        return;

                    if (GLOBAL.SelectAppPlayer == 3)
                        sub = sub4;

                    GLOBAL.TargetHandle = sub;

                    //녹스앱플레이어를 쓴다면 //IntPtr c = FindWindowEx(b, 0, "Qt5QWindowIcon", "ScreenBoardClassWindow"); 
                    Graphics gdata = Graphics.FromHwnd(sub);

                    Rectangle rect = Rectangle.Round(gdata.VisibleClipBounds);
                    rect = DPIConverter(rect, sub);

                    stBitmap.SetBitmap(new Bitmap(rect.Width, rect.Height,
                        System.Drawing.Imaging.PixelFormat.Format32bppArgb));

                    Graphics g = Graphics.FromImage(stBitmap.gBitmap);

                    IntPtr hdc = g.GetHdc();
                    //bool ret = GLOBAL.PrintWindow(sub, hdc, 2);
                    bool ret = GLOBAL.PrintWindow(sub, hdc, 2);
                    g.ReleaseHdc(hdc);
                    ret = GLOBAL.DeleteDC(hdc);
                    g = null;

                    if (mat == null)
                        mat = new Mat();

                    if (FinalImage == null)
                        FinalImage = new Mat();

                    mat = BitmapConverter.ToMat(stBitmap.gBitmap);

                    Cv2.Resize(mat, FinalImage, Picsize, 0, 0, InterpolationFlags.Lanczos4);
                    Cv2.CvtColor(FinalImage, FinalImage, ColorConversionCodes.BGRA2BGR);

                    WeakReference wMain = new WeakReference(mat);
                    WeakReference wFinal = new WeakReference(FinalImage);

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

                    var oldimage = picVision.Image;

                    this.Invoke(new Action(() =>
                    {
                        picVision.Image = FinalImage.ToBitmap();
                    }));

                    //if(mControlVision.IsDisposed)

                    if (isImageRun == false && mControlVision.IsDisposed)
                    {
                        mControlVision = FinalImage.Clone();
                    }

                    gdata.Dispose();
                    gdata = null;

                    mat.Release();
                    mat.Dispose();
                    mat = null;

                    stBitmap.Dispose();
                    
                    FinalImage.Release();
                    FinalImage.Dispose();
                    FinalImage = null;

                    ((IDisposable)oldimage).Dispose();
                    oldimage = null;

                    GC.Collect();

                    sub = IntPtr.Zero;
                }
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

                System.Console.WriteLine("Click Pos X : {0}, Y : {1}", stAxis.NowRealPosition.X, stAxis.NowRealPosition.Y);
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
            if (GLOBAL.SetMousePositionMode)
            {
                gfrm.SetPosition();
            }

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

        private void bgwImageWork_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (mControlVision != null)
                {
                    isImageRun = true;
                    if (mControlVision.IsDisposed || mControlVision.Width == 0 || mControlVision.Height == 0)
                    {
                        isImageRun = false;
                        continue;
                    }

                    if (!(GLOBAL.hfrmControl.SetAttackImagePos(ref mControlVision)))
                    {
                        Parallel.Invoke(
                            () =>
                            {
                                // HP
                                //GLOBAL.hfrmControl.SetHPImagePos(FinalImage.SubMat(new Rect(64, 18, 150, 8)));
                                // HP Text
                                GLOBAL.hfrmControl.GetHPTextImage(ref mControlVision);
                            },
                            () =>
                            {
                                // MP
                                //GLOBAL.hfrmControl.SetMPImagePos(FinalImage.SubMat(new Rect(64, 34, 150, 3)));
                                // MP Text
                                GLOBAL.hfrmControl.GetMPTextImage(ref mControlVision);
                            }
                        );
                    }

                    WeakReference sub = new WeakReference(mControlVision);

                    mControlVision.Release();
                    mControlVision.Dispose();
                    GC.SuppressFinalize(this);
                    GC.Collect();

                    isImageRun = false;
                }
            }
        }

        private void picVision_MouseEnter(object sender, EventArgs e)
        {

        }

        private void tsSetMousePosition_Click(object sender, EventArgs e)
        {
            gfrm = new frmUserPosition(GLOBAL.hfrmMain);
            gfrm.Show();
        }
    }
}
