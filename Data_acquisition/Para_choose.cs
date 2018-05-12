using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Data_acquisition.Ctrl;
using Data_acquisiton;
namespace Data_acquisition
{
    public partial class Para_choose : Form
    {
        public ParaLine ctr_line;
        public Parashow ctr_show;
        public Parashownew ctr_show2;
        public Gauge ctr_gauge;
        public Gauge_mid ctr_gaugemid;
        string Frm_name;
        Button btn_s; string tag_num;
        Color tag_color;
        public Para_choose(ParaLine ctr, string name)
        {
            Frm_name = name;
            this.ctr_line = ctr;
            tag_num = ctr.Tag.ToString();
            tag_color = ctr.Color;
            InitializeComponent();
            txb_max.Text = ctr.Max;
            txb_min.Text = ctr.Min;
            //如果已经开始施工，不能变换曲线参数
            if (Form_Main.run)
            {
                tabControl1.Enabled = false;
            }
            //如果是打印界面，开放选择接口
            if (Frm_name == "Frm_print") tabControl1.Enabled = true;
        }
        public Para_choose(Parashow ctr, string name)
        {
            Frm_name = name;
            this.ctr_show = ctr;
            tag_num = ctr.Tag.ToString();
            tag_color = ctr.Color;
            InitializeComponent();
            //如果是数字显示控件，不开放上下限设置
            txb_max.Enabled = false; txb_min.Enabled = false;
            btn_clear.Visible = true;
        }
        public Para_choose(Parashownew ctr, string name)
        {
            Frm_name = name;
            this.ctr_show2 = ctr;
            tag_num = ctr.Tag.ToString();
            tag_color = ctr.Color;
            InitializeComponent();
            //如果是数字显示控件，不开放上下限设置
            txb_max.Enabled = false; txb_min.Enabled = false;

        }
        public Para_choose(Gauge ctr, string name)
        {
            Frm_name = name;
            this.ctr_gauge = ctr;
            tag_num = ctr_gauge.Tag.ToString();
            InitializeComponent();
            //如果是数字显示控件，不开放颜色选取
            btn_color.Visible = false;
            txb_max.Text = ctr.Max;
            txb_min.Text = ctr.Min;
        }
        public Para_choose(Gauge_mid ctr, string name)
        {
            Frm_name = name;
            this.ctr_gaugemid = ctr;
            tag_num = ctr_gaugemid.Tag.ToString();
            InitializeComponent();
            //如果是数字显示控件，不开放颜色选取
            btn_color.Visible = false;
            txb_max.Text = ctr.Max;
            txb_min.Text = ctr.Min;
        }



        private void Para_choose_Load(object sender, EventArgs e)
        {

            btn_color.BackColor = tag_color;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.WorkerSupportsCancellation = true;    //声明是否支持取消线程
            backgroundWorker1.RunWorkerAsync(); //开始
            //语言切换
            if (Form_Main.lan == "Chinese") MultiLanguage.LoadLanguage(this, "Chinese");
            else if (Form_Main.lan == "English") MultiLanguage.LoadLanguage(this, "English");

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int x = 6, y = 6;

            //从配置文件中读取通道标签
            string path = Application.StartupPath + "\\Config\\" + "Para.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList list = xml.GetElementsByTagName("item");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNode node = list.Item(i);
                string Index = node.Attributes["序号"].Value;
                string Name = node.Attributes["中文名称"].Value;
                string Name_en = node.Attributes["英文名称"].Value;
                string Unit_en = node.Attributes["英制单位"].Value;
                string Unit_me = node.Attributes["公制单位"].Value;
                string max = node.Attributes["最大值"].Value;
                string min = node.Attributes["最小值"].Value;
                Button btn = new Button();
                btn.Tag = Index + "," + Unit_en + "," + Unit_me + "," + max + "," + min + "," + Name + "," + Name_en;
                if (Form_Main.lan == "Chinese")
                    btn.Text = Name;
                else if (Form_Main.lan == "English")
                    btn.Text = Name_en;
                btn.Size = new Size(120, 38);
                btn.Click += btnClick;
                //数据采集卡
                if (i >= 0 && i < 30)
                {
                    btn.Location = new Point(x + 131 * (i % 4), y + 45 * (i / 4));
                    if (tabPage1.InvokeRequired)
                    {

                        tabPage1.Invoke(new Action(() => { this.tabPage1.Controls.Add(btn); }));
                    }
                }
                //混砂车
                if (i >= 30 && i < 100)
                {
                    btn.Location = new Point(x + 131 * ((i - 30) % 4), y + 45 * ((i - 30) / 4));
                    if (tabPage2.InvokeRequired)
                    {
                        tabPage2.Invoke(new Action(() => { this.tabPage2.Controls.Add(btn); }));
                    }
                }
                //传统压裂泵
                if (i >= 150 && i < 200)
                {
                    btn.Location = new Point(x + 131 * ((i - 150) % 4), y + 45 * ((i - 150) / 4));
                    if (tabPage4.InvokeRequired)
                    {
                        tabPage4.Invoke(new Action(() => { this.tabPage4.Controls.Add(btn); }));
                    }
                }
                //电动压裂泵
                if (i >= 100 && i < 150)
                {
                    btn.Location = new Point(x + 131 * ((i - 100) % 4), y + 45 * ((i - 100) / 4));
                    if (tabPage3.InvokeRequired)
                    {
                        tabPage3.Invoke(new Action(() => { this.tabPage3.Controls.Add(btn); }));
                    }
                }


                if (tag_num == Index)
                {
                    btn_s = btn; btn_s.BackColor = Color.Gray;
                }
            }

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            backgroundWorker1.CancelAsync();
            if (btn_s != null)
            {
                string[] message = btn_s.Tag.ToString().Split(',');
                // txb_max.Text = message[3]; txb_min.Text = message[4];
            }
        }
        private void btnClick(object sender, EventArgs e)
        {
            if (btn_s != null) btn_s.BackColor = Color.Transparent;
            btn_s = sender as Button;
            ((Button)sender).BackColor = Color.Gray;
            string[] message = btn_s.Tag.ToString().Split(',');
            txb_max.Text = message[3]; txb_min.Text = message[4];
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string[] message = btn_s.Tag.ToString().Split(',');
            if (btn_s != null)
            {
                if (ctr_line != null)
                {
                    ctr_line.Tagname = message[5];
                    ctr_line.Tagname_EN = message[6];
                    ctr_line.Tag = message[0];
                    ctr_line.Unit = message[2];
                    ctr_line.Max = txb_max.Text;
                    ctr_line.Min = txb_min.Text;
                    ctr_line.Color = tag_color;
                    //保存修改到偏好配置文件

                    string path = Application.StartupPath + "\\Config\\preference.xml";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode root = doc.DocumentElement;
                    XmlNodeList nodeList = root.SelectNodes("Form[Name='" + Frm_name + "']//Controlsline//Control");


                    foreach (XmlNode node in nodeList)
                    {
                        if (ctr_line.Name == node.SelectSingleNode("@name").InnerText)
                        {
                            node.SelectSingleNode("@tagname").InnerText = ctr_line.Tagname;
                            node.SelectSingleNode("@tagname_en").InnerText = ctr_line.Tagname_EN;
                            node.SelectSingleNode("@min").InnerText = ctr_line.Min;
                            node.SelectSingleNode("@max").InnerText = ctr_line.Max;
                            node.SelectSingleNode("@unit").InnerText = ctr_line.Unit;
                            node.SelectSingleNode("@index").InnerText = ctr_line.Tag.ToString();
                            node.SelectSingleNode("@color").InnerText = ctr_line.Color.R.ToString() + "," +
                           ctr_line.Color.G.ToString() + "," + ctr_line.Color.B.ToString();

                        }

                    }
                    doc.Save(path);

                    ctr_line.refresh();
                    switch (Frm_name)
                    {
                        case "Form_Main": ((Form_Main)Application.OpenForms[Frm_name]).trend_refresh(ctr_line.Name, Convert.ToInt16(ctr_line.Tag)); break;
                        case "Frm_Realtrend": ((Frm_Realtrend)Application.OpenForms[Frm_name]).trend_refresh(ctr_line.Name); break;
                        case "Frm_Realtrend2": ((Frm_Realtrend2)Application.OpenForms[Frm_name]).trend_refresh(ctr_line.Name); break;
                        case "Frm_print":
                            {
                                ((Frm_print)Application.OpenForms[Frm_name]).trend_refresh(ctr_line.Name);
                                ((Frm_print)Application.OpenForms[Frm_name]).btn_refresh.PerformClick();
                                break;
                            }
                    }

                }
                if (ctr_show != null)
                {
                    ctr_show.Tagname = message[5];
                    ctr_show.Tagname_EN = message[6];
                    ctr_show.Tag = message[0];
                    ctr_show.Unit = message[2];
                    ctr_show.Color = tag_color;
                    //保存修改到偏好配置文件

                    string path = Application.StartupPath + "\\Config\\preference.xml";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode root = doc.DocumentElement;
                    XmlNodeList nodeList = root.SelectNodes("Form[Name='" + Frm_name + "']//Controlsshow//Control");


                    foreach (XmlNode node in nodeList)
                    {
                        if (ctr_show.Name == node.SelectSingleNode("@name").InnerText)
                        {
                            node.SelectSingleNode("@tagname").InnerText = ctr_show.Tagname;
                            node.SelectSingleNode("@tagname_en").InnerText = ctr_show.Tagname_EN;
                            node.SelectSingleNode("@unit").InnerText = ctr_show.Unit;
                            node.SelectSingleNode("@index").InnerText = ctr_show.Tag.ToString();
                            node.SelectSingleNode("@color").InnerText = ctr_show.Color.R.ToString() + "," +
                            ctr_show.Color.G.ToString() + "," + ctr_show.Color.B.ToString();
                        }

                    }
                    doc.Save(path);
                    ctr_show.label1.Visible = true;
                    ctr_show.label2.Visible = true;
                    ctr_show.label3.Visible = true;
                    ctr_show.refresh();
                }

                if (ctr_show2 != null)
                {
                    ctr_show2.Tagname = message[5];
                    ctr_show2.Tagname_EN = message[6];
                    ctr_show2.Tag = message[0];
                    ctr_show2.Unit = message[2];
                    ctr_show2.Color = tag_color;
                    //保存修改到偏好配置文件

                    string path = Application.StartupPath + "\\Config\\preference.xml";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode root = doc.DocumentElement;
                    XmlNodeList nodeList = root.SelectNodes("Form[Name='" + Frm_name + "']//Controlsshow//Control");


                    foreach (XmlNode node in nodeList)
                    {
                        if (ctr_show2.Name == node.SelectSingleNode("@name").InnerText)
                        {
                            node.SelectSingleNode("@tagname").InnerText = ctr_show2.Tagname;
                            node.SelectSingleNode("@tagname_en").InnerText = ctr_show2.Tagname_EN;
                            node.SelectSingleNode("@unit").InnerText = ctr_show2.Unit;
                            node.SelectSingleNode("@index").InnerText = ctr_show2.Tag.ToString();
                            node.SelectSingleNode("@color").InnerText = ctr_show2.Color.R.ToString() + "," +
                            ctr_show2.Color.G.ToString() + "," + ctr_show2.Color.B.ToString();
                        }

                    }
                    doc.Save(path);
                    ctr_show2.refresh();
                }


                if (ctr_gauge != null)
                {
                    ctr_gauge.Tagname = btn_s.Text;
                    ctr_gauge.Tag = message[0];
                    ctr_gauge.Unit = message[2];
                    ctr_gauge.Max = txb_max.Text;
                    ctr_gauge.Min = txb_min.Text;
                    //保存修改到偏好配置文件

                    string path = Application.StartupPath + "\\Config\\preference.xml";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode root = doc.DocumentElement;
                    XmlNodeList nodeList = root.SelectNodes("Form[Name='" + Frm_name + "']//Controlsgauge//Control");


                    foreach (XmlNode node in nodeList)
                    {
                        if (ctr_gauge.Name == node.SelectSingleNode("@name").InnerText)
                        {
                            node.SelectSingleNode("@tagname").InnerText = ctr_gauge.Tagname;
                            node.SelectSingleNode("@min").InnerText = ctr_gauge.Min;
                            node.SelectSingleNode("@max").InnerText = ctr_gauge.Max;
                            node.SelectSingleNode("@unit").InnerText = ctr_gauge.Unit;
                            node.SelectSingleNode("@index").InnerText = ctr_gauge.Tag.ToString();

                        }

                    }
                    doc.Save(path);


                    ctr_gauge.refresh();
                }

                if (ctr_gaugemid != null)
                {
                    ctr_gaugemid.Tagname = btn_s.Text;
                    ctr_gaugemid.Tag = message[0];
                    ctr_gaugemid.Unit = message[2];
                    ctr_gaugemid.Max = txb_max.Text;
                    ctr_gaugemid.Min = txb_min.Text;
                    //保存修改到偏好配置文件

                    string path = Application.StartupPath + "\\Config\\preference.xml";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode root = doc.DocumentElement;
                    XmlNodeList nodeList = root.SelectNodes("Form[Name='" + Frm_name + "']//Controlsgauge//Control");


                    foreach (XmlNode node in nodeList)
                    {
                        if (ctr_gaugemid.Name == node.SelectSingleNode("@name").InnerText)
                        {
                            node.SelectSingleNode("@tagname").InnerText = ctr_gaugemid.Tagname;
                            node.SelectSingleNode("@min").InnerText = ctr_gaugemid.Min;
                            node.SelectSingleNode("@max").InnerText = ctr_gaugemid.Max;
                            node.SelectSingleNode("@unit").InnerText = ctr_gaugemid.Unit;
                            node.SelectSingleNode("@index").InnerText = ctr_gaugemid.Tag.ToString();

                        }

                    }
                    doc.Save(path);


                    ctr_gaugemid.refresh();
                }

            }

            //保存修改的量程到配置文件

            string path2 = Application.StartupPath + "\\Config\\" + "Para.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(path2);
            XmlNodeList list = xml.GetElementsByTagName("item");
            for (int i = 0; i < list.Count; ++i)
            {
                XmlNode node = list.Item(i);
                if (node.Attributes["序号"].Value == message[0])
                {

                    node.Attributes["最大值"].Value = txb_max.Text;
                    node.Attributes["最小值"].Value = txb_min.Text;
                }

            }
            xml.Save(path2);




            this.Close();
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            ColorDialog loColorForm = new ColorDialog();
            if (loColorForm.ShowDialog() == DialogResult.OK)
            {

                btn_color.BackColor = loColorForm.Color;
                tag_color = loColorForm.Color;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.ctr_show.label1.Visible = false;
            this.ctr_show.label2.Visible = false;
            this.ctr_show.label3.Visible = false;
            this.ctr_show.BackColor = Color.Transparent;
            this.Close();
        }
    }
}
