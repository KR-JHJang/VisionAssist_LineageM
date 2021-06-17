using HPKR.API;
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

namespace VisionAssist.Forms
{
    public partial class frmControl : UserControl
    {
        private LMImageList gLMImageList;
        private Mat TempMat;

        private Mat matHP;
        private Mat matMP;
        private Mat matAttack;

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

        TesseractEngine TengineHP;
        TesseractEngine TengineMP;


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

            Process currentProcess = Process.GetCurrentProcess();

            foreach (ProcessThread processThread in currentProcess.Threads)
            {
                processThread.ProcessorAffinity = currentProcess.ProcessorAffinity;
            }
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

        public void GetMPTextImage(ref Mat src)
        {
            if (gImageProcess == null)
                return;

            Cv2.Resize(src, src, new Size(
                src.Width * 2,
                src.Height * 2), 0,0, InterpolationFlags.Lanczos4);
            gImageProcess.ConvertRgb2Gray(src);
            Cv2.Threshold(src, src, 200, 255, ThresholdTypes.Tozero);

            if (picboxMP.Image != null)
                picboxMP.Image.Dispose();

            picboxMP.Image = src.ToBitmap();

            Pix pix = PixConverter.ToPix(src.ToBitmap());
            TengineMP = new TesseractEngine(@"./tessdata", "eng", EngineMode.TesseractOnly);
            // tesseractengine 생성
            string whitelist = "0123456789/";
            TengineMP.SetVariable("tessedit_char_whitelist", whitelist);

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

            this.Invoke(new Action(() =>
            {
                LedMP.Text = mpStrings[0];
                LedMaxMP.Text = mpStrings[1];
            }));

            TengineMP.Dispose();
            TengineMP = null;

            if(mpStrings.Length == 2)
                SimpleMPWork(mpStrings);



        }

        public void GetHPTextImage(ref Mat src)
        {
            if (gImageProcess == null)
                return;

            Cv2.Resize(src, src, new Size(src.Width*2, src.Height*2)
                , 0, 0, InterpolationFlags.Lanczos4);

            gImageProcess.ConvertRgb2Gray(src);
            Cv2.Threshold(src, src, 180, 255, ThresholdTypes.Binary);

            if (picboxHPText.Image != null)
                picboxHPText.Image.Dispose();

            picboxHPText.Image = src.ToBitmap();

            Pix pix = PixConverter.ToPix(src.ToBitmap());
            TengineHP = new TesseractEngine(@"./tessdata", "eng", EngineMode.TesseractOnly);
            // tesseractengine 생성
            string whitelist = "0123456789/";
            TengineHP.SetVariable("tessedit_char_whitelist", whitelist);

            // 인식률을 높이기위한 숫자와 '/' 만 화이트리스트 적용
            var result = TengineHP.Process(pix);
            string HP = result.GetText().Trim();
            HP = HP.Replace(" ", "").Trim();

            //if (HP.IndexOf('/') == -1)
            if(WordNum(HP, "/") != 1)
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

            this.Invoke(new Action(() =>
            {
                LedHP.Text = hpStrings[0];
                LedMaxHP.Text = hpStrings[1];
            }));

            //if (!(TengineMP.IsDisposed))
            TengineHP.Dispose();
            TengineHP = null;

            SimpleHPWork(hpStrings);
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

                lblMatchingRatioMP.Invoke(new Action(() =>
                {
                    lblMatchingRatioMP.Text = ratio.ToString() + " %";
                }));

                decimal Per = 0;

                trBarMP.Invoke(new Action(() =>
                {
                    Per = decimal.Parse(trBarMP.Value.ToString()) * 10;
                }));

                if (chkRefillMP.Checked)
                {
                    if (ratio < Per)
                    {
                        //System.Console.WriteLine(ratio + " Search On");
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
            }
        }

        private int EvadeCounter;
        public void SimpleHPWork(string[] data)
        {
            if (GLOBAL.IsRun())
            {
                decimal hp = decimal.Parse(data[0]);
                decimal max = decimal.Parse(data[1]);

                if (max == 0)
                    return;

                decimal ratio = (hp / max) * 100;

                decimal barhp = Decimal.Zero;

                int Action = int.MinValue;

                ratio = Math.Round(ratio, 2);

                lblMatchingRatioHP.Invoke(new Action(() =>
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

                if (chkAvoidHP.Checked)
                {
                    EvadeCounter++;

                    if (ratio <= dEvade)
                    {
                        System.Console.WriteLine("[{0}] Refill HP : {1}", GLOBAL.GetTime(), ratio);
 
                        if (EvadeCounter >= 3)
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
                            SimpleExcuteEvade(GLOBAL._mousePositions[GLOBAL._tskillpos[3]]);
                        }
                        break;
                }
            }
        }

        public void SetHPImagePos(Mat src)
        {
            if (HPsize == OpenCvSharp.Size.Zero)
                return;

            matHP?.Release();
            matHP = src.Clone();
            
            Cv2.Resize(matHP, matHP, HPsize, 0, 0, InterpolationFlags.Cubic);

            if (chkHPTest.Checked)
            {
                gImageProcess.ConvertColorNormalize(matHP,
                    double.Parse(tbxHPUpper.Text),
                    double.Parse(tbxHPLower.Text), 2);
            }
            else
            {
                gImageProcess.ConvertColorNormalize(matHP, 142, 255, 2);
            }

            RefreshPicBox(ref matHP, ref picboxHP);

            //RefreshHP();

            if (GLOBAL.IsRun())
            {
                int ret = HP_Work();

                switch (ret)
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
                            SimpleExcuteEvade(GLOBAL._mousePositions[GLOBAL._tskillpos[3]]);
                        }
                        break;
                }
            }
        }
      
        public void SetMPImagePos(Mat src)
        {
            if (MPsize == OpenCvSharp.Size.Zero)
                return;

            matMP?.Release();
            matMP = src;
            
            Cv2.Resize(matMP, matMP, MPsize, 0, 0, InterpolationFlags.Cubic);

            gImageProcess.ConvertColorNormalize(ref matMP,
                102,
                108);

            RefreshPicBox(ref matMP, ref picboxMP);

            //RefreshMP();

            if (GLOBAL.IsRun())
            {
                if (MP_Work())
                {
                    if (GLOBAL._tskillboxes[1].checkBox.Checked)
                    {

                        //SearchSkillPos();
                    }
                }
            }
        }

        public bool SetAttackImagePos(ref Mat src)
        {
            if (Attacksize == OpenCvSharp.Size.Zero)
                return false;

            matAttack?.Release();
            matAttack = src;
            
            Cv2.Resize(matAttack, matAttack, Attacksize, 0, 0, InterpolationFlags.Cubic);

            //gImageProcess.ConvertRGB2GRAY(matAttack);

            RefreshPicBox(ref matAttack, ref picboxUserAttack);
            
            if (GLOBAL.IsRun())
            {
                if (EvadeAttack())
                {
                    if (GLOBAL._tskillboxes[3].IsUsed())
                    {
                        System.Console.WriteLine("[{0}] Evade Activate : {1}", GLOBAL.GetTime(), GLOBAL._mousePositions[GLOBAL._tskillpos[3]]);
                        SimpleExcuteEvade(GLOBAL._mousePositions[GLOBAL._tskillpos[3]]);
                        
                        return true;
                    }
                }
            }

            return false;
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

        private void RefreshHP()
        {
            if (!matHP.IsDisposed)
            {
                picboxHP.Image?.Dispose();
                picboxHP.Invoke(new Action(() =>
                {
                    picboxHP.Image = matHP.ToBitmap();
                }));

            }
        }

        private void RefreshMP()
        {
            try
            {
                if (!matMP.IsDisposed)
                {
                    if (picboxMP.Image != null)
                    {
                        picboxMP.Image.Dispose();
                    }

                    picboxMP.Invoke(new Action(() =>
                    {
                        picboxMP.Image = matMP.ToBitmap();
                    }));


                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void RefreshPicBox(ref Mat src, ref PictureBox target)
        {
            if(target.Image != null)
                target.Image?.Dispose();

            try
            {
                if (!src.IsDisposed)
                {
                    var mat = src;
                    var box = target;

                    box.Image = mat.ToBitmap();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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

        private bool EvadeAttack()
        {
            //if (matAttack != null && matPKImage != null)
            //{
                //VecLoc3d result = gImageProcess.TemplateMatchingGetAllData(ref matPKImage, ref matAttack);
                double result = gImageProcess.TemplateMatchingGetRatio(ref matPKImage, ref matAttack);

                lblMatchingRatioEvade.Invoke(new Action(() =>
                {
                    lblMatchingRatioEvade.Text = result.ToString() + " %";
                }));

                if (chkUserAttackEvade.Checked)
                {
                    if (result >= 0.63)
                    {
                        bEvadeAttack = true;
                    }
                    else
                        bEvadeAttack = false;
                }
                else
                    bEvadeAttack = false;
            //}
            //else
            //{
            //    return;
            //}

            return bEvadeAttack;
        }

        private void bgwEvadeAttack_DoWork(object sender, DoWorkEventArgs e)
        {
        //    while(true)
        //    {
        //        if (matAttack == null || matPKImage == null)
        //            continue;

        //        if (matPKImage.IsDisposed || matAttack.IsDisposed)
        //            continue;

        //        if (matAttack != null && matPKImage != null)
        //        {
        //            VecLoc4d result = gImageProcess.TemplateMatchingGetAllData(matPKImage.Clone(), matAttack.Clone());

        //            lblMatchingRatioEvade.Invoke(new Action(()=>
        //            {
        //                lblMatchingRatioEvade.Text = result.maxval.ToString() + " %";
        //            }));

        //            if(chkUserAttackEvade.Checked)
        //            {
        //                if (result.maxval >= 0.66)
        //                {
        //                    bEvadeAttack = true;
        //                }
        //                else
        //                    bEvadeAttack = false;
        //            }
        //            else
        //                bEvadeAttack = false;

        //            if (bEvadeAttack)
        //            {
        //                ExcuteEvade();
        //            }

        //            result.retMat.Release();
        //        }
                
        //        Thread.Sleep(100);
        //    }
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
            Thread.Sleep(20);
            GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONUP, 0, Param);
        }

        //private void ExcuteEvade()
        //{
        //    VecLoc4d result = gImageProcess.TemplateMatchingGetAllData(
        //        gLMImageList.GetMat((int)eLMImageList.SearchItemArea).Clone(),
        //        gLMImageList.GetMat((int)eLMImageList.Item_TeleportScroll).Clone());

        //    Random r = new Random();

        //    var threshold = 0.44;
        //    System.Console.WriteLine("Excute : " + result.maxval);

        //    if (result.maxval >= threshold)
        //    {
        //        int X = (int)(result.maxloc.X + matSearchItemAreaStartX) + 
        //            (gLMImageList.GetMat((int)eLMImageList.Item_TeleportScroll).Width / 2);
        //        int Y = (int)(result.maxloc.Y + matSearchItemAreaStartY) + 
        //            (gLMImageList.GetMat((int)eLMImageList.Item_TeleportScroll).Height / 2);

        //        X = (int)GLOBAL.hfrmVision.VisionMoveScalingWidth(r.Next(X - 5, X + 5));
        //        Y = (int)GLOBAL.hfrmVision.VisionMoveScalingHeight(r.Next(Y - 5, Y + 5));

        //        int longParameter = GLOBAL.hfrmVision.GetLongParameter(X, Y);

        //        //Thread.Sleep((r.Next(2000, 3000)));

        //        GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONDOWN, 0, longParameter);
        //        GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONUP, 0, longParameter);

        //        // 서치된 부분을 빨간 테두리로
        //        Rect rect = new Rect(result.maxloc.X, result.maxloc.Y, result.retMat.Width, result.retMat.Height);
        //        Cv2.Rectangle(result.retMat, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

        //        lblMatchingRatioExcute.Invoke(new Action(() =>
        //        {
        //            lblMatchingRatioExcute.Text = result.maxval.ToString();
        //        }));

        //        if (picEvadeTest.Image != null)
        //            picEvadeTest.Image.Dispose();

        //        Cv2.Resize(result.retMat, result.retMat, new Size(picEvadeTest.Width, picEvadeTest.Height), 0,0,InterpolationFlags.Cubic);

        //        picEvadeTest.Image = result.retMat.ToBitmap();

        //        //표시
        //        //Cv2.ImShow("template1_show", result.retMat);
        //        //Cv2.WaitKey(0);
        //    }
        //}

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

        private int HP_Work()
        {
            int Action = 0;

            if (matHP != null && matMaxHPImage != null)
            {
                double ratio = 0;

                try
                {
                    //ratio = gImageProcess.TemplateMatchingRatio(matMaxMPImage.Clone(), matMP.Clone());
                    ratio = gImageProcess.SimpleColorMatching(matMaxHPImage.Clone(), matHP.Clone(), 2);

                    if (ratio <= 0)
                        return 0;
                        
                    ratio = Math.Round(ratio, 2);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex);
                }


                lblMatchingRatioMP.Invoke(new Action(() =>
                {
                    lblMatchingRatioHP.Text = ratio.ToString() + " %";
                }));

                double Per = 0;

                trBarHP.Invoke(new Action(() =>
                {
                    Per = double.Parse(trBarHP.Value.ToString()) * 10;
                }));

                if (chkRefillHP.Checked)
                {
                    if (ratio <= Per)
                    {
                        System.Console.WriteLine("[{0}] Refill HP : {1}", GLOBAL.GetTime(), ratio);
                        //System.Console.WriteLine(ratio + " Search On");
                        Action = 1;
                    }
                }

                double dEvade = 0;

                trBarHP.Invoke(new Action(() =>
                {
                    dEvade = double.Parse(trBarHPEvade.Value.ToString()) * 10;
                }));

                if (chkAvoidHP.Checked)
                {
                    if (ratio <= dEvade)
                    {
                        System.Console.WriteLine("[{0}] Refill HP : {1}", GLOBAL.GetTime(), ratio);
                        Action = 2;
                    }
                }
            }

            return Action;
        }

        private void bgwHP_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (matHP == null)
                    continue;

                if (matHP.IsDisposed)
                    continue;

                if (matHP != null && matMaxHPImage != null)
                {
                    double ratio = 0;

                    try
                    {
                        //ratio = gImageProcess.TemplateMatchingRatio(matMaxMPImage.Clone(), matMP.Clone());
                        ratio = gImageProcess.SimpleColorMatching(matMaxHPImage.Clone(), matHP.Clone(), 2);

                        if (ratio <= 0)
                            continue;

                        ratio = Math.Round(ratio, 2);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex);
                        continue;
                    }


                    lblMatchingRatioHP.Invoke(new Action(() =>
                    {
                        lblMatchingRatioHP.Text = ratio.ToString() + " %";
                    }));

                    double Per = 0;

                    trBarHP.Invoke(new Action(()=>
                    {
                        Per = double.Parse(trBarHP.Value.ToString()) * 10;
                    }));

                    if (chkRefillHP.Checked)
                    {
                        if (ratio < Per)
                        {
                            //System.Console.WriteLine(ratio + " Search On");
                            bRefillHP = true;
                        }
                        else
                            bRefillHP = false;
                    }
                    else
                        bRefillHP = false;
                }

                Thread.Sleep(100);
            }
        }
    
        private bool MP_Work()
        {
            //if (matMP != null && matMaxMPImage != null)
            //{
                double ratio = 0;

                try
                {
                    //ratio = gImageProcess.TemplateMatchingRatio(matMaxMPImage.Clone(), matMP.Clone());
                    ratio = gImageProcess.SimpleColorMatching(matMaxMPImage.Clone(), matMP.Clone());
                    ratio = Math.Round(ratio, 2);

                    //System.Console.WriteLine("Ratio = {0}", ratio);
                    //Cv2.ImShow("1", matMaxMPImage);
                    //Cv2.ImShow("2", matMP);
                    //Cv2.WaitKey(0);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex);
                }


                lblMatchingRatioMP.Invoke(new Action(() =>
                {
                    lblMatchingRatioMP.Text = ratio.ToString() + " %";
                }));

                double Per = 0;

                trBarHP.Invoke(new Action(() =>
                {
                    Per = double.Parse(trBarMP.Value.ToString()) * 10;
                }));

                //System.Console.WriteLine(ratio);

                if (chkRefillMP.Checked)
                {
                    if (ratio < Per)
                    {
                        //System.Console.WriteLine(ratio + " Search On");
                        bRefillMP = true;
                    }
                    else
                        bRefillMP = false;
                }
                else
                    bRefillMP = false;
            //}

            return bRefillMP;
        }
        private void bgwMP_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (matMP == null)
                    continue;

                if (matMP.IsDisposed)
                    continue;

                if (matMP != null && matMaxMPImage != null)
                {
                    double ratio = 0;

                    try
                    {
                        //ratio = gImageProcess.TemplateMatchingRatio(matMaxMPImage.Clone(), matMP.Clone());
                        ratio = gImageProcess.SimpleColorMatching(matMaxMPImage, matMP);

                        if (ratio <= 0)
                            continue;

                        ratio = Math.Round(ratio, 2);

                        //System.Console.WriteLine("Ratio = {0}", ratio);
                        //Cv2.ImShow("1", matMaxMPImage);
                        //Cv2.ImShow("2", matMP);
                        //Cv2.WaitKey(0);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex);
                        continue;
                    }


                    lblMatchingRatioMP.Invoke(new Action(() =>
                    {
                        lblMatchingRatioMP.Text = ratio.ToString() + " %";
                    }));

                    double Per = 0;

                    trBarHP.Invoke(new Action(() =>
                    {
                        Per = double.Parse(trBarMP.Value.ToString()) * 10;
                    }));

                    if (chkRefillMP.Checked)
                    {
                        if (ratio < Per)
                        {
                            System.Console.WriteLine(ratio + " Search On");
                            bRefillMP = true;
                        }
                        else
                            bRefillMP = false;
                    }
                    else
                        bRefillMP = false;
                }

                Thread.Sleep(100);
            }
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
    }
}
