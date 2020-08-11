using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 应用语言。
    /// </summary>
    public enum GEOLang
    {
        [Display(Name = nameof(Resources.Lang.SimplifiedChinese), ResourceType = typeof(Resources.Lang))]
        zh_CN = 0,
        [Display(Name = nameof(Resources.Lang.English), ResourceType = typeof(Resources.Lang))]
        en_US = 1,
    }

    /// <summary>
    /// 高斯坐标分带枚举量。
    /// </summary>
    public enum GEOZoneType
    {
        /// <summary>
        /// 未设置分带。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GEOZoneTypeNone), ResourceType = typeof(Resources.Lang))]
        None = 0,
        /// <summary>
        /// 3度带。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GEOZoneType3), ResourceType = typeof(Resources.Lang))]
        Zone3 = 3,
        /// <summary>
        /// 6度带。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GEOZoneType6), ResourceType = typeof(Resources.Lang))]
        Zone6 = 6
    }

    /// <summary>
    /// 椭球枚举常量。
    /// </summary>
    public enum GEOEllipseType
    {
        /// <summary>
        /// 未设置椭球。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GEOEllipseTypenoEllipse), ResourceType = typeof(Resources.Lang))]
        noEllipse = 0,
        /// <summary>
        /// 克拉索夫斯基椭球体。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GEOEllipseTypeKrassovsky_ellipsoid), ResourceType = typeof(Resources.Lang))]
        Krassovsky_ellipsoid = 1,
        /// <summary>
        /// 1975年国际椭球体。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GEOEllipseTypeInt_1975), ResourceType = typeof(Resources.Lang))]
        Int_1975 = 2,
        /// <summary>
        /// WGS-84椭球体。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GEOEllipseTypeWGS_84), ResourceType = typeof(Resources.Lang))]
        WGS_84 = 3,
        /// <summary>
        /// CGCS-2000。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GEOEllipseTypeCGCS_2000), ResourceType = typeof(Resources.Lang))]
        CGCS_2000 = 4
    }

    /// <summary>
    /// 椭球值改变枚举常量。
    /// </summary>
    public enum EllipseChangedType
    {
        /// <summary>
        /// a改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.EllipseChangedTypea), ResourceType = typeof(Resources.Lang))]
        a = 0,
        /// <summary>
        /// b改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.EllipseChangedTypeb), ResourceType = typeof(Resources.Lang))]
        b = 1,
        /// <summary>
        /// 椭球类型改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.EllipseChangedTypeEllipseType), ResourceType = typeof(Resources.Lang))]
        EllipseType = 2,
    }

    /// <summary>
    /// 度分秒值改变枚举常量。
    /// </summary>
    public enum DMSValueChangedType
    {
        /// <summary>
        /// 度改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.EllipseChangedTypea), ResourceType = typeof(Resources.Lang))]
        D = 0,
        /// <summary>
        /// 分改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.EllipseChangedTypea), ResourceType = typeof(Resources.Lang))]
        M = 1,
        /// <summary>
        /// 秒改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.EllipseChangedTypea), ResourceType = typeof(Resources.Lang))]
        S = 2,
    }

    /// <summary>
    /// 地理经纬度值改变枚举常量。
    /// </summary>
    public enum GEOBLValueChangedType
    {
        /// <summary>
        /// B改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GEOBLValueChangedTypeB), ResourceType = typeof(Resources.Lang))]
        B = 0,
        /// <summary>
        /// L改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GEOBLValueChangedTypeL), ResourceType = typeof(Resources.Lang))]
        L = 1,
        /// <summary>
        /// 分带改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GEOBLValueChangedTypeZoneType), ResourceType = typeof(Resources.Lang))]
        ZoneType = 3,
        /// <summary>
        /// 椭球改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GEOBLValueChangedTypeEllipse), ResourceType = typeof(Resources.Lang))]
        Ellipse = 4,
    }

    /// <summary>
    /// 高斯坐标值改变枚举常量。
    /// </summary>
    public enum GaussValueChangedType
    {
        /// <summary>
        /// X改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GaussValueChangedTypeX), ResourceType = typeof(Resources.Lang))]
        X = 0,
        /// <summary>
        /// Y改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GaussValueChangedTypeY), ResourceType = typeof(Resources.Lang))]
        Y = 1,
        /// <summary>
        /// 带号改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GaussValueChangedTypeZone), ResourceType = typeof(Resources.Lang))]
        Zone = 2,
        /// <summary>
        /// 分带改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GaussValueChangedTypeZoneType), ResourceType = typeof(Resources.Lang))]
        ZoneType = 3,
        /// <summary>
        /// 椭球改变。
        /// </summary>
        [Display(Name = nameof(Resources.Lang.GaussValueChangedTypeEllipse), ResourceType = typeof(Resources.Lang))]
        Ellipse = 4,
    }

    /// <summary>
    /// 数据类型。
    /// </summary>
    public enum GEODataType
    {
        [Display(Name = nameof(Resources.Lang.CoordConvert), ResourceType = typeof(Resources.Lang))]
        CoordConvert = 0,
        [Display(Name = nameof(Resources.Lang.ZoneConvert), ResourceType = typeof(Resources.Lang))]
        ZoneConvert = 1,
    }

    /// <summary>
    /// 数据来源类型。
    /// </summary>
    public enum GEODataSourceType
    {
        [Display(Name = nameof(Resources.Lang.DataFile), ResourceType = typeof(Resources.Lang))]
        File = 0,
        [Display(Name = nameof(Resources.Lang.DB), ResourceType = typeof(Resources.Lang))]
        DB = 1,
    }

    public enum GEOConvertType
    {
        [Display(Name = nameof(Resources.Lang.GaussDirect), ResourceType = typeof(Resources.Lang))]
        GaussDirect = 0,
        [Display(Name = nameof(Resources.Lang.GaussReverse), ResourceType = typeof(Resources.Lang))]
        GaussReverse = 1,
        [Display(Name = nameof(Resources.Lang.Zone6To3), ResourceType = typeof(Resources.Lang))]
        Zone6To3 = 2,
        [Display(Name = nameof(Resources.Lang.Zone3To6), ResourceType = typeof(Resources.Lang))]
        Zone3To6 = 3,
    }

    /// <summary>
    /// 枚举常量的数据表。
    /// </summary>
    public static class GEODataTables
    {

        public static DataTable GetLangType()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add(nameof(GEOLang));
            DT.Columns.Add(Constants.NameCol);
            DT.Columns.Add(Constants.ValueCol);

            foreach (int i in Enum.GetValues(typeof(GEOLang)))
            {
                DataRow DR = DT.NewRow();
                DR[nameof(GEOLang)] = (typeof(GEOLang).GetField(((GEOLang)i).ToString()).GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute).GetName();
                DR[Constants.NameCol] = Enum.GetName(typeof(GEOLang), i);
                DR[Constants.ValueCol] = i;
                DT.Rows.Add(DR);
            }
            return DT;
        }

        /// <summary>
        /// 获取分带类型的数据表。
        /// </summary>
        /// <returns>数据表。</returns>
        public static DataTable GetZoneType()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add(nameof(GEOZoneType));
            DT.Columns.Add(Constants.NameCol);
            DT.Columns.Add(Constants.ValueCol);

            foreach (int i in Enum.GetValues(typeof(GEOZoneType)))
            {
                DataRow DR = DT.NewRow();
                DR[nameof(GEOZoneType)] = (typeof(GEOZoneType).GetField(((GEOZoneType)i).ToString()).GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute).GetName();
                DR[Constants.NameCol] = Enum.GetName(typeof(GEOZoneType), i);
                DR[Constants.ValueCol] = i;
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
            DT.Columns.Add(Constants.NameCol);
            DT.Columns.Add(Constants.ValueCol);
            foreach (int i in Enum.GetValues(typeof(GEOEllipseType)))
            {
                DataRow DR = DT.NewRow();
                DR[nameof(GEOEllipseType)] = (typeof(GEOEllipseType).GetField(((GEOEllipseType)i).ToString()).GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute).GetName();
                DR[Constants.NameCol] = Enum.GetName(typeof(GEOEllipseType), i);
                DR[Constants.ValueCol] = i;
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
            DT.Columns.Add(Constants.NameCol);
            DT.Columns.Add(Constants.ValueCol);
            foreach (int i in Enum.GetValues(e.GetType()))
            {
                DataRow DR = DT.NewRow();
                DR[nameof(e)] = (e.GetType().GetField(Enum.GetName(e.GetType(), i)).GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute).GetName();
                DR[Constants.NameCol] = Enum.GetName(e.GetType(), i);
                DR[Constants.ValueCol] = i;
                DT.Rows.Add(DR);
            }
            return DT;
        }

        /// <summary>
        /// 获取指定枚举指定值的描述内容。
        /// </summary>
        /// <param name="e">枚举。</param>
        /// <param name="i">枚举值。</param>
        /// <returns>描述。</returns>
        public static string GetDescription(Enum e, int i)
        {
            return (e.GetType().GetField(Enum.GetName(e.GetType(), i)).GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute).GetName();
        }
    }
}
