using System;
using System.Collections.Generic;
using System.Text;

namespace CoordTransfer
{
    public class PositionVectorTransferParamter
    {

        private CoordTrans7Param m_CoordTrans7Param;

        public CoordTrans7Param CoordTrans7Param
        {
            get { return m_CoordTrans7Param; }
            set { m_CoordTrans7Param = value; }
        }

       

        private IList<PointBL> m_InPoints;
        public IList<PointBL> InPoints
        {
            get { return m_InPoints; }
            set { m_InPoints = value; }
        }

        private IList<PointBL> m_OutPoints;
        public IList<PointBL> OutPoints
        {
            get { return m_OutPoints; }
            set { m_OutPoints = value; }
        }

    }
}
