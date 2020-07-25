using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    public static class NodeInfo
    {
        /// <summary>
        /// XML版本。
        /// </summary>
        public const string XmlVersion = "1.0";
        /// <summary>
        /// XML编码。
        /// </summary>
        public const string XmlEncode = "utf-8";
        /// <summary>
        /// 独立XML。
        /// </summary>
        public const string XmlStandalone = "yes";

        /// <summary>
        /// 根节点名称。
        /// </summary>
        public const string RootNode = "root";

        /// <summary>
        /// 时间节点。
        /// </summary>
        public const string TimeNode = "Time";
        /// <summary>
        /// 时间节点路径。
        /// </summary>
        public const string TimeNodePath = "./" + TimeNode;
        /// <summary>
        /// 最后更改属性。
        /// </summary>
        public const string LastModifiedAttr = "LastModified";

        public const string BLNode = "Geo";
        public const string BLNodePath = "./" + BLNode;
        public const string BNode = "B";
        public const string BNodePath = "./" + BNode;
        public const string LNode = "L";
        public const string LNodePath = "./" + LNode;
        public const string GaussNode = "Gauss";
        public const string GaussNodePath = "./" + GaussNode;
        public const string Gauss3Node = "GaussThree";
        public const string Gauss3NodePath = "./" + Gauss3Node;
        public const string Gauss6Node = "GaussSix";
        public const string Gauss6NodePath = "./" + Gauss6Node;
        public const string EllipseNode = "Ellipse";
        public const string EllipseNodePath = "./" + EllipseNode;

        public const string Tab1Node = "Tab1";
        public const string Tab1NodePath = "./" + Tab1Node;
        public const string Tab2Node = "Tab2";
        public const string Tab2NodePath = "./" + Tab2Node;
    }
}
