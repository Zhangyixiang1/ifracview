﻿namespace Data_acquisition.Ctrl
{
    partial class Gauge
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.radRadialGauge1 = new Telerik.WinControls.UI.Gauges.RadRadialGauge();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radialGaugeArc1 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeArc2 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeArc3 = new Telerik.WinControls.UI.Gauges.RadialGaugeArc();
            this.radialGaugeTicks1 = new Telerik.WinControls.UI.Gauges.RadialGaugeTicks();
            this.radialGaugeLabels1 = new Telerik.WinControls.UI.Gauges.RadialGaugeLabels();
            this.radialGaugeNeedle1 = new Telerik.WinControls.UI.Gauges.RadialGaugeNeedle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radRadialGauge1)).BeginInit();
            this.radRadialGauge1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radRadialGauge1
            // 
            this.radRadialGauge1.BackColor = System.Drawing.Color.Transparent;
            this.radRadialGauge1.Controls.Add(this.label2);
            this.radRadialGauge1.Controls.Add(this.label1);
            this.radRadialGauge1.Controls.Add(this.label3);
            this.radRadialGauge1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radialGaugeArc1,
            this.radialGaugeArc2,
            this.radialGaugeArc3,
            this.radialGaugeTicks1,
            this.radialGaugeLabels1,
            this.radialGaugeNeedle1});
            this.radRadialGauge1.Location = new System.Drawing.Point(0, 0);
            this.radRadialGauge1.Name = "radRadialGauge1";
            this.radRadialGauge1.RangeEnd = 180D;
            this.radRadialGauge1.Size = new System.Drawing.Size(320, 380);
            this.radRadialGauge1.StartAngle = 180D;
            this.radRadialGauge1.SweepAngle = 180D;
            this.radRadialGauge1.TabIndex = 6;
            this.radRadialGauge1.Text = "radRadialGauge1";
            this.radRadialGauge1.Value = 5F;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(244, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Psi";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "油压";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(320, 50);
            this.label3.TabIndex = 9;
            this.label3.Text = "######";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radialGaugeArc1
            // 
            this.radialGaugeArc1.AutoSize = true;
            this.radialGaugeArc1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(206)))), ((int)(((byte)(103)))));
            this.radialGaugeArc1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(206)))), ((int)(((byte)(103)))));
            this.radialGaugeArc1.Name = "radialGaugeArc1";
            this.radialGaugeArc1.RangeEnd = 60D;
            this.radialGaugeArc1.Width = 3D;
            // 
            // radialGaugeArc2
            // 
            this.radialGaugeArc2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.radialGaugeArc2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.radialGaugeArc2.Name = "radialGaugeArc2";
            this.radialGaugeArc2.RangeEnd = 120D;
            this.radialGaugeArc2.RangeStart = 61D;
            this.radialGaugeArc2.Width = 3D;
            // 
            // radialGaugeArc3
            // 
            this.radialGaugeArc3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.radialGaugeArc3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.radialGaugeArc3.Name = "radialGaugeArc3";
            this.radialGaugeArc3.RangeEnd = 180D;
            this.radialGaugeArc3.RangeStart = 121D;
            this.radialGaugeArc3.Width = 3D;
            // 
            // radialGaugeTicks1
            // 
            this.radialGaugeTicks1.DrawText = false;
            this.radialGaugeTicks1.Name = "radialGaugeTicks1";
            this.radialGaugeTicks1.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.radialGaugeTicks1.TicksCount = 6;
            this.radialGaugeTicks1.TicksLenghtPercentage = 4F;
            this.radialGaugeTicks1.TicksRadiusPercentage = 83F;
            this.radialGaugeTicks1.TickThickness = 1F;
            // 
            // radialGaugeLabels1
            // 
            this.radialGaugeLabels1.DrawText = false;
            this.radialGaugeLabels1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.radialGaugeLabels1.LabelFontSize = 5F;
            this.radialGaugeLabels1.LabelRadiusPercentage = 68F;
            this.radialGaugeLabels1.LabelsCount = 6;
            this.radialGaugeLabels1.Name = "radialGaugeLabels1";
            // 
            // radialGaugeNeedle1
            // 
            this.radialGaugeNeedle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.radialGaugeNeedle1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.radialGaugeNeedle1.BackLenghtPercentage = 0D;
            this.radialGaugeNeedle1.BindValue = true;
            this.radialGaugeNeedle1.InnerPointRadiusPercentage = 0D;
            this.radialGaugeNeedle1.LenghtPercentage = 70D;
            this.radialGaugeNeedle1.Name = "radialGaugeNeedle1";
            this.radialGaugeNeedle1.PointRadiusPercentage = 7D;
            this.radialGaugeNeedle1.Thickness = 1.5D;
            this.radialGaugeNeedle1.Value = 5F;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Gauge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radRadialGauge1);
            this.Name = "Gauge";
            this.Size = new System.Drawing.Size(320, 270);
            ((System.ComponentModel.ISupportInitialize)(this.radRadialGauge1)).EndInit();
            this.radRadialGauge1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.Gauges.RadRadialGauge radRadialGauge1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc1;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc2;
        private Telerik.WinControls.UI.Gauges.RadialGaugeArc radialGaugeArc3;
        private Telerik.WinControls.UI.Gauges.RadialGaugeTicks radialGaugeTicks1;
        private Telerik.WinControls.UI.Gauges.RadialGaugeLabels radialGaugeLabels1;
        private Telerik.WinControls.UI.Gauges.RadialGaugeNeedle radialGaugeNeedle1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;

    }
}
