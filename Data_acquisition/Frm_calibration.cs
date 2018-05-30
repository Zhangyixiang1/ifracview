using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TwinCAT.Ads;

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

            //XmlDocument doc = new XmlDocument();
            //doc.Load(path);
            //XmlNodeList list = doc.GetElementsByTagName("item");
            ////第一个box
            //foreach (Control ctr in groupBox1.Controls)
            //{
            //    if (ctr.Tag == null) continue;
            //    switch (ctr.Tag.ToString())
            //    {
            //        case ("最小值"):
            //            {
            //                ctr.Text = list[0].Attributes["最小值"].Value;
            //                ; break;
            //            }
            //        case ("最大值"):
            //            {
            //                ctr.Text = list[0].Attributes["最大值"].Value;
            //                ; break;
            //            }
            //        case ("范围下限"):
            //            {
            //                ctr.Text = list[0].Attributes["范围下限"].Value;
            //                ; break;
            //            }
            //        case ("范围上限"):
            //            {
            //                ctr.Text = list[0].Attributes["范围上限"].Value;
            //                ; break;
            //            }
            //    }
            //}

            //0529修改，从beckoff读取量程的值
            foreach (Control ctr in this.Controls)
            {
                if (ctr is GroupBox)
                {
                    GroupBox grp = ctr as GroupBox;
                    int index1 = grp.TabIndex;
                    foreach (Control ctr_ in grp.Controls)
                    {
                        if (ctr_ is TextBox)
                        {
                            TextBox txb = ctr_ as TextBox;
                            int index2 = txb.TabIndex;
                            txb.Text=Form_Main.Array_daq[index1,index2].ToString();
                        }
                    }

                }

            }

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //0529修改，从beckoff读取实时值
            foreach (Control ctr in this.Controls)
            {
                if (ctr is GroupBox)
                {
                    GroupBox grp = ctr as GroupBox;
                    int index1 = grp.TabIndex;
                    foreach (Control ctr_ in grp.Controls)
                    {
                        if (ctr_ is Label)
                        {
                            Label lbl = ctr_ as Label;
                            int index2 = lbl.TabIndex;
                            if (index2 == 4 || index2 == 5)
                            lbl.Text = Form_Main.Array_daq[index1, index2].ToString();
                        }
                    }

                }

            }
            
            
            
            //lbl_temp1.Text = ((Form_Main.Array_daq[0] - Form_Main.daqb[0]) / Form_Main.daqk[0]).ToString();
            //lbl_value1.Text = ((Form_Main.Array_daq[0] - Form_Main.daqb1[0]) / Form_Main.daqk1[0]).ToString();
            //lbl_temp2.Text = ((Form_Main.Array_daq[1] - Form_Main.daqb[1]) / Form_Main.daqk[1]).ToString();
            //lbl_value2.Text = ((Form_Main.Array_daq[1] - Form_Main.daqb1[1]) / Form_Main.daqk1[1]).ToString();
            //lbl_temp3.Text = ((Form_Main.Array_daq[2] - Form_Main.daqb[2]) / Form_Main.daqk[2]).ToString();
            //lbl_value3.Text = ((Form_Main.Array_daq[2] - Form_Main.daqb1[2]) / Form_Main.daqk1[2]).ToString();
            //lbl_temp4.Text = ((Form_Main.Array_daq[3] - Form_Main.daqb[3]) / Form_Main.daqk[3]).ToString();
            //lbl_value4.Text = ((Form_Main.Array_daq[3] - Form_Main.daqb1[3]) / Form_Main.daqk1[3]).ToString();
            //lbl_temp5.Text = ((Form_Main.Array_daq[4] - Form_Main.daqb[4]) / Form_Main.daqk[4]).ToString();
            //lbl_value5.Text = ((Form_Main.Array_daq[4] - Form_Main.daqb1[4]) / Form_Main.daqk1[4]).ToString();
            //lbl_temp6.Text = ((Form_Main.Array_daq[5] - Form_Main.daqb[5]) / Form_Main.daqk[5]).ToString();
            //lbl_value6.Text = ((Form_Main.Array_daq[5] - Form_Main.daqb1[5]) / Form_Main.daqk1[5]).ToString();
            //lbl_temp7.Text = ((Form_Main.Array_daq[6] - Form_Main.daqb[6]) / Form_Main.daqk[6]).ToString();
            //lbl_value7.Text = ((Form_Main.Array_daq[6] - Form_Main.daqb1[6]) / Form_Main.daqk1[6]).ToString();
            //lbl_temp8.Text = ((Form_Main.Array_daq[7] - Form_Main.daqb[7]) / Form_Main.daqk[7]).ToString();
            //lbl_value8.Text = ((Form_Main.Array_daq[7] - Form_Main.daqb1[7]) / Form_Main.daqk1[7]).ToString();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //现将所有值暂存在一个2维数组
            float[,] temparray = new float[10, 6];
            foreach (Control ctr in this.Controls)
            {
                if (ctr is GroupBox)
                {
                    GroupBox grp = ctr as GroupBox;
                    int index1 = grp.TabIndex;
                    foreach (Control ctr_ in grp.Controls)
                    {
                        if (ctr_ is TextBox)
                        {
                            TextBox txb = ctr_ as TextBox;
                            int index2 = txb.TabIndex;
                            temparray[index1, index2] = Convert.ToSingle(txb.Text);
                        }
                        if (ctr_ is Label) {
                            Label lbl = ctr_ as Label;
                            int index3 = lbl.TabIndex;
                            if(index3==4||index3==5)
                            temparray[index1, index3] = Convert.ToSingle(lbl.Text);
                        
                        }
                    }

                }

            }

            //将数组写到beckoff
            try
            {
               
                if (Form_Main.tcClient.IsConnected)
                {
                    AdsStream dataStream = new AdsStream(2 * 60);
                    BinaryWriter binwrite = new BinaryWriter(dataStream);
                    dataStream.Position = 0;

                    for (int i = 0; i < 60; i++)
                    {
                        binwrite.Write((float)temparray.GetValue(i)); 

                    }
                    Form_Main.tcClient.Write(Form_Main.tcHandle,dataStream);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
           




          
        }
    }
}
