using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionAssist.Forms;
using VisionAssist.Vision;

namespace VisionAssist
{
    public static class GLOBAL
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

        #region 메시지 보내기 - SendMessage(windowHandle, message, longParameter, wordParameter)
        /// <summary>
        /// 메시지 보내기
        /// </summary>
        /// <param name="windowHandle">윈도우 핸들</param>
        /// <param name="message">메시지</param>
        /// <param name="longParameter">LONG 매개 변수</param>
        /// <param name="wordParameter">WORD 매개 변수</param>
        /// <returns>처리 결과</returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr windowHandle, int message, IntPtr longParameter, IntPtr wordParameter);
        #endregion

        #region 메시지 보내기 - SendMessage(windowHandle, message, longParameter, wordParameter)
        /// <summary>
        /// 메시지 보내기
        /// </summary>
        /// <param name="windowHandle">윈도우 핸들</param>
        /// <param name="message">메시지</param>
        /// <param name="longParameter">LONG 매개 변수</param>
        /// <param name="wordParameter">WORD 매개 변수</param>
        /// <returns>처리 결과</returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public  static extern IntPtr SendMessage(IntPtr windowHandle, int message, int longParameter, int wordParameter);
        #endregion

        #region Field
        /// <summary>
        /// WM_LBUTTONMOVE
        /// </summary>
        public const int WM_MOUSEMOVE = 0x200;

        /// <summary>
        /// WM_LBUTTONDOWN
        /// </summary>
        public const int WM_LBUTTONDOWN = 0x201;

        /// <summary>
        /// WM_LBUTTONUP
        /// </summary>
        public const int WM_LBUTTONUP = 0x202;

        /// <summary>
        /// MK_LBUTTON
        /// </summary>
        public const int MK_LBUTTON = 0x0001;

        /// <summary>
        /// MK_RBUTTON
        /// </summary>
        public const int MK_RBUTTON = 0x0002;

        /// <summary>
        /// MK_SHIFT
        /// </summary>
        public const int MK_SHIFT = 0x0004;

        /// <summary>
        /// MK_CONTROL
        /// </summary>
        public const int MK_CONTROL = 0x0008;

        /// <summary>
        /// MK_MBUTTON
        /// </summary>
        public const int MK_MBUTTON = 0x0010;

        #endregion

        public static frmMain hfrmMain;
        public static frmControl hfrmControl;
        public static frmVIsion hfrmVision;

        public static Object monitorLock = new System.Object();
        public static bool Locktaken = false;

        public static int OriginWidth;
        public static int OriginHeight;
        public static int ScaleWidth;
        public static int ScaleHeight;
        public static int VisionWidth;
        public static int VisionHeight;

        public static IntPtr TargetHandle;

        public static bool GetPatternMode = false;

        private static bool _bisRun = false;

        public static void Run()
        {
            _bisRun = true;
        }

        public static void Stop()
        {
            _bisRun = false;
        }

        public static bool IsRun()
        {
            return _bisRun; 
        }
    }

    static class Program
    {                
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}

