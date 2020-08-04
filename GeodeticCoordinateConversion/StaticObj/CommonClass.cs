using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 提示值改变事件参数。
    /// </summary>
    public class HintChangedEventArgs : EventArgs
    {
        public object OldValue { get; }
        public object NewValue { get; }
        public EventArgs InnerArg { get; }

        /// <summary>
        /// 默认初始化。
        /// </summary>
        /// <param name="innerArg">内部事件参数。</param>
        public HintChangedEventArgs(EventArgs innerArg = null)
        {
            this.OldValue = null;
            this.NewValue = null;
            this.InnerArg = innerArg;
        }

        /// <summary>
        /// 通过提示值改变类型、旧值和新值初始化。
        /// </summary>
        /// <param name="oldValue">旧值。</param>
        /// <param name="newValue">新值。</param>
        /// <param name="innerArg">内部事件参数。</param>
        public HintChangedEventArgs(object oldValue, object newValue, EventArgs innerArg = null)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.InnerArg = innerArg;
        }
    }


    /// <summary>
    /// 绑定事件失败。
    /// </summary>
    [Serializable]
    public class EventBindException : Exception
    {
        public EventBindException() { }
        public EventBindException(string message) : base(message) { }
        public EventBindException(string message, Exception inner) : base(message, inner) { }
        protected EventBindException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// 初始化失败。
    /// </summary>
    [Serializable]
    public class InitializeException : Exception
    {
        public InitializeException() { }
        public InitializeException(string message) : base(message) { }
        public InitializeException(string message, Exception inner) : base(message, inner) { }
        protected InitializeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// 从XML结构初始化失败。
    /// </summary>
    [Serializable]
    public class InitializeFromXmlException : Exception
    {
        public InitializeFromXmlException() { }
        public InitializeFromXmlException(string message) : base(message) { }
        public InitializeFromXmlException(string message, Exception inner) : base(message, inner) { }
        protected InitializeFromXmlException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
