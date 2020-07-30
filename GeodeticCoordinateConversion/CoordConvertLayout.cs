﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using System.Xml.Serialization;
using System.IO;

namespace GeodeticCoordinateConversion
{
    public partial class CoordConvertLayout : UserControl
    {
        private GEOSettings AppSettings = new GEOSettings();
        private FileIO DataFile = new FileIO();
        public BindingList<CoordConvert> Data = new BindingList<CoordConvert>();
        public string Hint { get; private set; }

        public CoordConvertLayout()
        {
            InitializeComponent();
        }

        private void CoordConvertLayout_Load(object sender, EventArgs e)
        {
            this.Data.ListChanged += new ListChangedEventHandler(this.ResetColor);
            CoordConvertDGV.Columns.Clear();
            //绑定数据源
            CoordConvertDGV.DataSource = Data;
            CoordConvertDGV.AutoGenerateColumns = true;

            //替换椭球列
            DataGridViewComboBoxColumn Ell = new DataGridViewComboBoxColumn
            {
                //AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                Name = nameof(CoordConvert.EllipseType),
                HeaderText = (typeof(CoordConvert).GetProperty(nameof(CoordConvert.EllipseType))).GetCustomAttribute<DisplayNameAttribute>().DisplayName,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                DataSource = GEODataTables.GetEllipseType(),
                DisplayMember = nameof(GEOEllipseType),
                DataPropertyName = "EllipseType",
                ValueMember = "Value"
            };
            CoordConvertDGV.Columns.Remove(CoordConvertDGV.Columns["EllipseType"]);
            CoordConvertDGV.Columns.Insert(CoordConvertDGV.Columns["L"].Index + 1, Ell);

            //替换分带类型列
            DataGridViewComboBoxColumn Zo = new DataGridViewComboBoxColumn
            {
                //AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                Name = nameof(CoordConvert.ZoneType),
                HeaderText = (typeof(CoordConvert).GetProperty(nameof(CoordConvert.ZoneType))).GetCustomAttribute<DisplayNameAttribute>().DisplayName,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                DataSource = GEODataTables.GetZoneType(),
                DisplayMember = nameof(GEOZoneType),
                DataPropertyName = "ZoneType",
                ValueMember = "Value"
            };
            CoordConvertDGV.Columns.Remove(CoordConvertDGV.Columns["ZoneType"]);
            CoordConvertDGV.Columns.Insert(CoordConvertDGV.Columns["Y"].Index + 1, Zo);
            foreach (DataGridViewColumn c in CoordConvertDGV.Columns)
            {
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void LoadData(object sender, EventArgs e)
        {
            //using (var stream = System.IO.File.OpenRead(@"E:\S.xml"))
            //{
            //    var serializer = new XmlSerializer(Data.GetType());
            //    this.Data = serializer.Deserialize(stream) as BindingList<CoordConvert>;
            //}
            LoadData();
        }

        private void SaveData(object sender, EventArgs e)
        {      
            //using (var writer = new System.IO.StreamWriter(@"E:\S.xml"))
            //{
            //    var serializer = new XmlSerializer(Data.GetType());
            //    serializer.Serialize(writer, Data);
            //    writer.Flush();
            //}
            SaveData();
        }

        public void LoadData()
        {
            Data = new BindingList<CoordConvert>(DataFile.LoadCoordConvertData());
            CoordConvertDGV.DataSource = Data;
        }

        public void SaveData()
        {
            DataFile.SaveCoordConvertData(Data.ToList());
        }

        private void CoordConvertDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CoordConvertDGV.Rows[e.RowIndex].Cells[nameof(CoordConvert.Error)].Style.BackColor = Color.White;
            }
            catch (Exception err)
            {
                Trace.TraceError(err.ToString());
            }
        }

        private void AddRow(object sender, EventArgs e)
        {
            Data.Add(new CoordConvert());
        }

        private void DeleteRow(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dr = CoordConvertDGV.SelectedRows;
            for (int i = 0; i < dr.Count; i++)
            {
                CoordConvertDGV.Rows.RemoveAt(dr[i].Index);
            }
        }

        private void DirectBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if ((Data[i].Selected)&& (Data[i].Dirty))
                    CoordConvertDGV.Rows[i].Cells[nameof(CoordConvert.Error)].Style.BackColor = Data[i].GaussDirect() ? Color.Green : Color.Red;
            }
            CoordConvertDGV.ClearSelection();
            CoordConvertDGV.Invalidate();
        }

        private void ReverseBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if ((Data[i].Selected) && (Data[i].Dirty))
                    CoordConvertDGV.Rows[i].Cells[nameof(CoordConvert.Error)].Style.BackColor = Data[i].GaussReverse() ? Color.Green : Color.Red;
            }
            CoordConvertDGV.ClearSelection();
            CoordConvertDGV.Invalidate();
        }

        private void ResetColor(object sender,ListChangedEventArgs e)
        {
           if(e.ListChangedType== ListChangedType.ItemChanged)
            {
                MessageBox.Show(e.NewIndex.ToString() + "  " + e.OldIndex.ToString());
            }
        }

        private void TransferBtn_Click(object sender, EventArgs e)
        {
            TransferGauss();
        }

        /// <summary>
        /// 生成高斯坐标列表。
        /// </summary>
        /// <returns>高斯坐标列表。</returns>
        public List<GaussCoord> TransferGauss()
        {
            List<GaussCoord> G = new List<GaussCoord>();
            foreach (CoordConvert c in Data)
            {
                if(c.Selected)
                {
                    if (c.Gauss is null)
                    {
                        G.Add(c.Gauss);
                    }
                }
            }
            return G;
        }
    }
}
