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
    public partial class FrmSet7Param : Form 
    {
        private CoordTrans7Param param7 = new CoordTrans7Param();

        public FrmSet7Param()
        {
            InitializeComponent();
        }

        public CoordTrans7Param Param7
        {
            get { return this.param7; }
            set { this.param7 = value; }
        }

        private void btnConfrim_Click(object sender, EventArgs e)
        {
            double dX = double.Parse(this.txtdX.Text.Trim());

            double dY = double.Parse(this.txtdY.Text.Trim());

            double dZ = double.Parse(this.txtdZ.Text.Trim());

            double rX = double.Parse(this.txtrX.Text.Trim());

            double rY = double.Parse(this.txtrY.Text.Trim());

            double rZ = double.Parse(this.txtrZ.Text.Trim());

            double k = double.Parse(this.txtK.Text.Trim());


            param7.Set4Param(dX, dY, dZ, k);
            param7.SetRotationParam(rX, rY, rZ);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Frm7Param_Load(object sender, EventArgs e)
        {
            if (this.param7 != null && (this.param7.DX != 0 && this.param7.DY != 0 && this.param7.DZ != 0))
            {
                this.txtdX.Text = this.param7.DX.ToString();
                this.txtdY.Text = this.param7.DY.ToString();
                this.txtdZ.Text = this.param7.DZ.ToString();

                this.txtrX.Text = this.param7.RX.ToString();
                this.txtrY.Text = this.param7.RY.ToString();
                this.txtrZ.Text = this.param7.RZ.ToString();

                this.txtK.Text = this.param7.K.ToString();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}