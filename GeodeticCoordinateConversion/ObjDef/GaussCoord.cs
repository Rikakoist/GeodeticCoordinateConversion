using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 高斯坐标类。
    /// </summary>
    public sealed class GaussCoord
    {
        /// <summary>
        /// 全局唯一ID。
        /// </summary>
        public readonly Guid guid;
        /// <summary>
        /// 带内x坐标（私有）。
        /// </summary>
        private double x;
        /// <summary>
        /// 带内y坐标（私有）。
        /// </summary>
        private double y;
        /// <summary>
        /// 分带类型（私有）。
        /// </summary>
        private GEOZoneType zoneType;
        /// <summary>
        /// 带号（私有）。
        /// </summary>
        private int zone;
        /// <summary>
        /// 中央经线（私有）。
        /// </summary>
        private double center;

        /// <summary>
        /// 带内x坐标。
        /// </summary>
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                this.x = value;
                XChanged?.Invoke(this, null);
            }
        }
        /// <summary>
        /// 带内y坐标。
        /// </summary>
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                this.y = value;
                YChanged?.Invoke(this, null);
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
                    ZoneTypeChanged?.Invoke(this, null);
                }
            }
        }
        /// <summary>
        /// 带号，设置后会自动计算中央经线。
        /// </summary>
        public int Zone
        {
            get
            {
                return zone;
            }
            set
            {
                try
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
                                GetCenter();
                                break;
                            }
                        case GEOZoneType.Zone6:
                            {
                                if ((value < Restraints.Zone6Min) || (value > Restraints.Zone6Max))
                                {
                                    throw new ArgumentOutOfRangeException(ErrMessage.Data.Zone6OutOfRange);
                                }
                                this.zone = value;
                                GetCenter();
                                break;
                            }
                        default:
                            {
                                throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeUnknown);
                            }
                    }
                    ZoneChanged?.Invoke(this, null);
                }
                catch (Exception err)
                {
                    throw new SetZoneException(ErrMessage.GaussCoord.SetZoneFailed, err);
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
                try
                {
                    if ((value < Restraints.LongitudeMin) || (value > Restraints.LongitudeMax))
                    {
                        throw new ArgumentOutOfRangeException(ErrMessage.Data.LongitudeOutOfRange);
                    }
                    else
                    {
                        this.center = value;
                        CenterChanged?.Invoke(this, null);
                    }
                }
                catch (Exception err)
                {
                    throw new CenterException(ErrMessage.GaussCoord.SetCenterFailed, err);
                }
            }
        }
        /// <summary>
        /// 椭球。
        /// </summary>
        public Ellipse GEOEllipse;
        /// <summary>
        /// 脏数据。
        /// </summary>
        public bool IsDirty = true;

        /// <summary>
        /// 高斯坐标默认构造函数。
        /// </summary>
        public GaussCoord()
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.ZoneType = GEOZoneType.None;
                this.GEOEllipse = new Ellipse();
                this.GEOEllipse.EllipseChanged += new Ellipse.EllipseChangedEventHander(this.EllipsChange);
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.GaussCoord.InitializeError, err);
            }
        }

        /// <summary>
        /// 使用分带类型、带号、X、Y坐标和椭球（可选）初始化高斯坐标。
        /// </summary>
        /// <param name="ZoneType">分带类型。</param>
        /// <param name="Zone">带号。</param>
        /// <param name="X">带内X坐标。</param>
        /// <param name="Y">带内Y坐标。</param>
        /// <param name="EllipseType">椭球类型（可选，默认为无椭球）。</param>
        public GaussCoord(GEOZoneType ZoneType, int Zone, double X, double Y, GEOEllipseType EllipseType = GEOEllipseType.noEllipse)
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.X = X; this.Y = Y;
                this.ZoneType = ZoneType;
                this.Zone = Zone;
                this.GEOEllipse = new Ellipse(EllipseType);
                this.GEOEllipse.EllipseChanged += new Ellipse.EllipseChangedEventHander(this.EllipsChange);
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.GaussCoord.InitializeError, err);
            }
        }

        /// <summary>
        /// 使用椭球类型初始化高斯坐标。
        /// </summary>
        /// <param name="EllipseType"></param>
        public GaussCoord(GEOEllipseType EllipseType)
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.ZoneType = GEOZoneType.None;
                this.GEOEllipse = new Ellipse(EllipseType);
                this.GEOEllipse.EllipseChanged += new Ellipse.EllipseChangedEventHander(this.EllipsChange);
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.GaussCoord.InitializeError, err);
            }
        }

        /// <summary>
        /// 使用椭球初始化高斯坐标。
        /// </summary>
        /// <param name="E">椭球对象。</param>
        public GaussCoord(Ellipse E)
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.ZoneType = GEOZoneType.None;
                this.GEOEllipse = E;
                this.GEOEllipse.EllipseChanged += new Ellipse.EllipseChangedEventHander(this.EllipsChange);
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.GaussCoord.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过XML节点初始化高斯坐标。
        /// </summary>
        /// <param name="xmlNode">包含对象结构的XML节点。</param>
        public GaussCoord(XmlNode xmlNode)
        {
            try
            {
                XmlElement ele = (XmlElement)xmlNode;
                this.guid = Guid.Parse(ele.GetAttribute(nameof(guid)));
                this.X = double.Parse(ele.GetAttribute(nameof(X)));
                this.Y = double.Parse(ele.GetAttribute(nameof(Y)));
                this.ZoneType = (GEOZoneType)int.Parse(ele.GetAttribute(nameof(ZoneType)));
                this.Zone = int.Parse(ele.GetAttribute(nameof(Zone)));
                this.Center = double.Parse(ele.GetAttribute(nameof(Center)));
                this.GEOEllipse = new Ellipse(xmlNode.SelectSingleNode(NodeInfo.EllipseNodePath));
                this.GEOEllipse.EllipseChanged += new Ellipse.EllipseChangedEventHander(this.EllipsChange);
            }
            catch (Exception err)
            {
                throw new InitializeFromXmlException(ErrMessage.GaussCoord.InitializeError, err);
            }
        }

        public delegate void XChangedEventHander(object sender, EventArgs e);
        public event XChangedEventHander XChanged;
        public delegate void YChangedEventHander(object sender, EventArgs e);
        public event YChangedEventHander YChanged;
        public delegate void ZoneTypeChangedEventHander(object sender, EventArgs e);
        public event ZoneTypeChangedEventHander ZoneTypeChanged;
        public delegate void ZoneChangedEventHander(object sender, EventArgs e);
        public event ZoneChangedEventHander ZoneChanged;
        public delegate void CenterChangedEventHander(object sender, EventArgs e);
        public event CenterChangedEventHander CenterChanged;
        public delegate void EllipseChangedEventHander(object sender, EventArgs e);
        public event EllipseChangedEventHander EllipseChanged;

        private void EllipsChange(object sender, EventArgs e)
        {
            EllipseChanged?.Invoke(this, null);
        }

        /// <summary>
        /// 计算中央经线。
        /// </summary>
        /// <returns>计算是否成功。</returns>
        public bool GetCenter()
        {
            try
            {
                switch (this.ZoneType)
                {
                    case GEOZoneType.None:
                        {
                            throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeNotSet);
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
                            throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeUnknown);
                        }
                }
                return true;
            }
            catch (Exception err)
            {
                throw new CenterException(ErrMessage.GaussCoord.GetCenterFailed, err);
            }
        }

        /// <summary>
        /// 高斯反算（高斯投影坐标到度分秒）。
        /// </summary>
        /// <returns>高斯反算结果。</returns>
        public BL GaussReverse()
        {
            try
            {
                if (this.GEOEllipse == null)
                    throw new ArgumentNullException(ErrMessage.GEOEllipse.EllipseNull);
                if (this.GEOEllipse.EllipseType == GEOEllipseType.noEllipse)
                    throw new ArgumentOutOfRangeException(ErrMessage.GEOEllipse.EllipseNotSet);
                if (this.ZoneType == GEOZoneType.None)
                    throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeNotSet);

                double a = this.GEOEllipse.a; double e = this.GEOEllipse.e; double e2 = this.GEOEllipse.e2;

                double beta = this.X / 6367588.4969;
                double Bf = beta + (50221746 + (293622 + (2350 + 22 * Math.Pow(Math.Cos(beta), 2)) * Math.Pow(Math.Cos(beta), 2)) * Math.Pow(Math.Cos(beta), 2)) * Math.Pow(10, -10) * Math.Sin(beta) * Math.Cos(beta);
                double nf = Math.Pow(e2, 2) * Math.Pow(Math.Cos(Bf), 2);
                double Wf = Math.Sqrt(1 - Math.Pow(e, 2) * Math.Pow(Math.Sin(Bf), 2));
                double Mf = a * (1 - Math.Pow(e, 2)) / Math.Pow(Wf, 3);
                double Nf = a / Wf;
                double tf = Math.Tan(Bf);

                //反算B、l
                double B = Bf - tf * Math.Pow(this.Y, 2) / (2 * Mf * Nf) + tf * (5 + 3 * Math.Pow(tf, 2) + nf - 9 * nf * Math.Pow(tf, 2)) * Math.Pow(this.Y, 4) / (24 * Mf * Math.Pow(Nf, 3)) - tf * (61 + 90 * Math.Pow(tf, 2) + 45 * Math.Pow(tf, 4)) * Math.Pow(this.Y, 6) / (720 * Mf * Math.Pow(Nf, 5));
                B = B / Math.PI * 180;

                double L = this.Y / (Nf * Math.Cos(Bf)) - (1 + 2 * Math.Pow(tf, 2) + nf) * Math.Pow(this.Y, 3) / (6 * Math.Pow(Nf, 3) * Math.Cos(Bf)) + (5 + 28 * Math.Pow(tf, 2) + 24 * Math.Pow(tf, 4) + 6 * nf + 8 * nf * Math.Pow(tf, 2)) * Math.Pow(this.Y, 5) / (120 * Math.Pow(Nf, 5) * Math.Cos(Bf));
                L = L / Math.PI * 180;

                ////计算中央经线
                //GetCenter();

                // 本带内经度换算
                L += this.Center;

                BL ResultBL = new BL(GeoCalc.DEC2DMS(B), GeoCalc.DEC2DMS(L))
                {
                    GEOEllipse = this.GEOEllipse
                };
                return ResultBL;
            }
            catch (Exception err)
            {
                throw new GaussReverseException(ErrMessage.GaussCoord.GaussReverseFailed, err);
            }
        }

        /// <summary>
        /// 转换到XML元素。
        /// </summary>
        /// <param name="xmlDocument">指定的XML文档。</param>
        /// <param name="NodeName">新建的元素命名。</param>
        /// <returns>转换到的XML元素。</returns>
        internal XmlElement ToXmlElement(XmlDocument xmlDocument, string NodeName = NodeInfo.GaussNode)
        {
            try
            {
                XmlElement ele = xmlDocument.CreateElement(NodeName);

                ele.SetAttribute(nameof(guid), this.guid.ToString());
                ele.SetAttribute(nameof(X), this.X.ToString());
                ele.SetAttribute(nameof(Y), this.Y.ToString());
                ele.SetAttribute(nameof(ZoneType), ((int)this.ZoneType).ToString());
                ele.SetAttribute(nameof(Zone), this.Zone.ToString());
                ele.SetAttribute(nameof(Center), this.Center.ToString());

                ele.AppendChild(this.GEOEllipse.ToXmlElement(xmlDocument));

                return ele;
            }
            catch (Exception err)
            {
                throw new XmlException(ErrMessage.GaussCoord.SaveToXmlFailed, err);
            }
        }

        /// <summary>
        /// 设置带号异常。
        /// </summary>
        [Serializable]
        public class SetZoneException : Exception
        {
            public SetZoneException() { }
            public SetZoneException(string message) : base(message) { }
            public SetZoneException(string message, Exception inner) : base(message, inner) { }
            protected SetZoneException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        /// <summary>
        /// 中央经线异常。
        /// </summary>
        [Serializable]
        public class CenterException : Exception
        {
            public CenterException() { }
            public CenterException(string message) : base(message) { }
            public CenterException(string message, Exception inner) : base(message, inner) { }
            protected CenterException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        /// <summary>
        /// 高斯反算异常。
        /// </summary>
        [Serializable]
        public class GaussReverseException : Exception
        {
            public GaussReverseException() { }
            public GaussReverseException(string message) : base(message) { }
            public GaussReverseException(string message, Exception inner) : base(message, inner) { }
            protected GaussReverseException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
