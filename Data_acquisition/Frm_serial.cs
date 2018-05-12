using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Data_acquisition
{
    public partial class Frm_serial : Form
    {
        SerialPort com = new SerialPort();
        string input_portname;
        public Frm_serial(string portname)
        {
            InitializeComponent();
            input_portname = portname;
        }

        private void Frm_serial_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    if (comboBox1.Items[i].ToString() == input_portname.Substring(0,4))
                        comboBox1.SelectedItem = comboBox1.Items[i];
                }

            }
            else
            {
                comboBox1.Text = "未检测到串口";
            }

            comboBox2.SelectedIndex = 3;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

            if (Form_Main.run) { MessageBox.Show("数据正在用串口传输，请暂停后配置参数！"); return; }
            string path = Application.StartupPath + "\\Config\\" + "preference.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNode root = xml.DocumentElement;
            XmlNodeList nodeList = root.SelectNodes("Form[Name='Frm_Paraset']//Set");
            XmlNode node = nodeList[0];
            if (comboBox1.Items.Count == 0)
                node.SelectSingleNode("@port").InnerText = "null";
            else
            {
                if (Form_Main.com.IsOpen)
                {
                    Form_Main.com.Close();
                }
                node.SelectSingleNode("@port").InnerText = comboBox1.SelectedItem.ToString();
                Form_Main.com.PortName = comboBox1.SelectedItem.ToString();
                Form_Main.com.BaudRate = Convert.ToInt16(comboBox2.SelectedItem.ToString());

            }

            node.SelectSingleNode("@rate").InnerText = comboBox2.SelectedItem.ToString();
            ((Frm_Paraset)Application.OpenForms["Frm_Paraset"]).lbl_series.Text = node.SelectSingleNode("@port").InnerText + " " + node.SelectSingleNode("@rate").InnerText;
            xml.Save(path);
            this.Close();
        }
    }
}
