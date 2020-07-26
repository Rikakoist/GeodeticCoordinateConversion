﻿using System;
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
        /// <summary>
        /// 全局唯一ID。
        /// </summary>
        public readonly Guid guid;
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
        public double e { get; private set; }
        /// <summary>
        /// 第二偏心率。
        /// </summary>
        public double e2 { get; private set; }
        /// <summary>
        /// 极点处子午线曲率半径。
        /// </summary>
        public double c { get; private set; }
        /// <summary>
        /// 椭球类型。
        /// </summary>
        public GEOEllipseType EllipseType
        {
            get
            {
                return ellipseType;
            }
            set
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
                                throw new Exception(ErrMessage.ArgumentUnknown);
                            }
                    }
                    this.c = Math.Pow(this.a, 2) / this.b;
                    this.e = Math.Sqrt(Math.Pow(this.a, 2) - Math.Pow(this.b, 2)) / this.a;
                    this.e2 = Math.Sqrt(Math.Pow(this.a, 2) - Math.Pow(this.b, 2)) / this.b;
                    EllipseChanged?.Invoke(this, null);
                }
            }
        }

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public Ellipse()
        {
            this.EllipseType = GEOEllipseType.noEllipse;
        }

        /// <summary>
        /// 通过椭球类型初始化椭球。
        /// </summary>
        /// <param name="newEllipse">要设置的椭球类型</param>
        public Ellipse(GEOEllipseType newEllipse)
        {
            if ((int)newEllipse < 0)
                throw new ArgumentOutOfRangeException(ErrMessage.ArgumentUnknown);
            this.EllipseType = newEllipse;
        }

        /// <summary>
        /// 通过XML节点初始化。
        /// </summary>
        /// <param name="xmlNode">包含对象结构的XML节点。</param>
        public Ellipse(XmlNode xmlNode)
        {
            XmlElement ele = (XmlElement)xmlNode;
            this.EllipseType = (GEOEllipseType)int.Parse(ele.GetAttribute(nameof(EllipseType)));
        }

        public delegate void EllipseChangedEventHander(object sender, EventArgs e);
        public event EllipseChangedEventHander EllipseChanged;

        /// <summary>
        /// 转换到XML元素。
        /// </summary>
        /// <param name="xmlDocument">指定的XML文档。</param>
        /// <param name="NodeName">新建的元素命名，默认为Ellipse。</param>
        /// <returns>转换到的XML元素。</returns>
        internal XmlElement ToXmlElement(XmlDocument xmlDocument, string NodeName = NodeInfo.EllipseNode)
        {
            XmlElement ele = xmlDocument.CreateElement(NodeName);
            //ele.SetAttribute(nameof(guid), this.guid.ToString());
            ele.SetAttribute(nameof(EllipseType), ((int)this.EllipseType).ToString());
            return ele;
        }
    }
}
