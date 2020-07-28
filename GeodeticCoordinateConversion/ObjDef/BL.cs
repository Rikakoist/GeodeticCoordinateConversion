using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 度分秒经纬度类。
    /// </summary>
    public sealed class GEOBL
    {
        #region Fields
        /// <summary>
        /// 全局唯一ID。
        /// </summary>
        public readonly Guid guid;
        /// <summary>
        /// 配置文件。
        /// </summary>
        private GEOSettings AppSettings = new GEOSettings();
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
        /// 椭球。
        /// </summary>
        public Ellipse GEOEllipse;
        #endregion

        #region Properties
        /// <summary>
        /// 分带类型。
        /// </summary>
        public GEOZoneType ZoneType
        {
            get => zoneType;
            set
            {
                if (value == zoneType)
                {
                    return;
                }
                else
                {
                    this.zoneType = value;
                    ZoneTypeChanged?.Invoke(this, new EventArgs());
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 空的度分秒经纬度构造函数。将会新建两个默认值的DMS对象。
        /// </summary>
        public GEOBL()
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.ZoneType = (GEOZoneType)AppSettings.DefaultZoneType;
                this.B = new DMS(); this.L = new DMS();
                BindBLEvent();

                this.GEOEllipse = new Ellipse();
                BindEllipseEvent();
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.GEOBL.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过字符串初始化度分秒经纬度。
        /// </summary>
        /// <param name="B">字符串表示的纬度。</param>
        /// <param name="L">字符串表示的经度。</param>
        public GEOBL(string B, string L)
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.ZoneType = (GEOZoneType)AppSettings.DefaultZoneType;
                this.B = new DMS(B);
                this.L = new DMS(L);
                BindBLEvent();

                this.GEOEllipse = new Ellipse();
                BindEllipseEvent();
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.GEOBL.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过DMS对象初始化度分秒经纬度。
        /// </summary>
        /// <param name="B">DMS类型的纬度对象。</param>
        /// <param name="L">DMS类型的经度对象。</param>
        public GEOBL(DMS B, DMS L)
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.ZoneType = (GEOZoneType)AppSettings.DefaultZoneType;
                this.B = B ?? throw new ArgumentNullException(ErrMessage.GEOBL.GEOBLNull);
                this.L = L ?? throw new ArgumentNullException(ErrMessage.GEOBL.GEOBLNull);
                BindBLEvent();

                this.GEOEllipse = new Ellipse();
                BindEllipseEvent();
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.GEOBL.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过XML节点初始化度分秒经纬度。
        /// </summary>
        /// <param name="xmlNode">包含对象结构的XML节点。</param>
        public GEOBL(XmlNode xmlNode)
        {
            try
            {
                XmlElement ele = (XmlElement)xmlNode;
                this.guid = Guid.Parse(ele.GetAttribute(nameof(guid)));
                this.ZoneType = (GEOZoneType)int.Parse(ele.GetAttribute(nameof(ZoneType)));
                this.B = new DMS(xmlNode.SelectSingleNode(NodeInfo.BNodePath));
                this.L = new DMS(xmlNode.SelectSingleNode(NodeInfo.LNodePath));
                BindBLEvent();

                this.GEOEllipse = new Ellipse(xmlNode.SelectSingleNode(NodeInfo.EllipseNodePath));
                BindEllipseEvent();
            }
            catch (Exception err)
            {
                throw new InitializeFromXmlException(ErrMessage.GEOBL.InitializeError, err);
            }
        }
        #endregion

        #region Events
        public delegate void BChangedEventHander(object sender, EventArgs e);
        public event BChangedEventHander BChanged;
        public delegate void LChangedEventHander(object sender, EventArgs e);
        public event LChangedEventHander LChanged;
        public delegate void EllipseChangedEventHander(object sender, EventArgs e);
        public event EllipseChangedEventHander EllipseChanged;
        public delegate void ZoneTypeChangedEventHander(object sender, EventArgs e);
        public event ZoneTypeChangedEventHander ZoneTypeChanged;
        #endregion

        #region Methods

        /// <summary>
        /// 绑定椭球事件。
        /// </summary>
        private void BindEllipseEvent()
        {
            try
            {
                this.GEOEllipse.EllipseChanged += new Ellipse.EllipseChangedEventHander(this.EllipseChange);
            }
            catch (Exception err)
            {
                throw new EventBindException(ErrMessage.Generic.BindEventFailed, err);
            }
        }

        /// <summary>
        /// 触发椭球改变事件。
        /// </summary>
        /// <param name="sender">触发者。</param>
        /// <param name="e">附加参数。</param>
        private void EllipseChange(object sender, EventArgs e)
        {
            this.EllipseChanged?.Invoke(this, e);
        }

        /// <summary>
        /// 绑定地理经纬度事件。
        /// </summary>
        private void BindBLEvent()
        {
            try
            {
                this.B.DChanged += new DMS.DChangedEventHander(this.BLChange);
                this.B.MChanged += new DMS.MChangedEventHander(this.BLChange);
                this.B.SChanged += new DMS.SChangedEventHander(this.BLChange);

                this.L.DChanged += new DMS.DChangedEventHander(this.BLChange);
                this.L.MChanged += new DMS.MChangedEventHander(this.BLChange);
                this.L.SChanged += new DMS.SChangedEventHander(this.BLChange);
            }
            catch (Exception err)
            {
                throw new EventBindException(ErrMessage.Generic.BindEventFailed, err);
            }
        }

        /// <summary>
        /// 触发地理经纬度改变事件。
        /// </summary>
        /// <param name="sender">触发者。</param>
        /// <param name="e">附加参数。</param>
        private void BLChange(object sender, EventArgs e)
        {
            if (sender == this.B)
            {
                this.BChanged?.Invoke(this, e);
            }
            if (sender == this.L)
            {
                this.LChanged?.Invoke(this, e);
            }
        }

        /// <summary>
        /// 高斯正算（度分秒到高斯投影坐标）。
        /// </summary>
        /// <param name="CustomizeMode">强制自定义转换模式。</param>
        /// <returns>高斯正算结果。</returns>
        public GaussCoord GaussDirect(GEOZoneType CustomizeMode = GEOZoneType.None)
        {
            try
            {
                if (this.GEOEllipse == null)
                    throw new ArgumentNullException(ErrMessage.GEOEllipse.EllipseNull);
                if (this.GEOEllipse.EllipseType == GEOEllipseType.noEllipse)
                    throw new ArgumentOutOfRangeException(ErrMessage.GEOEllipse.EllipseNotSet);
                if (this.ZoneType == GEOZoneType.None)
                    throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeNotSet);

                //转换为十进制度（可使用自定义模式）
                DEC CDEC = new DEC(GeoCalc.DMS2DEC(this.B), GeoCalc.DMS2DEC(this.L),
                    (CustomizeMode != GEOZoneType.None) ? CustomizeMode : this.ZoneType);

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
                GaussCoord GaussResult = new GaussCoord(this.GEOEllipse)
                {
                    X = X + N / 2 * Math.Sin(CDEC.B) * Math.Cos(CDEC.B) * Math.Pow(l, 2) / Math.Pow(p, 2) + N / (24 * Math.Pow(p, 4)) * Math.Sin(CDEC.B) * (Math.Pow((Math.Cos(CDEC.B)), 3)) * (5 - Math.Pow(t, 2) + 9 * n + 4 * Math.Pow(n, 2)) * Math.Pow(l, 4) + N / (720 * Math.Pow(p, 6)) * Math.Sin(CDEC.B) * (Math.Pow((Math.Cos(CDEC.B)), 5)) * (61 - 58 * Math.Pow(t, 2) + Math.Pow(t, 4)) * Math.Pow(l, 6),
                    Y = N * Math.Cos(CDEC.B) * l / p + N / (6 * Math.Pow(p, 3)) * (Math.Pow(Math.Cos(CDEC.B), 3)) * (1 - Math.Pow(t, 2) + n) * Math.Pow(l, 3) + N / (120 * Math.Pow(p, 5)) * (Math.Pow(Math.Cos(CDEC.B), 5)) * (5 - 18 * Math.Pow(t, 2) + Math.Pow(t, 4) + 14 * n - 58 * Math.Pow(t, 2) * n) * Math.Pow(l, 5),
                    ZoneType = CDEC.ZoneType,
                    Zone = CDEC.Zone,
                };

                return GaussResult;
            }
            catch (Exception err)
            {
                throw new GaussDirectException(ErrMessage.GEOBL.GaussDirectFailed, err);
            }
        }

        /// <summary>
        /// 转换到XML元素。
        /// </summary>
        /// <param name="xmlDocument">指定的XML文档。</param>
        /// <param name="NodeName">新建的元素命名，默认为Geo。</param>
        /// <returns>转换到的XML元素。</returns>
        public XmlElement ToXmlElement(XmlDocument xmlDocument, string NodeName = NodeInfo.BLNode)
        {
            try
            {
                XmlElement ele = xmlDocument.CreateElement(NodeName);

                ele.SetAttribute(nameof(guid), this.guid.ToString());
                ele.SetAttribute(nameof(ZoneType), ((int)this.ZoneType).ToString());

                ele.AppendChild(this.GEOEllipse.ToXmlElement(xmlDocument));
                ele.AppendChild(this.B.ToXmlElement(xmlDocument, NodeInfo.BNode));
                ele.AppendChild(this.L.ToXmlElement(xmlDocument, NodeInfo.LNode));

                return ele;
            }
            catch (Exception err)
            {
                throw new XmlException(ErrMessage.GEOBL.SaveToXmlFailed, err);
            }
        }
        #endregion

        #region Exceptions
        /// <summary>
        /// 高斯正算异常。
        /// </summary>
        [Serializable]
        public class GaussDirectException : Exception
        {
            public GaussDirectException() { }
            public GaussDirectException(string message) : base(message) { }
            public GaussDirectException(string message, Exception inner) : base(message, inner) { }
            protected GaussDirectException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
        #endregion
    }

    /// <summary>
    /// 度分秒类。
    /// </summary>
    public sealed class DMS
    {
        #region Fields
        /// <summary>
        /// 全局唯一ID。
        /// </summary>
        public readonly Guid guid;
        /// <summary>
        /// 度（私有）。
        /// </summary>
        private double d;
        /// <summary>
        /// 分（私有）。
        /// </summary>
        private double m;
        /// <summary>
        /// 秒（私有）。
        /// </summary>
        private double s;
        #endregion

        #region Properties
        /// <summary>
        /// 度。
        /// </summary>
        public double D
        {
            get => d;
            set
            {
                if ((value < Restraints.DegreeMin) || (value > Restraints.DegreeMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.Data.DegreeOutOfRange);
                }
                else
                {
                    this.d = value;
                    this.DChanged?.Invoke(this, new EventArgs());
                }
            }
        }
        /// <summary>
        /// 分。
        /// </summary>
        public double M
        {
            get => m;
            set
            {
                if ((value < Restraints.MinuteMin) || (value > Restraints.MinuteMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.Data.MinuteOutOfRange);
                }
                else
                {
                    this.m = value;
                    this.MChanged?.Invoke(this, new EventArgs());
                }
            }
        }
        /// <summary>
        /// 秒。
        /// </summary>
        public double S
        {
            get => s;
            set
            {
                if ((value < Restraints.SecondMin) || (value > Restraints.SecondMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.Data.SecondOutOfRange);
                }
                else
                {
                    this.s = value;
                    this.SChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// 度分秒字符串表示形式。
        /// </summary>
        public string Value
        {
            get => this.ToString();
            set => this.FromString(value);
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 空的度分秒对象构造函数。度、分、秒将设为默认值0。
        /// </summary>
        public DMS()
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.D = 0; this.M = 0; this.S = 0;
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.DMS.InitializeError, err);
            }
        }

        /// <summary>
        /// 使用字符串初始化度分秒对象。
        /// </summary>
        /// <param name="Str"></param>
        public DMS(string Str)
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                FromString(Str);
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.DMS.InitializeError, err);
            }
        }

        /// <summary>
        /// 使用度分秒初始化度分秒对象。
        /// </summary>
        /// <param name="D">度。</param>
        /// <param name="M">分。</param>
        /// <param name="S">秒。</param>
        public DMS(double D, double M, double S)
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.D = D; this.M = M; this.S = S;
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.DMS.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过XML节点初始化度分秒对象。
        /// </summary>
        /// <param name="xmlNode">包含对象结构的XML节点。</param>
        public DMS(XmlNode xmlNode)
        {
            try
            {
                XmlElement ele = (XmlElement)xmlNode;
                this.guid = Guid.Parse(ele.GetAttribute(nameof(guid)));
                this.D = double.Parse(ele.GetAttribute(nameof(D)));
                this.M = double.Parse(ele.GetAttribute(nameof(M)));
                this.S = double.Parse(ele.GetAttribute(nameof(S)));
            }
            catch (Exception err)
            {
                throw new InitializeFromXmlException(ErrMessage.DMS.InitializeError, err);
            }
        }
        #endregion

        #region Events
        public delegate void DChangedEventHander(object sender, EventArgs e);
        public event DChangedEventHander DChanged;
        public delegate void MChangedEventHander(object sender, EventArgs e);
        public event MChangedEventHander MChanged;
        public delegate void SChangedEventHander(object sender, EventArgs e);
        public event SChangedEventHander SChanged;
        #endregion

        #region Methods
        /// <summary>
        /// 度分秒对象转换到XML元素。
        /// </summary>
        /// <param name="xmlDocument">指定的XML文档。</param>
        /// <param name="NodeName">新建的元素命名。</param>
        /// <returns>转换到的XML元素。</returns>
        public XmlElement ToXmlElement(XmlDocument xmlDocument, string NodeName)
        {
            try
            {
                XmlElement ele = xmlDocument.CreateElement(NodeName);

                ele.SetAttribute(nameof(guid), this.guid.ToString());
                ele.SetAttribute(nameof(D), this.D.ToString());
                ele.SetAttribute(nameof(M), this.M.ToString());
                ele.SetAttribute(nameof(S), this.S.ToString());

                return ele;
            }
            catch (Exception err)
            {
                throw new XmlException(ErrMessage.DMS.SaveToXmlFailed, err);
            }
        }

        /// <summary>
        /// 使用字符串设置度分秒的值。
        /// </summary>
        /// <param name="Str">输入字符串。</param>
        public void FromString(string Str)
        {
            try
            {
                if ((Str.IndexOf('.') == 0) || (Str.IndexOf('.') == Str.Length - 1) || ((Str.Split('.')).Length > 2))
                {
                    throw new FormatException(ErrMessage.Data.WrongDigitPosition);
                }
                if (Str.IndexOf('.') > 0)
                {
                    string[] SplitStr = Str.Split('.');
                    //小数点后补0至四位
                    while (SplitStr[1].Length < 4)
                    {
                        SplitStr[1] += "0";
                    }

                    //从字符串拆分度分秒
                    D = Convert.ToInt32(SplitStr[0]);
                    M = Convert.ToInt32(SplitStr[1].Substring(0, 2));
                    double tmpS = Convert.ToDouble(SplitStr[1].Substring(2));
                    //确认小数点位置
                    while (tmpS > 60.0)
                    {
                        tmpS /= 10;
                    }
                    S = tmpS;
                }
                else
                {
                    D = Convert.ToInt32(Str);
                    M = 0;
                    S = 0;
                }
            }
            catch (Exception err)
            {
                throw new FormatException(ErrMessage.DMS.ConvertFromStringFailed, err);
            }
        }

        /// <summary>
        /// 度分秒对象转换到字符串。
        /// </summary>
        /// <returns>转换到的字符串。</returns>
        public override string ToString()
        {
            try
            {
                double tmpD = D; double tmpM = M; double tmpS = S;
                //将度的小数点部分*60加到分上。
                if (Math.Abs(tmpD - (int)tmpD) > 1e-7)
                {
                    tmpM += (tmpD - (int)tmpD) * 60;
                }
                tmpD = (int)tmpD;

                //将分的小数点部分*60加到秒上。
                if (Math.Abs(tmpM - (int)tmpM) > 1e-7)
                {
                    tmpS += (tmpM - (int)tmpM) * 60;
                }
                tmpM = (int)tmpM;

                //去除秒的小数点，以便转换为字符串。
                while (Math.Abs(tmpS - (int)tmpS) > 1e-7)
                {
                    tmpS *= 10;
                }

                //秒为0。
                if (Math.Abs(tmpS) < 1e-7)
                {
                    //分为0。
                    if (Math.Abs(tmpM) < 1e-7)
                    {
                        //度为0。
                        if (Math.Abs(tmpD) < 1e-7)
                        {
                            return "0";
                        }
                        //度不为0。
                        else
                        {
                            return (tmpD.ToString() + ".0000");
                        }
                    }
                    //分不为0。
                    else
                    {
                        return (tmpD.ToString() + "." + tmpM.ToString("00") + "00");
                    }
                }
                //秒不为0。
                else
                {
                    return (tmpD.ToString() + "." + tmpM.ToString("00") + tmpS.ToString());
                }
            }
            catch (Exception err)
            {
                throw new FormatException(ErrMessage.DMS.ConvertToStringFailed, err);
            }
        }
        #endregion
    }
}
