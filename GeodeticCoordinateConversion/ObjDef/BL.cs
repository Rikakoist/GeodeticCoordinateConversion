﻿using System;
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
    public class BL
    {
        /// <summary>
        /// 全局唯一ID。
        /// </summary>
        public readonly Guid guid;
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
        /// 椭球。
        /// </summary>
        public Ellipse GEOEllipse;

        /// <summary>
        /// 空的构造函数。将会新建两个默认值的DMS对象。
        /// </summary>
        public BL()
        {
            this.guid = System.Guid.NewGuid();
            this.B = new DMS(); this.L = new DMS();
        }

        /// <summary>
        /// 通过字符串初始化度分秒经纬度。
        /// </summary>
        /// <param name="B">字符串表示的纬度。</param>
        /// <param name="L">字符串表示的经度。</param>
        public BL(string B, string L)
        {
            this.guid = System.Guid.NewGuid();
            this.B = GeoCalc.Str2DMS(B);
            this.L = GeoCalc.Str2DMS(L);
        }

        /// <summary>
        /// 通过DMS对象初始化。
        /// </summary>
        /// <param name="B">DMS类型的纬度对象。</param>
        /// <param name="L">DMS类型的经度对象。</param>
        public BL(DMS B, DMS L)
        {
            this.guid = System.Guid.NewGuid();
            this.B = B; this.L = L;
        }

        /// <summary>
        /// 通过XML节点初始化。
        /// </summary>
        /// <param name="xmlNode">包含对象结构的XML节点。</param>
        public BL(XmlNode xmlNode)
        {
            XmlElement ele = (XmlElement)xmlNode;
            this.guid =Guid.Parse(ele.GetAttribute(nameof(guid)));
            this.ZoneType = (GEOZoneType)int.Parse(ele.GetAttribute(nameof(ZoneType)));
            this.B = new DMS(xmlNode.SelectSingleNode(NodeInfo.BNodePath));
            this.L = new DMS(xmlNode.SelectSingleNode(NodeInfo.LNodePath));
            this.GEOEllipse = new Ellipse(xmlNode.SelectSingleNode(NodeInfo.EllipseNodePath));
        }

        /// <summary>
        /// 高斯正算（度分秒到高斯投影坐标）。
        /// </summary>
        /// <param name="CustomizeMode">强制自定义转换模式。</param>
        /// <returns>高斯正算结果。</returns>
        public GaussCoord GaussDirect(GEOZoneType CustomizeMode = GEOZoneType.None)
        {
            //转换为十进制度（可使用自定义模式）
            DEC CDEC = new DEC(GeoCalc.DMS2DEC(this.B), GeoCalc.DMS2DEC(this.L), (CustomizeMode != GEOZoneType.None) ? CustomizeMode : this.ZoneType);

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
            GaussCoord GaussResult = new GaussCoord
            {
                GEOEllipse = this.GEOEllipse,
                X = X + N / 2 * Math.Sin(CDEC.B) * Math.Cos(CDEC.B) * Math.Pow(l, 2) / Math.Pow(p, 2) + N / (24 * Math.Pow(p, 4)) * Math.Sin(CDEC.B) * (Math.Pow((Math.Cos(CDEC.B)), 3)) * (5 - Math.Pow(t, 2) + 9 * n + 4 * Math.Pow(n, 2)) * Math.Pow(l, 4) + N / (720 * Math.Pow(p, 6)) * Math.Sin(CDEC.B) * (Math.Pow((Math.Cos(CDEC.B)), 5)) * (61 - 58 * Math.Pow(t, 2) + Math.Pow(t, 4)) * Math.Pow(l, 6),
                Y = N * Math.Cos(CDEC.B) * l / p + N / (6 * Math.Pow(p, 3)) * (Math.Pow(Math.Cos(CDEC.B), 3)) * (1 - Math.Pow(t, 2) + n) * Math.Pow(l, 3) + N / (120 * Math.Pow(p, 5)) * (Math.Pow(Math.Cos(CDEC.B), 5)) * (5 - 18 * Math.Pow(t, 2) + Math.Pow(t, 4) + 14 * n - 58 * Math.Pow(t, 2) * n) * Math.Pow(l, 5),
                ZoneType = CDEC.ZoneType,
                Zone = CDEC.Zone,
            };
            //GaussResult.GetCenter();
            return GaussResult;
        }

        /// <summary>
        /// 转换到XML元素。
        /// </summary>
        /// <param name="xmlDocument">指定的XML文档。</param>
        /// <param name="NodeName">新建的元素命名，默认为Geo。</param>
        /// <returns>转换到的XML元素。</returns>
        internal XmlElement ToXmlElement(XmlDocument xmlDocument, string NodeName = NodeInfo.BLNode)
        {
            XmlElement ele = xmlDocument.CreateElement(NodeName);

            ele.SetAttribute(nameof(guid), this.guid.ToString());
            ele.SetAttribute(nameof(ZoneType), ((int)this.ZoneType).ToString());

            ele.AppendChild(this.GEOEllipse.ToXmlElement(xmlDocument));
            ele.AppendChild(this.B.ToXmlElement(xmlDocument, NodeInfo.BNode));
            ele.AppendChild(this.L.ToXmlElement(xmlDocument, NodeInfo.LNode));

            return ele;
        }
    }

    /// <summary>
    /// 度分秒类。
    /// </summary>
    public class DMS
    {
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

        /// <summary>
        /// 度。
        /// </summary>
        public double D
        {
            get
            {
                return d;
            }
            set
            {
                if ((value < Restraints.DegreeMin) || (value > Restraints.DegreeMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.DegreeOutOfRange);
                }
                else
                {
                    this.d = value;
                }
            }
        }
        /// <summary>
        /// 分。
        /// </summary>
        public double M
        {
            get
            {
                return m;
            }
            set
            {
                if ((value < Restraints.MinuteMin) || (value > Restraints.MinuteMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.MinuteOutOfRange);
                }
                else
                {
                    this.m = value;
                }
            }
        }
        /// <summary>
        /// 秒。
        /// </summary>
        public double S
        {
            get
            {
                return s;
            }
            set
            {
                if ((value < Restraints.SecondMin) || (value > Restraints.SecondMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.SecondOutOfRange);
                }
                else
                {
                    this.s = value;
                }
            }
        }

        /// <summary>
        /// 空的构造函数。度、分、秒将设为默认值0。
        /// </summary>
        public DMS()
        {
            this.guid = System.Guid.NewGuid();
            this.D = 0; this.M = 0; this.S = 0;
        }

        /// <summary>
        /// 使用度分秒初始化对象。
        /// </summary>
        /// <param name="D">度。</param>
        /// <param name="M">分。</param>
        /// <param name="S">秒。</param>
        public DMS(double D, double M, double S)
        {
            this.guid = System.Guid.NewGuid();
            this.D = D; this.M = M; this.S = S;
        }

        /// <summary>
        /// 通过XML节点初始化。
        /// </summary>
        /// <param name="xmlNode">包含对象结构的XML节点。</param>
        public DMS(XmlNode xmlNode)
        {
            XmlElement ele = (XmlElement)xmlNode;
            this.guid = Guid.Parse(ele.GetAttribute(nameof(guid)));
            this.D = double.Parse(ele.GetAttribute(nameof(D)));
            this.M = double.Parse(ele.GetAttribute(nameof(M)));
            this.S = double.Parse(ele.GetAttribute(nameof(S)));
        }

        /// <summary>
        /// 转换到XML元素。
        /// </summary>
        /// <param name="xmlDocument">指定的XML文档。</param>
        /// <param name="NodeName">新建的元素命名。</param>
        /// <returns>转换到的XML元素。</returns>
        internal XmlElement ToXmlElement(XmlDocument xmlDocument, string NodeName)
        {
            XmlElement ele = xmlDocument.CreateElement(NodeName);

            ele.SetAttribute(nameof(guid), this.guid.ToString());
            ele.SetAttribute(nameof(D), this.D.ToString());
            ele.SetAttribute(nameof(M), this.M.ToString());
            ele.SetAttribute(nameof(S), this.S.ToString());

            return ele;
        }
    }
}