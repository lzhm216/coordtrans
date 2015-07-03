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
    public partial class FrmSet4Param : Form
    {
        public CoordTrans4Param Param4 = new CoordTrans4Param();

        public FrmSet4Param()
        {
            InitializeComponent();
        }

        private void btnConfrim_Click(object sender, EventArgs e)
        {
            Param4.DX = Convert.ToDouble(txtXYi.Text.Trim());
            Param4.DY = Convert.ToDouble(txtYYi.Text.Trim());
            Param4.Arf = Convert.ToDouble(txtXuan.Text.Trim());
            Param4.K = Convert.ToDouble(txtChiDu.Text.Trim());

            this.DialogResult = DialogResult.OK;
            this.Close(); 
        }

        private void FrmSet4Param_Load(object sender, EventArgs e)
        {
            if (Param4 != null)
            {
                txtXYi.Text = Param4.DX.ToString();
                txtYYi.Text = Param4.DY.ToString();
                txtXuan.Text = Param4.Arf.ToString();
                txtChiDu.Text = Param4.K.ToString();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}