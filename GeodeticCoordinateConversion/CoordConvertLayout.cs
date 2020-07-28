using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeodeticCoordinateConversion
{
    public partial class CoordConvertLayout : UserControl
    {
        private GEOSettings AppSettings = new GEOSettings();
        private FileIO DataFile = new FileIO();
        public List<CoordConvert> ConvertData = new List<CoordConvert>();
       

        
        public CoordConvertLayout()
        {
            InitializeComponent();
        }

        private void CoordConvertDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
        }

        public void SaveData()
        {
            DataFile.CoordConvertDataToFile(ConvertData);
        }

        public void LoadData()
        {
            this.ConvertData = DataFile.FileToCoordConvertData();
        }
    }
}
