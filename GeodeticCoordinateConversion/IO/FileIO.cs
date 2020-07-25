using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GeodeticCoordinateConversion
{
    class FileIO
    {
        /// <summary>
        /// XML文档路径。
        /// </summary>
        public string docPath;

        /// <summary>
        /// XML文档对象。
        /// </summary>
        private XmlDocument document;
        /// <summary>
        /// 根节点。
        /// </summary>
        private XmlNode rootNode;

        public delegate void DocumentModifiedEventHander(object sender, EventArgs e);
        public event DocumentModifiedEventHander DocumentModified;

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="ConfigFilePath">配置文件的路径。</param>
        public FileIO(string ConfigFilePath)
        {
            try
            {
                docPath = ConfigFilePath;
                //若指定的配置文件路径不存在
                if (!File.Exists(docPath))
                {
                    //若无法创建配置文件
                    if (!CreateConfig())
                    {
                        throw new FileNotFoundException("指定的配置文件\"" + ConfigFilePath + "\"不存在，且无法创建。");
                    }
                    else
                    {
                        this.DocumentModified?.Invoke(this, null);
                    }
                }

                document = new XmlDocument();
                document.Load(ConfigFilePath);
                rootNode = document.SelectSingleNode("/root");
                if (rootNode == null)
                {
                    throw new KeyNotFoundException("加载配置文件\"" + ConfigFilePath + "\"根节点失败。");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, ErrMessage.ErrSpecifyingDataFile, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 创建空的配置文件。
        /// </summary>
        /// <returns>操作结果。</returns>
        private bool CreateConfig()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                XmlNode xmlNode = document.CreateXmlDeclaration(NodeInfo.XmlVersion, NodeInfo.XmlEncode, NodeInfo.XmlStandalone);
                document.AppendChild(xmlNode);
                XmlNode rootNode = document.CreateElement(NodeInfo.RootNode);
                document.AppendChild(rootNode);
                CreateTimeNode();
                document.Save(docPath);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        /// <summary>
        /// 创建最后修改时间节点。
        /// </summary>
        /// <returns>操作结果。</returns>
        private bool CreateTimeNode()
        {
            XmlNode modi = document.CreateElement(NodeInfo.TimeNode);
            ((XmlElement)modi).SetAttribute(NodeInfo.LastModifiedAttr, CommonText.LastModified + CommonText.Now);
            rootNode.AppendChild(modi);
            return true;
        }

        /// <summary>
        /// 更改最后修改时间。
        /// </summary>
        /// <returns>操作结果。</returns>
        private bool ModifyTime()
        {
            try
            {
                XmlNode modi = rootNode.SelectSingleNode(NodeInfo.TimeNodePath);
                ((XmlElement)modi).SetAttribute(NodeInfo.LastModifiedAttr, CommonText.LastModified + CommonText.Now);
                document.Save(docPath);
                return true;
            }
            catch (Exception err)
            {
                CreateTimeNode();
                return false;
            }
            finally
            {
                this.DocumentModified?.Invoke(this, null);
            }
        }

        public bool Tab1SaveToFile(List<Tab1File> T1F)
        {
            for (int i = 0; i < T1F.Count; i++)
            {
                XmlElement tabNode = document.CreateElement(NodeInfo.Tab1Node);

                tabNode.AppendChild(T1F[i].Tab1FileBL.ToXmlElement(document));
                tabNode.AppendChild(T1F[i].Tab1FileGC.ToXmlElement(document));

                rootNode.AppendChild(tabNode);
            }
            document.Save(docPath);
            ModifyTime();
            return true;
        }

        public List<Tab1File> Tab1LoadFromFile()
        {
            List<Tab1File> Result = new List<Tab1File>();
            Result.Clear();
            XmlNodeList XNL = rootNode.SelectNodes(NodeInfo.Tab1NodePath);
            if (XNL.Count < 1)
            {

            }
            else
            {
                for (int i = 0; i < XNL.Count; i++)
                {
                    Result.Add(new Tab1File(XNL[i]));
                }
            }
            return Result;
        }

        public bool Tab2SaveToFile(List<Tab2File> T2F)
        {
            for (int i = 0; i < T2F.Count; i++)
            {
                XmlElement tabNode = document.CreateElement(NodeInfo.Tab2Node);

                tabNode.AppendChild(T2F[i].Six.ToXmlElement(document, NodeInfo.Gauss6Node));
                tabNode.AppendChild(T2F[i].Three.ToXmlElement(document, NodeInfo.Gauss3Node));

                rootNode.AppendChild(tabNode);
            }
            document.Save(docPath);
            ModifyTime();
            return true;
        }

        public List<Tab2File> Tab2LoadFromFile()
        {
            List<Tab2File> Result = new List<Tab2File>();
            Result.Clear();
            XmlNodeList XNL = rootNode.SelectNodes(NodeInfo.Tab2NodePath);
            if (XNL.Count < 1)
            {

            }
            else
            {
                for (int i = 0; i < XNL.Count; i++)
                {
                    Result.Add(new Tab2File(XNL[i]));
                }
            }
            return Result;
        }
    }
}
