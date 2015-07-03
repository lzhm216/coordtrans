using System;
using System.Collections.Generic;
using System.Text;

namespace CoordTransfer
{
    public class DaDiPingMianTransfer
    {
        DaDiPingMianTransferParameter m_paramter;

        public DaDiPingMianTransferParameter Paramters
        {
            get { return this.m_paramter; }
            set { this.m_paramter = value; }
        }

        
        public DaDiPingMianTransfer(){}

        public DaDiPingMianTransfer(DaDiPingMianTransferParameter paramter)
        {
            this.m_paramter = paramter;
        }

        #region 大地--->平面,平面---->大地
        /// <summary>
        /// 大地--->平面
        /// </summary>
        public void DaDiToPingMian()
        {

            double X, N, ng2;
            double sB, cB, tB, tB2;

            double B = this.m_paramter.B * Math.PI / 180;
            double L = (this.m_paramter.L - this.m_paramter.Central_Meridian )* Math.PI / 180;  //经度减去中央子午线

            X = CalcXParam();   //由赤道到纬度B处的经线长度
            sB = Math.Sin(B);
            cB = Math.Cos(B);
            tB = Math.Tan(B);

            tB2 = tB * tB;  //tanB的平方
            N = this.m_paramter.TuoQiuJiChu.Long / Math.Sqrt(1 - this.m_paramter.TuoQiuJiChu.FirstE * sB * sB);

            ng2 = cB * cB * this.m_paramter.TuoQiuJiChu.SecondE;

            double k1 = N * sB * cB / 2;
            double K2 = N * sB * Math.Pow(cB, 3) * (5 - tB2 + 9 * ng2 + 4 * ng2 * ng2) / 24;
            double k3 = N * sB * Math.Pow(cB, 5) * (61 - 58 * tB2 + tB2 * tB2 + 270 * ng2 - 330 * ng2 * tB2) / 720;
                
            this.m_paramter.X = X + L * L * k1 + Math.Pow(L, 4) * K2 + Math.Pow(L, 6) * k3;

            this.m_paramter.Y = N * cB * L + N * Math.Pow(cB, 3) * Math.Pow(L, 3) * (1 - tB2 + ng2) / 6 + N * Math.Pow(cB, 5) * Math.Pow(L, 5) * (5 - 18 * tB2 + tB2 * tB2) / 120;
            this.m_paramter.Y = this.m_paramter.Y + 500000;

            this.m_paramter.X = Math.Round(this.m_paramter.X, 6);
            this.m_paramter.Y = Math.Round(this.m_paramter.Y, 6);

        }

        private double CalcXParam()
        {
            double arcB = this.m_paramter.B * Math.PI / 180;
            
            double firstE = this.m_paramter.TuoQiuJiChu.FirstE;

            double []a2g = CalcA2G(firstE);

            return this.m_paramter.TuoQiuJiChu.Long * (1 - firstE) * (a2g[0] * arcB - a2g[1] * Math.Sin(2 * arcB) + a2g[2] * Math.Sin(4 * arcB) - a2g[3] * Math.Sin(6 * arcB) + a2g[4] * Math.Sin(8 * arcB) - a2g[5] * Math.Sin(10 * arcB) + a2g[6] * Math.Sin(12 * arcB));

        }


        private double[] CalcA2G(double firstE)
        {
            double[] a2g = new double[7];
            a2g[0] = 1 + 3 * firstE / 4 + 45 * Math.Pow(firstE, 2) / 64 + 175 * Math.Pow(firstE, 3) / 256 + 11025 * Math.Pow(firstE, 4) / 16384 + 43659 * Math.Pow(firstE, 5) / 65536 + 693693 * Math.Pow(firstE, 6) / 1048576;
            a2g[1] = 3 * firstE / 8 + 15 * Math.Pow(firstE, 2) / 32 + 525 * Math.Pow(firstE, 3) / 1024 + 2205 * Math.Pow(firstE, 4) / 4096 + 72765 * Math.Pow(firstE, 5) / 131072 + 10297297 * Math.Pow(firstE, 6) / 524288;
            a2g[2] = 15 * Math.Pow(firstE, 2) / 256 + 105 * Math.Pow(firstE, 3) / 1024 + 2205 * Math.Pow(firstE, 4) / 16384 + 10395 * Math.Pow(firstE, 5) / 65536 + 1486485 * Math.Pow(firstE, 6) / 8388608;
            a2g[3] = 35 * Math.Pow(firstE, 3) / 3072 + 105 * Math.Pow(firstE, 4) / 4096 + 10395 * Math.Pow(firstE, 5) / 262144 + 55055 * Math.Pow(firstE, 6) / 1048576;
            a2g[4] = 315 * Math.Pow(firstE, 4) / 131072 + 3465 * Math.Pow(firstE, 5) / 524288 + 99099 * Math.Pow(firstE, 6) / 8388608;
            a2g[5] = 693 * Math.Pow(firstE, 5) / 1310720 + 9009 * Math.Pow(firstE, 6) / 5242880;
            a2g[6] = 1001 * Math.Pow(firstE, 6) / 8388608;
            return a2g;

        }

        /// <summary>
        ///  方法二:大地--->平面
        /// </summary>
        public void DaDiToPingMian2()
        {
            double A = this.m_paramter.TuoQiuJiChu.Long;
            double C = this.m_paramter.TuoQiuJiChu.Long * this.m_paramter.TuoQiuJiChu.Long / this.m_paramter.TuoQiuJiChu.Short;

            double ng2, n, tB, cosL;   //中间变量

            double B = this.m_paramter.B * Math.PI / 180;
            double L = (this.m_paramter.L - this.m_paramter.Central_Meridian) * Math.PI / 180;

            ng2 = this.m_paramter.TuoQiuJiChu.SecondE * Math.Cos(B) * Math.Cos(B);
            n = C / Math.Sqrt(1 + ng2);       //曲率半径
            
            tB = Math.Tan(B);
            cosL = Math.Cos(B) * L;

            double X = 0;
            if (this.m_paramter.TuoQiuJiChu.Name == "北京1954")
                X = 6367558.49687498 * B - 16036.4801 * Math.Sin(2 * B) + 16.8281 * Math.Sin(4 * B) - 0.0219753092 * Math.Sin(6 * B) + 3.11311 * 0.00001 * Math.Sin(8 * B) - 4.6 * 0.00000001 * Math.Sin(10 * B);
            else if (this.m_paramter.TuoQiuJiChu.Name == "西安1980")
                X = 111133.0047 * B * 180 / Math.PI - (32009.8575 * Math.Sin(B) + 133.9602 * Math.Pow(Math.Sin(B), 3) + 0.6976 * Math.Pow(Math.Sin(B), 5) + 0.0039 * Math.Pow(Math.Sin(B), 7)) * Math.Cos(B);


            this.m_paramter.X = X + n * cosL * cosL * tB / 2 + n * Math.Pow(cosL, 4) * tB * (5 - tB * tB + 9 * ng2 + 4 * ng2 * ng2) / 24 + n * Math.Pow(cosL, 6) * (61 - 58 * tB * tB + Math.Pow(tB, 4)) * tB / 720;
            this.m_paramter.Y = n * cosL + n * (1 - tB * tB + ng2) * Math.Pow(cosL, 3) / 6 + n * (5 - 18 * tB * tB + Math.Pow(tB, 4) + 14 * ng2 - 58 * ng2 * tB * tB) * Math.Pow(cosL, 5) / 120;

        }


        /// <summary>
        /// 平面--->大地
        /// </summary>
        public void PingMianToDaDi()
        {
            double a = this.m_paramter.TuoQiuJiChu.Long;
            double e2 = this.m_paramter.TuoQiuJiChu.FirstE;
            double[] a2g = CalcA2G(e2);
            double B0 = this.m_paramter.X / (a * (1 - e2)) / a2g[0];
            double Bf = CalcB(B0, this.m_paramter.X, a2g);

            double t2 = Math.Tan(Bf) * Math.Tan(Bf);
            double ng2 = this.m_paramter.TuoQiuJiChu.SecondE * Math.Cos(Bf) * Math.Cos(Bf);
            double W = Math.Sqrt(1 - e2 * Math.Sin(Bf) * Math.Sin(Bf));
            double N = a / W;
            double M = a * (1 - e2) / Math.Pow(W, 3); 

            this.m_paramter.Y = this.m_paramter.Y - 500000;
            double ycN = this.m_paramter.Y / N;

            double k1 = (5 + 3 * t2 + ng2 - 9 * ng2 * t2) * ycN * ycN / 12;
            double k2 = (61 + 90 * t2 + 45 * t2 * t2) * Math.Pow(ycN, 4) / 360;

            this.m_paramter.B = Bf - Math.Tan(Bf) * this.m_paramter.Y * ycN * (1 - k1 + k2) / (2  * M);
            
            double k3 = (1 + 2 * t2 + ng2) * ycN * ycN / 6;
            double k4 = (5 + 28 * t2 + 24 * t2 * t2 + 6 * ng2 + 8 * t2 * ng2) * Math.Pow(ycN, 4) / 120;

            this.m_paramter.L = ycN * (1 - k3 + k4) / Math.Cos(Bf);

            this.m_paramter.B = this.m_paramter.B * 180 / Math.PI;
            this.m_paramter.L = this.m_paramter.L * 180 / Math.PI + this.m_paramter.Central_Meridian;

            this.m_paramter.B = Math.Round(this.m_paramter.B, 8);
            this.m_paramter.L = Math.Round(this.m_paramter.L, 8);

        }

        private double CalcB(double B, double X, double[] a2g)
        {
            double Bf = 0;

            double B1 = B + (X - CalcFB(B, a2g)) / CalcFB1(B, a2g) / a2g[0];
            if ((B1 - B) < 0.000000000000001)
                Bf = B1;
            else
                Bf = CalcB(B1, X, a2g);
            return Bf;
        }

        private double CalcFB(double B, double[] a2g)
        {
            double a = this.m_paramter.TuoQiuJiChu.Long;
            double e2 = this.m_paramter.TuoQiuJiChu.FirstE;


            double FBf = a * (1 - e2) * (a2g[0] * B - a2g[1] * Math.Sin(2 * B) + a2g[2] * Math.Sin(4 * B) - a2g[3] * Math.Sin(6 * B) + a2g[4] * Math.Sin(8 * B) - a2g[5] * Math.Sin(10 * B) + a2g[6] * Math.Sin(12 * B));
            return FBf;
        }

        private double CalcFB1(double B, double[] a2g)
        {
            double a = this.m_paramter.TuoQiuJiChu.Long;
            double e2 = this.m_paramter.TuoQiuJiChu.FirstE;

            return a * (1 - e2) * (a2g[0] - 2 * a2g[1] * Math.Cos(2 * B) + 4 * a2g[2] * Math.Cos(4 * B) - 6 * a2g[3] * Math.Cos(6 * B) + 8 * a2g[4] * Math.Cos(8 * B) - 10 * a2g[5] * Math.Cos(10 * B) + 12 * a2g[6] * Math.Cos(12 * B));
        }

        #endregion


        /// <summary>
        /// 根据经度和分带类型计算中央子午线
        /// </summary>
        private double GetCenMeridian(double lon, int dd)
        {
            int n;
            int l;
            n = GetZoneNo(lon, dd);
            if (dd == 6)
                l = n * 6 - 3;
            else
                l = n * 3;

            return l;
        }

        /// <summary>
        ///根据经度和分带带宽获取带号
        /// </summary>
        private int GetZoneNo(double lon, int dd)
        {
            int n;
            if (dd == 6)
                n = (int)(lon / dd) + 1;
            else
                n = (int)(lon / dd + 0.5);

            return n;
        }

       

        //public void UTMToXY()
        //{
        //    double a = 6378137;
        //    double b = 6356752.3142;
        //    double e1, e2, e3;
        //    double X;//纵直角坐标
        //    double Y;//横直角坐标
        //    double L0 = 87.00;//原点经度
        //    double T;
        //    double C;
        //    double N;
        //    double A;
        //    double M, m1, m2, m3, m4;
        //    double x1, x2;
        //    double K0 = 0.9996;
        //    double FE;
        //    double[] BLtoXY = new double[2];
        //    double B = this.m_paramter.B;
        //    double L = this.m_paramter.L;

        //    B = B * Math.PI / 180.00;
        //    FE = 500000;//东纬偏移
        //    e1 = Math.Sqrt(1 - Math.Pow((b / a), 2.00));
        //    e2 = Math.Sqrt(Math.Pow((a / b), 2.00) - 1.00);

        //    T = Math.Pow(Math.Tan(B), 2.00);
        //    C = Math.Pow(e2, 2.00) * Math.Pow(Math.Cos(B), 2.00);
        //    A = (L * Math.PI / 180.00 - L0 * Math.PI / 180) * Math.Cos(B);

        //    m1 = (1 - Math.Pow(e1, 2.00) / 4.00 - 3 * Math.Pow(e1, 4.00) / 64.00 - 5 * Math.Pow(e1, 6.00) / 256) * (B);
        //    m2 = Math.Sin(2 * (B)) * (3 * Math.Pow(e1, 2.00) / 8 + 3 * Math.Pow(e1, 4.00) / 32 + 45 * Math.Pow(e1, 6.00) / 1024);
        //    m3 = (15 * Math.Pow(e1, 4.00) / 256 + 45 * Math.Pow(e1, 6.00) / 1024) * Math.Sin(4 * B);
        //    m4 = (35 * Math.Pow(e1, 6.00) / 3072) * Math.Sin(6 * B);
        //    M = a * (m1 - m2 + m3 - m4);

        //    N = a / (Math.Sqrt(1 - Math.Pow(e1, 2.00) * Math.Pow(Math.Sin(B), 2.00)));

        //    x1 = N * Math.Tan(B) * ((Math.Pow(A, 2.00) / 2) + (5 - T + 9 * C + 4 * Math.Pow(C, 2.00)) * Math.Pow(A, 4.00) / 24);
        //    x2 = (61 - 58 * T + Math.Pow(T, 2.00) + 600 * C - 330 * Math.Pow(e2, 2.0)) * Math.Pow(A, 6.00) / 720;
        //    X = K0 * (M + x1 + x2);

        //    Y = FE + K0 * N * (A + (1 - T + C) * (Math.Pow(A, 3.00) / 6.00) + (5 - 18 * T + Math.Pow(T, 2.00) +
        //        72 * C - 58 * Math.Pow(e2, 2.0)) * (Math.Pow(A, 5.00) / 120));

        //    this.m_paramter.X = X;
        //    this.m_paramter.Y = Y;
        //}

        ////这段程序是采用的是北京54 UTM投影的成投影坐标转换经纬度
        ////输入经纬度坐标 X（横轴坐标） Y（竖轴坐标）
        ////返回 数组 XYtoBL[0]为纬度  XYtoBL[1]为经度
        //public double[] UTMXYtoBL(double Xn, double Yn)
        //{
        //    double[] XYtoBL = new double[2];

        //    double Mf;
        //    double L0 = 87;//中央经度
        //    double Nf;
        //    double Tf, Bf;
        //    double Cf;
        //    double Rf;
        //    double b1, b2, b3;
        //    double r1, r2;
        //    double K0 = 0.9996;
        //    double D, S;
        //    double FE = 500000;//东纬偏移
        //    double FN = 0;
        //    double a = 6378245;
        //    double b = 6356863.0188;
        //    double e1, e2, e3;
        //    double B;
        //    double L;

        //    L0 = L0 * Math.PI / 180;//弧度

        //    e1 = Math.Sqrt(1 - Math.Pow((b / a), 2.00));
        //    e2 = Math.Sqrt(Math.Pow((a / b), 2.00) - 1);
        //    e3 = (1 - b / a) / (1 + b / a);

        //    Mf = (Xn - FN) / K0;
        //    S = Mf / (a * (1 - Math.Pow(e1, 2.00) / 4 - 3 * Math.Pow(e1, 4.00) / 64 - 5 * Math.Pow(e1, 6.00) / 256));

        //    b1 = (3 * e3 / 2.00 - 27 * Math.Pow(e3, 3.00) / 32.00) * Math.Sin(2.00 * S);
        //    b2 = (21 * Math.Pow(e3, 2.00) / 16 - 55 * Math.Pow(e3, 4.00) / 32) * Math.Sin(4 * S);
        //    b3 = (151 * Math.Pow(e3, 3.00) / 96) * Math.Sin(6 * S);
        //    Bf = S + b1 + b2 + b3;

        //    Nf = (Math.Pow(a, 2.00) / b) / Math.Sqrt(1 + Math.Pow(e2, 2.00) * Math.Pow(Math.Cos(Bf), 2.00));
        //    r1 = a * (1 - Math.Pow(e1, 2.00));
        //    r2 = Math.Pow((1 - Math.Pow(e1, 2.00) * Math.Pow(Math.Sin(Bf), 2.00)), 3.0 / 2.0);
        //    Rf = r1 / r2;
        //    Tf = Math.Pow(Math.Tan(Bf), 2.00);
        //    Cf = Math.Pow(e2, 2.00) * Math.Pow(Math.Cos(Bf), 2.00);
        //    D = (Yn - FE) / (K0 * Nf);

        //    b1 = Math.Pow(D, 2.00) / 2.0;
        //    b2 = (5 + 3 * Tf + 10 * Cf - 4 * Math.Pow(Cf, 2.0) - 9 * Math.Pow(e2, 2.0)) * Math.Pow(D, 4.00) / 24;
        //    b3 = (61 + 90 * Tf + 298 * Cf + 45 * Math.Pow(Tf, 2.00) - 252 * Math.Pow(e2, 2.0) - 3 * Math.Pow(Cf, 2.0)) * Math.Pow(D, 6.00) / 720;
        //    B = Bf - Nf * Math.Tan(Bf) / Rf * (b1 - b2 + b3);
        //    B = B * 180 / Math.PI;
        //    L = (L0 + (1 / Math.Cos(Bf)) * (D - (1 + 2 * Tf + Cf) * Math.Pow(D, 3) / 6 + (5 + 28 * Tf - 2 * Cf - 3
        //        * Math.Pow(Cf, 2.0) + 8 * Math.Pow(e2, 2.0) + 24 * Math.Pow(Tf, 2.0)) * Math.Pow(D, 5.00) / 120)) * 180 / Math.PI;
        //    L0 = L0 * 180 / Math.PI;//转化为度

        //    XYtoBL[0] = B;
        //    XYtoBL[1] = L;

        //    return XYtoBL;
        //}


        //public double[] BJXYToWGSXY(double x, double y)
        //{
        //    double[] temp = new double[2];
        //    temp = this.UTMXYtoBL(x, y);
        //    //temp = this.UTMToXY(temp[0], temp[1]);
        //    //temp = this.UTMToXY();
        //    return temp;
        //}
        //public double[] XYToSpherical(double X, double Y, double R)
        //{
        //    double[] Spherical = new double[3];
        //    double[] BL = new double[2];

        //    BL = this.UTMXYtoBL(Y, X);
        //    BL[0] *= Math.PI / 180;
        //    BL[1] *= Math.PI / 180;
        //    double temp = R * Math.Cos(BL[0]);

        //    Spherical[0] = temp * Math.Cos(BL[1]);
        //    Spherical[1] = temp * Math.Sin(BL[1]);
        //    Spherical[2] = R * Math.Sin(BL[0]);

        //    return Spherical;
        //}


    }

    public class DaDiPingMianTransferParameter
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

        private double central_Meridian;

        public double Central_Meridian
        {
            get { return this.central_Meridian; }
            set { this.central_Meridian = value; }
        }
    }
}
