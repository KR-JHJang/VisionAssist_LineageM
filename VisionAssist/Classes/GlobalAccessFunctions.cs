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
            Max
        }

        private static List<Rect> pRect = new List<Rect>();

        static VisionRect()
        {
            for (int idx = 0; idx < (int)ePosition.Max; idx++)
            {
                pRect.Add(new Rect(0, 0, 0, 0));
            }
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
