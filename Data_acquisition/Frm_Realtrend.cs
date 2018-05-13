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
using ZedGraph;
namespace Data_acquisition
{
    public partial class Frm_Realtrend : Form
    {
        #region 方法
        public Frm_Realtrend()
        {
            InitializeComponent();

        }
        /// <summary>
        /// 曲线刷新
        /// </summary>
        /// <param name="isshow">曲线是否显示</param>
        /// <param name="num_line">曲线编号</param>
        public void trend_refresh(bool isshow, string num_line)
        {
            string num = num_line.Substring(num_line.Length - 1);
            //对应编号的曲线重绘，包括上下限和编号
            switch (num)
            {
                case "1":
                    zedGraphControl1.GraphPane.CurveList[4].IsVisible = isshow;
                    zedGraphControl1.GraphPane.YAxisList[2].IsVisible = isshow;
                    break;
                case "2":
                    zedGraphControl1.GraphPane.CurveList[2].IsVisible = isshow;
                    zedGraphControl1.GraphPane.YAxisList[1].IsVisible = isshow;
                    break;
                case "3":
                    zedGraphControl1.GraphPane.CurveList[0].IsVisible = isshow;
                    zedGraphControl1.GraphPane.YAxisList[0].IsVisible = isshow;
                    break;
                case "4":
                    zedGraphControl1.GraphPane.CurveList[1].IsVisible = isshow;
                    zedGraphControl1.GraphPane.Y2AxisList[0].IsVisible = isshow;
                    break;
                case "5":
                    zedGraphControl1.GraphPane.CurveList[3].IsVisible = isshow;
                    zedGraphControl1.GraphPane.Y2AxisList[1].IsVisible = isshow;
                    break;
                case "6":
                    zedGraphControl1.GraphPane.CurveList[5].IsVisible = isshow;
                    zedGraphControl1.GraphPane.Y2AxisList[2].IsVisible = isshow;
                    break;
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
        /// <summary>
        /// 读取xml偏好配置文件
        /// </summary>
        public void xml_load()
        {
            try
            {
                string path = Application.StartupPath + "\\Config\\preference.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode root = doc.DocumentElement;
                //先读取paraLine控件的信息
                XmlNodeList nodeList = root.SelectNodes("Form[Name='Frm_Realtrend']//Controlsline//Control");
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is ParaLine)
                    {
                        ParaLine ctr = ctrl as ParaLine;
                        foreach (XmlNode node in nodeList)
                        {
                            if (ctr.Name == node.SelectSingleNode("@name").InnerText)
                            {
                                //ctr.Tagname = node.SelectSingleNode("@tagname").InnerText;
                                //ctr.Tagname_EN = node.SelectSingleNode("@tagname_en").InnerText;
                                //ctr.Min = node.SelectSingleNode("@min").InnerText;
                                //ctr.Max = node.SelectSingleNode("@max").InnerText;
                                //ctr.Unit = node.SelectSingleNode("@unit").InnerText;
                                ctr.Tag = node.SelectSingleNode("@index").InnerText;
                                //0513修改，信息从para里面读
                                ctr.Tag = node.SelectSingleNode("@index").InnerText;
                                int index = Convert.ToInt16(ctr.Tag);
                                ctr.Tagname = Form_Main.dt_para.Rows[index - 1]["中文名称"].ToString();
                                ctr.Tagname_EN = Form_Main.dt_para.Rows[index - 1]["英文名称"].ToString();
                                ctr.Min = Form_Main.dt_para.Rows[index - 1]["最小值"].ToString();
                                ctr.Max = Form_Main.dt_para.Rows[index - 1]["最大值"].ToString();
                                ctr.Unit = Form_Main.dt_para.Rows[index - 1]["公制单位"].ToString();
                                if (Form_Main.Unit == 1) ctr.Unit = Form_Main.dt_para.Rows[index - 1]["英制单位"].ToString();
                                ctr.Color = Comm.ReadColor.getcolor(node.SelectSingleNode("@color").InnerText);
                                //if (Form_Main.Unit == 1) ctr.Unit = Form_Main.factor_unit[Convert.ToInt16(ctr.Tag)];
                                ctr.refresh();

                            }

                        }
                    }
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 初始化图表控件
        /// </summary>
        public void chart_initial()
        {
            zedGraphControl1.IsShowContextMenu = false;
            zedGraphControl1.IsEnableHPan = false; zedGraphControl1.IsEnableVPan = false;
            zedGraphControl1.IsEnableHZoom = false; zedGraphControl1.IsEnableZoom = false;
            GraphPane myPane = zedGraphControl1.GraphPane;
            // myPane.Fill = new Fill(Color.FromArgb(28, 29, 31));
            myPane.Fill = new Fill(Color.Black);
            myPane.Chart.Fill = new Fill(Color.Black);
            myPane.IsFontsScaled = false;
            myPane.Border.Color = Color.White;
            myPane.Chart.Border.Color = Color.Gray;
            // Set the titles and axis labels
            myPane.Legend.IsVisible = false;
            myPane.Title.Text = " ";
            //x轴
            myPane.XAxis.Title.Text = "时间(分钟)";
            myPane.XAxis.MajorGrid.Color = Color.White;
            myPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            myPane.XAxis.Scale.FontSpec.Size = 15;
            myPane.XAxis.Title.FontSpec.Size = 15;
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
            myPane.XAxis.MajorGrid.IsVisible = true;
            //y轴
            myPane.YAxis.MajorTic.IsInside = false;
            myPane.YAxis.MajorGrid.Color = Color.White;
            myPane.YAxis.MinorTic.IsInside = false;
            myPane.Y2Axis.MajorTic.IsInside = false;
            myPane.Y2Axis.MajorGrid.Color = Color.White;
            myPane.Y2Axis.MinorTic.IsInside = false;

            // Make up some data points based on the Sine function
            PointPairList List1 = new PointPairList();
            PointPairList List2 = new PointPairList();
            PointPairList List3 = new PointPairList();
            PointPairList List4 = new PointPairList();
            PointPairList List5 = new PointPairList();
            PointPairList List6 = new PointPairList();


            // 根据配置信息，生成曲线坐标轴的样式
            LineItem myCurve = myPane.AddCurve(paraLine3.Tagname,
               List1, paraLine3.Color, SymbolType.None);
            myCurve.Line.Width = 1;

            myCurve = myPane.AddCurve(paraLine4.Tagname,
               List2, paraLine4.Color, SymbolType.None);
            myCurve.Line.Width = 1;
            myCurve.IsY2Axis = true;


            myCurve = myPane.AddCurve(paraLine2.Tagname,
               List3, paraLine2.Color, SymbolType.None);
            myCurve.Line.Width = 1;
            myCurve.YAxisIndex = 1;

            myCurve = myPane.AddCurve(paraLine5.Tagname,
    List4, paraLine5.Color, SymbolType.None);
            myCurve.Line.Width = 1;
            myCurve.IsY2Axis = true;
            myCurve.YAxisIndex = 1;

            myCurve = myPane.AddCurve(paraLine1.Tagname,
               List5, paraLine1.Color, SymbolType.None);
            myCurve.Line.Width = 1;
            myCurve.YAxisIndex = 2;

            myCurve = myPane.AddCurve(paraLine6.Tagname,
       List6, paraLine6.Color, SymbolType.None);
            myCurve.Line.Width = 1;
            myCurve.IsY2Axis = true;
            myCurve.YAxisIndex = 2;

            // Make the Y axis 
            myPane.YAxis.Scale.FontSpec.FontColor = paraLine3.Color;
            myPane.YAxis.Scale.FontSpec.Size = 15;
            myPane.YAxis.Title.FontSpec.FontColor = paraLine3.Color;
            myPane.YAxis.Title.FontSpec.Size = 15;
            myPane.YAxis.Color = paraLine3.Color;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MajorTic.Color = paraLine3.Color;
            myPane.YAxis.MinorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.Color = paraLine3.Color;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            myPane.YAxis.Scale.Max = int.Parse(paraLine3.Max);
            myPane.YAxis.Scale.Min = int.Parse(paraLine3.Min);

            // Enable the Y2 axis 
            myPane.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale black
            myPane.Y2Axis.Scale.FontSpec.FontColor = paraLine4.Color;
            myPane.Y2Axis.Scale.FontSpec.Size = 15;
            myPane.Y2Axis.Title.FontSpec.FontColor = paraLine4.Color;
            myPane.Y2Axis.Title.FontSpec.Size = 15;
            myPane.Y2Axis.Color = paraLine4.Color;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            myPane.Y2Axis.MajorTic.IsOpposite = false;
            myPane.Y2Axis.MajorTic.Color = paraLine4.Color;
            myPane.Y2Axis.MinorTic.IsOpposite = false;
            myPane.Y2Axis.MinorTic.Color = paraLine4.Color;
            // Display the Y2 axis grid lines
            myPane.Y2Axis.MajorGrid.IsVisible = true;
            // Align the Y2 axis labels so they are flush to the axis
            myPane.Y2Axis.Scale.Align = AlignP.Inside;
            myPane.Y2Axis.Scale.Max = int.Parse(paraLine4.Max);
            myPane.Y2Axis.Scale.Min = int.Parse(paraLine4.Min);

            // Create a second Y Axis
            YAxis yAxis3 = new YAxis(paraLine2.Tagname + "(" + paraLine2.Unit + ")");
            myPane.YAxisList.Add(yAxis3);
            yAxis3.Scale.FontSpec.FontColor = paraLine2.Color;
            yAxis3.Scale.FontSpec.Size = 15;
            yAxis3.Title.FontSpec.FontColor = paraLine2.Color;
            yAxis3.Title.FontSpec.Size = 15;
            yAxis3.Color = paraLine2.Color;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis3.MajorTic.IsInside = false;
            yAxis3.MinorTic.IsInside = false;
            yAxis3.MajorTic.IsOpposite = false;
            yAxis3.MajorTic.Color = paraLine2.Color;
            yAxis3.MinorTic.IsOpposite = false;
            yAxis3.MinorTic.Color = paraLine2.Color;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis3.Scale.Align = AlignP.Inside;
            yAxis3.Scale.Max = int.Parse(paraLine2.Max);
            yAxis3.Scale.Min = int.Parse(paraLine2.Min);


            // Create a third Y Axis
            YAxis yAxis5 = new YAxis(paraLine1.Tagname + "(" + paraLine1.Unit + ")");
            myPane.YAxisList.Add(yAxis5);
            yAxis5.Scale.FontSpec.FontColor = paraLine1.Color;
            yAxis5.Scale.FontSpec.Size = 15;
            yAxis5.Title.FontSpec.FontColor = paraLine1.Color;
            yAxis5.Title.FontSpec.Size = 15;
            yAxis5.Color = paraLine1.Color;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis5.MajorTic.IsInside = false;
            yAxis5.MinorTic.IsInside = false;
            yAxis5.MajorTic.IsOpposite = false;
            yAxis5.MajorTic.Color = paraLine1.Color;
            yAxis5.MinorTic.IsOpposite = false;
            yAxis5.MinorTic.Color = paraLine1.Color;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis5.Scale.Align = AlignP.Inside;
            yAxis5.Scale.Max = int.Parse(paraLine1.Max);
            yAxis5.Scale.Min = int.Parse(paraLine1.Min);


            // Create a second Y2 Axis
            Y2Axis yAxis4 = new Y2Axis(paraLine5.Tagname + "(" + paraLine5.Unit + ")");
            yAxis4.IsVisible = true;
            myPane.Y2AxisList.Add(yAxis4);
            yAxis4.Scale.FontSpec.FontColor = paraLine5.Color;
            yAxis4.Scale.FontSpec.Size = 15;
            yAxis4.Title.FontSpec.FontColor = paraLine5.Color;
            yAxis4.Title.FontSpec.Size = 15;
            yAxis4.Color = paraLine5.Color;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis4.MajorTic.IsInside = false;
            yAxis4.MinorTic.IsInside = false;
            yAxis4.MajorTic.IsOpposite = false;
            yAxis4.MajorTic.Color = paraLine5.Color;
            yAxis4.MinorTic.IsOpposite = false;
            yAxis4.MinorTic.Color = paraLine5.Color;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis4.Scale.Align = AlignP.Inside;
            yAxis4.Scale.Max = int.Parse(paraLine5.Max);
            yAxis4.Scale.Min = int.Parse(paraLine5.Min);

            // Create a third Y2 Axis
            Y2Axis yAxis6 = new Y2Axis(paraLine6.Tagname + "(" + paraLine6.Unit + ")");
            yAxis6.IsVisible = true;
            myPane.Y2AxisList.Add(yAxis6);
            yAxis6.Scale.FontSpec.FontColor = paraLine6.Color;
            yAxis6.Scale.FontSpec.Size = 15;
            yAxis6.Title.FontSpec.FontColor = paraLine6.Color;
            yAxis6.Title.FontSpec.Size = 15;
            yAxis6.Color = paraLine6.Color;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            yAxis6.MajorTic.IsInside = false;
            yAxis6.MinorTic.IsInside = false;
            yAxis6.MajorTic.IsOpposite = false;
            yAxis6.MajorTic.Color = paraLine6.Color;
            yAxis6.MinorTic.IsOpposite = false;
            yAxis6.MinorTic.Color = paraLine6.Color;
            // Align the Y2 axis labels so they are flush to the axis
            yAxis6.Scale.Align = AlignP.Inside;
            yAxis6.Scale.Max = int.Parse(paraLine6.Max);
            yAxis6.Scale.Min = int.Parse(paraLine6.Min);
            // Fill the axis background with a gradient
            //  myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);


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
            //新增，读取配置文件的曲线颜色信息，更新曲线
            trend_refresh("1"); trend_refresh("2"); trend_refresh("3");
            trend_refresh("4"); trend_refresh("5"); trend_refresh("6");


            zedGraphControl1.AxisChange();



        }
        public void trend_refresh(string num_line)
        {
            string num = num_line.Substring(num_line.Length - 1);
            //对应编号的曲线重绘，包括上下限和编号
            switch (num)
            {
                case "1":
                    zedGraphControl1.GraphPane.CurveList[4].Label.Text = paraLine1.Tagname;
                    zedGraphControl1.GraphPane.CurveList[4].Color = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].MajorTic.Color = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].MinorTic.Color = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].Color = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].Scale.FontSpec.FontColor = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].Title.Text = paraLine1.Tagname + "(" + paraLine1.Unit + ")";
                    zedGraphControl1.GraphPane.YAxisList[2].Scale.Min = int.Parse(paraLine1.Min);
                    zedGraphControl1.GraphPane.YAxisList[2].Scale.Max = int.Parse(paraLine1.Max);
                    break;
                case "2":
                    zedGraphControl1.GraphPane.CurveList[2].Label.Text = paraLine2.Tagname;
                    zedGraphControl1.GraphPane.CurveList[2].Color = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].MajorTic.Color = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].MinorTic.Color = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].Color = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].Scale.FontSpec.FontColor = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].Title.Text = paraLine2.Tagname + "(" + paraLine2.Unit + ")";
                    zedGraphControl1.GraphPane.YAxisList[1].Scale.Min = int.Parse(paraLine2.Min);
                    zedGraphControl1.GraphPane.YAxisList[1].Scale.Max = int.Parse(paraLine2.Max);
                    break;
                case "3":
                    zedGraphControl1.GraphPane.CurveList[0].Label.Text = paraLine3.Tagname;
                    zedGraphControl1.GraphPane.CurveList[0].Color = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].MajorTic.Color = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].MinorTic.Color = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].Color = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].Scale.FontSpec.FontColor = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].Title.Text = paraLine3.Tagname + "(" + paraLine3.Unit + ")";
                    zedGraphControl1.GraphPane.YAxisList[0].Scale.Min = int.Parse(paraLine3.Min);
                    zedGraphControl1.GraphPane.YAxisList[0].Scale.Max = int.Parse(paraLine3.Max);
                    break;
                case "4":
                    zedGraphControl1.GraphPane.CurveList[1].Label.Text = paraLine4.Tagname;
                    zedGraphControl1.GraphPane.CurveList[1].Color = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].MajorTic.Color = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].MinorTic.Color = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].Color = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].Scale.FontSpec.FontColor = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].Title.Text = paraLine4.Tagname + "(" + paraLine4.Unit + ")";
                    zedGraphControl1.GraphPane.Y2AxisList[0].Scale.Min = int.Parse(paraLine4.Min);
                    zedGraphControl1.GraphPane.Y2AxisList[0].Scale.Max = int.Parse(paraLine4.Max);
                    break;
                case "5":
                    zedGraphControl1.GraphPane.CurveList[3].Label.Text = paraLine5.Tagname;
                    zedGraphControl1.GraphPane.CurveList[3].Color = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].MajorTic.Color = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].MinorTic.Color = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].Color = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].Scale.FontSpec.FontColor = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].Title.Text = paraLine5.Tagname + "(" + paraLine5.Unit + ")";
                    zedGraphControl1.GraphPane.Y2AxisList[1].Scale.Min = int.Parse(paraLine5.Min);
                    zedGraphControl1.GraphPane.Y2AxisList[1].Scale.Max = int.Parse(paraLine5.Max);
                    break;
                case "6":
                    zedGraphControl1.GraphPane.CurveList[5].Label.Text = paraLine6.Tagname;
                    zedGraphControl1.GraphPane.CurveList[5].Color = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].MajorTic.Color = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].MinorTic.Color = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].Color = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].Scale.FontSpec.FontColor = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].Title.Text = paraLine6.Tagname + "(" + paraLine6.Unit + ")";
                    zedGraphControl1.GraphPane.Y2AxisList[2].Scale.Min = int.Parse(paraLine6.Min);
                    zedGraphControl1.GraphPane.Y2AxisList[2].Scale.Max = int.Parse(paraLine6.Max);
                    break;
                case "0":

                    zedGraphControl1.GraphPane.CurveList[4].Label.Text = paraLine1.Tagname;
                    zedGraphControl1.GraphPane.CurveList[4].Color = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].MajorTic.Color = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].MinorTic.Color = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].Color = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].Scale.FontSpec.FontColor = paraLine1.Color;
                    zedGraphControl1.GraphPane.YAxisList[2].Title.Text = paraLine1.Tagname + "(" + paraLine1.Unit + ")";
                    zedGraphControl1.GraphPane.YAxisList[2].Scale.Min = int.Parse(paraLine1.Min);
                    zedGraphControl1.GraphPane.YAxisList[2].Scale.Max = int.Parse(paraLine1.Max);

                    zedGraphControl1.GraphPane.CurveList[2].Label.Text = paraLine2.Tagname;
                    zedGraphControl1.GraphPane.CurveList[2].Color = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].MajorTic.Color = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].MinorTic.Color = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].Color = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].Scale.FontSpec.FontColor = paraLine2.Color;
                    zedGraphControl1.GraphPane.YAxisList[1].Title.Text = paraLine2.Tagname + "(" + paraLine2.Unit + ")";
                    zedGraphControl1.GraphPane.YAxisList[1].Scale.Min = int.Parse(paraLine2.Min);
                    zedGraphControl1.GraphPane.YAxisList[1].Scale.Max = int.Parse(paraLine2.Max);

                    zedGraphControl1.GraphPane.CurveList[0].Label.Text = paraLine3.Tagname;
                    zedGraphControl1.GraphPane.CurveList[0].Color = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].MajorTic.Color = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].MinorTic.Color = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].Color = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].Scale.FontSpec.FontColor = paraLine3.Color;
                    zedGraphControl1.GraphPane.YAxisList[0].Title.Text = paraLine3.Tagname + "(" + paraLine3.Unit + ")";
                    zedGraphControl1.GraphPane.YAxisList[0].Scale.Min = int.Parse(paraLine3.Min);
                    zedGraphControl1.GraphPane.YAxisList[0].Scale.Max = int.Parse(paraLine3.Max);

                    zedGraphControl1.GraphPane.CurveList[1].Label.Text = paraLine4.Tagname;
                    zedGraphControl1.GraphPane.CurveList[1].Color = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].MajorTic.Color = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].MinorTic.Color = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].Color = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].Scale.FontSpec.FontColor = paraLine4.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[0].Title.Text = paraLine4.Tagname + "(" + paraLine4.Unit + ")";
                    zedGraphControl1.GraphPane.Y2AxisList[0].Scale.Min = int.Parse(paraLine4.Min);
                    zedGraphControl1.GraphPane.Y2AxisList[0].Scale.Max = int.Parse(paraLine4.Max);

                    zedGraphControl1.GraphPane.CurveList[3].Label.Text = paraLine5.Tagname;
                    zedGraphControl1.GraphPane.CurveList[3].Color = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].MajorTic.Color = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].MinorTic.Color = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].Color = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].Scale.FontSpec.FontColor = paraLine5.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[1].Title.Text = paraLine5.Tagname + "(" + paraLine5.Unit + ")";
                    zedGraphControl1.GraphPane.Y2AxisList[1].Scale.Min = int.Parse(paraLine5.Min);
                    zedGraphControl1.GraphPane.Y2AxisList[1].Scale.Max = int.Parse(paraLine5.Max);

                    zedGraphControl1.GraphPane.CurveList[5].Label.Text = paraLine6.Tagname;
                    zedGraphControl1.GraphPane.CurveList[5].Color = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].MajorTic.Color = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].MinorTic.Color = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].Color = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].Scale.FontSpec.FontColor = paraLine6.Color;
                    zedGraphControl1.GraphPane.Y2AxisList[2].Title.Text = paraLine6.Tagname + "(" + paraLine6.Unit + ")";
                    zedGraphControl1.GraphPane.Y2AxisList[2].Scale.Min = int.Parse(paraLine6.Min);
                    zedGraphControl1.GraphPane.Y2AxisList[2].Scale.Max = int.Parse(paraLine6.Max);
                    break;
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
        #endregion



        #region 控件事件
        private void Frm_Realtrend_Load(object sender, EventArgs e)
        {
            xml_load();//读取偏好设置文件
            chart_initial();//初始化图表控件
            //语言切换
            MultiLanguage.LoadLanguage(Application.OpenForms["Frm_Realtrend"], Form_Main.lan);
            if (Form_Main.lan == "Chinese")
            {
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.GraphPane.XAxis.Title.Text = "时间(分钟)";
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.AxisChange();
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.Invalidate();
            }
            else if (Form_Main.lan == "English")
            {
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.GraphPane.XAxis.Title.Text = "Time(min)";
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.AxisChange();
                ((Frm_Realtrend)Application.OpenForms["Frm_Realtrend"]).zedGraphControl1.Invalidate();
            }

        }

        private void Frm_Realtrend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Location = new Point(1920, 0);
                this.BringToFront();
            }
            ((Frm_Window)Application.OpenForms["Frm_Window"]).Visible = false;
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

        public void timer_trend(double count, bool refresh)
        {


            //取Graph第一个曲线，也就是第一步:在GraphPane.CurveList集合中查找CurveItem
            LineItem curve1 = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            LineItem curve2 = zedGraphControl1.GraphPane.CurveList[1] as LineItem;
            LineItem curve3 = zedGraphControl1.GraphPane.CurveList[2] as LineItem;
            LineItem curve4 = zedGraphControl1.GraphPane.CurveList[3] as LineItem;
            LineItem curve5 = zedGraphControl1.GraphPane.CurveList[4] as LineItem;
            LineItem curve6 = zedGraphControl1.GraphPane.CurveList[5] as LineItem;
            if (curve1 == null)
            {
                return;
            }

            //第二步:在CurveItem中访问PointPairList(或者其它的IPointList)，根据自己的需要增加新数据或修改已存在的数据
            IPointListEdit list1 = curve1.Points as IPointListEdit;
            IPointListEdit list2 = curve2.Points as IPointListEdit;
            IPointListEdit list3 = curve3.Points as IPointListEdit;
            IPointListEdit list4 = curve4.Points as IPointListEdit;
            IPointListEdit list5 = curve5.Points as IPointListEdit;
            IPointListEdit list6 = curve6.Points as IPointListEdit;

            if (list1 == null)
            {
                return;
            }

            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            double factor = 60;
            int num1 = int.Parse(paraLine3.Tag.ToString());
            int num2 = int.Parse(paraLine4.Tag.ToString());
            int num3 = int.Parse(paraLine2.Tag.ToString());
            int num4 = int.Parse(paraLine5.Tag.ToString());
            int num5 = int.Parse(paraLine1.Tag.ToString());
            int num6 = int.Parse(paraLine6.Tag.ToString());

            //  factor = 1;//测试用
            //添加数据
            list1.Add(count / factor, Form_Main.Loglist.Values.ElementAt((int)count).DATA[num1] * Form_Main.factor[num1]);
            list2.Add(count / factor, Form_Main.Loglist.Values.ElementAt((int)count).DATA[num2] * Form_Main.factor[num2]);
            list3.Add(count / factor, Form_Main.Loglist.Values.ElementAt((int)count).DATA[num3] * Form_Main.factor[num3]);
            list4.Add(count / factor, Form_Main.Loglist.Values.ElementAt((int)count).DATA[num4] * Form_Main.factor[num4]);
            list5.Add(count / factor, Form_Main.Loglist.Values.ElementAt((int)count).DATA[num5] * Form_Main.factor[num5]);
            list6.Add(count / factor, Form_Main.Loglist.Values.ElementAt((int)count).DATA[num6] * Form_Main.factor[num6]);


            if (Form_Main.count / factor > xScale.Max)
            {
                xScale.Max = xScale.Max + 30;
                xScale.MajorStep = xScale.Max / 6;//X轴大步长为5，也就是显示文字的大间隔
            }


            //Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            //if (time > xScale.Max - xScale.MajorStep)
            //{
            //xScale.Max = time + xScale.MajorStep;
            //xScale.Min = xScale.Max - 30.0;

            if (refresh)
            {
                //第三步:调用ZedGraphControl.AxisChange()方法更新X和Y轴的范围
                zedGraphControl1.AxisChange();

                //第四步:调用Form.Invalidate()方法更新图表
                zedGraphControl1.Invalidate();
            }
        }
        public void trend_add(double count)
        {


            //取Graph第一个曲线，也就是第一步:在GraphPane.CurveList集合中查找CurveItem
            LineItem curve1 = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            LineItem curve2 = zedGraphControl1.GraphPane.CurveList[1] as LineItem;
            LineItem curve3 = zedGraphControl1.GraphPane.CurveList[2] as LineItem;
            LineItem curve4 = zedGraphControl1.GraphPane.CurveList[3] as LineItem;
            LineItem curve5 = zedGraphControl1.GraphPane.CurveList[4] as LineItem;
            LineItem curve6 = zedGraphControl1.GraphPane.CurveList[5] as LineItem;
            if (curve1 == null)
            {
                return;
            }

            //第二步:在CurveItem中访问PointPairList(或者其它的IPointList)，根据自己的需要增加新数据或修改已存在的数据
            IPointListEdit list1 = curve1.Points as IPointListEdit;
            IPointListEdit list2 = curve2.Points as IPointListEdit;
            IPointListEdit list3 = curve3.Points as IPointListEdit;
            IPointListEdit list4 = curve4.Points as IPointListEdit;
            IPointListEdit list5 = curve5.Points as IPointListEdit;
            IPointListEdit list6 = curve6.Points as IPointListEdit;

            if (list1 == null)
            {
                return;
            }

            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            double factor = 60;
            int num1 = int.Parse(paraLine3.Tag.ToString());
            int num2 = int.Parse(paraLine4.Tag.ToString());
            int num3 = int.Parse(paraLine2.Tag.ToString());
            int num4 = int.Parse(paraLine5.Tag.ToString());
            int num5 = int.Parse(paraLine1.Tag.ToString());
            int num6 = int.Parse(paraLine6.Tag.ToString());

            //  factor = 1;//测试用
            //添加数据
            for (int i = 0; i < count; i++)
            {
                list1.Add(i / factor, Form_Main.Loglist.Values.ElementAt((int)i).DATA[num1] * Form_Main.factor[num1]);
                list2.Add(i / factor, Form_Main.Loglist.Values.ElementAt((int)i).DATA[num2] * Form_Main.factor[num2]);
                list3.Add(i / factor, Form_Main.Loglist.Values.ElementAt((int)i).DATA[num3] * Form_Main.factor[num3]);
                list4.Add(i / factor, Form_Main.Loglist.Values.ElementAt((int)i).DATA[num4] * Form_Main.factor[num4]);
                list5.Add(i / factor, Form_Main.Loglist.Values.ElementAt((int)i).DATA[num5] * Form_Main.factor[num5]);
                list6.Add(i / factor, Form_Main.Loglist.Values.ElementAt((int)i).DATA[num6] * Form_Main.factor[num6]);
                if (((Frm_add)Application.OpenForms["Frm_add"]).progressBar1.InvokeRequired)
                {
                    ((Frm_add)Application.OpenForms["Frm_add"]).progressBar1.Invoke(new Action(() => ((Frm_add)Application.OpenForms["Frm_add"]).progressBar1.Value++));
                }
            }

            if (Form_Main.count / factor > xScale.Max)
            {
                int a = (int)(count / 1800);
                xScale.Max = xScale.Max + 30 * a;
                xScale.MajorStep = xScale.Max / 6;//X轴大步长为5，也就是显示文字的大间隔
            }


            //Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            //if (time > xScale.Max - xScale.MajorStep)
            //{
            //xScale.Max = time + xScale.MajorStep;
            //xScale.Min = xScale.Max - 30.0;


            //第三步:调用ZedGraphControl.AxisChange()方法更新X和Y轴的范围
            zedGraphControl1.AxisChange();

            //第四步:调用Form.Invalidate()方法更新图表
            zedGraphControl1.Invalidate();

        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_totaltime.Text = string.Format("{0:T}", Form_Main.time);
            lbl_stagetime.Text = string.Format("{0:T}", Form_Main.time_stage);
        }



    }
}
