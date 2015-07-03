using System;
using System.Collections.Generic;
using System.Text;

using Matrix;

namespace CoordTransfer
{
    public class CoordTrans7Param
    {
        public double[,] values = new double[7, 1];


        public void Set4Param(double dx, double dy, double dz, double k)
        {
            this.DX = dx;
            this.DY = dy;
            this.DZ = dz;
            this.K = k;
            this.RX = this.RY = this.RZ = 0;
        }

        public void SetRotationParam(double rx, double ry, double rz)
        {
            this.RX = rx;
            this.RY = ry;
            this.RZ = rz;
        }


        private void InitMatrixAB(ref double [][] A,ref double [][]B,List<Coords7ST> st7)
        {
            if (st7 == null) return;

            int count = st7.Count;

            if (count < 3) return;

            A = new double[count * 3][];
            for (int i = 0; i < count * 3; i++)
            {
                A[i] = new double[7];
            }

            B = new double[count * 3][];
            for (int i = 0; i < count * 3; i++)
            {
                B[i] = new double[1];
            }

            int idx = 0;
            for (int i = 0; i < count * 3; i = i + 3)
            {
                A[i][0] = 1; A[i][1] = 0; A[i][2] = 0;
                A[i][3] = 0; A[i][4] = -st7[idx].SourceZ; A[i][5] = st7[idx].SourceY; A[i][6] = st7[idx].SourceX;

                A[i + 1][0] = 0; A[i + 1][1] = 1; A[i + 1][2] = 0;
                A[i + 1][3] = st7[idx].SourceZ; A[i + 1][4] = 0; A[i + 1][5] = -st7[idx].SourceX; A[i + 1][6] = st7[idx].SourceY;

                A[i + 2][0] = 0; A[i + 2][1] = 0; A[i + 2][2] = 1;
                A[i + 2][3] = -st7[idx].SourceY; A[i + 2][4] = st7[idx].SourceX; A[i + 2][5] = 0; A[i + 2][6] = st7[idx].SourceZ;

                B[i][0] = st7[idx].TargetX; B[i + 1][0] = st7[idx].TargetY; B[i + 2][0] = st7[idx].TargetZ;

                idx = idx + 1;
            }
        }

        /// <summary>
        /// 方法一：AT*A*S=AT*B
        /// </summary>
        /// <param name="st7"></param>
        public void CalculateTrans7Param1(List<Coords7ST> st7)
        {

            double[][] A = new double[0][];
            double[][] B = new double[0][];

            InitMatrixAB(ref A, ref B, st7);
            
            GeneralMatrix matrixA = new GeneralMatrix(A);
            GeneralMatrix matrixB = new GeneralMatrix(B);
            GeneralMatrix matrixAT = matrixA.Transpose();

            GeneralMatrix matrixATA = matrixAT.Multiply(matrixA);
            GeneralMatrix matrixATAInv = matrixATA.Inverse();
            GeneralMatrix matrixParam = matrixATAInv.Multiply(matrixAT).Multiply(matrixB);

            this.Set4Param(matrixParam.GetElement(0, 0), matrixParam.GetElement(1, 0), matrixParam.GetElement(2, 0), matrixParam.GetElement(6, 0));
            this.SetRotationParam(matrixParam.GetElement(3, 0), matrixParam.GetElement(4, 0), matrixParam.GetElement(5, 0));

        }


        /// <summary>
        /// 直接求逆矩阵
        /// </summary>
        /// <param name="st7"></param>
        public void CalculateTrans7Param2(List<Coords7ST> st7)
        {
            double[][] A = new double[0][];
            double[][] B = new double[0][];

            InitMatrixAB(ref A, ref B, st7);

            GeneralMatrix matrixA = new GeneralMatrix(A);
            GeneralMatrix matrixB = new GeneralMatrix(B);
            GeneralMatrix matrixParam = matrixA.Inverse() * matrixB;

            this.Set4Param(matrixParam.GetElement(0, 0), matrixParam.GetElement(1, 0), matrixParam.GetElement(2, 0), matrixParam.GetElement(6, 0));
            this.SetRotationParam(matrixParam.GetElement(3, 0), matrixParam.GetElement(4, 0), matrixParam.GetElement(5, 0));

        }

        /// <summary>
        /// QR分解法
        /// </summary>
        /// <param name="st7"></param>
        public void CalculateTrans7Param3(List<Coords7ST> st7)
        {
            double[][] A = new double[0][];
            double[][] B = new double[0][];

            InitMatrixAB(ref A, ref B, st7);

            GeneralMatrix matrixA = new GeneralMatrix(A);
            GeneralMatrix matrixB = new GeneralMatrix(B);

            QRDecomposition qrDecp = matrixA.QRD();
            GeneralMatrix q = qrDecp.Q;
            GeneralMatrix r = qrDecp.R;

            GeneralMatrix matrixParam = r.Inverse().Multiply(q.Transpose()).Multiply(matrixB);

            this.Set4Param(matrixParam.GetElement(0, 0), matrixParam.GetElement(1, 0), matrixParam.GetElement(2, 0), matrixParam.GetElement(6, 0));
            this.SetRotationParam(matrixParam.GetElement(3, 0), matrixParam.GetElement(4, 0), matrixParam.GetElement(5, 0));

        }


        public void CalTargetCoord(double x1, double y1, double z1, ref double x2, ref double y2, ref double z2)
        {
            x2 = this.values[0, 0] - z1 * this.values[4, 0] + y1 * this.values[5, 0] + x1 * this.values[6, 0];
            y2 = this.values[1, 0] + z1 * this.values[3, 0] + x1 * this.values[5, 0] + y1 * this.values[6, 0];
            z2 = this.values[2, 0] - y1 * this.values[3, 0] + x1 * this.values[4, 0] + z1 * this.values[6, 0];
        }

        public void CalTargetCoord1(double x1, double y1, double z1, ref double x2, ref double y2, ref double z2)
        {
            x2 = this.DX + this.K * (x1 + this.RZ * y1 - this.RY * z1);
            y2 = this.DY + this.K * (-this.RZ * x1 + y1 + this.RX * z1);
            z2 = this.DZ + this.K * (this.RY * x1 - this.RX * y1 + z1);
        }

        public void CalRMS(List<Coords7ST> st7)
        {
            if (st7 == null) return;
            for (int i = 0; i < st7.Count; i++)
            {
                double tX = 0, tY = 0, tZ = 0;
                CalTargetCoord(st7[i].SourceX, st7[i].SourceY, st7[i].SourceZ, ref tX, ref tY, ref tZ);
                st7[i].RMS = Math.Sqrt((tX - st7[i].TargetX) * (tX - st7[i].TargetX) + (tY - st7[i].TargetY) * (tY - st7[i].TargetY) + (tZ - st7[i].TargetZ) * (tZ - st7[i].TargetZ));
            }
        }

        /// <summary>
        /// X轴偏依移量
        /// </summary>
        public double DX
        {
            get
            {
                return values[0, 0];
            }
            set
            {
                values[0, 0] = value;
            }
        }

        /// <summary>
        /// Y轴偏依移量
        /// </summary>
        public double DY
        {
            get
            {
                return values[1, 0];
            }
            set
            {
                values[1, 0] = value;
            }
        }

        /// <summary>
        /// Z轴偏依移量
        /// </summary>
        public double DZ
        {
            get
            {
                return values[2, 0];
            }
            set
            {
                values[2, 0] = value;
            }
        }

        /// <summary>
        /// X轴旋转角度
        /// </summary>
        public double RX
        {
            get
            {
                return values[3, 0];
            }
            set
            {
                values[3, 0] = value;
            }
        }

        /// <summary>
        /// Y轴旋转角度
        /// </summary>
        public double RY
        {
            get
            {
                return values[4, 0];
            }
            set
            {
                values[4, 0] = value;
            }
        }

        /// <summary>
        /// Z轴旋转角度
        /// </summary>
        public double RZ
        {
            get
            {
                return values[5, 0];
            }
            set
            {
                values[5, 0] = value;
            }
        }

        /// <summary>
        /// 尺度
        /// </summary>
        public double K
        {
            get
            {
                return values[6, 0];
            }
            set
            {
                values[6, 0] = value;
            }
        }

        
    }

    public class Coords7ST
    {
        double sX, sY, sZ, tX, tY, tZ;

        double rms;

        public Coords7ST()
        {
            this.sX = 0; this.sY = 0; this.sZ = 0;
            this.tX = 0; this.tY = 0; this.tZ = 0;
            this.rms = 0;
        }
        
        public Coords7ST(double sX,double sY,double sZ,double tX,double tY,double tZ)
        {
            this.sX = sX; this.sY = sY; this.sZ = sZ;
            this.tX = tX; this.tY = tY; this.tZ = tZ;
            this.rms = 0;
        }

        public double SourceX
        {
            get { return this.sX; }
        }

        public double SourceY
        {
            get { return this.sY; }
        }

        public double SourceZ
        {
            get { return this.sZ; }
        }

        public double TargetX
        {
            get { return this.tX; }
        }

        public double TargetY
        {
            get { return this.tY; }
        }

        public double TargetZ
        {
            get { return this.tZ; }
        }

        public double RMS
        {
            get { return this.rms; }
            set { this.rms = value; }
        }
    }
}
