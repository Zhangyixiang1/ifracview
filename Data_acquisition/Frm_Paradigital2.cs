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
    public partial class Frm_Paradigital2 : Form
    {
        public Frm_Paradigital2()
        {
            InitializeComponent();
        }



        private void Frm_Paradigital2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Location = new Point(5760, 0); this.BringToFront();
            ((Frm_Window)Application.OpenForms["Frm_Window"]).Visible = false;
        }

        private void parashow4_Load(object sender, EventArgs e)
        {

        }

        private void Frm_Paradigital2_Load(object sender, EventArgs e)
        {
            xml_load();

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Parashownew)
                {
                    Parashownew ctr2 = ctrl as Parashownew;
                    ctr2.timer1.Enabled = true;
                }
            }
            //语言切换
            MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Paradigital2"],Form_Main.lan);
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
                XmlNodeList nodeList = root.SelectNodes("Form[Name='Frm_Paradigital2']//Controlsshow//Control");

                //1115新增
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
