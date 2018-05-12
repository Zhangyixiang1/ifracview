using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_acquisition.Comm
{
    class Pub_func
    {
        /// <summary>
        ///  清空gridview控件里的内容
        /// </summary>
        /// <param name="dgv">gridview控件</param>
        /// 

        public static void grid_clear(DataGridView dgv)
        {
            DataTable dt = (DataTable)dgv.DataSource;
            if (dt == null) return;
            dt.Rows.Clear();
            dgv.DataSource = dt;
        }
        public static void SetValue(string AppKey, string AppValue)
        {
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");

            System.Xml.XmlNode xNode;
            System.Xml.XmlElement xElem1;
            System.Xml.XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//appSettings");

            xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
            if (xElem1 != null) xElem1.SetAttribute("value", AppValue);
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("key", AppKey);
                xElem2.SetAttribute("value", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
        }
        public static string GetValue(string AppKey)
        {
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");
            System.Xml.XmlNode xNode;
            System.Xml.XmlElement xElem1;
            xNode = xDoc.SelectSingleNode("//appSettings");
            xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
            if (xElem1 != null) return xElem1.GetAttribute("value");
            else return "false";
        }
        public static void printsrc(Point pt)
        {
            Bitmap img = new Bitmap(1920, 1080);//实例化一个和窗体一样大的bitmap
            Graphics g = Graphics.FromImage(img);
            g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.CopyFromScreen(pt.X, pt.Y, 0, 0, new Size(1920, 1080));//保存整个窗体为图片
            ((Frm_Window)Application.OpenForms["Frm_Window"]).pictureBox1.Image = img;
            ((Frm_Window)Application.OpenForms["Frm_Window"]).Location=new Point(pt.X,pt.Y);
            ((Frm_Window)Application.OpenForms["Frm_Window"]).Visible=true;
        }
    }
}
