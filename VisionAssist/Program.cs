using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionAssist.API;
using VisionAssist.API.TelegramAPI;
using VisionAssist.Forms;
using VisionAssist.Vision;

namespace VisionAssist
{
    public struct Tskillbox
    {
        public CheckBox checkBox;
        public GroupBox groupBox;
        public List<RadioButton> RadioButtons;

        public Tskillbox(CheckBox chk, GroupBox grb, List<RadioButton> List, int num = 0)
        {
            this.checkBox = chk;
            this.groupBox = grb;
            this.RadioButtons = List;
        }

        public bool IsUsed()
        {
            return checkBox.Checked;
        }
    }
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

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
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

        public struct Func
        {
            public static TelegramController Telegram;
        }

        public static Object monitorLock = new System.Object();
        public static bool Locktaken = false;

        public static int OriginWidth;
        public static int OriginHeight;
        public static int ScaleWidth;
        public static int ScaleHeight;
        public static int VisionWidth;
        public static int VisionHeight;

        public static int SelectAppPlayer = int.MinValue;

        public static IntPtr TargetHandle;

        public static bool SetMousePositionMode = false;
        public static bool GetPatternMode = false;

        private static bool _bisRun = false;

        public static List<Tskillbox> lstSkillBoxes;
        public static List<int> lstSkillPos;

        public static List<int> lstMousePos;

        private static decimal[][] _axisStrings;

        public static string Path = Directory.GetCurrentDirectory() + "\\Param.ini";

        public static string GetTime()
        {
            return DateTime.Now.ToString("HHmmss");
        }

        static GLOBAL()
        {
            ReadSetupFile(Directory.GetCurrentDirectory() + "\\Param.ini");

            lstMousePos = new List<int>(10)
            {
                GetLongParameter((int)_axisStrings[0][0], (int)_axisStrings[0][1]),
                GetLongParameter((int)_axisStrings[1][0], (int)_axisStrings[1][1]),
                GetLongParameter((int)_axisStrings[2][0], (int)_axisStrings[2][1]),
                GetLongParameter((int)_axisStrings[3][0], (int)_axisStrings[3][1]),
                GetLongParameter((int)_axisStrings[4][0], (int)_axisStrings[4][1]),
                GetLongParameter((int)_axisStrings[5][0], (int)_axisStrings[5][1]),
                GetLongParameter((int)_axisStrings[6][0], (int)_axisStrings[6][1]),
                GetLongParameter((int)_axisStrings[7][0], (int)_axisStrings[7][1]),
                GetLongParameter((int)_axisStrings[8][0], (int)_axisStrings[8][1]),
                GetLongParameter((int)_axisStrings[9][0], (int)_axisStrings[9][1])
            };

            lstSkillPos = new List<int>(4)
            {
                0,
                0,
                0,
                0
            };
        }

        public static bool GetSkillGroupStatus(int idx)
        {
            return lstSkillBoxes[idx].IsUsed();
        }

        public static int GetSkillPosition(int idx)
        {
            return lstSkillPos[idx];
        }

        public static int GetLongParameter(int low, int high)
        {
            return ((high << 16) | (low & 0xffff));
        }

        public static void ReadSetupFile(string Path)
        {
            _axisStrings = new decimal[10][];
            for(int idx = 0; idx < 10; idx++)
            {
                _axisStrings[idx] = new decimal[2];
            }

            _axisStrings[0][0] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M1X", Path));
            _axisStrings[0][1] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M1Y", Path));
            _axisStrings[1][0] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M2X", Path));
            _axisStrings[1][1] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M2Y", Path));
            _axisStrings[2][0] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M3X", Path));
            _axisStrings[2][1] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M3Y", Path));
            _axisStrings[3][0] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M4X", Path));
            _axisStrings[3][1] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M4Y", Path));
            _axisStrings[4][0] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M5X", Path));
            _axisStrings[4][1] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M5Y", Path));
            _axisStrings[5][0] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M6X", Path));
            _axisStrings[5][1] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M6Y", Path));
            _axisStrings[6][0] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M7X", Path));
            _axisStrings[6][1] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M7Y", Path));
            _axisStrings[7][0] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M8X", Path));
            _axisStrings[7][1] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M8Y", Path));
            _axisStrings[8][0] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M9X", Path));
            _axisStrings[8][1] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M9Y", Path));
            _axisStrings[9][0] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M10X", Path));
            _axisStrings[9][1] = decimal.Parse(INIControl.IniRead("MousePositionParameter", "M10Y", Path));
        }

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
        static void KillProcess()
        {
            Process[] pList = Process.GetProcessesByName("Vision Assist");
            if (pList.Length > 0)
            {
                pList[0].Kill();
            }
        }/// 
         /// <summary>
         /// 해당 애플리케이션의 주 진입점입니다.
         /// </summary>
        [STAThread]
        static void Main()
        {
            //bool createdNew;
            //Mutex dup = new Mutex(true, "Focus Explorer MutexT", out createdNew); //Mutex생성

            //if (createdNew)
            //{
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());

            //    dup.ReleaseMutex(); //Mutex 해제
            //}
            //else // 프로그램이 중복 실행된 경우
            //{
            //    MessageBox.Show("The program is already running", "Informaion");
            //    //KillProcess();
            //}
        }
    }
}

