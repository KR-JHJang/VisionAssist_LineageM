using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VisionAssist.API
{
    public static class INIControl
    {
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            string section,
            string key,
            string def,
            StringBuilder retVal,
            int size,
            string filePath);

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(
            string section,
            string key,
            string val,
            string filePath);

        public static string Read(string Section, string Key, string Path)
        {
            StringBuilder strValue = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "0", strValue, 255, Path);
            return strValue.ToString().Trim();
        }

        public static string ReadNotNull(string Section, string Key, string Path)
        {
            StringBuilder strValue = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", strValue, 255, Path);
            return strValue.ToString().Trim();
        }

        public static void Write(string Section, string Key, string Value, string Path)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }
    }


}
