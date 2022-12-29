using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionAssist.Classes
{
    public static class VisionRect
    {
        public enum ePosition
        {
            Attack,
            HP,
            MP,
            Location,
            Exp,
            Slot1,
            Slot2,
            Slot3,
            Slot4,
            Slot5,
            Slot6,
            Slot7,
            Slot8,
            Slot9,
            Slot10,
            Max
        }

        private static List<Rect> pRect = new List<Rect>();

        static VisionRect()
        {
            for (int idx = 0; idx < (int)ePosition.Max; idx++)
            {
                pRect.Add(new Rect(0, 0, 0, 0));
            }

            pRect[(int)ePosition.Attack] = new Rect(837, 399, 42, 47);
            pRect[(int)ePosition.HP] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.MP] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.Location] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.Exp] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.Slot1] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.Slot2] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.Slot3] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.Slot4] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.Slot5] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.Slot6] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.Slot7] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.Slot8] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.Slot9] = new Rect(0, 0, 0, 0);
            pRect[(int)ePosition.Slot10] = new Rect(0, 0, 0, 0);            
        }

        public static void Add(Rect rct)
        {
            pRect.Add(rct);
        }

        public static void Clear()
        {
            pRect.Clear();
        }

        public static void SetRect(Rect rct, ePosition pos)
        {
            pRect[(int)pos] = rct;
        }

        public static List<Rect> GetRect()
        {
            return pRect;
        }

        public static Rect GetRect(ePosition pos)
        {
            return pRect[(int)pos];
        }

        public static void DrawRectArea(Mat Data)
        {
            for(int idx = 0; idx < (int)ePosition.Max; idx++)
            {
                if(pRect[idx] != null)
                {
                    Cv2.Rectangle(Data, pRect[idx], Scalar.Red, 1, LineTypes.Link8);
                }
            }
        }
    }

    public class GlobalAccessFunctions
    {

    }
}
