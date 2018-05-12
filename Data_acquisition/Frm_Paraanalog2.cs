using Data_acquisition.Ctrl;
using Data_acquisiton;
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
    public partial class Frm_Paraanalog2 : Form
    {
        public Frm_Paraanalog2()
        {
            InitializeComponent();
        }



        private void Frm_Paraanalog2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Location = new Point(7680, 0); this.BringToFront();
            ((Frm_Window)Application.OpenForms["Frm_Window"]).Visible = false;
        }

        private void Frm_Paraanalog2_Load(object sender, EventArgs e)
        {

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Parashownew)
                {
                    Parashownew ctr2 = ctrl as Parashownew;
                    ctr2.timer1.Enabled = true;
                }
                if (ctrl is Gauge)
                {
                    Gauge ctr2 = ctrl as Gauge;
                    ctr2.timer1.Enabled = true;
                }

            }
            gauge0.timer1.Enabled = true;
            xml_load();
            //语言切换
            if (Form_Main.lan == "Chinese")
            {
                MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Paraanalog2"], "Chinese");
                ((Frm_Paraanalog2)Application.OpenForms["Frm_Paraanalog2"]).gauge2.label1.Text = "井口套压";
                ((Frm_Paraanalog2)Application.OpenForms["Frm_Paraanalog2"]).gauge0.label4.Text = "井口油压";
                ((Frm_Paraanalog2)Application.OpenForms["Frm_Paraanalog2"]).gauge1.label1.Text = "井口排出流量";
            }
            else
            {
                MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Paraanalog2"], "English");
                ((Frm_Paraanalog2)Application.OpenForms["Frm_Paraanalog2"]).gauge2.label1.Text = "Casing Pressure";
                ((Frm_Paraanalog2)Application.OpenForms["Frm_Paraanalog2"]).gauge0.label4.Text = "Tubing Pressure";
                ((Frm_Paraanalog2)Application.OpenForms["Frm_Paraanalog2"]).gauge1.label1.Text = "Discharge Rate";
            }
        }

        private void xml_load()
        {
            try
            {
                string path = Application.StartupPath + "\\Config\\preference.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode root = doc.DocumentElement;
                //现读取paraLine控件的信息
                XmlNodeList nodeList = root.SelectNodes("Form[Name='Frm_Paraanalog2']//Controlsshow//Control");

                //1115新增,parashow控件
                foreach (Control ctr in this.Controls)
                {
                    if (ctr is Parashownew)
                    {
                        Parashownew ctr2 = ctr as Parashownew;
                        foreach (XmlNode node in nodeList)
                        {
                            if (ctr2.Name == node.SelectSingleNode("@name").InnerText)
                            {
                                ctr2.Tagname = node.SelectSingleNode("@tagname").InnerText;
                                ctr2.Tagname_EN = node.SelectSingleNode("@tagname_en").InnerText;
                                ctr2.Unit = node.SelectSingleNode("@unit").InnerText;
                                ctr2.Tag = node.SelectSingleNode("@index").InnerText;
                                ctr2.Color = Comm.ReadColor.getcolor(node.SelectSingleNode("@color").InnerText);
                                if (Form_Main.Unit == 1) ctr2.Unit = Form_Main.factor_unit[Convert.ToInt16(ctr2.Tag)];
                                ctr2.refresh();
                            }

                        }
                    }

                }
                //1115新增，gauge控件
                nodeList = root.SelectNodes("Form[Name='Frm_Paraanalog2']//Controlsgauge//Control");
                foreach (Control ctr in this.Controls)
                {
                    if (ctr is Gauge)
                    {
                        Gauge ctr2 = ctr as Gauge;
                        foreach (XmlNode node in nodeList)
                        {
                            if (ctr2.Name == node.SelectSingleNode("@name").InnerText)
                            {
                                ctr2.Tagname = node.SelectSingleNode("@tagname").InnerText;
                                ctr2.Unit = node.SelectSingleNode("@unit").InnerText;
                                ctr2.Tag = node.SelectSingleNode("@index").InnerText;
                                ctr2.Min = node.SelectSingleNode("@min").InnerText;
                                ctr2.Max = node.SelectSingleNode("@max").InnerText;
                                if (Form_Main.Unit == 1) ctr2.Unit = Form_Main.factor_unit[Convert.ToInt16(ctr2.Tag)];
                                ctr2.refresh();
                            }
                            //初始化大表盘的参数
                            if (node.SelectSingleNode("@name").InnerText == "gauge0")
                            {
                                gauge0.Tagname = node.SelectSingleNode("@tagname").InnerText;
                                gauge0.Unit = node.SelectSingleNode("@unit").InnerText;
                                gauge0.Tag = node.SelectSingleNode("@index").InnerText;
                                gauge0.Min = node.SelectSingleNode("@min").InnerText;
                                gauge0.Max = node.SelectSingleNode("@max").InnerText;
                                if (Form_Main.Unit == 1) gauge0.Unit = Form_Main.factor_unit[Convert.ToInt16(gauge0.Tag)];
                                gauge0.refresh();

                            }
                        }
                    }


                }


                //foreach (Control ctrl in this.tabControl1.Controls)
                //{
                //    if (ctrl is TabPage)
                //    {
                //        TabPage ctrl2 = ctrl as TabPage;
                //        foreach (Control ctr in ctrl2.Controls)
                //        {
                //            if (ctr is Parashow)
                //            {
                //                Parashow ctr2 = ctr as Parashow;
                //                foreach (XmlNode node in nodeList)
                //                {
                //                    if (ctr2.Name == node.SelectSingleNode("@name").InnerText)
                //                    {
                //                        ctr2.Tagname = node.SelectSingleNode("@tagname").InnerText;
                //                        ctr2.Unit = node.SelectSingleNode("@unit").InnerText;
                //                        ctr2.Tag = node.SelectSingleNode("@index").InnerText;
                //                        ctr2.refresh();
                //                    }

                //                }
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }




        }
    }
}
