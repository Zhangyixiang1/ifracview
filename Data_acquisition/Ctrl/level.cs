using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Data_acquisition.Ctrl
{
    public partial class level : UserControl
    {
        public level()
        {
            InitializeComponent();
        }
        public void Refresh(double percent)
        {
            Graphics gra = this.panel1.CreateGraphics();
            gra.Clear(Color.White);
            double r = panel1.Width / 2;
            //double percent = Convert.ToDouble(textBox1.Text) / 100;
            // if (percent == 0) return;
            double unit = panel1.Width * percent;

            GraphicsPath myPath = new GraphicsPath();
            Pen myPen = new Pen(Color.Black, 2);//实例化Pen类
            Rectangle myRectangle = new Rectangle(0, 0, panel1.Width, panel1.Height);//定义一个Rectangle结构
            //myPath.DrawArc(myPen, myRectangle, 0, 180);//绘制圆弧
            //myPath.DrawLine(myPen, new Point(0, 75), new Point(150, 75));

            //有公式y=kx+b算的k=-180，b=90（x为液位，y为起始角）
            float angle = Convert.ToSingle(percent * -180 + 90);
            myPath.AddArc(myRectangle, angle, 180 - 2 * angle);
            double dy = r * Math.Sin(Convert.ToDouble(angle * Math.PI / 180));
            double dx = r * Math.Cos(Convert.ToDouble(angle * Math.PI / 180));
            int x = Convert.ToInt16(dx);
            int y = Convert.ToInt16(dy);
            int R = Convert.ToInt16(r);
            Point[] pt = new Point[2];
            pt[0] = new Point(R - x, R + y); pt[1] = new Point(R + x, R + y);
            myPath.AddCurve(pt);

            //string stringText = "zyx";
            //FontFamily family = new FontFamily("Arial");
            //int fontStyle = (int)FontStyle.Italic;
            //int emSize = 26;
            //Point origin = new Point(75, 75);
            //StringFormat format = StringFormat.GenericDefault;
            //myPath.AddString(stringText, family, fontStyle, emSize, origin, format);
            Region re = new Region(myPath);
            gra.FillRegion(Brushes.Red, re);
            gra.DrawArc(myPen, myRectangle, 0, 360);

        }
    }
}
