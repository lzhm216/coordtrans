using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;

namespace CoordTransferUI
{
    public partial class FrmSetCoordSys : Form
    {
        private IProjectedCoordinateSystem m_CurProCoord = null;
        private IGeographicCoordinateSystem m_CurGeoCoord = null;
        private TransferType m_CurrentType;
        private string m_CoorSysString;
        private string m_Datum;
        private string m_SpatialReferenceName;

        public IProjectedCoordinateSystem CurProCoord
        {
            get { return m_CurProCoord; }
            set { m_CurProCoord = value; }
        }

        public IGeographicCoordinateSystem CurGeoCoord
        {
            get { return m_CurGeoCoord; }
            set { m_CurGeoCoord = value; }
        }

        public string CoorSysString
        {
            get { return this.m_CoorSysString; }
            set { this.m_CoorSysString = value; }
        }

        public string Datum
        {
            get { return this.m_Datum; }
            set { this.m_Datum = value; }
        }

        public string SpatialReferenceName
        {
            get { return this.m_SpatialReferenceName; }
            set { this.m_SpatialReferenceName = value; }
        }

        public FrmSetCoordSys(TransferType m_CurrentType)
        {
            this.m_CurrentType = m_CurrentType;
            this.m_CoorSysString = "";

            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog flg = new OpenFileDialog();
            flg.Filter = "坐标文件(*prj)|*.prj";

            string coordPath = Application.StartupPath + "\\坐标系统";

            if (!System.IO.Directory.Exists(coordPath))
                System.IO.Directory.CreateDirectory(coordPath);
            flg.InitialDirectory = coordPath;

            if (flg.ShowDialog() == DialogResult.OK)
            {
                ISpatialReferenceFactory SpRefFac = new SpatialReferenceEnvironmentClass();
                ISpatialReference SpRef = SpRefFac.CreateESRISpatialReferenceFromPRJFile(flg.FileName);

                this.m_SpatialReferenceName = SpRef.Name;

                if (flg.FileName.Contains("大地坐标系"))
                {
                    this.m_CurGeoCoord = SpRef as IGeographicCoordinateSystem;
                    this.m_Datum = m_CurGeoCoord.Datum.Name;
                    this.txtName.Text = m_CurGeoCoord.Name;
                    this.LoadGeoCoord(true, this.m_CurGeoCoord);
                    this.LoadFileContent(flg.FileName);
                }
                else if (flg.FileName.Contains("平面坐标系"))
                {
                    this.m_CurProCoord = SpRef as IProjectedCoordinateSystem;
                    this.m_Datum = m_CurProCoord.GeographicCoordinateSystem.Datum.Name;
                    this.txtName.Text = m_CurProCoord.Name;
                    this.LoadProCoord(true, this.m_CurProCoord);
                    this.LoadFileContent(flg.FileName);
                }
            }
        }

        private void LoadFileContent(string FileName)
        {
            try
            {
                if (!File.Exists(FileName)) return ;

                FileStream fs = new FileStream(FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string lineStr = sr.ReadLine();

                while (lineStr != null)
                {
                    this.CoorSysString += lineStr;
                    lineStr = sr.ReadLine();
                }

                sr.Close();
                fs.Close();
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        private void LoadGeoCoord(bool p, IGeographicCoordinateSystem pGeoCoord)
        {
            this.txtName.Text = pGeoCoord.Name;
            this.rtxDetail.Text = "地理坐标系统:\n";
            this.rtxDetail.Text += "Name :" + pGeoCoord.Name +"\n";
            this.rtxDetail.Text += " Datum: " + pGeoCoord.Datum.Name + "\n";
            this.rtxDetail.Text += "   Spheroid: " + pGeoCoord.Datum.Spheroid.Name + "\n";
            this.rtxDetail.Text += "   Semimajor Axis: " + pGeoCoord.Datum.Spheroid.SemiMajorAxis.ToString() + "\n";
            this.rtxDetail.Text += "   Semiminor Axis: " + pGeoCoord.Datum.Spheroid.SemiMinorAxis.ToString() + "\n";
            this.rtxDetail.Text += "   Inverse Flattening: " + pGeoCoord.Datum.Spheroid.Flattening.ToString() + "\n";
            
        }

        /// <summary>
        /// 加载坐标系统
        /// </summary>
        /// <param name="isFile">是否文件方式加载</param>
        private void LoadProCoord(bool isFile, IProjectedCoordinateSystem pProCoord)
        {
            this.txtName.Text = pProCoord.Name;
            this.rtxDetail.Text = "投影坐标系统：\n";
            this.rtxDetail.Text += " Name :" + pProCoord.Name + "\n";

            this.rtxDetail.Text += "Projection: " + pProCoord.Projection.Name + "\n";
            this.rtxDetail.Text += "Parameters:\n";
            this.rtxDetail.Text += " False_Easting: " + pProCoord.FalseEasting.ToString() + "\n";
            this.rtxDetail.Text += " False_Northing: " + pProCoord.FalseNorthing.ToString() + "\n";
            this.rtxDetail.Text += " Central_Meridian: " + pProCoord.get_CentralMeridian(true).ToString() + "\n";
            this.rtxDetail.Text += " Scale_Factor: " + pProCoord.ScaleFactor.ToString() + "\n";
            this.rtxDetail.Text += " Latitude_Of_Origin: 0.000000\n";
            this.rtxDetail.Text += " Linear Unit: Meter (1.000000)\n";

            this.rtxDetail.Text += "地理坐标系统：\n";
            this.rtxDetail.Text += " Name: " + pProCoord.GeographicCoordinateSystem.Name + "\n";
            this.rtxDetail.Text += " Alias: " + pProCoord.GeographicCoordinateSystem.Alias + "\n";
            this.rtxDetail.Text += " Abbreviation: " + pProCoord.GeographicCoordinateSystem.Abbreviation + "\n";
            this.rtxDetail.Text += " Remarks: " + pProCoord.GeographicCoordinateSystem.Remarks + "\n";
            this.rtxDetail.Text += " Angular Unit: Degree (0.017453292519943299)\n";
            this.rtxDetail.Text += " Prime Meridian: " + pProCoord.GeographicCoordinateSystem.PrimeMeridian.Name + "\n";
            this.rtxDetail.Text += " Datum: " + pProCoord.GeographicCoordinateSystem.Datum.Name + "\n";
            this.rtxDetail.Text += "   Spheroid: " + pProCoord.GeographicCoordinateSystem.Datum.Spheroid.Name + "\n";
            this.rtxDetail.Text += "   Semimajor Axis: " + pProCoord.GeographicCoordinateSystem.Datum.Spheroid.SemiMajorAxis.ToString() + "\n";
            this.rtxDetail.Text += "   Semiminor Axis: " + pProCoord.GeographicCoordinateSystem.Datum.Spheroid.SemiMinorAxis.ToString() + "\n";
            this.rtxDetail.Text += "   Inverse Flattening: " + pProCoord.GeographicCoordinateSystem.Datum.Spheroid.Flattening.ToString() + "\n";

            this.rtxDetail.Text += "X/Y Domain: \n";
            double xMin = 0, xMax = 90000000, yMin = 0, yMax = 90000000, zMin = 0, zMax = 20000;
            pProCoord.SetDomain(xMin, xMax, yMin, yMax);

            this.rtxDetail.Text += " Min X: " + xMin.ToString() + "\n";
            this.rtxDetail.Text += " Min Y: " + yMin.ToString() + "\n";
            this.rtxDetail.Text += " Max X: " + xMax.ToString() + "\n";
            this.rtxDetail.Text += " Max Y: " + yMax.ToString() + "\n";

            this.rtxDetail.Text += "Z Domain: \n";
            pProCoord.SetZDomain(zMin, zMax);

            this.rtxDetail.Text += " Min: " + zMin.ToString() + "\n";
            this.rtxDetail.Text += " Max: " + zMax.ToString() + "\n";


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmCoord_Load(object sender, EventArgs e)
        {

        }

        
    }
}