using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionAssist.API;

namespace VisionAssist.Forms
{
    public partial class frmUserPosition : Form
    {
        private frmMain Handle;
        private List<RadioButton> gListRadioButtons;
        public frmUserPosition(frmMain handler)
        {
            InitializeComponent();
            Initialize();

            Handle = handler;
            GLOBAL.SetMousePositionMode = true;
        }

        private void Initialize()
        {
            gListRadioButtons = new List<RadioButton>();
            gListRadioButtons.Add(g1r1);
            gListRadioButtons.Add(g1r2);
            gListRadioButtons.Add(g1r3);
            gListRadioButtons.Add(g1r4);
            gListRadioButtons.Add(g1r5);
            gListRadioButtons.Add(g1r6);
            gListRadioButtons.Add(g1r7);
            gListRadioButtons.Add(g1r8);
            gListRadioButtons.Add(g1r9);
            gListRadioButtons.Add(g1r10);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GLOBAL.SetMousePositionMode = false;

            this.Close();
        }

        public void SetPosition()
        {
            string Path = Directory.GetCurrentDirectory() + "\\Param.ini";
            string X = Handle.tbxRealMouseX.Text;
            string Y = Handle.tbxRealMouseY.Text;

            for (int idx = 0; idx < gListRadioButtons.Count; idx++)
            {
                if(gListRadioButtons[idx].Checked)
                {
                    switch(idx)
                    {
                        case 0:
                            INIControl.IniWrite("MousePositionParameter", "M1X", X, Path);
                            INIControl.IniWrite("MousePositionParameter", "M1Y", Y, Path);
                            break;
                        case 1:
                            INIControl.IniWrite("MousePositionParameter", "M2X", X, Path);
                            INIControl.IniWrite("MousePositionParameter", "M2Y", Y, Path);
                            break;
                        case 2:
                            INIControl.IniWrite("MousePositionParameter", "M3X", X, Path);
                            INIControl.IniWrite("MousePositionParameter", "M3Y", Y, Path);
                            break;
                        case 3:
                            INIControl.IniWrite("MousePositionParameter", "M4X", X, Path);
                            INIControl.IniWrite("MousePositionParameter", "M4Y", Y, Path);
                            break;
                        case 4:
                            INIControl.IniWrite("MousePositionParameter", "M5X", X, Path);
                            INIControl.IniWrite("MousePositionParameter", "M5Y", Y, Path);
                            break;
                        case 5:
                            INIControl.IniWrite("MousePositionParameter", "M6X", X, Path);
                            INIControl.IniWrite("MousePositionParameter", "M6Y", Y, Path);
                            break;
                        case 6:
                            INIControl.IniWrite("MousePositionParameter", "M7X", X, Path);
                            INIControl.IniWrite("MousePositionParameter", "M7Y", Y, Path);
                            break;
                        case 7:
                            INIControl.IniWrite("MousePositionParameter", "M8X", X, Path);
                            INIControl.IniWrite("MousePositionParameter", "M8Y", Y, Path);
                            break;
                        case 8:
                            INIControl.IniWrite("MousePositionParameter", "M9X", X, Path);
                            INIControl.IniWrite("MousePositionParameter", "M9Y", Y, Path);
                            break;
                        case 9:
                            INIControl.IniWrite("MousePositionParameter", "M10X", X, Path);
                            INIControl.IniWrite("MousePositionParameter", "M10Y", Y, Path);
                            break;
                    }

                    MessageBox.Show("Message", "Set Complete");

                    GLOBAL.ReadSetupFile(Path);

                    break;
                }
            }
        }
    }
}
