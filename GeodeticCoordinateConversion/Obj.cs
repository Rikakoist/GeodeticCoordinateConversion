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
    public class DMS
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
                if ((value < Restraints.DegreeMin)||(value>Restraints.DegreeMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessages.DegreeOutOfRange);
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
                if ((value < Restraints.MinuteMin)||(value>Restraints.MinuteMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessages.MinuteOutOfRange);
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
                if ((value < Restraints.SecondMin)||(value>Restraints.SecondMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessages.SecondOutOfRange);
                }
                else
                {
                    this.s = value;
                }
            }
        }
        public DMS()
        {
            this.D = 0; this.M = 0; this.S = 0;
        }
        public DMS(double D, double M, double S)
        {
            this.D = D; this.M = M; this.S = S;
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
                if ((value < Restraints.BiotitudeMin) || (value > Restraints.BiotitudeMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessages.BiotitudeOutOfRange);
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
                if ((value < Restraints.LongitudeMin) || (value > Restraints.LongitudeMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessages.LongitudeOutOfRange);
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
                if ((value < Restraints.LongitudeMin) || (value > Restraints.LongitudeMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessages.LongitudeOutOfRange);
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
                switch (this.ZoneType)
                {
                    case GEOZoneType.None:
                        {
                            throw new ArgumentException(ErrMessages.ZoneTypeNotSet);
                        }
                    case GEOZoneType.Zone3:
                        {
                            if ((value < Restraints.Zone3Min) || (value > Restraints.Zone3Max))
                            {
                                throw new ArgumentOutOfRangeException(ErrMessages.Zone3OutOfRange);
                            }
                            this.zone = value;
                            break;
                        }
                    case GEOZoneType.Zone6:
                        {
                            if ((value < Restraints.Zone6Min) || (value > Restraints.Zone6Max))
                            {
                                throw new ArgumentOutOfRangeException(ErrMessages.Zone6OutOfRange);
                            }
                            this.zone = value;
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException(ErrMessages.ArgumentUnknown);
                        }
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
                if (value == zoneType)
                {
                    return;
                }
                else
                {
                    this.zoneType = value;
                    Recalc();
                }
            }
        }
        public DEC()
        {

        }

        public DEC(double B, double L, GEOZoneType ZoneType)
        {
            this.B = B; this.L = L; this.ZoneType = ZoneType;
        }

        private bool Recalc()
        {
            switch (this.ZoneType)
            {
                case GEOZoneType.None:
                    {
                        throw new ArgumentException(ErrMessages.ZoneTypeNotSet);
                    }
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
                        throw new ArgumentException(ErrMessages.ArgumentUnknown);
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
        /// <summary>
        /// 未设置分带。
        /// </summary>
        None = 0,
        /// <summary>
        /// 3度带。
        /// </summary>
        Zone3 = 1,
        /// <summary>
        /// 6度带。
        /// </summary>
        Zone6 = 2
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
