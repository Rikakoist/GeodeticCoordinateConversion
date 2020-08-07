using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 6度带、3度带互转类。
    /// </summary>
    public class ZoneConvert : DataStatus
    {
        #region Fields
        /// <summary>
        /// 高斯6°带坐标对象。
        /// </summary>
        public GaussCoord Gauss6;
        /// <summary>
        /// 高斯3°带坐标对象。
        /// </summary>
        public GaussCoord Gauss3;
        #endregion

        #region Properties
        /// <summary>
        /// 是否选中。
        /// </summary>
        [DisplayName("选中")]
        public bool Selected { get => base.Selected; set => base.Selected = value; }
        /// <summary>
        /// 6°带带号。
        /// </summary>
        [DisplayName("6°带号")]
        public string Zone6
        {
            get => Gauss6.Zone.ToString();
            set => Gauss6.Zone = int.Parse(value);
        }
        /// <summary>
        /// 6°带X坐标。
        /// </summary>
        [DisplayName("6°带X坐标")]
        public string X6
        {
            get => Gauss6.X.ToString();
            set => Gauss6.X = double.Parse(value);
        }
        /// <summary>
        /// 6°带Y坐标。
        /// </summary>
        [DisplayName("6°带Y坐标")]
        public string Y6
        {
            get => Gauss6.Y.ToString();
            set => Gauss6.Y = double.Parse(value);
        }
        /// <summary>
        /// 椭球。
        /// </summary>
        [DisplayName("椭球")]
        public string EllipseType
        {
            get => ((int)Gauss3.GEOEllipse.EllipseType).ToString();
            set
            {
                Gauss3.GEOEllipse.EllipseType = (GEOEllipseType)(int.Parse(value));
                Gauss6.GEOEllipse.EllipseType = (GEOEllipseType)(int.Parse(value));
            }
        }
        /// <summary>
        /// 3°带带号。
        /// </summary>
        [DisplayName("3°带号")]
        public string Zone3
        {
            get => Gauss3.Zone.ToString();
            set => Gauss3.Zone = int.Parse(value);
        }
        /// <summary>
        /// 3°带X坐标。
        /// </summary>
        [DisplayName("3°带X坐标")]
        public string X3
        {
            get => Gauss3.X.ToString();
            set => Gauss3.X = double.Parse(value);
        }
        /// <summary>
        /// 3°带Y坐标。
        /// </summary>
        [DisplayName("3°带Y坐标")]
        public string Y3
        {
            get => Gauss3.Y.ToString();
            set => Gauss3.Y = double.Parse(value);
        }
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
                if (newGauss is null)
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
                            BindGauss3Events();
                            Convert3To6();
                            break;
                        }
                    case GEOZoneType.Zone6:
                        {
                            this.Gauss6 = newGauss;
                            BindGauss6Events();
                            Convert6To3();
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
                if (gauss1 is null || gauss2 is null)
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
                            this.Gauss6 = gauss2;
                            break;
                        }
                    case GEOZoneType.Zone6:
                        {
                            this.Gauss6 = gauss1;
                            this.Gauss3 = gauss2;
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

                this.UID = Guid.Parse(ele.GetAttribute(nameof(UID)));
                this.Dirty = bool.Parse(ele.GetAttribute(nameof(Dirty)));
                this.Error = bool.Parse(ele.GetAttribute(nameof(Error)));
                this.Selected = bool.Parse(ele.GetAttribute(nameof(Selected)));
                this.Calculated = bool.Parse(ele.GetAttribute(nameof(Calculated)));

                XmlNode Gauss3Node = ele.SelectSingleNode(NodeInfo.Gauss3NodePath);
                if (Gauss3Node is null)
                {
                    this.Gauss3 = new GaussCoord();
                }
                else
                {
                    this.Gauss3 = new GaussCoord(Gauss3Node);
                }
                BindGauss3Events();

                XmlNode Gauss6Node = ele.SelectSingleNode(NodeInfo.Gauss6NodePath);
                if (Gauss6Node is null)
                {
                    this.Gauss6 = new GaussCoord();
                }
                else
                {
                    this.Gauss6 = new GaussCoord(Gauss6Node);
                }
                BindGauss6Events();
            }
            catch (Exception err)
            {
                throw new XmlException(ErrMessage.ZoneConvert.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过GUID从数据库初始化6度带、3度带互转对象。
        /// </summary>
        /// <param name="guid">要查询的GUID。</param>
        public ZoneConvert(Guid guid)
        {
            try
            {
                if (DBIO.GUIDExists(nameof(ZoneConvert), guid))
                {
                    DataRow dr = DBIO.SelectByGUID(nameof(ZoneConvert), guid);
                    this.UID = Guid.Parse(dr[nameof(UID)].ToString());
                    this.Selected = bool.Parse(dr[nameof(Selected)].ToString());
                    this.Dirty = bool.Parse(dr[nameof(Dirty)].ToString());
                    this.Calculated = bool.Parse(dr[nameof(Calculated)].ToString());
                    this.Error = bool.Parse(dr[nameof(Error)].ToString());

                    this.Gauss6 = new GaussCoord(Guid.Parse(dr[nameof(Gauss6)].ToString()));
                    BindGauss6Events();
                    this.Gauss3 = new GaussCoord(Guid.Parse(dr[nameof(Gauss3)].ToString()));
                    BindGauss3Events();
                }
                else
                {
                    this.Gauss6 = new GaussCoord();
                    BindGauss6Events();
                    this.Gauss3 = new GaussCoord();
                    BindGauss3Events();
                }
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.CoordConvert.InitializeError, err);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 绑定3度带对象事件。
        /// </summary>
        private void BindGauss3Events()
        {
            this.Gauss3.ValueChanged += new GaussCoord.GaussValueChangedEventHander(this.ChangeState);
        }

        /// <summary>
        /// 绑定6度带对象事件。
        /// </summary>
        private void BindGauss6Events()
        {
            this.Gauss6.ValueChanged += new GaussCoord.GaussValueChangedEventHander(this.ChangeState);
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
        /// 6度带转3度带。
        /// </summary>
        public bool Convert6To3()
        {
            try
            {
                if ((Gauss6 != null) && (!Calculated))
                {
                    Gauss3 = Gauss6.GaussReverse() //六度带反算
                          .GaussDirect(GEOZoneType.Zone3);   //三度带正算
                    BindGauss3Events();
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
        /// 3度带转6度带。
        /// </summary>
        public bool Convert3To6()
        {
            try
            {
                if ((Gauss3 != null) && (!Calculated))
                {
                    Gauss6 = Gauss3.GaussReverse()   //三度带反算
                          .GaussDirect(GEOZoneType.Zone6);   //六度带正算
                    BindGauss6Events();
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
        /// 自动转换。
        /// </summary>
        public void AutoConvert()
        {
            throw new NotImplementedException(ErrMessage.Generic.FunctionNotImplemented);
        }

        /// <summary>
        /// 6度带、3度带互转对象转换到XML元素。
        /// </summary>
        /// <param name="xmlDocument">指定的XML文档。</param>
        /// <param name="NodeName">新建的元素命名。</param>
        /// <returns>转换到的XML元素。</returns>
        public XmlElement ToXmlElement(XmlDocument xmlDocument, string NodeName = NodeInfo.ZoneConvertNode)
        {
            try
            {
                XmlElement ele = xmlDocument.CreateElement(NodeName);

                ele.SetAttribute(nameof(UID), UID.ToString());
                ele.SetAttribute(nameof(Dirty), Dirty.ToString());
                ele.SetAttribute(nameof(Error), Error.ToString());
                ele.SetAttribute(nameof(Selected), Selected.ToString());
                ele.SetAttribute(nameof(Calculated), Calculated.ToString());

                if (Gauss3 != null)
                {
                    ele.AppendChild(this.Gauss3.ToXmlElement(xmlDocument, NodeInfo.Gauss3Node));
                }

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

        /// <summary>
        /// 将6度带、3度带互转对象保存到数据库。
        /// </summary>
        /// <returns>操作结果。</returns>
        public bool SaveToDB()
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand()
                {
                    Connection = DBIO.con,
                };

                OleDbParameter p = new OleDbParameter("@UID", UID.ToString());
                cmd.Parameters.AddWithValue("@Selected", Selected);
                cmd.Parameters.AddWithValue("@Dirty", Dirty);
                cmd.Parameters.AddWithValue("@Calculated", Calculated);
                cmd.Parameters.AddWithValue("@Error", Error);
                cmd.Parameters.AddWithValue("@Gauss6", Gauss6.UID.ToString());
                cmd.Parameters.AddWithValue("@Gauss3", Gauss3.UID.ToString());

                if (DBIO.GUIDExists(nameof(CoordConvert), this.UID))
                {
                    cmd.CommandText = "UPDATE ZoneConvert SET [Selected] = @Selected, [Dirty] = @Dirty, [Calculated] = @Calculated, [Error] = @Error, [Gauss6] = @Gauss6, [Gauss3] = @Gauss3 WHERE [UID] = @UID";
                    cmd.Parameters.Insert(cmd.Parameters.Count, p);
                }
                else
                {
                    cmd.CommandText = "INSERT INTO ZoneConvert ([UID], [Selected], [Dirty], [Calculated], [Error], [Gauss6], [Gauss3]) VALUES (@UID, @Selected, @Dirty, @Calculated, @Error, @Gauss6, @Gauss3)";
                    cmd.Parameters.Insert(0, p);
                }
                cmd.ExecuteNonQuery();
                Gauss6.SaveToDB();
                Gauss3.SaveToDB();
                return true;
            }
            catch (Exception)
            {
                return false;
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
