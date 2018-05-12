using Data_acquisition.Ctrl;
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
    public partial class Frm_Paraanalog : Form
    {
        public Frm_Paraanalog()
        {
            InitializeComponent();
        }



        private void Frm_Paraanalog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void Frm_Paraanalog_Load(object sender, EventArgs e)
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
            gauge0.timer1.Enabled=true;
            xml_load();
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
                XmlNodeList nodeList = root.SelectNodes("Form[Name='Frm_Paraanalog']//Controlsshow//Control");

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
                                ctr2.Unit = node.SelectSingleNode("@unit").InnerText;
                                ctr2.Tag = node.SelectSingleNode("@index").InnerText;
                                ctr2.Color=Comm.ReadColor.getcolor(node.SelectSingleNode("@color").InnerText);
                                ctr2.refresh();
                            }

                        }
                    }

                }
                //1115新增，gauge控件
                nodeList = root.SelectNodes("Form[Name='Frm_Paraanalog']//Controlsgauge//Control");
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
                                ctr2.refresh();
                            }
                          //初始化大表盘的参数
                          if(node.SelectSingleNode("@name").InnerText=="gauge0"){
                              gauge0.Tagname = node.SelectSingleNode("@tagname").InnerText;
                              gauge0.Unit = node.SelectSingleNode("@unit").InnerText;
                              gauge0.Tag = node.SelectSingleNode("@index").InnerText;
                              gauge0.Min = node.SelectSingleNode("@min").InnerText;
                              gauge0.Max = node.SelectSingleNode("@max").InnerText;
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
