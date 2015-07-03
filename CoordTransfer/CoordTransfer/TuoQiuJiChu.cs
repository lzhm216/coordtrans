using System;
using System.Collections.Generic;
using System.Text;

namespace CoordTransfer
{
    /// <summary>
    /// 椭球基准
    /// </summary>
    public class TuoQiuJiChu
    {

        private double m_Long;
        /// <summary>
        /// 长半轴
        /// </summary>
        public double Long
        {
            get { return m_Long; }
            set { m_Long = value; }
        }

        private double m_Short;
        /// <summary>
        /// 短半轴
        /// </summary>
        public double Short
        {
            get { return m_Short; }
            set { m_Short = value; }
        }

      
        /// <summary>
        /// 扁率
        /// </summary>
        public double Alpha
        {
            get 
            {
                return (this.m_Long - this.m_Short) / this.m_Long; 
            }
            

        }

       
        /// <summary>
        /// 第一偏心率的平方
        /// </summary>
        public double FirstE
        {
            get
            {
                return (this.m_Long * this.m_Long - this.m_Short * this.m_Short) / (this.m_Long * this.m_Long);
            }


        }

      
        /// <summary>
        /// 第二偏心率的平方
        /// </summary>
        public double SecondE
        {
            get
            {
                return (this.m_Long * this.m_Long - this.m_Short * this.m_Short) / (this.m_Short * this.m_Short);
            }


        }


        private string m_Name;
        /// <summary>
        /// 椭球名称
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        

        public TuoQiuJiChu()
        { 
        
        }

        public TuoQiuJiChu(string name)
        {
            if (name == "WGS1984" || name == "WGS84")
            {
                this.m_Name = "WGS1984";
                this.m_Long = 6378137;
                this.m_Short = 6356752.31414;
            }
            else if (name == "西安1980" || name == "Xian1980")
            {
                this.m_Name = "西安1980";
                this.m_Long = 6378140;
                this.m_Short = 6356755.2882;
            }
            else if (name == "北京1954" || name == "Beijing1954")
            {
                this.m_Name = "北京1954";
                this.m_Long = 6378245;
                this.m_Short = 6356863.0188;
            }
            else if (name == "CGCS2000")
            {
                this.m_Name = "CGCS2000";
                this.m_Long = 6378137;
                this.m_Short = 6356752.31414;
            }
        }

        public TuoQiuJiChu(string name, double long_radius, double short_radius)
        {
            this.m_Name = name;
            this.m_Long = long_radius;
            this.m_Short = short_radius;
        }
        /// <summary>
        /// WGS-84坐标系
        /// </summary>
        public static TuoQiuJiChu WGS1984 = new TuoQiuJiChu("WGS1984", 6378137, 6356752.31414);
        /// <summary>
        /// 西安-80坐标系
        /// </summary>
        public static TuoQiuJiChu Xian1980 = new TuoQiuJiChu("西安1980", 6378140, 6356755.2882);
        /// <summary>
        /// 北京-54坐标系
        /// </summary>
        public static TuoQiuJiChu Beijing1954 = new TuoQiuJiChu("北京1954", 6378245, 6356863.0188);

        /// <summary>
        /// WGS-84坐标系
        /// </summary>
        public static TuoQiuJiChu CGCS2000 = new TuoQiuJiChu("CGCS2000", 6378137, 6356752.31414);

        /// <summary>
        /// 返回所有坐标系
        /// </summary>
        /// <returns></returns>
        public static IList<TuoQiuJiChu> GetAllTuoQiuJiChu()
        {
            IList<TuoQiuJiChu> result = new List<TuoQiuJiChu>();

            result.Add(WGS1984);
            result.Add(Xian1980);
            result.Add(Beijing1954);

            return result;
        }
	
    }
}
