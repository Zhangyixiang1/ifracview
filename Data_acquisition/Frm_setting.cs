using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Data_acquisiton;
using System.Globalization;
using System.Threading;
using Data_acquisition.Comm;
namespace Data_acquisition
{
    public partial class Frm_setting : Form
    {

        public Frm_setting()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rdb_chn.Checked)
            {
                Form_Main.lan = "Chinese";
                Pub_func.SetValue("Language", "Chinese");
                //主界面
                MultiLanguage.LoadLanguage(Application.OpenForms["Form_Main"], "Chinese");
                ((Form_Main)Application.OpenForms["Form_Main"]).zedGraphControl1.GraphPane.XAxis.Title.Text = "时间(分钟)";
                ((Form_Main)Application.OpenForms["Form_Main"]).zedGraphControl1.AxisChange();
                ((Form_Main)Application.OpenForms["Form_Main"]).zedGraphControl1.Invalidate();
                ((Form_Main)Application.OpenForms["Form_Main"]).lbl_stage.Text =
                Form_Main.wellname + Form_Main.wellnum + "第" + Form_Main.stage_big + "段  " + "阶段:" + Form_Main.num_stage;
                DataGridView grd = ((Form_Main)Application.OpenForms["Form_Main"]).dataGridView1;
                grd.Columns[0].HeaderText = "阶段号"; grd.Columns[1].HeaderText = "名称"; grd.Columns[2].HeaderText = "净液量(m3)";
                grd.Columns[3].HeaderText = "砂浓度起始(kg/m3)"; grd.Columns[4].HeaderText = "砂浓度结束(kg/m3)";
                grd.Columns[5].HeaderText = "液添1起始(L/m3)"; grd.Columns[6].HeaderText = "液添1结束(L/m3)"; grd.Columns[7].HeaderText = "液添2起始(L/m3)";
                grd.Columns[8].HeaderText = "液添2结束(L/m3)"; grd.Columns[9].HeaderText = "液添3起始(L/m3)"; grd.Columns[10].HeaderText = "液添3结束(L/m3)";
                grd.Columns[11].HeaderText = "干添1起始(kg/m3)"; grd.Columns[12].HeaderText = "干添1结束(kg/m3)"; grd.Columns[13].HeaderText = "干添2起始(kg/m3)";
                grd.Columns[14].HeaderText = "干添2结束(kg/m3)"; grd.Columns[15].HeaderText = "支撑剂类型";
                //曲线界面1
                MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Realtrend"], "Chinese");
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.GraphPane.XAxis.Title.Text = "时间(分钟)";
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.AxisChange();
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.Invalidate();
                //曲线界面2
                MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Realtrend2"], "Chinese");
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).zedGraphControl1.GraphPane.XAxis.Title.Text = "排出总量(m3)";
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).zedGraphControl1.AxisChange();
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).zedGraphControl1.Invalidate();
                DataGridView grd2 = ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).dataGridView1;
                grd2.Columns[0].HeaderText = "添加剂";
                grd2.Rows[0].Cells[0].Value = "支撑剂"; grd2.Rows[1].Cells[0].Value = "液添1"; grd2.Rows[2].Cells[0].Value = "液添2";
                grd2.Rows[3].Cells[0].Value = "液添3"; grd2.Rows[4].Cells[0].Value = "干添1"; grd2.Rows[5].Cells[0].Value = "干添2";
                grd2.Columns[1].HeaderText = "控制模式"; grd2.Columns[2].HeaderText = "目标浓度(x/m3)";
                grd2.Columns[3].HeaderText = "当前浓度(x/m3)"; grd2.Columns[4].HeaderText = "当前流量(x/min)";
                grd2.Columns[5].HeaderText = "阶段总量(m3 or kg)"; grd2.Columns[6].HeaderText = "总量(m3 or kg)";
                //数字界面
                MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Paradigital2"], "Chinese");
                //表盘界面
                MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Paraanalog2"], "Chinese");
                ((Frm_Paraanalog2)Application.OpenForms["Frm_Paraanalog2"]).gauge2.label1.Text = "井口套压";
                ((Frm_Paraanalog2)Application.OpenForms["Frm_Paraanalog2"]).gauge0.label4.Text = "井口油压";
                ((Frm_Paraanalog2)Application.OpenForms["Frm_Paraanalog2"]).gauge1.label1.Text = "井口排出流量";
                //本界面
                MultiLanguage.LoadLanguage(this, "Chinese");
            }
            if (rdb_eng.Checked)
            {   //主界面
                Form_Main.lan = "English";
                Pub_func.SetValue("Language", "English");
                MultiLanguage.LoadLanguage(Application.OpenForms["Form_Main"], "English");
                ((Form_Main)Application.OpenForms["Form_Main"]).zedGraphControl1.GraphPane.XAxis.Title.Text = "Time(Min)";
                ((Form_Main)Application.OpenForms["Form_Main"]).zedGraphControl1.AxisChange();
                ((Form_Main)Application.OpenForms["Form_Main"]).zedGraphControl1.Invalidate();
                ((Form_Main)Application.OpenForms["Form_Main"]).lbl_stage.Text =
                Form_Main.wellname + Form_Main.wellnum + "job" + Form_Main.stage_big + "stage:" + Form_Main.num_stage;
                DataGridView grd = ((Form_Main)Application.OpenForms["Form_Main"]).dataGridView1;
                grd.Columns[0].HeaderText = "Stage"; grd.Columns[1].HeaderText = "Name"; grd.Columns[2].HeaderText = "Clean Vol.(m3)";
                grd.Columns[3].HeaderText = "Sand Start(kg/m3)"; grd.Columns[4].HeaderText = "Sand End(kg/m3)";
                grd.Columns[5].HeaderText = "LA1 Start(L/m3)"; grd.Columns[6].HeaderText = " LA1  End(L/m3)"; grd.Columns[7].HeaderText = "LA2 Start(L/m3)";
                grd.Columns[8].HeaderText = " LA2  End(L/m3)"; grd.Columns[9].HeaderText = "LA3 Start(L/m3)"; grd.Columns[10].HeaderText = "LA3  End(L/m3)";
                grd.Columns[11].HeaderText = "DA1 Start(kg/m3)"; grd.Columns[12].HeaderText = "DA1  End(kg/m3)"; grd.Columns[13].HeaderText = "DA2 Start(kg/m3)";
                grd.Columns[14].HeaderText = "DA2  End(kg/m3)"; grd.Columns[15].HeaderText = "SandType";
                //曲线界面1
                MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Realtrend"], "English");
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.GraphPane.XAxis.Title.Text = "Time(min)";
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.AxisChange();
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.Invalidate();
                //曲线界面2
                MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Realtrend2"], "English");
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).zedGraphControl1.GraphPane.XAxis.Title.Text = "Discharge Total(m3)";
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).zedGraphControl1.AxisChange();
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).zedGraphControl1.Invalidate();
                DataGridView grd2 = ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).dataGridView1;
                grd2.Columns[0].HeaderText = "Chemical Name";
                grd2.Rows[0].Cells[0].Value = "Sand"; grd2.Rows[1].Cells[0].Value = "Chem1"; grd2.Rows[2].Cells[0].Value = "Chem2";
                grd2.Rows[3].Cells[0].Value = "Chem3"; grd2.Rows[4].Cells[0].Value = "DryAdd1"; grd2.Rows[5].Cells[0].Value = "DryAdd2";
                grd2.Columns[1].HeaderText = "Control Mode"; grd2.Columns[2].HeaderText = "Target Concen(x/m3)";
                grd2.Columns[3].HeaderText = "Actual Concen(x/m3)"; grd2.Columns[4].HeaderText = "Current Rate(x/min)";
                grd2.Columns[5].HeaderText = "Stage Total(m3 or kg)"; grd2.Columns[6].HeaderText = "Job Total(m3 or kg)";
                //数字界面
                MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Paradigital2"], "English");
                //表盘界面
                MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Paraanalog2"], "English");
                ((Frm_Paraanalog2)Application.OpenForms["Frm_Paraanalog2"]).gauge2.label1.Text = "Casing Pressure";
                ((Frm_Paraanalog2)Application.OpenForms["Frm_Paraanalog2"]).gauge0.label4.Text = "Tubing Pressure";
                ((Frm_Paraanalog2)Application.OpenForms["Frm_Paraanalog2"]).gauge1.label1.Text = "Discharge Rate";
                //本界面
                MultiLanguage.LoadLanguage(this, "English");
            }
            //检测到公英制如果变化了，提示要重启程序
            if(Form_Main.Unit.ToString()!=Pub_func.GetValue("Unit")){
            
            Pub_func.SetValue("Unit",Form_Main.Unit.ToString());
            string msg="切换公英制，软件将会重启，是否继续！";
            if (Form_Main.lan=="English") msg="If you are going to change the unit, the system will restart. Are you sure to continue? ";
           DialogResult result= MessageBox.Show(msg,"Warm",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if(result==DialogResult.OK){
            Application.Restart();
            }
            }

            this.Close();
        }

        private void Frm_setting_Load(object sender, EventArgs e)
        {
            //语言切换
            if (Form_Main.lan == "Chinese")
            {
                MultiLanguage.LoadLanguage(this, "Chinese");
                rdb_chn.Checked = true;
            }
            else if (Form_Main.lan == "English")
            {
                MultiLanguage.LoadLanguage(this, "English");
                rdb_eng.Checked = true;
            }
            if(Form_Main.Unit==0) rdb_metric.Checked=true;
            else if(Form_Main.Unit==1) rdb_engunit.Checked=true;

            //0512读取设备IP
            txb_f1.Text = Form_Main.value_state.GetValue(1).ToString().Substring(0,Form_Main.value_state.GetValue(1).ToString().Length - 4);
            txb_f2.Text = Form_Main.value_state.GetValue(3).ToString().Substring(0, Form_Main.value_state.GetValue(3).ToString().Length - 4);
            txb_f3.Text = Form_Main.value_state.GetValue(5).ToString().Substring(0, Form_Main.value_state.GetValue(5).ToString().Length - 4);
            txb_f4.Text = Form_Main.value_state.GetValue(7).ToString().Substring(0, Form_Main.value_state.GetValue(7).ToString().Length - 4);
            txb_f5.Text = Form_Main.value_state.GetValue(9).ToString().Substring(0, Form_Main.value_state.GetValue(9).ToString().Length - 4);
            txb_f6.Text = Form_Main.value_state.GetValue(11).ToString().Substring(0, Form_Main.value_state.GetValue(11).ToString().Length - 4);
            txb_f7.Text = Form_Main.value_state.GetValue(13).ToString().Substring(0, Form_Main.value_state.GetValue(13).ToString().Length - 4);
            txb_f8.Text = Form_Main.value_state.GetValue(15).ToString().Substring(0, Form_Main.value_state.GetValue(15).ToString().Length - 4);
            txb_b.Text = Form_Main.value_state.GetValue(17).ToString().Substring(0, Form_Main.value_state.GetValue(17).ToString().Length - 4);
            txb_daq.Text = Comm.Pub_func.GetValue("daq");


        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdb_engunit_CheckedChanged(object sender, EventArgs e)
        {
            if(rdb_engunit.Checked) Form_Main.Unit=1;
        }

        private void rdb_metric_CheckedChanged(object sender, EventArgs e)
        {
            if(rdb_metric.Checked)Form_Main.Unit=0;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            Form_Main.kep3.KepItems.Item(1).Write(txb_f1.Text + ",1,0");
            Form_Main.kep3.KepItems.Item(3).Write(txb_f2.Text + ",1,0");
            Form_Main.kep3.KepItems.Item(5).Write(txb_f3.Text + ",1,0");
            Form_Main.kep3.KepItems.Item(7).Write(txb_f4.Text + ",1,0");
            Form_Main.kep3.KepItems.Item(9).Write(txb_f5.Text + ",1,0");
            Form_Main.kep3.KepItems.Item(11).Write(txb_f6.Text + ",1,0");
            Form_Main.kep3.KepItems.Item(13).Write(txb_f7.Text + ",1,0");
            Form_Main.kep3.KepItems.Item(15).Write(txb_f8.Text + ",1,0");
            Form_Main.kep3.KepItems.Item(17).Write(txb_b.Text + ",1,0");
            Comm.Pub_func.SetValue("daq", txb_daq.Text);
            btn_confirm.Enabled = false;
        }
    }
}
