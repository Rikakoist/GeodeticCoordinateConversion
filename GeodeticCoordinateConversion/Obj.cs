using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
   

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
                if ((value < Restraints.DegreeMin) || (value > Restraints.DegreeMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.DegreeOutOfRange);
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
                if ((value < Restraints.MinuteMin) || (value > Restraints.MinuteMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.MinuteOutOfRange);
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
                if ((value < Restraints.SecondMin) || (value > Restraints.SecondMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.SecondOutOfRange);
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

    /// <summary>
    /// 度分秒经纬度类。
    /// </summary>
    public class BL
    {
        /// <summary>
        /// 分带类型（私有）。
        /// </summary>
        private GEOZoneType zoneType;

        /// <summary>
        /// 纬度。
        /// </summary>
        public DMS B;
        /// <summary>
        /// 经度。
        /// </summary>
        public DMS L;
        /// <summary>
        /// 分带类型。
        /// </summary>
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
                }
            }
        }
        /// <summary>
        /// 椭球。
        /// </summary>
        public Ellipse GEOEllipse;

        /// <summary>
        /// 空的构造函数。将会新建两个默认值的DMS对象。
        /// </summary>
        public BL()
        {
            this.B = new DMS(); this.L = new DMS();
        }

        /// <summary>
        /// 通过字符串初始化度分秒经纬度。
        /// </summary>
        /// <param name="B">字符串表示的纬度。</param>
        /// <param name="L">字符串表示的经度。</param>
        public BL(string B, string L)
        {
            this.B = GeoCalc.Str2DMS(B);
            this.L = GeoCalc.Str2DMS(L);
        }

        /// <summary>
        /// 通过DMS对象初始化。
        /// </summary>
        /// <param name="B">DMS类型的纬度对象。</param>
        /// <param name="L">DMS类型的经度对象。</param>
        public BL(DMS B, DMS L)
        {
            this.B = B; this.L = L;
        }

        /// <summary>
        /// 高斯正算（度分秒到高斯投影坐标）。
        /// </summary>
        /// <param name="CustomizeMode">强制自定义转换模式。</param>
        /// <returns>高斯正算结果。</returns>
        public GaussCoord GaussDirect(GEOZoneType CustomizeMode = GEOZoneType.None)
        {
            //转换为十进制度（可使用自定义模式）
            DEC CDEC = new DEC(GeoCalc.DMS2DEC(this.B), GeoCalc.DMS2DEC(this.L), (CustomizeMode != GEOZoneType.None) ? CustomizeMode : this.ZoneType);

            double a = this.GEOEllipse.a; double e = this.GEOEllipse.e; double e2 = this.GEOEllipse.e2;

            //克拉索夫斯基椭球元素
            double m0 = a * (1 - Math.Pow(e, 2));
            double m2 = 3 / 2 * Math.Pow(e, 2) * m0;
            double m4 = 5 / 4 * Math.Pow(e, 2) * m2;
            double m6 = 7 / 6 * Math.Pow(e, 2) * m4;
            double m8 = 9 / 8 * Math.Pow(e, 2) * m6;

            double a0 = m0 + m2 / 2 + 3 / 8 * m4 + 5 / 16 * m6 + 35 / 128 * m8;
            double a2 = m2 / 2 + m4 / 2 + 15 / 32 * m6 + 7 / 16 * m8;
            double a4 = m4 / 8 + 3 / 16 * m6 + 7 / 32 * m8;
            double a6 = m6 / 32 + m8 / 16;
            double a8 = m8 / 128;

            double l = (CDEC.L - CDEC.Center) * 3600;    //经度差转换为秒

            //十进制转弧度
            CDEC.B = GeoCalc.DEC2ARC(CDEC.B);
            CDEC.L = GeoCalc.DEC2ARC(CDEC.L);

            //计算中间参数
            double W = Math.Sqrt(1 - Math.Pow(e, 2) * Math.Pow((Math.Sin(CDEC.B)), 2));
            double M = a * Math.Pow(1 - e, 2) / Math.Pow(W, 3);
            double N = a / W;
            double n = Math.Pow(e2, 2) * Math.Pow((Math.Cos(CDEC.B)), 2);
            double p = 206265;

            //求子午线弧长
            double X = a0 * CDEC.B - Math.Sin(CDEC.B) * Math.Cos(CDEC.B) * ((a2 - a4 + a6) + (2 * a4 - 16 / 3 * a6) * Math.Pow(Math.Sin(CDEC.B), 2) + 16 / 3 * a6 * Math.Pow(Math.Sin(CDEC.B), 4));
            double t = Math.Tan(CDEC.B);

            //正算转换
            GaussCoord GaussResult = new GaussCoord
            {
                GEOEllipse = this.GEOEllipse,
                x = X + N / 2 * Math.Sin(CDEC.B) * Math.Cos(CDEC.B) * Math.Pow(l, 2) / Math.Pow(p, 2) + N / (24 * Math.Pow(p, 4)) * Math.Sin(CDEC.B) * (Math.Pow((Math.Cos(CDEC.B)), 3)) * (5 - Math.Pow(t, 2) + 9 * n + 4 * Math.Pow(n, 2)) * Math.Pow(l, 4) + N / (720 * Math.Pow(p, 6)) * Math.Sin(CDEC.B) * (Math.Pow((Math.Cos(CDEC.B)), 5)) * (61 - 58 * Math.Pow(t, 2) + Math.Pow(t, 4)) * Math.Pow(l, 6),
                y = N * Math.Cos(CDEC.B) * l / p + N / (6 * Math.Pow(p, 3)) * (Math.Pow(Math.Cos(CDEC.B), 3)) * (1 - Math.Pow(t, 2) + n) * Math.Pow(l, 3) + N / (120 * Math.Pow(p, 5)) * (Math.Pow(Math.Cos(CDEC.B), 5)) * (5 - 18 * Math.Pow(t, 2) + Math.Pow(t, 4) + 14 * n - 58 * Math.Pow(t, 2) * n) * Math.Pow(l, 5),
                ZoneType = CDEC.ZoneType,
                Zone = CDEC.Zone,
            };
            GaussResult.GetCenter();
            return GaussResult;
        }
    }

    /// <summary>
    /// 十进制度类（计算中间变量）。
    /// </summary>
    public class DEC
    {
        /// <summary>
        /// 纬度（私有）。
        /// </summary>
        private double b;
        /// <summary>
        /// 经度（私有）。
        /// </summary>
        private double l;
        /// <summary>
        /// 中央经线（私有）。
        /// </summary>
        private double center;
        /// <summary>
        /// 分带类型（私有）。
        /// </summary>
        private GEOZoneType zoneType;
        /// <summary>
        /// 带号（私有）。
        /// </summary>
        private int zone;

        /// <summary>
        /// 纬度。
        /// </summary>
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
                    throw new ArgumentOutOfRangeException(ErrMessage.BiotitudeOutOfRange);
                }
                else
                {
                    this.b = value;
                }
            }
        }
        /// <summary>
        /// 经度。
        /// </summary>
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
                    throw new ArgumentOutOfRangeException(ErrMessage.LongitudeOutOfRange);
                }
                else
                {
                    this.l = value;
                }
            }
        }
        /// <summary>
        /// 中央经线。
        /// </summary>
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
                    throw new ArgumentOutOfRangeException(ErrMessage.LongitudeOutOfRange);
                }
                else
                {
                    this.center = value;
                }
            }
        }
        /// <summary>
        /// 分带类型。
        /// </summary>
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
        /// <summary>
        /// 带号。
        /// </summary>
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
                            break;
                            //throw new ArgumentException(ErrMessage.ZoneTypeNotSet);
                        }
                    case GEOZoneType.Zone3:
                        {
                            if ((value < Restraints.Zone3Min) || (value > Restraints.Zone3Max))
                            {
                                throw new ArgumentOutOfRangeException(ErrMessage.Zone3OutOfRange);
                            }
                            this.zone = value;
                            break;
                        }
                    case GEOZoneType.Zone6:
                        {
                            if ((value < Restraints.Zone6Min) || (value > Restraints.Zone6Max))
                            {
                                throw new ArgumentOutOfRangeException(ErrMessage.Zone6OutOfRange);
                            }
                            this.zone = value;
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException(ErrMessage.ArgumentUnknown);
                        }
                }
            }
        }

        /// <summary>
        /// 空的构造函数。B、L为0.0，且分带类型为None。
        /// </summary>
        public DEC()
        {
            this.B = 0.0; this.L = 0.0; this.zoneType = GEOZoneType.None;
        }

        /// <summary>
        /// 带参数的构造函数。
        /// </summary>
        /// <param name="B">纬度。</param>
        /// <param name="L">经度。</param>
        /// <param name="ZoneType">分带类型。</param>
        public DEC(double B, double L, GEOZoneType ZoneType)
        {
            this.B = B; this.L = L; this.ZoneType = ZoneType;
        }

        /// <summary>
        /// 根据分带类型重新计算带号和中央经线，在更改分带类型后自动触发。
        /// </summary>
        /// <returns>计算是否成功。</returns>
        private bool Recalc()
        {
            switch (this.ZoneType)
            {
                case GEOZoneType.None:
                    {
                        throw new ArgumentException(ErrMessage.ZoneTypeNotSet);
                    }
                case GEOZoneType.Zone3:
                    {
                        this.Zone = Convert.ToInt32(Math.Round(this.L / 3));
                        this.Center = 3.0 * this.Zone;
                        break;
                    }
                case GEOZoneType.Zone6:
                    {
                        this.Zone = Convert.ToInt32(Math.Round((this.L + 3) / 6));
                        this.Center = 6.0 * this.Zone - 3;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(ErrMessage.ArgumentUnknown);
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
        Zone3 = 3,
        /// <summary>
        /// 6度带。
        /// </summary>
        Zone6 = 6
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
