using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 高斯坐标分带枚举量。
    /// </summary>
    public enum GEOZoneType
    {
        /// <summary>
        /// 未设置分带。
        /// </summary>
        None = 0,
        /// <summary>
        /// 3度带。
        /// </summary>
        Zone3 = 3,
        /// <summary>
        /// 6度带。
        /// </summary>
        Zone6 = 6
    }

    /// <summary>
    /// 椭球枚举常量
    /// </summary>
    public enum GEOEllipseType
    {
        /// <summary>
        /// 未设置椭球。
        /// </summary>
        noEllipse = 0,
        /// <summary>
        /// 克拉索夫斯基椭球体。
        /// </summary>
        Krassovsky_ellipsoid = 1,
        /// <summary>
        /// 1975年国际椭球体。
        /// </summary>
        Int_1975 = 2,
        /// <summary>
        /// WGS-84椭球体。
        /// </summary>
        WGS_84 = 3,
        /// <summary>
        /// CGCS-2000。
        /// </summary>
        CGCS_2000 = 4
    }
}
