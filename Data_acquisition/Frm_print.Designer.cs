namespace Data_acquisition
{
    partial class Frm_print
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.paraLine1 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine6 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine5 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine4 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine3 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine2 = new Data_acquisition.Ctrl.ParaLine();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 70);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1704, 960);
            this.zedGraphControl1.TabIndex = 23;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("宋体", 40F);
            this.lbl_title.Location = new System.Drawing.Point(12, 10);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(131, 54);
            this.lbl_title.TabIndex = 24;
            this.lbl_title.Text = "标题";
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(1731, 233);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(161, 67);
            this.btn_print.TabIndex = 25;
            this.btn_print.Text = "打印";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1731, 94);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 47);
            this.textBox1.TabIndex = 26;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1729, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "标题";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(1731, 160);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(161, 67);
            this.btn_refresh.TabIndex = 25;
            this.btn_refresh.Text = "刷新";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_export
            // 
            this.btn_export.Location = new System.Drawing.Point(1731, 306);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(161, 67);
            this.btn_export.TabIndex = 25;
            this.btn_export.Text = "导出";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // paraLine1
            // 
            this.paraLine1.BackColor = System.Drawing.Color.Transparent;
            this.paraLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine1.Color = System.Drawing.Color.Red;
            this.paraLine1.fontcolor = System.Drawing.Color.Black;
            this.paraLine1.Line_Enabled = true;
            this.paraLine1.Location = new System.Drawing.Point(660, 12);
            this.paraLine1.Max = "50";
            this.paraLine1.Min = "0";
            this.paraLine1.Name = "paraLine1";
            this.paraLine1.Size = new System.Drawing.Size(174, 50);
            this.paraLine1.TabIndex = 22;
            this.paraLine1.Tag = "31";
            this.paraLine1.Tagname = "井口油压";
            this.paraLine1.Tagname_EN = "Tubing Pressure(WH)";
            this.paraLine1.Unit = null;
            // 
            // paraLine6
            // 
            this.paraLine6.BackColor = System.Drawing.Color.Transparent;
            this.paraLine6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine6.Color = System.Drawing.Color.SkyBlue;
            this.paraLine6.fontcolor = System.Drawing.Color.Black;
            this.paraLine6.Line_Enabled = true;
            this.paraLine6.Location = new System.Drawing.Point(1540, 12);
            this.paraLine6.Max = "1000";
            this.paraLine6.Min = "0";
            this.paraLine6.Name = "paraLine6";
            this.paraLine6.Size = new System.Drawing.Size(174, 50);
            this.paraLine6.TabIndex = 17;
            this.paraLine6.Tag = "74";
            this.paraLine6.Tagname = "输砂总量";
            this.paraLine6.Tagname_EN = "Proppant Total";
            this.paraLine6.Unit = "m3";
            // 
            // paraLine5
            // 
            this.paraLine5.BackColor = System.Drawing.Color.Transparent;
            this.paraLine5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine5.Color = System.Drawing.Color.SeaGreen;
            this.paraLine5.fontcolor = System.Drawing.Color.Black;
            this.paraLine5.Line_Enabled = true;
            this.paraLine5.Location = new System.Drawing.Point(1364, 12);
            this.paraLine5.Max = "1000";
            this.paraLine5.Min = "0";
            this.paraLine5.Name = "paraLine5";
            this.paraLine5.Size = new System.Drawing.Size(174, 50);
            this.paraLine5.TabIndex = 18;
            this.paraLine5.Tag = "70";
            this.paraLine5.Tagname = "排出总量";
            this.paraLine5.Tagname_EN = "Discharge Total";
            this.paraLine5.Unit = "m3";
            // 
            // paraLine4
            // 
            this.paraLine4.BackColor = System.Drawing.Color.Transparent;
            this.paraLine4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine4.Color = System.Drawing.Color.Lime;
            this.paraLine4.fontcolor = System.Drawing.Color.Black;
            this.paraLine4.Line_Enabled = false;
            this.paraLine4.Location = new System.Drawing.Point(1188, 12);
            this.paraLine4.Max = "500";
            this.paraLine4.Min = "0";
            this.paraLine4.Name = "paraLine4";
            this.paraLine4.Size = new System.Drawing.Size(174, 50);
            this.paraLine4.TabIndex = 19;
            this.paraLine4.Tag = "35";
            this.paraLine4.Tagname = "实际砂浓度";
            this.paraLine4.Tagname_EN = "Proppant Concentration";
            this.paraLine4.Unit = "kg/m3";
            // 
            // paraLine3
            // 
            this.paraLine3.BackColor = System.Drawing.Color.Transparent;
            this.paraLine3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine3.Color = System.Drawing.Color.Blue;
            this.paraLine3.fontcolor = System.Drawing.Color.Black;
            this.paraLine3.Line_Enabled = true;
            this.paraLine3.Location = new System.Drawing.Point(1012, 12);
            this.paraLine3.Max = "50";
            this.paraLine3.Min = "0";
            this.paraLine3.Name = "paraLine3";
            this.paraLine3.Size = new System.Drawing.Size(174, 50);
            this.paraLine3.TabIndex = 20;
            this.paraLine3.Tag = "39";
            this.paraLine3.Tagname = "排出排量";
            this.paraLine3.Tagname_EN = "Discharge Rate(WH)";
            this.paraLine3.Unit = "m3/min";
            // 
            // paraLine2
            // 
            this.paraLine2.BackColor = System.Drawing.Color.Transparent;
            this.paraLine2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.paraLine2.fontcolor = System.Drawing.Color.Black;
            this.paraLine2.Line_Enabled = true;
            this.paraLine2.Location = new System.Drawing.Point(836, 12);
            this.paraLine2.Max = "50";
            this.paraLine2.Min = "0";
            this.paraLine2.Name = "paraLine2";
            this.paraLine2.Size = new System.Drawing.Size(174, 50);
            this.paraLine2.TabIndex = 21;
            this.paraLine2.Tag = "32";
            this.paraLine2.Tagname = "井口套压";
            this.paraLine2.Tagname_EN = "Casing Pressure(WH)";
            this.paraLine2.Unit = "Mpa";
            // 
            // Frm_print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1042);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.paraLine1);
            this.Controls.Add(this.paraLine6);
            this.Controls.Add(this.paraLine5);
            this.Controls.Add(this.paraLine4);
            this.Controls.Add(this.paraLine3);
            this.Controls.Add(this.paraLine2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "Frm_print";
            this.Text = "打印预览";
            this.Load += new System.EventHandler(this.Frm_print_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Ctrl.ParaLine paraLine1;
        private Ctrl.ParaLine paraLine6;
        private Ctrl.ParaLine paraLine5;
        private Ctrl.ParaLine paraLine4;
        private Ctrl.ParaLine paraLine3;
        private Ctrl.ParaLine paraLine2;
        public ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_export;
        private System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.Button btn_refresh;
    }
}