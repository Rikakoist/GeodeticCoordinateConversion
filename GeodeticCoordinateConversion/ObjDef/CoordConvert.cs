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
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 经纬度、高斯互转对象。
    /// </summary>
    public class CoordConvert : DataStatus
    {
        #region Fields
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
        [DispId(0)]
        public bool Selected { get => base.Selected; set => base.Selected = value; }
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

                this.UID = Guid.Parse(ele.GetAttribute(nameof(UID)));
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
                throw new XmlException(ErrMessage.CoordConvert.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过GUID从数据库初始化经纬度、高斯互转对象。
        /// </summary>
        /// <param name="guid">要查询的GUID。</param>
        public CoordConvert(Guid guid)
        {
            try
            {
                if (DBIO.GUIDExists(nameof(CoordConvert), guid))
                {
                    DataRow dr = DBIO.SelectByGUID(nameof(CoordConvert), guid);
                    this.UID = Guid.Parse(dr[nameof(UID)].ToString());
                    this.Selected = bool.Parse(dr[nameof(Selected)].ToString());
                    this.Dirty = bool.Parse(dr[nameof(Dirty)].ToString());
                    this.Calculated = bool.Parse(dr[nameof(Calculated)].ToString());
                    this.Error = bool.Parse(dr[nameof(Error)].ToString());

                    this.BL = new GEOBL(Guid.Parse(dr[nameof(BL)].ToString()));
                    BindBLEvents();
                    this.Gauss = new GaussCoord(Guid.Parse(dr[nameof(Gauss)].ToString()));
                    BindGaussEvents();
                }
                else
                {
                    this.BL = new GEOBL();
                    BindBLEvents();
                    this.Gauss = new GaussCoord();
                    BindGaussEvents();
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
        /// 经纬度、高斯互转对象转换到XML元素。
        /// </summary>
        /// <param name="xmlDocument">指定的XML文档。</param>
        /// <param name="NodeName">新建的元素命名。</param>
        /// <returns>转换到的XML元素。</returns>
        public XmlElement ToXmlElement(XmlDocument xmlDocument, string NodeName = NodeInfo.CoordConvertNode)
        {
            try
            {
                XmlElement ele = xmlDocument.CreateElement(NodeName);

                ele.SetAttribute(nameof(UID), UID.ToString());
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
                throw new XmlException(ErrMessage.CoordConvert.SaveToXmlFailed, err);
            }
        }

        /// <summary>
        /// 将经纬度、高斯互转对象保存到数据库。
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
                cmd.Parameters.AddWithValue("@BL", BL.UID.ToString());
                cmd.Parameters.AddWithValue("@Gauss", Gauss.UID.ToString());

                if (DBIO.GUIDExists(nameof(CoordConvert), this.UID))
                {
                    cmd.CommandText = "UPDATE CoordConvert SET [Selected] = @Selected, [Dirty] = @Dirty, [Calculated] = @Calculated, [Error] = @Error, [BL] = @BL, [Gauss] = @Gauss WHERE [UID] = @UID";
                    cmd.Parameters.Insert(cmd.Parameters.Count, p);
                }
                else
                {
                    cmd.CommandText = "INSERT INTO CoordConvert ([UID], [Selected], [Dirty], [Calculated], [Error], [BL], [Gauss]) VALUES (@UID, @Selected, @Dirty, @Calculated, @Error, @BL, @Gauss)";
                    cmd.Parameters.Insert(0, p);
                }
                cmd.ExecuteNonQuery();
                Gauss.SaveToDB();
                BL.SaveToDB();
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
