using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionAssist.Forms.GuildMark
{    
    internal struct ST_GROUP
    {
        public string ImagePath;
        public bool Use;
        public Mat im;
    }

    internal class Functions
    { 
        // 현재는 20개까지만 관리 할 예정
        private const int gGroupCount = 20;
        internal ST_GROUP[] stGroup;

        public Functions()
        {
            stGroup = new ST_GROUP[gGroupCount];
        }
    }
}
