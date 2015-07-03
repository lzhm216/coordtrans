using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CoordTransfer;

namespace CoordTransferUI
{
    public partial class FrmSetPrjParamter : Form
    {
        public double Central_Meridian;
        public double falseEast;
        public double falseNorth;
        //public CoordTransfer.ProjectType PrjType;

        public FrmSetPrjParamter()
        {
            this.Central_Meridian = 0;
            this.falseNorth = 0;
            this.falseEast = 0;
            //this.PrjType = ProjectType.Unknown;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Central_Meridian = double.Parse(this.textBox1.Text.Trim());
                this.falseNorth = double.Parse(this.textBox2.Text.Trim());
                this.falseEast = double.Parse(this.textBox3.Text.Trim());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message, "错误信息");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void setPrjParamterForm_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //PrjType = ProjectType.Gs3;  
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                //PrjType = ProjectType.Gs6;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                //PrjType = ProjectType.Utm;
            }
        }

    }
}