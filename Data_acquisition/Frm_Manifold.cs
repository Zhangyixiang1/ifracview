using Data_acquisiton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Data_acquisition
{
    public partial class Frm_Manifold : Form
    {
        public Frm_Manifold()
        {
            InitializeComponent();
        }

        public void chart_initial()
        {
            //zed
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Fill = new Fill(Color.Black);
            myPane.Chart.Fill = new Fill(Color.Black);
            myPane.Chart.Border.Color = Color.Gray;
            myPane.IsFontsScaled = false;
            //myPane.Border.IsVisible=false;
            // myPane.Legend.IsVisible = false;
            myPane.Border.Width = 1;
            myPane.Border.Color = Color.White;
            //lengend
            myPane.Legend.Fill = new Fill(Color.Black);
            myPane.Legend.FontSpec.FontColor = Color.White;
            //myPane.Title.Text = " ";
            myPane.Title.IsVisible = false;
            //x轴
            myPane.XAxis.Title.Text = "时间";
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Scale.Format = "HH:mm:ss";
            myPane.XAxis.MajorGrid.Color = Color.White;
            myPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            myPane.XAxis.Scale.FontSpec.Size = 15;
            myPane.XAxis.Title.FontSpec.Size = 10;
            myPane.XAxis.Title.FontSpec.FontColor = Color.White;
            myPane.XAxis.Scale.Min = DateTime.Now.ToOADate();
            myPane.XAxis.Scale.Max = DateTime.Now.AddHours(1).ToOADate();
            myPane.XAxis.MajorTic.IsInside = false;
            myPane.XAxis.MinorTic.IsInside = false;
            myPane.XAxis.MajorTic.IsOpposite = false;
            myPane.XAxis.MinorTic.IsOpposite = false;
            myPane.XAxis.MajorTic.Color = Color.White;
            myPane.XAxis.MinorTic.Color = Color.White;
            //   myPane.XAxis.Scale.MajorStep = 5;//X轴大步长为5，也就是显示文字的大间隔
            //y轴
            myPane.YAxis.MajorTic.IsInside = false;
            myPane.YAxis.MajorGrid.Color = Color.White;
            myPane.YAxis.MinorTic.IsInside = false;
            myPane.Y2Axis.MajorTic.IsInside = false;
            myPane.Y2Axis.MajorGrid.Color = Color.White;
            myPane.Y2Axis.MinorTic.IsInside = false;

            // 添加3条曲线
            PointPairList List1 = new PointPairList();
            PointPairList List2 = new PointPairList();
            PointPairList List3 = new PointPairList();


            // 第1条线的标号为3
            LineItem myCurve = myPane.AddCurve("井口油压",
               List1, Color.Red, SymbolType.None);
            myCurve.Line.Width = 1;
            // Fill the symbols with white
            // myCurve.Symbol.Fill = new Fill(Color.White);

            //第2条线的标号为4
            myCurve = myPane.AddCurve("排出流量",
               List2, Color.FromArgb(0, 255, 0), SymbolType.None);
            myCurve.Line.Width = 1;
            // Fill the symbols with white
            // myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.YAxisIndex = 1;

            // 第3条线的标号为2
            myCurve = myPane.AddCurve("砂浓度",
               List3, Color.FromArgb(255, 128, 128), SymbolType.None);
            myCurve.Line.Width = 1;
            // Fill the symbols with white
            //   myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the second Y axis
            myCurve.YAxisIndex = 2;




            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            // 3条y轴的颜色，文字大小等相关属性
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Scale.FontSpec.Size = 15;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Title.FontSpec.Size = 15;
            myPane.YAxis.Color = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MajorTic.Color = Color.Red;
            myPane.YAxis.Scale.Max = 120;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.MajorStep = 30;
            myPane.YAxis.MinorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.Color = Color.Red;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            myPane.YAxis.MajorGrid.IsVisible = true;
            //myPane.YAxis.Scale.Max = int.Parse(paraLine3.Max);
            //myPane.YAxis.Scale.Min = int.Parse(paraLine3.Min);


            //// Enable the Y2 axis Lime
            //myPane.Y2Axis.IsVisible = true;
            //// Make the Y2 axis scale black
            //myPane.Y2Axis.Scale.FontSpec.FontColor = Color.Lime;
            //myPane.Y2Axis.Scale.FontSpec.Size = 15;
            //myPane.Y2Axis.Title.FontSpec.FontColor = Color.Lime;
            //myPane.Y2Axis.Title.FontSpec.Size = 15;
            //myPane.Y2Axis.Color = Color.Lime;
            //// turn off the opposite tics so the Y2 tics don't show up on the Y axis
            //myPane.Y2Axis.MajorTic.IsOpposite = false;
            //myPane.Y2Axis.MajorTic.Color = Color.Lime;
            //myPane.Y2Axis.MinorTic.IsOpposite = false;
            //myPane.Y2Axis.MinorTic.Color = Color.Lime;
            //// Display the Y2 axis grid lines
            //myPane.Y2Axis.MajorGrid.IsVisible = true;
            //// Align the Y2 axis labels so they are flush to the axis
            //myPane.Y2Axis.Scale.Align = AlignP.Inside;
            //myPane.Y2Axis.Scale.Max = int.Parse(paraLine4.Max);
            //myPane.Y2Axis.Scale.Min = int.Parse(paraLine4.Min);

            // Create a second Y Axis, Yellow
            YAxis yAxis3 = new YAxis();
            myPane.YAxisList.Add(yAxis3);
            yAxis3.Scale.FontSpec.FontColor = Color.FromArgb(0, 255, 0);
            yAxis3.Scale.FontSpec.Size = 15;
            yAxis3.Title.FontSpec.FontColor = Color.FromArgb(0, 255, 0);
            yAxis3.Title.FontSpec.Size = 15;
            yAxis3.Color = Color.FromArgb(0, 255, 0);
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis3.MajorTic.IsInside = false;
            yAxis3.MinorTic.IsInside = false;
            yAxis3.MajorTic.IsOpposite = false;
            yAxis3.MajorTic.Color = Color.FromArgb(0, 255, 0);
            yAxis3.MinorTic.IsOpposite = false;
            yAxis3.MinorTic.Color = Color.FromArgb(0, 255, 0);
            yAxis3.Scale.Max = 30;
            yAxis3.Scale.Min = 0;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis3.Scale.Align = AlignP.Inside;
            //yAxis3.Scale.Max = int.Parse(paraLine2.Max);
            //yAxis3.Scale.Min = int.Parse(paraLine2.Min);
            yAxis3.Scale.MagAuto = false;

            // Create a third Y Axis, red
            YAxis yAxis5 = new YAxis();
            myPane.YAxisList.Add(yAxis5);
            yAxis5.Scale.FontSpec.FontColor = Color.FromArgb(255, 128, 128);
            yAxis5.Scale.FontSpec.Size = 15;
            yAxis5.Title.FontSpec.FontColor = Color.FromArgb(255, 128, 128);
            yAxis5.Title.FontSpec.Size = 15;
            yAxis5.Color = Color.FromArgb(255, 128, 128);
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis5.MajorTic.IsInside = false;
            yAxis5.MinorTic.IsInside = false;
            yAxis5.MajorTic.IsOpposite = false;
            yAxis5.MajorTic.Color = Color.FromArgb(255, 128, 128);
            yAxis5.MinorTic.IsOpposite = false;
            yAxis5.MinorTic.Color = Color.FromArgb(255, 128, 128);
            yAxis5.Scale.Max = 10000;
            yAxis5.Scale.Min = 0;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis5.Scale.Align = AlignP.Inside;
            //yAxis5.Scale.Max = int.Parse(paraLine1.Max);
            //yAxis5.Scale.Min = int.Parse(paraLine1.Min);
            yAxis5.Scale.MagAuto = false;



            //新增，y轴不显示名称及零线
            foreach (YAxis y in myPane.YAxisList)
            {
                y.MajorGrid.IsZeroLine = false;
                y.Title.IsVisible = false;
            }
            foreach (Y2Axis y in myPane.Y2AxisList)
            {
                y.MajorGrid.IsZeroLine = false;
                y.Title.IsVisible = false;
            }


            zedGraphControl1.AxisChange();

        }


        private void Frm_Manifold_Load(object sender, EventArgs e)
        {
            chart_initial();

            //语言切换
            MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Manifold"], Form_Main.lan);
            if (Form_Main.lan == "Chinese")
            {
                zedGraphControl1.GraphPane.XAxis.Title.Text = "时间(分钟)";
                zedGraphControl1.GraphPane.CurveList[0].Label.Text = "井口油压";
                zedGraphControl1.GraphPane.CurveList[1].Label.Text = "排出流量";
                zedGraphControl1.GraphPane.CurveList[2].Label.Text = "砂浓度";
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                //datagridview初始化
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "排出";
                //index = dataGridView1.Rows.Add();
                //dataGridView1.Rows[index].Cells[0].Value = "排出";
                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "支撑剂";
                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "干添1";
                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "干添2";
                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "液添1";
                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "液添2";
                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "液添3";
                index = dataGridView1.Rows.Add();
                //液添4暂时没有数据
                dataGridView1.Rows[index].Cells[0].Value = "液添4";
                dataGridView1.Rows[index].Cells[1].Value = "0.0" + " L"; dataGridView1.Rows[index].Cells[2].Value = "0.0" + " L";
                dataGridView1.Columns[0].HeaderText = "名称";
                dataGridView1.Columns[0].HeaderText = "阶段";
                dataGridView1.Columns[0].HeaderText = "总量";

            }
            else if (Form_Main.lan == "English")
            {
                zedGraphControl1.GraphPane.XAxis.Title.Text = "Time(min)";
                zedGraphControl1.GraphPane.CurveList[0].Label.Text = "Tub Pressure";
                zedGraphControl1.GraphPane.CurveList[1].Label.Text = "Discharge Rate";
                zedGraphControl1.GraphPane.CurveList[2].Label.Text = "Proppant Conc.";
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
                //datagridview初始化
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "Discharge";
                //index = dataGridView1.Rows.Add();
                //dataGridView1.Rows[index].Cells[0].Value = "排出";
                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "Proppant";
                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "DryAdd1";
                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "DryAdd2";
                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "Chem1";
                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "Chem2";
                index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = "Chem3";
                index = dataGridView1.Rows.Add();
                //液添4暂时没有数据
                dataGridView1.Rows[index].Cells[0].Value = "Chem4";
                dataGridView1.Rows[index].Cells[1].Value = "0.0" + " L"; dataGridView1.Rows[index].Cells[2].Value = "0.0" + " L";
                dataGridView1.Columns[0].HeaderText = "Name";
                dataGridView1.Columns[0].HeaderText = "Stage";
                dataGridView1.Columns[0].HeaderText = "Total";
            }


            // dataGridView1.DefaultCellStyle.BackColor = Color.White;
            // dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(218, 226, 230);
            dataGridView1.ClearSelection();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                refresh(this);
                //刷新阶段信息和添加剂信息
                if (Form_Main.isSync)
                {
                    int percent1 = Convert.ToInt16(Form_Main.value_blender.GetValue(589));
                    int percent2 = Convert.ToInt16(Form_Main.value_blender.GetValue(631));
                    if (percent1 > 100) percent1 = 100;
                    if (percent2 > 100) percent2 = 100;
                    radProgressBar1.Value1 = percent1; radProgressBar1.Text = percent1 + "%";
                    radProgressBar2.Value1 = percent2; radProgressBar2.Text = percent2 + "%";
                }
                //刷新液位
                // lbl_level.Text = trans_point(Form_Main.value_blender.GetValue(632))+"%"; 
                level1.Refresh(Convert.ToDouble(Form_Main.value_blender.GetValue(632)));
                //刷新grdiview信息
                ////吸入
                //dataGridView1.Rows[0].Cells[1].Value = trans_point(Form_Main.value_blender.GetValue(8)) + " m3/min";//速率
                //dataGridView1.Rows[0].Cells[2].Value = trans_point(Form_Main.value_blender.GetValue(39)) + " m3";//总量
                //dataGridView1.Rows[0].Cells[1].Value = trans_point(Form_Main.value_blender.GetValue(9)) + " m3";//阶段
                //dataGridView1.Rows[0].Cells[2].Value = trans_point(Form_Main.value_blender.GetValue(40)) + " m3";//总量

                //井口排出量
                dataGridView1.Rows[0].Cells[1].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[54]) + " m3";//阶段
                dataGridView1.Rows[0].Cells[2].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[68]) + " m3";//总量
                dataGridView1.Rows[0].Cells[1].Style.ForeColor = Color.FromArgb(0, 176, 240);
                dataGridView1.Rows[0].Cells[2].Style.ForeColor = Color.FromArgb(0, 176, 240);
                //支撑剂
                dataGridView1.Rows[1].Cells[1].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[60]) + " kg";//阶段
                dataGridView1.Rows[1].Cells[2].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[74]) + " kg";//总量
                dataGridView1.Rows[1].Cells[1].Style.ForeColor = Color.FromArgb(234, 150, 81);
                dataGridView1.Rows[1].Cells[2].Style.ForeColor = Color.FromArgb(234, 150, 81);
                //干添1
                dataGridView1.Rows[2].Cells[1].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[65]) + " kg";//阶段
                dataGridView1.Rows[2].Cells[2].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[79]) + " kg";//总量
                dataGridView1.Rows[2].Cells[1].Style.ForeColor = Color.FromArgb(255, 198, 26);
                dataGridView1.Rows[2].Cells[2].Style.ForeColor = Color.FromArgb(255, 198, 26);
                //干添2
                dataGridView1.Rows[3].Cells[1].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[66]) + " kg";//阶段
                dataGridView1.Rows[3].Cells[2].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[80]) + " kg";//总量
                dataGridView1.Rows[3].Cells[1].Style.ForeColor = Color.FromArgb(255, 198, 26);
                dataGridView1.Rows[3].Cells[2].Style.ForeColor = Color.FromArgb(255, 198, 26);
                //液添1
                dataGridView1.Rows[4].Cells[1].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[61]) + " L";//阶段
                dataGridView1.Rows[4].Cells[2].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[75]) + " L";//总量
                dataGridView1.Rows[4].Cells[1].Style.ForeColor = Color.FromArgb(185, 139, 0);
                dataGridView1.Rows[4].Cells[2].Style.ForeColor = Color.FromArgb(185, 139, 0);
                //液添2
                dataGridView1.Rows[5].Cells[1].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[62]) + " L";//阶段
                dataGridView1.Rows[5].Cells[2].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[76]) + " L";//总量
                dataGridView1.Rows[5].Cells[1].Style.ForeColor = Color.FromArgb(185, 139, 0);
                dataGridView1.Rows[5].Cells[2].Style.ForeColor = Color.FromArgb(185, 139, 0);
                //液添3
                dataGridView1.Rows[6].Cells[1].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[63]) + " L";//阶段
                dataGridView1.Rows[6].Cells[2].Value = trans_point(Form_Main.Paralist.Last().Value.DATA[77]) + " L";//总量
                dataGridView1.Rows[6].Cells[1].Style.ForeColor = Color.FromArgb(185, 139, 0);
                dataGridView1.Rows[6].Cells[2].Style.ForeColor = Color.FromArgb(185, 139, 0);
                dataGridView1.Rows[7].Cells[1].Style.ForeColor = Color.FromArgb(185, 139, 0);
                dataGridView1.Rows[7].Cells[2].Style.ForeColor = Color.FromArgb(185, 139, 0);
                //刷新曲线的值

                CurveList list = zedGraphControl1.GraphPane.CurveList;
                //0井口油压 1排出流量 2砂浓度
                double x = DateTime.Now.ToOADate();
                list[0].AddPoint(new PointPair(x, Form_Main.Paralist.Last().Value.DATA[31]));
                list[1].AddPoint(new PointPair(x, Form_Main.Paralist.Last().Value.DATA[34]));
                list[2].AddPoint(new PointPair(x, Form_Main.Paralist.Last().Value.DATA[35]));
                //大于1消失，轴移动
                if (list[0].Points.Count > 3600)
                {
                    DateTime ts = DateTime.FromOADate(zedGraphControl1.GraphPane.XAxis.Scale.Min);
                    DateTime te = DateTime.FromOADate(zedGraphControl1.GraphPane.XAxis.Scale.Max);
                    zedGraphControl1.GraphPane.XAxis.Scale.Min = ts.AddSeconds(1).ToOADate();
                    zedGraphControl1.GraphPane.XAxis.Scale.Max = te.AddSeconds(1).ToOADate();
                }
                if (list[0].Points.Count > 4000) foreach (CurveItem line in list)
                    {
                        line.RemovePoint(0);
                    }
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
            catch
            {


            }


        }
        private void refresh(Control container)
        {
            try
            {
                foreach (Control ctr in container.Controls)
                {
                    if (ctr is System.Windows.Forms.Label)
                    {
                        System.Windows.Forms.Label lbl = ctr as System.Windows.Forms.Label;
                        if (lbl.Tag != null)
                        {
                            if (lbl.Tag.ToString() == "HH")
                                if (lbl.TabIndex == 37) { lbl.Text = Form_Main.Paralist.Last().Value.DATA[lbl.TabIndex].ToString("#0.00"); }
                                else if (lbl.TabIndex == 36) { lbl.Text = Form_Main.Paralist.Last().Value.DATA[lbl.TabIndex].ToString("#0.000"); }
                                else { lbl.Text = Form_Main.Paralist.Last().Value.DATA[lbl.TabIndex].ToString("#0.0"); }

                        }
                    }
                    else if (ctr is Panel)
                    {
                        Panel pan = ctr as Panel;
                        if (pan.Tag != null)
                        {
                            if (pan.Tag.ToString() == "HH")
                            {
                                double data = Form_Main.Paralist.Last().Value.DATA[pan.TabIndex];
                                if (data > 0.1) pan.BackColor = Color.FromArgb(192, 0, 0);
                                else pan.BackColor = Color.FromArgb(0, 176, 240);
                            }
                        }
                        refresh(ctr);
                    }
                }
            }
            catch
            {


            }


        }
        /// <summary>
        /// 转换成两位字符串
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string trans_point(object item)
        {
            double data = Convert.ToDouble(item);
            return data.ToString("#0.0");

        }

        /// <summary>
        /// 更新井号信息
        /// </summary>
        public void wellinfo_refresh()
        {
            if (lbl_wellinfo.InvokeRequired) { lbl_wellinfo.Invoke(new Action(() => lbl_wellinfo.Text = Form_Main.wellname)); }
            else { lbl_wellinfo.Text = Form_Main.wellname; }

            if (lbl_wellnum.InvokeRequired) { lbl_wellnum.Invoke(new Action(() => lbl_wellnum.Text = Form_Main.wellnum)); }
            else { lbl_wellnum.Text = Form_Main.wellnum; }

            if (lbl_stagebig.InvokeRequired) { lbl_stagebig.Invoke(new Action(() => lbl_stagebig.Text = Form_Main.stage_big)); }
            else { lbl_stagebig.Text = Form_Main.stage_big; }

            if (lbl_stage.InvokeRequired) { lbl_stage.Invoke(new Action(() => lbl_stage.Text = Form_Main.num_stage + "/" + Form_Main.num_totalstage)); }
            else { lbl_stage.Text = Form_Main.num_stage + "/" + Form_Main.num_totalstage; }


        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel4.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel30.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel20.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel21.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel2.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel11.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel12.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel13.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel14.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel7.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel8.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel9.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel10.ClientRectangle,
     Color.White, 1, ButtonBorderStyle.Solid, //左边
     Color.White, 1, ButtonBorderStyle.Solid, //上边
     Color.White, 1, ButtonBorderStyle.Solid, //右边
     Color.White, 1, ButtonBorderStyle.Solid);//底边
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel3.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }


    }
}
