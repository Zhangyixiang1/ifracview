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
    public partial class Gauge_mid : UserControl
    {
        private string tagname, unit, min, max;

        public string Tagname { get { return tagname; } set { tagname = value; } }
        public string Unit { get { return unit; } set { unit = value; } }
        public string Min
        {
            get { return min; }
            set { this.min = value; }
        }
        public string Max
        {
            get { return max; }
            set { this.max = value; }
        }

        public Gauge_mid()
        {
            InitializeComponent();
        }
        public void refresh()
        {
            this.label4.Text = tagname; this.label2.Text = unit;
            radRadialGauge1.RangeStart = int.Parse(min);
            radRadialGauge1.RangeEnd = int.Parse(max);
            radialGaugeArc1.RangeEnd = double.Parse(max) / 3;
            radialGaugeArc2.RangeStart = double.Parse(max) / 3;
            radialGaugeArc2.RangeEnd = double.Parse(max) * 2 / 3;
            radialGaugeArc3.RangeStart = double.Parse(max) * 2 / 3;
            radialGaugeArc3.RangeEnd = int.Parse(max);
            if (Form_Main.Unit == 1) label2.Text = Form_Main.factor_unit[Convert.ToInt16(Tag)];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt16(this.Tag);
                radRadialGauge1.Value = (float)(Form_Main.Paralist.Values.Last().DATA[num] * Form_Main.factor[num]);
                label5.Text = (Form_Main.Paralist.Values.Last().DATA[num] * Form_Main.factor[num]).ToString("#0.00");
            }

            catch { }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Para_choose frm = new Para_choose(this, this.ParentForm.Name);
            frm.ShowDialog();
        }
    }
}
