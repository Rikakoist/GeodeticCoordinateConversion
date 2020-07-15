using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    //高斯坐标类
    class GaussCoord
    {
        public int Type;    //带类型
        public int Zone;    //带号
        public double Center; //中央经线
        public double x;
        public double y;
    }

    //度分秒类
    class DMS
    {
        public double D;
        public double M;
        public double S;
    }

    //度分秒经纬度类
    class BL
    {
        public DMS B;
        public DMS L;
    }

    //十进制度类
    class DEC
    {
        public double B;
        public double L;
        public double Center;
        public int Zone;
    }

    class Tab1File
    {
        public BL Tab1FileBL;
        public GaussCoord Tab1FileGC;
    }

    class Tab2File
    {
        public GaussCoord Six;
        public GaussCoord Three;
    }
}
