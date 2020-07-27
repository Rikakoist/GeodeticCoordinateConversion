using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
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
