﻿using HPKR.API;
using System.Threading;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Security.Policy;
using VisionAssist.API;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using Tesseract;
using Rect = OpenCvSharp.Rect;
using Size = OpenCvSharp.Size;
using VisionAssist.Classes;
using System.IO;

namespace VisionAssist.Forms
{
    public partial class frmControl : UserControl
    {
        private LMImageList gLMImageList;
        private Mat TempMat;

        //private Mat matHP;
        //private Mat matMP;
        //private Mat matAttack;

        private Mat[] matArrHP;
        private Mat[] matArrMP;

        private Mat matPKImage;
        private Mat matMaxHPImage;
        private Mat matMaxMPImage;

        private Mat matSearchSkillArea;
        private int matSearchSkillAreaStartX;
        private int matSearchSkillAreaStartY;

        private Mat matSearchItemArea;
        private int matSearchItemAreaStartX;
        private int matSearchItemAreaStartY;

        private Mat matGunner_ManaChange;

        private HPKR_ImageProcess gImageProcess;

        private bool bRefillMP = false;
        private bool bRefillHP = false;
        private bool bEvadeAttack = false;

        private bool isMPWorking = false;

        private OpenCvSharp.Size MPsize;
        private OpenCvSharp.Size HPsize;
        private OpenCvSharp.Size Attacksize;

        TesseractEngine TengineMP;
        TesseractEngine TengineLoc;


        public frmControl()
        {
            InitializeComponent();
            GLOBAL.hfrmControl = this;

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            //Idle이벤트를 없앤다.
            Application.Idle -= Application_Idle; 

            InitVariables();
            LoadResource();
            InitPicturebox();

            ReadData();
            RunThread();

            HPsize = new OpenCvSharp.Size(picboxHP.Size.Width, picboxHP.Size.Height);
            MPsize = new OpenCvSharp.Size(picboxMP.Size.Width, picboxMP.Size.Height);
            Attacksize = new OpenCvSharp.Size(picboxUserAttack.Size.Width, picboxUserAttack.Size.Height);
        }

        private void ReadData()
        {
            chkRefillHP.Checked = Convert.ToBoolean(int.Parse(INIControl.IniRead("ControlParameter", "UseReFillHP", GLOBAL.Path)));
            chkAvoidHP.Checked = Convert.ToBoolean(int.Parse(INIControl.IniRead("ControlParameter", "UseEvadeHP", GLOBAL.Path)));
            chkRefillMP.Checked = Convert.ToBoolean(int.Parse(INIControl.IniRead("ControlParameter", "UseReFillMP", GLOBAL.Path)));
            chkUserAttackEvade.Checked = Convert.ToBoolean(int.Parse(INIControl.IniRead("ControlParameter", "UseEvadeAttack", GLOBAL.Path)));

            trBarHP.Value = int.Parse(INIControl.IniRead("ControlParameter", "PerReFillHP", GLOBAL.Path)); ;
            trBarHPEvade.Value = int.Parse(INIControl.IniRead("ControlParameter", "PerEvadeHP", GLOBAL.Path)); ;
            trBarMP.Value = int.Parse(INIControl.IniRead("ControlParameter", "PerRefillMP", GLOBAL.Path)); ;
        }

        private void RunThread()
        {
            //bgwSearchSkillPos.RunWorkerAsync();
            //bgwEvadeAttack.RunWorkerAsync();
            //bgwMP.RunWorkerAsync();
            //bgwHP.RunWorkerAsync();

            //Process currentProcess = Process.GetCurrentProcess();

            //foreach (ProcessThread processThread in currentProcess.Threads)
            //{
            //    processThread.ProcessorAffinity = currentProcess.ProcessorAffinity;
            //}
        }

        private void LoadResource()
        {
            matPKImage = Properties.Resources.PK.ToMat();
            //matMaxMPImage = Properties.Resources.MP.ToMat();
            matGunner_ManaChange = Properties.Resources.Gunner_ManaChange.ToMat();

            matPKImage = gImageProcess.ImageResize(matPKImage, picboxUserAttack.Size.Width, picboxUserAttack.Size.Height);
            gLMImageList.InsertMat(Properties.Resources.PK.ToMat(), (int)eLMImageList.PKImage);

            //matMaxMPImage = gImageProcess.ImageResize(matMaxMPImage, picboxMP.Size.Width, picboxMP.Size.Height);
            //gLMImageList.InsertMat(Properties.Resources.MP.ToMat(), (int)eLMImageList.MaxMP);

            matGunner_ManaChange = gImageProcess.ImageResize(matGunner_ManaChange, 70, 70);
            gLMImageList.InsertMat(Properties.Resources.Gunner_ManaChange.ToMat(), (int)eLMImageList.GunnerSkill_ManaChange);

            TempMat = Properties.Resources.Teleport_Scroll.ToMat();
            TempMat = gImageProcess.ImageResize(TempMat, 70, 70);
            gLMImageList.InsertMat(TempMat, (int)eLMImageList.Item_TeleportScroll);
        }

        private void InitPicturebox()
        {
            Mat mBlue = new Mat();
            mBlue.Create(picboxColorBlue.Height, picboxColorBlue.Width, MatType.CV_8UC3);
            gImageProcess.FillColor(mBlue, new Vec3b(255,0,0));

            Mat mRed = new Mat();
            mRed.Create(picboxColorRed.Height, picboxColorRed.Width, MatType.CV_8UC3);
            gImageProcess.FillColor(mRed, new Vec3b(0, 0, 255));

            picboxColorRed.Image = mRed.ToBitmap();
            picboxColorBlue.Image = mBlue.ToBitmap();

            matMaxHPImage = mRed.Clone();
            matMaxMPImage = mBlue.Clone();

        }
        private void InitVariables()
        {
            gLMImageList = new LMImageList();

            matArrHP = new Mat[10];
            matArrMP = new Mat[10];

            gImageProcess = new HPKR_ImageProcess();

            while(true)
            {
                if(gImageProcess != null) 
                    break;
            }
        }

        private void SetImageToArray(Mat[] target, Mat src)
        {
            if(gImageProcess != null)
            {
                OpenCvSharp.Size size = gImageProcess.GetImageSize(src);

                for (int idx = 0; idx < target.Length; idx++)
                {
                    Rect rct = new Rect((size.Width / target.Length) * idx, 0, (size.Width / target.Length), size.Height);
                    target[idx] = gImageProcess.ImageCrop(src, rct);
                }
            }
        }

        public void GetLocation(ref Mat src)
        {
            if (gImageProcess == null)
                return;

            Rect Pos = new Rect(800, 234, 152, 18);
            Mat MatLoc = src.SubMat(Pos);
            WeakReference wMat = new WeakReference(MatLoc);

            var old = picboxLoc.Image;

            try
            {
                VisionRect.SetRect(Pos, VisionRect.ePosition.Location);

                Cv2.Resize(MatLoc, MatLoc, new Size(
                    MatLoc.Width * 3,
                    MatLoc.Height * 3), 0, 0, InterpolationFlags.Lanczos4);

                //Cv2.InRange(MatLoc, )

                gImageProcess.ConvertRgb2Gray(MatLoc);
                //Cv2.Threshold(MatLoc, MatLoc, 140, 255, ThresholdTypes.Trunc);
                Cv2.Threshold(MatLoc, MatLoc, 170, 255, ThresholdTypes.Tozero);

                picboxLoc.Image = MatLoc.ToBitmap();

                Pix pix = PixConverter.ToPix(MatLoc.ToBitmap());
                TengineLoc = new TesseractEngine(@"./tessdata", "hangul", EngineMode.Default);

                //string whitelist = "0123456789/";
                //TengineLoc.SetVariable("tessedit_char_whitelist", whitelist);

                var result = TengineLoc.Process(pix);
                string strLoc = result.GetText().Trim();
                strLoc = strLoc.Replace(" ", "").Trim();

                System.Console.WriteLine(strLoc);

            }
            catch(Exception e)
            {
                return;
            }
            finally
            {
                //result.Dispose();

                if(old != null)
                    old.Dispose();

                TengineLoc.Dispose();
                TengineLoc = null;

                MatLoc.Release();
                MatLoc.Dispose();
                MatLoc = null;
            }
        }

        public void GetMPTextImage(Mat src)
        {
            if (gImageProcess == null)
                return;

            Rect Pos = new Rect(107, 28, 54, 13);

            using (Mat Source = src.Clone())
            using (Mat MatMP = Source.SubMat(Pos))
            using (Mat ResultResize = new Mat())
            {
                VisionRect.SetRect(Pos, VisionRect.ePosition.MP);

                Cv2.Resize(MatMP, ResultResize, new Size(MatMP.Width * 4, MatMP.Height * 4)
                    , 0, 0, InterpolationFlags.Lanczos4);

                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                // Stopwatch 를 시작 합니다.
                sw.Start();

                using (Mat GrayMat = gImageProcess.ConvertRgb2Gray(ResultResize))
                using (Mat ThresMat = new Mat())
                using (var old = picboxMP.Image)
                {
                    Cv2.Threshold(GrayMat, ThresMat, 200, 255, ThresholdTypes.Tozero);

                    picboxMP.Image = ThresMat.ToBitmap();

                    using (Pix pix = PixConverter.ToPix(ThresMat.ToBitmap()))
#if FAST_TESS
                    using (TesseractEngine TengineMP = new TesseractEngine(@"./tessdata/Fast", "eng", EngineMode.Default))
#else
                    using(TesseractEngine TengineHP = new TesseractEngine(@"./tessdata/Best", "eng", EngineMode.Default))
#endif
                    {
                        // 인식률을 높이기위한 숫자와 '/' 만 화이트리스트 적용
                        var result = TengineMP.Process(pix);
                        string MP = result.GetText().Trim();
                        MP = MP.Replace(" ", "").Trim();

                        //if (MP.IndexOf('/') == -1)
                        if (WordNum(MP, "/") != 1)
                            return;

                        if (WordNum(MP, "\n") != 0)
                            return;

                        string[] mpStrings = MP.Split('/');

                        if (mpStrings[0] == "" || mpStrings[1] == "" || mpStrings[1] == "0")
                            return;

                        bool isnum = false;
                        int chk = 0;
                        foreach (var VARIABLE in mpStrings)
                        {
                            isnum = int.TryParse(VARIABLE, out chk);
                        }

                        if (isnum == false)
                            return;

                        this.BeginInvoke(new Action(() =>
                        {
                            LedMP.Text = mpStrings[0];
                            LedMaxMP.Text = mpStrings[1];
                        }));

                        if (mpStrings.Length == 2)
                            SimpleMPWork(mpStrings);

                        result.Dispose();
                    }
                }

                sw.Stop();
                Console.WriteLine("END TIME :: " + sw.ElapsedMilliseconds.ToString() + " msec");
            }

            
        }

        public void GetHPTextImage(Mat src)
        {
            if (gImageProcess == null)
                return;

            Rect Pos = new Rect(96, 11, 76, 15);

            using(Mat Source = src.Clone())
            using(Mat MatHP = Source.SubMat(Pos))
            using(Mat ResultResize = new Mat())
            {
                VisionRect.SetRect(Pos, VisionRect.ePosition.HP);
                
                Cv2.Resize(MatHP, ResultResize, new Size(MatHP.Width * 4, MatHP.Height * 4)
                    , 0, 0, InterpolationFlags.Lanczos4);

                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                // Stopwatch 를 시작 합니다.
                sw.Start();

                using (Mat GrayMat = gImageProcess.ConvertRgb2Gray(ResultResize))
                using(Mat ThresMat = new Mat())
                using(var old = picboxHPText.Image)
                {
                    Cv2.Threshold(GrayMat, ThresMat, 180, 255, ThresholdTypes.Binary);

                    picboxHPText.Image = ThresMat.ToBitmap();

                    using (Pix pix = PixConverter.ToPix(ThresMat.ToBitmap()))
#if FAST_TESS
                    using(TesseractEngine TengineHP = new TesseractEngine(@"./tessdata/Fast", "eng", EngineMode.Default))
#else
                    using(TesseractEngine TengineHP = new TesseractEngine(@"./tessdata/Best", "eng", EngineMode.Default))
#endif
                    {
                        // tesseractengine 생성
                        string whitelist = "0123456789/";
                        // 인식률을 높이기위한 숫자와 '/' 만 화이트리스트 적용
                        TengineHP.SetVariable("tessedit_char_whitelist", whitelist);                       

                        var result = TengineHP.Process(pix);
                        string HP = result.GetText().Trim();
                        HP = HP.Replace(" ", "").Trim();

                        //if (HP.IndexOf('/') == -1)
                        if (WordNum(HP, "/") != 1)
                            return;

                        if (WordNum(HP, "\n") != 0)
                            return;

                        string[] hpStrings = HP.Split('/');

                        if (hpStrings[0] == "" || hpStrings[1] == "" || hpStrings[1] == "0")
                            return;

                        if (hpStrings.Length != 2)
                            return;

                        bool isnum = false;
                        int chk = 0;
                        foreach (var VARIABLE in hpStrings)
                        {
                            isnum = int.TryParse(VARIABLE, out chk);
                        }

                        if (isnum == false)
                            return;

                        this.BeginInvoke(new Action(() =>
                        {
                            LedHP.Text = hpStrings[0];
                            LedMaxHP.Text = hpStrings[1];
                        }));

                        SimpleHPWork(hpStrings, ref src);

                        result.Dispose();
                    }
                }

                sw.Stop();
                Console.WriteLine("END TIME :: " + sw.ElapsedMilliseconds.ToString() + " msec");
            }
        }

        public int WordNum(String String, String Word)
        {
            int Num;
            Num = String.Length - String.Replace(Word, "").Length;
            Num = Num / Word.Length;

            return Num;
        }

        public void SimpleMPWork(string[] data)
        {
            if (GLOBAL.IsRun())
            {
                bool Action = false;

                decimal mp = decimal.Parse(data[0]);
                decimal max = decimal.Parse(data[1]);

                if (max == 0)
                    return;

                decimal ratio = (mp / max) * 100;

                decimal barmp = Decimal.Zero;

                ratio = Math.Round(ratio, 2);

                this.BeginInvoke(new Action(() =>
                {
                    lblMatchingRatioMP.Text = ratio.ToString() + " %";

                    decimal Per = 0;
                    Per = decimal.Parse(trBarMP.Value.ToString()) * 10;

                    if (chkRefillMP.Checked)
                    {
                        if (ratio < Per)
                        {
                            Action = true;
                        }
                    }

                    if (Action)
                    {
                        if (GLOBAL._tskillboxes[1].IsUsed())
                        {
                            SimpleExcuteEvade(GLOBAL._mousePositions[GLOBAL._tskillpos[1]]);
                        }
                    }
                }));
            }
        }

        private int EvadeCounter;
        public void SimpleHPWork(string[] data, ref Mat src)
        {
            if (GLOBAL.IsRun())
            {
                decimal hp = decimal.Parse(data[0]);
                decimal max = decimal.Parse(data[1]);

                if (max < 1000 || max > 15000)
                {
                    System.Console.WriteLine(string.Format(@"Max Value is Abnormal : {0}", max));
                    return;
                }
                
                decimal ratio = (hp / max) * 100;
                decimal barhp = Decimal.Zero;

                int Action = int.MinValue;

                ratio = Math.Round(ratio, 2);

                lblMatchingRatioHP.BeginInvoke(new Action(() =>
                {
                    lblMatchingRatioHP.Text = ratio.ToString() + " %";
                }));

                trBarHP.Invoke(new Action(() =>
                {
                    barhp = decimal.Parse(trBarHP.Value.ToString()) * 10;
                }));

                if (chkRefillHP.Checked)
                {
                    if (ratio <= barhp)
                    {
                        System.Console.WriteLine("[{0}] Refill HP : {1}", GLOBAL.GetTime(), ratio);
                        //System.Console.WriteLine(ratio + " Search On");
                        Action = 1;
                    }
                }

                decimal dEvade = 0;

                trBarHP.Invoke(new Action(() =>
                {
                    dEvade = decimal.Parse(trBarHPEvade.Value.ToString()) * 10;
                }));

                if(Action != 1)
                {
                    if (chkAvoidHP.Checked)
                    {
                        EvadeCounter++;

                        if (ratio <= dEvade)
                        {
                            System.Console.WriteLine("[{0}] Evade HP : {1}", GLOBAL.GetTime(), ratio);

                            if (EvadeCounter >= 4)
                            {
                                Action = 2;
                                EvadeCounter = 0;
                            }
                        }
                        else
                        {
                            EvadeCounter = 0;
                        }
                    }
                }

                switch (Action)
                {
                    case 1:
                        if (GLOBAL._tskillboxes[0].IsUsed())
                        {
                            SimpleExcuteEvade(GLOBAL._mousePositions[GLOBAL._tskillpos[0]]);
                        }
                        break;
                    case 2:
                        if (GLOBAL._tskillboxes[3].IsUsed())
                        {
                            // 회피 시엔 알람 필요 없음
                            // 공격당할 시 알려줄 메시지
                            //GLOBAL.hfrmMain.SetNotifyPopupMsg("T");

                            // 이미지 저장
                            SaveImage(ref src, "Evade");

                            SimpleExcuteEvade(GLOBAL._mousePositions[GLOBAL._tskillpos[3]]);
                        }
                        break;
                    default:
                    break;
                }
            }
        }

        public bool SetAttackImagePos(ref Mat src)
        {
            if (Attacksize == OpenCvSharp.Size.Zero)
                return false;

            Rect Pos = new Rect(837, 399, 42, 47);

            using (Mat MatAttack = src.SubMat(Pos))
            {
                VisionRect.SetRect(Pos, VisionRect.ePosition.Attack);

                using (Mat ResultMat = new Mat())
                {
                    Cv2.Resize(MatAttack, ResultMat, Attacksize, 0, 0, InterpolationFlags.Lanczos4);

                    this.Invoke(new Action(()=>
                    {
                        picboxUserAttack.Image = ResultMat.ToBitmap();
                        //RefreshPicBox(ResultMat, picboxUserAttack);
                    }));

                    if (GLOBAL.IsRun())
                    {
                        if (EvadeAttack(ResultMat))
                        {
                            // 공격당할 시 알려줄 메시지
                            GLOBAL.hfrmMain.SetNotifyPopupMsg("A");

                            // 이미지 저장
                            SaveImage(ref src, "Attack");

                            if (GLOBAL._tskillboxes[3].IsUsed())
                            {
                                System.Console.WriteLine("[{0}] Evade Activate : {1}", GLOBAL.GetTime(), GLOBAL._mousePositions[GLOBAL._tskillpos[3]]);
                                SimpleExcuteEvade(GLOBAL._mousePositions[GLOBAL._tskillpos[3]]);

                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private void SaveImage(ref Mat Src, string Msg = "")
        {
            string Path = $@"{Application.StartupPath}\Capture\" + @DateTime.Now.ToString("yyyy-MM-dd") + "\\";
            string Extention = Path + @DateTime.Now.ToString("HH-mm-ss ") + Msg + ".png";
            if (Directory.Exists(Path) == false)
            {
                Directory.CreateDirectory(Path);
            }
            else
            {
                Src.SaveImage(Extention, new ImageEncodingParam(ImwriteFlags.PngCompression, 1));
            }
        }

        public void SetSearchSkillAreaImage(Mat src, Rect Area)
        {
            matSearchSkillArea?.Release();
            matSearchSkillArea = src.Clone();

            matSearchSkillAreaStartX = Area.X;
            matSearchSkillAreaStartY = Area.Y;
        }

        public void SetSearchItemAreaImage(Mat src, Rect Area, int idx)
        {
            gLMImageList.InsertMat(src, idx);

            matSearchItemArea?.Release();
            matSearchItemArea = src.Clone();

            matSearchItemAreaStartX = Area.X;
            matSearchItemAreaStartY = Area.Y;
        }

        public void SetMessage(string msg)
        {
            tbxSearchMessage.Invoke(new Action(()=>
            {
                tbxSearchMessage.Text = msg;
            }));
        }

        private void btnGetPattern_Click(object sender, EventArgs e)
        {
            GLOBAL.GetPatternMode = true;
            GLOBAL.hfrmVision.picVision.Cursor = Cursors.Cross;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void RefreshPicBox(Mat src, PictureBox target)
        {
            using(var mat = src.Clone())
            using (var box = target)
            {
                box.Image = mat.ToBitmap();
                box.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int idx = 0; idx < matArrHP.Length; idx++)
            {
                Cv2.ImShow(idx.ToString(), matArrHP[idx]);
            }

            for (int idx = 0; idx < matArrMP.Length; idx++)
            {
                Cv2.ImShow(idx.ToString(), matArrMP[idx]);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Invalidate();
        }

        private bool EvadeAttack(Mat MatAttack)
        {
            double result = gImageProcess.TemplateMatchingGetRatio(ref matPKImage, ref MatAttack);

            lblMatchingRatioEvade.Invoke(new Action(() =>
            {
                lblMatchingRatioEvade.Text = result.ToString() + " %";
            }));

            if (chkUserAttackEvade.Checked)
            {
                if (result >= 0.6)
                {
                    bEvadeAttack = true;
                }
                else
                    bEvadeAttack = false;
            }
            else
                bEvadeAttack = false;

            return bEvadeAttack;
        }

        private void bgwEvadeAttack_DoWork(object sender, DoWorkEventArgs e)
        {
       
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }


        private void lblMatchingRatioMP_Click(object sender, EventArgs e)
        {

        }

        private void SearchSkillPos()
        {
            //if (matSearchSkillArea != null && matGunner_ManaChange != null)
            //{
                Random r = new Random();

                if (bRefillMP)
                {
                    Mat result = new Mat();
                    Mat GrayMat = new Mat();
                    Mat GrayArea = new Mat();

                    Cv2.CvtColor(matGunner_ManaChange, GrayMat, ColorConversionCodes.BGR2GRAY);
                    Cv2.CvtColor(matSearchSkillArea, GrayArea, ColorConversionCodes.BGR2GRAY);

                    // 이미지 템플릿 매치
                    Cv2.MatchTemplate(GrayArea, GrayMat, result, TemplateMatchModes.CCoeffNormed);

                    // 이미지의 최대/ 최소 위치 겟
                    OpenCvSharp.Point minloc, maxloc;
                    double minval, maxval;
                    Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

                    // 타겟 이미지랑 유사 정도 1에 가까울 수록 같음
                    var threshold = 0.53;
                    System.Console.WriteLine("Search Skill : {0}", maxval);

                    if (maxval >= threshold)
                    {
                        int X = (int)(maxloc.X + matSearchSkillAreaStartX) + (matGunner_ManaChange.Width / 2);
                        int Y = (int)(maxloc.Y + matSearchSkillAreaStartY) + (matGunner_ManaChange.Height / 2);

                        X = (int)GLOBAL.hfrmVision.VisionMoveScalingWidth(r.Next(X - 5, X + 5));
                        Y = (int)GLOBAL.hfrmVision.VisionMoveScalingHeight(r.Next(Y - 5, Y + 5));

                        int longParameter = GLOBAL.hfrmVision.GetLongParameter(X, Y);
                        GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONDOWN, 0, longParameter);
                        GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONUP, 0, longParameter);

                        // 서치된 부분을 빨간 테두리로
                        //Rect rect = new Rect(maxloc.X, maxloc.Y, matGunner_ManaChange.Width, matGunner_ManaChange.Height);
                        //Cv2.Rectangle(GrayArea, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

                        //표시
                        //Cv2.ImShow("template1_show", GrayArea);
                        //Cv2.ImShow("org", matGunner_ManaChange);
                        //Cv2.WaitKey(0);

                    }

                    //result.Release();
                }

                //Thread.Sleep(r.Next(400, 1000));
            //}
        }

        private void bgwSearchSkillPos_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                if (matSearchSkillArea != null && matGunner_ManaChange != null)
                { 
                    Random r = new Random();
    
                    if (bRefillMP)
                    {
                        Mat result = new Mat();
                        Mat GrayMat = new Mat();
                        Mat GrayArea = new Mat();

                        try
                        {
                            Cv2.CvtColor(matGunner_ManaChange, GrayMat, ColorConversionCodes.BGR2GRAY);
                            Cv2.CvtColor(matSearchSkillArea, GrayArea, ColorConversionCodes.BGR2GRAY);
                        }
                        catch(Exception ex)
                        {
                            continue;
                        }
                        

                        // 이미지 템플릿 매치
                        Cv2.MatchTemplate(GrayArea, GrayMat, result, TemplateMatchModes.CCoeffNormed);

                        // 이미지의 최대/ 최소 위치 겟
                        OpenCvSharp.Point minloc, maxloc;
                        double minval, maxval;
                        Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

                        // 타겟 이미지랑 유사 정도 1에 가까울 수록 같음
                        var threshold = 0.53;
                        System.Console.WriteLine(maxval);
                        if (maxval >= threshold)
                        {
                            int X = (int)(maxloc.X + matSearchSkillAreaStartX) + (matGunner_ManaChange.Width / 2);
                            int Y = (int)(maxloc.Y + matSearchSkillAreaStartY) + (matGunner_ManaChange.Height / 2);

                            X = (int)GLOBAL.hfrmVision.VisionMoveScalingWidth(r.Next(X-5, X+5));
                            Y = (int)GLOBAL.hfrmVision.VisionMoveScalingHeight(r.Next(Y - 5, Y + 5));

                            int longParameter = GLOBAL.hfrmVision.GetLongParameter(X, Y);
                            GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONDOWN, 0, longParameter);
                            GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONUP, 0, longParameter);

                            // 서치된 부분을 빨간 테두리로
                            //Rect rect = new Rect(maxloc.X, maxloc.Y, matGunner_ManaChange.Width, matGunner_ManaChange.Height);
                            //Cv2.Rectangle(GrayArea, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

                            //표시
                            //Cv2.ImShow("template1_show", GrayArea);
                            //Cv2.ImShow("org", matGunner_ManaChange);
                            //Cv2.WaitKey(0);

                        }

                        //result.Release();
                    }
                    
                    Thread.Sleep(r.Next(400, 1000));
                }

                //Monitor.Exit(GLOBAL.monitorLock);
            }
        }

        private void SimpleExcuteEvade(int Param)
        {
            GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONDOWN, 0, Param);
            Thread.Sleep(200);            
            GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONUP, 0, Param);
            //Thread.Sleep(100);
        }


        private void bgwExcuteEvade_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                if(bEvadeAttack)
                {
                    // 타겟 이미지랑 유사 정도 1에 가까울 수록 같음

                }
            }           
        }

        private void bgwHP_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }
    

        private void bgwMP_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblMatchingRatioEvade_Click(object sender, EventArgs e)
        {

        }

        private void trBarHPEvade_Scroll(object sender, EventArgs e)
        {
            ttHP.SetToolTip(trBarHPEvade, (trBarHPEvade.Value * 10) + "%".ToString());
            INIControl.IniWrite("ControlParameter", "PerEvadeHP", trBarHPEvade.Value.ToString(), GLOBAL.Path);
        }

        private void trBarHP_Scroll(object sender, EventArgs e)
        {
            ttHP.SetToolTip(trBarHP, (trBarHP.Value * 10) + "%".ToString());
            INIControl.IniWrite("ControlParameter", "PerReFillHP", trBarHP.Value.ToString(), GLOBAL.Path);
        }

        private void trBarMP_Scroll(object sender, EventArgs e)
        {
            ttMP.SetToolTip(trBarMP, (trBarMP.Value * 10) + "%".ToString());
            INIControl.IniWrite("ControlParameter", "PerRefillMP", trBarMP.Value.ToString(), GLOBAL.Path);
        }

        private void chkUserAttackEvade_CheckedChanged(object sender, EventArgs e)
        {
            INIControl.IniWrite("ControlParameter", "UseEvadeAttack", Convert.ToInt32(chkUserAttackEvade.Checked).ToString(), GLOBAL.Path);
        }

        private void chkAvoidHP_CheckedChanged(object sender, EventArgs e)
        {
            INIControl.IniWrite("ControlParameter", "UseEvadeHP", Convert.ToInt32(chkAvoidHP.Checked).ToString(), GLOBAL.Path);
        }

        private void chkRefillMP_CheckedChanged(object sender, EventArgs e)
        {
            INIControl.IniWrite("ControlParameter", "UseReFillMP", Convert.ToInt32(chkRefillMP.Checked).ToString(), GLOBAL.Path);
        }

        private void chkRefillHP_CheckedChanged(object sender, EventArgs e)
        {
            INIControl.IniWrite("ControlParameter", "UseReFillHP", Convert.ToInt32(chkRefillHP.Checked).ToString(), GLOBAL.Path);
        }

        private void btnSetMessage_Click(object sender, EventArgs e)
        {
            //TextBox textBox = sender as TextBox;
            //GLOBAL.SendMessage(GLOBAL.TargetHandle, 0x004A, 0, tbxKeyString.Text);
        }
    }
}
