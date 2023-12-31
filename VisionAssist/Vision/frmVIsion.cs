﻿using System;
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
using VisionAssist.Classes;
using System.Runtime.InteropServices;
using HPKR_VisionControl;

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

    public struct stImageWork
    {
        public static bool isRun = false;
        public static Mat Target = null;
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
        public Direct2dControl g_direct2D;

        private List<WindowSnap> lstSnap;
        private Rect gRect;
        public bool bDrawText = false;
        public bool VisionGetRun = false;
        private Thread Visiontrd = null;

        private Mat mat = new Mat();
        private Mat FinalImage = new Mat();
        private Mat FinalCopy;
        
        private Task Task_ImageWork;

        private bool isImageRun;

        private frmUserPosition gfrm;

        private HPKR_ImageProcess gImageProcess = null;

        private static OpenCvSharp.Size Picsize;

        private Mat mControlVision;

        private static object _imageLock = new object();

        private bool MouseDown_Clicked = false;

        public frmVIsion()
        {
            InitializeComponent();
            GLOBAL.hfrmVision = this;

            this.KeyUp += GLOBAL.hfrmMain.frmMain_KeyUp;

            g_direct2D = new Direct2dControl(picVision.Handle,
                picVision.Width, picVision.Height);

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

            // 새로 추가함
            //TaskRun();

            GLOBAL.VisionWidth = picVision.Width;
            GLOBAL.VisionHeight = picVision.Height;

            gImageProcess = new HPKR_ImageProcess();
        }

        public void func_ImageWork(Mat VisionData)
        {           
            stImageWork.isRun = true;            

            // 공격 당하고 있으면 이후의 동작을 수행하지 않는다.
            if (!(GLOBAL.hfrmControl.SetAttackImagePos(ref VisionData)))
            {
#if FAST_TESS
                Parallel.Invoke(
                () =>
                {
                    if(GLOBAL.hfrmControl.GetHPTextImage(VisionData))
                    {
                        // 자동 스킬 공격
                        GLOBAL.hfrmControl.SimpleAttackSkill();
                        GLOBAL.hfrmControl.GetMPTextImage(VisionData);
                    }
                },
                () =>
                {
                    
                },
                () =>
                {
                    //GLOBAL.hfrmControl.GetLocation(VisionData);
                },
                () =>
                {
                    // 현재 위치가 어디인지 파악 
                    // 해당 기능은 추후 자동사냥 구현할때 참고 될지도...?

                    //GLOBAL.hfrmControl.GetLocation(ref mControlVision);
                });
#else
                Mat Sample = null;
                if (VisionData.IsDisposed == false)
                {
                    Sample = VisionData.Clone();
                    Thread RunThread = new Thread(new ThreadStart(delegate ()
                    {
                        Parallel.Invoke(
                        () =>
                        {
                            GLOBAL.hfrmControl.GetHPTextImage(Sample);
                        },
                        () =>
                        {
                            //GLOBAL.hfrmControl.GetMPTextImage(ref VisionData);
                        },
                        () =>
                        {
                            // 현재 위치가 어디인지 파악 
                            // 해당 기능은 추후 자동사냥 구현할때 참고 될지도...?

                            //GLOBAL.hfrmControl.GetLocation(ref mControlVision);
                        });

                        Sample.Dispose();
                    }));


                    RunThread.Start();
                }
#endif
            }

            VisionData.Release();
            VisionData.Dispose();
            stImageWork.isRun = false;
        }

        public void SetMousePosition(int X, int Y)
        {
            stAxis.NowPosition.X = X;
            stAxis.NowPosition.Y = Y;

            stAxis.NowRealPosition.X = (float)VisionMoveScalingWidth(X);
            stAxis.NowRealPosition.Y = (float)VisionMoveScalingHeight(Y);
        }

        public Vector2 ConvertPosition(int X, int Y)
        {
            Vector2 RealPos = new Vector2(0, 0);

            RealPos.X = (float)VisionMoveScalingWidth(X);
            RealPos.Y = (float)VisionMoveScalingHeight(Y);

            return RealPos;
        }

        public Rect ConvertPosition(Rect Source)
        {
            Rect RealPos = new Rect(0, 0, 0, 0);

            RealPos.X = (int)VisionMoveScalingWidth(Source.X);
            RealPos.Y = (int)VisionMoveScalingHeight(Source.Y);
            RealPos.Width = (int)VisionMoveScalingWidth(Source.Width);
            RealPos.Height = (int)VisionMoveScalingHeight(Source.Height);

            return RealPos;
        }

        public Vector2 ConvertPositionRandomize(Rect Source)
        {
            Rect RealPos = new Rect(0, 0, 0, 0);

            RealPos.X = (int)VisionMoveScalingWidth(Source.X);
            RealPos.Y = (int)VisionMoveScalingHeight(Source.Y);
            RealPos.Width = (int)VisionMoveScalingWidth(Source.Width);
            RealPos.Height = (int)VisionMoveScalingHeight(Source.Height);

            Random r = new Random();

            RealPos.X = r.Next(RealPos.X + 4, RealPos.X + RealPos.Width - 4);
            RealPos.Y = r.Next(RealPos.Y + 4, RealPos.Y + RealPos.Height - 4);

            Vector2 Ret = new Vector2(RealPos.X, RealPos.Y);

            return Ret;
        }

        public Vector2 GetRealPosition(Rect pos)
        {
            float posX = pos.X + (pos.Width / 2);
            float posY = pos.Y + (pos.Height / 2);

            Vector2 RealPos = new Vector2(0, 0);

            RealPos.X = (float)VisionMoveScalingWidth(posX);
            RealPos.Y = (float)VisionMoveScalingHeight(posY);

            return RealPos;
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
            //if(rect.TopLeft == rect.BottomRight)
            //    return;

            //using(Bitmap Dummy = (Bitmap)picVision.Image.Clone())
            //{
            //    using(Mat test = gImageProcess.ImageCrop(Dummy, rect))
            //    {

            //    }
            //}
        }

        int OldWidth = 0;
        int OldHeight = 0;
        Mat g_ResultMat = new Mat();
        public void ImageCapture(string target)
        {
            if(gImageProcess == null)
                return;

            if(!GLOBAL.GetPatternMode)
            {
                lock (_imageLock)
                {
                    //IntPtr main = GLOBAL.FindWindow(null, target+ "(64)");
                    IntPtr main = GLOBAL.FindWindow(null, target);
                    IntPtr sub = IntPtr.Zero;

                    sub = GLOBAL.FindWindowEx(main, 0, "RenderWindow", "TheRender");

                    if (main == IntPtr.Zero)
                        return;

                    if (sub == IntPtr.Zero)
                        return;

                    GLOBAL.TargetHandle = sub;

                    using (Graphics gdata = Graphics.FromHwnd(sub))
                    {
                        Rectangle rect = Rectangle.Round(gdata.VisibleClipBounds);
                        rect = DPIConverter(rect, sub);

                        using (Bitmap BitData = new Bitmap(rect.Width, rect.Height,
                        System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                        //using (Bitmap BitData = new Bitmap(rect.Width, rect.Height,
                        //System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                        
                        using(Graphics g = Graphics.FromImage(BitData))
                        {
                            IntPtr hdc = g.GetHdc();

                            bool ret = GLOBAL.PrintWindow(sub, hdc, 2);
                            g.ReleaseHdc(hdc);
                            ret = GLOBAL.DeleteDC(hdc);

                            using (Mat Originmat = BitmapConverter.ToMat(BitData))
                            using (Mat FinalImage = new Mat())
                            using (Mat ResultMat = new Mat())
                            {
                                    
                                //Cv2.Resize(mat, FinalImage, Picsize, 0, 0, InterpolationFlags.Lanczos4);
                                Cv2.Resize(Originmat, FinalImage, Picsize, 0, 0, InterpolationFlags.Linear);
                                Cv2.CvtColor(FinalImage, ResultMat, ColorConversionCodes.RGBA2RGB);

                                if (OldWidth != ResultMat.Width || OldHeight != ResultMat.Height)
                                {
                                    OldWidth = ResultMat.Width;
                                    OldHeight = ResultMat.Height;

                                    Invoke(new Action(() =>
                                    {
                                        g_direct2D.Initialize(picVision.Handle, ResultMat.Width, ResultMat.Height);
                                    }));
                                }

                                if (bDrawText)
                                {
                                    // Text Location
                                    OpenCvSharp.Point myPoint;
                                    myPoint.X = FinalImage.Width - 400;
                                    myPoint.Y = FinalImage.Height - 10;

                                    // Font Face
                                    int myFontFace = 2;

                                    Vector2 Pos = GetMousePosition();
                                    string frame = string.Format("Pos : {0}, {1}", Pos.X, Pos.Y);

                                    // Font Scale
                                    gImageProcess.DrawTextToImage(myPoint, ResultMat, frame, Scalar.Red);
                                }

                                // Maint 체크박스 활성화 시
                                if (GLOBAL.hfrmMain.GetMaintenanceMode())
                                {
                                    // 설정한 영역에 대한 사각박스를 그린다.
                                    VisionRect.DrawRectArea(ResultMat);
                                }

                                if (stImageWork.Target == null)
                                {
                                    stImageWork.Target = ResultMat.Clone();
                                }
                                    
                                g_direct2D.DrawImage(ResultMat);
                            }
                        }
                    }
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

            if (GLOBAL.SetMousePositionMode)
            {
                return;
            }

            // 패턴 가져오기위해 이미지 그리기 멈춤
            if (GLOBAL.GetPatternMode)
            {
                gRect = new Rect(e.X, e.Y, 0, 0);
                SetMouseRangeStart(gRect.X, gRect.Y);

                // 여기서부터 시작했다는 플래그 발생시킴
                MouseDown_Clicked = true;
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
                if (MouseDown_Clicked)
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

                //GetImageFromPictureBox(gRect);
                SetMouseRangeEnd(width, height);
                
                MouseDown_Clicked = false;

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

                    //e.Graphics.DrawRectangle(pen, rct);
                    //e.Dispose();
                }
            }
            else
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    Rectangle rct = new Rectangle(0, 0, 0, 0);
                    //e.Graphics.DrawRectangle(pen, rct);
                    //e.Dispose();
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

        private void picVision_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            GLOBAL.SendMessage(GLOBAL.TargetHandle, 0x000c, 0, textBox.Text);
        }
    }

    public struct COPYDATASTRUCT
    {
        public IntPtr dwData;
        public UInt32 cbData;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData;
    }
}
