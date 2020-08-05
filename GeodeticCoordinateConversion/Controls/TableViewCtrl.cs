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
using System.IO;
using GeodeticCoordinateConversion.Properties;

namespace GeodeticCoordinateConversion
{
    public partial class TableViewCtrl : UserControl
    {
        DBIO DBFile = new DBIO();
        DataSet ds = new DataSet();
        string tn;
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

        public TableViewCtrl()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        #region Methods
        //加载时填充表名
        private async void DBLoad(object sender, EventArgs e)
        {
            try
            {
                TableListComboBox.DataSource = DBFile.GetTableList();
                TableListComboBox.DisplayMember = "DESCRIPTION";
                TableListComboBox.ValueMember = "TABLE_NAME";

                Hint = Hints.TableListLoaded(TableListComboBox.Items.Count);

                for (int i = 0; i < TableListComboBox.Items.Count; i++)
                {
                    await Task.Run(() => DBFile.GetTable(ds, (TableListComboBox.DataSource as DataTable).Rows[i]["TABLE_NAME"].ToString()));
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
                Hint = Hints.TableRecordCount(TableListComboBox.Text, ds.Tables[tn]?.Rows.Count);
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }

        //重载表数据
        private void ReloadTable(object sender, EventArgs e)
        {
            DBFile.GetTable(ds, tn);
            Hint = Hints.TableReloaded(TableListComboBox.Text);
        }

        //添加行
        private void AddRow(object sender, EventArgs e)
        {
            ds.Tables[tn].Rows.Add();
            Hint = Hints.RowAdded();
        }

        //删除行
        private void DelRow(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dr = DGV.SelectedRows;
            int j = DGV.SelectedRows.Count;

            for (int i = 0; i < dr.Count; i++)
            {
                ds.Tables[tn].Rows[dr[i].Index].Delete();
            }
            ds.AcceptChanges();
            Hint = Hints.RowDeleted(j);
        }

        //保存更改
        private async void SaveChanges(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() => DBFile.SaveEdit(ds, tn));
            }
            catch (Exception err)
            {
                MessageBoxes.Error(err.ToString());
            }
        }
        #endregion

        #region Events
        public delegate void HintChangedEventHandler(object sender, HintChangedEventArgs e);
        public event HintChangedEventHandler HintChanged;
        #endregion

        private void SaveDBToFile(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog()
            {
                AddExtension = true,
                CheckPathExists = true,
                DefaultExt = "xml",
                FileName = new Properties.Settings().DataFileName,
                Filter = "XML files (*.xml)|*.xml",
                Title = "选择保存位置...",
            };
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                FileIO F = new FileIO(Path.GetDirectoryName(SFD.FileName), Path.GetFileName(SFD.FileName));
                List<CoordConvert> C = new DBIO().LoadCoordConvertData();
                F.SaveCoordConvertData(C,new Settings().ClearExistingRecordSaveDBToFile);
                List<ZoneConvert> Z = new DBIO().LoadZoneConvertData();
                F.SaveZoneConvertData(Z, new Settings().ClearExistingRecordSaveDBToFile);
                Hint = Hints.DBSavedToFile(C?.Count,Z?.Count);
            }
            else
            {
                Hint = Hints.OperationCanceled;
            }
        }

        private void LoadDBFromFile(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog()
            {
                AddExtension=true,
                CheckFileExists=true,
                CheckPathExists=true,
                DefaultExt = "xml",
                FileName = new Properties.Settings().DataFileName,
                Filter= "XML files (*.xml)|*.xml",
                Title="选择数据文件...",
            };
            if(OFD.ShowDialog()==DialogResult.OK)
            {
                FileIO F = new FileIO(Path.GetDirectoryName(OFD.FileName), Path.GetFileName(OFD.FileName));
                List<CoordConvert> C = F.LoadCoordConvertData();
                new DBIO().SaveCoordConvertData(C,new Settings().ClearExistingRecordSaveFileToDB);
                List<ZoneConvert> Z = F.LoadZoneConvertData();
                new DBIO().SaveZoneConvertData(Z, new Settings().ClearExistingRecordSaveFileToDB);
                Hint = Hints.FileSavedToDB(C?.Count,Z?.Count);
            }
            else
            {
                Hint = Hints.OperationCanceled;
            }
        }
    }
}
