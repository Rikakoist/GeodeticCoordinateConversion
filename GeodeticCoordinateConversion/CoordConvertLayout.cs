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

namespace GeodeticCoordinateConversion
{
    public partial class CoordConvertLayout : UserControl
    {
        private GEOSettings AppSettings = new GEOSettings();
        private FileIO DataFile = new FileIO();
        public List<CoordConvert> ConvertData = new List<CoordConvert>();
        private BindingSource bs = new BindingSource();

        public CoordConvertLayout()
        {
            InitializeComponent();
           
            DataTable table = GEODataTables.GetZoneType();
            this.ZoneType.DataSource = table;
            this.ZoneType.DataPropertyName = "Text";
            //BindingSource bindingSource = new BindingSource();

            //.DataBindings.Add("Text", bindingSource, nameof(GEOZoneType));
        }

        private void CoordConvertLayout_Load(object sender, EventArgs e)
        {
            //cols = CoordConvertDataGridView.Columns;
            //bs.DataSource = ConvertData;
            //CoordConvertDataGridView.DataSource = bs;
            //CoordConvertDataGridView.AutoGenerateColumns = true;     
            //bs.DataMember ="CoordConvert";
        }

        private void LoadData(object sender, EventArgs e)
        {
            LoadData();
            CoordConvertDataGridView.Rows.Clear();
            for (int i = 0; i < ConvertData.Count; i++)
            {
                CoordConvertDataGridView.Rows.Add();
            }
        }

        private void SaveData(object sender, EventArgs e)
        {
            SaveData();
        }

        public void LoadData()
        {
             DataFile.LoadCoordConvertData(ConvertData);
        }

        public void SaveData()
        {
            DataFile.SaveCoordConvertData(ConvertData);
        }

        private void CoordConvertDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string s = CoordConvertDataGridView.Columns[e.ColumnIndex].Name;
                Type t = ConvertData[e.RowIndex].GetType();
                PropertyInfo f = t.GetProperty(s);
                f.SetValue(ConvertData[e.RowIndex], CoordConvertDataGridView[e.ColumnIndex, e.RowIndex].Value);
            }
            catch (Exception err)
            {
                CoordConvertDataGridView[e.ColumnIndex, e.RowIndex].Value = ConvertData[e.RowIndex].GetType().GetProperty(CoordConvertDataGridView.Columns[e.ColumnIndex].Name).GetValue(ConvertData[e.RowIndex]);
                Trace.TraceError(err.ToString());
            }
        }

        private void AddRow(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            ConvertData.Add(new CoordConvert());

            CoordConvertDataGridView.Rows.Add(row);
        }

        private void CoordConvertDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int count = e.RowCount;
            DataGridViewRow row =CoordConvertDataGridView.Rows[e.RowIndex];
            CoordConvert c = ConvertData[e.RowIndex];
            row.SetValues(c.B,c.L, "", "", c.X, c.Y, c.Zone, "");

        }

        private void DeleteRow(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView D = sender as DataGridView;
            if (D.CurrentCell is DataGridViewButtonCell)
            {
                string s = D.Columns[e.ColumnIndex].Name;
                if (s == "Delete")
                {
                    D.Rows.RemoveAt(e.RowIndex);
                    ConvertData.RemoveAt(e.RowIndex);
                }
            }
        }

        private void EditComboBox(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView D = sender as DataGridView;

            if (D.CurrentCell is DataGridViewComboBoxCell)
            {
                ComboBox C = e.Control as ComboBox;
                
                C.SelectedIndexChanged+= new EventHandler(ChangeComboBoxIndex);
            }
        }

        public void ChangeComboBoxIndex(object sender, EventArgs e)
        {

            ComboBox c = sender as ComboBox;

            c.Leave += new EventHandler(EndEditComboBox);
            try
            {
                //在这里就可以做值是否改变判断
                if (c.SelectedItem != null)
                {
                    
                }
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EndEditComboBox(object sender, EventArgs e)
        {
            ComboBox c= sender as ComboBox;
            c.SelectedIndexChanged -= new EventHandler(ChangeComboBoxIndex);
        }
    }
}
