namespace CoordTransferUI
{
    partial class FrmCal4Param
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
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblChiDu = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.lblDY = new System.Windows.Forms.Label();
            this.lblDX = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.gvPoint = new System.Windows.Forms.DataGridView();
            this.sName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoint)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(315, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 3;
            this.button6.Text = "清空";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(627, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "取消";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.btnCalculate);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(705, 161);
            this.panel2.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(523, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "确定";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(112, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "读取...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(418, 6);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "计算";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblChiDu);
            this.groupBox1.Controls.Add(this.lblR);
            this.groupBox1.Controls.Add(this.lblDY);
            this.groupBox1.Controls.Add(this.lblDX);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 126);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "计算结果";
            // 
            // lblChiDu
            // 
            this.lblChiDu.AutoSize = true;
            this.lblChiDu.Location = new System.Drawing.Point(331, 52);
            this.lblChiDu.Name = "lblChiDu";
            this.lblChiDu.Size = new System.Drawing.Size(0, 12);
            this.lblChiDu.TabIndex = 3;
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(331, 26);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(0, 12);
            this.lblR.TabIndex = 2;
            // 
            // lblDY
            // 
            this.lblDY.AutoSize = true;
            this.lblDY.Location = new System.Drawing.Point(7, 52);
            this.lblDY.Name = "lblDY";
            this.lblDY.Size = new System.Drawing.Size(0, 12);
            this.lblDY.TabIndex = 1;
            // 
            // lblDX
            // 
            this.lblDX.AutoSize = true;
            this.lblDX.Location = new System.Drawing.Point(7, 26);
            this.lblDX.Name = "lblDX";
            this.lblDX.Size = new System.Drawing.Size(0, 12);
            this.lblDX.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(207, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "删除选中";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gvPoint
            // 
            this.gvPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sName,
            this.colSourceX,
            this.colSourceY,
            this.colTargetX,
            this.colTargetY,
            this.cRMS});
            this.gvPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPoint.Location = new System.Drawing.Point(0, 0);
            this.gvPoint.Name = "gvPoint";
            this.gvPoint.RowTemplate.Height = 23;
            this.gvPoint.Size = new System.Drawing.Size(705, 285);
            this.gvPoint.TabIndex = 0;
            // 
            // sName
            // 
            this.sName.HeaderText = "点名";
            this.sName.Name = "sName";
            this.sName.Width = 80;
            // 
            // colSourceX
            // 
            this.colSourceX.HeaderText = "转换前X(m)";
            this.colSourceX.Name = "colSourceX";
            this.colSourceX.Width = 120;
            // 
            // colSourceY
            // 
            this.colSourceY.HeaderText = "转换前Y(m)";
            this.colSourceY.Name = "colSourceY";
            this.colSourceY.Width = 120;
            // 
            // colTargetX
            // 
            this.colTargetX.HeaderText = "转换后X(m)";
            this.colTargetX.Name = "colTargetX";
            this.colTargetX.Width = 120;
            // 
            // colTargetY
            // 
            this.colTargetY.HeaderText = "转换后Y(m)";
            this.colTargetY.Name = "colTargetY";
            this.colTargetY.Width = 120;
            // 
            // cRMS
            // 
            this.cRMS.HeaderText = "RMS";
            this.cRMS.Name = "cRMS";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gvPoint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(705, 285);
            this.panel1.TabIndex = 2;
            // 
            // FrmCal4Param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 446);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCal4Param";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计算四参数";
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoint)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblChiDu;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblDY;
        private System.Windows.Forms.Label lblDX;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView gvPoint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetY;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRMS;

    }
}