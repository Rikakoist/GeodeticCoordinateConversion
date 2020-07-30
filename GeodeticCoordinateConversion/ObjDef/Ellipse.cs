using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 椭球对象
    /// </summary>
    public class Ellipse
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
        /// 椭球类型(私有)。
        /// </summary>
        private GEOEllipseType ellipseType;

        /// <summary>
        /// 长半轴。
        /// </summary>
        public double a { get; private set; }
        /// <summary>
        /// 短半轴。
        /// </summary>
        public double b { get; private set; }
        /// <summary>
        /// 第一偏心率。
        /// </summary>
        public double e {
            get => (Math.Sqrt(Math.Pow(this.a, 2) - Math.Pow(this.b, 2)) / this.a);
        }
        /// <summary>
        /// 第二偏心率。
        /// </summary>
        public double e2 {
            get=> (Math.Sqrt(Math.Pow(this.a, 2) - Math.Pow(this.b, 2)) / this.b);
        }
        /// <summary>
        /// 极点处子午线曲率半径。
        /// </summary>
        public double c {
            get=> (Math.Pow(this.a, 2) / this.b);
        }
        #endregion

        #region Properties
        /// <summary>
        /// 椭球类型。
        /// </summary>
        public GEOEllipseType EllipseType
        {
            get => ellipseType;
            set
            {
                try
                {
                    if (value == ellipseType)
                        return;
                    else
                    {
                        ellipseType = value;
                        switch (value)
                        {
                            case GEOEllipseType.noEllipse:
                                {
                                    return;
                                }
                            case GEOEllipseType.Krassovsky_ellipsoid:
                                {
                                    //克拉索夫斯基椭球体
                                    this.a = 6378245;
                                    this.b = 6356863.0187730473;
                                    break;
                                }
                            case GEOEllipseType.Int_1975:
                                {
                                    //1975年国际椭球体
                                    this.a = 6378140;
                                    this.b = 6356755.2881575287;
                                    break;
                                }
                            case GEOEllipseType.WGS_84:
                                {
                                    //WGS-84椭球体
                                    this.a = 6378137;
                                    this.b = 6356752.3142;
                                    break;
                                }
                            case GEOEllipseType.CGCS_2000:
                                {
                                    //CGCS-2000
                                    this.a = 6378137;
                                    this.b = 6356752.3141;
                                    break;
                                }
                            default:
                                {
                                    throw new Exception(ErrMessage.GEOEllipse.EllipseUnknown);
                                }
                        }
                        EllipseChanged?.Invoke(this, new EventArgs());
                    }
                }
                catch (Exception err)
                {
                    this.EllipseType = GEOEllipseType.noEllipse;
                    throw new SetEllipseTypeException(ErrMessage.GEOEllipse.SetEllipseTypeFailed, err);
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 椭球默认构造函数。
        /// </summary>
        public Ellipse()
        {
            try
            {
                //this.EllipseType = GEOEllipseType.noEllipse;
                this.EllipseType = (GEOEllipseType)AppSettings.DefaultEllipseType;
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.GEOEllipse.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过椭球类型初始化椭球。
        /// </summary>
        /// <param name="newEllipse">要设置的椭球类型</param>
        public Ellipse(GEOEllipseType newEllipse)
        {
            try
            {
                if ((int)newEllipse < 0)
                    throw new ArgumentOutOfRangeException(ErrMessage.GEOEllipse.EllipseUnknown);
                this.EllipseType = newEllipse;
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.GEOEllipse.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过XML节点初始化椭球。
        /// </summary>
        /// <param name="xmlNode">包含对象结构的XML节点。</param>
        public Ellipse(XmlNode xmlNode)
        {
            try
            {
                XmlElement ele = (XmlElement)xmlNode;
                this.EllipseType = (GEOEllipseType)int.Parse(ele.GetAttribute(nameof(EllipseType)));
            }
            catch (Exception err)
            {
                throw new InitializeFromXmlException(ErrMessage.GEOEllipse.InitializeError, err);
            }
        }
        #endregion

        #region Events
        public delegate void EllipseChangedEventHander(object sender, EventArgs e);
        public event EllipseChangedEventHander EllipseChanged;
        #endregion

        #region Methods
        /// <summary>
        /// 转换到XML元素。
        /// </summary>
        /// <param name="xmlDocument">指定的XML文档。</param>
        /// <param name="NodeName">新建的元素命名，默认为Ellipse。</param>
        /// <returns>转换到的XML元素。</returns>
        public XmlElement ToXmlElement(XmlDocument xmlDocument, string NodeName = NodeInfo.EllipseNode)
        {
            try
            {
                XmlElement ele = xmlDocument.CreateElement(NodeName);
                //ele.SetAttribute(nameof(guid), this.guid.ToString());
                ele.SetAttribute(nameof(EllipseType), ((int)this.EllipseType).ToString());
                return ele;
            }
            catch (Exception err)
            {
                throw new XmlException(ErrMessage.GEOEllipse.SaveToXmlFailed, err);
            }
        }

        /// <summary>
        /// 相等。
        /// </summary>
        /// <param name="obj">比较对象。</param>
        /// <returns>比较结果。</returns>
        public override bool Equals(object obj)
        {
            var ellipse = obj as Ellipse;
            return ellipse != null &&
                   a == ellipse.a &&
                   b == ellipse.b &&
                   EllipseType == ellipse.EllipseType;
        }

        /// <summary>
        /// 获取摘要。
        /// </summary>
        /// <returns>摘要。</returns>
        public override int GetHashCode()
        {
            var hashCode = 986177874;
            hashCode = hashCode * -1521134295 + a.GetHashCode();
            hashCode = hashCode * -1521134295 + b.GetHashCode();
            hashCode = hashCode * -1521134295 + EllipseType.GetHashCode();
            return hashCode;
        }
        #endregion

        #region Exceptions
        /// <summary>
        /// 设置椭球类型异常。
        /// </summary>
        [Serializable]
        public class SetEllipseTypeException : Exception
        {
            public SetEllipseTypeException() { }
            public SetEllipseTypeException(string message) : base(message) { }
            public SetEllipseTypeException(string message, Exception inner) : base(message, inner) { }
            protected SetEllipseTypeException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
        #endregion
    }
}
