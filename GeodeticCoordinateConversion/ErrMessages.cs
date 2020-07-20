using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 错误讯息。
    /// </summary>
    public static class ErrMessages
    {
        /// <summary>
        /// 传入了未知的参数。
        /// </summary>
        public static string ArgumentUnknown = "传入了未知的参数。";
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
        /// 未设置分带类型。
        /// </summary>
        public static string ZoneTypeNotSet = "未设置分带类型。";
        /// <summary>
        /// 3度带带号超限。
        /// </summary>
        public static string Zone3OutOfRange = "3度分带带号应介于" + Restraints.Zone3Min.ToString() + " - " + Restraints.Zone3Max.ToString() + " 间。";
        /// <summary>
        /// 6度带带号超限。
        /// </summary>
        public static string Zone6OutOfRange = "6度分带带号应介于" + Restraints.Zone6Min.ToString() + " - " + Restraints.Zone6Max.ToString() + " 间。";
    }
}
