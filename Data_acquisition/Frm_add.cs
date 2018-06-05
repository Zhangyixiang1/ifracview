using Data_acquisition.Comm;
using Data_acquisiton;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using ZedGraph;

namespace Data_acquisition
{
    public partial class Frm_add : Form
    {
        DataTable tb;
        DataTable tb1;
        DataTable tb2;

        public Frm_add()
        {
            InitializeComponent();

        }
        #region 事件

        private void Frm_add_Load(object sender, EventArgs e)
        {
            tb1 = new DataTable();
            tb2 = new DataTable();
            DbManager db = new DbManager();
            db.ConnStr = "Data Source=localhost;" +
                            "Initial Catalog=ifracview;User Id=root;Password=hhdq;";
            string sql = "select *  from wellinfo";
            tb = db.ExcuteDataTable(sql);
            //施工的历史信息显示在listbox中
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                listBox1.Items.Add(tb.Rows[i]["date"].ToString() + "---" + tb.Rows[i]["wellname"] + tb.Rows[i]["wellnum"] +
                "第" + tb.Rows[i]["wellstage"] + "段");
            }
            //语言切换
            if (Form_Main.lan == "Chinese") MultiLanguage.LoadLanguage(this, "Chinese");
            else if (Form_Main.lan == "English") MultiLanguage.LoadLanguage(this, "English");
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {


            if (listBox1.SelectedIndex < 0)
            {
                if (Form_Main.lan == "Chinese") MessageBox.Show("请选择需要追加施工的数据包！");
                else MessageBox.Show("Choose the data first！");
            }
            else
            {

                progressBar1.Visible = true;//显示进度条
                btn_OK.Enabled = false;
                btn_del.Enabled = false;
                //获取当前的ID号
                Form_Main.wellinfoID = Convert.ToInt32(tb.Rows[listBox1.SelectedIndex][0]);
                //获取当前的阶段信息
                Form_Main.stageinfo = tb.Rows[listBox1.SelectedIndex][11].ToString();
                Thread th = new Thread(new ThreadStart(add));
                th.Start();



            }
        }

        private void Frm_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (progressBar1.Visible) e.Cancel = true;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form_Main.iscnndatabase)
                {
                    if (Form_Main.lan == "Chinese") MessageBox.Show("请删除前现结束施工！");
                    else MessageBox.Show("Finish the job first！");
                    return;
                }
                if (listBox1.SelectedIndex < 0)

                    if (Form_Main.lan == "Chinese") MessageBox.Show("请选择需要删除的数据包！");
                    else MessageBox.Show("Choose the data first！");

                else
                {   //先删除wellinfo里面的信息
                    DbManager db = new DbManager();
                    db.ConnStr = "Data Source=localhost;" +
                                    "Initial Catalog=ifracview;User Id=root;Password=hhdq;";
                    int index = listBox1.SelectedIndex;
                    string id = tb.Rows[index]["id"].ToString();
                    string sql = "delete from wellinfo where id=" + id;
                    db.ExecuteNonquery(sql);
                    //再删除数据包的表单
                    DbManager db1 = new DbManager();
                    db1.ConnStr = "Data Source=localhost;" +
                                    "Initial Catalog=ifracviewdata;User Id=root;Password=hhdq;";
                    string ori_tbname = listBox1.SelectedItem.ToString();
                    string[] temp_tbanme = ori_tbname.Split('-');
                    string tbname = temp_tbanme[0];
                    DateTime dt = DateTime.Parse(tbname);
                    tbname = "tb" + dt.ToString("u").Replace("-", "").Replace(":", "").Replace(" ", "");
                    string sql1 = "drop table " + tbname;
                    db1.ExecuteNonquery(sql1);
                    if (Form_Main.lan == "Chinese") MessageBox.Show("删除成功！");
                    else MessageBox.Show("Delete Success！");
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        #endregion

        #region 方法

        /// <summary>
        /// 追加施工线程需要执行的方法
        /// </summary>
        private void add()
        {
            try
            {   //处理字符串获得选择的数据库名名
                string ori_tbname = "";
                if (listBox1.InvokeRequired) { listBox1.Invoke(new Action(() => ori_tbname = listBox1.SelectedItem.ToString())); }
                else { ori_tbname = listBox1.SelectedItem.ToString(); }
                string[] temp_tbanme = ori_tbname.Split('-');
                string tbname = temp_tbanme[0];
                DateTime dt = DateTime.Parse(tbname);
                tbname = "tb" + dt.ToString("u").Replace("-", "").Replace(":", "").Replace(" ", "");
                Form_Main.tbname = tbname;
                //以该表单名从数据库请求数据,将数据源以及井队信息传给主界面的paralist和loglist
                DbManager db = new DbManager();
                db.ConnStr = "Data Source=localhost;" +
                                 "Initial Catalog=ifracviewdata;User Id=root;Password=hhdq;";
                string sql = "select stage,value from " + tbname;
                string sql2 = "select stage ,COUNT(*) as count from " + tbname + "  group by stage desc limit 1 ";

                tb1 = db.ExcuteDataTable(sql);   //tb1查询的是表中的json格式数据
                tb2 = db.ExcuteDataTable(sql2);  //tb2查询的最后一个阶段号和阶段运行的秒数

                Dictionary<string, Datamodel> data = new Dictionary<string, Datamodel>();
                //for (int i = 0; i < tb1.Rows.Count; i++)
                //{
                //    string json = tb1.Rows[i]["value"].ToString();
                //    KeyValuePair<string, Datamodel> _data = JsonConvert.DeserializeObject<KeyValuePair<string, Datamodel>>(json);
                //    data.Add(_data.Key, _data.Value);

                //    Form_Main.list_stage.Add(Convert.ToInt16(tb1.Rows[i]["stage"]));
                //}

                //0403用foreach提高查询速度
                if (progressBar1.InvokeRequired)
                {
                    progressBar1.Invoke(new Action(() => this.progressBar1.Maximum = tb1.Rows.Count * 4));
                }
                else
                {
                    this.progressBar1.Maximum = tb1.Rows.Count * 4;
                }
                foreach (DataRow rw in tb1.Rows)
                {

                    string json = rw["value"].ToString();
                    KeyValuePair<string, Datamodel> _data = JsonConvert.DeserializeObject<KeyValuePair<string, Datamodel>>(json);
                    data.Add(_data.Key, _data.Value);
                    if (progressBar1.InvokeRequired)
                    {
                        progressBar1.Invoke(new Action(() => this.progressBar1.Value++));
                    }
                    Form_Main.list_stage.Add(Convert.ToInt16(rw["stage"]));
                }


                //清空现有的list的数据，以及曲线的list,更新井队信息
                //阶段信息
                DateTime time = Convert.ToDateTime("00:00:00");
                DateTime time_stage = Convert.ToDateTime("00:00:00");
                int num_stage = (int)tb2.Rows[0][0];
                time = time.AddSeconds(tb1.Rows.Count);
                time_stage = time_stage.AddSeconds(Convert.ToInt32(tb2.Rows[0][1]));
                Form_Main.num_stage = num_stage;
                Form_Main.num_totalstage = Convert.ToInt16(Comm.Pub_func.GetValue("totalstage"));
                Form_Main.time = time;
                Form_Main.time_stage = time_stage;
                
                if (listBox1.InvokeRequired)
                {
                    listBox1.Invoke(new Action(() =>
                    {
                        Form_Main.wellname = tb.Rows[listBox1.SelectedIndex]["wellname"].ToString();
                        Form_Main.wellnum = tb.Rows[listBox1.SelectedIndex]["wellnum"].ToString();
                        Form_Main.stage_big = tb.Rows[listBox1.SelectedIndex]["wellstage"].ToString();
                    }));

                }
                else
                {
                    Form_Main.wellname = tb.Rows[listBox1.SelectedIndex]["wellname"].ToString();
                    Form_Main.wellnum = tb.Rows[listBox1.SelectedIndex]["wellnum"].ToString();
                    Form_Main.stage_big = tb.Rows[listBox1.SelectedIndex]["wellstage"].ToString();
                }

                ((Form_Main)Application.OpenForms["Form_Main"]).wellinfo_refresh();
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).wellinfo_refresh();
                ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).wellinfo_refresh();

                Form_Main.count = data.Count; Form_Main.iscnndatabase = true;
                foreach (LineItem line in ((Form_Main)Application.OpenForms["Form_Main"]).zedGraphControl1.GraphPane.CurveList)
                {
                    line.Clear();
                }
                foreach (LineItem line in ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.GraphPane.CurveList)
                {
                    line.Clear();
                }
                foreach (LineItem line in ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).zedGraphControl1.GraphPane.CurveList)
                {
                    line.Clear();
                }
                Form_Main.Paralist.Clear(); Form_Main.Loglist.Clear();

                //0605新增，追加施工时统计量要赋个初值
                //blender
                Form_Main.test[54] = data.Values.ElementAt(data.Count - 1).DATA[54];//井口排出阶段量
                Form_Main.test[55] = data.Values.ElementAt(data.Count - 1).DATA[55];//吸入阶段总量
                Form_Main.test[56] = data.Values.ElementAt(data.Count - 1).DATA[56];//排出阶段总量
                Form_Main.test[57] = data.Values.ElementAt(data.Count - 1).DATA[57];//绞龙1阶段总量
                Form_Main.test[58] = data.Values.ElementAt(data.Count - 1).DATA[58];//绞龙2阶段总量
                Form_Main.test[59] = data.Values.ElementAt(data.Count - 1).DATA[59];//绞龙3阶段总量
                Form_Main.test[60] = data.Values.ElementAt(data.Count - 1).DATA[60];//输砂阶段总量
                Form_Main.test[61] = data.Values.ElementAt(data.Count - 1).DATA[61];//液添1阶段总量
                Form_Main.test[62] = data.Values.ElementAt(data.Count - 1).DATA[62];//液添2阶段总量
                Form_Main.test[63] = data.Values.ElementAt(data.Count - 1).DATA[63];//液添3阶段总量
                Form_Main.test[64] = data.Values.ElementAt(data.Count - 1).DATA[64];//液添阶段总量
                Form_Main.test[65] = data.Values.ElementAt(data.Count - 1).DATA[65];//干添1阶段总量
                Form_Main.test[66] = data.Values.ElementAt(data.Count - 1).DATA[66];//干添2阶段总量
                Form_Main.test[67] = data.Values.ElementAt(data.Count - 1).DATA[67];//干添阶段总量
                Form_Main.test[68] = data.Values.ElementAt(data.Count - 1).DATA[68];//井口排出总量
                Form_Main.test[69] = data.Values.ElementAt(data.Count - 1).DATA[69];//吸入总量
                Form_Main.test[70] = data.Values.ElementAt(data.Count - 1).DATA[70];//排出总量
                Form_Main.test[71] = data.Values.ElementAt(data.Count - 1).DATA[71];//蛟龙1总量
                Form_Main.test[72] = data.Values.ElementAt(data.Count - 1).DATA[72];//蛟龙2总量
                Form_Main.test[73] = data.Values.ElementAt(data.Count - 1).DATA[73];//蛟龙3总量
                Form_Main.test[74] = data.Values.ElementAt(data.Count - 1).DATA[74];//蛟龙总量
                Form_Main.test[75] = data.Values.ElementAt(data.Count - 1).DATA[75];//液添1总量
                Form_Main.test[76] = data.Values.ElementAt(data.Count - 1).DATA[76];//液添2总量
                Form_Main.test[77] = data.Values.ElementAt(data.Count - 1).DATA[77];//液添3总量
                Form_Main.test[78] = data.Values.ElementAt(data.Count - 1).DATA[78];//液添总量
                Form_Main.test[79] = data.Values.ElementAt(data.Count - 1).DATA[79];//干添1总量
                Form_Main.test[80] = data.Values.ElementAt(data.Count - 1).DATA[80];//干添2总量
                Form_Main.test[81] = data.Values.ElementAt(data.Count - 1).DATA[81];//干添总量
                //pumps
                for (int i =1; i <=8; i++) {
                    Form_Main.test[104 + (i - 1) * 5] = data.Values.ElementAt(data.Count - 1).DATA[104 + (i - 1) * 5];//阶段量
                    Form_Main.test[105 + (i - 1) * 5] = data.Values.ElementAt(data.Count - 1).DATA[105 + (i - 1) * 5];//累积量
                }
                Form_Main.test[141] = data.Values.ElementAt(data.Count - 1).DATA[141];//泵总排量
                Form_Main.test[142] = data.Values.ElementAt(data.Count - 1).DATA[142];//泵总阶段累计
                Form_Main.test[143] = data.Values.ElementAt(data.Count - 1).DATA[143];//泵总累计                                                                 


                    //刷新曲线
                    ((Form_Main)Application.OpenForms["Form_Main"]).list_add(data);
                if (progressBar1.InvokeRequired)
                {
                    progressBar1.Invoke(new Action(() => progressBar1.Visible = false));
                }
                else progressBar1.Visible = false;
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => this.Close()));
                }
                else { this.Close(); }

            }
            catch (Exception)
            {
                MessageBox.Show("数据包错误，请重新选择数据文件！");
                //throw;
            }

        }

        #endregion

    }
}
