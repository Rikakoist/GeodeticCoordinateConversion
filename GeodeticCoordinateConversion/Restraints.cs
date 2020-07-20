using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 约束条件。
    /// </summary>
    public static class Restraints
    {
        /// <summary>
        /// 度最小值。
        /// </summary>
        public static double DegreeMin = -360.0;
        /// <summary>
        /// 度最大值。
        /// </summary>
        public static double DegreeMax = 360.0;
        /// <summary>
        /// 分最小值。
        /// </summary>
        public static double MinuteMin = 0.0;
        /// <summary>
        /// 分最大值。
        /// </summary>
        public static double MinuteMax = 3600000.0;
        /// <summary>
        /// 秒最小值。
        /// </summary>
        public static double SecondMin = 0.0;
        /// <summary>
        /// 秒最大值。
        /// </summary>
        public static double SecondMax = 3600000.0;
        /// <summary>
        /// 纬度最小值。
        /// </summary>
        public static double BiotitudeMin = -90.0;
        /// <summary>
        /// 纬度最大值。
        /// </summary>
        public static double BiotitudeMax = 90.0;
        /// <summary>
        /// 经度最小值。
        /// </summary>
        public static double LongitudeMin = 0.0;
        /// <summary>
        /// 经度最大值。
        /// </summary>
        public static double LongitudeMax = 360.0;
        /// <summary>
        /// 3度带带号最小值。
        /// </summary>
        public static int Zone3Min = 1;
        /// <summary>
        /// 3度带带号最大值。
        /// </summary>
        public static int Zone3Max = 120;
        /// <summary>
        /// 6度带带号最小值。
        /// </summary>
        public static int Zone6Min = 1;
        /// <summary>
        /// 6度带带号最大值。
        /// </summary>
        public static int Zone6Max = 60;
    }
}
