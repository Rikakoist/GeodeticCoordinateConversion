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
                return center;
            }
            set
            {
                if ((value < Restraints.LongitudeMin) || (value > Restraints.LongitudeMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.Data.LongitudeOutOfRange);
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
                            //throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeNotSet);
                        }
                    case GEOZoneType.Zone3:
                        {
                            if ((value < Restraints.Zone3Min) || (value > Restraints.Zone3Max))
                            {
                                throw new ArgumentOutOfRangeException(ErrMessage.Data.Zone3OutOfRange);
                            }
                            this.zone = value;
                            break;
                        }
                    case GEOZoneType.Zone6:
                        {
                            if ((value < Restraints.Zone6Min) || (value > Restraints.Zone6Max))
                            {
                                throw new ArgumentOutOfRangeException(ErrMessage.Data.Zone6OutOfRange);
                            }
                            this.zone = value;
                            break;
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
                        throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeNotSet);
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
                        throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeUnknown);
                    }
            }
            return true;
        }
    }

    class Tab1File
    {
        public BL Tab1FileBL;
        public GaussCoord Tab1FileGC;

        public Tab1File()
        {

        }

        public Tab1File(XmlNode xmlNode)
        {
            this.Tab1FileBL = new BL(xmlNode.SelectSingleNode(NodeInfo.BLNodePath));
            this.Tab1FileGC = new GaussCoord(xmlNode.SelectSingleNode(NodeInfo.GaussNode));
        }
    }

    class Tab2File
    {
        public GaussCoord Six;
        public GaussCoord Three;

        public Tab2File()
        {

        }

        public Tab2File(XmlNode xmlNode)
        {
            this.Six = new GaussCoord(xmlNode.SelectSingleNode(NodeInfo.Gauss6NodePath));
            this.Three = new GaussCoord(xmlNode.SelectSingleNode(NodeInfo.Gauss3NodePath));
        }
    }
}
