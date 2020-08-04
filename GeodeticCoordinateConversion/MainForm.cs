using GeodeticCoordinateConversion.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeodeticCoordinateConversion
{
    public partial class MainForm : Form
    {
        private Settings AppSettings = new Settings();
        private FileIO DataFile = new FileIO();
        private DBIO DBFile = new DBIO();
        public string Hint { get=>HintLabel.Text; set => HintLabel.Text = value; }

        public BindingList<CoordConvert> CoordData = new BindingList<CoordConvert>();
        public BindingList<ZoneConvert> ZoneData = new BindingList<ZoneConvert>();
        DataGridView CoordDGV;
        DataGridView ZoneDGV;

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;    //Better to use delegate.
            Hint = CommonText.Greet();

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

            Coord.ConvertSelectionChange += new CoordConvertLayout.ConvertSelectionChangeEventHander(this.ConvertSelection);

            Coord.TransferBtn.Click += new System.EventHandler(this.TransferCoord2Gauss);

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

            Zone.ConvertSelectionChange += new CoordConvertLayout.ConvertSelectionChangeEventHander(this.ConvertSelection);

            //数据库表编辑控件
            TableViewCtrl TVC = new TableViewCtrl()
            {
                Dock = DockStyle.Fill,
                TabStop=true,
               TabIndex =0,
            };
            TVC.HintChanged += new TableViewCtrl.HintChangedEventHandler(this.ChildHintChanged);
            this.DBTabPage.Controls.Add(TVC);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        #region Public

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
                    CoordData = new BindingList<CoordConvert>(await Task.Run(() => DataFile.LoadCoordConvertData()));
                    CoordDGV.DataSource = CoordData;
                    CoordDGV.ClearSelection();
                }
                if (sender == Zone.LoadFileBtn)
                {
                    ZoneData = new BindingList<ZoneConvert>(await Task.Run(() => DataFile.LoadZoneConvertData()));
                    ZoneDGV.DataSource = ZoneData;
                    ZoneDGV.ClearSelection();
                }
                if (sender == Coord.LoadDBBtn)
                {
                    CoordData = new BindingList<CoordConvert>(await Task.Run(() => DBFile.LoadCoordConvertData()));
                    CoordDGV.DataSource = CoordData;
                    CoordDGV.ClearSelection();
                }
                if (sender == Zone.LoadDBBtn)
                {
                    ZoneData = new BindingList<ZoneConvert>(await Task.Run(() => DBFile.LoadZoneConvertData()));
                    ZoneDGV.DataSource = ZoneData;
                    ZoneDGV.ClearSelection();
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
                    await Task.Run(() => DataFile.SaveCoordConvertData(CoordData.ToList()));
                }
                if (sender == Zone.SaveFileBtn)
                {
                    await Task.Run(() => DataFile.SaveZoneConvertData(ZoneData.ToList()));
                }
                if (sender == Coord.SaveDBBtn)
                {
                    await Task.Run(() => DBFile.SaveCoordConvertData(CoordData.ToList()));
                }
                if (sender == Zone.SaveDBBtn)
                {
                    await Task.Run(() => DBFile.SaveZoneConvertData(ZoneData.ToList()));
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

        public void ChildHintChanged(object sender,HintChangedEventArgs e)
        {
            this.Hint = e.NewValue.ToString();
        }

        private void OpenSettings(object sender, EventArgs e)
        {

        }

        private void ShowAbout(object sender, EventArgs e)
        {
            new AboutApp().ShowDialog();
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
                DisplayMember = nameof(GEOEllipseType),
                DataPropertyName = nameof(Ellipse.EllipseType),
                ValueMember = "Value"
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
                ValueMember = "Value"
            };
            CoordDGV.Columns.Remove(CoordDGV.Columns[nameof(CoordConvert.ZoneType)]);
            CoordDGV.Columns.Insert(CoordDGV.Columns[nameof(CoordConvert.Y)].Index + 1, ZoneCol);
        }

        //坐标转换正反算操作
        private void CoordConvertOperation(object sender, EventArgs e)
        {
            for (int i = 0; i < CoordData.Count; i++)
            {
                if ((CoordData[i].Selected) && (CoordData[i].Dirty))
                {
                    if (sender == Coord.ReverseBtn)
                    {
                        CoordData[i].GaussReverse();
                    }
                    if (sender == Coord.DirectBtn)
                    {
                        CoordData[i].GaussDirect();
                    }
                }
                Coord.ResetColor(i);
            }
            CoordDGV.ClearSelection();
            CoordDGV.Invalidate();
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
             if(AppSettings.SwitchAfterGaussTransfer)
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
                ValueMember = "Value"
            };
            ZoneDGV.Columns.Remove(ZoneDGV.Columns[nameof(Ellipse.EllipseType)]);
            ZoneDGV.Columns.Insert(ZoneDGV.Columns[nameof(ZoneConvert.Y6)].Index + 1, Ell);
        }

        //换带操作
        private void ZoneConvertOperation(object sender, EventArgs e)
        {
            for (int i = 0; i < ZoneData.Count; i++)
            {
                if ((ZoneData[i].Selected) && (ZoneData[i].Dirty))
                {
                    if (sender == Zone.ReverseBtn)
                    {
                        ZoneData[i].Convert3To6();
                    }
                    if (sender == Zone.DirectBtn)
                    {
                        ZoneData[i].Convert6To3();
                    }
                }
                Zone.ResetColor(i);
            }
            ZoneDGV.ClearSelection();
            ZoneDGV.Invalidate();
        }
        #endregion

    }
}
