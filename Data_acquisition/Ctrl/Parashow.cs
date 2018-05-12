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
    public partial class Parashow : UserControl
    {

        float X, Y;
        private string tagname, unit, tagname_en;
        public string Tagname { get { return tagname; } set { tagname = value; } }
        public string Unit { get { return unit; } set { unit = value; } }
        public string Tagname_EN { get { return tagname_en; } set { tagname_en = value; } }
        public Parashow()
        {
            InitializeComponent();
            X = this.Width;
            Y = this.Height;
            setTag(this);
        }
        public void refresh()
        {
           if(Form_Main.lan=="Chinese") this.label1.Text = tagname;
           else this.label1.Text = tagname_en; 
            this.label3.Text = unit;
            if (Form_Main.Unit == 1) label3.Text = Form_Main.factor_unit[Convert.ToInt16(Tag)];
        }
        public Color Color
        {
            get { return label1.ForeColor; }
            set
            {
                this.label1.ForeColor = value;
                this.label2.ForeColor = value;
                this.label3.ForeColor = value;
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

        private void Parashow_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = (this.Height) / Y;
            setControls(newx, newy, this);
        }

        private void Parashow_Click(object sender, EventArgs e)
        {
            Para_choose frm = new Para_choose(this, this.ParentForm.Name);
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt16(this.Tag);
                label2.Text = (Form_Main.Paralist.Values.Last().DATA[num] * Form_Main.factor[num]).ToString("#0.00");
            }

            catch { }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Para_choose frm = new Para_choose(this, this.ParentForm.Name);
            frm.ShowDialog();
        }
    }
}
