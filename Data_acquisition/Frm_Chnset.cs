using Data_acquisition.Comm;
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
    public partial class Frm_Chnset : Form
    {
        DataTable dt;
        public Frm_Chnset()
        {
            InitializeComponent();
        }

        private void Frm_Chnset_Load(object sender, EventArgs e)
        {
           

            //0528修改，曲线daq的参数设置，行数从30开始，即混砂橇
            dt = Form_Main.dt_para.Clone();
            for (int i = 0; i < Form_Main.dt_para.Rows.Count - 30; i++)
            {

                dt.Rows.Add(Form_Main.dt_para.Rows[i + 30].ItemArray);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 40;
            foreach (DataGridViewColumn cln in dataGridView1.Columns) cln.SortMode = DataGridViewColumnSortMode.NotSortable; //禁止排序
            dataGridView1.Columns["加快捷键"].Visible = false; dataGridView1.Columns["减快捷键"].Visible = false;
            dataGridView1.Columns["幅度"].Visible = false; dataGridView1.Columns["启用快捷键"].Visible = false;
            dataGridView1.Columns["序号"].ReadOnly = true;

            //语言切换
            if (Form_Main.lan == "Chinese")
            {
                MultiLanguage.LoadLanguage(this, "Chinese");

            }
            else if (Form_Main.lan == "English")
            {
                MultiLanguage.LoadLanguage(this, "English");
                //表头
                dataGridView1.Columns[0].HeaderText = "ID"; dataGridView1.Columns[1].HeaderText = "CH Name"; dataGridView1.Columns[2].HeaderText = "EN Name";
                dataGridView1.Columns[3].HeaderText = "EN Unit"; dataGridView1.Columns[4].HeaderText = "Metric Unit"; dataGridView1.Columns[5].HeaderText = "MAX";
                dataGridView1.Columns[6].HeaderText = "MIN"; dataGridView1.Columns[7].HeaderText = "Factor"; dataGridView1.Columns[8].HeaderText = "Offset";
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btn_confirm.Enabled = true;
                if(Form_Main.lan=="Chinese")
                label1.Text = dataGridView1.SelectedRows[0].Cells["中文名称"].Value.ToString();
                else label1.Text = dataGridView1.SelectedRows[0].Cells["英文名称"].Value.ToString();
                txb_add.Text = dataGridView1.SelectedRows[0].Cells["加快捷键"].Value.ToString();
                txb_sub.Text = dataGridView1.SelectedRows[0].Cells["减快捷键"].Value.ToString();
                txb_value.Text = dataGridView1.SelectedRows[0].Cells["幅度"].Value.ToString();
                checkBox1.Checked = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["启用快捷键"].Value);
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            //输入框不能为空
            if (string.IsNullOrEmpty(txb_add.Text) || string.IsNullOrEmpty(txb_sub.Text) || string.IsNullOrEmpty(txb_value.Text))
            {
                MessageBox.Show("输入框不能为空！");
                return;
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {


                //修改结果保存到offlist中

                if (Form_Main.Offlist.ContainsKey(txb_add.Text))
                {
                    //Offmodel model = new Offmodel(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells["序号"].Value),
                    //    Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["启用快捷键"].Value), Convert.ToDouble(txb_value.Text));
                    //Form_Main.Offlist["txb_add.Text"] = model;
                    if (Form_Main.Offlist[txb_add.Text].index != Convert.ToInt16(dataGridView1.SelectedRows[0].Cells["序号"].Value))
                    {
                        MessageBox.Show("键值" + txb_add.Text + "已被占用，请重新键入！");
                        return;
                    }
                    else
                    {
                        Form_Main.Offlist[txb_add.Text].active = checkBox1.Checked;
                        Form_Main.Offlist[txb_add.Text].value = Convert.ToDouble(txb_value.Text);
                    }
                }
                else
                {
                    Offmodel model = new Offmodel(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells["序号"].Value),
                    checkBox1.Checked, Convert.ToDouble(txb_value.Text));
                    Form_Main.Offlist.Add(txb_add.Text, model);

                }
                if (Form_Main.Offlist.ContainsKey(txb_sub.Text))
                {
                    //Offmodel model = new Offmodel(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells["序号"].Value),
                    //    Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["启用快捷键"].Value), Convert.ToDouble(txb_value.Text));
                    //Form_Main.Offlist["txb_sub.Text"] = model;
                    if (Form_Main.Offlist[txb_add.Text].index != Convert.ToInt16(dataGridView1.SelectedRows[0].Cells["序号"].Value))
                    {
                        MessageBox.Show("键值" + txb_add.Text + "已被占用，请重新键入！");
                        return;
                    }
                    else
                    {
                        Form_Main.Offlist[txb_sub.Text].active = checkBox1.Checked;
                        Form_Main.Offlist[txb_sub.Text].value = -Convert.ToDouble(txb_value.Text);
                    }
                }
                else
                {
                    Offmodel model = new Offmodel(Convert.ToInt16(dataGridView1.SelectedRows[0].Cells["序号"].Value),
                        checkBox1.Checked, -Convert.ToDouble(txb_value.Text));
                    Form_Main.Offlist.Add(txb_sub.Text, model);
                }
                dataGridView1.SelectedRows[0].Cells["加快捷键"].Value = txb_add.Text;
                dataGridView1.SelectedRows[0].Cells["减快捷键"].Value = txb_sub.Text;
                dataGridView1.SelectedRows[0].Cells["幅度"].Value = txb_value.Text;
                dataGridView1.SelectedRows[0].Cells["启用快捷键"].Value = checkBox1.Checked.ToString();
            }
            btn_confirm.Enabled = false;
        }

        private void txb_add_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            //0528修改，临时的表要修改到Form_main.dt_para

            for (int i = 0; i < Form_Main.dt_para.Rows.Count - 30; i++)
            {
                Form_Main.dt_para.Rows[i + 30].ItemArray = dt.Rows[i].ItemArray;
            }
            //保存修改结果到xml文档
            string path = Application.StartupPath + "\\Config\\Para.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList list = xml.GetElementsByTagName("item");
            for (int i = 0; i < list.Count - 30; i++)
            {
                list[i + 30].Attributes["中文名称"].Value = dataGridView1.Rows[i].Cells["中文名称"].Value.ToString();
                list[i + 30].Attributes["英文名称"].Value = dataGridView1.Rows[i].Cells["英文名称"].Value.ToString();
                list[i + 30].Attributes["英制单位"].Value = dataGridView1.Rows[i].Cells["英制单位"].Value.ToString();
                list[i + 30].Attributes["公制单位"].Value = dataGridView1.Rows[i].Cells["公制单位"].Value.ToString();
                list[i + 30].Attributes["最大值"].Value = dataGridView1.Rows[i].Cells["最大值"].Value.ToString();
                list[i + 30].Attributes["最小值"].Value = dataGridView1.Rows[i].Cells["最小值"].Value.ToString();
                list[i + 30].Attributes["因子"].Value = dataGridView1.Rows[i].Cells["因子"].Value.ToString();
                list[i + 30].Attributes["偏移量"].Value = dataGridView1.Rows[i].Cells["偏移量"].Value.ToString();
                Form_Main.offset[i + +30 + 1] = Convert.ToDouble(dataGridView1.Rows[i].Cells["偏移量"].Value.ToString());
                list[i + 30].Attributes["加快捷键"].Value = dataGridView1.Rows[i].Cells["加快捷键"].Value.ToString();
                list[i + 30].Attributes["减快捷键"].Value = dataGridView1.Rows[i].Cells["减快捷键"].Value.ToString();
                list[i + 30].Attributes["启用快捷键"].Value = dataGridView1.Rows[i].Cells["启用快捷键"].Value.ToString();
                list[i + 30].Attributes["幅度"].Value = dataGridView1.Rows[i].Cells["幅度"].Value.ToString();
            }
            xml.Save(path);

            //界面更新显示信息
            foreach (Form frm in Application.OpenForms)
                pre_refresh(frm);
            this.Close();
        }

        private void txb_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            //数字0~9所对应的keychar为48~57，小数点是46，Backspace是8  
            e.Handled = true;
            //输入0-9和Backspace del 有效  
            if ((e.KeyChar >= 47 && e.KeyChar <= 58) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            if (e.KeyChar == 46)                       //小数点        
            {
                if (txb_value.Text.Length <= 0)
                    e.Handled = true;           //小数点不能在第一位        
                else
                {
                    float f;
                    if (float.TryParse(txb_value.Text + e.KeyChar.ToString(), out f))
                    {
                        e.Handled = false;
                    }
                }
            }
        }
        private void pre_refresh(Form frm)
        {

            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is ParaLine)
                {
                    ParaLine ctr = ctrl as ParaLine;

                    int index = Convert.ToInt16(ctr.Tag);
                    ctr.Tagname = Form_Main.dt_para.Rows[index - 1]["中文名称"].ToString();
                    ctr.Tagname_EN = Form_Main.dt_para.Rows[index - 1]["英文名称"].ToString();
                    ctr.Min = Form_Main.dt_para.Rows[index - 1]["最小值"].ToString();
                    ctr.Max = Form_Main.dt_para.Rows[index - 1]["最大值"].ToString();
                    ctr.Unit = Form_Main.dt_para.Rows[index - 1]["公制单位"].ToString();
                    if (Form_Main.Unit == 1) ctr.Unit = Form_Main.dt_para.Rows[index - 1]["英制单位"].ToString();
                    ctr.refresh();

                }
                if (ctrl is Gauge)
                {
                    Gauge ctr = ctrl as Gauge;

                    int index = Convert.ToInt16(ctr.Tag);
                    ctr.Tagname = Form_Main.dt_para.Rows[index - 1]["中文名称"].ToString();
                    //ctr.Tagname_EN = Form_Main.dt_para.Rows[index - 1]["英文名称"].ToString();
                    ctr.Min = Form_Main.dt_para.Rows[index - 1]["最小值"].ToString();
                    ctr.Max = Form_Main.dt_para.Rows[index - 1]["最大值"].ToString();
                    ctr.Unit = Form_Main.dt_para.Rows[index - 1]["公制单位"].ToString();
                    if (Form_Main.Unit == 1) ctr.Unit = Form_Main.dt_para.Rows[index - 1]["英制单位"].ToString();


                }


                if (ctrl is Parashow)
                {
                    Parashow ctrl2 = ctrl as Parashow;

                    int index = Convert.ToInt16(ctrl2.Tag);
                    ctrl2.Tagname = Form_Main.dt_para.Rows[index - 1]["中文名称"].ToString();
                    ctrl2.Tagname_EN = Form_Main.dt_para.Rows[index - 1]["英文名称"].ToString();
                    ctrl2.Unit = Form_Main.dt_para.Rows[index - 1]["公制单位"].ToString();
                    if (Form_Main.Unit == 1) ctrl2.Unit = Form_Main.dt_para.Rows[index - 1]["英制单位"].ToString();
                    ctrl2.refresh();
                }

                if (ctrl is Parashownew)
                {

                    Parashownew ctrl2 = ctrl as Parashownew;

                    int index = Convert.ToInt16(ctrl2.Tag);
                    ctrl2.Tagname = Form_Main.dt_para.Rows[index - 1]["中文名称"].ToString();
                    ctrl2.Tagname_EN = Form_Main.dt_para.Rows[index - 1]["英文名称"].ToString();
                    ctrl2.Unit = Form_Main.dt_para.Rows[index - 1]["公制单位"].ToString();
                    if (Form_Main.Unit == 1) ctrl2.Unit = Form_Main.dt_para.Rows[index - 1]["英制单位"].ToString();
                    ctrl2.refresh();

                }

            }
            //更新坐标轴

            ((Form_Main)Application.OpenForms["Form_Main"]).trend_refresh("0");
            ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).trend_refresh("0");
            ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).trend_refresh("1");


        }

    }

}
