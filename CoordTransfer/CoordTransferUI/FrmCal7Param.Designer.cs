namespace CoordTransferUI
{
    partial class FrmCal7Param
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gvPoint = new System.Windows.Forms.DataGridView();
            this.sName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRZ = new System.Windows.Forms.Label();
            this.lblChiDu = new System.Windows.Forms.Label();
            this.lblRY = new System.Windows.Forms.Label();
            this.lblRX = new System.Windows.Forms.Label();
            this.lblDZ = new System.Windows.Forms.Label();
            this.lblDY = new System.Windows.Forms.Label();
            this.lblDX = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPoint)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gvPoint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 285);
            this.panel1.TabIndex = 0;
            // 
            // gvPoint
            // 
            this.gvPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sName,
            this.colSourceX,
            this.colSourceY,
            this.colSourceZ,
            this.colTargetX,
            this.colTargetY,
            this.colTargetZ,
            this.cRMS});
            this.gvPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvPoint.Location = new System.Drawing.Point(0, 0);
            this.gvPoint.Name = "gvPoint";
            this.gvPoint.RowTemplate.Height = 23;
            this.gvPoint.Size = new System.Drawing.Size(814, 285);
            this.gvPoint.TabIndex = 0;
            // 
            // sName
            // 
            this.sName.HeaderText = "点名";
            this.sName.Name = "sName";
            this.sName.Width = 70;
            // 
            // colSourceX
            // 
            this.colSourceX.HeaderText = "源坐标X";
            this.colSourceX.Name = "colSourceX";
            // 
            // colSourceY
            // 
            this.colSourceY.HeaderText = "源坐标Y";
            this.colSourceY.Name = "colSourceY";
            // 
            // colSourceZ
            // 
            this.colSourceZ.HeaderText = "源坐标Z";
            this.colSourceZ.Name = "colSourceZ";
            // 
            // colTargetX
            // 
            this.colTargetX.HeaderText = "目标坐标X";
            this.colTargetX.Name = "colTargetX";
            // 
            // colTargetY
            // 
            this.colTargetY.HeaderText = "目标坐标Y";
            this.colTargetY.Name = "colTargetY";
            // 
            // colTargetZ
            // 
            this.colTargetZ.HeaderText = "目标坐标Y";
            this.colTargetZ.Name = "colTargetZ";
            // 
            // cRMS
            // 
            this.cRMS.HeaderText = "RMS";
            this.cRMS.Name = "cRMS";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(2, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "添加...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRZ);
            this.groupBox1.Controls.Add(this.lblChiDu);
            this.groupBox1.Controls.Add(this.lblRY);
            this.groupBox1.Controls.Add(this.lblRX);
            this.groupBox1.Controls.Add(this.lblDZ);
            this.groupBox1.Controls.Add(this.lblDY);
            this.groupBox1.Controls.Add(this.lblDX);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 142);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "计算结果";
            // 
            // lblRZ
            // 
            this.lblRZ.AutoSize = true;
            this.lblRZ.Location = new System.Drawing.Point(263, 65);
            this.lblRZ.Name = "lblRZ";
            this.lblRZ.Size = new System.Drawing.Size(0, 12);
            this.lblRZ.TabIndex = 6;
            // 
            // lblChiDu
            // 
            this.lblChiDu.AutoSize = true;
            this.lblChiDu.Location = new System.Drawing.Point(6, 101);
            this.lblChiDu.Name = "lblChiDu";
            this.lblChiDu.Size = new System.Drawing.Size(0, 12);
            this.lblChiDu.TabIndex = 5;
            // 
            // lblRY
            // 
            this.lblRY.AutoSize = true;
            this.lblRY.Location = new System.Drawing.Point(263, 43);
            this.lblRY.Name = "lblRY";
            this.lblRY.Size = new System.Drawing.Size(0, 12);
            this.lblRY.TabIndex = 4;
            // 
            // lblRX
            // 
            this.lblRX.AutoSize = true;
            this.lblRX.Location = new System.Drawing.Point(263, 21);
            this.lblRX.Name = "lblRX";
            this.lblRX.Size = new System.Drawing.Size(0, 12);
            this.lblRX.TabIndex = 3;
            // 
            // lblDZ
            // 
            this.lblDZ.AutoSize = true;
            this.lblDZ.Location = new System.Drawing.Point(7, 65);
            this.lblDZ.Name = "lblDZ";
            this.lblDZ.Size = new System.Drawing.Size(0, 12);
            this.lblDZ.TabIndex = 2;
            // 
            // lblDY
            // 
            this.lblDY.AutoSize = true;
            this.lblDY.Location = new System.Drawing.Point(7, 43);
            this.lblDY.Name = "lblDY";
            this.lblDY.Size = new System.Drawing.Size(0, 12);
            this.lblDY.TabIndex = 1;
            // 
            // lblDX
            // 
            this.lblDX.AutoSize = true;
            this.lblDX.Location = new System.Drawing.Point(7, 21);
            this.lblDX.Name = "lblDX";
            this.lblDX.Size = new System.Drawing.Size(0, 12);
            this.lblDX.TabIndex = 0;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(314, 6);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "计算1";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(110, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "删除选中";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnCalculate);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 185);
            this.panel2.TabIndex = 1;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(212, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "清空表格";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(722, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "取消";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(620, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "确定";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(518, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 2;
            this.button7.Text = "计算3";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(416, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "计算2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCal7Param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 470);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmCal7Param";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计算七参数";
            this.Load += new System.EventHandler(this.FrmCalculate7Param_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPoint)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gvPoint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRZ;
        private System.Windows.Forms.Label lblChiDu;
        private System.Windows.Forms.Label lblRY;
        private System.Windows.Forms.Label lblRX;
        private System.Windows.Forms.Label lblDZ;
        private System.Windows.Forms.Label lblDY;
        private System.Windows.Forms.Label lblDX;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn cRMS;

    }
}