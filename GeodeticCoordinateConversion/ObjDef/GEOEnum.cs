using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        [Description("未设置分带")]
        None = 0,
        /// <summary>
        /// 3度带。
        /// </summary>
        [Description("3度带")]
        Zone3 = 3,
        /// <summary>
        /// 6度带。
        /// </summary>
        [Description("6度带")]
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
        [Description("未设置椭球")]
        noEllipse = 0,
        /// <summary>
        /// 克拉索夫斯基椭球体。
        /// </summary>
        [Description("克拉索夫斯基椭球体")]
        Krassovsky_ellipsoid = 1,
        /// <summary>
        /// 1975年国际椭球体。
        /// </summary>
        [Description("1975年国际椭球体")]
        Int_1975 = 2,
        /// <summary>
        /// WGS-84椭球体。
        /// </summary>
        [Description("WGS-84椭球体")]
        WGS_84 = 3,
        /// <summary>
        /// CGCS-2000。
        /// </summary>
        [Description("CGCS-2000")]
        CGCS_2000 = 4
    }

    public static class GEODataTables
    {
        public static DataTable GetZoneType()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add(nameof(GEOEllipseType));
            DT.Columns.Add("Value");
            foreach(int i in Enum.GetValues(typeof(GEOZoneType)))
            {
                DataRow DR = DT.NewRow();
                DR[nameof(GEOEllipseType)] = (typeof(GEOZoneType).GetField(((GEOZoneType)i).ToString()).GetCustomAttributes(false)[0] as DescriptionAttribute).Description;
                DR["Value"] = i;
                DT.Rows.Add(DR);
            }
            return DT;
        }
    }
}
