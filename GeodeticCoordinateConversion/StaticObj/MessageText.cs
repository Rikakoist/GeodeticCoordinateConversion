using System;
using System.Collections.Generic;
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
        /// 椭球错误。
        /// </summary>
        public static class GEOEllipse
        {
            /// <summary>
            /// 未初始化椭球。
            /// </summary>
            public static string EllipseNull = "未初始化椭球。";
            /// <summary>
            /// 未设置椭球类型。
            /// </summary>
            public static string EllipseNotSet = "未设置椭球类型。";
            /// <summary>
            /// 未知的椭球类型。
            /// </summary>
            public static string EllipseUnknown = "未知的椭球类型。";
        }

        /// <summary>
        /// 高斯坐标错误。
        /// </summary>
        public static class GaussCoord
        {
            /// <summary>
            /// 未初始化高斯坐标。
            /// </summary>
            public static string GaussNull = "未初始化高斯坐标。";
            /// <summary>
            /// 用于初始化的两个高斯坐标拥有同样的分带类型。
            /// </summary>
            public static string SameZoneType = "用于初始化的两个高斯坐标拥有同样的分带类型。";
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
        public static string LastModified = "最后编辑于：";
    }
}
