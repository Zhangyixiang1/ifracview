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
    public partial class Frm_Paraset : Form
    {
        string lan;

        public Frm_Paraset()
        {
            InitializeComponent();
        }

        private void Frm_Paraset_Load(object sender, EventArgs e)
        {
            //语言切换
            if (Form_Main.lan == "Chinese")
            {
                MultiLanguage.LoadLanguage(this, "Chinese");
                lan = "中文名称";
            }
            else if (Form_Main.lan == "English")
            {
                MultiLanguage.LoadLanguage(this, "English");
                lan = "英文名称";
            }


            string path = Application.StartupPath + "\\Config\\" + "preference.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNode root = xml.DocumentElement;
            XmlNodeList nodeList = root.SelectNodes("Form[Name='" + this.Name + "']//Set");
            XmlNode node = nodeList[0];
            string index1 = node.SelectSingleNode("@report").InnerText; //报表参数
            string index2 = node.SelectSingleNode("@series").InnerText;//串口参数
            lbl_series.Text = node.SelectSingleNode("@port").InnerText + " " + node.SelectSingleNode("@rate").InnerText;
            string interval = node.SelectSingleNode("@interval").InnerText;
            //初始化报表输出表格
            if (interval == "60") rdbtn_60s.Checked = true;
            if (Form_Main.isfracmode) rdbrn_fracpro.Checked = true;
            string[] temp = index1.Split(',');
            for (int i = 0; i < temp.Length; i++)
            {
                int sec_index = Convert.ToInt16(temp[i]);
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = Form_Main.dt_para.Rows[sec_index - 1]["中文名称"];
                dataGridView1.Rows[index].Cells[1].Value = Form_Main.dt_para.Rows[sec_index - 1]["公制单位"];
                dataGridView1.Rows[index].Cells[2].Value = Form_Main.dt_para.Rows[sec_index - 1]["序号"];
                dataGridView1.Rows[index].HeaderCell.Value = string.Format("{0}", i + 1);
            }
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();

            //初始化串口传输输出表格
            string[] temp1 = index2.Split(',');
            for (int i = 0; i < temp1.Length; i++)
            {
                int sec_index = Convert.ToInt16(temp1[i]);
                int index = dataGridView2.Rows.Add();
                dataGridView2.Rows[index].Cells[0].Value = Form_Main.dt_para.Rows[sec_index - 1]["中文名称"];
                dataGridView2.Rows[index].Cells[1].Value = Form_Main.dt_para.Rows[sec_index - 1]["公制单位"];
                dataGridView2.Rows[index].Cells[2].Value = Form_Main.dt_para.Rows[sec_index - 1]["序号"];
                dataGridView2.Rows[index].HeaderCell.Value = string.Format("{0}", i + 1);
            }
            dataGridView2.Refresh();
            dataGridView2.ClearSelection();
        }



        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            StringBuilder str1 = new StringBuilder();
            StringBuilder str2 = new StringBuilder();
            if (rdbtn_60s.Checked) Form_Main.report_interval = 60;
            else Form_Main.report_interval = 1;
            if (rdbrn_fracpro.Checked) Form_Main.isfracmode = true;
            else Form_Main.isfracmode = false; 
            Form_Main.report_index.Clear();
            //保存到xml配置文档
            string path = Application.StartupPath + "\\Config\\" + "preference.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNode root = xml.DocumentElement;
            XmlNodeList nodeList = root.SelectNodes("Form[Name='" + this.Name + "']//Set");
            XmlNode node = nodeList[0];
            Form_Main.report_index.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Form_Main.report_index.Add(Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value));
                str1.Append(Convert.ToInt16(dataGridView1.Rows[i].Cells[2].Value) + ",");
            }
            Form_Main.series_index.Clear();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                Form_Main.series_index.Add(Convert.ToInt16(dataGridView2.Rows[i].Cells[2].Value));
                str2.Append(Convert.ToInt16(dataGridView2.Rows[i].Cells[2].Value) + ",");
            }
            node.SelectSingleNode("@report").InnerText = str1.ToString().Substring(0, str1.ToString().Length - 1);
            node.SelectSingleNode("@series").InnerText = str2.ToString().Substring(0, str2.ToString().Length - 1);
            node.SelectSingleNode("@interval").InnerText = Form_Main.report_interval.ToString();
            node.SelectSingleNode("@mode").InnerText = Form_Main.isfracmode.ToString();
            xml.Save(path);
            this.Close();
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;

            Frm_Parachoose frm = new Frm_Parachoose(e.RowIndex, dataGridView1);
            frm.ShowDialog();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Frm_Parachoose frm = new Frm_Parachoose(-1, dataGridView1);
            frm.ShowDialog();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {

                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    dataGridView1.Rows[i].HeaderCell.Value = string.Format("{0}", i + 1);
                }
            }
        }

        private void btn_add1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 16)
            {
                MessageBox.Show("串口输出最多传输16个参数！");
            }
            Frm_Parachoose frm = new Frm_Parachoose(-1, dataGridView2);
            frm.ShowDialog();
        }

        private void btn_remove1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0)
            {

                dataGridView2.Rows.Remove(dataGridView2.SelectedRows[0]);
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {

                    dataGridView2.Rows[i].HeaderCell.Value = string.Format("{0}", i + 1);
                }
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0) return;

            Frm_Parachoose frm = new Frm_Parachoose(e.RowIndex, dataGridView2);
            frm.ShowDialog();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            dataGridView2.ClearSelection();
        }

        private void btn_series_Click(object sender, EventArgs e)
        {
            Frm_serial frm = new Frm_serial(lbl_series.Text);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_report frm = new Frm_report();
            frm.ShowDialog();
        }


    }
}
