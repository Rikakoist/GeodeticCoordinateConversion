using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GeodeticCoordinateConversion.Deprecated;
using GeodeticCoordinateConversion.Properties;

namespace GeodeticCoordinateConversion.Deprecated
{
    public partial class MainForm : Form
    {
        List<GaussCoord> Tab1GC = new List<GaussCoord>();
        List<GaussCoord> Tab23GC = new List<GaussCoord>();
        List<GaussCoord> Tab26GC = new List<GaussCoord>();
        List<GEOBL> Tab1DMS = new List<GEOBL>();
        List<GEOBL> Tab2DMS = new List<GEOBL>();
        List<Tab1File> T1F = new List<Tab1File>();
        List<Tab2File> T2F = new List<Tab2File>();
        Ellipse E = new Ellipse(0);
        FileIO dataFile = new FileIO();
        DBIO dbFile = new DBIO();
        Settings AppSettings = new Settings();

        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitApp(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region 数据框操作
        private void ClearDataGridView(object sender, EventArgs e)
        {
            try
            {
                if (sender == ClearTab1InputDataGridView)
                {
                    Tab1InputDataGridView.Rows.Clear();
                    Hint.Text = "成功地清空了页面1中的数据框。";
                }

                if (sender == ClearTab2InputDataGridView)
                {
                    Tab2InputDataGridView.Rows.Clear();
                    Hint.Text = "成功地清空了页面2中的数据框。";
                }

                if (sender == ClearBL)
                {
                    for (int i = 0; i < Tab1InputDataGridView.Rows.Count - 1; i++)
                    {
                        Tab1InputDataGridView[0, i].Value = "";
                        Tab1InputDataGridView[1, i].Value = "";
                    }
                    Hint.Text = "成功地清除了已输入的经纬度坐标。";
                }

                if (sender == ClearXY)
                {
                    for (int i = 0; i < Tab1InputDataGridView.Rows.Count - 1; i++)
                    {
                        for (int j = 3; j <= 6; j++)
                        {
                            Tab1InputDataGridView[j, i].Value = "";
                            Tab1InputDataGridView[j, i].Value = "";
                        }
                    }
                    Hint.Text = "成功地清除了已输入的高斯投影坐标。";
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        //删除行
        private void DelRow(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    if (sender == Tab1InputDataGridView && e.RowIndex < Tab1InputDataGridView.Rows.Count - 1)
                    {
                        Tab1InputDataGridView.Rows.RemoveAt(e.RowIndex);
                        Hint.Text = "成功地删除了页面1数据框中的第" + (e.RowIndex + 1).ToString() + "行的数据。";
                    }
                    if (sender == Tab2InputDataGridView && e.RowIndex < Tab2InputDataGridView.Rows.Count - 1)
                    {
                        Tab2InputDataGridView.Rows.RemoveAt(e.RowIndex);
                        Hint.Text = "成功地删除了页面2数据框中的第" + (e.RowIndex + 1).ToString() + "行的数据。";
                    }
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        //转移换算结果至换带窗口
        private void GaussMove(object sender, EventArgs e)
        {
            try
            {
                if (Tab1InputDataGridView.Rows.Count > 1)
                {
                    Tab1GC.Clear();
                    for (int i = 0; i < Tab1InputDataGridView.Rows.Count - 1; i++)
                    {
                        Tab1GC.Add(new GaussCoord
                        {
                            X = Convert.ToDouble(Tab1InputDataGridView[3, i].Value),
                            Y = Convert.ToDouble(Tab1InputDataGridView[4, i].Value) - 500000, //-500km读取

                            ZoneType = (GEOZoneType)Convert.ToInt32(Tab1InputDataGridView[5, i].Value),
                            Zone = Convert.ToInt32(Tab1InputDataGridView[6, i].Value),
                        });
                    }
                    Tab2InputDataGridView.Rows.Clear();
                    for (int i = 0; i < Tab1GC.Count(); i++)
                    {
                        Tab2InputDataGridView.Rows.Add();
                        switch (Tab1GC[0].ZoneType)
                        {
                            case GEOZoneType.Zone3:
                                {
                                    Tab2InputDataGridView[3, i].Value = Tab1GC[i].X.ToString();
                                    Tab2InputDataGridView[4, i].Value = Tab1GC[i].Zone.ToString() + (Tab1GC[i].Y + 500000).ToString();
                                    break;
                                }
                            case GEOZoneType.Zone6:
                                {
                                    Tab2InputDataGridView[0, i].Value = Tab1GC[i].X.ToString();
                                    Tab2InputDataGridView[1, i].Value = Tab1GC[i].Zone.ToString() + (Tab1GC[i].Y + 500000).ToString();
                                    break;
                                }
                            default:
                                {
                                    throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeUnknown);
                                }
                        }
                    }
                    MainTabControl.SelectedIndex = 1;
                    Hint.Text = "已将坐标转换结果转移到换带数据框中。";
                }
                else
                {
                    throw new Exception(ErrMessage.Data.EmptyDataGridView);
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
                Hint.Text = "上一次结果转移操作出现问题，请检查后重试！";
            }
        }
        #endregion

        #region 输入限制、提示及椭球选择
        private void InputRestrictions(object sender, KeyPressEventArgs e)
        {
            if (MainTabControl.SelectedIndex < 2)
            {
                if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '-' || e.KeyChar == '+' || e.KeyChar == '.' || (byte)(e.KeyChar) == 8 || e.KeyChar == 46)
                {
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
            }
        }

        //选择椭球
        private void ChangeEllipse(object sender, EventArgs e)
        {
            E = new Ellipse((GEOEllipseType)(EllipseMethod.SelectedIndex + 1));
            SetHint("椭球已更改为" + EllipseMethod.SelectedItem.ToString());
        }

        //设置使用提示
        internal void SetHint(string TXT)
        {
            Hint.Text = TXT;
        }

        #endregion

        #region 计算
        //坐标转换计算
        private void Tab1GeoGauss(object sender, EventArgs e)
        {
            try
            {
                if (Tab1InputDataGridView.Rows.Count > 1)
                {
                    Tab1DMS.Clear();
                    Tab1GC.Clear();

                    //经纬度转高斯投影
                    if (sender == DMSToGaussButton)
                    {
                        for (int i = 0; i < Tab1InputDataGridView.Rows.Count - 1; i++)
                        {
                            Tab1DMS.Add(new GEOBL(Tab1InputDataGridView[0, i].Value.ToString(), Tab1InputDataGridView[1, i].Value.ToString()));
                            Tab1DMS[i].GEOEllipse = E;
                            if (ThreeRadioButton.Checked)    //根据用户选择来决定转换方式（3、6）
                            {
                                Tab1DMS[i].ZoneType = GEOZoneType.Zone3;
                            }
                            else if (SixRadioButton.Checked)
                            {
                                Tab1DMS[i].ZoneType = GEOZoneType.Zone6;
                            }
                            else
                            {
                                throw new ArgumentException(ErrMessage.GEOZone.ZoneTypeNotSet);
                            }
                            Tab1GC.Add(Tab1DMS[i].GaussDirect());
                        }
                        //if (ThreeRadioButton.Checked)    //根据用户选择来决定转换方式（3、6）
                        //{
                        //    CoordConversion.GaussPrepare(E, ref Tab1GC, ref Tab1DMS, 0, 3);
                        //}
                        //else if (SixRadioButton.Checked)
                        //{
                        //    CoordConversion.GaussPrepare(E, ref Tab1GC, ref Tab1DMS, 0, 6);
                        //}
                        //else
                        //{
                        //    throw new Exception("转换到多少分带？你再说一遍？");
                        //}

                        for (int i = 0; i < Tab1GC.Count; i++)
                        {
                            Tab1InputDataGridView[3, i].Value = Tab1GC[i].X.ToString();
                            Tab1InputDataGridView[4, i].Value = (Tab1GC[i].Y + 500000).ToString();  //+500km显示
                            Tab1InputDataGridView[5, i].Value = ((int)Tab1GC[i].ZoneType).ToString();
                            Tab1InputDataGridView[6, i].Value = Tab1GC[i].Zone.ToString();
                        }
                        SetHint("成功地将经纬度坐标转换为高斯投影" + ((int)Tab1GC[0].ZoneType).ToString() + "°带坐标。");
                    }

                    //高斯投影转经纬度
                    if (sender == GaussToDMSButton)
                    {
                        for (int i = 0; i < Tab1InputDataGridView.Rows.Count - 1; i++)
                        {
                            Tab1GC.Add(new GaussCoord
                            {
                                GEOEllipse = E,
                                X = Convert.ToDouble(Tab1InputDataGridView[3, i].Value),
                                Y = Convert.ToDouble(Tab1InputDataGridView[4, i].Value) - 500000, //-500km读取
                                ZoneType = (GEOZoneType)Convert.ToInt32(Tab1InputDataGridView[5, i].Value),
                                Zone = Convert.ToInt32(Tab1InputDataGridView[6, i].Value),
                            });
                            Tab1DMS.Add(Tab1GC[i].GaussReverse());
                        }
                        //CoordConversion.GaussPrepare(E, ref Tab1GC, ref Tab1DMS, 1, 0);
                        for (int i = 0; i < Tab1DMS.Count; i++)
                        {
                            Tab1InputDataGridView[0, i].Value = GeoCalc.DMS2Str(Tab1DMS[i].B);
                            Tab1InputDataGridView[1, i].Value = GeoCalc.DMS2Str(Tab1DMS[i].L);
                        }
                        SetHint("成功地将高斯投影" + ((int)Tab1GC[0].ZoneType).ToString() + "°带坐标转换为经纬度坐标。");
                    }
                }
                else
                {
                    throw new Exception(ErrMessage.Data.EmptyDataGridView);
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
                SetHint(ErrMessage.Generic.ConvertOperationFailed);
            }
        }

        //换带计算
        private void ZoneConvert(object sender, EventArgs e)
        {
            try
            {
                if (Tab2InputDataGridView.Rows.Count > 1)
                {
                    Tab23GC.Clear();
                    Tab26GC.Clear();
                    Tab2DMS.Clear();
                    //6->3
                    if (sender == SixToThreeButton)
                    {
                        for (int i = 0; i < Tab2InputDataGridView.Rows.Count - 1; i++)
                        {
                            Tab26GC.Add(new GaussCoord
                            {
                                GEOEllipse = E,
                                X = Convert.ToDouble(Tab2InputDataGridView[0, i].Value),
                                Y = GeoCalc.GetY(Tab2InputDataGridView[1, i].Value.ToString()),
                                ZoneType = GEOZoneType.Zone6,
                                Zone = GeoCalc.GetZoneNum(Tab2InputDataGridView[1, i].Value.ToString()),
                            });
                            Tab23GC.Add((Tab26GC[i].GaussReverse()) //六度带反算
                                .GaussDirect(GEOZoneType.Zone3));   //三度带正算
                        }
                        //CoordConversion.GaussPrepare(E, ref Tab26GC, ref Tab2DMS, 1, 6);    
                        //CoordConversion.GaussPrepare(E, ref Tab23GC, ref Tab2DMS, 0, 3);   
                        for (int i = 0; i < Tab23GC.Count; i++)
                        {
                            //Tab2InputDataGridView[3, i].Value = Tab23GC[i].x.ToString();
                            Tab2InputDataGridView[3, i].Value = Tab26GC[i].X.ToString();    //转换前后X不变
                            Tab2InputDataGridView[4, i].Value = Tab23GC[i].Zone.ToString() + (Tab23GC[i].Y + 500000).ToString();
                        }
                        SetHint(Hints.Zone6To3Success);
                    }
                    //3->6
                    if (sender == ThreeToSixButton)
                    {
                        for (int i = 0; i < Tab2InputDataGridView.Rows.Count - 1; i++)
                        {
                            Tab23GC.Add(new GaussCoord
                            {
                                GEOEllipse = E,
                                X = Convert.ToDouble(Tab2InputDataGridView[3, i].Value),
                                Y = GeoCalc.GetY(Tab2InputDataGridView[4, i].Value.ToString()),
                                ZoneType = GEOZoneType.Zone3,
                                Zone = GeoCalc.GetZoneNum(Tab2InputDataGridView[4, i].Value.ToString()),
                            });
                            Tab26GC.Add(Tab23GC[i].GaussReverse()   //三度带反算
                                .GaussDirect(GEOZoneType.Zone6));   //六度带正算
                        }
                        //CoordConversion.GaussPrepare(E, ref Tab23GC, ref Tab2DMS, 1, 3);
                        //CoordConversion.GaussPrepare(E, ref Tab26GC, ref Tab2DMS, 0, 6);
                        for (int i = 0; i < Tab26GC.Count; i++)
                        {
                            //Tab2InputDataGridView[0, i].Value = Tab26GC[i].x.ToString();
                            Tab2InputDataGridView[0, i].Value = Tab23GC[i].X.ToString();    //转换前后X不变
                            Tab2InputDataGridView[1, i].Value = Tab26GC[i].Zone.ToString() + (Tab26GC[i].Y + 500000).ToString();
                        }
                        SetHint(Hints.Zone3To6Success);
                    }
                }
                else
                {
                    throw new Exception(ErrMessage.Data.EmptyDataGridView);
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
                SetHint(ErrMessage.Generic.ConvertOperationFailed);
            }
        }
        #endregion

        #region 数据管理
        //文件及数据库存取
        private void DataManagement(object sender, EventArgs e)
        {
            try
            {
                switch (MainTabControl.SelectedIndex)   //根据选定的选项卡决定目标数据框
                {
                    case 0:
                        {
                            //Tab1文件读取
                            if (sender == ReadFileToolStripMenuItem)
                            {
                                T1F.Clear();
                                Tab1InputDataGridView.Rows.Clear();

                                ////T1F = dataFile.FileToCoordConvertData();
                                //T1F = IO.Tab1LoadFromFile(WorkFolder.Text + "\\GeoConversion.xml");

                                for (int i = 0; i < T1F.Count; i++)
                                {
                                    Tab1InputDataGridView.Rows.Add();
                                    Tab1InputDataGridView[0, i].Value = GeoCalc.DMS2Str(T1F[i].Tab1FileBL.B);
                                    Tab1InputDataGridView[1, i].Value = GeoCalc.DMS2Str(T1F[i].Tab1FileBL.L);
                                    Tab1InputDataGridView[3, i].Value = T1F[i].Tab1FileGC.X.ToString();
                                    Tab1InputDataGridView[4, i].Value = T1F[i].Tab1FileGC.Y.ToString();
                                    Tab1InputDataGridView[5, i].Value = ((int)T1F[i].Tab1FileGC.ZoneType).ToString();
                                    Tab1InputDataGridView[6, i].Value = T1F[i].Tab1FileGC.Zone.ToString();
                                }
                                SetHint("成功地从文件加载" + (Tab1InputDataGridView.Rows.Count - 1).ToString() + "条坐标转换数据。");
                            }

                            //Tab1文件存储
                            if (sender == SaveFileToolStripMenuItem)
                            {
                                if (Tab1InputDataGridView.Rows.Count > 1)
                                {
                                    T1F.Clear();

                                    for (int i = 0; i < Tab1InputDataGridView.Rows.Count - 1; i++)
                                    {
                                        T1F.Add(new Tab1File()
                                        {
                                            Tab1FileBL = new GEOBL(Tab1InputDataGridView[0, i].Value.ToString(), Tab1InputDataGridView[1, i].Value.ToString())
                                            {
                                                GEOEllipse = E,
                                                ZoneType = (GEOZoneType)Convert.ToInt32(Tab1InputDataGridView[5, i].Value),
                                            },
                                            Tab1FileGC = new GaussCoord
                                            {
                                                X = Convert.ToDouble(Tab1InputDataGridView[3, i].Value),
                                                Y = Convert.ToDouble(Tab1InputDataGridView[4, i].Value),
                                                ZoneType = (GEOZoneType)Convert.ToInt32(Tab1InputDataGridView[5, i].Value),
                                                Zone = Convert.ToInt32(Tab1InputDataGridView[6, i].Value),
                                                GEOEllipse = E,
                                            },
                                        });
                                    }

                                    ////dataFile.CoordConvertDataToFile(T1F);
                                    //IO.Tab1SaveToFile(WorkFolder.Text + "\\GeoConversion.xml", T1F);
                                    SetHint("成功地将" + (Tab1InputDataGridView.Rows.Count - 1).ToString() + "条坐标转换数据存储至文件。");
                                }
                                else
                                {
                                    throw new Exception(ErrMessage.Data.EmptyDataGridView);
                                }
                            }

                            //Tab1数据库读取
                            if (sender == LoadFromDBToolStripMenuItem)
                            {
                                dbFile.ReadFromDB("CoordConvert", TmpDataGridView);
                                Tab1InputDataGridView.Rows.Clear();
                                for (int i = 0; i < TmpDataGridView.Rows.Count - 1; i++)
                                {
                                    Tab1InputDataGridView.Rows.Add();
                                    Tab1InputDataGridView[0, i].Value = TmpDataGridView[2, i].Value;
                                    Tab1InputDataGridView[1, i].Value = TmpDataGridView[3, i].Value;
                                    Tab1InputDataGridView[3, i].Value = TmpDataGridView[4, i].Value;
                                    Tab1InputDataGridView[4, i].Value = TmpDataGridView[5, i].Value;
                                    Tab1InputDataGridView[5, i].Value = TmpDataGridView[6, i].Value;
                                    Tab1InputDataGridView[6, i].Value = TmpDataGridView[7, i].Value;
                                }
                                SetHint("成功地从数据库加载了" + (Tab1InputDataGridView.Rows.Count - 1).ToString() + "条换带数据。");
                            }

                            //Tab1数据库存储
                            if (sender == SaveToDBToolStripMenuItem)
                            {
                                if (Tab1InputDataGridView.Rows.Count > 1)
                                {
                                    for (int i = 0; i < Tab1InputDataGridView.Rows.Count - 1; i++)
                                    {
                                        string InsertTxt = "Insert Into CoordConvert (DT, B, L, X, Y, ZoneType, ZoneNum) Values ('";
                                        InsertTxt += IO.DT() + "' , '" +
                                            Tab1InputDataGridView[0, i].Value.ToString() + "' , '" +
                                            Tab1InputDataGridView[1, i].Value.ToString() + "' , '" +
                                            Tab1InputDataGridView[3, i].Value.ToString() + "' , '" +
                                            Tab1InputDataGridView[4, i].Value.ToString() + "' , '" +
                                            Tab1InputDataGridView[5, i].Value.ToString() + "' , '" +
                                            Tab1InputDataGridView[6, i].Value.ToString() + "' )";
                                        dbFile.SaveToDB(InsertTxt);
                                    }
                                    SetHint("成功地将" + (Tab1InputDataGridView.Rows.Count - 1).ToString() + "条换带数据存储至数据库。");
                                }
                                else
                                {
                                    throw new Exception(ErrMessage.Data.EmptyDataGridView);
                                }
                            }
                            break;
                        }
                    case 1:
                        {
                            //Tab2文件读取
                            if (sender == ReadFileToolStripMenuItem)
                            {
                                T2F.Clear();
                                Tab2InputDataGridView.Rows.Clear();
                                T2F = IO.Tab2LoadFromFile(AppSettings.DataFileName);
                                //T2F = IO.Tab2LoadFromFile(WorkFolder.Text + "\\ZoneConversion.xml");

                                for (int i = 0; i < T2F.Count; i++)
                                {
                                    Tab2InputDataGridView.Rows.Add();
                                    Tab2InputDataGridView[0, i].Value = T2F[i].Six.X.ToString();
                                    Tab2InputDataGridView[1, i].Value = T2F[i].Six.Y.ToString();
                                    Tab2InputDataGridView[3, i].Value = T2F[i].Three.X.ToString();
                                    Tab2InputDataGridView[4, i].Value = T2F[i].Three.Y.ToString();
                                }
                                SetHint("成功地从文件加载" + (Tab2InputDataGridView.Rows.Count - 1).ToString() + "条换带数据。");
                            }

                            //Tab2文件存储
                            if (sender == SaveFileToolStripMenuItem)
                            {
                                if (Tab2InputDataGridView.Rows.Count > 1)
                                {
                                    T2F.Clear();
                                    for (int i = 0; i < Tab2InputDataGridView.Rows.Count - 1; i++)
                                    {
                                        T2F.Add(new Tab2File()
                                        {
                                            Six = new GaussCoord
                                            {
                                                GEOEllipse = E,
                                                X = Convert.ToDouble(Tab2InputDataGridView[0, i].Value),
                                                Y = Convert.ToDouble(Tab2InputDataGridView[1, i].Value),
                                                ZoneType = GEOZoneType.Zone6,
                                            },
                                            Three = new GaussCoord
                                            {
                                                GEOEllipse = E,
                                                X = Convert.ToDouble(Tab2InputDataGridView[3, i].Value),
                                                Y = Convert.ToDouble(Tab2InputDataGridView[4, i].Value),
                                                ZoneType = GEOZoneType.Zone3,
                                            },
                                        });
                                    }
                                    IO.Tab2SaveToFile(AppSettings.DataFileName,T2F);
                                    //IO.Tab2SaveToFile(WorkFolder.Text + "\\ZoneConversion.xml", T2F);
                                    SetHint("成功地将" + (Tab2InputDataGridView.Rows.Count - 1).ToString() + "条换带数据存储至文件。");
                                }
                                else
                                {
                                    throw new Exception(ErrMessage.Data.EmptyDataGridView);
                                }
                            }

                            //Tab2数据库读取
                            if (sender == LoadFromDBToolStripMenuItem)
                            {
                                dbFile.ReadFromDB("ZoneConvert", TmpDataGridView);
                                Tab2InputDataGridView.Rows.Clear();
                                for (int i = 0; i < TmpDataGridView.Rows.Count - 1; i++)
                                {
                                    Tab2InputDataGridView.Rows.Add();
                                    Tab2InputDataGridView[0, i].Value = TmpDataGridView[2, i].Value;
                                    Tab2InputDataGridView[1, i].Value = TmpDataGridView[3, i].Value;
                                    Tab2InputDataGridView[3, i].Value = TmpDataGridView[4, i].Value;
                                    Tab2InputDataGridView[4, i].Value = TmpDataGridView[5, i].Value;
                                }
                                SetHint("成功地从数据库加载了" + (Tab2InputDataGridView.Rows.Count - 1).ToString() + "条换带数据。");
                            }

                            //Tab2数据库存储
                            if (sender == SaveToDBToolStripMenuItem)
                            {
                                if (Tab2InputDataGridView.Rows.Count > 1)
                                {
                                    for (int i = 0; i < Tab2InputDataGridView.Rows.Count - 1; i++)
                                    {
                                        string InsertTxt = "Insert Into ZoneConvert (DT, XIn6, YIn6, XIn3, YIn3) Values ('";
                                        InsertTxt += IO.DT() + "' , '" +
                                            Tab2InputDataGridView[0, i].Value.ToString() + "' , '" +
                                            Tab2InputDataGridView[1, i].Value.ToString() + "' , '" +
                                            Tab2InputDataGridView[3, i].Value.ToString() + "' , '" +
                                            Tab2InputDataGridView[4, i].Value.ToString() + "' )";
                                        dbFile.SaveToDB(InsertTxt);
                                    }
                                    SetHint("成功地将" + (Tab2InputDataGridView.Rows.Count - 1).ToString() + "条换带数据存储至数据库。");
                                }
                                else
                                {
                                    throw new Exception(ErrMessage.Data.EmptyDataGridView);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            SetHint(ErrMessage.Data.DataGridViewNotExist);
                            break;
                        }
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        //打开工作路径
        private void NavigateWorkFolder(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", WorkFolder.Text);
        }


        #region 数据库操作
        //更改选定表
        private void ChangeTable(object sender, EventArgs e)
        {
            ReloadDB(true);
        }

        //重载数据库
        private void ReloadDB(object sender, EventArgs e)
        {
            ReloadDB(false);
        }

        //重载的实际操作
        internal void ReloadDB(bool Clear)
        {
            try
            {

                dbFile.ReadFromDB(ChooseDatabaseComboBox.Text, DBDataGridView);
                if (Clear)
                {
                    InsertTextBox.Clear();
                    SetHint("已加载表 " + ChooseDatabaseComboBox.Text);
                }
                else
                {
                    SetHint("已重载表 " + ChooseDatabaseComboBox.Text);
                }
                if (ChooseDatabaseComboBox.SelectedIndex >= 2)
                {
                    throw new Exception("选定表不存在！");
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
                SetHint("选择数据库中的表时出现问题。");
            }
        }

        //插入数据库
        private void InsertIntoDB(object sender, EventArgs e)
        {
            try
            {
                string[] InsertText = InsertTextBox.Text.Replace(" ", ",").Replace("\r\n", ",").Split(',');
                string UpdateDBPath = DBPathTextBox.Text;
                if (String.IsNullOrWhiteSpace(InsertTextBox.Text))
                {
                    throw new Exception("文本框为空~");
                }
                else
                {
                    Insert(ChooseDatabaseComboBox.SelectedIndex, InsertText);
                    InsertTextBox.Clear();
                    SetHint("插入数据成功。");
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
                SetHint("向表中插入数据时出现问题。");
            }
        }

        //插入实际操作方法
        internal void Insert(int TableIndex, string[] InsertText)
        {
            try
            {
                switch (TableIndex)
                {
                    case 0:
                        {
                            string InsertCols = "(DT, B, L, X, Y, ZoneType, ZoneNum)";
                            int ElementNums = 6;
                            dbFile.CheckElementsAndCols(ElementNums, InsertText.Length);
                            dbFile.InsertIntoDB("CoordConvert", DBDataGridView, InsertCols, InsertText, ElementNums);
                            break;
                        }
                    case 1:
                        {
                            string InsertCols = "(DT, XIn6, YIn6, XIn3, YIn3)";
                            int ElementNums = 4;
                            dbFile.CheckElementsAndCols(ElementNums, InsertText.Length);
                            dbFile.InsertIntoDB("ZoneConvert", DBDataGridView, InsertCols, InsertText, ElementNums);
                            break;
                        }
                    default:
                        {
                            throw new Exception("表序号非法！");
                        }
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
                SetHint("向表中插入数据时出现问题。");
            }
        }

        //清空输入
        private void ClearInput(object sender, EventArgs e)
        {
            InsertTextBox.Clear();
            SetHint("已清空输入框。");
        }

        //删除表中的行
        private void DeleteRow(object sender, EventArgs e)
        {
            try
            {
                if (MainTabControl.SelectedIndex == 2)
                {
                    if (ChooseDatabaseComboBox.SelectedIndex < 0)
                    {
                        throw new Exception("未选择表！");
                    }
                    if (DBDataGridView.SelectedCells.Count == 0)
                    {
                        throw new Exception("未选择单元格！");
                    }
                    if (MessageBoxes.Confirm("确认删除所选单元格所在的行？") == "OK")
                    {
                        dbFile.DeleteFromDB(ChooseDatabaseComboBox.Text, DBDataGridView, DBDataGridView.CurrentCell.RowIndex);
                        if (ChooseDatabaseComboBox.SelectedIndex >= 2)
                        {
                            throw new Exception("表序号非法！");
                        }
                    }
                    else
                    {
                        MessageBoxes.OperationCanceledByUser();
                        SetHint("对表中数据进行删除时出现问题。");
                    }
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
                SetHint("对表中数据进行删除时出现问题。");
            }
        }

        //更新表中的数据
        private void UpdateDB(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dbFile.UpdateDB(ChooseDatabaseComboBox.Text, DBDataGridView, e.ColumnIndex, e.RowIndex);
                SetHint("成功更新表 " + ChooseDatabaseComboBox.Text + " 中第" + (e.RowIndex + 1).ToString() + "行第" + e.ColumnIndex + "列的数据。");
            }
            catch (Exception err)
            {
                if (MessageBoxes.Error(err.ToString()) == "OK")
                {
                    dbFile.ReadFromDB(ChooseDatabaseComboBox.Text, DBDataGridView);
                    SetHint("更新表 " + ChooseDatabaseComboBox.Text + " 中第" + (e.RowIndex + 1).ToString() + "行第" + e.ColumnIndex + "列的数据时出现问题。");
                }
            }
        }

        //表存储到文件
        private void DB2File(object sender, EventArgs e)
        {
            try
            {
                switch (ChooseDatabaseComboBox.SelectedIndex)
                {
                    //将坐标转换结果转换至文件
                    case 0:
                        {
                            dbFile.ReadFromDB("CoordConvert", TmpDataGridView);
                            if (TmpDataGridView.Rows.Count > 1)
                            {
                                T1F.Clear();
                                for (int i = 0; i < TmpDataGridView.Rows.Count - 1; i++)
                                {
                                    T1F.Add(new Tab1File()
                                    {
                                        Tab1FileBL = new GEOBL(TmpDataGridView[2, i].Value.ToString(), TmpDataGridView[3, i].Value.ToString()),
                                        Tab1FileGC = new GaussCoord
                                        {
                                            X = Convert.ToDouble(TmpDataGridView[4, i].Value),
                                            Y = Convert.ToDouble(TmpDataGridView[5, i].Value),
                                            ZoneType = (GEOZoneType)Convert.ToInt32(TmpDataGridView[6, i].Value),
                                            Zone = Convert.ToInt32(TmpDataGridView[7, i].Value),
                                        },
                                    });
                                }
                                IO.Tab1SaveToFile(WorkFolder.Text + "\\GeoConversionDB_" + IO.DT() + ".xml", T1F);
                                SetHint("成功地将" + (TmpDataGridView.Rows.Count - 1).ToString() + "条数据库中的坐标转换数据转换为文件。");
                            }
                            else
                            {
                                throw new Exception("目标数据表中无数据。");
                            }
                            break;
                        }
                    //将换带转换结果转换至文件
                    case 1:
                        {
                            dbFile.ReadFromDB("CoordConvert", TmpDataGridView);
                            if (TmpDataGridView.Rows.Count > 1)
                            {
                                T2F.Clear();
                                if (TmpDataGridView.Rows.Count > 1)
                                {
                                    T2F.Clear();
                                    for (int i = 0; i < TmpDataGridView.Rows.Count - 1; i++)
                                    {
                                        T2F.Add(new Tab2File()
                                        {
                                            Six = new GaussCoord
                                            {
                                                X = Convert.ToDouble(TmpDataGridView[0, i].Value),
                                                Y = Convert.ToDouble(TmpDataGridView[1, i].Value),
                                            },
                                            Three = new GaussCoord
                                            {
                                                X = Convert.ToDouble(TmpDataGridView[3, i].Value),
                                                Y = Convert.ToDouble(TmpDataGridView[4, i].Value),
                                            },
                                        });
                                    }
                                    IO.Tab2SaveToFile(WorkFolder.Text + "\\ZoneConversion.xml", T2F);
                                    SetHint("成功地将" + (TmpDataGridView.Rows.Count - 1).ToString() + "条数据库中的换带数据转换为文件。");
                                }
                            }
                            else
                            {
                                throw new Exception("目标数据表中无数据。");
                            }
                            break;
                        }
                    default:
                        {
                            throw new Exception("选择表错误。");
                        }
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
                SetHint("将数据库转换到文件时出现问题。");
            }
        }

        //查询
        private void DBQuery(object sender, EventArgs e)
        {
            try
            {
                dbFile.ReadFromDB(ChooseDatabaseComboBox.SelectedItem.ToString(), InsertTextBox.Text, DBDataGridView);
                SetHint("查询到" + (DBDataGridView.Rows.Count - 1).ToString() + "个符合条件的结果。");
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
                SetHint("查询时出现问题。");
            }
        }

        #endregion

        #endregion

        #region 个性化
        //初始化加载配置文件
        private void LoadSettings(object sender, EventArgs e)
        {
            try
            {
                EllipseMethod.SelectedIndex = 0;
                E = new Ellipse((GEOEllipseType)(EllipseMethod.SelectedIndex + 1));    //初始默认椭球
                WorkFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                SettingsOperation(-1);
                DBPathTextBox.Text = WorkFolder.Text + "\\GeoConvertDB.mdb";
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        //更改工作目录
        private void ChangeWorkFolder(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog ChangeFilePath = new FolderBrowserDialog();
                if (ChangeFilePath.ShowDialog() == DialogResult.OK)
                {
                    WorkFolder.Text = ChangeFilePath.SelectedPath;
                    DBPathTextBox.Text = WorkFolder.Text + "\\GeoConvertDB.mdb";
                }
                else
                {
                    SetHint(ErrMessage.Generic.OpertionCanceledByUser);
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        //设置存取
        internal void SettingsOperation(int Method)
        {
            string SettingPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\GeoConvertSettings.xml";
            if (Method == 1)    //存
            {
                IO.SaveSettings(SettingPath, WorkFolder.Text, EllipseMethod.SelectedIndex, ThreeRadioButton.Checked);
            }
            if (Method == -1)    //取
            {
                //加载配置文件
                if (!File.Exists(SettingPath))   //不存在创建
                {
                    SettingsOperation(1);
                }
                else   //存在读取
                {
                    IO.LoadSettings(SettingPath, ref WorkFolder, ref EllipseMethod, ref ThreeRadioButton, ref SixRadioButton);
                }
            }
        }

        //窗口关闭时保存配置文件
        private void SaveUserSettings(object sender, FormClosingEventArgs e)
        {
            try
            {
                SettingsOperation(1);
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }
        #endregion

        //作者信息
        private void ShowAuthor(object sender, EventArgs e)
        {
            MessageBoxes.Author();
        }
    }
}