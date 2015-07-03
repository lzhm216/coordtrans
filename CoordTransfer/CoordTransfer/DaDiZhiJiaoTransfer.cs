using System;
using System.Collections.Generic;
using System.Text;

namespace CoordTransfer
{
    /// <summary>
    /// 大地坐标系和空间直角坐标系的转换
    /// </summary>
    public class DaDiZhiJiaoTransfer
    {
        private DaDiZhiJiaoTransferParamter m_paramter;

        public DaDiZhiJiaoTransferParamter Paramter
        {
            get { return m_paramter; }
            set { m_paramter = value; }
        }

        private static double m_PI = Math.PI;

        public DaDiZhiJiaoTransfer(DaDiZhiJiaoTransferParamter paramter)
        {
            this.m_paramter = paramter;
        }

        /// <summary>
        /// 大地坐标-->空间直角坐标
        /// </summary>
        public void DaDiToZhiJiao()
        {
            double n = this.m_paramter.TuoQiuJiChu.Long / Math.Sqrt(1 - this.m_paramter.TuoQiuJiChu.FirstE  *Math.Sin(this.m_paramter.B*m_PI/180)*Math.Sin(this.m_paramter.B*m_PI/180));
            this.m_paramter.X = (n + this.m_paramter.H) * Math.Cos(this.m_paramter.B * m_PI / 180)*Math.Cos(this.m_paramter.L*m_PI/180);
            this.m_paramter.Y = (n + this.m_paramter.H) * Math.Cos(this.m_paramter.B * m_PI / 180) * Math.Sin(this.m_paramter.L * m_PI / 180);
            this.m_paramter.Z = (n * (1 - this.m_paramter.TuoQiuJiChu.FirstE) + this.m_paramter.H) * Math.Sin(this.m_paramter.B * m_PI / 180);

            this.m_paramter.X = Math.Round(this.m_paramter.X, 6);
            this.m_paramter.Y = Math.Round(this.m_paramter.Y, 6);
            this.m_paramter.Z = Math.Round(this.m_paramter.Z, 6);
        }

        /// <summary>
        /// 空间直角坐标-->大地坐标
        /// </summary>
        public void ZhijiaoToDadi()
        {
            this.m_paramter.L = Math.Atan(this.m_paramter.Y / this.m_paramter.X);


            if ((this.m_paramter.Y > 0 && this.m_paramter.X < 0) || (this.m_paramter.Y < 0 && this.m_paramter.X > 0))

                this.m_paramter.L = 180 + this.m_paramter.L * 180 / m_PI;
            else
                this.m_paramter.L = this.m_paramter.L * 180 / m_PI;


            double B0 = Math.Atan(this.m_paramter.Z / Math.Sqrt(this.m_paramter.X * this.m_paramter.X + this.m_paramter.Y * this.m_paramter.Y));

            double n = CalcN(B0);

            double B = CalcB(B0,ref n);

            if ((this.m_paramter.Y > 0 && this.m_paramter.X < 0) || (this.m_paramter.Y < 0 && this.m_paramter.X > 0))
                this.m_paramter.B = B * 180 / m_PI;
            else
            this.m_paramter.B = 180 - B * 180 / m_PI;

            double h1 = this.m_paramter.Z / Math.Sin(B);
            double h2 = n * (1 - this.m_paramter.TuoQiuJiChu.FirstE);
            this.m_paramter.H = h1 - h2;

            this.m_paramter.B = this.m_paramter.B;
            this.m_paramter.L = this.m_paramter.L;
            this.m_paramter.H = this.m_paramter.H;
            
        }


        /// <summary>
        /// 迭代计算B
        /// </summary>
        /// <param name="B0">B初始值</param>
        /// <param name="n">n</param>
        /// <returns>B最终值</returns>
        private double CalcB(double B0, ref double n)
        {
            double Br;
            double B1 = Math.Atan((this.m_paramter.Z + n * this.m_paramter.TuoQiuJiChu.FirstE  * Math.Sin(B0)) / Math.Sqrt(this.m_paramter.X * this.m_paramter.X + this.m_paramter.Y * this.m_paramter.Y));
            n = CalcN(B1);
            if (Math.Abs((B1 - B0)) < 0.000000001)
                return B1;
            else
                Br = CalcB(B1, ref n);
            return Br;
        }

        private double CalcN(double B)
        {
            return  this.m_paramter.TuoQiuJiChu.Long / Math.Sqrt(1 - this.m_paramter.TuoQiuJiChu.FirstE * Math.Sin(B) * Math.Sin(B));
        }
    }

    public class DaDiZhiJiaoTransferParamter
    {
        private TuoQiuJiChu tuoQiuJiChu;

        public TuoQiuJiChu TuoQiuJiChu
        {
            get { return tuoQiuJiChu; }
            set { tuoQiuJiChu = value; }
        }

      

        private double b;

        public double B
        {
            get { return b; }
            set { b = value; }
        }

        private double l;

        public double L
        {
            get { return l; }
            set { l = value; }
        }

        private double h;

        public double H
        {
            get { return h; }
            set { h = value; }
        }

        private double x;

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        private double z;

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

    }
}
