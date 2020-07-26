using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    public class GEOCoord
    {
        /// <summary>
        /// 全局唯一ID。
        /// </summary>
        public readonly Guid guid;
        /// <summary>
        /// x坐标（私有）。
        /// </summary>
        private double x;
        /// <summary>
        /// y坐标（私有）。
        /// </summary>
        private double y;
        /// <summary>
        /// 分带类型（私有）。
        /// </summary>
        private GEOZoneType zoneType;
        /// <summary>
        /// 带号（私有）。
        /// </summary>
        private int zone;
        /// <summary>
        /// 中央经线（私有）。
        /// </summary>
        private double center;
    }
}
