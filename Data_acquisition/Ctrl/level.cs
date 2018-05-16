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
            Color fill = Color.FromArgb(0, 176, 240);
            if (percent <= 20 || percent >= 90) fill = Color.Red;

            Graphics gra = this.pictureBox1.CreateGraphics();
            // 初始化画板  
            Bitmap image = new Bitmap(this.Width, this.Height);
            // 初始化图形面板  
            Graphics g = Graphics.FromImage(image); 
            g.SmoothingMode = SmoothingMode.AntiAlias;
            gra.SmoothingMode = SmoothingMode.AntiAlias;
           // gra.Clear(Color.FromArgb(191,191,191));
            double r = pictureBox1.Width / 2;
             percent = percent / 100;
            double unit = pictureBox1.Width * percent;

            GraphicsPath myPath = new GraphicsPath();
            Pen myPen = new Pen(Color.White,(float)0.5);//实例化Pen类
            SolidBrush brush = new SolidBrush(fill);  
            Rectangle myRectangle = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);//定义一个Rectangle结构
         
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
            //添加字符
            string stringText = (percent*100).ToString("#0.0")+"%";
            FontFamily family = new FontFamily("宋体");
            int fontStyle = (int)FontStyle.Regular;
            int emSize = 20;
            Point origin = new Point(45,60);
            StringFormat format = StringFormat.GenericDefault;
            myPath.AddString(stringText, family, fontStyle, emSize, origin, format);
            Region re = new Region(myPath);
            g.FillRegion(brush, re);
            g.DrawArc(myPen, 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1, 0, 360);
           
            pictureBox1.BackgroundImage = image;
            pictureBox1.Refresh();
           // gra.DrawImage(image, 0, 0);

        }
       
    }
}
