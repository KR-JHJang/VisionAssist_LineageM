using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VisionAssist.Classes
{
    public static class VisionRect
    {
        public enum ePosition
        {
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

            Attack,
            HP,
            MP,
            Location,
            Exp,
            
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
            pRect[(int)ePosition.Exp] = new Rect(0, 0, 0, 0);

            int startX = 352;
            int StartY = 500;
            int Width = 55;

            // 아이콘 위치 고정좌표
            pRect[(int)ePosition.Slot1] = new Rect(startX, StartY, Width, 50);
            pRect[(int)ePosition.Slot2] = new Rect((startX + (Width * 1)) + 2, StartY, Width, 50);
            pRect[(int)ePosition.Slot3] = new Rect((startX + (Width * 2)) + 4, StartY, Width, 50);
            pRect[(int)ePosition.Slot4] = new Rect((startX + (Width * 3)) + 8, StartY, Width, 50);
            pRect[(int)ePosition.Slot5] = new Rect((startX + (Width * 4)) + 12, StartY, Width, 50);
            pRect[(int)ePosition.Slot6] = new Rect((startX + (Width * 5)) + 4 + 68, StartY, Width, 50);
            pRect[(int)ePosition.Slot7] = new Rect((startX + (Width * 6)) + 8 + 68, StartY, Width, 50);
            pRect[(int)ePosition.Slot8] = new Rect((startX + (Width * 7)) + 12 + 68, StartY, Width, 50);
            pRect[(int)ePosition.Slot9] = new Rect((startX + (Width * 8)) + 16 + 68, StartY, Width, 50);
            pRect[(int)ePosition.Slot10] = new Rect((startX + (Width * 9)) + 20 + 68, StartY, Width, 50);

            pRect[(int)ePosition.Location] = new Rect(820, 234, 130, 20);
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

        public static Rect GetRect(int pos)
        {
            return pRect[pos];
        }        

        public static void DrawRectArea(Mat Data)
        {
            int startX = 352;
            int StartY = 500;
            int Width = 55;

            // 아이콘 위치 고정좌표
            pRect[(int)ePosition.Slot1] = new Rect(startX, StartY, Width, 50);
            pRect[(int)ePosition.Slot2] = new Rect((startX + (Width * 1)) + 2 ,      StartY, Width, 50);
            pRect[(int)ePosition.Slot3] = new Rect((startX + (Width * 2)) + 4 ,      StartY, Width, 50);
            pRect[(int)ePosition.Slot4] = new Rect((startX + (Width * 3)) + 8 ,      StartY, Width, 50);
            pRect[(int)ePosition.Slot5] = new Rect((startX + (Width * 4)) + 12 ,     StartY, Width, 50);
            pRect[(int)ePosition.Slot6] = new Rect((startX + (Width * 5)) + 4 + 68,  StartY, Width, 50);
            pRect[(int)ePosition.Slot7] = new Rect((startX + (Width * 6)) + 8 + 68,  StartY, Width, 50);
            pRect[(int)ePosition.Slot8] = new Rect((startX + (Width * 7)) + 12 + 68, StartY, Width, 50);
            pRect[(int)ePosition.Slot9] = new Rect((startX + (Width * 8)) + 16 + 68, StartY, Width, 50);
            pRect[(int)ePosition.Slot10] =new Rect((startX + (Width * 9)) + 20 + 68, StartY, Width, 50);

            pRect[(int)ePosition.Location] = new Rect(820, 233, 130, 21);

            for (int idx = 0; idx < (int)ePosition.Max; idx++)
            {
                if(pRect[idx] != null)
                {
                    Cv2.Rectangle(Data, pRect[idx], Scalar.Red, 1, LineTypes.Link8);
                }
            }
        }


    }

    public static class GlobalFunctions
    {
        public static int GetLongParameter(int low, int high)
        {
            return ((high << 16) | (low & 0xffff));
        }
    }
}
