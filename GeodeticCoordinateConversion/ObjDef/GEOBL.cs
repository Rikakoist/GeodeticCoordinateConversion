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
                try
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
                catch (Exception err)
                {
                    this.ZoneType = GEOZoneType.None;
                    throw new ArgumentOutOfRangeException(ErrMessage.GEOZone.ZoneTypeUnknown, err);
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
        /// 通过DMS对象、椭球类型和分带类型初始化度分秒经纬度。
        /// </summary>
        /// <param name="B">DMS类型的纬度对象。</param>
        /// <param name="L">DMS类型的经度对象。</param>
        /// <param name="EllipseType">椭球类型。</param>
        /// <param name="ZoneType">分带类型。</param>
        public GEOBL(DMS B, DMS L, Ellipse E, GEOZoneType ZoneType)
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.ZoneType = ZoneType;
                this.B = B ?? throw new ArgumentNullException(ErrMessage.GEOBL.GEOBLNull);
                this.L = L ?? throw new ArgumentNullException(ErrMessage.GEOBL.GEOBLNull);
                BindBLEvent();

                this.GEOEllipse = E ?? throw new ArgumentNullException(ErrMessage.GEOEllipse.EllipseNull);
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
                if (this.GEOEllipse is null)
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
                double tmpB = GeoCalc.DEC2ARC(CDEC.B);
                double tmpL = GeoCalc.DEC2ARC(CDEC.L);

                //计算中间参数
                double W = Math.Sqrt(1 - Math.Pow(e, 2) * Math.Pow((Math.Sin(tmpB)), 2));
                double M = a * Math.Pow(1 - e, 2) / Math.Pow(W, 3);
                double N = a / W;
                double n = Math.Pow(e2, 2) * Math.Pow((Math.Cos(tmpB)), 2);
                double p = 206265;

                //求子午线弧长
                double X = a0 * tmpB - Math.Sin(tmpB) * Math.Cos(tmpB) * ((a2 - a4 + a6) + (2 * a4 - 16 / 3 * a6) * Math.Pow(Math.Sin(tmpB), 2) + 16 / 3 * a6 * Math.Pow(Math.Sin(tmpB), 4));
                double t = Math.Tan(tmpB);

                //正算转换
                double tmpX = X + N / 2 * Math.Sin(tmpB) * Math.Cos(tmpB) * Math.Pow(l, 2) / Math.Pow(p, 2) + N / (24 * Math.Pow(p, 4)) * Math.Sin(tmpB) * (Math.Pow((Math.Cos(tmpB)), 3)) * (5 - Math.Pow(t, 2) + 9 * n + 4 * Math.Pow(n, 2)) * Math.Pow(l, 4) + N / (720 * Math.Pow(p, 6)) * Math.Sin(tmpB) * (Math.Pow((Math.Cos(tmpB)), 5)) * (61 - 58 * Math.Pow(t, 2) + Math.Pow(t, 4)) * Math.Pow(l, 6);
                double tmpY = N * Math.Cos(tmpB) * l / p + N / (6 * Math.Pow(p, 3)) * (Math.Pow(Math.Cos(tmpB), 3)) * (1 - Math.Pow(t, 2) + n) * Math.Pow(l, 3) + N / (120 * Math.Pow(p, 5)) * (Math.Pow(Math.Cos(tmpB), 5)) * (5 - 18 * Math.Pow(t, 2) + Math.Pow(t, 4) + 14 * n - 58 * Math.Pow(t, 2) * n) * Math.Pow(l, 5);

                GaussCoord GaussResult = new GaussCoord(CDEC.ZoneType, CDEC.Zone, tmpX, tmpY, this.GEOEllipse);

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
}
