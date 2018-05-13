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
        }
    }
}
