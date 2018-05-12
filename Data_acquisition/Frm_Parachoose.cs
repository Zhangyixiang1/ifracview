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
    public partial class Frm_Parachoose : Form
    {
        string lan;     //当前语言
        int sec_index;  //构造函数传入的所选参数
        DataGridView dgv;  //构造函数传入参数
        public Frm_Parachoose(int index, DataGridView dt)
        {
            InitializeComponent();
            sec_index = index;
            dgv = dt;
        }

        private void Frm_Parachoose_Load(object sender, EventArgs e)
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

            //初始化listbox1
            string path = Application.StartupPath + "\\Config\\" + "Para.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList list = xml.GetElementsByTagName("item");

            for (int i = 0; i < list.Count; i++)
            {
                XmlNode node = list.Item(i);
                string Index = node.Attributes["序号"].Value;
                string Name = node.Attributes[lan].Value;
                //if (Name == "备用") continue;
                listBox1.Items.Add(Index + ":" + Name);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个参数！");
            }
            else
            {
                //判断参数是否存在

                for (int i = 0; i < dgv.Rows.Count; i++)
                {

                    if (dgv.Rows[i].Cells[2].Value == Form_Main.dt_para.Rows[listBox1.SelectedIndex]["序号"])
                    {
                        MessageBox.Show("参数已经选择，请勾选其他参数！"); return;
                    }

                }
                //添加选择参数
                if (sec_index == -1)
                {
                    int index = dgv.Rows.Add();
                    dgv.Rows[index].Cells[0].Value = Form_Main.dt_para.Rows[listBox1.SelectedIndex]["中文名称"];
                    dgv.Rows[index].Cells[1].Value = Form_Main.dt_para.Rows[listBox1.SelectedIndex]["公制单位"];
                    dgv.Rows[index].Cells[2].Value = Form_Main.dt_para.Rows[listBox1.SelectedIndex]["序号"];
                    dgv.Rows[index].HeaderCell.Value = string.Format("{0}", index + 1);
                }
                //更改选择参数
                else
                {
                   
                    dgv.Rows[sec_index].Cells[0].Value = Form_Main.dt_para.Rows[listBox1.SelectedIndex]["中文名称"];
                    dgv.Rows[sec_index].Cells[1].Value = Form_Main.dt_para.Rows[listBox1.SelectedIndex]["公制单位"];
                    dgv.Rows[sec_index].Cells[2].Value = Form_Main.dt_para.Rows[listBox1.SelectedIndex]["序号"];


                }

            }

            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
