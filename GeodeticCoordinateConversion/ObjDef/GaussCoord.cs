using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 高斯坐标类。
    /// </summary>
    public class GaussCoord
    {
        /// <summary>
        /// 分带类型（私有）。
        /// </summary>
        private GEOZoneType zoneType;
        /// <summary>
        /// 带号（私有）。
        /// </summary>
        private int zone;
        /// <summary>
        /// 分带类型。
        /// </summary>
        public double Center; //中央经线
        public double x;
        public double y;
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
        /// 椭球。
        /// </summary>
        public Ellipse GEOEllipse;

        /// <summary>
        /// 计算中央经线。
        /// </summary>
        /// <returns>计算是否成功。</returns>
        public bool GetCenter()
        {
            switch (this.ZoneType)
            {
                case GEOZoneType.None:
                    {
                        throw new ArgumentException(ErrMessage.ZoneTypeNotSet);
                    }
                case GEOZoneType.Zone3:
                    {
                        this.Center = 3.0 * this.Zone;
                        break;
                    }
                case GEOZoneType.Zone6:
                    {
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

        /// <summary>
        /// 高斯反算（高斯投影坐标到度分秒）。
        /// </summary>
        /// <returns>高斯反算结果。</returns>
        public BL GaussReverse()
        {
            double a = this.GEOEllipse.a; double e = this.GEOEllipse.e; double e2 = this.GEOEllipse.e2;

            double beta = this.x / 6367588.4969;
            double Bf = beta + (50221746 + (293622 + (2350 + 22 * Math.Pow(Math.Cos(beta), 2)) * Math.Pow(Math.Cos(beta), 2)) * Math.Pow(Math.Cos(beta), 2)) * Math.Pow(10, -10) * Math.Sin(beta) * Math.Cos(beta);
            double nf = Math.Pow(e2, 2) * Math.Pow(Math.Cos(Bf), 2);
            double Wf = Math.Sqrt(1 - Math.Pow(e, 2) * Math.Pow(Math.Sin(Bf), 2));
            double Mf = a * (1 - Math.Pow(e, 2)) / Math.Pow(Wf, 3);
            double Nf = a / Wf;
            double tf = Math.Tan(Bf);

            //反算B、l
            double B = Bf - tf * Math.Pow(this.y, 2) / (2 * Mf * Nf) + tf * (5 + 3 * Math.Pow(tf, 2) + nf - 9 * nf * Math.Pow(tf, 2)) * Math.Pow(this.y, 4) / (24 * Mf * Math.Pow(Nf, 3)) - tf * (61 + 90 * Math.Pow(tf, 2) + 45 * Math.Pow(tf, 4)) * Math.Pow(this.y, 6) / (720 * Mf * Math.Pow(Nf, 5));
            B = B / Math.PI * 180;

            double L = this.y / (Nf * Math.Cos(Bf)) - (1 + 2 * Math.Pow(tf, 2) + nf) * Math.Pow(this.y, 3) / (6 * Math.Pow(Nf, 3) * Math.Cos(Bf)) + (5 + 28 * Math.Pow(tf, 2) + 24 * Math.Pow(tf, 4) + 6 * nf + 8 * nf * Math.Pow(tf, 2)) * Math.Pow(this.y, 5) / (120 * Math.Pow(Nf, 5) * Math.Cos(Bf));
            L = L / Math.PI * 180;

            //计算中央经线
            GetCenter();

            // 本带内经度换算
            L += this.Center;

            BL ResultBL = new BL(GeoCalc.DEC2DMS(B), GeoCalc.DEC2DMS(L))
            {
                GEOEllipse = this.GEOEllipse
            };
            return ResultBL;
        }
    }
}
