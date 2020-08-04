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
        DataSet ds = new DataSet();
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

                for(int i = 0;i< TableListComboBox.Items.Count;i++)
                {
                    DBFile.GetTable(ds,(TableListComboBox.DataSource as DataTable).Rows[i]["TABLE_NAME"].ToString());
                }

                SelectedTableNameChanged(null, null);
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        //选中的表名更改
        private void SelectedTableNameChanged(object sender, EventArgs e)
        {
            try
            {
                tn = ((TableListComboBox.DataSource as DataTable).Rows[TableListComboBox.SelectedIndex]["TABLE_NAME"].ToString());
                DGV.DataSource = ds.Tables[tn];
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        //重载表数据
        private void ReloadTable(object sender, EventArgs e)
        {
            DBFile.GetTable(ds,tn);
        }

        //添加行
        private void AddRow(object sender, EventArgs e)
        {
            ds.Tables[tn].Rows.Add();
        }

        //删除行
        private void DelRow(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dr = DGV.SelectedRows;
            for (int i = 0; i < dr.Count; i++)
            {
                ds.Tables[tn].Rows.RemoveAt(dr[i].Index);
            }
        }

        //保存更改
        private async void SaveChanges(object sender, EventArgs e)
        {
            try
            {
               await Task.Run(()=> DBFile.SaveEdit(ds,tn));
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }
    }
}
