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

        private void Frm_Manifold_Load(object sender, EventArgs e)
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
            myPane.XAxis.Title.Text = "时间(分钟)";
            myPane.XAxis.MajorGrid.Color = Color.White;
            myPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            myPane.XAxis.Scale.FontSpec.Size = 15;
            myPane.XAxis.Title.FontSpec.Size = 10;
            myPane.XAxis.Title.FontSpec.FontColor = Color.White;
            myPane.XAxis.Scale.Min = 0; //X轴最小值0
            myPane.XAxis.Scale.Max = 30; //X轴最大30
            myPane.XAxis.MajorTic.IsInside = false;
            myPane.XAxis.MinorTic.IsInside = false;
            myPane.XAxis.MajorTic.IsOpposite = false;
            myPane.XAxis.MinorTic.IsOpposite = false;
            myPane.XAxis.MajorTic.Color = Color.White;
            myPane.XAxis.MinorTic.Color = Color.White;
            myPane.XAxis.Scale.MajorStep = 5;//X轴大步长为5，也就是显示文字的大间隔
            //y轴
            myPane.YAxis.MajorTic.IsInside = false;
            myPane.YAxis.MajorGrid.Color = Color.White;
            myPane.YAxis.MinorTic.IsInside = false;
            myPane.Y2Axis.MajorTic.IsInside = false;
            myPane.Y2Axis.MajorGrid.Color = Color.White;
            myPane.Y2Axis.MinorTic.IsInside = false;

            // 添加6条曲线
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
               List2, Color.White, SymbolType.None);
            myCurve.Line.Width = 1;
            // Fill the symbols with white
            // myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
           

            // 第3条线的标号为2
            myCurve = myPane.AddCurve("砂浓度",
               List3, Color.Yellow, SymbolType.None);
            myCurve.Line.Width = 1;
            // Fill the symbols with white
            //   myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the second Y axis
            myCurve.YAxisIndex = 1;

            


            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            // 6条y轴的颜色，文字大小等相关属性
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Scale.FontSpec.Size = 15;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Title.FontSpec.Size = 15;
            myPane.YAxis.Color = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MajorTic.Color = Color.Red;
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
            yAxis3.Scale.FontSpec.FontColor = Color.White;
            yAxis3.Scale.FontSpec.Size = 15;
            yAxis3.Title.FontSpec.FontColor = Color.White;
            yAxis3.Title.FontSpec.Size = 15;
            yAxis3.Color = Color.White;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis3.MajorTic.IsInside = false;
            yAxis3.MinorTic.IsInside = false;
            yAxis3.MajorTic.IsOpposite = false;
            yAxis3.MajorTic.Color = Color.White;
            yAxis3.MinorTic.IsOpposite = false;
            yAxis3.MinorTic.Color = Color.White;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis3.Scale.Align = AlignP.Inside;
            //yAxis3.Scale.Max = int.Parse(paraLine2.Max);
            //yAxis3.Scale.Min = int.Parse(paraLine2.Min);


            // Create a third Y Axis, red
            YAxis yAxis5 = new YAxis();
            myPane.YAxisList.Add(yAxis5);
            yAxis5.Scale.FontSpec.FontColor = Color.Yellow;
            yAxis5.Scale.FontSpec.Size = 15;
            yAxis5.Title.FontSpec.FontColor = Color.Yellow;
            yAxis5.Title.FontSpec.Size = 15;
            yAxis5.Color = Color.Yellow;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis5.MajorTic.IsInside = false;
            yAxis5.MinorTic.IsInside = false;
            yAxis5.MajorTic.IsOpposite = false;
            yAxis5.MajorTic.Color = Color.Yellow;
            yAxis5.MinorTic.IsOpposite = false;
            yAxis5.MinorTic.Color = Color.Yellow;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis5.Scale.Align = AlignP.Inside;
            //yAxis5.Scale.Max = int.Parse(paraLine1.Max);
            //yAxis5.Scale.Min = int.Parse(paraLine1.Min);


          

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
            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = "泵累计";
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
            dataGridView1.Rows[index].Cells[1].Value = "0.0" + " m3"; dataGridView1.Rows[index].Cells[2].Value = "0.0" + " m3";
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(218, 226, 230);
            dataGridView1.ClearSelection();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                refresh(this);
                //刷新阶段信息和添加剂信息
                int percent1 = Convert.ToInt16(Form_Main.value_blender.GetValue(589));
                int percent2 = Convert.ToInt16(Form_Main.value_blender.GetValue(631));
                radProgressBar1.Value1 = percent1; radProgressBar1.Text = percent1 + "%";
                radProgressBar2.Value1 = percent1; radProgressBar2.Text = percent2 + "%";
                //刷新grdiview信息
                ////吸入
                //dataGridView1.Rows[0].Cells[1].Value = trans_point(Form_Main.value_blender.GetValue(8)) + " m3/min";//速率
                //dataGridView1.Rows[0].Cells[2].Value = trans_point(Form_Main.value_blender.GetValue(39)) + " m3";//总量
                //泵累计
                dataGridView1.Rows[0].Cells[1].Value = trans_point(Form_Main.value_blender.GetValue(9)) + " m3";//阶段
                dataGridView1.Rows[0].Cells[2].Value = trans_point(Form_Main.value_blender.GetValue(40)) + " m3";//总量
                //支撑剂
                dataGridView1.Rows[1].Cells[1].Value = trans_point(Form_Main.value_blender.GetValue(16)) + " kg";//阶段
                dataGridView1.Rows[1].Cells[2].Value = trans_point(Form_Main.value_blender.GetValue(44)) + " kg";//总量
                //干添1
                dataGridView1.Rows[2].Cells[1].Value = trans_point(Form_Main.value_blender.GetValue(21)) + " kg";//阶段
                dataGridView1.Rows[2].Cells[2].Value = trans_point(Form_Main.value_blender.GetValue(49)) + " kg";//总量
                //干添2
                dataGridView1.Rows[3].Cells[1].Value = trans_point(Form_Main.value_blender.GetValue(22)) + " kg";//阶段
                dataGridView1.Rows[3].Cells[2].Value = trans_point(Form_Main.value_blender.GetValue(50)) + " kg";//总量
                //液添1
                dataGridView1.Rows[4].Cells[1].Value = trans_point(Form_Main.value_blender.GetValue(17)) + " m3";//阶段
                dataGridView1.Rows[4].Cells[2].Value = trans_point(Form_Main.value_blender.GetValue(45)) + " m3";//总量
                //液添2
                dataGridView1.Rows[5].Cells[1].Value = trans_point(Form_Main.value_blender.GetValue(18)) + " m3";//阶段
                dataGridView1.Rows[5].Cells[2].Value = trans_point(Form_Main.value_blender.GetValue(46)) + " m3";//总量
                //液添3
                dataGridView1.Rows[6].Cells[1].Value = trans_point(Form_Main.value_blender.GetValue(19)) + " m3";//阶段
                dataGridView1.Rows[6].Cells[2].Value = trans_point(Form_Main.value_blender.GetValue(47)) + " m3";//总量
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
                                lbl.Text = Form_Main.Paralist.Last().Value.DATA[lbl.TabIndex].ToString("#0.00");
                        }
                    }
                    else if (ctr is Panel)
                    {
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
    }
}
