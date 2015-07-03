using System;
using System.Collections.Generic;
using System.Text;

using CoordTransfer;
using Matrix;

namespace CoordTransfer
{
    public class CoordTrans4Param
    {
        double dx, dy, arf, k;

        public void SetParam(double dx, double dy, double a, double k)
        {
            this.dx = dx;
            this.dy = dy;
            this.arf = a;
            this.k = k;
        }

        public double DX
        {
            get { return this.dx; }
            set { this.dx = value; }
        }

        public double DY
        {
            get { return this.dy; }
            set { this.dy = value; }
        }

        public double Arf
        {
            get { return this.arf; }
            set { this.arf = value; }
        }

        public double K
        {
            get { return this.k; }
            set { this.k = value; }
        }

        /// <summary>
        /// 计算四参数
        /// </summary>
        /// <param name="st4"></param>
        public void CalculateTrans4Param(List<Coords4ST> st4)
        {
            int count = st4.Count;

            double[][] A = new double[count * 2][];
            for (int i = 0; i < count * 2; i++)
            {
                A[i] = new double[4];
            }

            double[][] B = new double[count * 2][];
            for (int i = 0; i < count * 2; i++)
            {
                B[i] = new double[1];
            }

            int idx = 0;
            for (int i = 0; i < count * 2; i = i + 2)
            {
                A[i][0] = 1; A[i][1] = 0; A[i][2] = st4[idx].SourceX; A[i][3] = -st4[idx].SourceY;
                A[i + 1][0] = 0; A[i + 1][1] = 1; A[i + 1][2] = st4[idx].SourceY; A[i + 1][3] = st4[idx].SourceX;

                B[i][0] = st4[idx].TargetX;
                B[i + 1][0] = st4[idx].TargetY;

                idx = idx + 1;
            }
            GeneralMatrix matrixA = new GeneralMatrix(A);
            GeneralMatrix matrixB = new GeneralMatrix(B);

            GeneralMatrix matrixParm = matrixA.Inverse().Multiply(matrixB);

            this.dx = matrixParm.GetElement(0, 0);
            this.dy = matrixParm.GetElement(1, 0);
            this.arf = Math.Atan(matrixParm.GetElement(3, 0) / matrixParm.GetElement(2, 0));
            this.k = matrixParm.GetElement(3, 0) / Math.Sin(this.arf);

        }

        /// <summary>
        /// 根据原坐标计算目标坐标
        /// </summary>
        /// <param name="x1">原坐标x</param>
        /// <param name="y1">原坐标y</param>
        /// <param name="x2">目标坐标x</param>
        /// <param name="y2">目标坐标y</param>
        public void CalTargetCoord(double x1, double y1, ref double x2, ref double y2)
        {
            x2 = this.dx + this.k * (Math.Cos(this.arf) * x1 - Math.Sin(this.arf) * y1);
            y2 = this.dy + this.k * (Math.Sin(this.arf) * x1 + Math.Cos(this.arf) * y1);
        }

        public void CalRMS(List<Coords4ST> st4)
        {
            if (st4 == null) return;
            for (int i = 0; i < st4.Count; i++)
            {
                double tX = 0, tY = 0;
                CalTargetCoord(st4[i].SourceX, st4[i].SourceY, ref tX, ref tY);
                st4[i].RMS = Math.Sqrt((tX - st4[i].TargetX) * (tX - st4[i].TargetX) + (tY - st4[i].TargetY) * (tY - st4[i].TargetY));
            }
        }
    }

    public class Coords4ST
    {
        double sX, sY, tX, tY;
        double rms;

        public Coords4ST()
        {
            this.sX = 0;this.sY = 0;
            this.tX = 0;this.tY = 0;
            this.rms = 0;
        }

        public Coords4ST(double sX, double sY, double tX, double tY)
        {
            this.sX = sX;this.sY = sY;
            this.tX = tX;this.tY = tY;
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

        public double TargetX
        {
            get { return this.tX; }
        }

        public double TargetY
        {
            get { return this.tY; }
        }
        public double RMS
        {
            get { return this.rms; }
            set { this.rms = value; }
        }
    }
}
