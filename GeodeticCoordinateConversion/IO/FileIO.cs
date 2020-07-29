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
        /// 配置文件。
        /// </summary>
        private GEOSettings AppSettings = new GEOSettings();

        /// <summary>
        /// XML文档路径（私有）。
        /// </summary>
        private string docPath;
        /// <summary>
        /// XML文档对象。
        /// </summary>
        private XmlDocument document;
        /// <summary>
        /// 根节点。
        /// </summary>
        private XmlNode rootNode;

        /// <summary>
        /// XML文档路径。
        /// </summary>
        public string DocPath
        {
            get => docPath;
            set
            {
                try
                {
                    if (!Directory.Exists(value))
                        throw new DirectoryNotFoundException(ErrMessage.Generic.DirectoryNotFound);
                    docPath = Path.Combine(value, AppSettings.DataFileName);
                    CheckDataFileExists();
                    this.DocPathChanged?.Invoke(this, null);
                    InitDoc();
                }
                catch (Exception err)
                {
                    throw new DocPathException(ErrMessage.DataFile.SetDocPathFailed, err);
                }
            }
        }

        public FileIO()
        {
            this.DocPath = AppSettings.WorkFolder;
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="ConfigFilePath">配置文件的路径。</param>
        public FileIO(string ConfigFilePath)
        {
            try
            {
                DocPath = ConfigFilePath;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, ErrMessage.Data.ErrSpecifyingDataFile, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public delegate void DocPathChangedEventHander(object sender, EventArgs e);
        public event DocPathChangedEventHander DocPathChanged;
        public delegate void DocModifiedEventHander(object sender, EventArgs e);
        public event DocModifiedEventHander DocModified;

        /// <summary>
        /// 检查配置文件是否存在。
        /// </summary>
        /// <returns>操作结果。</returns>
        private void CheckDataFileExists()
        {
            if (!File.Exists(DocPath))
            {
                document = new XmlDocument();
                XmlNode xmlNode = document.CreateXmlDeclaration(NodeInfo.XmlVersion, NodeInfo.XmlEncode, NodeInfo.XmlStandalone);
                document.AppendChild(xmlNode);
                rootNode = document.CreateElement(NodeInfo.RootNode);
                document.AppendChild(rootNode);
                CreateTimeNode();
                document.Save(DocPath);
                this.DocModified?.Invoke(this, null);
            }
        }

        /// <summary>
        /// 初始化文档。
        /// </summary>
        private void InitDoc()
        {
            document = new XmlDocument();
            document.Load(DocPath);
            rootNode = document.SelectSingleNode("/root");
            if (rootNode == null)
            {
                throw new KeyNotFoundException("加载配置文件\"" + DocPath + "\"根节点失败。");
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
                document.Save(DocPath);
                return true;
            }
            catch (Exception)
            {
                CreateTimeNode();
                return false;
            }
            finally
            {
                this.DocModified?.Invoke(this, null);
            }
        }

        public bool SaveCoordConvertData(List<CoordConvert> Data)
        {
            foreach(CoordConvert c in Data)
            {
                rootNode.AppendChild(c.ToXmlElement(document));
            }
            document.Save(DocPath);
            ModifyTime();
            return true;
        }

        public List<CoordConvert> LoadCoordConvertData()
        {
            List<CoordConvert> Data = new List<CoordConvert>();
            Data.Clear();
            XmlNodeList XNL = rootNode.SelectNodes(NodeInfo.CoordConvertNodePath);
            if (XNL.Count >= 1)
            {
                
                foreach(XmlNode x in XNL)
                {
                    Data.Add(new CoordConvert(x));
                }
                //return true;
            }
            return Data; 
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
            document.Save(DocPath);
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

        /// <summary>
        /// 配置文件路径异常。
        /// </summary>
        [Serializable]
        public class DocPathException : Exception
        {
            public DocPathException() { }
            public DocPathException(string message) : base(message) { }
            public DocPathException(string message, Exception inner) : base(message, inner) { }
            protected DocPathException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
