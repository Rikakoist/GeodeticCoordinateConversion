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

    /// <summary>
    /// 枚举常量的数据表。
    /// </summary>
    public static class GEODataTables
    {
        /// <summary>
        /// 获取分带类型的数据表。
        /// </summary>
        /// <returns>数据表。</returns>
        public static DataTable GetZoneType()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add(nameof(GEOZoneType));
            DT.Columns.Add("Name");
            DT.Columns.Add("Value");

            foreach(int i in Enum.GetValues(typeof(GEOZoneType)))
            {
                DataRow DR = DT.NewRow();
                DR[nameof(GEOZoneType)] = (typeof(GEOZoneType).GetField(((GEOZoneType)i).ToString()).GetCustomAttributes(false)[0] as DescriptionAttribute).Description;
                DR["Name"] = Enum.GetName(typeof(GEOZoneType), i);
                DR["Value"] = i;
                DT.Rows.Add(DR);
            }
            return DT;
        }

        /// <summary>
        /// 获取椭球类型的数据表。
        /// </summary>
        /// <returns>数据表。</returns>
        public static DataTable GetEllipseType()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add(nameof(GEOEllipseType));
            DT.Columns.Add("Name");
            DT.Columns.Add("Value");
            foreach (int i in Enum.GetValues(typeof(GEOEllipseType)))
            {
                DataRow DR = DT.NewRow();
                DR[nameof(GEOEllipseType)] = (typeof(GEOEllipseType).GetField(((GEOEllipseType)i).ToString()).GetCustomAttributes(false)[0] as DescriptionAttribute).Description;
                DR["Name"] = Enum.GetName(typeof(GEOEllipseType), i);
                DR["Value"] = i;
                DT.Rows.Add(DR);
            }
            return DT;
        }

        /// <summary>
        /// 通用获取数据表方式。由于未知原因会造成后续错误。
        /// </summary>
        /// <param name="e">枚举类型。</param>
        /// <returns></returns>
        public static DataTable GetEnumType(Enum e)
        {
            DataTable DT = new DataTable();
            DT.Columns.Add(nameof(e));
            DT.Columns.Add("Name");
            DT.Columns.Add("Value");
            foreach (int i in Enum.GetValues(e.GetType()))
            {
                DataRow DR = DT.NewRow();
                DR[nameof(e)] = (e.GetType().GetField(Enum.GetName(e.GetType(), i)).GetCustomAttributes(false)[0] as DescriptionAttribute).Description;
                DR["Name"] = Enum.GetName(e.GetType(), i);
                DR["Value"] = i;
                DT.Rows.Add(DR);
            }
            return DT;
        }
    }
}
