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
using System.Resources;

namespace GeodeticCoordinateConversion
{
    public partial class ConvertCtrl : UserControl
    {
        private string hint;
        public string Hint
        {
            get => hint;
            set
            {
                HintChangedEventArgs e = new HintChangedEventArgs(hint, value);
                hint = value;
                HintChanged?.Invoke(this, e);
            }
        }
        public static ResourceManager rm = new ResourceManager(Constants.ResourceSpace, Assembly.GetExecutingAssembly());

        public delegate void ConvertSelectionChangeEventHander(object sender, string tag, EventArgs e);
        public event ConvertSelectionChangeEventHander ConvertSelectionChange;

        public ConvertCtrl()
        {
            InitializeComponent();

            #region Multi-language
            SelectAllBtn.Text = rm.GetString("SelectAll");
            SelectNoneBtn.Text = rm.GetString("SelectNone");
            InvertSelectBtn.Text = rm.GetString("InvertSelect");
            BtnToolTip.SetToolTip(AddRowBtn, rm.GetString("AddNewRow"));
            BtnToolTip.SetToolTip(DeleteBtn, rm.GetString("DeleteRow"));
            BtnToolTip.SetToolTip(LoadFileBtn, rm.GetString("LoadFile"));
            BtnToolTip.SetToolTip(SaveFileBtn, rm.GetString("SaveFile"));
            BtnToolTip.SetToolTip(LoadDBBtn, rm.GetString("LoadDB"));
            BtnToolTip.SetToolTip(SaveDBBtn, rm.GetString("SaveDB"));
            BtnToolTip.SetToolTip(TransferBtn, rm.GetString("TransferToZoneConvert"));
            #endregion

        }

        #region Events
        public delegate void HintChangedEventHandler(object sender, HintChangedEventArgs e);
        public event HintChangedEventHandler HintChanged;
        #endregion

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

            DataStatus o = (DGV.DataSource as BindingList<CoordConvert> != null)
                ? ((DGV.DataSource as BindingList<CoordConvert>)[row] as DataStatus)
                : ((DGV.DataSource as BindingList<ZoneConvert>)[row] as DataStatus);

            Properties.Settings S = new Properties.Settings();

            DGV.Rows[row].Cells[nameof(DataStatus.Selected)].Style.BackColor =
                    o.Selected ? S.SelectedColor : S.DefaultCellColor;
            DGV.Rows[row].Cells[nameof(DataStatus.Error)].Style.BackColor =
                    (o.Dirty || (!o.Calculated)) ? S.DefaultCellColor : (o.Error ? S.ErrorColor : S.CorrectColor);
            DGV.Rows[row].Cells[nameof(DataStatus.Dirty)].Style.BackColor =
                    o.Dirty ? S.DirtyColor : S.DefaultCellColor;
            DGV.Rows[row].Cells[nameof(DataStatus.Calculated)].Style.BackColor =
                   o.Calculated ? S.CalculatedColor : S.DefaultCellColor;
        }

        private void ChangeSelection(object sender, EventArgs e)
        {
            ConvertSelectionChange?.Invoke(this, (sender as Button).Tag.ToString(), e);
        }

        private void DGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Hint = e.Exception?.InnerException?.Message.Replace("\r\n", " ")??e.Exception.Message.Replace("\r\n", " ");
        }
    }
}
