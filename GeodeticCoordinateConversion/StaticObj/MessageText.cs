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
        public static ResourceManager rm = new ResourceManager(Constants.ResourceSpace, Assembly.GetExecutingAssembly());

        /// <summary>
        /// 坐标转换错误。
        /// </summary>
        public static class CoordConvert
        {
            /// <summary>
            /// 坐标转换对象初始化失败。
            /// </summary>
            public static string InitializeError = rm.GetString("CoordConvertInitializeError");
            /// <summary>
            /// 高斯坐标转换到地理经纬度失败。
            /// </summary>
            public static string GaussToGEOBLFailed = rm.GetString("GaussToGEOBLFailed");
            /// <summary>
            /// 地理经纬度转换到高斯坐标失败。
            /// </summary>
            public static string GEOBLToGaussFailed = rm.GetString("GEOBLToGaussFailed");
            /// <summary>
            /// 将坐标转换对象保存到XML结构失败。
            /// </summary>
            public static string SaveToXmlFailed = rm.GetString("CoordConvertSaveToXmlFailed");
        }

        /// <summary>
        /// 数据错误。
        /// </summary>
        public static class Data
        {
            /// <summary>
            /// 指定数据文件出错。
            /// </summary>
            public static string ErrSpecifyingDataFile = rm.GetString("ErrSpecifyingDataFile");
            /// <summary>
            /// 当前选定的选项卡不包含计算用数据框。
            /// </summary>
            public static string DataGridViewNotExist = rm.GetString("DataGridViewNotExist");
            /// <summary>
            /// 数据框为空。
            /// </summary>
            public static string EmptyDataGridView = rm.GetString("EmptyDataGridView");
            /// <summary>
            /// 字符串小数点位置错误。
            /// </summary>
            public static string WrongDigitPosition = rm.GetString("WrongDigitPosition");

            /// <summary>
            /// 度超限。
            /// </summary>
            /// <param name="val">当前值。</param>
            /// <returns></returns>
            public static string DegreeOutOfRange(double val)
            {
                return string.Format(rm.GetString("DegreeOutOfRange"), GeodeticCoordinateConversion.DMS.DegreeMin.ToString(), GeodeticCoordinateConversion.DMS.DegreeMax.ToString(),val);
            }
            /// <summary>
            /// 分超限。
            /// </summary>
            /// <param name="val">当前值。</param>
            /// <returns></returns>
            public static string MinuteOutOfRange(double val)
            {
                return string.Format(rm.GetString("MinuteOutOfRange"), GeodeticCoordinateConversion.DMS.MinuteMin.ToString(), GeodeticCoordinateConversion.DMS.MinuteMax.ToString(), val);
            }
            /// <summary>
            /// 秒超限。
            /// </summary>
            /// <param name="val">当前值。</param>
            /// <returns></returns>
            public static string SecondOutOfRange(double val)
            {
                return string.Format(rm.GetString("SecondOutOfRange"), GeodeticCoordinateConversion.DMS.SecondMin.ToString(), GeodeticCoordinateConversion.DMS.SecondMax.ToString(), val);
            }
            /// <summary>
            /// 纬度超限。
            /// </summary>
            /// <param name="val">当前值。</param>
            /// <returns></returns>
            public static string BiotitudeOutOfRange(double val)
            {
                return string.Format(rm.GetString("BiotitudeOutOfRange"), DEC.BiotitudeMin.ToString(), DEC.BiotitudeMax.ToString(), val);
            }
            /// <summary>
            /// 经度超限。
            /// </summary>
            /// <param name="val">当前值。</param>
            /// <returns></returns>
            public static string LongitudeOutOfRange(double val)
            {
                return string.Format(rm.GetString("LongitudeOutOfRange"), DEC.LongitudeMin.ToString(), DEC.LongitudeMax.ToString(), val);
            }
            /// <summary>
            /// 3度带带号超限。
            /// </summary>
            /// <param name="val">当前值。</param>
            /// <returns></returns>
            public static string Zone3OutOfRange(int val)
            {
                return string.Format(rm.GetString("Zone3OutOfRange"), GeodeticCoordinateConversion.GaussCoord.Zone3Min.ToString(), GeodeticCoordinateConversion.GaussCoord.Zone3Max.ToString(), val);
            }
            /// <summary>
            /// 6度带带号超限。
            /// </summary>
            /// <param name="val">当前值。</param>
            /// <returns></returns>
            public static string Zone6OutOfRange(int val)
            {
                return string.Format(rm.GetString("Zone6OutOfRange"), GeodeticCoordinateConversion.GaussCoord.Zone6Min.ToString(), GeodeticCoordinateConversion.GaussCoord.Zone6Max.ToString(), val);
            }
        }

        /// <summary>
        /// 数据管理对象错误。
        /// </summary>
        public static class DataFile
        {
            /// <summary>
            /// 数据文件管理对象初始化失败。
            /// </summary>
            public static string InitializeError = rm.GetString("DataFileInitializeError");
            /// <summary>
            /// 设置数据文件存放目录失败。
            /// </summary>
            public static string SetDocPathFailed = rm.GetString("SetDocPathFailed");
        }

        /// <summary>
        /// 数据库错误。
        /// </summary>
        public static class DB
        {
            /// <summary>
            /// 数据库管理对象初始化失败。
            /// </summary>
            public static string InitializeError = rm.GetString("DBInitializeError");
            /// <summary>
            /// 设置数据库存放目录失败。
            /// </summary>
            public static string SetDBPathFailed = rm.GetString("SetDBPathFailed");
        }

        /// <summary>
        /// 度分秒对象错误。
        /// </summary>
        public static class DMS
        {
            /// <summary>
            /// 度分秒对象初始化失败。
            /// </summary>
            public static string InitializeError = rm.GetString("DMSInitializeError");
            /// <summary>
            /// 未初始化度分秒对象。
            /// </summary>
            public static string DMSNull = rm.GetString("DMSNull");
            /// <summary>
            /// 从字符串读取度分秒信息失败。
            /// </summary>
            public static string ConvertFromStringFailed = rm.GetString("ConvertFromStringFailed");
            /// <summary>
            /// 将度分秒信息转换为字符串失败。
            /// </summary>
            public static string ConvertToStringFailed = rm.GetString("ConvertToStringFailed");
            /// <summary>
            /// 将度分秒对象保存到XML结构失败。
            /// </summary>
            public static string SaveToXmlFailed = rm.GetString("DMSSaveToXmlFailed");
        }

        /// <summary>
        /// 地理经纬度对象错误。
        /// </summary>
        public static class GEOBL
        {
            /// <summary>
            /// 地理经纬度对象初始化失败。
            /// </summary>
            public static string InitializeError = rm.GetString("GEOBLInitializeError");
            /// <summary>
            /// 未初始化地理经纬度对象。
            /// </summary>
            public static string GEOBLNull = rm.GetString("GEOBLNull");
            /// <summary>
            /// 高斯正算失败。
            /// </summary>
            public static string GaussDirectFailed = rm.GetString("GaussDirectFailed");
            /// <summary>
            /// 将地理经纬度保存到XML结构失败。
            /// </summary>
            public static string SaveToXmlFailed = rm.GetString("GEOBLSaveToXmlFailed");
        }

        /// <summary>
        /// 椭球对象错误。
        /// </summary>
        public static class GEOEllipse
        {
            /// <summary>
            /// 椭球初始化失败。
            /// </summary>
            public static string InitializeError = rm.GetString("GEOEllipseInitializeError");
            /// <summary>
            /// 未初始化椭球对象。
            /// </summary>
            public static string EllipseNull = rm.GetString("EllipseNull");
            /// <summary>
            /// 未设置椭球类型。
            /// </summary>
            public static string EllipseNotSet = rm.GetString("EllipseNotSet");
            /// <summary>
            /// 未知的椭球类型。
            /// </summary>
            public static string EllipseUnknown = rm.GetString("EllipseUnknown");
            /// <summary>
            /// 设置椭球类型失败。
            /// </summary>
            public static string SetEllipseTypeFailed = rm.GetString("SetEllipseTypeFailed");
            /// <summary>
            /// 将椭球保存到XML结构失败。
            /// </summary>
            public static string SaveToXmlFailed = rm.GetString("GEOEllipseSaveToXmlFailed");
        }

        /// <summary>
        /// 高斯坐标对象错误。
        /// </summary>
        public static class GaussCoord
        {
            /// <summary>
            /// 高斯坐标初始化失败。
            /// </summary>
            public static string InitializeError = rm.GetString("GaussCoordInitializeError");
            /// <summary>
            /// 未初始化高斯坐标。
            /// </summary>
            public static string GaussNull = rm.GetString("GaussNull");
            /// <summary>
            /// 计算中央经线失败。
            /// </summary>
            public static string GetCenterFailed = rm.GetString("GetCenterFailed");
            /// <summary>
            /// 设置中央经线失败。
            /// </summary>
            public static string SetCenterFailed = rm.GetString("SetCenterFailed");
            /// <summary>
            /// 用于初始化的两个高斯坐标拥有同样的分带类型。
            /// </summary>
            public static string SameZoneType = rm.GetString("SameZoneType");
            /// <summary>
            /// 设置高斯坐标带号失败。
            /// </summary>
            public static string SetZoneFailed = rm.GetString("SetZoneFailed");
            /// <summary>
            /// 高斯反算失败。
            /// </summary>
            public static string GaussReverseFailed = rm.GetString("GaussReverseFailed");
            /// <summary>
            /// 将高斯坐标保存到XML结构失败。
            /// </summary>
            public static string SaveToXmlFailed = rm.GetString("GaussCoordSaveToXmlFailed");
        }

        /// <summary>
        /// 通用错误。
        /// </summary>
        public static class Generic
        {
            /// <summary>
            /// 传入了未知的参数。
            /// </summary>
            public static string ArgumentUnknown = rm.GetString("ArgumentUnknown");
            /// <summary>
            /// 转换操作失败。
            /// </summary>
            public static string ConvertOperationFailed = rm.GetString("ConvertOperationFailed");
            /// <summary>
            /// 操作被用户取消。
            /// </summary>
            public static string OpertionCanceledByUser = rm.GetString("OperationCanceledByUser");
            /// <summary>
            /// 该功能暂未实现。
            /// </summary>
            public static string FunctionNotImplemented = rm.GetString("FunctionNotImplemented");
            /// <summary>
            /// 指定的文件夹不存在。
            /// </summary>
            public static string DirectoryNotFound = rm.GetString("DirectoryNotFound");
            /// <summary>
            /// 指定的文件不存在。
            /// </summary>
            public static string FileNotFound = rm.GetString("FileNotFound");

            /// <summary>
            /// 绑定事件失败。
            /// </summary>
            public static string BindEventFailed = rm.GetString("BindEventFailed");
        }

        /// <summary>
        /// 分带错误。
        /// </summary>
        public static class GEOZone
        {
            /// <summary>
            /// 未设置分带类型。
            /// </summary>
            public static string ZoneTypeNotSet = rm.GetString("ZoneTypeNotSet");
            /// <summary>
            /// 未知的分带类型。
            /// </summary>
            public static string ZoneTypeUnknown = rm.GetString("ZoneTypeUnknown");
        }

        /// <summary>
        /// 换带错误。
        /// </summary>
        public static class ZoneConvert
        {
            /// <summary>
            /// 换带初始化失败。
            /// </summary>
            public static string InitializeError = rm.GetString("ZoneConvertInitializeError");
            /// <summary>
            /// 换带操作失败。
            /// </summary>
            public static string ZoneConvertFailed = rm.GetString("ZoneConvertFailed");
            /// <summary>
            /// 从3度带转换到6度带失败。
            /// </summary>
            public static string Convert3To6Failed = rm.GetString("Convert3To6Failed");
            /// <summary>
            /// 从6度带转换到3度带失败。
            /// </summary>
            public static string Convert6To3Failed = rm.GetString("Convert6To3Failed");
            /// <summary>
            /// 将换带对象保存到XML结构失败。
            /// </summary>
            public static string SaveToXmlFailed = rm.GetString("ZoneConvertSaveToXmlFailed");
        }
    }

    /// <summary>
    /// 提示信息。
    /// </summary>
    public static class Hints
    {
        public static ResourceManager rm = new ResourceManager(Constants.ResourceSpace, Assembly.GetExecutingAssembly());

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
        public static ResourceManager rm = new ResourceManager(Constants.ResourceSpace, Assembly.GetExecutingAssembly());

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
