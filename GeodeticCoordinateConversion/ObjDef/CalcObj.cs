using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    public class CalcObj
    {
        public bool Selected = true;    
        /// <summary>
        /// 脏数据。
        /// </summary>
        [DisplayName("脏数据")]
        public bool Dirty { get; protected set; } = false;
        /// <summary>
        /// 已计算。
        /// </summary>
        [DisplayName("已计算")]
        public bool Calculated { get; protected set; } = false;
        /// <summary>
        /// 计算错误。
        /// </summary>
        [DisplayName("计算错误")]
        public bool Error { get; protected set; } = false;
    }
}
