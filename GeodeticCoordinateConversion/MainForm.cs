using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeodeticCoordinateConversion
{
    public partial class MainForm : Form
    {
        private GEOSettings AppSettings = new GEOSettings();
        private FileIO DataFile = new FileIO();
        private DBIO DBFile = new DBIO();

        public BindingList<CoordConvert> CoordData = new BindingList<CoordConvert>();
        public BindingList<ZoneConvert> ZoneData = new BindingList<ZoneConvert>();
        DataGridView CoordDGV;
        DataGridView ZoneDGV;

        public MainForm()
        {
            InitializeComponent();

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
        }

        private void Form1_Load(object sender, EventArgs e)
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
        private void LoadData(object sender, EventArgs e)
        {
            if (sender == Coord.LoadFileBtn)
            {
                CoordData = new BindingList<CoordConvert>(DataFile.LoadCoordConvertData());
                CoordDGV.DataSource = CoordData;
                CoordDGV.ClearSelection();
            }
            if (sender == Zone.LoadFileBtn)
            {
                ZoneData = new BindingList<ZoneConvert>(DataFile.LoadZoneConvertData());
                ZoneDGV.DataSource = ZoneData;
                ZoneDGV.ClearSelection();
            }
            if (sender == Coord.LoadDBBtn)
            {
                CoordData = new BindingList<CoordConvert>(DBFile.LoadCoordConvertData());
                CoordDGV.DataSource = CoordData;
                CoordDGV.ClearSelection();
            }
            if (sender == Zone.LoadDBBtn)
            {
                ZoneData = new BindingList<ZoneConvert>(DBFile.LoadZoneConvertData());
                ZoneDGV.DataSource = ZoneData;
                ZoneDGV.ClearSelection();
            }
        }

        //保存数据
        private void SaveData(object sender, EventArgs e)
        {
            if (sender == Coord.SaveFileBtn)
            {
                DataFile.SaveCoordConvertData(CoordData.ToList());
            }
            if (sender == Zone.SaveFileBtn)
            {
                DataFile.SaveZoneConvertData(ZoneData.ToList());
            }
            if (sender == Coord.SaveDBBtn)
            {
                DBFile.SaveCoordConvertData(CoordData.ToList());
            }
            if (sender == Zone.SaveDBBtn)
            {
                DBFile.SaveZoneConvertData(ZoneData.ToList());
            }
        }

        //选择操作
        private void ConvertSelection(object sender, string tag, EventArgs e)
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
        #endregion

        #region CoordConvert
        //初始化坐标转换
        private void InitCoordConvert(object sender, EventArgs e)
        {
            //绑定数据源
            CoordDGV.DataSource = CoordData;
            CoordDGV.AutoGenerateColumns = true;

            //替换椭球列
            DataGridViewComboBoxColumn Ell = new DataGridViewComboBoxColumn
            {
                Name = nameof(CoordConvert.EllipseType),
                HeaderText = (typeof(CoordConvert).GetProperty(nameof(CoordConvert.EllipseType))).GetCustomAttribute<DisplayNameAttribute>().DisplayName,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                DataSource = GEODataTables.GetEllipseType(),
                DisplayMember = nameof(GEOEllipseType),
                DataPropertyName = "EllipseType",
                ValueMember = "Value"
            };
            CoordDGV.Columns.Remove(CoordDGV.Columns["EllipseType"]);
            CoordDGV.Columns.Insert(CoordDGV.Columns["L"].Index + 1, Ell);

            //替换分带类型列
            DataGridViewComboBoxColumn Zo = new DataGridViewComboBoxColumn
            {
                Name = nameof(CoordConvert.ZoneType),
                HeaderText = (typeof(CoordConvert).GetProperty(nameof(CoordConvert.ZoneType))).GetCustomAttribute<DisplayNameAttribute>().DisplayName,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                DataSource = GEODataTables.GetZoneType(),
                DisplayMember = nameof(GEOZoneType),
                DataPropertyName = "ZoneType",
                ValueMember = "Value"
            };
            CoordDGV.Columns.Remove(CoordDGV.Columns["ZoneType"]);
            CoordDGV.Columns.Insert(CoordDGV.Columns["Y"].Index + 1, Zo);
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
                DataPropertyName = "EllipseType",
                ValueMember = "Value"
            };
            ZoneDGV.Columns.Remove(ZoneDGV.Columns["EllipseType"]);
            ZoneDGV.Columns.Insert(ZoneDGV.Columns["Y6"].Index + 1, Ell);
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
