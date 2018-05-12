using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_acquisition.Ctrl
{
    public partial class Parashownew : UserControl
    {
        float X, Y;
        private Color tagcolor;
        private string tagname, unit,tagname_en;
        public string Tagname { get { return tagname; } set { tagname = value; } }
        public string Tagname_EN { get { return tagname_en; } set { tagname_en = value; } }
        public string Unit { get { return unit; } set { unit = value; } }
        public Parashownew()
        {
            InitializeComponent();
            X = this.Width;
            Y = this.Height;
            setTag(this);


        }
        private void chang_color()
        {
            try
            {
                double H, S, B;
                int R, G, BB;
                RGB2HSB(tagcolor.R, tagcolor.G, tagcolor.B, out H, out S, out B);
                HSB2RGB(H, S*0.2, B*0.2 , out R, out G, out BB);
                this.radPanel1.PanelElement.PanelFill.BackColor = Color.FromArgb(R, G, BB);
                this.radPanel1.PanelElement.PanelFill.BackColor2 = tagcolor;
                this.radPanel1.PanelElement.PanelFill.BackColor3 = tagcolor;
                this.radPanel1.PanelElement.PanelFill.BackColor4 = tagcolor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void refresh()
        {
            if (Form_Main.lan == "Chinese") this.label1.Text = tagname;
            else this.label1.Text = tagname_en; this.label2.Text = unit;
            if (Form_Main.Unit == 1) label2.Text = Form_Main.factor_unit[Convert.ToInt16(Tag)];

        }
        public Color Color
        {
            get { return tagcolor; }
            set
            {
                this.tagcolor = value;
                double H, S, B;
                int R, G, BB;
                RGB2HSB(value.R, value.G, value.B, out H, out S, out B);
                HSB2RGB(H, 0.2, B, out R, out G, out BB);
                this.radPanel1.PanelElement.PanelFill.BackColor = Color.FromArgb(R, G, BB);
                this.radPanel1.PanelElement.PanelFill.BackColor2 = value;
                this.radPanel1.PanelElement.PanelFill.BackColor3 = value;
                this.radPanel1.PanelElement.PanelFill.BackColor4 = value;

            }
        }



        private void setTag(Control ctrs)
        {
            foreach (Control ctr in ctrs.Controls)
            {
                ctr.Tag = ctr.Width + ":" + ctr.Height + ":" + ctr.Left + ":" + ctr.Top + ":" + ctr.Font.Size;
                if (ctr.Controls.Count > 0) setTag(ctr);   //递归算法
            }

        }
        private void setControls(float newx, float newy, Control ctrs)
        {
            foreach (Control ctr in ctrs.Controls)
            {
                if (ctr.Tag == null) continue;
                string[] mytag = ctr.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                ctr.Width = (int)a;

                a = Convert.ToSingle(mytag[1]) * newy;
                ctr.Height = (int)a;

                a = Convert.ToSingle(mytag[2]) * newx;
                ctr.Left = (int)a;

                a = Convert.ToSingle(mytag[3]) * newy;
                ctr.Top = (int)a;

                Single currentSize = Convert.ToSingle(mytag[4]) * newy;
                ctr.Font = new Font(ctr.Font.Name, currentSize, ctr.Font.Style, ctr.Font.Unit);

                if (ctr.Controls.Count > 0) setControls(newx, newy, ctr);
            }



        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt16(this.Tag);
                radPanel1.Text = (Form_Main.Paralist.Values.Last().DATA[num] * Form_Main.factor[num]).ToString("#0.00");
            }

            catch { }
        }

        private void Parashow2_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = (this.Height) / Y;
            setControls(newx, newy, this);
        }
        public static void RGB2HSB(int red, int green, int blue, out double hue, out double sat, out double bri)
        {
            double r = ((double)red / 255.0);
            double g = ((double)green / 255.0);
            double b = ((double)blue / 255.0);

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));

            hue = 0.0;
            if (max == r && g >= b)
            {
                if (max - min == 0) hue = 0.0;
                else hue = 60 * (g - b) / (max - min);
            }
            else if (max == r && g < b)
            {
                hue = 60 * (g - b) / (max - min) + 360;
            }
            else if (max == g)
            {
                hue = 60 * (b - r) / (max - min) + 120;
            }
            else if (max == b)
            {
                hue = 60 * (r - g) / (max - min) + 240;
            }

            sat = (max == 0) ? 0.0 : (1.0 - ((double)min / (double)max));
            bri = max;
        }
        public static void HSB2RGB(double hue, double sat, double bri, out int red, out int green, out int blue)
        {
            double r = 0;
            double g = 0;
            double b = 0;

            if (sat == 0)
            {
                r = g = b = bri;
            }
            else
            {
                // the color wheel consists of 6 sectors. Figure out which sector you're in.
                double sectorPos = hue / 60.0;
                int sectorNumber = (int)(Math.Floor(sectorPos));
                // get the fractional part of the sector
                double fractionalSector = sectorPos - sectorNumber;

                // calculate values for the three axes of the color. 
                double p = bri * (1.0 - sat);
                double q = bri * (1.0 - (sat * fractionalSector));
                double t = bri * (1.0 - (sat * (1 - fractionalSector)));

                // assign the fractional colors to r, g, and b based on the sector the angle is in.
                switch (sectorNumber)
                {
                    case 0:
                        r = bri;
                        g = t;
                        b = p;
                        break;
                    case 1:
                        r = q;
                        g = bri;
                        b = p;
                        break;
                    case 2:
                        r = p;
                        g = bri;
                        b = t;
                        break;
                    case 3:
                        r = p;
                        g = q;
                        b = bri;
                        break;
                    case 4:
                        r = t;
                        g = p;
                        b = bri;
                        break;
                    case 5:
                        r = bri;
                        g = p;
                        b = q;
                        break;
                }
            }
            red = Convert.ToInt32(r * 255);
            green = Convert.ToInt32(g * 255);
            blue = Convert.ToInt32(b * 255); ;
        }

        private void Parashow2_Load(object sender, EventArgs e)
        {
            //  chang_color();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Para_choose frm = new Para_choose(this, this.ParentForm.Name);
            frm.ShowDialog();
        }
    }

}

