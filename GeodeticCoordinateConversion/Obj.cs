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

    /// <summary>
    /// 度分秒类。
    /// </summary>
    class DMS
    {
        private double d;
        private double m;
        private double s;
        public double D
        {
            get
            {
                return d;
            }
            set
            {
                if(value<0)
                {
                    throw new ArgumentOutOfRangeException("度应大于等于0。");
                }
                else
                {
                    this.d = value;
                }
            }
        }
        public double M
        {
            get
            {
                return m;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("分应大于等于0。");
                }
                else
                {
                    this.m = value;
                }
            }
        }
        public double S
        {
            get
            {
                return s;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("秒应大于等于0。");
                }
                else
                {
                    this.s = value;
                }
            }
        }
        public DMS()
        {
            this.D = 0;this.M = 0;this.S = 0;
        }
        public DMS(double D, double M,double S)
        {
            this.D = D;this.M = M;this.S = S;
        }
    }

    //度分秒经纬度类
    class BL
    {
        public DMS B;
        public DMS L;

    }

    /// <summary>
    /// 十进制度类。
    /// </summary>
    class DEC
    {
        private double b;
        private double l;
        private double center;
        private int zone;
        private GEOZoneType zoneType;
        public double B
        {
            get
            {
                return b;
            }
            set
            {
                if ((value<-90.0)||(value>90.0))
                {
                    throw new ArgumentOutOfRangeException("纬度应介于-90~90间。");
                }
                else
                {
                    this.b = value;
                }
            }
        }
        public double L
        {
            get
            {
                return l;
            }
            set
            {
                if ((value < -180.0) || (value > 180.0))
                {
                    throw new ArgumentOutOfRangeException("经度应介于-180~180间。");
                }
                else
                {
                    this.l = value;
                }
            }
        }
        public double Center
        {
            get
            {
                return center;
            }
            set
            {
                //todo:约束条件
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("");
                }
                else
                {
                    this.center = value;
                }
            }
        }
        public int Zone
        {
            get
            {
                return zone;
            }
            set
            {
                //todo:约束条件
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("");
                }
                else
                {
                    this.zone = value;
                }
            }
        }
        public GEOZoneType ZoneType
        {
            get
            {
                return zoneType;
            }
            set
            {
                if (value==zoneType)
                {
                    return;
                }
                else
                {
                    this.zoneType = value;
                    recalc();
                }
            }
        }
        public DEC()
        {

        }
        public DEC(double B,double L,double Center)
        {

        }
        private bool recalc()
        {         
            switch (this.ZoneType)
            {
                case GEOZoneType.Zone3:
                    {
                        this.Zone = Convert.ToInt32(Math.Round(this.L / 3));
                        this.Center = 3 * this.Zone;
                        break;
                    }
                case GEOZoneType.Zone6:
                    {
                        this.Zone = Convert.ToInt32(Math.Round((this.L + 3) / 6));
                        this.Center = 6 * this.Zone - 3;
                        break;
                    }
                default:
                    {

                        return false;
                    }
            }
            return true;
        }
    }

    /// <summary>
    /// 高斯坐标分带枚举量。
    /// </summary>
    public enum GEOZoneType
    {
        None=0,
        Zone3=1,
        Zone6=2
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
