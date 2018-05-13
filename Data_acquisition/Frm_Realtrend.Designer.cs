namespace Data_acquisition
{
    partial class Frm_Realtrend
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_stage = new System.Windows.Forms.Label();
            this.lbl_wellnum = new System.Windows.Forms.Label();
            this.lbl_stagebig = new System.Windows.Forms.Label();
            this.lbl_wellinfo = new System.Windows.Forms.Label();
            this.radProgressBar2 = new Telerik.WinControls.UI.RadProgressBar();
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.paraLine1 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine6 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine5 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine4 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine3 = new Data_acquisition.Ctrl.ParaLine();
            this.paraLine2 = new Data_acquisition.Ctrl.ParaLine();
            this.lbl_totaltime = new System.Windows.Forms.Label();
            this.lbl_stagetime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 71);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1920, 1009);
            this.zedGraphControl1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(278, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 41;
            this.label4.Text = "阶段:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "段号:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(272, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "井号:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "油田:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_stage
            // 
            this.lbl_stage.AutoSize = true;
            this.lbl_stage.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_stage.ForeColor = System.Drawing.Color.White;
            this.lbl_stage.Location = new System.Drawing.Point(342, 38);
            this.lbl_stage.Name = "lbl_stage";
            this.lbl_stage.Size = new System.Drawing.Size(31, 20);
            this.lbl_stage.TabIndex = 45;
            this.lbl_stage.Text = "##";
            // 
            // lbl_wellnum
            // 
            this.lbl_wellnum.AutoSize = true;
            this.lbl_wellnum.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_wellnum.ForeColor = System.Drawing.Color.White;
            this.lbl_wellnum.Location = new System.Drawing.Point(342, 12);
            this.lbl_wellnum.Name = "lbl_wellnum";
            this.lbl_wellnum.Size = new System.Drawing.Size(31, 20);
            this.lbl_wellnum.TabIndex = 46;
            this.lbl_wellnum.Text = "##";
            // 
            // lbl_stagebig
            // 
            this.lbl_stagebig.AutoSize = true;
            this.lbl_stagebig.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_stagebig.ForeColor = System.Drawing.Color.White;
            this.lbl_stagebig.Location = new System.Drawing.Point(151, 38);
            this.lbl_stagebig.Name = "lbl_stagebig";
            this.lbl_stagebig.Size = new System.Drawing.Size(31, 20);
            this.lbl_stagebig.TabIndex = 47;
            this.lbl_stagebig.Text = "##";
            // 
            // lbl_wellinfo
            // 
            this.lbl_wellinfo.AutoSize = true;
            this.lbl_wellinfo.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_wellinfo.ForeColor = System.Drawing.Color.White;
            this.lbl_wellinfo.Location = new System.Drawing.Point(151, 12);
            this.lbl_wellinfo.Name = "lbl_wellinfo";
            this.lbl_wellinfo.Size = new System.Drawing.Size(31, 20);
            this.lbl_wellinfo.TabIndex = 48;
            this.lbl_wellinfo.Text = "##";
            // 
            // radProgressBar2
            // 
            this.radProgressBar2.BackColor = System.Drawing.Color.Black;
            this.radProgressBar2.ForeColor = System.Drawing.Color.White;
            this.radProgressBar2.Location = new System.Drawing.Point(576, 40);
            this.radProgressBar2.Name = "radProgressBar2";
            this.radProgressBar2.SeparatorColor1 = System.Drawing.Color.Black;
            this.radProgressBar2.SeparatorColor2 = System.Drawing.Color.Black;
            this.radProgressBar2.SeparatorColor3 = System.Drawing.Color.Black;
            this.radProgressBar2.SeparatorColor4 = System.Drawing.Color.Black;
            this.radProgressBar2.Size = new System.Drawing.Size(120, 18);
            this.radProgressBar2.TabIndex = 51;
            this.radProgressBar2.Text = "0%";
            ((Telerik.WinControls.UI.RadProgressBarElement)(this.radProgressBar2.GetChildAt(0))).Text = "0%";
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(0))).BorderWidth = 1F;
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(0))).BorderInnerColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(0))).BorderInnerColor2 = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(0))).BorderInnerColor4 = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(1))).BorderInnerColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(1))).BorderInnerColor2 = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(1))).BackColor2 = System.Drawing.Color.SeaGreen;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(1))).BackColor3 = System.Drawing.Color.SeaGreen;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(1))).BackColor4 = System.Drawing.Color.SeaGreen;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(1))).HorizontalLineColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.SeaGreen;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.ProgressBarTextElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(3))).BorderInnerColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.ProgressBarTextElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(3))).BorderInnerColor2 = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.ProgressBarTextElement)(this.radProgressBar2.GetChildAt(0).GetChildAt(3))).Text = "0%";
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.BackColor = System.Drawing.Color.Black;
            this.radProgressBar1.ForeColor = System.Drawing.Color.White;
            this.radProgressBar1.Location = new System.Drawing.Point(576, 13);
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.SeparatorColor1 = System.Drawing.Color.Black;
            this.radProgressBar1.SeparatorColor2 = System.Drawing.Color.Black;
            this.radProgressBar1.SeparatorColor3 = System.Drawing.Color.Black;
            this.radProgressBar1.SeparatorColor4 = System.Drawing.Color.Black;
            this.radProgressBar1.Size = new System.Drawing.Size(120, 18);
            this.radProgressBar1.TabIndex = 52;
            this.radProgressBar1.Text = "0%";
            ((Telerik.WinControls.UI.RadProgressBarElement)(this.radProgressBar1.GetChildAt(0))).Text = "0%";
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BorderWidth = 1F;
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BorderInnerColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BorderInnerColor2 = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).BorderInnerColor4 = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            ((Telerik.WinControls.UI.ProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BorderInnerColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BorderInnerColor2 = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BackColor2 = System.Drawing.Color.SeaGreen;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BackColor3 = System.Drawing.Color.SeaGreen;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BackColor4 = System.Drawing.Color.SeaGreen;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).HorizontalLineColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).ForeColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).BackColor = System.Drawing.Color.SeaGreen;
            ((Telerik.WinControls.UI.UpperProgressIndicatorElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.ProgressBarTextElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(3))).BorderInnerColor = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.ProgressBarTextElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(3))).BorderInnerColor2 = System.Drawing.SystemColors.ControlDark;
            ((Telerik.WinControls.UI.ProgressBarTextElement)(this.radProgressBar1.GetChildAt(0).GetChildAt(3))).Text = "0%";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(406, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 20);
            this.label5.TabIndex = 49;
            this.label5.Text = "作业总进度:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(402, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 20);
            this.label6.TabIndex = 50;
            this.label6.Text = "阶段进度:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // paraLine1
            // 
            this.paraLine1.BackColor = System.Drawing.Color.Transparent;
            this.paraLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine1.Color = System.Drawing.Color.Red;
            this.paraLine1.fontcolor = System.Drawing.Color.White;
            this.paraLine1.Line_Enabled = true;
            this.paraLine1.Location = new System.Drawing.Point(849, 12);
            this.paraLine1.Max = null;
            this.paraLine1.Min = null;
            this.paraLine1.Name = "paraLine1";
            this.paraLine1.Size = new System.Drawing.Size(174, 50);
            this.paraLine1.TabIndex = 22;
            this.paraLine1.Tagname = null;
            this.paraLine1.Tagname_EN = null;
            this.paraLine1.Unit = null;
            // 
            // paraLine6
            // 
            this.paraLine6.BackColor = System.Drawing.Color.Transparent;
            this.paraLine6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine6.Color = System.Drawing.Color.SkyBlue;
            this.paraLine6.fontcolor = System.Drawing.Color.White;
            this.paraLine6.Line_Enabled = true;
            this.paraLine6.Location = new System.Drawing.Point(1739, 12);
            this.paraLine6.Max = "1000";
            this.paraLine6.Min = "0";
            this.paraLine6.Name = "paraLine6";
            this.paraLine6.Size = new System.Drawing.Size(174, 50);
            this.paraLine6.TabIndex = 17;
            this.paraLine6.Tagname = null;
            this.paraLine6.Tagname_EN = null;
            this.paraLine6.Unit = "Mpa";
            // 
            // paraLine5
            // 
            this.paraLine5.BackColor = System.Drawing.Color.Transparent;
            this.paraLine5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine5.Color = System.Drawing.Color.SeaGreen;
            this.paraLine5.fontcolor = System.Drawing.Color.White;
            this.paraLine5.Line_Enabled = true;
            this.paraLine5.Location = new System.Drawing.Point(1561, 12);
            this.paraLine5.Max = "1000";
            this.paraLine5.Min = "0";
            this.paraLine5.Name = "paraLine5";
            this.paraLine5.Size = new System.Drawing.Size(174, 50);
            this.paraLine5.TabIndex = 18;
            this.paraLine5.Tagname = null;
            this.paraLine5.Tagname_EN = null;
            this.paraLine5.Unit = "Mpa";
            // 
            // paraLine4
            // 
            this.paraLine4.BackColor = System.Drawing.Color.Transparent;
            this.paraLine4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine4.Color = System.Drawing.Color.Lime;
            this.paraLine4.fontcolor = System.Drawing.Color.White;
            this.paraLine4.Line_Enabled = false;
            this.paraLine4.Location = new System.Drawing.Point(1383, 12);
            this.paraLine4.Max = "1000";
            this.paraLine4.Min = "0";
            this.paraLine4.Name = "paraLine4";
            this.paraLine4.Size = new System.Drawing.Size(174, 50);
            this.paraLine4.TabIndex = 19;
            this.paraLine4.Tagname = null;
            this.paraLine4.Tagname_EN = null;
            this.paraLine4.Unit = "Mpa";
            // 
            // paraLine3
            // 
            this.paraLine3.BackColor = System.Drawing.Color.Transparent;
            this.paraLine3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine3.Color = System.Drawing.Color.Blue;
            this.paraLine3.fontcolor = System.Drawing.Color.White;
            this.paraLine3.Line_Enabled = true;
            this.paraLine3.Location = new System.Drawing.Point(1205, 12);
            this.paraLine3.Max = "1000";
            this.paraLine3.Min = "0";
            this.paraLine3.Name = "paraLine3";
            this.paraLine3.Size = new System.Drawing.Size(174, 50);
            this.paraLine3.TabIndex = 20;
            this.paraLine3.Tagname = null;
            this.paraLine3.Tagname_EN = null;
            this.paraLine3.Unit = "Mpa";
            // 
            // paraLine2
            // 
            this.paraLine2.BackColor = System.Drawing.Color.Transparent;
            this.paraLine2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paraLine2.Color = System.Drawing.Color.Yellow;
            this.paraLine2.fontcolor = System.Drawing.Color.White;
            this.paraLine2.Line_Enabled = true;
            this.paraLine2.Location = new System.Drawing.Point(1027, 12);
            this.paraLine2.Max = "1000";
            this.paraLine2.Min = "0";
            this.paraLine2.Name = "paraLine2";
            this.paraLine2.Size = new System.Drawing.Size(174, 50);
            this.paraLine2.TabIndex = 21;
            this.paraLine2.Tagname = null;
            this.paraLine2.Tagname_EN = null;
            this.paraLine2.Unit = "Mpa";
            // 
            // lbl_totaltime
            // 
            this.lbl_totaltime.AutoSize = true;
            this.lbl_totaltime.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.lbl_totaltime.ForeColor = System.Drawing.Color.White;
            this.lbl_totaltime.Location = new System.Drawing.Point(697, 38);
            this.lbl_totaltime.Name = "lbl_totaltime";
            this.lbl_totaltime.Size = new System.Drawing.Size(82, 22);
            this.lbl_totaltime.TabIndex = 53;
            this.lbl_totaltime.Text = "00:00:00";
            // 
            // lbl_stagetime
            // 
            this.lbl_stagetime.AutoSize = true;
            this.lbl_stagetime.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.lbl_stagetime.ForeColor = System.Drawing.Color.White;
            this.lbl_stagetime.Location = new System.Drawing.Point(697, 11);
            this.lbl_stagetime.Name = "lbl_stagetime";
            this.lbl_stagetime.Size = new System.Drawing.Size(82, 22);
            this.lbl_stagetime.TabIndex = 53;
            this.lbl_stagetime.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Frm_Realtrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.lbl_stagetime);
            this.Controls.Add(this.lbl_totaltime);
            this.Controls.Add(this.radProgressBar2);
            this.Controls.Add(this.radProgressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_stage);
            this.Controls.Add(this.lbl_wellnum);
            this.Controls.Add(this.lbl_stagebig);
            this.Controls.Add(this.lbl_wellinfo);
            this.Controls.Add(this.paraLine1);
            this.Controls.Add(this.paraLine6);
            this.Controls.Add(this.paraLine5);
            this.Controls.Add(this.paraLine4);
            this.Controls.Add(this.paraLine3);
            this.Controls.Add(this.paraLine2);
            this.Controls.Add(this.zedGraphControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Frm_Realtrend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Frm_Realtrend_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Realtrend_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_wellnum;
        private System.Windows.Forms.Label lbl_stagebig;
        private System.Windows.Forms.Label lbl_wellinfo;
        public ZedGraph.ZedGraphControl zedGraphControl1;
        public System.Windows.Forms.Label lbl_stage;
        public Telerik.WinControls.UI.RadProgressBar radProgressBar2;
        public Telerik.WinControls.UI.RadProgressBar radProgressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lbl_totaltime;
        public System.Windows.Forms.Label lbl_stagetime;
        private System.Windows.Forms.Timer timer1;
        public Ctrl.ParaLine paraLine1;
        public Ctrl.ParaLine paraLine6;
        public Ctrl.ParaLine paraLine5;
        public Ctrl.ParaLine paraLine4;
        public Ctrl.ParaLine paraLine3;
        public Ctrl.ParaLine paraLine2;
    }
}