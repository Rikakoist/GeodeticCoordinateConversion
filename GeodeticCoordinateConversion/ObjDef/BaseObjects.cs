using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// UID类。
    /// </summary>
    public class UIDClass
    {
        /// <summary>
        /// 全局唯一ID。
        /// </summary>
        public Guid UID { get; protected set; } = Guid.NewGuid();
    }
    /// <summary>
    /// 用户控件使用的用于指示数据状态的基类。
    /// </summary>
    public class DataStatus:UIDClass
    {
        /// <summary>
        /// 是否选中。
        /// </summary>
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
