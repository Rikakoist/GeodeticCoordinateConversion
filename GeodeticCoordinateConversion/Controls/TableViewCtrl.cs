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
    public partial class TableViewCtrl : UserControl
    {
        DBIO DBFile = new DBIO();

        public TableViewCtrl()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        //加载时填充表名
        private void DBLoad(object sender, EventArgs e)
        {
            try
            {
                TableListComboBox.DataSource = DBFile.GetTableList();
                TableListComboBox.DisplayMember = "DESCRIPTION";
                TableListComboBox.ValueMember = "TABLE_NAME";
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        //选中的表名更改
        private void SelectedTableNameChanged(object sender, EventArgs e)
        {
            ReloadTable(this, e);
        }

        //重载表数据
        private async void ReloadTable(object sender, EventArgs e)
        {
            try
            {
                DBDGV.DataSource = await Task.Run(() => DBFile.GetFullTable(((TableListComboBox.DataSource as DataTable).Rows[TableListComboBox.SelectedIndex]["TABLE_NAME"]).ToString()));
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        private void AddRow(object sender, EventArgs e)
        {

        }

        private void DelRow(object sender, EventArgs e)
        {

        }
    }
}
