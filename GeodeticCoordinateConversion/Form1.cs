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
    public partial class Form1 : Form
    {
        private GEOSettings AppSettings = new GEOSettings();
        private FileIO DataFile = new FileIO();

        public BindingList<CoordConvert> CoordData = new BindingList<CoordConvert>();
        public BindingList<ZoneConvert> ZoneData = new BindingList<ZoneConvert>();
        DataGridView CoordDGV;
        DataGridView ZoneDGV;

        public Form1()
        {
            InitializeComponent();
            this.CoordDGV = Coord.DGV;
            Coord.Load += new EventHandler(this.InitCoordConvert);

            Coord.AddRowBtn.Click += new System.EventHandler(this.AddRow);
            Coord.LoadBtn.Click += new System.EventHandler(this.LoadData);
            Coord.SaveBtn.Click += new System.EventHandler(this.SaveData);

            Coord.DirectBtn.Click += new System.EventHandler(this.CoordConvertOperation);
            Coord.ReverseBtn.Click += new System.EventHandler(this.CoordConvertOperation);

            Coord.ConvertSelectionChange += new CoordConvertLayout.ConvertSelectionChangeEventHander(this.ConvertSelection);

            //Coord.SelectAllBtn.Click += new System.EventHandler(this.ConvertSelection);
            //Coord.SelectNoneBtn.Click += new System.EventHandler(this.ConvertSelection);
            //Coord.ReverseSelectBtn.Click += new System.EventHandler(this.ConvertSelection);      

            Coord.TransferBtn.Click += new System.EventHandler(this.TransferCoord2Gauss);

            this.ZoneDGV = Zone.DGV;
            Zone.TransferBtn.Visible = false;
            Zone.Load += new EventHandler(this.InitZoneConvert);

            Zone.AddRowBtn.Click += new System.EventHandler(this.AddRow);
            Zone.LoadBtn.Click += new System.EventHandler(this.LoadData);
            Zone.SaveBtn.Click += new System.EventHandler(this.SaveData);

            Zone.DirectBtn.Click += new System.EventHandler(this.ZoneConvertOperation);
            Zone.ReverseBtn.Click += new System.EventHandler(this.ZoneConvertOperation);

            Zone.ConvertSelectionChange += new CoordConvertLayout.ConvertSelectionChangeEventHander(this.ConvertSelection);
            ////Zone.SelectAllBtn.Click += new System.EventHandler(this.ConvertSelection);
            ////Zone.SelectNoneBtn.Click += new System.EventHandler(this.ConvertSelection);
            ////Zone.ReverseSelectBtn.Click += new System.EventHandler(this.ConvertSelection);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region Public

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

        private void LoadData(object sender, EventArgs e)
        {
            if (sender == Coord.LoadBtn)
            {
                CoordData = new BindingList<CoordConvert>(DataFile.LoadCoordConvertData());
                CoordDGV.DataSource = CoordData;
                CoordDGV.ClearSelection();
            }
            if (sender == Zone.LoadBtn)
            {
                ZoneData = new BindingList<ZoneConvert>(DataFile.LoadZoneConvertData());
                ZoneDGV.DataSource = ZoneData;
                ZoneDGV.ClearSelection();
            }
        }

        private void SaveData(object sender, EventArgs e)
        {
            if (sender == Coord.SaveBtn)
            {
                DataFile.SaveCoordConvertData(CoordData.ToList());
            }
            if (sender == Zone.SaveBtn)
            {
                DataFile.SaveZoneConvertData(ZoneData.ToList());
            }
        }

        private void ConvertSelection(object sender, string tag, EventArgs e)
        {
            if (sender == Coord)
            {
                for (int i = 0; i < CoordData.Count; i++)
                {
                    CalcObj c = CoordData[i];
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
                    CalcObj c = ZoneData[i];
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

        private void TransferCoord2Gauss(object sender, EventArgs e)
        {
            foreach (GaussCoord G in TransferGauss())
            {
                ZoneData.Add(new ZoneConvert(G));
            }
        }

        /// <summary>
        /// 生成高斯坐标列表。
        /// </summary>
        /// <returns>高斯坐标列表。</returns>
        public List<GaussCoord> TransferGauss()
        {
            List<GaussCoord> G = new List<GaussCoord>();
            foreach (CoordConvert c in CoordData)
            {
                if (c.Selected && (!c.Error) && (!(c.Gauss is null)))
                {
                    G.Add(c.Gauss);
                }
            }
            return G;
        }
        #endregion

        #region ZoneConvert
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
