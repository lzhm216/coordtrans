using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using CoordTransfer;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.DataSourcesFile;

namespace CoordTransferUI
{
    public partial class FrmMain : Form
    {
        private TuoQiuJiChu m_TuoQiuJiChu = new TuoQiuJiChu();
        private PositionVectorTransferParamter m_PositionVectorTransferParamter = new PositionVectorTransferParamter();

        //中央子午线
        private double m_Central_Meridian;
        private double m_False_East;
        private double m_False_North;
        //private ProjectType m_PrjType;

        //要转换数据的个数
        private int inRecCount;

        private CoordTrans4Param m_CoordTrans4Param = new CoordTrans4Param();
        private CoordTrans7Param m_CoordTrans7Param = new CoordTrans7Param();
        /// <summary>
        /// ESRI根据7参数转换算法
        /// </summary>
        public PositionVectorTransferParamter PositionVectorTransferParamter
        {
            get { return m_PositionVectorTransferParamter; }
            set { m_PositionVectorTransferParamter = value; }
        }

        // 当前转换类型
        private TransferType m_CurrentType;

        public FrmMain()
        {
            //this.m_PrjType = ProjectType.Unknown;
            this.m_CurrentType = TransferType.DaDiToZhiJiao; ;
            this.m_Central_Meridian = -1;
            this.inRecCount = 0;
            InitializeComponent();

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.cbSource.DataSource = TuoQiuJiChu.GetAllTuoQiuJiChu();
            this.cbSource.DisplayMember = "Name";

            this.cbTarget.DataSource = TuoQiuJiChu.GetAllTuoQiuJiChu();
            this.cbTarget.DisplayMember = "Name";
        }


        /// <summary>
        /// 根据radioButton选择的情况获取当前转换类型
        /// </summary>
        private void getCurTransType()
        {
            if (this.radioButton1.Checked == true)
            {
                if (this.radioButton4.Checked == true)
                {
                    this.m_CurrentType = TransferType.ZhijiaoToZhijiao;
                }
                else if (this.radioButton5.Checked == true)
                {
                    this.m_CurrentType = TransferType.ZhijiaoToDadi;
                }
                else
                {
                    this.m_CurrentType = TransferType.Unknown;
                }
            }
            else if (this.radioButton2.Checked == true)
            {
                if (this.radioButton4.Checked == true)
                {
                    this.m_CurrentType = TransferType.DaDiToZhiJiao;
                }
                else if (this.radioButton6.Checked == true)
                {
                    this.m_CurrentType = TransferType.DadiToPingMian;
                }
                else
                {
                    this.m_CurrentType = TransferType.Unknown;
                }
            }
            else if (this.radioButton3.Checked == true)
            {
                if (this.radioButton4.Checked == true)
                {
                    this.m_CurrentType = TransferType.PingMianToZhiJiao;
                }
                else if (this.radioButton5.Checked == true)
                {
                    this.m_CurrentType = TransferType.PingMianToDaDi;
                }
                else if (this.radioButton6.Checked == true)
                {
                    this.m_CurrentType = TransferType.PingMianToPingMian;
                }
                else
                {
                    this.m_CurrentType = TransferType.Unknown;
                }
            }
        }

       
        #region 菜单:参数设定
        /// <summary>
        /// 调用设置7参数窗口
        /// </summary>
        private void tsm7Param_Click(object sender, EventArgs e)
        {
            FrmSet7Param frm7Set = new FrmSet7Param();
            frm7Set.Param7 = this.m_CoordTrans7Param;

            if (frm7Set.ShowDialog() == DialogResult.OK)
            {
                this.m_CoordTrans7Param = frm7Set.Param7;
            }

        }
        /// <summary>
        /// 调用7参数计算窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmCal_Click(object sender, EventArgs e)
        {
            FrmCal7Param cal7 = new FrmCal7Param();
            if (cal7.ShowDialog() == DialogResult.OK)
            {
                this.m_CoordTrans7Param = cal7.Param7;
            }
        }

        /// <summary>
        /// 调用设置4参数窗口
        /// </summary>
        private void tsm4Param_Click(object sender, EventArgs e)
        {
            FrmSet4Param frm4set = new FrmSet4Param();
            frm4set.Param4 = this.m_CoordTrans4Param;
            if (frm4set.ShowDialog() == DialogResult.OK)
            {
                if (frm4set.Param4 != null)
                    this.m_CoordTrans4Param = frm4set.Param4;
            }
        }
        /// <summary>
        /// 调用7参数计算窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm4Cal_Click(object sender, EventArgs e)
        {
            FrmCal4Param frm4cal = new FrmCal4Param();

            if (frm4cal.ShowDialog() == DialogResult.OK)
            {
                this.m_CoordTrans4Param = frm4cal.Param4;
            }
            
        }


        /// <summary>
        /// Shapefile文件定义坐标系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void defineCooordSysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDefineCoordSys frmDefineCoordSys = new FrmDefineCoordSys();
            frmDefineCoordSys.ShowDialog();
        }

        /// <summary>
        /// ShapeFile文件坐标转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShpTransfer frmShpTransfer = new FrmShpTransfer();
            frmShpTransfer.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        #endregion



        #region 坐标转换类型菜单Click事件

        private void tsmDaDiToZhiJiao_Click(object sender, EventArgs e)
        {
            this.radioButton2.Checked = true;
            this.radioButton4.Checked = true;

            this.m_CurrentType = TransferType.DaDiToZhiJiao;
        }

        private void tsmZhijiaoToDadi_Click(object sender, EventArgs e)
        {
            this.radioButton1.Checked = true;
            this.radioButton5.Checked = true;

            this.m_CurrentType = TransferType.ZhijiaoToDadi;
        }

        private void tsmZhiJiaoToZhiJiao_Click(object sender, EventArgs e)
        {
            this.radioButton1.Checked = true;
            this.radioButton4.Checked = true;

            this.m_CurrentType = TransferType.ZhijiaoToZhijiao;
        }

        private void tsmDaDiToPingMian_Click(object sender, EventArgs e)
        {

            this.radioButton2.Checked = true;
            this.radioButton6.Checked = true;

            this.m_CurrentType = TransferType.DadiToPingMian;
        }

        private void tsmPingMianToDaDi_Click(object sender, EventArgs e)
        {
            this.radioButton3.Checked = true;
            this.radioButton5.Checked = true;

            this.m_CurrentType = TransferType.PingMianToDaDi;
        }

        private void shapefileTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmShpTransfer frmShpTrans = new FrmShpTransfer();
            frmShpTrans.ShowDialog();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            openDlg.InitialDirectory = @"E:\lzhm\";
            openDlg.Title = "打开源文件";


            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openDlg.FileName;
                InitGridView(label3.Text);

            }
        }

        /// <summary>
        /// 获取ShapeFile文件的坐标系统
        /// </summary>
        /// <param name="inWorkspaceName">工作空间</param>
        /// <param name="inFileName">文件名</param>
        /// <returns></returns>
        //private string getSpatialReferenceInfo(string inWorkspaceName, string inFileName)
        //{
        //    IWorkspaceFactory shapefileworkspaceF = new ShapefileWorkspaceFactoryClass();
        //    IWorkspace workspace = shapefileworkspaceF.OpenFromFile(inWorkspaceName, 0);
        //    IFeatureWorkspace featureWorkspace = workspace as IFeatureWorkspace;
        //    IFeatureClass featureClass = featureWorkspace.OpenFeatureClass(inFileName) as IFeatureClass;

        //    ISpatialReference pSpatialref = (ISpatialReference)featureClass.GetFeature(0).Shape.SpatialReference;

        //    return pSpatialref.Name;

        //}

        /// <summary>
        /// 将文件中的内容填写到DataGridView中
        /// </summary>
        /// <param name="inFileName">文件路径</param>
        private void InitGridView(string inFileName)
        {
            try
            {
                this.dataGridView1.Rows.Clear();
                FileStream fs = new FileStream(inFileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string lineStr = sr.ReadLine();

                inRecCount = 0;
                while (lineStr != null)
                {
                    char[] splitChr = new char[1];
                    splitChr[0] = ',';
                    string[] subStr = lineStr.Split(splitChr);

                    int index = this.dataGridView1.Rows.Add();
                    DataGridViewRow row = this.dataGridView1.Rows[index] as DataGridViewRow;
                    row.HeaderCell.Value = inRecCount;
                    row.Cells[0].Value = subStr[0];
                    row.Cells[1].Value = subStr[1];
                    row.Cells[2].Value = subStr[2];
                    row.Cells[3].Value = subStr[3];

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

            int i = this.dataGridView1.Rows.Count;

            if (i >0)
            {
                inRecCount = i - 1;
            }

            if (this.inRecCount <= 0) return;

            this.dataGridView2.Rows.Clear();

            //文本文件转换

            if (this.m_CurrentType == TransferType.DadiToDadi)
            {
                
            }
            else if (this.m_CurrentType == TransferType.DaDiToZhiJiao)
            {
                DaDiToZhiJiaoM(inRecCount);
            }
            else if (this.m_CurrentType == TransferType.DadiToPingMian)
            {
                DaDiToPingMianM(inRecCount);
            }
            else if (this.m_CurrentType == TransferType.ZhijiaoToDadi)
            {
                ZhijiaoToDadiM(inRecCount);
            }
            else if (this.m_CurrentType == TransferType.ZhijiaoToZhijiao)
            {
                if (this.m_CoordTrans7Param == null) return;

                ZhijiaoToZhijiaoM(inRecCount);
            }
            
            else if (this.m_CurrentType == TransferType.PingMianToDaDi)
            {
                PingMianToDaDiM(inRecCount);
            }
            else if (this.m_CurrentType == TransferType.PingMianToPingMian)
            {
                if (this.m_CoordTrans4Param == null) return;

                PingMianToPingMian(inRecCount);
            }
            else if (this.m_CurrentType == TransferType.Unknown)
            {
                MessageBox.Show("不支持此类型转换");
                return;
            }



        }





        #region 批量转换函数
        private void ZhijiaoToDadiM(double recCount)
        {
            try
            {
                DaDiZhiJiaoTransferParamter paramter = new DaDiZhiJiaoTransferParamter();
                paramter.TuoQiuJiChu = this.cbSource.SelectedItem as TuoQiuJiChu;

                for (int i = 0; i < recCount; i++)
                {
                    paramter.X = double.Parse(this.dataGridView1.Rows[i].Cells[1].Value.ToString().Trim());
                    paramter.Y = double.Parse(this.dataGridView1.Rows[i].Cells[2].Value.ToString().Trim());
                    paramter.Z = double.Parse(this.dataGridView1.Rows[i].Cells[3].Value.ToString().Trim());

                    DaDiZhiJiaoTransfer transfer = new DaDiZhiJiaoTransfer(paramter);

                    transfer.ZhijiaoToDadi();

                    int index = this.dataGridView2.Rows.Add();
                    DataGridViewRow row = this.dataGridView2.Rows[index] as DataGridViewRow;

                    this.dataGridView2.Rows[i].Cells[0].Value = this.dataGridView1.Rows[i].Cells[0].Value;
                    this.dataGridView2.Rows[i].Cells[1].Value = transfer.Paramter.B.ToString();
                    this.dataGridView2.Rows[i].Cells[2].Value = transfer.Paramter.L.ToString();
                    this.dataGridView2.Rows[i].Cells[3].Value = transfer.Paramter.H.ToString();
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        private void DaDiToZhiJiaoM(double recCount)
        {
            try
            {
                DaDiZhiJiaoTransferParamter paramter = new DaDiZhiJiaoTransferParamter();
                paramter.TuoQiuJiChu = this.cbSource.SelectedItem as TuoQiuJiChu;

                for (int i = 0; i < recCount; i++)
                {
                    paramter.B = double.Parse(this.dataGridView1.Rows[i].Cells[1].Value.ToString().Trim());
                    paramter.L = double.Parse(this.dataGridView1.Rows[i].Cells[2].Value.ToString().Trim());
                    paramter.H = double.Parse(this.dataGridView1.Rows[i].Cells[3].Value.ToString().Trim());

                    DaDiZhiJiaoTransfer transfer = new DaDiZhiJiaoTransfer(paramter);
                    transfer.DaDiToZhiJiao();

                    int index = this.dataGridView2.Rows.Add();
                    DataGridViewRow row = this.dataGridView2.Rows[index] as DataGridViewRow;

                    this.dataGridView2.Rows[i].Cells[0].Value = this.dataGridView1.Rows[i].Cells[0].Value;
                    this.dataGridView2.Rows[i].Cells[1].Value = transfer.Paramter.X.ToString();
                    this.dataGridView2.Rows[i].Cells[2].Value = transfer.Paramter.Y.ToString();
                    this.dataGridView2.Rows[i].Cells[3].Value = transfer.Paramter.Z.ToString();
                }
            }
            catch(Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        private void PingMianToDaDiM(int inRecCount)
        {
            try
            {

                DaDiPingMianTransferParameter paramter = new DaDiPingMianTransferParameter();
                paramter.TuoQiuJiChu = this.cbSource.SelectedItem as TuoQiuJiChu;
                for (int i = 0; i < inRecCount; i++)
                {
                    paramter.X = double.Parse(this.dataGridView1.Rows[i].Cells[1].Value.ToString().Trim());
                    paramter.Y = double.Parse(this.dataGridView1.Rows[i].Cells[2].Value.ToString().Trim());

                    //如果Z值未输入
                    if (this.dataGridView1.Rows[i].Cells[3].Value == null)
                    {
                        paramter.Z = 0;
                    }
                    else
                    {
                        paramter.Z = double.Parse(this.dataGridView1.Rows[i].Cells[3].Value.ToString().Trim());
                    }

                    if (this.m_Central_Meridian == -1)
                    {
                        MessageBox.Show("请设置中央子午线");
                        return;
                    }

                    paramter.Central_Meridian = this.m_Central_Meridian;

                    DaDiPingMianTransfer transfer = new DaDiPingMianTransfer(paramter);
                    transfer.PingMianToDaDi();

                    int index = this.dataGridView2.Rows.Add();
                    DataGridViewRow row = this.dataGridView2.Rows[index] as DataGridViewRow;

                    this.dataGridView2.Rows[i].Cells[0].Value = this.dataGridView1.Rows[i].Cells[0].Value;
                    this.dataGridView2.Rows[i].Cells[1].Value = transfer.Paramters.B.ToString();
                    this.dataGridView2.Rows[i].Cells[2].Value = transfer.Paramters.L.ToString();
                    this.dataGridView2.Rows[i].Cells[3].Value = transfer.Paramters.Z.ToString();
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }

        private void DaDiToPingMianM(int inRecCount)
        {
            try
            {
                DaDiPingMianTransferParameter paramter = new DaDiPingMianTransferParameter();
                paramter.TuoQiuJiChu = this.cbSource.SelectedItem as TuoQiuJiChu;

                for (int i = 0; i < inRecCount; i++)
                {
                    paramter.B = double.Parse(this.dataGridView1.Rows[i].Cells[1].Value.ToString().Trim());
                    paramter.L = double.Parse(this.dataGridView1.Rows[i].Cells[2].Value.ToString().Trim());
                    paramter.H = double.Parse(this.dataGridView1.Rows[i].Cells[3].Value.ToString().Trim());

                    if (this.m_Central_Meridian == -1)
                    {
                        MessageBox.Show("请设置中央子午线!");
                        return;
                    }

                    paramter.Central_Meridian = this.m_Central_Meridian;

                    DaDiPingMianTransfer transfer = new DaDiPingMianTransfer(paramter);
                    transfer.DaDiToPingMian();

                    int index = this.dataGridView2.Rows.Add();
                    DataGridViewRow row = this.dataGridView2.Rows[index] as DataGridViewRow;

                    this.dataGridView2.Rows[i].Cells[0].Value = this.dataGridView1.Rows[i].Cells[0].Value;
                    this.dataGridView2.Rows[i].Cells[1].Value = transfer.Paramters.X.ToString();
                    this.dataGridView2.Rows[i].Cells[2].Value = transfer.Paramters.Y.ToString();
                    this.dataGridView2.Rows[i].Cells[3].Value = transfer.Paramters.H.ToString();
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
        }


        private void PingMianToPingMian(int inRecCount)
        {
            double x1, y1, x2, y2;

            if (this.inRecCount <= 0) return;
            if (m_CoordTrans4Param == null) return;

            for (int i = 0; i < inRecCount; i++)
            {
                x2 = y2 = 0;
                x1 = double.Parse(this.dataGridView1.Rows[i].Cells[1].Value.ToString().Trim());
                y1 = double.Parse(this.dataGridView1.Rows[i].Cells[2].Value.ToString().Trim());

                m_CoordTrans4Param.CalTargetCoord(x1, y1, ref x2, ref y2);

                int index = this.dataGridView2.Rows.Add();
                DataGridViewRow row = this.dataGridView2.Rows[index] as DataGridViewRow;

                this.dataGridView2.Rows[i].Cells[0].Value = this.dataGridView1.Rows[i].Cells[0].Value;
                this.dataGridView2.Rows[i].Cells[1].Value = Math.Round(x2, 6).ToString();
                this.dataGridView2.Rows[i].Cells[2].Value = Math.Round(y2, 6).ToString();
                this.dataGridView2.Rows[i].Cells[3].Value = this.dataGridView1.Rows[i].Cells[3].Value;
            }
        }

        private void ZhijiaoToZhijiaoM(int inRecCount)
        {
            double x1, y1,z1, x2, y2,z2;

            if (this.inRecCount <= 0) return;
            if (m_CoordTrans4Param == null) return;

            for (int i = 0; i < inRecCount; i++)
            {
                x2 = y2 =z2= 0;
                x1 = double.Parse(this.dataGridView1.Rows[i].Cells[1].Value.ToString().Trim());
                y1 = double.Parse(this.dataGridView1.Rows[i].Cells[2].Value.ToString().Trim());
                z1 = double.Parse(this.dataGridView1.Rows[i].Cells[3].Value.ToString().Trim());

                m_CoordTrans7Param.CalTargetCoord1(x1, y1, z1, ref x2, ref y2, ref z2);
                int index = this.dataGridView2.Rows.Add();
                DataGridViewRow row = this.dataGridView2.Rows[index] as DataGridViewRow;

                this.dataGridView2.Rows[i].Cells[0].Value = this.dataGridView1.Rows[i].Cells[0].Value;
                this.dataGridView2.Rows[i].Cells[1].Value = Math.Round(x2, 6).ToString();
                this.dataGridView2.Rows[i].Cells[2].Value = Math.Round(y2, 6).ToString();
                this.dataGridView2.Rows[i].Cells[3].Value = Math.Round(z2, 6).ToString();
            }

        }

        #endregion


        #region Shapefile文件转换
        /// <summary>
        /// Shapefile 大地--->平面 
        /// </summary>
        //private void DaDiToPingMianShp(string InFileName, string OutFileName, string OutCoorSys)
        //{
        //    CoordTransfer.Project project = new Project();

        //    project.InFileName = InFileName;
        //    project.OutFileName = OutFileName;
        //    project.OutCoorSys = OutCoorSys;

        //    project.Run();

        //}

        /// <summary>
        /// Shapefile 平面--->大地
        /// </summary>
        //private void PingMianToDaDiShp(string InFileName, string OutFileName, string OutCoorSys)
        //{
        //    CoordTransfer.Project project = new Project();

        //    project.InFileName = InFileName;
        //    project.OutFileName = OutFileName;
        //    project.OutCoorSys = OutCoorSys;

        //    project.Run();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InFileName"></param>
        /// <param name="OutFileName"></param>
        private void PingMianToPingMianShp(string InFileName, string OutFileName)
        { 
            
        }

        #endregion

        /// <summary>
        /// 将结果存储在文件中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            saveDlg.InitialDirectory = @"E:\lzhm\";
            saveDlg.RestoreDirectory = true;

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                label5.Text = saveDlg.FileName;
                string outFileName = saveDlg.FileName;
                OutputGridViewContent(outFileName);
            }
        }

        private void OutputGridViewContent(string outFileName)
        {
            FileStream fs = new FileStream(outFileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < inRecCount; i++)
            {
                string txt = this.dataGridView2.Rows[i].Cells[0].Value + ",";
                txt = txt + this.dataGridView2.Rows[i].Cells[1].Value + ",";
                txt = txt + this.dataGridView2.Rows[i].Cells[2].Value + ",";
                txt = txt + this.dataGridView2.Rows[i].Cells[3].Value;
                sw.WriteLine(txt);
            }
            sw.Close();
            fs.Close();
        }

        #region radioButtom CheckedChanged事件处理

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
            {
                //this.dataGridView1.Rows.Clear();
                //this.dataGridView2.Rows.Clear();

                //this.dataGridView1.Rows[0].Cells[0].Value = "1";
                //this.dataGridView1.Rows[0].Cells[1].Value = "-1254147.50964685";
                //this.dataGridView1.Rows[0].Cells[2].Value = "4975547.16761378";
                //this.dataGridView1.Rows[0].Cells[3].Value = "3777679.7893634";
                //this.inRecCount = 1;

                this.dataGridView1.Columns[1].HeaderText = "X(m)";
                this.dataGridView1.Columns[2].HeaderText = "Y(m)";
                this.dataGridView1.Columns[3].HeaderText = "Z(m)";

                getCurTransType();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked == true)
            {
                //this.dataGridView1.Rows.Clear();
                //this.dataGridView2.Rows.Clear();

                //this.dataGridView1.Rows[0].Cells[0].Value = "1";
                //this.dataGridView1.Rows[0].Cells[1].Value = "36.545178";
                //this.dataGridView1.Rows[0].Cells[2].Value = "104.147396";
                //this.dataGridView1.Rows[0].Cells[3].Value = "1203.121";
                //this.inRecCount = 1;

                this.dataGridView1.Columns[1].HeaderText = "B(dd)";
                this.dataGridView1.Columns[2].HeaderText = "L(dd)";
                this.dataGridView1.Columns[3].HeaderText = "H(m)";

                getCurTransType();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton3.Checked == true)
            {
                //this.dataGridView1.Rows.Clear();
                //this.dataGridView2.Rows.Clear();

                //this.dataGridView1.Rows[0].Cells[0].Value = "1";
                //this.dataGridView1.Rows[0].Cells[1].Value = "4046447.77099195";
                //this.dataGridView1.Rows[0].Cells[2].Value = "-76343.4389127917";
                //this.dataGridView1.Rows[0].Cells[3].Value = "1203.121";
                //this.inRecCount = 1;

                this.dataGridView1.Columns[1].HeaderText = "X(m)";
                this.dataGridView1.Columns[2].HeaderText = "Y(m)";
                this.dataGridView1.Columns[3].HeaderText = "H(m)";

                getCurTransType();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton4.Checked == true)
            {

                this.dataGridView2.Columns[1].HeaderText = "X(m)";
                this.dataGridView2.Columns[2].HeaderText = "Y(m)";
                this.dataGridView2.Columns[3].HeaderText = "Z(m)";

                getCurTransType();
            }

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton5.Checked == true)
            {

                this.dataGridView2.Columns[1].HeaderText = "B(dd)";
                this.dataGridView2.Columns[2].HeaderText = "L(dd)";
                this.dataGridView2.Columns[3].HeaderText = "H(m)";

                getCurTransType();
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton6.Checked == true)
            {
                this.dataGridView2.Columns[1].HeaderText = "X(m)";
                this.dataGridView2.Columns[2].HeaderText = "Y(m)";
                this.dataGridView2.Columns[3].HeaderText = "H(m)";

                getCurTransType();
            }
        }

        #endregion



        private void setProjectParamterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSetPrjParamter prjFrm = new FrmSetPrjParamter();

            if (prjFrm.ShowDialog() == DialogResult.OK)
            {
                this.m_Central_Meridian = prjFrm.Central_Meridian;
                this.m_False_East = prjFrm.falseEast;
                this.m_False_North = prjFrm.falseNorth;
                //this.m_PrjType = prjFrm.PrjType;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.inRecCount = 0;
            this.dataGridView1.Rows.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Rows.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add(1);
            this.inRecCount = this.inRecCount + 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0) return;

            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = this.dataGridView1.Rows[i];
                if (row.Selected == true)
                {
                    this.dataGridView1.Rows.Remove(row);
                    this.inRecCount = this.inRecCount - 1;
                }
            }
        }




    }




    /// <summary>
    /// 转换类型
    /// </summary>
    public enum TransferType
    {
        DadiToDadi,
        DaDiToZhiJiao,
        DadiToPingMian,

        ZhijiaoToDadi,
        ZhijiaoToZhijiao,
        ZhijiaoToPingMian,

        PingMianToZhiJiao,
        PingMianToDaDi,
        PingMianToPingMian,

        Unknown
    }
}