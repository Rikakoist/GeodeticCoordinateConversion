using GeodeticCoordinateConversion.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 错误信息。
    /// </summary>
    public static class ErrMessage
    {
        private static Settings S = new Settings();
        private static ResourceManager rm = new ResourceManager("GeodeticCoordinateConversion.Resources." + S.Language, Assembly.GetExecutingAssembly());

        /// <summary>
        /// 坐标转换错误。
        /// </summary>
        public static class CoordConvert
        {
            /// <summary>
            /// 坐标转换对象初始化失败。
            /// </summary>
            public static string InitializeError = "坐标转换对象初始化失败。";
            /// <summary>
            /// 高斯坐标转换到地理经纬度失败。
            /// </summary>
            public static string GaussToGEOBLFailed = "高斯坐标转换到地理经纬度失败。";
            /// <summary>
            /// 地理经纬度转换到高斯坐标失败。
            /// </summary>
            public static string GEOBLToGaussFailed = "地理经纬度转换到高斯坐标失败。";
            /// <summary>
            /// 将坐标转换对象保存到XML结构失败。
            /// </summary>
            public static string SaveToXmlFailed = "将坐标转换对象保存到XML结构失败。";
        }

        /// <summary>
        /// 数据错误。
        /// </summary>
        public static class Data
        {
            /// <summary>
            /// 指定数据文件出错。
            /// </summary>
            public static string ErrSpecifyingDataFile = "指定数据文件出错。";
            /// <summary>
            /// 当前选定的选项卡不包含计算用数据框。
            /// </summary>
            public static string DataGridViewNotExist = "当前选定的选项卡不包含计算用数据框。";
            /// <summary>
            /// 数据框为空。
            /// </summary>
            public static string EmptyDataGridView = "数据框为空。";
            /// <summary>
            /// 字符串小数点位置错误。
            /// </summary>
            public static string WrongDigitPosition = "字符串小数点位置错误。";

            /// <summary>
            /// 度超限。
            /// </summary>
            public static string DegreeOutOfRange = "度应介于 " + Restraints.DegreeMin.ToString() + " - " + Restraints.DegreeMax.ToString() + " 间。";
            /// <summary>
            /// 分超限。
            /// </summary>
            public static string MinuteOutOfRange = "分应介于 " + Restraints.MinuteMin.ToString() + " - " + Restraints.MinuteMax.ToString() + " 间。";
            /// <summary>
            /// 秒超限。
            /// </summary>
            public static string SecondOutOfRange = "秒应介于 " + Restraints.SecondMin.ToString() + " - " + Restraints.SecondMax.ToString() + " 间。";
            /// <summary>
            /// 纬度超限。
            /// </summary>
            public static string BiotitudeOutOfRange = "纬度应介于 " + Restraints.BiotitudeMin.ToString() + " - " + Restraints.BiotitudeMax.ToString() + " 间。";
            /// <summary>
            /// 经度超限。
            /// </summary>
            public static string LongitudeOutOfRange = "经度应介于 " + Restraints.LongitudeMin.ToString() + " - " + Restraints.LongitudeMax.ToString() + " 间。";
            /// <summary>
            /// 3度带带号超限。
            /// </summary>
            public static string Zone3OutOfRange = "3度分带带号应介于" + Restraints.Zone3Min.ToString() + " - " + Restraints.Zone3Max.ToString() + " 间。";
            /// <summary>
            /// 6度带带号超限。
            /// </summary>
            public static string Zone6OutOfRange = "6度分带带号应介于" + Restraints.Zone6Min.ToString() + " - " + Restraints.Zone6Max.ToString() + " 间。";
        }

        /// <summary>
        /// 数据管理对象错误。
        /// </summary>
        public static class DataFile
        {
            /// <summary>
            /// 数据文件管理对象初始化失败。
            /// </summary>
            public static string InitializeError = "数据文件管理对象初始化失败。";
            /// <summary>
            /// 设置数据文件存放目录失败。
            /// </summary>
            public static string SetDocPathFailed = "设置数据文件存放目录失败。";
        }

        /// <summary>
        /// 数据库错误。
        /// </summary>
        public static class DB
        {
            /// <summary>
            /// 数据库管理对象初始化失败。
            /// </summary>
            public static string InitializeError = "数据库管理对象初始化失败。";
            /// <summary>
            /// 设置数据库存放目录失败。
            /// </summary>
            public static string SetDBPathFailed = "设置数据库存放目录失败。";
        }

        /// <summary>
        /// 度分秒对象错误。
        /// </summary>
        public static class DMS
        {
            /// <summary>
            /// 度分秒对象初始化失败。
            /// </summary>
            public static string InitializeError = "度分秒对象初始化失败。";
            /// <summary>
            /// 未初始化度分秒对象。
            /// </summary>
            public static string DMSNull = "未初始化度分秒对象。";
            /// <summary>
            /// 从字符串读取度分秒信息失败。
            /// </summary>
            public static string ConvertFromStringFailed = "从字符串读取度分秒信息失败。";
            /// <summary>
            /// 将度分秒信息转换为字符串失败。
            /// </summary>
            public static string ConvertToStringFailed = "将度分秒信息转换为字符串失败。";
            /// <summary>
            /// 将度分秒对象保存到XML结构失败。
            /// </summary>
            public static string SaveToXmlFailed = "将度分秒对象保存到XML结构失败。";
        }

        /// <summary>
        /// 地理经纬度对象错误。
        /// </summary>
        public static class GEOBL
        {
            /// <summary>
            /// 地理经纬度对象初始化失败。
            /// </summary>
            public static string InitializeError = "地理经纬度对象初始化失败。";
            /// <summary>
            /// 未初始化地理经纬度对象。
            /// </summary>
            public static string GEOBLNull = "未初始化地理经纬度对象。";
            /// <summary>
            /// 高斯正算失败。
            /// </summary>
            public static string GaussDirectFailed = "高斯正算失败。";
            /// <summary>
            /// 将地理经纬度保存到XML结构失败。
            /// </summary>
            public static string SaveToXmlFailed = "将地理经纬度对象保存到XML结构失败。";
        }

        /// <summary>
        /// 椭球对象错误。
        /// </summary>
        public static class GEOEllipse
        {
            /// <summary>
            /// 椭球初始化失败。
            /// </summary>
            public static string InitializeError = "椭球对象初始化失败。";
            /// <summary>
            /// 未初始化椭球对象。
            /// </summary>
            public static string EllipseNull = "未初始化椭球对象。";
            /// <summary>
            /// 未设置椭球类型。
            /// </summary>
            public static string EllipseNotSet = "未设置椭球类型。";
            /// <summary>
            /// 未知的椭球类型。
            /// </summary>
            public static string EllipseUnknown = "未知的椭球类型。";
            /// <summary>
            /// 设置椭球类型失败。
            /// </summary>
            public static string SetEllipseTypeFailed = "设置椭球类型失败。";
            /// <summary>
            /// 将椭球保存到XML结构失败。
            /// </summary>
            public static string SaveToXmlFailed = "将椭球对象保存到XML结构失败。";
        }

        /// <summary>
        /// 高斯坐标对象错误。
        /// </summary>
        public static class GaussCoord
        {
            /// <summary>
            /// 高斯坐标初始化失败。
            /// </summary>
            public static string InitializeError = "高斯坐标对象初始化失败。";
            /// <summary>
            /// 未初始化高斯坐标。
            /// </summary>
            public static string GaussNull = "未初始化高斯坐标对象。";
            /// <summary>
            /// 计算中央经线失败。
            /// </summary>
            public static string GetCenterFailed = "计算中央经线失败。";
            /// <summary>
            /// 设置中央经线失败。
            /// </summary>
            public static string SetCenterFailed = "设置中央经线失败。";
            /// <summary>
            /// 用于初始化的两个高斯坐标拥有同样的分带类型。
            /// </summary>
            public static string SameZoneType = "用于初始化对象的两个高斯坐标拥有同样的分带类型。";
            /// <summary>
            /// 设置高斯坐标带号失败。
            /// </summary>
            public static string SetZoneFailed = "设置高斯坐标带号失败。";
            /// <summary>
            /// 高斯反算失败。
            /// </summary>
            public static string GaussReverseFailed = "高斯反算失败。";
            /// <summary>
            /// 将高斯坐标保存到XML结构失败。
            /// </summary>
            public static string SaveToXmlFailed = "将高斯坐标对象保存到XML结构失败。";
        }

        /// <summary>
        /// 通用错误。
        /// </summary>
        public static class Generic
        {
            /// <summary>
            /// 传入了未知的参数。
            /// </summary>
            public static string ArgumentUnknown = "传入了未知的参数。";
            /// <summary>
            /// 转换操作失败。
            /// </summary>
            public static string ConvertOperationFailed = "上一次坐标转换操作出现问题，请检查后重试。";
            /// <summary>
            /// 操作被用户取消。
            /// </summary>
            public static string OpertionCanceledByUser = "操作被用户取消。";
            /// <summary>
            /// 该功能暂未实现。
            /// </summary>
            public static string FunctionNotImplemented = "该功能暂未实现。";
            /// <summary>
            /// 指定的文件夹不存在。
            /// </summary>
            public static string DirectoryNotFound = "指定的文件夹不存在。";
            /// <summary>
            /// 指定的文件不存在。
            /// </summary>
            public static string FileNotFound = "指定的文件不存在。";

            /// <summary>
            /// 绑定事件失败。
            /// </summary>
            public static string BindEventFailed = "绑定事件失败。";
        }

        /// <summary>
        /// 分带错误。
        /// </summary>
        public static class GEOZone
        {
            /// <summary>
            /// 未设置分带类型。
            /// </summary>
            public static string ZoneTypeNotSet = "未设置分带类型。";
            /// <summary>
            /// 未知的分带类型。
            /// </summary>
            public static string ZoneTypeUnknown = "未知的分带类型。";
        }

        /// <summary>
        /// 换带错误。
        /// </summary>
        public static class ZoneConvert
        {
            /// <summary>
            /// 换带初始化失败。
            /// </summary>
            public static string InitializeError = "换带初始化失败。";
            /// <summary>
            /// 换带操作失败。
            /// </summary>
            public static string ZoneConvertFailed = "换带操作失败。";
            /// <summary>
            /// 从3度带转换到6度带失败。
            /// </summary>
            public static string Convert3To6Failed = "从3度带转换到6度带失败。";
            /// <summary>
            /// 从6度带转换到3度带失败。
            /// </summary>
            public static string Convert6To3Failed = "从6度带转换到3度带失败。";
            /// <summary>
            /// 将换带对象保存到XML结构失败。
            /// </summary>
            public static string SaveToXmlFailed = "将换带对象保存到XML结构失败。";
        }
    }

    /// <summary>
    /// 提示信息。
    /// </summary>
    public static class Hints
    {
        private static Settings S = new Settings();
        private static ResourceManager rm = new ResourceManager("GeodeticCoordinateConversion.Resources." + S.Language, Assembly.GetExecutingAssembly());

        /// <summary>
        /// 获取问候语。
        /// </summary>
        /// <returns>按照小时决定返回的问候语。</returns>
        public static string Greet()
        {
            int h = DateTime.Now.Hour;
            string pref = rm.GetString("Hello");
            string suff = rm.GetString("PeriodComma");
            switch (h)
            {
                case 23:
                case 0:
                case 1:
                    {
                        pref = rm.GetString("DeepNight");
                        break;
                    }
                case 2:
                case 3:
                case 4:
                    {
                        pref = rm.GetString("NightOwl");
                        suff = rm.GetString("Comma") + rm.GetString("Hello");
                        break;
                    }
                case 5:
                case 6:
                case 7:
                    {
                        pref = rm.GetString("NewDay");
                        break;
                    }
                case 8:
                case 9:
                case 10:
                    {
                        pref = rm.GetString("GoodMorning");
                        break;
                    }
                case 11:
                case 12:
                case 13:
                    {
                        pref = rm.GetString("GoodNoon");
                        break;
                    }
                case 14:
                case 15:
                case 16:
                case 17:
                    {
                        pref = rm.GetString("GoodAfternoon");
                        break;
                    }
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                    {
                        pref = rm.GetString("GoodEvening");
                        break;
                    }
                default:
                    {
                        pref = rm.GetString("Halo");
                        break;
                    }
            }
            return pref + rm.GetString("Comma") + Environment.UserName + suff;
        }
        /// <summary>
        /// 用户取消了操作。
        /// </summary>
        public static string OperationCanceled = rm.GetString("OperationCanceledByUser");
        /// <summary>
        /// 计算结果。
        /// </summary>
        /// <param name="convertType">转换类型。</param>
        /// <param name="all">记录总条数。</param>
        /// <param name="calculated">已计算条数。</param>
        /// <param name="success">成功条数。</param>
        /// <param name="failed">失败条数。</param>
        /// <returns></returns>
        public static string ConvertResult(GEOConvertType convertType, int all, int calculated, int success, int failed)
        {
            return string.Format(rm.GetString("ConvertResult"), GEODataTables.GetDescription(new GEOConvertType(), (int)convertType), all,calculated,success,failed);
        }
        /// <summary>
        /// 已加载数据。
        /// </summary>
        /// <param name="dataSourceType">数据源类型。</param>
        /// <param name="Count">记录数量。</param>
        /// <param name="dataType">数据类型</param>
        /// <returns></returns>
        public static string DataLoaded(GEODataSourceType dataSourceType, int Count, GEODataType dataType)
        {
            return string.Format(rm.GetString("DataLoaded"), GEODataTables.GetDescription(new GEODataSourceType(), (int)dataSourceType),Count, GEODataTables.GetDescription(new GEODataType(), (int)dataType));
        }
        /// <summary>
        /// 已保存数据。
        /// </summary>
        /// <param name="dataSourceType">数据源类型。</param>
        /// <param name="Count">记录数量。</param>
        /// <param name="dataType">数据类型</param>
        /// <returns></returns>
        public static string DataSaved(GEODataSourceType dataSourceType, int Count, GEODataType dataType)
        {
            return string.Format(rm.GetString("DataSaved"), Count, GEODataTables.GetDescription(new GEODataType(), (int)dataType), GEODataTables.GetDescription(new GEODataSourceType(), (int)dataSourceType));
        }
        /// <summary>
        /// 已加载表列表。
        /// </summary>
        /// <param name="TableCount">表数。</param>
        /// <returns></returns>
        public static string TableListLoaded(int TableCount)
        {
            return string.Format(rm.GetString("TableListLoaded"), new Settings().DBName, TableCount);
        }
        /// <summary>
        /// 表记录数。
        /// </summary>
        /// <param name="TableName">表名。</param>
        /// <param name="RecordCount">记录数。</param>
        /// <returns></returns>
        public static string TableRecordCount(string TableName, int? RecordCount)
        {
            return string.Format(rm.GetString("TableRecordCount"), TableName.Replace(" ","_"),RecordCount);
        }
        /// <summary>
        /// 已重载表。
        /// </summary>
        /// <param name="TableName">表名。</param>
        /// <returns></returns>
        public static string TableReloaded(string TableName)
        {
            return string.Format(rm.GetString("TableReloaded"), new Settings().DBName, TableName.Replace(" ", "_"));
        }
        /// <summary>
        /// 已添加行。
        /// </summary>
        /// <returns></returns>
        public static string RowAdded()
        {
            return rm.GetString("RowAdded");
        }
        /// <summary>
        /// 已删除行。
        /// </summary>
        /// <param name="row">行数。</param>
        /// <returns></returns>
        public static string RowDeleted(int row)
        {
            return string.Format(rm.GetString("RowDeleted"), row);
        }
        /// <summary>
        /// 数据库转换到文件。
        /// </summary>
        /// <param name="CoordCount">坐标转换记录条数。</param>
        /// <param name="ZoneCount">换带记录条数。</param>
        /// <returns></returns>
        public static string DBSavedToFile(int? CoordCount, int? ZoneCount)
        {
            return string.Format(rm.GetString("DBSavedToFile"), new Settings().DBName,CoordCount,ZoneCount, new Settings().DataFileName);
        }
        /// <summary>
        /// 文件转换到数据库。
        /// </summary>
        /// <param name="CoordCount">坐标转换记录条数。</param>
        /// <param name="ZoneCount">换带记录条数。</param>
        /// <returns></returns>
        public static string FileSavedToDB(int? CoordCount, int? ZoneCount)
        {
            return string.Format(rm.GetString("FileSavedToDB"), new Settings().DataFileName, CoordCount, ZoneCount, new Settings().DBName);
        }
    }

    /// <summary>
    /// 数据文件文本。
    /// </summary>
    public static class XMLStr
    {
        /// <summary>
        /// 当前时间。
        /// </summary>
        public static string Now = DateTime.Now.ToString("yyyyMMddHHmmss");
    }

    /// <summary>
    /// 数据库描述字符串。
    /// </summary>
    public static class DBStr
    {
        private static Settings S = new Settings();
        private static ResourceManager rm = new ResourceManager("GeodeticCoordinateConversion.Resources." + S.Language, Assembly.GetExecutingAssembly());

        /// <summary>
        /// 数据状态。
        /// </summary>
        public static class DataStatus
        {
            public static string Selected = rm.GetString("DataStatusSelected");
            public static string Dirty = rm.GetString("DataStatusDirty");
            public static string Calculated = rm.GetString("DataStatusCalculated");
            public static string Error = rm.GetString("DataStatusError");
        }

        /// <summary>
        /// 坐标转换。
        /// </summary>
        public static class CoordConvert
        {
            public static string Description = rm.GetString("CoordConvert");
            public static string UID = rm.GetString("CoordConvertUID");
            public static string BL = rm.GetString("CoordConvertBL");
            public static string Gauss = rm.GetString("CoordConvertGauss");
        }

        /// <summary>
        /// 换带计算。
        /// </summary>
        public static class ZoneConvert
        {
            public static string Description = rm.GetString("ZoneConvert");
            public static string UID = rm.GetString("ZoneConvertUID");
            public static string Gauss6 = rm.GetString("ZoneConvertGauss6");
            public static string Gauss3 = rm.GetString("ZoneConvertGauss3");
        }

        /// <summary>
        /// 高斯坐标。
        /// </summary>
        public static class GaussCoord
        {
            public static string Description = rm.GetString("GaussCoord");
            public static string UID = rm.GetString("GaussCoordUID");
            public static string X = rm.GetString("GaussCoordX");
            public static string Y = rm.GetString("GaussCoordY");
            public static string EllipseType = rm.GetString("GaussCoordEllipseType");
            public static string ZoneType = rm.GetString("GaussCoordZoneType");
            public static string Zone = rm.GetString("GaussCoordZone");
        }

        /// <summary>
        /// 地理经纬度。
        /// </summary>
        public static class GEOBL
        {
            public static string Description = rm.GetString("GEOBL");
            public static string UID = rm.GetString("GEOBLUID");
            public static string B = rm.GetString("GEOBLB");
            public static string L = rm.GetString("GEOBLL");
            public static string EllipseType = rm.GetString("GEOBLEllipseType");
            public static string ZoneType = rm.GetString("GEOBLZoneType");
        }
    }
}
