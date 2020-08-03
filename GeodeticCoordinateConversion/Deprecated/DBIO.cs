using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;
using GeodeticCoordinateConversion.Deprecated;
using ADOX;
using System.Runtime.InteropServices;

namespace GeodeticCoordinateConversion.Deprecated
{
    public sealed class DBIO
    {
        /// <summary>
        /// 全局唯一ID。
        /// </summary>
        public readonly Guid UID = Guid.NewGuid();

        /// <summary>
        /// 配置文件。
        /// </summary>
        private GEOSettings AppSettings = new GEOSettings();

        /// <summary>
        /// 数据库文件存放的目录（私有）。
        /// </summary>
        private string dbPath;
        /// <summary>
        /// 数据库文件存放的目录。
        /// </summary>
        public string DBPath
        {
            get => dbPath;
            set
            {
                try
                {
                    if (!Directory.Exists(value))
                        throw new DirectoryNotFoundException(ErrMessage.Generic.DirectoryNotFound);
                    dbPath = Path.Combine(value, AppSettings.DBName);
                    CheckDBExists();
                    this.DBPathChanged?.Invoke(this, null);
                }
                catch (Exception err)
                {
                    throw new DBPathException(ErrMessage.DB.SetDBPathFailed, err);
                }
            }
        }
        public string ConnectionInfo { get => "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + DBPath; }

        /// <summary>
        /// 默认的数据库管理构造函数，数据库路径为配置文件中路径。
        /// </summary>
        public DBIO()
        {
            try
            {
                this.DBPath = AppSettings.WorkFolder;
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.DB.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过数据库所在的文件夹路径初始化数据库管理对象。
        /// </summary>
        /// <param name="DBPath">数据库所在的文件夹路径。</param>
        public DBIO(string DBPath)
        {
            try
            {
                this.DBPath = DBPath;
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.DB.InitializeError, err);
            }
        }

        public delegate void DBPathChangedEventHander(object sender, EventArgs e);
        public event DBPathChangedEventHander DBPathChanged;

        /// <summary>
        /// 检查数据库是否存在，不存在则创建。
        /// </summary>
        private void CheckDBExists()
        {
            if (!File.Exists(DBPath))
            {
                System.Reflection.Assembly DBAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                var DBStream = DBAssembly.GetManifestResourceStream("GeodeticCoordinateConversion.GeoConvertDB.mdb");
                byte[] DBResource = new Byte[DBStream.Length];
                DBStream.Read(DBResource, 0, (int)DBStream.Length);
                var DBFileStream = new FileStream(DBPath, FileMode.Create);
                DBFileStream.Write(DBResource, 0, (int)DBStream.Length);
                DBFileStream.Close();
            }
        }

        //保存操作
        public void SaveToDB(string Insert)
        {
            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo))
            {
                Connection.Open();
                OleDbCommand Command = new OleDbCommand
                {
                    CommandText = Insert,
                    Connection = Connection
                };
                Command.ExecuteNonQuery();
            }
        }

        //读取操作
        public void ReadFromDB(string TableName, DataGridView Datas)
        {

            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo))
            {
                Connection.Open();
                OleDbCommand Command = new OleDbCommand
                {
                    CommandText = "SELECT * FROM " + TableName,
                    Connection = Connection
                };
                OleDbDataAdapter Adapter = new OleDbDataAdapter
                {
                    SelectCommand = Command
                };
                DataSet ReadData = new DataSet();
                Adapter.Fill(ReadData, TableName);
                Datas.DataSource = ReadData.Tables[TableName];
                Command.ExecuteReader();
            }
        }

        //查询操作
        public void ReadFromDB(string TableName, string QueryCommand, DataGridView Datas)
        {

            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo))
            {
                Connection.Open();
                OleDbCommand Command = new OleDbCommand
                {
                    CommandText = QueryCommand,
                    Connection = Connection
                };
                OleDbDataAdapter Adapter = new OleDbDataAdapter
                {
                    SelectCommand = Command
                };
                DataSet ReadData = new DataSet();
                Adapter.Fill(ReadData, TableName);
                Datas.DataSource = ReadData.Tables[TableName];
                Command.ExecuteReader();
            }
        }

        //读取到操作数据框的重载
        public DataSet ReadToDG(string TableName)
        {

            DataSet ReadData = new DataSet();
            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo))
            {
                Connection.Open();
                OleDbCommand Command = new OleDbCommand
                {
                    CommandText = "SELECT * FROM " + TableName,
                    Connection = Connection
                };
                OleDbDataAdapter Adapter = new OleDbDataAdapter
                {
                    SelectCommand = Command
                };

                Adapter.Fill(ReadData, TableName);
            }
            return ReadData;
        }

        //删除操作
        public void DeleteFromDB(string TableName, DataGridView Datas, int RowIndex)
        {

            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo))
            {
                Connection.Open();
                string DeleteRow = Datas.Rows[RowIndex].Cells[0].Value.ToString();
                OleDbCommand DeleteCommand = new OleDbCommand
                {
                    CommandText = "DELETE FROM " + TableName + " WHERE ID = " + DeleteRow,
                    Connection = Connection
                };
                DeleteCommand.ExecuteNonQuery();
                if (MessageBoxes.Success("删除第" + (RowIndex + 1).ToString() + "行数据成功！") == "OK")
                {
                    ReadFromDB(TableName, DBPath, Datas);
                }
            }
        }

        //插入操作
        public void InsertIntoDB(string TableName, DataGridView Datas, string Cols, string[] InputStringArray, int ColumnCount)
        {

            string Command = "INSERT INTO " + TableName + " " + Cols + " VALUES ('" + IO.DT() + "', ";
            for (int i = 0; i < ColumnCount; i++)
            {
                if (i < ColumnCount - 1)
                {
                    Command += InputStringArray[i] + ", ";
                }
                if (i == ColumnCount - 1)
                {
                    Command += InputStringArray[i] + ")";
                }
            }
            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo))
            {
                Connection.Open();
                OleDbCommand CreateCommand = new OleDbCommand
                {
                    CommandText = Command,
                    Connection = Connection
                };
                CreateCommand.ExecuteNonQuery();
                if (MessageBoxes.Success("插入成功！") == "OK")
                {
                    ReadFromDB(TableName, DBPath, Datas);
                }
            }
        }

        //更新操作
        public void UpdateDB(string TableName, DataGridView Datas, int ColumnIndex, int RowIndex)
        {

            using (OleDbConnection Connection = new OleDbConnection(ConnectionInfo))
            {
                Connection.Open();
                string UpdateCols = Datas.Columns[ColumnIndex].HeaderText;  //Get column header
                string UpdateRows = Datas.Rows[RowIndex].Cells[0].Value.ToString(); //Get the value of the first cell in the row focused
                string NewValue = Datas.CurrentCell.Value.ToString();   //Get the value of currently selected cell
                OleDbCommand Command = new OleDbCommand
                {
                    CommandText = "UPDATE " + TableName + " SET " + UpdateCols + " = " + NewValue + " WHERE ID = " + UpdateRows,
                    Connection = Connection
                };
                Command.ExecuteNonQuery();
            }
        }

        //检查行列数
        public void CheckElementsAndCols(int ElementNums, int Cols)
        {
            if (ElementNums != Cols)
            {
                throw new Exception("要插入的元素数量不正确，应为" + ElementNums + "个。");
            }
        }

        /// <summary>
        /// 数据库路径异常。
        /// </summary>
        [Serializable]
        public class DBPathException : Exception
        {
            public DBPathException() { }
            public DBPathException(string message) : base(message) { }
            public DBPathException(string message, Exception inner) : base(message, inner) { }
            protected DBPathException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
    }
}
