using Data_acquisition.Comm;
using MySql.Data.MySqlClient;
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
    public partial class Frm_report : Form
    {

        MySqlDataAdapter da;
        DataSet ds;

        public Frm_report()
        {
            InitializeComponent();
        }

        private void Frm_report_Load(object sender, EventArgs e)
        {
            //配置文件读取井队信息
            //txb_title.Text = Pub_func.GetValue("title");
            //txb_wellname.Text = Pub_func.GetValue("wellname");
            //txb_wellnum.Text = Pub_func.GetValue("wellnum");
            //txb_clientname.Text = Pub_func.GetValue("clientname");
            //txb_clientrep.Text = Pub_func.GetValue("clientrep");
            //txb_cstunit.Text = Pub_func.GetValue("cstunit");
            //txb_cstrep.Text = Pub_func.GetValue("cstrep");
            //txb_cstcomm.Text = Pub_func.GetValue("cstcomm");
            //txb_remark.Text = Pub_func.GetValue("remark");

            //从数据库获得当前井队信息

            string ConnStr = "Data Source=localhost;" +
                            "Initial Catalog=ifracview;User Id=root;Password=hhdq;";
            string sql = "select *  from reportsche";

            da = new MySqlDataAdapter(sql, new MySqlConnection(ConnStr));
            ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[1].HeaderText = "阶段号";
            dataGridView1.Columns[2].HeaderText = "阶段类型";
            dataGridView1.Columns[3].HeaderText = "支撑剂名称";
            xmlload();

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //保存报表抬头
            //Pub_func.SetValue("title", txb_title.Text);
            //Pub_func.SetValue("wellname", txb_wellname.Text);
            //Pub_func.SetValue("wellnum", txb_wellnum.Text);
            //Pub_func.SetValue("clientname", txb_clientname.Text);
            //Pub_func.SetValue("clientrep", txb_clientrep.Text);
            //Pub_func.SetValue("cstunit", txb_cstunit.Text);
            //Pub_func.SetValue("cstrep", txb_cstrep.Text);
            //Pub_func.SetValue("cstcomm", txb_cstcomm.Text);
            //Pub_func.SetValue("remark", txb_remark.Text);

            //保存阶段信息
            MySqlCommandBuilder bul = new MySqlCommandBuilder(da);
            da.Update(ds);
            xmlsave();
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //读取xml
        private void xmlload()
        {
            XmlDocument doc = new XmlDocument();
            string path = Application.StartupPath + "\\Config\\preference.xml";
            doc.Load(path);
            XmlNode root = doc.DocumentElement;
            XmlNodeList list = root.SelectNodes("Form[Name='Frm_creat']//Set");
            txb_wellname.Text = list[0].Attributes["wellname"].Value;
            txb_wellnum.Text = list[0].Attributes["wellnum"].Value;
            txb_clientname.Text = list[0].Attributes["clientname"].Value;
            txb_clientrep.Text = list[0].Attributes["clientrep"].Value;
            txb_cstunit.Text = list[0].Attributes["cstunit"].Value;
            txb_cstrep.Text = list[0].Attributes["cstrep"].Value;
            txb_cstcomm.Text = list[0].Attributes["cstcomm"].Value;

        }
        //保存xml
        private void xmlsave()
        {
            XmlDocument doc = new XmlDocument();
            string path = Application.StartupPath + "\\Config\\preference.xml";
            doc.Load(path);
            XmlNode root = doc.DocumentElement;
            XmlNodeList list = root.SelectNodes("Form[Name='Frm_creat']//Set");
            list[0].Attributes["wellname"].Value = txb_wellname.Text;
            list[0].Attributes["wellnum"].Value = txb_wellnum.Text;
            list[0].Attributes["clientname"].Value = txb_clientname.Text;
            list[0].Attributes["clientrep"].Value = txb_clientrep.Text;
            list[0].Attributes["cstunit"].Value = txb_cstunit.Text;
            list[0].Attributes["cstrep"].Value = txb_cstrep.Text;
            list[0].Attributes["cstcomm"].Value = txb_cstcomm.Text;
          
            doc.Save(path);
        }
    }
}
