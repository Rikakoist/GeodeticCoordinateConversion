using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 6度带、3度带互转类。
    /// </summary>
    public class ZoneConvert
    {
        #region Fields
        public bool Gauss6Calculated = false;
        public GaussCoord Gauss6;
        public bool Gauss3Calculated = false;
        public GaussCoord Gauss3;
        #endregion

        #region Constructor
        /// <summary>
        /// 默认构造函数，会使用空的构造函数新建两个高斯坐标对象。
        /// </summary>
        public ZoneConvert()
        {
            try
            {
                this.Gauss3 = new GaussCoord();
                this.Gauss6 = new GaussCoord();
                BindGauss3Events();
                BindGauss6Events();
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.ZoneConvert.InitializeError, err);
            }
        }

        /// <summary>
        /// 使用一个高斯坐标初始化6度带、3度带互转类。
        /// </summary>
        /// <param name="newGauss">高斯坐标，需要设置带类型。</param>
        public ZoneConvert(GaussCoord newGauss)
        {
            try
            {
                if (newGauss == null)
                    throw new ArgumentNullException(ErrMessage.GaussCoord.GaussNull);
                switch (newGauss.ZoneType)
                {
                    case GEOZoneType.None:
                        {
                            throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeNotSet);
                        }
                    case GEOZoneType.Zone3:
                        {
                            this.Gauss3 = newGauss;
                            this.Gauss3Calculated = true;
                            BindGauss3Events();
                            break;
                        }
                    case GEOZoneType.Zone6:
                        {
                            this.Gauss6 = newGauss;
                            this.Gauss6Calculated = true;
                            BindGauss6Events();
                            break;
                        }
                }
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.ZoneConvert.InitializeError, err);
            }
        }

        /// <summary>
        /// 使用两个高斯坐标初始化6度带、3度带互转类。
        /// </summary>
        /// <param name="gauss1">高斯坐标，需要设置带类型（分带不可与另一个相同）。</param>
        /// <param name="gauss2">高斯坐标，需要设置带类型（分带不可与另一个相同）。</param>
        public ZoneConvert(GaussCoord gauss1, GaussCoord gauss2)
        {
            try
            {
                if (gauss1 == null || gauss2 == null)
                    throw new ArgumentNullException(ErrMessage.GaussCoord.GaussNull);
                if (gauss1.ZoneType == GEOZoneType.None || gauss2.ZoneType == GEOZoneType.None)
                    throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeNotSet);
                if (gauss1.ZoneType == gauss2.ZoneType)
                    throw new ArgumentException(ErrMessage.GaussCoord.SameZoneType);

                switch (gauss1.ZoneType)
                {
                    case GEOZoneType.Zone3:
                        {
                            this.Gauss3 = gauss1;
                            this.Gauss3Calculated = true;
                            this.Gauss6 = gauss2;
                            this.Gauss6Calculated = true;
                            break;
                        }
                    case GEOZoneType.Zone6:
                        {
                            this.Gauss6 = gauss1;
                            this.Gauss6Calculated = true;
                            this.Gauss3 = gauss2;
                            this.Gauss3Calculated = true;
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeUnknown);
                        }
                }
                BindGauss3Events();
                BindGauss6Events();
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.ZoneConvert.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过XML节点初始化6度带、3度带互转对象。
        /// </summary>
        /// <param name="xmlNode">包含对象结构的XML节点。</param>
        public ZoneConvert(XmlNode xmlNode)
        {
            try
            {
                XmlElement ele = (XmlElement)xmlNode;

                this.Gauss3Calculated = bool.Parse(ele.GetAttribute(nameof(Gauss3Calculated)));
                XmlNode Gauss3Node = ele.SelectSingleNode(NodeInfo.Gauss3NodePath);
                if (Gauss3Node == null)
                {
                    this.Gauss3 = new GaussCoord();
                }
                else
                {
                    this.Gauss3 = new GaussCoord(Gauss3Node);
                }

                this.Gauss6Calculated = bool.Parse(ele.GetAttribute(nameof(Gauss6Calculated)));
                XmlNode Gauss6Node = ele.SelectSingleNode(NodeInfo.Gauss6NodePath);
                if (Gauss6Node == null)
                {
                    this.Gauss6 = new GaussCoord();
                }
                else
                {
                    this.Gauss6 = new GaussCoord(Gauss6Node);
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
        /// 绑定3度带对象事件。
        /// </summary>
        private void BindGauss3Events()
        {
            this.Gauss3.XChanged += new GaussCoord.XChangedEventHander(this.GaussDirty);
            this.Gauss3.YChanged += new GaussCoord.YChangedEventHander(this.GaussDirty);
            this.Gauss3.EllipseChanged += new GaussCoord.EllipseChangedEventHander(this.GaussDirty);
        }

        /// <summary>
        /// 绑定6度带对象事件。
        /// </summary>
        private void BindGauss6Events()
        {
            this.Gauss6.XChanged += new GaussCoord.XChangedEventHander(this.GaussDirty);
            this.Gauss6.YChanged += new GaussCoord.YChangedEventHander(this.GaussDirty);
            this.Gauss6.EllipseChanged += new GaussCoord.EllipseChangedEventHander(this.GaussDirty);
        }

        /// <summary>
        /// 改变计算状态。
        /// </summary>
        /// <param name="sender">触发者。</param>
        /// <param name="e">附加参数。</param>
        private void GaussDirty(object sender, EventArgs e)
        {
            if (sender == this.Gauss3)
            {
                this.Gauss6Calculated = false;
            }
            if (sender == this.Gauss6)
            {
                this.Gauss3Calculated = false;
            }
        }

        /// <summary>
        /// 6度带转3度带。
        /// </summary>
        public void Convert6To3()
        {
            try
            {
                if ((Gauss6 != null) && (!Gauss3Calculated))
                {
                    Gauss3 = Gauss6.GaussReverse() //六度带反算
                          .GaussDirect(GEOZoneType.Zone3);   //三度带正算
                    Gauss3Calculated = true;
                    BindGauss3Events();
                }
            }
            catch (Exception err)
            {
                throw new ZoneConvertException(ErrMessage.ZoneConvert.Convert6To3Failed, err);
            }
        }

        /// <summary>
        /// 3度带转6度带。
        /// </summary>
        public void Convert3To6()
        {
            try
            {
                if ((Gauss3 != null) && (!Gauss6Calculated))
                {
                    Gauss6 = Gauss3.GaussReverse()   //三度带反算
                          .GaussDirect(GEOZoneType.Zone6);   //六度带正算
                    Gauss6Calculated = true;
                    BindGauss6Events();
                }
            }
            catch (Exception err)
            {
                throw new ZoneConvertException(ErrMessage.ZoneConvert.Convert3To6Failed, err);
            }
        }

        /// <summary>
        /// 自动转换。
        /// </summary>
        public void AutoConvert()
        {
            throw new NotImplementedException(ErrMessage.Generic.FunctionNotImplemented);
        }

        /// <summary>
        /// 转换到XML元素。
        /// </summary>
        /// <param name="xmlDocument">指定的XML文档。</param>
        /// <param name="NodeName">新建的元素命名。</param>
        /// <returns>转换到的XML元素。</returns>
        public XmlElement ToXmlElement(XmlDocument xmlDocument, string NodeName = NodeInfo.ZoneConvertNode)
        {
            try
            {
                XmlElement ele = xmlDocument.CreateElement(NodeName);

                ele.SetAttribute(nameof(Gauss3Calculated), Gauss3Calculated.ToString());
                if (Gauss3 != null)
                {
                    ele.AppendChild(this.Gauss3.ToXmlElement(xmlDocument, NodeInfo.Gauss3Node));
                }
                ele.SetAttribute(nameof(Gauss6Calculated), Gauss6Calculated.ToString());
                if (Gauss6 != null)
                {
                    ele.AppendChild(this.Gauss6.ToXmlElement(xmlDocument, NodeInfo.Gauss6Node));
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
        /// 换带异常。
        /// </summary>
        [Serializable]
        public class ZoneConvertException : Exception
        {
            public ZoneConvertException() { }
            public ZoneConvertException(string message) : base(message) { }
            public ZoneConvertException(string message, Exception inner) : base(message, inner) { }
            protected ZoneConvertException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
        #endregion
    }
}
