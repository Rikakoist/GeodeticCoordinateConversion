using GeodeticCoordinateConversion.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 错误信息。
    /// </summary>
    public static class ErrMessage
    {
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
        /// <summary>
        /// 已将6°带转换到3°带。
        /// </summary>
        public static string Zone6To3Success = "已将6°带转换到3°带。";
        /// <summary>
        /// 已将3°带转换到6°带。
        /// </summary>
        public static string Zone3To6Success = "已将3°带转换到6°带。";

        public static string TableListLoaded(int TableCount)
        {
            return "在数据库 " + new Settings().DBName + " 中找到 " + TableCount + " 张表。";
        }

        public static string TableRecordCount(string TableName, int? RecordCount)
        {
            return TableName+" 表中有 " + RecordCount + " 条记录。";
        }

        public static string TableReloaded(string TableName)
        {
            return "已从数据库 " + new Settings().DBName + " 重载表 " + TableName;
        }

        public static string RowAdded()
        {
            return "添加了1条新的记录。";
        }

        public static string RowDeleted(int row)
        {
            return "删除了"+row+"条记录。";
        }
    }

    /// <summary>
    /// 文本。
    /// </summary>
    public static class CommonText
    {
        /// <summary>
        /// 当前时间。
        /// </summary>
        public static string Now = DateTime.Now.ToString("yyyyMMddHHmmss");
        /// <summary>
        /// 最后编辑于。
        /// </summary>
        public static string LastModified = "最后编辑于";
        /// <summary>
        /// 获取问候语。
        /// </summary>
        /// <returns>按照小时决定返回的问候语。</returns>
        public static string Greet()
        {
            int h = DateTime.Now.Hour;
            string pref = "你好，";
            string suff = "。";
            switch (h)
            {
                case 23:
                case 0:
                case 1:
                    {
                        pref = "夜深了，";
                        break;
                    }
                case 2:
                case 3:
                case 4:
                    {
                        pref = "夜猫子";
                        suff = "，你好。";
                        break;
                    }
                case 5:
                case 6:
                case 7:
                    {
                        pref = "早上好，";
                        break;
                    }
                case 8:
                case 9:
                case 10:
                    {
                        pref = "上午好，";
                        break;
                    }
                case 11:
                case 12:
                case 13:
                    {
                        pref = "中午好，";
                        break;
                    }
                case 14:
                case 15:
                case 16:
                case 17:
                    {
                        pref = "下午好，";
                        break;
                    }
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                    {
                        pref = "晚上好，";
                        break;
                    }
                default:
                    {
                        pref = "哈喽，";
                        break;
                    }
            }
            return pref + Environment.UserName + suff;
        }
    }
}
