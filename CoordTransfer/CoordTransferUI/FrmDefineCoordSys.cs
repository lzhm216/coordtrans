using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CoordTransfer;
using ESRI.ArcGIS.Geometry;

namespace CoordTransferUI
{
    public partial class FrmDefineCoordSys : Form
    {
        string fileName;

        public FrmDefineCoordSys()
        {
            InitializeComponent();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
        //    OpenFileDialog opendlg = new OpenFileDialog();
        //    opendlg.Title = "打开ShapeFile文件";
        //    opendlg.Multiselect = true;
        //    opendlg.InitialDirectory = "D:\\lzhm\\";
        //    opendlg.Filter = "ShapeFile文件(*.shp)|*.shp|所有文件(*.*)|*.*";
        //    DialogResult ds = opendlg.ShowDialog();


        //    if (ds == DialogResult.OK)
        //    {
        //        textBox1.Text = opendlg.FileName;

        //        fileName = opendlg.SafeFileName;

        //        GetShapefileCoordSysInfo(fileName, textBox1.Text.Remove(textBox1.Text.LastIndexOf("\\")));

               
        //    }
        }

        private void GetShapefileCoordSysInfo(string fileName, string workspaceName)
        {
        //    SpatialReferenceClass spatialRef = new CoordTransfer.SpatialReferenceClass();

        //    spatialRef.ShapeFileName = fileName;
        //    spatialRef.WorkspaceName = workspaceName;

        //    spatialRef.GetSpatialReferenceName();

        //    string spatialRefName = spatialRef.SpatialName;
        //    //string prjDatum = spatialRef.Datum;
        //    bool isGeographicCoordSys = spatialRef.IsGeographicCoordinateSystem;

        //    if (spatialRefName == "Unknown")
        //    {
        //        this.button6.Enabled = true;
        //        textBox2.Text = "你的数据还没定义坐标系统";
        //    }
        //    else
        //    {
        //        textBox2.Text = spatialRefName;

        //        if (isGeographicCoordSys == true)
        //        {
        //            IGeographicCoordinateSystem pGeoCoorSys = (IGeographicCoordinateSystem)spatialRef.GeographicCoordSys;
        //            //this.LoadGeoCoord(true, pGeoCoorSys);
        //        }
        //        else
        //        {
        //            IProjectedCoordinateSystem pPrjCoorSys = (IProjectedCoordinateSystem)spatialRef.ProjectCoordSys;
        //            //LoadProCoord(true, pPrjCoorSys);
        //        }
        //    }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            //定义坐标系统
            FrmSetCoordSys frmSetCoord = new FrmSetCoordSys(TransferType.Unknown);
            string coordSysStr = string.Empty;

            if (frmSetCoord.ShowDialog() == DialogResult.OK)
            {
                if (coordSysStr == string.Empty)
                {
                    MessageBox.Show("请选择坐标系统");
                    return;
                }

                //this.prjDatum1 = frmcoord.Datum;
                coordSysStr = frmSetCoord.CoorSysString;
                textBox2.Text = frmSetCoord.SpatialReferenceName;
            }

            try
            {
                //DefineCoorSystem defineCoordSys = new DefineCoorSystem();
                //defineCoordSys.FileName = textBox1.Text;
                //defineCoordSys.CoorSystemStr = coordSysStr;
                //defineCoordSys.Run();
                //MessageBox.Show(defineCoordSys.DefineResult);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //清除坐标系统

            //ClearCoorSystem clearCoorSys = new ClearCoorSystem();
            //clearCoorSys.ShapefileName = fileName;
            //clearCoorSys.WorkspaceName = textBox1.Text.Remove(textBox1.Text.LastIndexOf("\\"));
            //clearCoorSys.Run();
        }
    }
}