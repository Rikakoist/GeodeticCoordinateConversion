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
using System.Resources;
using System.Reflection;

namespace GeodeticCoordinateConversion
{
    public partial class TableViewCtrl : UserControl
    {
        DataSet ds = new DataSet();
        public static ResourceManager rm = new ResourceManager(Constants.ResourceSpace, Assembly.GetExecutingAssembly());

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

            #region Multi-language
            TableLabel.Text = rm.GetString("DataTable");
            CtrlToolTip.SetToolTip(ReloadTableBtn, rm.GetString("ReloadTable"));
            CtrlToolTip.SetToolTip(SaveDBToFileBtn, rm.GetString("SaveDBToFile"));
            CtrlToolTip.SetToolTip(LoadDBFromFileBtn, rm.GetString("LoadDBFromFile"));
            CtrlToolTip.SetToolTip(SaveDBChangesBtn, rm.GetString("SaveTableChanges"));
            CtrlToolTip.SetToolTip(AddRowBtn, rm.GetString("AddNewRecordToTable"));
            CtrlToolTip.SetToolTip(DeleteBtn, rm.GetString("DeleteSelectedRecord"));
            #endregion

            CheckForIllegalCrossThreadCalls = false;
        }

        #region Methods
        //加载时填充表名
        private async void DBLoad(object sender, EventArgs e)
        {
            try
            {
                TableListComboBox.DataSource = DBIO.GetTableList();
                TableListComboBox.DisplayMember = "DESCRIPTION";
                TableListComboBox.ValueMember = "TABLE_NAME";

                Hint = Hints.TableListLoaded(TableListComboBox.Items.Count);

                for (int i = 0; i < TableListComboBox.Items.Count; i++)
                {
                    await Task.Run(() => DBIO.GetTable(ds, (TableListComboBox.DataSource as DataTable).Rows[i]["TABLE_NAME"].ToString()));
                }
                SelectedTableNameChanged(null, null);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
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
                MessageBox.Show(err.ToString());
            }
        }

        //重载表数据
        private void ReloadTable(object sender, EventArgs e)
        {
            DBIO.GetTable(ds, tn);
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
                await Task.Run(() => DBIO.SaveEdit(ds, tn));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
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
                FileName = new Settings().DataFileName,
                Filter = "XML files (*.xml)|*.xml",
                Title = rm.GetString("SelectSavePos"),
            };
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                FileIO F = new FileIO(Path.GetDirectoryName(SFD.FileName), Path.GetFileName(SFD.FileName));
                List<CoordConvert> C = DBIO.LoadCoordConvertData();
                F.SaveCoordConvertData(C, new Settings().ClearExistingRecordDB2File);
                List<ZoneConvert> Z = DBIO.LoadZoneConvertData();
                F.SaveZoneConvertData(Z, new Settings().ClearExistingRecordDB2File);
                Hint = Hints.DBSavedToFile(C?.Count, Z?.Count);
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
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xml",
                FileName = new Settings().DataFileName,
                Filter = "XML files (*.xml)|*.xml",
                Title = rm.GetString("SelectDataFile"),
            };
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                FileIO F = new FileIO(Path.GetDirectoryName(OFD.FileName), Path.GetFileName(OFD.FileName));
                List<CoordConvert> C = F.LoadCoordConvertData();
                DBIO.SaveCoordConvertData(C, new Settings().ClearExistingRecordFile2DB);
                List<ZoneConvert> Z = F.LoadZoneConvertData();
                DBIO.SaveZoneConvertData(Z, new Settings().ClearExistingRecordFile2DB);
                Hint = Hints.FileSavedToDB(C?.Count, Z?.Count);
            }
            else
            {
                Hint = Hints.OperationCanceled;
            }
        }
    }
}
