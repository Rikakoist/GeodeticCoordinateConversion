using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Data;

namespace GeodeticCoordinateConversion
{
    class IO
    {
        //获取当前时间
        internal static string DT()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        //从文件读取点位信息
        internal static double[,] LoadFromCSV(string FileName)
        {

            //获取文本
            string Thoroughly = File.ReadAllText(FileName);

            //拆分文本至行
            Thoroughly = Thoroughly.Replace('\n', '\r');
            string[] Lines = Thoroughly.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            //统计行列数
            int RowCount = Lines.Length;
            int ColCount = Lines[0].Split(',').Length;

            //根据行列数建立新数组
            double[,] TempArray = new double[RowCount, ColCount];

            //将文本填充进数组
            for (int Row = 0; Row < RowCount; Row++)
            {
                string[] ArrayLine = Lines[Row].Split(',');
                for (int Col = 0; Col < ColCount; Col++)
                {
                    TempArray[Row, Col] = Convert.ToDouble(ArrayLine[Col]);
                }
            }
            return TempArray;
        }

        #region 数据文件读写
        //从文件读取Tab1信息
        internal static List<Tab1File> Tab1LoadFromFile(string FilePath)
        {
            List<Tab1File> Result = new List<Tab1File>();
            //新建XmlDocument对象，并从指定路径加载文件
            XmlDocument XD = new XmlDocument();
            XD.Load(FilePath);

            using (FileStream FS = new FileStream(FilePath, FileMode.Open))
            {
                XmlNodeList XNL = XD.GetElementsByTagName("Tab1");
                if (XNL.Count < 1)
                {
                    
                }
                else
                {
                    Result.Clear();
                    //从列表中逐点添加
                    for (int i = 0; i < XNL.Count; i++)
                    {
                        Result.Add(new Tab1File()
                        {
                            Tab1FileBL = new BL
                            {
                                B = new DMS
                                {
                                    D = Convert.ToDouble(XNL[i].ChildNodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].Value),
                                    M = Convert.ToDouble(XNL[i].ChildNodes[0].ChildNodes[0].ChildNodes[1].ChildNodes[0].Value),
                                    S = Convert.ToDouble(XNL[i].ChildNodes[0].ChildNodes[0].ChildNodes[2].ChildNodes[0].Value),
                                },
                                L = new DMS
                                {
                                    D = Convert.ToDouble(XNL[i].ChildNodes[0].ChildNodes[1].ChildNodes[0].ChildNodes[0].Value),
                                    M = Convert.ToDouble(XNL[i].ChildNodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[0].Value),
                                    S = Convert.ToDouble(XNL[i].ChildNodes[0].ChildNodes[1].ChildNodes[2].ChildNodes[0].Value),
                                },
                            },
                            Tab1FileGC = new GaussCoord
                            {
                                x = Convert.ToDouble(XNL[i].ChildNodes[1].ChildNodes[0].ChildNodes[0].Value),
                                y = Convert.ToDouble(XNL[i].ChildNodes[1].ChildNodes[1].ChildNodes[0].Value),
                                ZoneType = (GEOZoneType)Convert.ToInt32(XNL[i].ChildNodes[1].ChildNodes[2].ChildNodes[0].Value),
                                Zone = Convert.ToInt32(XNL[i].ChildNodes[1].ChildNodes[3].ChildNodes[0].Value),
                            },
                        });
                    }
                }
            }
            return Result;
        }

        //保存Tab1信息到文件
        internal static void Tab1SaveToFile(string FilePath, List<Tab1File> T1F)
        {
            try
            {
                Stream XmlStream = new MemoryStream();
                using (XmlTextWriter xw = new XmlTextWriter(FilePath, Encoding.UTF8) { Formatting = Formatting.Indented })
                {
                    xw.WriteStartDocument(true);    //书写XML声明

                    //书写XML注释
                    xw.WriteComment("本文件存储地理经纬度与高斯坐标转换结果。");
                    xw.WriteComment("保存时间" + DT());

                    xw.WriteStartElement("Root");   //书写根节点

                    //对XML文件逐节点写入
                    for (int i = 0; i < T1F.Count; i++)
                    {
                        xw.WriteStartElement("Tab1");
                        xw.WriteStartElement("Geo");
                            xw.WriteStartElement("B");
                                xw.WriteElementString("D", Convert.ToString(T1F[i].Tab1FileBL.B.D));
                                xw.WriteElementString("M", Convert.ToString(T1F[i].Tab1FileBL.B.M));
                                xw.WriteElementString("S", Convert.ToString(T1F[i].Tab1FileBL.B.S));
                            xw.WriteEndElement();
                            xw.WriteStartElement("L");
                                xw.WriteElementString("D", Convert.ToString(T1F[i].Tab1FileBL.L.D));
                                xw.WriteElementString("M", Convert.ToString(T1F[i].Tab1FileBL.L.M));
                                xw.WriteElementString("S", Convert.ToString(T1F[i].Tab1FileBL.L.S));
                            xw.WriteEndElement();
                        xw.WriteEndElement();
                        xw.WriteStartElement("Gauss");
                            xw.WriteElementString("X", Convert.ToString(T1F[i].Tab1FileGC.x));
                            xw.WriteElementString("Y", Convert.ToString(T1F[i].Tab1FileGC.y));
                            xw.WriteElementString("Type", Convert.ToString((int)(T1F[i].Tab1FileGC.ZoneType)));
                            xw.WriteElementString("Zone", Convert.ToString(T1F[i].Tab1FileGC.Zone));
                        xw.WriteEndElement();
                        xw.WriteEndElement();
                    }
                    xw.WriteEndElement();
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.Message);
            }
        }

        //从文件读取Tab2信息
        internal static List<Tab2File> Tab2LoadFromFile(string FilePath)
        {
            List<Tab2File> Result = new List<Tab2File>();
            //新建XmlDocument对象，并从指定路径加载文件
            XmlDocument XD = new XmlDocument();
            XD.Load(FilePath);

            using (FileStream FS = new FileStream(FilePath, FileMode.Open))
            {
                XmlNodeList XNL = XD.GetElementsByTagName("Tab2");
                if (XNL.Count < 1)
                {

                }
                else
                {
                    Result.Clear();
                    //从列表中逐点添加
                    for (int i = 0; i < XNL.Count; i++)
                    {
                        Result.Add(new Tab2File()
                        {
                           Six = new GaussCoord
                            {
                               x = Convert.ToDouble(XNL[i].ChildNodes[0].ChildNodes[0].ChildNodes[0].Value),
                               y = Convert.ToDouble(XNL[i].ChildNodes[0].ChildNodes[1].ChildNodes[0].Value),
                            },
                            Three = new GaussCoord
                            {
                                x = Convert.ToDouble(XNL[i].ChildNodes[1].ChildNodes[0].ChildNodes[0].Value),
                                y = Convert.ToDouble(XNL[i].ChildNodes[1].ChildNodes[1].ChildNodes[0].Value),
                            },
                        });
                    }
                }
            }
            return Result;
        }

        //保存Tab2信息到文件
        internal static void Tab2SaveToFile(string FilePath, List<Tab2File> T2F)
        {
            try
            {
                Stream XmlStream = new MemoryStream();
                using (XmlTextWriter xw = new XmlTextWriter(FilePath, Encoding.UTF8) { Formatting = Formatting.Indented })
                {
                    xw.WriteStartDocument(true);    //书写XML声明

                    //书写XML注释
                    xw.WriteComment("本文件存储高斯3°、6°带转换结果。");
                    xw.WriteComment("保存时间" + DT());

                    xw.WriteStartElement("Root");   //书写根节点

                    //对XML文件逐节点写入
                    for (int i = 0; i < T2F.Count; i++)
                    {
                        xw.WriteStartElement("Tab2");
                            xw.WriteStartElement("Six");
                                xw.WriteElementString("X", Convert.ToString(T2F[i].Six.x));
                                xw.WriteElementString("Y", Convert.ToString(T2F[i].Six.y));
                            xw.WriteEndElement();
                            xw.WriteStartElement("Three");
                                xw.WriteElementString("X", Convert.ToString(T2F[i].Three.x));
                                xw.WriteElementString("Y", Convert.ToString(T2F[i].Three.y));
                            xw.WriteEndElement();
                        xw.WriteEndElement();
                    }
                    xw.WriteEndElement();
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.Message);
            }
        }
        #endregion

        #region 配置文件读写
        //保存配置文件
        internal static void SaveSettings(string FilePath, string WorkFolder, int SelectedEllipse, bool ThreeChecked)
        {
            Stream XmlStream = new MemoryStream();
            using (XmlTextWriter xw = new XmlTextWriter(FilePath, Encoding.UTF8) { Formatting = Formatting.Indented })
            {
                xw.WriteStartDocument(true);    //书写XML声明

                //书写XML注释
                xw.WriteComment("本文件存储窗体配置信息。");
                xw.WriteComment("保存时间" + DT());

                xw.WriteStartElement("Settings");   //根节点

                //对XML文件逐节点写入
                xw.WriteElementString("WorkFolder", WorkFolder); //工作文件夹
                xw.WriteElementString("Ellipse", SelectedEllipse.ToString()); //椭球

                if(ThreeChecked)
                {
                    xw.WriteElementString("ConvertMethod", "3"); //椭球
                }
                else
                {
                    xw.WriteElementString("ConvertMethod", "6"); //椭球
                }
            }
        }

        internal static void LoadSettings(string FilePath, ref ToolStripMenuItem WorkFolder, ref ToolStripComboBox EllipseMethod, ref RadioButton Three, ref RadioButton Six)
        {
            //新建XmlDocument对象，并从指定路径加载文件
            XmlDocument XD = new XmlDocument();
            XD.Load(FilePath);

            using (FileStream FS = new FileStream(FilePath, FileMode.Open))
            {
                //工作文件夹
                XmlNodeList XNL = XD.GetElementsByTagName("WorkFolder");
                if (XNL.Count == 1)
                {
                    WorkFolder.Text = XNL[0].ChildNodes[0].Value;
                }

                //椭球
                XNL = XD.GetElementsByTagName("Ellipse");
                if (XNL.Count == 1)
                {
                    EllipseMethod.SelectedIndex = Convert.ToInt32(XNL[0].ChildNodes[0].Value);
                }

                XNL = XD.GetElementsByTagName("ConvertMethod");
                if (XNL.Count == 1)
                {
                    if (Convert.ToInt32(XNL[0].ChildNodes[0].Value) == 3)
                    {
                        Three.Checked = true;
                        Six.Checked = false;
                    }
                    else if (Convert.ToInt32(XNL[0].ChildNodes[0].Value) == 6)
                    {
                        Three.Checked = false;
                        Six.Checked = true;
                    }
                    else
                    {
                        throw new Exception("分带未知。");
                    }
                }
            }
        }
        #endregion

    }
}
