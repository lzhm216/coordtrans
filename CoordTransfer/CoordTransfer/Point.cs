using System;
using System.Collections.Generic;
using System.Text;

namespace CoordTransfer
{
    public class PointBL
    {
        private double latitude;
        /// <summary>
        /// Î³¶È
        /// </summary>
        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        private double longitude;
        /// <summary>
        /// ¾­¶È
        /// </summary>
        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public PointBL(double Lat,double Lon)
        {
            this.longitude = Lon;
            this.latitude = Lat;
        }

    }

   
}
