using System;
using System.Collections.Generic;
using System.Text;

namespace CoordTransfer
{
    /// <summary>
    /// �����׼
    /// </summary>
    public class TuoQiuJiChu
    {

        private double m_Long;
        /// <summary>
        /// ������
        /// </summary>
        public double Long
        {
            get { return m_Long; }
            set { m_Long = value; }
        }

        private double m_Short;
        /// <summary>
        /// �̰���
        /// </summary>
        public double Short
        {
            get { return m_Short; }
            set { m_Short = value; }
        }

      
        /// <summary>
        /// ����
        /// </summary>
        public double Alpha
        {
            get 
            {
                return (this.m_Long - this.m_Short) / this.m_Long; 
            }
            

        }

       
        /// <summary>
        /// ��һƫ���ʵ�ƽ��
        /// </summary>
        public double FirstE
        {
            get
            {
                return (this.m_Long * this.m_Long - this.m_Short * this.m_Short) / (this.m_Long * this.m_Long);
            }


        }

      
        /// <summary>
        /// �ڶ�ƫ���ʵ�ƽ��
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
        /// ��������
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
            else if (name == "����1980" || name == "Xian1980")
            {
                this.m_Name = "����1980";
                this.m_Long = 6378140;
                this.m_Short = 6356755.2882;
            }
            else if (name == "����1954" || name == "Beijing1954")
            {
                this.m_Name = "����1954";
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
        /// WGS-84����ϵ
        /// </summary>
        public static TuoQiuJiChu WGS1984 = new TuoQiuJiChu("WGS1984", 6378137, 6356752.31414);
        /// <summary>
        /// ����-80����ϵ
        /// </summary>
        public static TuoQiuJiChu Xian1980 = new TuoQiuJiChu("����1980", 6378140, 6356755.2882);
        /// <summary>
        /// ����-54����ϵ
        /// </summary>
        public static TuoQiuJiChu Beijing1954 = new TuoQiuJiChu("����1954", 6378245, 6356863.0188);

        /// <summary>
        /// WGS-84����ϵ
        /// </summary>
        public static TuoQiuJiChu CGCS2000 = new TuoQiuJiChu("CGCS2000", 6378137, 6356752.31414);

        /// <summary>
        /// ������������ϵ
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
