using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 经纬度、高斯互转对象。
    /// </summary>
    public class CoordConvert
    {
        #region Fields
        public bool BLCalculated = false;
        public GEOBL BL;
        public bool GaussCalculated = false;
        public GaussCoord Gauss;
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
                this.GaussCalculated = false;
            }
            if (sender == this.BL)
            {
                this.BLCalculated = false;
            }
        }

        public bool GaussToGEOBL()
        {
            try
            {

            }
            catch(Exception err)
            {

            }
        }

        public bool GEOBLToGauss()
        {
            try
            {

            }
            catch (Exception err)
            {

            }
        }
        #endregion
    }
}
