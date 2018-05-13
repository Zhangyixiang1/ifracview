using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Data_acquisition
{
    public partial class Frm_calibration : Form
    {
        string path = Application.StartupPath + "\\Config\\Calibration.xml";
        public Frm_calibration()
        {
            InitializeComponent();
        }

        private void Frm_calibration_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList list = doc.GetElementsByTagName("item");
            //第一个box
            foreach (Control ctr in groupBox1.Controls)
            {
                if (ctr.Tag == null) continue;
                switch (ctr.Tag.ToString())
                {
                    case ("最小值"):
                        {
                            ctr.Text = list[0].Attributes["最小值"].Value;
                            ; break;
                        }
                    case ("最大值"):
                        {
                            ctr.Text = list[0].Attributes["最大值"].Value;
                            ; break;
                        }
                    case ("范围下限"):
                        {
                            ctr.Text = list[0].Attributes["范围下限"].Value;
                            ; break;
                        }
                    case ("范围上限"):
                        {
                            ctr.Text = list[0].Attributes["范围上限"].Value;
                            ; break;
                        }
                }
            }
            //第二个box
            foreach (Control ctr in groupBox2.Controls)
            {
                if (ctr.Tag == null) continue;
                switch (ctr.Tag.ToString())
                {
                    case ("最小值"):
                        {
                            ctr.Text = list[1].Attributes["最小值"].Value;
                            ; break;
                        }
                    case ("最大值"):
                        {
                            ctr.Text = list[1].Attributes["最大值"].Value;
                            ; break;
                        }
                    case ("范围下限"):
                        {
                            ctr.Text = list[1].Attributes["范围下限"].Value;
                            ; break;
                        }
                    case ("范围上限"):
                        {
                            ctr.Text = list[1].Attributes["范围上限"].Value;
                            ; break;
                        }
                }
            }
            //第三个box
            foreach (Control ctr in groupBox3.Controls)
            {
                if (ctr.Tag == null) continue;
                switch (ctr.Tag.ToString())
                {
                    case ("最小值"):
                        {
                            ctr.Text = list[2].Attributes["最小值"].Value;
                            ; break;
                        }
                    case ("最大值"):
                        {
                            ctr.Text = list[2].Attributes["最大值"].Value;
                            ; break;
                        }
                    case ("范围下限"):
                        {
                            ctr.Text = list[2].Attributes["范围下限"].Value;
                            ; break;
                        }
                    case ("范围上限"):
                        {
                            ctr.Text = list[2].Attributes["范围上限"].Value;
                            ; break;
                        }
                }
            }
            //第四个box
            foreach (Control ctr in groupBox4.Controls)
            {
                if (ctr.Tag == null) continue;
                switch (ctr.Tag.ToString())
                {
                    case ("最小值"):
                        {
                            ctr.Text = list[3].Attributes["最小值"].Value;
                            ; break;
                        }
                    case ("最大值"):
                        {
                            ctr.Text = list[3].Attributes["最大值"].Value;
                            ; break;
                        }
                    case ("范围下限"):
                        {
                            ctr.Text = list[3].Attributes["范围下限"].Value;
                            ; break;
                        }
                    case ("范围上限"):
                        {
                            ctr.Text = list[3].Attributes["范围上限"].Value;
                            ; break;
                        }
                }
            }
            //第五个box
            foreach (Control ctr in groupBox5.Controls)
            {
                if (ctr.Tag == null) continue;
                switch (ctr.Tag.ToString())
                {
                    case ("最小值"):
                        {
                            ctr.Text = list[4].Attributes["最小值"].Value;
                            ; break;
                        }
                    case ("最大值"):
                        {
                            ctr.Text = list[4].Attributes["最大值"].Value;
                            ; break;
                        }
                    case ("范围下限"):
                        {
                            ctr.Text = list[4].Attributes["范围下限"].Value;
                            ; break;
                        }
                    case ("范围上限"):
                        {
                            ctr.Text = list[4].Attributes["范围上限"].Value;
                            ; break;
                        }
                }
            }
            //第六个box
            foreach (Control ctr in groupBox6.Controls)
            {
                if (ctr.Tag == null) continue;
                switch (ctr.Tag.ToString())
                {
                    case ("最小值"):
                        {
                            ctr.Text = list[5].Attributes["最小值"].Value;
                            ; break;
                        }
                    case ("最大值"):
                        {
                            ctr.Text = list[5].Attributes["最大值"].Value;
                            ; break;
                        }
                    case ("范围下限"):
                        {
                            ctr.Text = list[5].Attributes["范围下限"].Value;
                            ; break;
                        }
                    case ("范围上限"):
                        {
                            ctr.Text = list[5].Attributes["范围上限"].Value;
                            ; break;
                        }
                }
            }
            //第七个box
            foreach (Control ctr in groupBox7.Controls)
            {
                if (ctr.Tag == null) continue;
                switch (ctr.Tag.ToString())
                {
                    case ("最小值"):
                        {
                            ctr.Text = list[6].Attributes["最小值"].Value;
                            ; break;
                        }
                    case ("最大值"):
                        {
                            ctr.Text = list[6].Attributes["最大值"].Value;
                            ; break;
                        }
                    case ("范围下限"):
                        {
                            ctr.Text = list[6].Attributes["范围下限"].Value;
                            ; break;
                        }
                    case ("范围上限"):
                        {
                            ctr.Text = list[6].Attributes["范围上限"].Value;
                            ; break;
                        }
                }
            }
            //第八个box
            foreach (Control ctr in groupBox8.Controls)
            {
                if (ctr.Tag == null) continue;
                switch (ctr.Tag.ToString())
                {
                    case ("最小值"):
                        {
                            ctr.Text = list[7].Attributes["最小值"].Value;
                            ; break;
                        }
                    case ("最大值"):
                        {
                            ctr.Text = list[7].Attributes["最大值"].Value;
                            ; break;
                        }
                    case ("范围下限"):
                        {
                            ctr.Text = list[7].Attributes["范围下限"].Value;
                            ; break;
                        }
                    case ("范围上限"):
                        {
                            ctr.Text = list[7].Attributes["范围上限"].Value;
                            ; break;
                        }
                }
            }
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_temp1.Text = ((Form_Main.Array_daq[0] - Form_Main.daqb[0]) / Form_Main.daqk[0]).ToString();
            lbl_value1.Text = ((Form_Main.Array_daq[0] - Form_Main.daqb1[0]) / Form_Main.daqk1[0]).ToString();
            lbl_temp2.Text = ((Form_Main.Array_daq[1] - Form_Main.daqb[1]) / Form_Main.daqk[1]).ToString();
            lbl_value2.Text = ((Form_Main.Array_daq[1] - Form_Main.daqb1[1]) / Form_Main.daqk1[1]).ToString();
            lbl_temp3.Text = ((Form_Main.Array_daq[2] - Form_Main.daqb[2]) / Form_Main.daqk[2]).ToString();
            lbl_value3.Text = ((Form_Main.Array_daq[2] - Form_Main.daqb1[2]) / Form_Main.daqk1[2]).ToString();
            lbl_temp4.Text = ((Form_Main.Array_daq[3] - Form_Main.daqb[3]) / Form_Main.daqk[3]).ToString();
            lbl_value4.Text = ((Form_Main.Array_daq[3] - Form_Main.daqb1[3]) / Form_Main.daqk1[3]).ToString();
            lbl_temp5.Text = ((Form_Main.Array_daq[4] - Form_Main.daqb[4]) / Form_Main.daqk[4]).ToString();
            lbl_value5.Text = ((Form_Main.Array_daq[4] - Form_Main.daqb1[4]) / Form_Main.daqk1[4]).ToString();
            lbl_temp6.Text = ((Form_Main.Array_daq[5] - Form_Main.daqb[5]) / Form_Main.daqk[5]).ToString();
            lbl_value6.Text = ((Form_Main.Array_daq[5] - Form_Main.daqb1[5]) / Form_Main.daqk1[5]).ToString();
            lbl_temp7.Text = ((Form_Main.Array_daq[6] - Form_Main.daqb[6]) / Form_Main.daqk[6]).ToString();
            lbl_value7.Text = ((Form_Main.Array_daq[6] - Form_Main.daqb1[6]) / Form_Main.daqk1[6]).ToString();
            lbl_temp8.Text = ((Form_Main.Array_daq[7] - Form_Main.daqb[7]) / Form_Main.daqk[7]).ToString();
            lbl_value8.Text = ((Form_Main.Array_daq[7] - Form_Main.daqb1[7]) / Form_Main.daqk1[7]).ToString();
        }
    }
}
