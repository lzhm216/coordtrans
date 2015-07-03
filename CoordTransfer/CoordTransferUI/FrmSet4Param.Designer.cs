namespace CoordTransferUI
{
    partial class FrmSet4Param
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
            this.txtChiDu = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtYYi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtXuan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtXYi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfrim = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtChiDu
            // 
            this.txtChiDu.Location = new System.Drawing.Point(126, 131);
            this.txtChiDu.Name = "txtChiDu";
            this.txtChiDu.Size = new System.Drawing.Size(153, 21);
            this.txtChiDu.TabIndex = 13;
            this.txtChiDu.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtChiDu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtYYi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtXuan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtXYi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 260);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "4参数设置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "尺度：";
            // 
            // txtYYi
            // 
            this.txtYYi.Location = new System.Drawing.Point(126, 61);
            this.txtYYi.Name = "txtYYi";
            this.txtYYi.Size = new System.Drawing.Size(153, 21);
            this.txtYYi.TabIndex = 11;
            this.txtYYi.Text = "111.82";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Y轴平移（m）：";
            // 
            // txtXuan
            // 
            this.txtXuan.Location = new System.Drawing.Point(126, 96);
            this.txtXuan.Name = "txtXuan";
            this.txtXuan.Size = new System.Drawing.Size(153, 21);
            this.txtXuan.TabIndex = 3;
            this.txtXuan.Text = "0.3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "旋转（dd）：";
            // 
            // txtXYi
            // 
            this.txtXYi.Location = new System.Drawing.Point(126, 26);
            this.txtXYi.Name = "txtXYi";
            this.txtXYi.Size = new System.Drawing.Size(153, 21);
            this.txtXYi.TabIndex = 1;
            this.txtXYi.Text = "107.17";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "X轴平移（m）：";
            // 
            // btnConfrim
            // 
            this.btnConfrim.Location = new System.Drawing.Point(130, 285);
            this.btnConfrim.Name = "btnConfrim";
            this.btnConfrim.Size = new System.Drawing.Size(75, 23);
            this.btnConfrim.TabIndex = 4;
            this.btnConfrim.Text = "确定";
            this.btnConfrim.UseVisualStyleBackColor = true;
            this.btnConfrim.Click += new System.EventHandler(this.btnConfrim_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(220, 285);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 5;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // FrmSet4Param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 338);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConfrim);
            this.Controls.Add(this.btnCancle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(340, 370);
            this.MinimumSize = new System.Drawing.Size(340, 370);
            this.Name = "FrmSet4Param";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置四参数";
            this.Load += new System.EventHandler(this.FrmSet4Param_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtChiDu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtYYi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtXuan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtXYi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfrim;
        private System.Windows.Forms.Button btnCancle;


    }
}