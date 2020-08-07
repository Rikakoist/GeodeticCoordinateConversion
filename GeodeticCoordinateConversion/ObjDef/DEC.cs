using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

/// <summary>
/// 中间变量。
/// </summary>
namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 十进制度类（计算中间变量）。
    /// </summary>
    public sealed class DEC
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
        /// 分带类型（私有）。
        /// </summary>
        private GEOZoneType zoneType;

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
                    throw new ArgumentOutOfRangeException(ErrMessage.Data.BiotitudeOutOfRange);
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
                    throw new ArgumentOutOfRangeException(ErrMessage.Data.LongitudeOutOfRange);
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
                switch (this.ZoneType)
                {
                    case GEOZoneType.None:
                        {
                            throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeNotSet);
                        }
                    case GEOZoneType.Zone3:
                        {
                            return (3.0 * this.Zone);
                        }
                    case GEOZoneType.Zone6:
                        {
                            return (6.0 * this.Zone - 3);
                        }
                    default:
                        {
                            throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeUnknown);
                        }
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
                switch (this.ZoneType)
                {
                    case GEOZoneType.None:
                        {
                            throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeNotSet);
                        }
                    case GEOZoneType.Zone3:
                        {
                            return (int)((this.L + 1.5) / 3.0);
                        }
                    case GEOZoneType.Zone6:
                        {
                            return (int)((this.L + 6.0) / 6.0);
                        }
                    default:
                        {
                            throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeUnknown);
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
    }
}
