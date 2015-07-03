using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using CoordTransfer;
using ESRI.ArcGIS.Geometry;

namespace CoordTransferUI
{
    public partial class FrmShpTransfer : Form
    {
        string pSavefilename;
        string prjCoorSystem;

        string prjDatum1;
        string prjDatum2;

        IPoint[] fromPoints;
        IPoint[] toPoints;

        string shpFileName;

        public FrmShpTransfer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.Title = "打开ShapeFile文件";
            opendlg.Multiselect = true;
            opendlg.InitialDirectory = "D:\\lzhm\\";
            opendlg.Filter = "ShapeFile文件(*.shp)|*.shp|所有文件(*.*)|*.*";
            DialogResult ds = opendlg.ShowDialog();


            //if (ds == DialogResult.OK)
            //{
            //    textBox1.Text = opendlg.FileName;
            //    //textBox2.Text= getSpatialreferenceinfo(pShpfilename.Replace(".shp", ""), opendlg.SafeFileName);
            //    shpFileName = opendlg.SafeFileName;

            //    CoordTransfer.SpatialReferenceClass spatialRef = new CoordTransfer.SpatialReferenceClass();

            //    spatialRef.ShapeFileName = opendlg.SafeFileName;
            //    spatialRef.WorkspaceName = textBox1.Text.Remove(textBox1.Text.LastIndexOf("\\"));

            //    spatialRef.GetSpatialReferenceName() ;

            //    string spatialRefName = spatialRef.SpatialName;
            //    prjDatum1 = spatialRef.Datum;

            //    if (spatialRefName == "Unknown")
            //    {
            //        this.button6.Enabled = true;
            //        textBox2.Text = "你的数据还没定义坐标系统";
            //    }
            //    else
            //    {
            //        textBox2.Text = spatialRefName;
            //    }
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "设置存储路径";
            saveDlg.InitialDirectory = "D:\\lzhm\\";
            saveDlg.Filter = "ShapeFile文件(*.shp)|*.shp|所有文件(*.*)|*.*";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                pSavefilename = saveDlg.FileName;
                textBox3.Text = pSavefilename;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                if (this.textBox1.Text == "" || this.textBox3.Text == "" || this.textBox4.Text == "") return;

                if ((this.prjDatum1 != this.prjDatum2) && this.textBox5.Text == "") return;

                //Project prj = new Project();
                //prj.InFileName = textBox1.Text;
                //prj.OutFileName = textBox3.Text;
                //prj.OutCoorSys = this.prjCoorSystem;
                //prj.Run();

                //label7.Text = prj.ResultString;
            }
            else
            {
                if (shpFileName == null) return;
                if (fromPoints == null || toPoints == null) return;

                //ShapefileTransfer4 shpTransfer4 = new ShapefileTransfer4();
                //shpTransfer4.FromPoints = fromPoints;
                //shpTransfer4.ToPoints = toPoints;
                //shpTransfer4.ShapeFileName = shpFileName;
                //shpTransfer4.WorkspaceName = textBox1.Text.Remove(textBox1.Text.LastIndexOf("\\"));
                //shpTransfer4.transform2D();

                //ShapefileTransfer7 shpTransfer7 = new ShapefileTransfer7();
                //shpTransfer7.FromPoints = fromPoints;
                //shpTransfer7.ToPoints = toPoints;
                //shpTransfer7.ShapeFileName = shpFileName;
                //shpTransfer7.WorkspaceName = textBox1.Text.Remove(textBox1.Text.LastIndexOf("\\"));
                //shpTransfer7.transform3D();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //选择目标坐标系统
            FrmSetCoordSys frmCoord = new FrmSetCoordSys(TransferType.Unknown);

            if (frmCoord.ShowDialog() == DialogResult.OK)
            {
                this.prjCoorSystem = frmCoord.CoorSysString;
                if (this.prjCoorSystem == "")
                {
                    MessageBox.Show("请选择目标坐标系统!");
                    return;
                }

                if (frmCoord.CurGeoCoord != null)
                {
                    this.textBox4.Text = frmCoord.CurGeoCoord.Name;
                    this.prjDatum2 = frmCoord.Datum;
                    if (this.prjDatum2 != this.prjDatum1)
                    {
                        textBox5.Enabled = true;
                        label6.Enabled = true;
                        button7.Enabled = true;
                    }
                }
                else
                {
                    this.textBox4.Text = frmCoord.CurProCoord.Name;
                    this.prjDatum2 = frmCoord.Datum;
                    if (this.prjDatum2 != this.prjDatum1)
                    {
                        textBox5.Enabled = true;
                        button7.Enabled = true;
                        label6.Enabled = true;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            //定义坐标系统
            FrmSetCoordSys frmcoord = new FrmSetCoordSys(TransferType.Unknown);
            string coordSysStr = string.Empty;

            if (frmcoord.ShowDialog() == DialogResult.OK)
            {
                if (coordSysStr == string.Empty)
                {
                    MessageBox.Show("请选择坐标系统");
                    return;
                }

                this.prjDatum1 = frmcoord.Datum;
                coordSysStr = frmcoord.CoorSysString;
                textBox2.Text = frmcoord.SpatialReferenceName;
            }

            try
            {
                //DefineCoorSystem defineCoordSys = new DefineCoorSystem();
                //defineCoordSys.FileName = textBox1.Text;
                //defineCoordSys.CoorSystemStr = coordSysStr;
                //defineCoordSys.Run();
                //MessageBox.Show(defineCoordSys.DefineResult);
            }
            catch
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;

                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;

                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "文本文件(*.txt)|*.txt";
            
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                InitFromToPoint(openDlg.FileName);
            }
        }

        private void InitFromToPoint(string p)
        {
            
            FileStream fs = new FileStream(p, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            try
            {
                int count = Convert.ToInt32(sr.ReadLine());

                fromPoints = new IPoint[count];
                toPoints = new IPoint[count];

                for (int i = 0; i < count; i++)
                {
                    string strLine = sr.ReadLine();
                    string[] strCoords = strLine.Split(new char[] { ',' });
                    IPoint fromPnt = new PointClass();
                    fromPnt.X = double.Parse(strCoords[2]); fromPnt.Y = double.Parse(strCoords[1]); fromPnt.Z = double.Parse(strCoords[3]);
                    fromPoints[i] = fromPnt;

                    IPoint toPnt = new PointClass();
                    toPnt.X = double.Parse(strCoords[5]); toPnt.Y = double.Parse(strCoords[4]); toPnt.Z = double.Parse(strCoords[6]);
                    toPoints[i] = toPnt;
                }
            }
            catch { }
            finally 
            {
                sr.Close(); fs.Close();
            
            }
        }


    }
}