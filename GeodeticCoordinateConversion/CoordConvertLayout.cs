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
        }

        private void CoordConvertLayout_Load(object sender, EventArgs e)
        {
            //cols = CoordConvertDataGridView.Columns;
            //bs.DataSource = ConvertData;
            //CoordConvertDataGridView.DataSource = bs;
            //CoordConvertDataGridView.AutoGenerateColumns = true;     
            //bs.DataMember ="CoordConvert";
        }

        private void CoordConvertDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int count = e.RowCount;
            DataGridViewRow row =CoordConvertDataGridView.Rows[e.RowIndex];
            CoordConvert c = ConvertData[e.RowIndex];
            row.SetValues(c.BL.B.Value, c.BL.L.Value, "", "", c.Gauss.X, c.Gauss.Y, c.Gauss.Zone, "");
        }

        public void SaveData()
        {
            DataFile.CoordConvertDataToFile(ConvertData);
        }

        public void LoadData()
        {
            this.ConvertData = DataFile.FileToCoordConvertData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConvertData = DataFile.FileToCoordConvertData();
            CoordConvertDataGridView.Rows.Clear();
            for (int i = 0;i<ConvertData.Count;i++)
            {
                CoordConvertDataGridView.Rows.Add();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataFile.CoordConvertDataToFile(ConvertData);
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
            }
        }

        private void AddRow(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            ConvertData.Add(new CoordConvert());

            CoordConvertDataGridView.Rows.Add(row);
        }
    }
}
