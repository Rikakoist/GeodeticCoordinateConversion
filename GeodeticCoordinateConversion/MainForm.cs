using GeodeticCoordinateConversion.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeodeticCoordinateConversion
{
    public partial class MainForm : Form
    {
        private static Settings AppSettings = new Settings();
        public static ResourceManager rm = new ResourceManager(Constants.ResourceSpace, Assembly.GetExecutingAssembly());

        private FileIO DataFile = new FileIO();
        public string Hint { get => HintLabel.Text; set => HintLabel.Text = value; }

        public BindingList<CoordConvert> CoordData = new BindingList<CoordConvert>();
        public BindingList<ZoneConvert> ZoneData = new BindingList<ZoneConvert>();
        DataGridView CoordDGV;
        DataGridView ZoneDGV;

        public MainForm()
        {
            InitializeComponent();

            #region Multi-language
            this.Text = rm.GetString("AppTitle");
            SettingsBtn.Text = rm.GetString("Settings");
            AboutBtn.Text = rm.GetString("About");

            CoordTabPage.Text = rm.GetString("CoordConvert");
            ZoneTabPage.Text = rm.GetString("ZoneConvert");
            DBTabPage.Text = rm.GetString("DBTab");

            HintLabel.Text = rm.GetString("NowLoading");
            TimeLabel.Text = rm.GetString("NowLoading");
            #endregion

            CheckForIllegalCrossThreadCalls = false;    //Better to use delegate.
            Hint = Hints.Greet();

            //坐标转换事件绑定
            this.CoordDGV = Coord.DGV;
            Coord.Load += new EventHandler(this.InitCoordConvert);

            Coord.AddRowBtn.Click += new System.EventHandler(this.AddRow);
            Coord.LoadFileBtn.Click += new System.EventHandler(this.LoadData);
            Coord.SaveFileBtn.Click += new System.EventHandler(this.SaveData);
            Coord.LoadDBBtn.Click += new System.EventHandler(this.LoadData);
            Coord.SaveDBBtn.Click += new System.EventHandler(this.SaveData);

            Coord.DirectBtn.Click += new System.EventHandler(this.CoordConvertOperation);
            Coord.ReverseBtn.Click += new System.EventHandler(this.CoordConvertOperation);

            Coord.ConvertSelectionChange += new ConvertCtrl.ConvertSelectionChangeEventHander(this.ConvertSelection);

            Coord.TransferBtn.Click += new System.EventHandler(this.TransferCoord2Gauss);
            Coord.HintChanged += new ConvertCtrl.HintChangedEventHandler(this.ChildHintChanged);

            //换带事件绑定
            this.ZoneDGV = Zone.DGV;
            Zone.TransferBtn.Visible = false;
            Zone.Load += new EventHandler(this.InitZoneConvert);

            Zone.AddRowBtn.Click += new System.EventHandler(this.AddRow);
            Zone.LoadFileBtn.Click += new System.EventHandler(this.LoadData);
            Zone.SaveFileBtn.Click += new System.EventHandler(this.SaveData);
            Zone.LoadDBBtn.Click += new System.EventHandler(this.LoadData);
            Zone.SaveDBBtn.Click += new System.EventHandler(this.SaveData);

            Zone.DirectBtn.Click += new System.EventHandler(this.ZoneConvertOperation);
            Zone.ReverseBtn.Click += new System.EventHandler(this.ZoneConvertOperation);

            Zone.ConvertSelectionChange += new ConvertCtrl.ConvertSelectionChangeEventHander(this.ConvertSelection);
            Zone.HintChanged += new ConvertCtrl.HintChangedEventHandler(this.ChildHintChanged);

            //数据库表编辑控件
            TableViewCtrl TVC = new TableViewCtrl()
            {
                Dock = DockStyle.Fill,
                TabStop = true,
                TabIndex = 0,
            };
            TVC.HintChanged += new TableViewCtrl.HintChangedEventHandler(this.ChildHintChanged);
            this.DBTabPage.Controls.Add(TVC);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        #region Public
        /// <summary>
        /// 选择路径。
        /// </summary>
        /// <param name="fileMode">文件模式。</param>
        /// <returns>选择的路径。</returns>
        private string SelectPath(FileMode fileMode)
        {
            switch(fileMode)
            {
                case FileMode.Open:
                    {
                        OpenFileDialog OFD = new OpenFileDialog()
                        {
                            AddExtension = true,
                            CheckPathExists = true,
                            CheckFileExists=true,
                            DefaultExt = "xml",
                            Filter = "XML files (*.xml)|*.xml",
                            Title = rm.GetString("SelectDataFile"),
                        };
                        if (OFD.ShowDialog() == DialogResult.OK)
                        {
                            return OFD.FileName;
                        }
                        break;
                    }
                case FileMode.Create:
                    {
                        SaveFileDialog SFD = new SaveFileDialog()
                        {
                            AddExtension = true,
                            CheckPathExists = true,
                            DefaultExt = "xml",
                            FileName = new Settings().DataFileName,
                            Filter = "XML files (*.xml)|*.xml",
                            Title = rm.GetString("SelectSavePos"),
                        };
                        if (SFD.ShowDialog() == DialogResult.OK)
                        {
                            return SFD.FileName;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return string.Empty;
        }
        //添加行
        private void AddRow(object sender, EventArgs e)
        {
            if (sender == Coord.AddRowBtn)
            {
                CoordData.Add(new CoordConvert());
            }
            if (sender == Zone.AddRowBtn)
            {
                ZoneData.Add(new ZoneConvert());
            }
        }

        //加载数据
        private async void LoadData(object sender, EventArgs e)
        {
            try
            {
                if (sender == Coord.LoadFileBtn)
                {
                    if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                    {
                        string tmpP = SelectPath(FileMode.Open);
                        if (File.Exists(tmpP))
                        {
                            FileIO FI = new FileIO(Path.GetDirectoryName(tmpP), Path.GetFileName(tmpP));
                            CoordData = new BindingList<CoordConvert>(await Task.Run(() => FI.LoadCoordConvertData()));
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        CoordData = new BindingList<CoordConvert>(await Task.Run(() => DataFile.LoadCoordConvertData()));
                    }
                    CoordDGV.DataSource = CoordData;
                    CoordDGV.ClearSelection();
                    Hint = Hints.DataLoaded(GEODataSourceType.File, CoordData.Count(), GEODataType.CoordConvert);
                }
                if (sender == Zone.LoadFileBtn)
                {
                    if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                    {
                        string tmpP = SelectPath(FileMode.Open);
                        if (File.Exists(tmpP))
                        {
                            FileIO FI = new FileIO(Path.GetDirectoryName(tmpP), Path.GetFileName(tmpP));
                            ZoneData = new BindingList<ZoneConvert>(await Task.Run(() => FI.LoadZoneConvertData()));
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        ZoneData = new BindingList<ZoneConvert>(await Task.Run(() => DataFile.LoadZoneConvertData()));
                    }
                    ZoneDGV.DataSource = ZoneData;
                    ZoneDGV.ClearSelection();
                    Hint = Hints.DataLoaded(GEODataSourceType.File, ZoneData.Count(), GEODataType.ZoneConvert);
                }
                if (sender == Coord.LoadDBBtn)
                {
                    CoordData = new BindingList<CoordConvert>(await Task.Run(() => DBIO.LoadCoordConvertData()));
                    CoordDGV.DataSource = CoordData;
                    CoordDGV.ClearSelection();
                    Hint = Hints.DataLoaded(GEODataSourceType.DB, CoordData.Count(), GEODataType.CoordConvert);
                }
                if (sender == Zone.LoadDBBtn)
                {
                    ZoneData = new BindingList<ZoneConvert>(await Task.Run(() => DBIO.LoadZoneConvertData()));
                    ZoneDGV.DataSource = ZoneData;
                    ZoneDGV.ClearSelection();
                    Hint = Hints.DataLoaded(GEODataSourceType.DB, ZoneData.Count(), GEODataType.ZoneConvert);
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        //保存数据
        private async void SaveData(object sender, EventArgs e)
        {
            try
            {
                if (sender == Coord.SaveFileBtn)
                {
                    if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                    {
                        string tmpP = SelectPath(FileMode.Create);
                        if (File.Exists(tmpP))
                        {
                            FileIO FI = new FileIO(Path.GetDirectoryName(tmpP), Path.GetFileName(tmpP));
                            await Task.Run(() => FI.SaveCoordConvertData(CoordData.ToList(), AppSettings.ClearExistingRecordData2File));
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        await Task.Run(() => DataFile.SaveCoordConvertData(CoordData.ToList(), AppSettings.ClearExistingRecordData2File));
                    }
                    Hint = Hints.DataSaved(GEODataSourceType.File, CoordData.Count(), GEODataType.CoordConvert);
                }
                if (sender == Zone.SaveFileBtn)
                {
                    if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                    {
                        string tmpP = SelectPath(FileMode.Create);
                        if (File.Exists(tmpP))
                        {
                            FileIO FI = new FileIO(Path.GetDirectoryName(tmpP), Path.GetFileName(tmpP));
                            await Task.Run(() => FI.SaveZoneConvertData(ZoneData.ToList(), AppSettings.ClearExistingRecordData2File));
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        await Task.Run(() => DataFile.SaveZoneConvertData(ZoneData.ToList(), AppSettings.ClearExistingRecordData2File));
                    }
                    Hint = Hints.DataSaved(GEODataSourceType.File, ZoneData.Count(), GEODataType.ZoneConvert);
                }
                if (sender == Coord.SaveDBBtn)
                {
                    await Task.Run(() => DBIO.SaveCoordConvertData(CoordData.ToList(), AppSettings.ClearExistingRecordData2DB));
                    Hint = Hints.DataSaved(GEODataSourceType.DB, CoordData.Count(), GEODataType.CoordConvert);
                }
                if (sender == Zone.SaveDBBtn)
                {
                    await Task.Run(() => DBIO.SaveZoneConvertData(ZoneData.ToList(), AppSettings.ClearExistingRecordData2DB));
                    Hint = Hints.DataSaved(GEODataSourceType.DB, ZoneData.Count(), GEODataType.ZoneConvert);
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        //选择操作
        private void ConvertSelection(object sender, string tag, EventArgs e)
        {
            try
            {
                if (sender == Coord)
                {
                    for (int i = 0; i < CoordData.Count; i++)
                    {
                        DataStatus c = CoordData[i];
                        if (tag == "SelectAll")
                        {
                            if (!c.Selected)
                                c.Selected = true;
                        }
                        if (tag == "SelectNone")
                        {
                            if (c.Selected)
                                c.Selected = false;
                        }
                        if (tag == "ReverseSelect")
                        {
                            c.Selected = !c.Selected;
                        }
                        Coord.ResetColor(i);
                    }
                    CoordDGV.Invalidate();
                }
                if (sender == Zone)
                {
                    for (int i = 0; i < ZoneData.Count; i++)
                    {
                        DataStatus c = ZoneData[i];
                        if (tag == "SelectAll")
                        {
                            if (!c.Selected)
                                c.Selected = true;
                        }
                        if (tag == "SelectNone")
                        {
                            if (c.Selected)
                                c.Selected = false;
                        }
                        if (tag == "ReverseSelect")
                        {
                            c.Selected = !c.Selected;
                        }
                        Zone.ResetColor(i);
                    }
                    ZoneDGV.Invalidate();
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        //子控件的提示信息改变
        public void ChildHintChanged(object sender, HintChangedEventArgs e)
        {
            this.Hint = e.NewValue?.ToString();
        }

        //时钟
        private void Clock(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        //打开设置窗口
        private void OpenSettings(object sender, EventArgs e)
        {
            if (new SettingsForm().ShowDialog() == DialogResult.OK)
                Application.Restart();
        }

        //关于窗口
        private void ShowAbout(object sender, EventArgs e)
        {
            new AboutApp().ShowDialog();
        }

        //关闭连接
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClockTimer.Dispose();
        }
        #endregion

        #region CoordConvert
        //初始化坐标转换
        private void InitCoordConvert(object sender, EventArgs e)
        {
            //绑定数据源
            CoordDGV.DataSource = CoordData;
            CoordDGV.AutoGenerateColumns = true;

            //替换椭球列
            DataGridViewComboBoxColumn EllCol = new DataGridViewComboBoxColumn
            {
                Name = nameof(CoordConvert.EllipseType),
                HeaderText = (typeof(CoordConvert).GetProperty(nameof(CoordConvert.EllipseType))).GetCustomAttribute<DisplayNameAttribute>().DisplayName,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                DataSource = GEODataTables.GetEllipseType(),
                //DataSource = GEODataTables.GetEnumType(GEOEllipseType),
                DisplayMember = nameof(GEOEllipseType),
                DataPropertyName = nameof(Ellipse.EllipseType),
                ValueMember = Constants.ValueCol
            };
            CoordDGV.Columns.Remove(CoordDGV.Columns[nameof(Ellipse.EllipseType)]);
            CoordDGV.Columns.Insert(CoordDGV.Columns[nameof(CoordConvert.L)].Index + 1, EllCol);

            //替换分带类型列
            DataGridViewComboBoxColumn ZoneCol = new DataGridViewComboBoxColumn
            {
                Name = nameof(CoordConvert.ZoneType),
                HeaderText = (typeof(CoordConvert).GetProperty(nameof(CoordConvert.ZoneType))).GetCustomAttribute<DisplayNameAttribute>().DisplayName,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                DataSource = GEODataTables.GetZoneType(),
                DisplayMember = nameof(GEOZoneType),
                DataPropertyName = nameof(CoordConvert.ZoneType),
                ValueMember = Constants.ValueCol
            };
            CoordDGV.Columns.Remove(CoordDGV.Columns[nameof(CoordConvert.ZoneType)]);
            CoordDGV.Columns.Insert(CoordDGV.Columns[nameof(CoordConvert.Y)].Index + 1, ZoneCol);

            foreach(DataGridViewColumn DC in CoordDGV.Columns)
            {
                DC.HeaderText = rm.GetString(DC.Name);
            }
        }

        //坐标转换正反算操作
        private void CoordConvertOperation(object sender, EventArgs e)
        {
            if (CoordData.Count <= 0)
                return;
            int _success = 0; int _fail = 0; int _calc = 0;
            for (int i = 0; i < CoordData.Count; i++)
            {
                if ((CoordData[i].Selected) && (CoordData[i].Dirty))
                {
                    _calc++;
                    if (sender == Coord.ReverseBtn)
                    {
                        if (CoordData[i].GaussReverse())
                            _success++;
                        else
                            _fail++;
                    }
                    if (sender == Coord.DirectBtn)
                    {
                        if (CoordData[i].GaussDirect())
                            _success++;
                        else
                            _fail++;
                    }
                }
                Coord.ResetColor(i);
            }
            CoordDGV.ClearSelection();
            CoordDGV.Invalidate();
            if (sender == Coord.ReverseBtn)
            {
                Hint = Hints.ConvertResult(GEOConvertType.GaussReverse, CoordData.Count, _calc, _success, _fail);
            }
            if (sender == Coord.DirectBtn)
            {
                Hint = Hints.ConvertResult(GEOConvertType.GaussDirect, CoordData.Count, _calc, _success, _fail);
            }
            _success = _fail = _calc = 0;
        }

        //坐标转换转高斯
        private void TransferCoord2Gauss(object sender, EventArgs e)
        {
            if (CoordData.Count <= 0)
                return;
            foreach (CoordConvert c in CoordData)
            {
                if (c.Selected && (!c.Error) && (!(c.Gauss is null)))
                {
                    ZoneData.Add(new ZoneConvert(c.Gauss));
                }
            }
            if (AppSettings.SwitchAfterGaussTransfer)
                ConvertTabControl.SelectedTab = ZoneTabPage;
        }
        #endregion

        #region ZoneConvert
        //初始化坐标换带
        private void InitZoneConvert(object sender, EventArgs e)
        {
            //绑定数据源
            ZoneDGV.DataSource = ZoneData;
            ZoneDGV.AutoGenerateColumns = true;

            //替换椭球列
            DataGridViewComboBoxColumn Ell = new DataGridViewComboBoxColumn
            {
                Name = nameof(ZoneConvert.EllipseType),
                HeaderText = (typeof(ZoneConvert).GetProperty(nameof(ZoneConvert.EllipseType))).GetCustomAttribute<DisplayNameAttribute>().DisplayName,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                DataSource = GEODataTables.GetEllipseType(),
                DisplayMember = nameof(GEOEllipseType),
                DataPropertyName = nameof(Ellipse.EllipseType),
                ValueMember = Constants.ValueCol
            };
            ZoneDGV.Columns.Remove(ZoneDGV.Columns[nameof(Ellipse.EllipseType)]);
            ZoneDGV.Columns.Insert(ZoneDGV.Columns[nameof(ZoneConvert.Y6)].Index + 1, Ell);

            foreach (DataGridViewColumn DC in ZoneDGV.Columns)
            {
                DC.HeaderText = rm.GetString(DC.Name);
            }
        }

        //换带操作
        private void ZoneConvertOperation(object sender, EventArgs e)
        {
            if (ZoneData.Count <= 0)
                return;
            int _success = 0; int _fail = 0; int _calc = 0;
            for (int i = 0; i < ZoneData.Count; i++)
            {
                if ((ZoneData[i].Selected) && (ZoneData[i].Dirty))
                {
                    _calc++;
                    if (sender == Zone.ReverseBtn)
                    {
                        if (ZoneData[i].Convert3To6())
                            _success++;
                        else
                            _fail++;
                    }
                    if (sender == Zone.DirectBtn)
                    {
                        if (ZoneData[i].Convert6To3())
                            _success++;
                        else
                            _fail++;
                    }
                }
                Zone.ResetColor(i);
            }
            ZoneDGV.ClearSelection();
            ZoneDGV.Invalidate();
            if (sender == Zone.ReverseBtn)
            {
                Hint = Hints.ConvertResult(GEOConvertType.Zone3To6, ZoneData.Count, _calc, _success, _fail);
            }
            if (sender == Zone.DirectBtn)
            {
                Hint = Hints.ConvertResult(GEOConvertType.Zone6To3, ZoneData.Count, _calc, _success, _fail);
            }
            _success = _fail = _calc = 0;
        }
        #endregion
    }
}