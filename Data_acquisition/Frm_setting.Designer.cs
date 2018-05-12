namespace Data_acquisition
{
    partial class Frm_setting
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb_metric = new System.Windows.Forms.RadioButton();
            this.rdb_engunit = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdb_chn = new System.Windows.Forms.RadioButton();
            this.rdb_eng = new System.Windows.Forms.RadioButton();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txb_daq = new System.Windows.Forms.TextBox();
            this.txb_b = new System.Windows.Forms.TextBox();
            this.txb_f1 = new System.Windows.Forms.TextBox();
            this.txb_f2 = new System.Windows.Forms.TextBox();
            this.txb_f3 = new System.Windows.Forms.TextBox();
            this.txb_f4 = new System.Windows.Forms.TextBox();
            this.txb_f5 = new System.Windows.Forms.TextBox();
            this.txb_f6 = new System.Windows.Forms.TextBox();
            this.txb_f7 = new System.Windows.Forms.TextBox();
            this.txb_f8 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb_metric);
            this.groupBox1.Controls.Add(this.rdb_engunit);
            this.groupBox1.Location = new System.Drawing.Point(226, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(91, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单位";
            // 
            // rdb_metric
            // 
            this.rdb_metric.AutoSize = true;
            this.rdb_metric.Location = new System.Drawing.Point(6, 52);
            this.rdb_metric.Name = "rdb_metric";
            this.rdb_metric.Size = new System.Drawing.Size(47, 16);
            this.rdb_metric.TabIndex = 0;
            this.rdb_metric.TabStop = true;
            this.rdb_metric.Text = "公制";
            this.rdb_metric.UseVisualStyleBackColor = true;
            this.rdb_metric.CheckedChanged += new System.EventHandler(this.rdb_metric_CheckedChanged);
            // 
            // rdb_engunit
            // 
            this.rdb_engunit.AutoSize = true;
            this.rdb_engunit.Location = new System.Drawing.Point(7, 21);
            this.rdb_engunit.Name = "rdb_engunit";
            this.rdb_engunit.Size = new System.Drawing.Size(47, 16);
            this.rdb_engunit.TabIndex = 0;
            this.rdb_engunit.TabStop = true;
            this.rdb_engunit.Text = "英制";
            this.rdb_engunit.UseVisualStyleBackColor = true;
            this.rdb_engunit.CheckedChanged += new System.EventHandler(this.rdb_engunit_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdb_chn);
            this.groupBox2.Controls.Add(this.rdb_eng);
            this.groupBox2.Location = new System.Drawing.Point(226, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(102, 81);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "语言";
            // 
            // rdb_chn
            // 
            this.rdb_chn.AutoSize = true;
            this.rdb_chn.Location = new System.Drawing.Point(6, 52);
            this.rdb_chn.Name = "rdb_chn";
            this.rdb_chn.Size = new System.Drawing.Size(47, 16);
            this.rdb_chn.TabIndex = 0;
            this.rdb_chn.TabStop = true;
            this.rdb_chn.Text = "中文";
            this.rdb_chn.UseVisualStyleBackColor = true;
            // 
            // rdb_eng
            // 
            this.rdb_eng.AutoSize = true;
            this.rdb_eng.Location = new System.Drawing.Point(7, 21);
            this.rdb_eng.Name = "rdb_eng";
            this.rdb_eng.Size = new System.Drawing.Size(47, 16);
            this.rdb_eng.TabIndex = 0;
            this.rdb_eng.TabStop = true;
            this.rdb_eng.Text = "英文";
            this.rdb_eng.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(226, 270);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(226, 225);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "DAQ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "混砂车";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "泵1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "泵2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "泵3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "泵4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "泵5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "泵6";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "泵7";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "泵8";
            // 
            // txb_daq
            // 
            this.txb_daq.Location = new System.Drawing.Point(75, 18);
            this.txb_daq.Name = "txb_daq";
            this.txb_daq.Size = new System.Drawing.Size(124, 21);
            this.txb_daq.TabIndex = 3;
            // 
            // txb_b
            // 
            this.txb_b.Location = new System.Drawing.Point(75, 46);
            this.txb_b.Name = "txb_b";
            this.txb_b.Size = new System.Drawing.Size(124, 21);
            this.txb_b.TabIndex = 3;
            // 
            // txb_f1
            // 
            this.txb_f1.Location = new System.Drawing.Point(75, 74);
            this.txb_f1.Name = "txb_f1";
            this.txb_f1.Size = new System.Drawing.Size(124, 21);
            this.txb_f1.TabIndex = 3;
            // 
            // txb_f2
            // 
            this.txb_f2.Location = new System.Drawing.Point(75, 102);
            this.txb_f2.Name = "txb_f2";
            this.txb_f2.Size = new System.Drawing.Size(124, 21);
            this.txb_f2.TabIndex = 3;
            // 
            // txb_f3
            // 
            this.txb_f3.Location = new System.Drawing.Point(75, 130);
            this.txb_f3.Name = "txb_f3";
            this.txb_f3.Size = new System.Drawing.Size(124, 21);
            this.txb_f3.TabIndex = 3;
            // 
            // txb_f4
            // 
            this.txb_f4.Location = new System.Drawing.Point(75, 158);
            this.txb_f4.Name = "txb_f4";
            this.txb_f4.Size = new System.Drawing.Size(124, 21);
            this.txb_f4.TabIndex = 3;
            // 
            // txb_f5
            // 
            this.txb_f5.Location = new System.Drawing.Point(75, 186);
            this.txb_f5.Name = "txb_f5";
            this.txb_f5.Size = new System.Drawing.Size(124, 21);
            this.txb_f5.TabIndex = 3;
            // 
            // txb_f6
            // 
            this.txb_f6.Location = new System.Drawing.Point(75, 214);
            this.txb_f6.Name = "txb_f6";
            this.txb_f6.Size = new System.Drawing.Size(124, 21);
            this.txb_f6.TabIndex = 3;
            // 
            // txb_f7
            // 
            this.txb_f7.Location = new System.Drawing.Point(75, 242);
            this.txb_f7.Name = "txb_f7";
            this.txb_f7.Size = new System.Drawing.Size(124, 21);
            this.txb_f7.TabIndex = 3;
            // 
            // txb_f8
            // 
            this.txb_f8.Location = new System.Drawing.Point(75, 270);
            this.txb_f8.Name = "txb_f8";
            this.txb_f8.Size = new System.Drawing.Size(124, 21);
            this.txb_f8.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_confirm);
            this.groupBox3.Location = new System.Drawing.Point(12, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 330);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(6, 300);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_confirm.TabIndex = 0;
            this.btn_confirm.Text = "应用";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // Frm_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 344);
            this.Controls.Add(this.txb_f8);
            this.Controls.Add(this.txb_f7);
            this.Controls.Add(this.txb_f6);
            this.Controls.Add(this.txb_f5);
            this.Controls.Add(this.txb_f4);
            this.Controls.Add(this.txb_f3);
            this.Controls.Add(this.txb_f2);
            this.Controls.Add(this.txb_f1);
            this.Controls.Add(this.txb_b);
            this.Controls.Add(this.txb_daq);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.Frm_setting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdb_metric;
        private System.Windows.Forms.RadioButton rdb_engunit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdb_chn;
        private System.Windows.Forms.RadioButton rdb_eng;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txb_daq;
        private System.Windows.Forms.TextBox txb_b;
        private System.Windows.Forms.TextBox txb_f1;
        private System.Windows.Forms.TextBox txb_f2;
        private System.Windows.Forms.TextBox txb_f3;
        private System.Windows.Forms.TextBox txb_f4;
        private System.Windows.Forms.TextBox txb_f5;
        private System.Windows.Forms.TextBox txb_f6;
        private System.Windows.Forms.TextBox txb_f7;
        private System.Windows.Forms.TextBox txb_f8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_confirm;

    }
}

