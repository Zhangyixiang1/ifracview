using Data_acquisiton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_acquisition
{
    public partial class Frm_send : Form
    {
        private DataGridView dataGridView1;
        StringBuilder stageinfo;
        public Frm_send(DataGridView dgv)
        {
            InitializeComponent();
            this.dataGridView1 = dgv;
           
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (!chb_auto.Checked)
                {
                    ((Form_Main)Application.OpenForms["Form_Main"]).btn_next.Enabled = true; Form_Main.kep1.KepItems.Item(587).Write(false);
                    Form_Main.stage_auto = false;
                    //((Form_Main)Application.OpenForms["Form_Main"]).rdbtn_hand.Checked = true;
                    //((Form_Main)Application.OpenForms["Form_Main"]).rdbtn_auto.Checked = false;
                }
                else
                {
                    ((Form_Main)Application.OpenForms["Form_Main"]).btn_next.Enabled = false; Form_Main.kep1.KepItems.Item(587).Write(true);

                    Form_Main.stage_auto = true;
                    //((Form_Main)Application.OpenForms["Form_Main"]).rdbtn_auto.Checked = true;
                    //((Form_Main)Application.OpenForms["Form_Main"]).rdbtn_hand.Checked = false;
                }

                progressBar1.Maximum = dataGridView1.Rows.Count;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow dr = dataGridView1.Rows[i];
                    int[] temp_handle = new int[]{0,
                   Form_Main.kep1.Item_serverhandle1_To_PC[545+i],//基液
                    Form_Main.kep1.Item_serverhandle1_To_PC[53+i],Form_Main.kep1.Item_serverhandle1_To_PC[94+i], //砂浓度
                   Form_Main.kep1.Item_serverhandle1_To_PC[135+i],Form_Main.kep1.Item_serverhandle1_To_PC[176+i],//液添1
                    Form_Main.kep1.Item_serverhandle1_To_PC[217+i],Form_Main.kep1.Item_serverhandle1_To_PC[258+i],//液添2
                    Form_Main.kep1.Item_serverhandle1_To_PC[299+i],Form_Main.kep1.Item_serverhandle1_To_PC[339+i],//液添3
                     Form_Main.kep1.Item_serverhandle1_To_PC[381+i],Form_Main.kep1.Item_serverhandle1_To_PC[422+i],//干添1
                    Form_Main.kep1.Item_serverhandle1_To_PC[463+i],Form_Main.kep1.Item_serverhandle1_To_PC[504+i] //干添2
                    };

                    object[] temp_value = new object[] { "", dr.Cells[2].Value, dr.Cells[3].Value, 
                    dr.Cells[4].Value, dr.Cells[5].Value, 
                    dr.Cells[6].Value, dr.Cells[7].Value, 
                    dr.Cells[8].Value,dr.Cells[9].Value,
                    dr.Cells[10].Value,dr.Cells[11].Value,
                    dr.Cells[12].Value,dr.Cells[13].Value,dr.Cells[14].Value,};
                    Array handle = (Array)temp_handle;
                    Array value = (Array)temp_value;
                    Array err;
                    int id;
                    Form_Main.kep1.KepGroup.AsyncWrite(handle.Length - 1, ref handle, ref value, out err, 1, out id);
                
                    GC.Collect();
                    progressBar1.Value = i;
               //     stageinfo.Append(dr.Cells[1].ToString()+",");
                }
                //0517修改，排出总量清零

                Form_Main.kep1.KepItems.Item(20).Write(true);
                //发送总阶段数到PLC
                Form_Main.kep1.KepItems.Item(588).Write(dataGridView1.Rows.Count);
                //0526修改，发送成功后记录已发送
                Form_Main.isSend = true;


                //发送成功后将阶段信息保存到数据库
               // Form_Main.stageinfo=stageinfo.ToString();
                //DbManager db = new DbManager();
                //db.ConnStr = "Data Source=localhost;" +
                //"Initial Catalog=ifracview;User Id=root;Password=hhdq;";
                //string sql = "update wellinfo set stageinfo=" + "'" + stageinfo.ToString()+"'"+" where id="+Form_Main.wellinfoID;
                //db.ExecuteNonquery(sql);
                this.Close();

                //同步计划数据，先删除表中数据，再重新插入
                //DbManager db = new DbManager();
                //db.ConnStr = "Data Source=localhost;" +
                //"Initial Catalog=ifracview;User Id=root;Password=hhdq;";
                //string sql = "delete from schedule";
                //db.ExecuteNonquery(sql);
                //string sql2 = "insert into schedule(Stage,Sand,LA1,LA2,LA3,LA4,DA1,Cleanvol) values(@stage,@sand,@la1,@la2,@la3,@la4,@da1,@vol)";
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    List<MySqlParameter> Paramter = new List<MySqlParameter>();
                //    Paramter.Add(new MySqlParameter("@stage", dataGridView1.Rows[i].Cells[0].Value.ToString()));
                //    Paramter.Add(new MySqlParameter("@sand", dataGridView1.Rows[i].Cells[1].Value.ToString()));
                //    Paramter.Add(new MySqlParameter("@la1", dataGridView1.Rows[i].Cells[2].Value.ToString()));
                //    Paramter.Add(new MySqlParameter("@la2", dataGridView1.Rows[i].Cells[3].Value.ToString()));
                //    Paramter.Add(new MySqlParameter("@la3", dataGridView1.Rows[i].Cells[4].Value.ToString()));
                //    Paramter.Add(new MySqlParameter("@la4", dataGridView1.Rows[i].Cells[5].Value.ToString()));
                //    Paramter.Add(new MySqlParameter("@da1", dataGridView1.Rows[i].Cells[6].Value.ToString()));
                //    Paramter.Add(new MySqlParameter("@vol", dataGridView1.Rows[i].Cells[7].Value.ToString()));
                //    db.ExecuteNonquery(sql2, Paramter.ToArray());
                //}


                //砂浓度


                //    kep1.KepGroup.AsyncWrite(1,kep1.Item_serverhandle1_To_PC[33],out );



            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.ToString());
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_send_Load(object sender, EventArgs e)
        {
            //语言切换
            if (Form_Main.lan == "Chinese") MultiLanguage.LoadLanguage(this, "Chinese");
            else if (Form_Main.lan == "English") MultiLanguage.LoadLanguage(this, "English");
        }
    }
}
