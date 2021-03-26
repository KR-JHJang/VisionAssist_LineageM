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

            RunThread();
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



        public void SetHPImagePos(Mat src)
        {
            matHP?.Release();
            matHP = src;

            OpenCvSharp.Size size = new OpenCvSharp.Size(
            picboxHP.Size.Width,
            picboxHP.Size.Height);

            Cv2.Resize(matHP, matHP, size, 0, 0, InterpolationFlags.Cubic);

            gImageProcess.ConvertColorNormalize(matHP, 140, 255, 2);

            RefreshHP();
            //SetImageToArray(matArrHP, matHP);

            HP_Work();

        }
      
        public void SetMPImagePos(Mat src)
        {
            matMP?.Release();
            matMP = src;
            
            OpenCvSharp.Size size = new OpenCvSharp.Size(
            picboxMP.Size.Width,
            picboxMP.Size.Height);

            Cv2.Resize(matMP, matMP, size, 0, 0, InterpolationFlags.Cubic);

            gImageProcess.ConvertColorNormalize(matMP,
                102,
                108);

            RefreshMP();

            if (MP_Work())
            {
                SearchSkillPos();
            }
        }

        public void SetSearchSkillAreaImage(Mat src, Rect Area)
        {
            matSearchSkillArea?.Release();

            matSearchSkillArea = src;
            matSearchSkillAreaStartX = Area.X;
            matSearchSkillAreaStartY = Area.Y;
        }

        public void SetSearchItemAreaImage(Mat src, Rect Area, int idx)
        {
            gLMImageList.InsertMat(src, idx);

            if (matSearchItemArea != null)
                matSearchItemArea.Release();

            matSearchItemArea = src;
            matSearchItemAreaStartX = Area.X;
            matSearchItemAreaStartY = Area.Y;
        }

        public void SetAttackImagePos(Mat src)
        {
            matAttack?.Release();
            matAttack = src;

            OpenCvSharp.Size size = new OpenCvSharp.Size(
            picboxUserAttack.Size.Width,
            picboxUserAttack.Size.Height);

            Cv2.Resize(matAttack, matAttack, size, 0, 0, InterpolationFlags.Cubic);

            //gImageProcess.ConvertRGB2GRAY(matAttack);

            RefreshPicBox(matAttack.Clone(), picboxUserAttack);
            if (EvadeAttack())
            {
                ExcuteEvade();
            }
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

        private void trBarHP_Scroll(object sender, EventArgs e)
        {
            ttHP.SetToolTip(trBarHP, (trBarHP.Value * 10) + "%".ToString());
        }

        private void trBarMP_Scroll(object sender, EventArgs e)
        {
            ttMP.SetToolTip(trBarMP, (trBarMP.Value * 10) + "%".ToString());
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
                if (picboxHP.Image != null)
                {
                    picboxHP.Image.Dispose();
                }

                picboxHP.Image = matHP.ToBitmap();
            }
        }

        private void RefreshMP()
        {
            if (!matMP.IsDisposed)
            {
                if (picboxMP.Image != null)
                {
                    picboxMP.Image.Dispose();
                }

                picboxMP.Image = matMP.ToBitmap();
            }
            else
                return;
        }

        private void RefreshPicBox(Mat src, PictureBox target)
        {
            if (!src.IsDisposed)
            {
                if (target.Image != null)
                {
                    target.Image.Dispose();
                }

                target.Image = src.ToBitmap();
                src.Release();
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
                VecLoc4d result = gImageProcess.TemplateMatchingGetAllData(matPKImage.Clone(), matAttack.Clone());

                lblMatchingRatioEvade.Invoke(new Action(() =>
                {
                    lblMatchingRatioEvade.Text = result.maxval.ToString() + " %";
                }));

                if (chkUserAttackEvade.Checked)
                {
                    if (result.maxval >= 0.66)
                    {
                        bEvadeAttack = true;
                    }
                    else
                        bEvadeAttack = false;
                }
                else
                    bEvadeAttack = false;

                result.retMat.Release();
            //}
            //else
            //{
            //    return;
            //}

            return bEvadeAttack;
        }

        private void bgwEvadeAttack_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                if (matAttack == null || matPKImage == null)
                    continue;

                if (matPKImage.IsDisposed || matAttack.IsDisposed)
                    continue;

                if (matAttack != null && matPKImage != null)
                {
                    VecLoc4d result = gImageProcess.TemplateMatchingGetAllData(matPKImage.Clone(), matAttack.Clone());

                    lblMatchingRatioEvade.Invoke(new Action(()=>
                    {
                        lblMatchingRatioEvade.Text = result.maxval.ToString() + " %";
                    }));

                    if(chkUserAttackEvade.Checked)
                    {
                        if (result.maxval >= 0.66)
                        {
                            bEvadeAttack = true;
                        }
                        else
                            bEvadeAttack = false;
                    }
                    else
                        bEvadeAttack = false;

                    if (bEvadeAttack)
                    {
                        ExcuteEvade();
                    }

                    result.retMat.Release();
                }
                
                Thread.Sleep(100);
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void ExcuteEvade()
        {
            VecLoc4d result = gImageProcess.TemplateMatchingGetAllData(
                gLMImageList.GetMat((int)eLMImageList.SearchItemArea).Clone(),
                gLMImageList.GetMat((int)eLMImageList.Item_TeleportScroll).Clone());

            Random r = new Random();

            var threshold = 0.44;
            System.Console.WriteLine("Excute : " + result.maxval);

            if (result.maxval >= threshold)
            {
                int X = (int)(result.maxloc.X + matSearchItemAreaStartX) + 
                    (gLMImageList.GetMat((int)eLMImageList.Item_TeleportScroll).Width / 2);
                int Y = (int)(result.maxloc.Y + matSearchItemAreaStartY) + 
                    (gLMImageList.GetMat((int)eLMImageList.Item_TeleportScroll).Height / 2);

                X = (int)GLOBAL.hfrmVision.VisionMoveScalingWidth(r.Next(X - 5, X + 5));
                Y = (int)GLOBAL.hfrmVision.VisionMoveScalingHeight(r.Next(Y - 5, Y + 5));

                int longParameter = GLOBAL.hfrmVision.GetLongParameter(X, Y);

                //Thread.Sleep((r.Next(2000, 3000)));

                GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONDOWN, 0, longParameter);
                GLOBAL.SendMessage(GLOBAL.TargetHandle, GLOBAL.WM_LBUTTONUP, 0, longParameter);

                // 서치된 부분을 빨간 테두리로
                Rect rect = new Rect(result.maxloc.X, result.maxloc.Y, result.retMat.Width, result.retMat.Height);
                Cv2.Rectangle(result.retMat, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

                lblMatchingRatioExcute.Invoke(new Action(() =>
                {
                    lblMatchingRatioExcute.Text = result.maxval.ToString();
                }));

                if (picEvadeTest.Image != null)
                    picEvadeTest.Image.Dispose();

                Cv2.Resize(result.retMat, result.retMat, new Size(picEvadeTest.Width, picEvadeTest.Height), 0,0,InterpolationFlags.Cubic);

                picEvadeTest.Image = result.retMat.ToBitmap();

                //표시
                //Cv2.ImShow("template1_show", result.retMat);
                //Cv2.WaitKey(0);
            }
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

        private void HP_Work()
        {
            if (matHP != null && matMaxHPImage != null)
            {
                double ratio = 0;

                try
                {
                    //ratio = gImageProcess.TemplateMatchingRatio(matMaxMPImage.Clone(), matMP.Clone());
                    ratio = gImageProcess.SimpleColorMatching(matMaxHPImage.Clone(), matHP.Clone(), 2);

                    if (ratio <= 0)
                        return;
                        
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

                if (chkRefillMP.Checked)
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
                    bRefillMP = false;
            }
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


                    lblMatchingRatioMP.Invoke(new Action(() =>
                    {
                        lblMatchingRatioHP.Text = ratio.ToString() + " %";
                    }));

                    double Per = 0;

                    trBarHP.Invoke(new Action(()=>
                    {
                        Per = double.Parse(trBarHP.Value.ToString()) * 10;
                    }));

                    if (chkRefillMP.Checked)
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
                        bRefillMP = false;
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
    }
}
