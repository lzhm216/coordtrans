using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CoordTransfer;

namespace CoordTransferUI
{
    public partial class FrmCal7Param : Form
    {
        private CoordTrans7Param param7 = new CoordTrans7Param();

        public FrmCal7Param()
        {
            InitializeComponent();
        }

        public CoordTrans7Param Param7
        {
            get { return this.param7; }
            set { this.param7 = value; }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (this.gvPoint.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in this.gvPoint.SelectedRows)
                {
                    this.gvPoint.Rows.Remove(row);
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (this.gvPoint.Rows.Count < 3)
            {
                MessageBox.Show("必须有3个公共点以上才能求7参数！");
                return;
            }

            try
            {
                List<Coords7ST> st7 = new List<Coords7ST>();
                for (int i = 0; i < this.gvPoint.Rows.Count - 1; i++)
                {
                    double sX = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colSourceX"].Value.ToString().Trim());
                    double sY = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colSourceY"].Value.ToString().Trim());
                    double sZ = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colSourceZ"].Value.ToString().Trim());

                    double tX = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colTargetX"].Value.ToString().Trim());
                    double tY = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colTargetY"].Value.ToString().Trim());
                    double tZ = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colTargetZ"].Value.ToString().Trim());

                    st7.Add(new Coords7ST(sX, sY, sZ, tX, tY, tZ));

                }

                this.param7.CalculateTrans7Param1(st7);

                //计算中误差
                this.param7.CalRMS(st7);

                for (int i = 0; i < st7.Count; i++)
                {
                    this.gvPoint.Rows[i].Cells["cRMS"].Value = Math.Round(st7[i].RMS, 6);
                }

                this.gvPoint.Refresh();

                this.lblDX.Text = string.Format("X轴平移：{0}", this.param7.DX);
                this.lblDY.Text = string.Format("Y轴平移：{0}", this.param7.DY);
                this.lblDZ.Text = string.Format("Z轴平移：{0}", this.param7.DZ);

                this.lblRX.Text = string.Format("X轴旋转：{0}", this.param7.RX);
                this.lblRY.Text = string.Format("Y轴旋转：{0}", this.param7.RY);
                this.lblRZ.Text = string.Format("Z轴旋转：{0}", this.param7.RZ);

                this.lblChiDu.Text = string.Format("尺度：{0}", this.param7.K);
            }
            catch { }
        }

        private void FrmCalculate7Param_Load(object sender, EventArgs e)
        {
            int index = this.gvPoint.Rows.Add();
            DataGridViewRow row = this.gvPoint.Rows[index];

            row.Cells["sName"].Value = 1;
            row.Cells["colTargetX"].Value = 2917152.447;
            row.Cells["colTargetY"].Value = 35469334.98;
            row.Cells["colTargetZ"].Value = 976.192;

            row.Cells["colSourceX"].Value = 2917210.645;
            row.Cells["colSourceY"].Value = 35469414.46;
            row.Cells["colSourceZ"].Value = 976.192;

            index = this.gvPoint.Rows.Add();
            row = this.gvPoint.Rows[index];
            
            row.Cells["sName"].Value = 2;
            row.Cells["colTargetX"].Value = 2902205.235;
            row.Cells["colTargetY"].Value = 35475472.34;
            row.Cells["colTargetZ"].Value = 1702.374;

            row.Cells["colSourceX"].Value = 2902263.531;
            row.Cells["colSourceY"].Value = 35475551.814;
            row.Cells["colSourceZ"].Value = 1702.374;

            index = this.gvPoint.Rows.Add();
            row = this.gvPoint.Rows[index];

            row.Cells["sName"].Value = 3;
            row.Cells["colTargetX"].Value = 2912137.15;
            row.Cells["colTargetY"].Value = 35472597.085;
            row.Cells["colTargetZ"].Value = 1047.539;

            row.Cells["colSourceX"].Value = 2912195.358;
            row.Cells["colSourceY"].Value = 35472676.556;
            row.Cells["colSourceZ"].Value = 1047.539;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "文本文件(*.txt)|*.txt";
            openDlg.InitialDirectory = @"E:\lzhm\datat";
            openDlg.Title = "打开源文件";

            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                string inFileName = openDlg.FileName;

                InitGridView(inFileName);

                //textBox1.Text = inFileName;
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
                while (lineStr != null)
                {
                    char[] splitChr = new char[1];
                    splitChr[0] = ',';
                    string[] subStr = lineStr.Split(splitChr);

                    int index = this.gvPoint.Rows.Add();
                    DataGridViewRow row = this.gvPoint.Rows[index] as DataGridViewRow;
                    row.HeaderCell.Value = subStr[0];
                    row.Cells[0].Value = subStr[1];
                    row.Cells[1].Value = subStr[2];
                    row.Cells[2].Value = subStr[3];
                    row.Cells[3].Value = subStr[4];
                    row.Cells[4].Value = subStr[5];
                    row.Cells[5].Value = subStr[6];
                    row.Cells[6].Value = subStr[7];

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

        private void button6_Click(object sender, EventArgs e)
        {
            this.gvPoint.Rows.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmSet7Param frm7Set = new FrmSet7Param();
            frm7Set.Param7 = this.param7;

            if (frm7Set.ShowDialog()== DialogResult.OK)
            {
                this.param7 = frm7Set.Param7;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.gvPoint.Rows.Count < 3)
            {
                MessageBox.Show("必须有3个公共点以上才能求7参数！");
                return;
            }

            List<Coords7ST> st7 = new List<Coords7ST>();
            for (int i = 0; i < this.gvPoint.Rows.Count - 1; i++)
            {
                double sX = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colSourceX"].Value.ToString().Trim());
                double sY = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colSourceY"].Value.ToString().Trim());
                double sZ = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colSourceZ"].Value.ToString().Trim());

                double tX = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colTargetX"].Value.ToString().Trim());
                double tY = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colTargetY"].Value.ToString().Trim());
                double tZ = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colTargetZ"].Value.ToString().Trim());

                st7.Add(new Coords7ST(sX, sY, sZ, tX, tY, tZ));

            }

            this.param7.CalculateTrans7Param2(st7);

            //计算中误差
            this.param7.CalRMS(st7);

            for (int i = 0; i < st7.Count; i++)
            {
                this.gvPoint.Rows[i].Cells["cRMS"].Value = Math.Round(st7[i].RMS, 6);
            }

            this.lblDX.Text = string.Format("X轴平移：{0}", this.param7.DX);
            this.lblDY.Text = string.Format("Y轴平移：{0}", this.param7.DY);
            this.lblDZ.Text = string.Format("Z轴平移：{0}", this.param7.DZ);

            this.lblRX.Text = string.Format("X轴旋转：{0}", this.param7.RX);
            this.lblRY.Text = string.Format("Y轴旋转：{0}", this.param7.RY);
            this.lblRZ.Text = string.Format("Z轴旋转：{0}", this.param7.RZ);

            this.lblChiDu.Text = string.Format("尺度：{0}", this.param7.K);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.gvPoint.Rows.Count < 3)
            {
                MessageBox.Show("必须有3个公共点以上才能求7参数！");
                return;
            }

            List<Coords7ST> st7 = new List<Coords7ST>();
            for (int i = 0; i < this.gvPoint.Rows.Count - 1; i++)
            {
                double sX = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colSourceX"].Value.ToString().Trim());
                double sY = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colSourceY"].Value.ToString().Trim());
                double sZ = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colSourceZ"].Value.ToString().Trim());

                double tX = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colTargetX"].Value.ToString().Trim());
                double tY = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colTargetY"].Value.ToString().Trim());
                double tZ = Convert.ToDouble(this.gvPoint.Rows[i].Cells["colTargetZ"].Value.ToString().Trim());

                st7.Add(new Coords7ST(sX, sY, sZ, tX, tY, tZ));

            }

            this.param7.CalculateTrans7Param3(st7);

            //计算中误差
            this.param7.CalRMS(st7);

            for (int i = 0; i < st7.Count; i++)
            {
                this.gvPoint.Rows[i].Cells["cRMS"].Value = Math.Round(st7[i].RMS, 6);
            }

            this.lblDX.Text = string.Format("X轴平移：{0}", this.param7.DX);
            this.lblDY.Text = string.Format("Y轴平移：{0}", this.param7.DY);
            this.lblDZ.Text = string.Format("Z轴平移：{0}", this.param7.DZ);

            this.lblRX.Text = string.Format("X轴旋转：{0}", this.param7.RX);
            this.lblRY.Text = string.Format("Y轴旋转：{0}", this.param7.RY);
            this.lblRZ.Text = string.Format("Z轴旋转：{0}", this.param7.RZ);

            this.lblChiDu.Text = string.Format("尺度：{0}", this.param7.K);
        }
       
    }
}