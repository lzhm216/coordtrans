using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using CoordTransfer;
using Matrix;

namespace CoordTransferUI
{
    public partial class FrmCal4Param : Form
    {
        private CoordTrans4Param param4 = new CoordTrans4Param();

        public FrmCal4Param()
        {
            InitializeComponent();
        }

        public CoordTrans4Param Param4
        {
            get { return this.param4; }
            set { this.param4 = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //增加
            DataGridViewRow row = new DataGridViewRow();
            this.gvPoint.Rows.Add(row);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //从文件添加坐标
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "文本文件(*.txt)|*.txt";
            openDlg.InitialDirectory = @"D:\lzhm";
            openDlg.Title = "打开源文件";

            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                string inFileName = openDlg.FileName;

                InitGridView(inFileName);
            }
        }

        private void InitGridView(string inFileName)
        {
            try
            {
                this.gvPoint.Rows.Clear();
                FileStream fs = new FileStream(inFileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string lineStr = sr.ReadLine();

                int inRecCount = 0;

                string[] subStr;

                while (lineStr != null)
                {
                    int index = this.gvPoint.Rows.Add();
                    DataGridViewRow row = this.gvPoint.Rows[index] as DataGridViewRow;

                    subStr = lineStr.Split(new char[] { ',' });
                    row.Cells[0].Value = subStr[0];
                    row.Cells[1].Value = subStr[1];
                    row.Cells[2].Value = subStr[2];
                    row.Cells[3].Value = subStr[3];
                    row.Cells[4].Value = subStr[4];
                    inRecCount = inRecCount + 1;
                    lineStr = sr.ReadLine();
                }

                sr.Close();
                fs.Close();
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //删除一行
            if (this.gvPoint.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in this.gvPoint.SelectedRows)
                {
                    this.gvPoint.Rows.Remove(row);
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //清空表格
            this.gvPoint.Rows.Clear();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //计算
            if (this.gvPoint.Rows.Count < 2)
            {
                MessageBox.Show("必须有2个公共点以上才能求 4 参数！");
                return;
            }

            List<Coords4ST> st4 = new List<Coords4ST>();
            Coords4ST st;
            for (int i = 0; i < this.gvPoint.Rows.Count - 1; i++)
            { 
                double sX = double.Parse(this.gvPoint.Rows[i].Cells["colSourceX"].Value.ToString());
                double sY = double.Parse(this.gvPoint.Rows[i].Cells["colSourceY"].Value.ToString());

                double tX = double.Parse(this.gvPoint.Rows[i].Cells["colTargetX"].Value.ToString());
                double tY = double.Parse(this.gvPoint.Rows[i].Cells["colTargetY"].Value.ToString());

                st = new Coords4ST(sX, sY, tX, tY);
                st4.Add(st);
            }
            st = null;
            this.Param4.CalculateTrans4Param(st4);
            this.Param4.CalRMS(st4);

            for (int i = 0; i < st4.Count; i++)
            {
                this.gvPoint.Rows[i].Cells["cRMS"].Value = Math.Round(st4[i].RMS, 6);    
            }

            this.lblDX.Text = string.Format("X轴平移(米)：{0}", this.Param4.DX);
            this.lblDY.Text = string.Format("Y轴平移(米)：{0}", this.Param4.DY);

            this.lblR.Text = string.Format("旋转(弧度)：{0}", this.Param4.Arf);

            this.lblChiDu.Text = string.Format("尺度：{0}", this.Param4.K);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //确定
            FrmSet4Param frmset4Param = new FrmSet4Param();
            frmset4Param.Param4 = this.Param4;
            
            if (frmset4Param.ShowDialog() == DialogResult.OK)
            {
                this.Param4 = frmset4Param.Param4;    
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //取消
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}