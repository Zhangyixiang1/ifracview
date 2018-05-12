using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Data_acquisition
{
    public partial class Frm_Window : Form
    {
        public Frm_Window()
        {
            InitializeComponent();
        }
        private void lanchange(string lan)
        {
            if (lan == "Chinese") label1.Text = "设置中";
            else if (lan == "English") label1.Text = "Setting";

        }

        private void Frm_Window_Load(object sender, EventArgs e)
        {
            lanchange(Form_Main.lan);
        }

        private void Frm_Window_VisibleChanged(object sender, EventArgs e)
        {
            lanchange(Form_Main.lan);
        }
    }
}
