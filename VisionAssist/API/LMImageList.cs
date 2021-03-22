using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionAssist.API
{
    public enum eLMImageList
    {
        Item_TeleportScroll = 0,


        GunnerSkill_StartIndex = 100,
        GunnerSkill_ManaChange,

        KnightSkill_StartIndex = 200,
        ElfSkill_StartIndex = 300,
        DarkElfSkill_StartIndex = 400,
        MageSkill_StartIndex = 500,
        WarriorSkill_StartIndex = 600,
        HolyKnightSkill_StartIndex = 700,
        DarkKnightSkill_StartIndex = 800,

        Status_StartIndex = 900,
        HP,
        MP,

        PKImage,
        MaxHP,
        MaxMP,
        Attack,

        SearchSkillArea,
        SearchItemArea,

        Status_End = 999,
        Max,
    }

    public class LMImageList : IDisposable
    {
        Mat[] ImageList;

        public LMImageList()
        { 
            ImageList = new Mat[(int)eLMImageList.Max];
        }

        public void InsertMat(Mat src, int num)
        {
            if(ImageList[num] != null)
                ImageList[num].Release();

            ImageList[num] = src;
        }
        public Mat GetMat(int num)
        {
            return ImageList[num];
        }

        protected virtual void Dispose(bool disposing)
        {
            foreach(var src in ImageList)
            {
                if(src != null)
                {
                    src.Release();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
