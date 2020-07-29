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
        public BindingList<CoordConvert> bl= new BindingList<CoordConvert>();

        public CoordConvertLayout()
        {
            InitializeComponent();
        }

        private void CoordConvertLayout_Load(object sender, EventArgs e)
        {
            //cols = CoordConvertDataGridView.Columns;
            //bs.DataSource = ConvertData;
            //CoordConvertDataGridView.DataSource = bs;

            //bs.DataMember ="CoordConvert";
            CoordConvertDGV.Columns.Clear();
            CoordConvertDGV.DataSource = bl;
            CoordConvertDGV.AutoGenerateColumns = true;
        }

        private void LoadData(object sender, EventArgs e)
        {
            LoadData();
            return;
            CoordConvertDGV.Rows.Clear();
            for (int i = 0; i < ConvertData.Count; i++)
            {
                CoordConvertDGV.Rows.Add();
            }
        }

        private void SaveData(object sender, EventArgs e)
        {
            SaveData();
        }

        public void LoadData()
        {
             bl=new BindingList<CoordConvert>(DataFile.LoadCoordConvertData());
            CoordConvertDGV.DataSource = bl;
        }

        public void SaveData()
        {
            DataFile.SaveCoordConvertData(bl.ToList());
        }

        private void CoordConvertDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CoordConvertDGV.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                return;
                string s = CoordConvertDGV.Columns[e.ColumnIndex].Name;
                Type t = ConvertData[e.RowIndex].GetType();
                PropertyInfo f = t.GetProperty(s);
                f.SetValue(ConvertData[e.RowIndex], CoordConvertDGV[e.ColumnIndex, e.RowIndex].Value);
            }
            catch (Exception err)
            {
                CoordConvertDGV[e.ColumnIndex, e.RowIndex].Value = ConvertData[e.RowIndex].GetType().GetProperty(CoordConvertDGV.Columns[e.ColumnIndex].Name).GetValue(ConvertData[e.RowIndex]);
                Trace.TraceError(err.ToString());
            }
        }

        private void AddRow(object sender, EventArgs e)
        {
            //DataGridViewRow row = new DataGridViewRow();
            //ConvertData.Add(new CoordConvert());

            //CoordConvertDataGridView.Rows.Add(row);
            bl.Add(new CoordConvert());
        }

        private void CoordConvertDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            return;
            int count = e.RowCount;
            DataGridViewRow row =CoordConvertDGV.Rows[e.RowIndex];
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

        private void DeleteRow(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dr = CoordConvertDGV.SelectedRows;
            for(int i = 0;i<dr.Count;i++)
            {
                CoordConvertDGV.Rows.RemoveAt(dr[i].Index);
            }
        }

        private void DirectBtn_Click(object sender, EventArgs e)
        {
            for(int i = 0;i<bl.Count;i++)
            {
                CoordConvertDGV.Rows[i].DefaultCellStyle.BackColor = bl[i].GaussDirect()?Color.Green:Color.Red;
            }
            CoordConvertDGV.Invalidate();
        }

        private void ReverseBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bl.Count; i++)
            {
                CoordConvertDGV.Rows[i].DefaultCellStyle.BackColor = bl[i].GaussReverse() ? Color.Green : Color.Red;
            }
            CoordConvertDGV.Invalidate();
        }

        private void ResetColor()
        {
           
            for (int i = 0; i < bl.Count; i++)
            {
                DataGridViewCellStyle C = CoordConvertDGV.Rows[i].DefaultCellStyle;
                C.BackColor = (C.BackColor == Color.Green) ? Color.White : C.BackColor;
            }
        }
    }
}
