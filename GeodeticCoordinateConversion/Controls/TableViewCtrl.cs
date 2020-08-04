using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace GeodeticCoordinateConversion
{
    public partial class TableViewCtrl : UserControl
    {
        DBIO DBFile = new DBIO();
        OleDbDataAdapter Adapter;
        DataTable ds;
        string tn;

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

        public void GetFullTable(string TableName)
        {
            using (OleDbConnection con = new OleDbConnection(DBFile.ConnectionInfo))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand
                {
                    CommandText = "SELECT * FROM " + TableName,
                    Connection = con
                };
                Adapter = new OleDbDataAdapter(cmd);
                ds = new DataTable();
              

                Adapter.Fill(ds);
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
                tn= ((TableListComboBox.DataSource as DataTable).Rows[TableListComboBox.SelectedIndex]["TABLE_NAME"].ToString());
                await Task.Run(() => GetFullTable(tn));
                await Task.Run(() => DBDGV.DataSource = ds);            
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

        private void UpdateDB(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void SaveChanges(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(DBFile.ConnectionInfo))
                {
                    con.Open();
                    Adapter = new OleDbDataAdapter("SELECT * FROM "+tn, con);
                    OleDbCommandBuilder cb = new OleDbCommandBuilder(Adapter);
                    Adapter.DeleteCommand = cb.GetDeleteCommand();
                    Adapter.InsertCommand = cb.GetInsertCommand();
                    Adapter.UpdateCommand = cb.GetUpdateCommand();
                    int a = Adapter.Update(ds);
                }
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }
    }
}
