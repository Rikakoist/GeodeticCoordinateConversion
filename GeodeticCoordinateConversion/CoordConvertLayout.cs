using System;
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
        public string Hint { get; private set; }

        public delegate void ConvertSelectionChangeEventHander(object sender,string tag, EventArgs e);
        public event ConvertSelectionChangeEventHander ConvertSelectionChange;

        public CoordConvertLayout()
        {
            InitializeComponent();
        }

        private void CoordConvertLayout_Load(object sender, EventArgs e)
        {
        }

        private void DGV_DataSourceChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in DGV.Rows)
            {
                ResetColor(r.Index);
            }
        }

        private void DGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ResetColor(e.RowIndex);
        }

        private void DeleteRow(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dr = DGV.SelectedRows;
            for (int i = 0; i < dr.Count; i++)
            {
                DGV.Rows.RemoveAt(dr[i].Index);
            }
        }

        private void DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ResetColor(e.RowIndex);
            }
            catch (Exception err)
            {
                Trace.TraceError(err.ToString());
            }
        }

        public void ResetColor(int row)
        {
            if (row >= DGV.Rows.Count)
                return;

            CalcObj o = (DGV.DataSource as BindingList<CoordConvert> != null)
                ? ((DGV.DataSource as BindingList<CoordConvert>)[row] as CalcObj)
                : ((DGV.DataSource as BindingList<ZoneConvert>)[row] as CalcObj);

            DGV.Rows[row].Cells[nameof(CalcObj.Selected)].Style.BackColor =
                    o.Selected ? Color.DarkGreen : Color.White;
            DGV.Rows[row].Cells[nameof(CalcObj.Error)].Style.BackColor =
                    (o.Dirty || (!o.Calculated)) ? Color.White : (o.Error ? Color.Red : Color.Green);
            DGV.Rows[row].Cells[nameof(CalcObj.Dirty)].Style.BackColor =
                    o.Dirty ? Color.RosyBrown : Color.White;
            DGV.Rows[row].Cells[nameof(CalcObj.Calculated)].Style.BackColor =
                   o.Calculated ? Color.ForestGreen : Color.White;
        }

        private void ChangeSelection(object sender, EventArgs e)
        {
            ConvertSelectionChange?.Invoke(this,(sender as Button).Tag.ToString(), e);
        }
    }
}
