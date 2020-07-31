using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 经纬度、高斯互转对象。
    /// </summary>
    public class CoordConvert
    {
        #region Fields
        /// <summary>
        /// 全局唯一ID。
        /// </summary>
        public readonly Guid guid;
        //public bool Selected = true;
        //public bool Error = true;
        //public bool Dirty = false;
        //public bool Calculated = false;
        /// <summary>
        /// 地理经纬度对象。
        /// </summary>
        public GEOBL BL;
        /// <summary>
        /// 高斯坐标对象。
        /// </summary>
        public GaussCoord Gauss;
        #endregion

        #region Properties
        /// <summary>
        /// 是否选中。
        /// </summary>
        [DisplayName("选中")]
        public bool Selected { get; set; } = true;
        /// <summary>
        /// 计算错误。
        /// </summary>
        [DisplayName("计算错误")]
        public bool Error { get; private set; } = false;
        /// <summary>
        /// 脏数据。
        /// </summary>
        [DisplayName("脏数据")]
        public bool Dirty { get; private set; } = false;
        /// <summary>
        /// 已计算。
        /// </summary>
        [DisplayName("已计算")]
        public bool Calculated { get; private set; } = false;
        /// <summary>
        /// 地理纬度。
        /// </summary>
        [DisplayName("地理B坐标")]
        public string B
        {
            get => BL.B.Value;
            set => BL.B.Value = value;
        }
        /// <summary>
        /// 地理经度。
        /// </summary>
        [DisplayName("地理L坐标")]
        public string L
        {
            get => BL.L.Value;
            set => BL.L.Value = value;
        }
        /// <summary>
        /// 椭球。
        /// </summary>
        [DisplayName("椭球")]
        public string EllipseType
        {
            get => ((int)BL.GEOEllipse.EllipseType).ToString();
            set
            {
                BL.GEOEllipse.EllipseType = (GEOEllipseType)(int.Parse(value));
                Gauss.GEOEllipse.EllipseType = (GEOEllipseType)(int.Parse(value));
            }
        }
        /// <summary>
        /// 高斯X坐标。
        /// </summary>
        [DisplayName("高斯X坐标")]
        public string X
        {
            get => Gauss.X.ToString();
            set => Gauss.X = double.Parse(value);
        }
        /// <summary>
        /// 高斯Y坐标。
        /// </summary>
        [DisplayName("高斯Y坐标")]
        public string Y
        {
            get => Gauss.Y.ToString();
            set => Gauss.Y = double.Parse(value);
        }
        /// <summary>
        /// 分带类型。
        /// </summary>
        [DisplayName("分带")]
        public string ZoneType
        {
            get => ((int)BL.ZoneType).ToString();
            set
            {
                BL.ZoneType = (GEOZoneType)int.Parse(value);
                Gauss.ZoneType = (GEOZoneType)int.Parse(value);
            }
        }
        /*
        [DisplayName("分带")]
        public GEOZoneType ZoneType
        {
            get => BL.ZoneType;
            set
            {
                BL.ZoneType = value;
                Gauss.ZoneType = value;
            }
        }
        */
        /// <summary>
        /// 高斯带号。
        /// </summary>
        [DisplayName("带号")]
        public int Zone
        {
            get => Gauss.Zone;
            set => Gauss.Zone = value;
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
                this.Dirty = bool.Parse(ele.GetAttribute(nameof(Dirty)));
                this.Error = bool.Parse(ele.GetAttribute(nameof(Error)));
                this.Selected = bool.Parse(ele.GetAttribute(nameof(Selected)));
                this.Calculated = bool.Parse(ele.GetAttribute(nameof(Calculated)));

                XmlNode BLNode = ele.SelectSingleNode(NodeInfo.BLNodePath);
                if (BLNode is null)
                {
                    this.BL = new GEOBL();
                }
                else
                {
                    this.BL = new GEOBL(BLNode);
                }
                BindBLEvents();

                XmlNode GaussNode = ele.SelectSingleNode(NodeInfo.GaussNodePath);
                if (GaussNode is null)
                {
                    this.Gauss = new GaussCoord();
                }
                else
                {
                    this.Gauss = new GaussCoord(GaussNode);
                }
                BindGaussEvents();
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
                this.Gauss.ValueChanged += new GaussCoord.GaussValueChangedEventHander(this.ChangeState);
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
                this.BL.ValueChanged += new GEOBL.GEOBLValueChangedEventHander(this.ChangeState);
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
        private void ChangeState(object sender, EventArgs e)
        {
            this.Dirty = true;
            this.Error = false;
            this.Calculated = false;
        }

        /// <summary>
        /// 高斯坐标转换到地理经纬度。
        /// </summary>
        public bool GaussReverse()
        {
            try
            {
                if (!(Gauss is null) && (!Calculated))
                {
                    BL = Gauss.GaussReverse();
                    BindBLEvents();
                    this.Error = false;
                    return true;
                }
                this.Error = true;
                return false;
            }
            catch (Exception err)
            {
                Trace.TraceError(err.ToString());
                this.Error = true;
                return false;
            }
            finally
            {
                this.Dirty = false;
                this.Calculated = true;
            }
        }

        /// <summary>
        /// 地理经纬度转换到高斯坐标。
        /// </summary>
        public bool GaussDirect()
        {
            try
            {
                if (!(BL is null) && (!Calculated))
                {
                    Gauss = BL.GaussDirect();
                    BindGaussEvents();
                    this.Error = false;
                    return true;
                }
                this.Error = true;
                return false;
            }
            catch (Exception err)
            {
                Trace.TraceError(err.ToString());
                this.Error = true;
                return false;
            }
            finally
            {
                this.Dirty = false;
                this.Calculated = true;
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
                ele.SetAttribute(nameof(Dirty), Dirty.ToString());
                ele.SetAttribute(nameof(Error), Error.ToString());
                ele.SetAttribute(nameof(Selected), Selected.ToString());
                ele.SetAttribute(nameof(Calculated), Calculated.ToString());

                if (BL != null)
                {
                    ele.AppendChild(this.BL.ToXmlElement(xmlDocument));
                }

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
