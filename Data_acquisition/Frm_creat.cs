﻿using Data_acquisiton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Data_acquisition
{
    public partial class Frm_creat : Form
    {
        public Frm_creat()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {

                DbManager db = new DbManager();
                db.ConnStr = "Data Source=localhost;" +
                           "Initial Catalog=ifracview;User Id=root;Password=hhdq;";
                //验证输入框是否为空,若为空用null填充,
                string sql = "insert into wellinfo values(0,@txt_wellname,@txt_wellnum,@txt_stage,@datetime,@txt_clientname," +
                "@txt_representname,@txt_constructionname,@txt_cstrepname,@txt_leadername,@txt_comment,@stageinfo)";
                List<MySqlParameter> Paramter = new List<MySqlParameter>();
                if (string.IsNullOrEmpty(txt_wellname.Text)) Paramter.Add(new MySqlParameter("@txt_wellname", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_wellname", txt_wellname.Text));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_wellnum", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_wellnum", txt_wellnum.Text));
                if (string.IsNullOrEmpty(txt_stage.Text)) Paramter.Add(new MySqlParameter("@txt_stage", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_stage", txt_stage.Text));
                Paramter.Add(new MySqlParameter("@datetime", dateTimePicker1.Value.ToString()));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_clientname", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_clientname", txt_clientname.Text));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_representname", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_representname", txt_representname.Text));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_constructionname", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_constructionname", txt_constructionname.Text));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_cstrepname", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_cstrepname", txt_cstrepname.Text));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_leadername", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_leadername", txt_leadername.Text));
                if (string.IsNullOrEmpty(txt_wellnum.Text)) Paramter.Add(new MySqlParameter("@txt_comment", DBNull.Value));
                else Paramter.Add(new MySqlParameter("@txt_comment", txt_comment.Text));
                Paramter.Add(new MySqlParameter("@stageinfo", Form_Main.stageinfo));
                db.ExecuteNonquery(sql, Paramter.ToArray());
                //获得自增ID号
                string sql2 = " SELECT LAST_INSERT_ID() ";
                Form_Main.wellinfoID = Convert.ToInt32(db.ExecuteScalar(sql2));
                string msg = "创建施工成功！";
                if (Form_Main.lan == "English") msg = "Creat success!";
                DialogResult result = MessageBox.Show(msg);
                if (result == DialogResult.OK)
                {
                    //在数据库生成一个以时间为名的表单用以存储实时数据
                    DbManager db1 = new DbManager();
                    db1.ConnStr = "Data Source=localhost;" +
                               "Initial Catalog=ifracviewdata;User Id=root;Password=hhdq;";
                    string tbname = dateTimePicker1.Value.ToString();
                    MySqlParameter par = new MySqlParameter("@title", MySqlDbType.VarChar);
                    string tb_name = "tb" + dateTimePicker1.Value.ToString("u").Replace("-", "").Replace(":", "").Replace(" ", "");
                    par.Value = tb_name;
                    db1.ExecuteProcNonQuery("creatdb", par);
                    //创建成功后，将值传给主界面并刷新显示井队信息信息
                    Form_Main.iscnndatabase = true;
                    Form_Main.tbname = tb_name;
                    Form_Main.wellname = txt_wellname.Text;
                    Form_Main.wellnum = txt_wellnum.Text;
                    Form_Main.stage_big = txt_stage.Text;

                    ((Form_Main)Application.OpenForms["Form_Main"]).wellinfo_refresh();
                    ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).wellinfo_refresh();
                    ((Frm_Realtrend2)Application.OpenForms["Frm_Realtrend2"]).wellinfo_refresh();

                    //0522修改，保存最后一次输入值到xml文件，启动下一个界面
                    xmlsave();

                    //阶段同步按钮
                    if (checkBox1.Checked)
                    {
                        Form_Main.isSync = true;

                        if (!Form_Main.isRights)
                        {
                            MessageBox.Show("操作权限在混砂撬，阶段记录模式切换到手动！");
                            Form_Main.isSync = false;
                        }
                    }
                    else Form_Main.isSync = false;
                    //保存井口数据来源
                    Form_Main.wellDataIndex[0] = cmb_wellpre.SelectedIndex;
                    Form_Main.wellDataIndex[1] = cmb_wellflow.SelectedIndex;
                    Form_Main.wellDataIndex[2] = cmb_wellden.SelectedIndex;
                    Form_Main.wellDataIndex[3] = cmb_wellpipe.SelectedIndex;
                    Frm_Chnset frm = new Frm_Chnset();
                    frm.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void Frm_creat_Load(object sender, EventArgs e)
        {
            //语言切换
            cmb_wellpre.Items.Clear(); cmb_wellpipe.Items.Clear(); cmb_wellflow.Items.Clear(); cmb_wellden.Items.Clear();

            if (Form_Main.lan == "Chinese")
            {
                MultiLanguage.LoadLanguage(this, "Chinese");
                cmb_wellpre.Items.AddRange(new object[]{"压力1","压力2","压力3","压力4","压裂泵1","压力泵2","压裂泵3","压裂泵4","压裂泵5","压力泵6","压力泵7","压力泵8"});
                cmb_wellpipe.Items.AddRange(new object[]{"压力1","压力2","压力3","压力4"});
                cmb_wellflow.Items.AddRange(new object[]{"流量计1","流量计2","压裂泵","混砂橇"});
                cmb_wellden.Items.AddRange(new object[]{"密度计1","密度计2","密度计3","密度计4","混砂橇"});
            }
            else if (Form_Main.lan == "English")
            {
                MultiLanguage.LoadLanguage(this, "English");
                cmb_wellpre.Items.AddRange(new object[] { "Pressure1", "Pressure2", "Pressure3", "Pressure4", "Pump1", "Pump2", "Pump3", "Pump4", "Pump5", "Pump6", "Pump7", "Pump8" });
                cmb_wellpipe.Items.AddRange(new object[] { "Pressure1", "Pressure2", "Pressure3", "Pressure4" });
                cmb_wellflow.Items.AddRange(new object[] { "Flow1", "Flow2", "Pump", "Blender" });
                cmb_wellden.Items.AddRange(new object[] { "Density1", "Density2", "Density3", "Density4", "Blender" });

            }
            //0522添加，除了段号和时间，其他信息只要输入一次就记忆下来
            xmlload();
            //0512读取设备IP
            txb_daq.Text = Comm.Pub_func.GetValue("daq");
            txb_f1.Text = Form_Main.value_state.GetValue(1).ToString().Substring(0, Form_Main.value_state.GetValue(1).ToString().Length - 4);
            txb_f2.Text = Form_Main.value_state.GetValue(3).ToString().Substring(0, Form_Main.value_state.GetValue(3).ToString().Length - 4);
            txb_f3.Text = Form_Main.value_state.GetValue(5).ToString().Substring(0, Form_Main.value_state.GetValue(5).ToString().Length - 4);
            txb_f4.Text = Form_Main.value_state.GetValue(7).ToString().Substring(0, Form_Main.value_state.GetValue(7).ToString().Length - 4);
            txb_f5.Text = Form_Main.value_state.GetValue(9).ToString().Substring(0, Form_Main.value_state.GetValue(9).ToString().Length - 4);
            txb_f6.Text = Form_Main.value_state.GetValue(11).ToString().Substring(0, Form_Main.value_state.GetValue(11).ToString().Length - 4);
            txb_f7.Text = Form_Main.value_state.GetValue(13).ToString().Substring(0, Form_Main.value_state.GetValue(13).ToString().Length - 4);
            txb_f8.Text = Form_Main.value_state.GetValue(15).ToString().Substring(0, Form_Main.value_state.GetValue(15).ToString().Length - 4);
            txb_b.Text = Form_Main.value_state.GetValue(17).ToString().Substring(0, Form_Main.value_state.GetValue(17).ToString().Length - 4);
            //判断通讯，同步按钮是否可钩选
            if (Convert.ToBoolean(Form_Main.value_state.GetValue(18)))
                checkBox1.Enabled = false;
        }

        //读取xml
        private void xmlload()
        {
            XmlDocument doc = new XmlDocument();
            string path = Application.StartupPath + "\\Config\\preference.xml";
            doc.Load(path);
            XmlNode root = doc.DocumentElement;
            XmlNodeList list = root.SelectNodes("Form[Name='Frm_creat']//Set");
            txt_wellname.Text = list[0].Attributes["wellname"].Value;
            txt_wellnum.Text = list[0].Attributes["wellnum"].Value;
            txt_clientname.Text = list[0].Attributes["clientname"].Value;
            txt_representname.Text = list[0].Attributes["clientrep"].Value;
            txt_constructionname.Text = list[0].Attributes["cstunit"].Value;
            txt_cstrepname.Text = list[0].Attributes["cstrep"].Value;
            txt_leadername.Text = list[0].Attributes["cstcomm"].Value;
            cmb_wellpre.SelectedIndex = Convert.ToInt16(list[0].Attributes["wellpre"].Value);
            cmb_wellflow.SelectedIndex = Convert.ToInt16(list[0].Attributes["wellflow"].Value);
            cmb_wellden.SelectedIndex = Convert.ToInt16(list[0].Attributes["wellden"].Value);
            cmb_wellpipe.SelectedIndex = Convert.ToInt16(list[0].Attributes["wellpipe"].Value);
        }

        //保存xml
        private void xmlsave()
        {
            XmlDocument doc = new XmlDocument();
            string path = Application.StartupPath + "\\Config\\preference.xml";
            doc.Load(path);
            XmlNode root = doc.DocumentElement;
            XmlNodeList list = root.SelectNodes("Form[Name='Frm_creat']//Set");
            list[0].Attributes["wellname"].Value = txt_wellname.Text;
            list[0].Attributes["wellnum"].Value = txt_wellnum.Text;
            list[0].Attributes["clientname"].Value = txt_clientname.Text;
            list[0].Attributes["clientrep"].Value = txt_representname.Text;
            list[0].Attributes["cstunit"].Value = txt_constructionname.Text;
            list[0].Attributes["cstrep"].Value = txt_cstrepname.Text;
            list[0].Attributes["cstcomm"].Value = txt_leadername.Text;
            list[0].Attributes["wellpre"].Value = cmb_wellpre.SelectedIndex.ToString();
            list[0].Attributes["wellflow"].Value = cmb_wellflow.SelectedIndex.ToString();
            list[0].Attributes["wellden"].Value = cmb_wellden.SelectedIndex.ToString();
            list[0].Attributes["wellpipe"].Value = cmb_wellpipe.SelectedIndex.ToString();
            doc.Save(path);
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

        private void button1_Click(object sender, EventArgs e)
        {
            tabPage2.Select();
        }


    }
}
