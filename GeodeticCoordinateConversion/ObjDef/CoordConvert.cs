using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 经纬度、高斯互转对象。
    /// </summary>
    public class CoordConvert
    {
        #region Fields
        public readonly Guid guid;
        public bool BLCalculated = false;
        public GEOBL BL;
        public bool GaussCalculated = false;
        public GaussCoord Gauss;
        #endregion

        #region Properties
        /// <summary>
        /// 地理纬度。
        /// </summary>
        public string B
        {
            get => BL.B.Value;
            set => BL.B.Value = value;
        }
        /// <summary>
        /// 地理经度。
        /// </summary>
        public string L
        {
            get => BL.L.Value;
            set => BL.L.Value = value;
        }
        /// <summary>
        /// 高斯X坐标。
        /// </summary>
        public string X
        {
            get => Gauss.X.ToString();
            set => Gauss.X = double.Parse(value);
        }
        /// <summary>
        /// 高斯Y坐标。
        /// </summary>
        public string Y
        {
            get => Gauss.Y.ToString();
            set => Gauss.Y = double.Parse(value);
        }
        /// <summary>
        /// 高斯带号。
        /// </summary>
        public string Zone
        {
            get => Gauss.Zone.ToString();
            set => Gauss.Zone = int.Parse(value);
        }
        /// <summary>
        /// 分带类型。
        /// </summary>
        public GEOZoneType ZoneType
        {
            get => BL.ZoneType;
            set
            {
                BL.ZoneType = value;
                Gauss.ZoneType = value;
            }
        }
        /// <summary>
        /// 椭球。
        /// </summary>
        public GEOEllipseType EllipseType
        {
            get => BL.GEOEllipse.EllipseType;
            set
            {
                BL.GEOEllipse.EllipseType = value;
                Gauss.GEOEllipse.EllipseType = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 经纬度、高斯互转对象默认构造函数。
        /// </summary>
        public CoordConvert()
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.BL = new GEOBL();
                BindBLEvents();
                this.Gauss = new GaussCoord();
                BindGaussEvents();
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.CoordConvert.InitializeError, err);
            }
        }

        /// <summary>
        /// 使用地理经纬度对象和高斯坐标对象初始化经纬度、高斯互转对象。
        /// </summary>
        /// <param name="BL">地理经纬度对象。</param>
        /// <param name="Gauss">高斯坐标对象。</param>
        public CoordConvert(GEOBL BL, GaussCoord Gauss)
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.BL = BL ?? throw new ArgumentNullException(ErrMessage.GEOBL.GEOBLNull);
                BindBLEvents();
                this.Gauss = Gauss ?? throw new ArgumentNullException(ErrMessage.GaussCoord.GaussNull);
                BindGaussEvents();
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.CoordConvert.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过XML节点初始化经纬度、高斯互转对象。
        /// </summary>
        /// <param name="xmlNode">包含对象结构的XML节点。</param>
        public CoordConvert(XmlNode xmlNode)
        {
            try
            {
                XmlElement ele = (XmlElement)xmlNode;

                this.guid = Guid.Parse(ele.GetAttribute(nameof(guid)));
                this.BLCalculated = bool.Parse(ele.GetAttribute(nameof(BLCalculated)));
                XmlNode BLNode = ele.SelectSingleNode(NodeInfo.BLNodePath);
                if (BLNode == null)
                {
                    this.BL = new GEOBL();
                }
                else
                {
                    this.BL = new GEOBL(BLNode);
                }

                this.GaussCalculated = bool.Parse(ele.GetAttribute(nameof(GaussCalculated)));
                XmlNode GaussNode = ele.SelectSingleNode(NodeInfo.GaussNodePath);
                if (GaussNode == null)
                {
                    this.Gauss = new GaussCoord();
                }
                else
                {
                    this.Gauss = new GaussCoord(GaussNode);
                }
            }
            catch (Exception err)
            {
                throw new XmlException(ErrMessage.ZoneConvert.InitializeError, err);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 绑定高斯坐标对象事件。
        /// </summary>
        private void BindGaussEvents()
        {
            try
            {
                this.Gauss.XChanged += new GaussCoord.XChangedEventHander(this.MakeDirty);
                this.Gauss.YChanged += new GaussCoord.YChangedEventHander(this.MakeDirty);
                this.Gauss.CenterChanged += new GaussCoord.CenterChangedEventHander(this.MakeDirty);
                this.Gauss.EllipseChanged += new GaussCoord.EllipseChangedEventHander(this.MakeDirty);
                this.Gauss.ZoneChanged += new GaussCoord.ZoneChangedEventHander(this.MakeDirty);
                this.Gauss.ZoneTypeChanged += new GaussCoord.ZoneTypeChangedEventHander(this.MakeDirty);
            }
            catch (Exception err)
            {
                throw new EventBindException(ErrMessage.Generic.BindEventFailed, err);
            }
        }

        /// <summary>
        /// 绑定地理经纬度对象事件。
        /// </summary>
        private void BindBLEvents()
        {
            try
            {
                this.BL.BChanged += new GEOBL.BChangedEventHander(this.MakeDirty);
                this.BL.LChanged += new GEOBL.LChangedEventHander(this.MakeDirty);
                this.BL.EllipseChanged += new GEOBL.EllipseChangedEventHander(this.MakeDirty);
                this.BL.ZoneTypeChanged += new GEOBL.ZoneTypeChangedEventHander(this.MakeDirty);
            }
            catch (Exception err)
            {
                throw new EventBindException(ErrMessage.Generic.BindEventFailed, err);
            }
        }

        /// <summary>
        /// 改变计算状态。
        /// </summary>
        /// <param name="sender">触发者。</param>
        /// <param name="e">附加参数。</param>
        private void MakeDirty(object sender, EventArgs e)
        {
            if (sender == this.Gauss)
            {
                this.BLCalculated = false;
            }
            if (sender == this.BL)
            {
                this.GaussCalculated = false;
            }
        }

        /// <summary>
        /// 高斯坐标转换到地理经纬度。
        /// </summary>
        public void GaussToGEOBL()
        {
            try
            {
                if ((Gauss != null) && (!BLCalculated))
                {
                    BL = Gauss.GaussReverse();
                    BindBLEvents();
                }
            }
            catch (Exception err)
            {
                throw new CoordConvertException(ErrMessage.CoordConvert.GaussToGEOBLFailed, err);
            }
        }

        /// <summary>
        /// 地理经纬度转换到高斯坐标。
        /// </summary>
        public void GEOBLToGauss()
        {
            try
            {
                if ((BL != null) && (!GaussCalculated))
                {
                    Gauss = BL.GaussDirect();
                    BindGaussEvents();
                }
            }
            catch (Exception err)
            {
                throw new CoordConvertException(ErrMessage.CoordConvert.GEOBLToGaussFailed, err);
            }
        }

        /// <summary>
        /// 转换到XML元素。
        /// </summary>
        /// <param name="xmlDocument">指定的XML文档。</param>
        /// <param name="NodeName">新建的元素命名。</param>
        /// <returns>转换到的XML元素。</returns>
        public XmlElement ToXmlElement(XmlDocument xmlDocument, string NodeName = NodeInfo.CoordConvertNode)
        {
            try
            {
                XmlElement ele = xmlDocument.CreateElement(NodeName);

                ele.SetAttribute(nameof(guid), guid.ToString());
                ele.SetAttribute(nameof(BLCalculated), BLCalculated.ToString());
                if (BL != null)
                {
                    ele.AppendChild(this.BL.ToXmlElement(xmlDocument));
                }
                ele.SetAttribute(nameof(GaussCalculated), GaussCalculated.ToString());
                if (Gauss != null)
                {
                    ele.AppendChild(this.Gauss.ToXmlElement(xmlDocument));
                }
                return ele;
            }
            catch (Exception err)
            {
                throw new XmlException(ErrMessage.ZoneConvert.SaveToXmlFailed, err);
            }
        }
        #endregion

        #region Exceptions
        /// <summary>
        /// 坐标转换异常。
        /// </summary>
        [Serializable]
        public class CoordConvertException : Exception
        {
            public CoordConvertException() { }
            public CoordConvertException(string message) : base(message) { }
            public CoordConvertException(string message, Exception inner) : base(message, inner) { }
            protected CoordConvertException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
        #endregion
    }
}
