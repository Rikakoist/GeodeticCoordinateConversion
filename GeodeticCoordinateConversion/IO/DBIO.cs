using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;
using ADOX;
using System.Runtime.InteropServices;
using GeodeticCoordinateConversion.Properties;

namespace GeodeticCoordinateConversion
{
    public sealed class DBIO
    {
        /// <summary>
        /// 全局唯一ID。
        /// </summary>
        public static readonly Guid UID = Guid.NewGuid();

        /// <summary>
        /// 配置文件。
        /// </summary>
        private static Settings AppSettings = new Settings();

        /// <summary>
        /// 数据库文件存放的目录（私有）。
        /// </summary>
        private string dbPath;
        /// <summary>
        /// 数据库文件名称（私有）。
        /// </summary>
        private string dbName;
        /// <summary>
        /// 数据库文件存放的目录。
        /// </summary>
        public string DBPath
        {
            get => Path.Combine(dbPath, dbName);
            set
            {
                try
                {
                    if (!File.Exists(value))
                        throw new FileNotFoundException(ErrMessage.Generic.FileNotFound);
                    dbPath = Path.GetDirectoryName(value);
                    dbName = Path.GetFileName(value);
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
                this.dbPath = AppSettings.WorkFolder;
                this.dbName = AppSettings.DBName;
                CheckDBExists();
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
        public DBIO(string DBPath, string DBName)
        {
            try
            {
                this.dbPath = DBPath;
                this.dbName = DBName;
                CheckDBExists();
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
                byte[] DBResource = new byte[DBStream.Length];
                DBStream.Read(DBResource, 0, (int)DBStream.Length);
                var DBFileStream = new FileStream(DBPath, FileMode.Create);
                DBFileStream.Write(DBResource, 0, (int)DBStream.Length);
                DBFileStream.Close();
            }
        }

        /// <summary>
        /// 检查GUID在对应表中是否存在。
        /// </summary>
        /// <param name="TableName">表名。</param>
        /// <param name="guid">要检查的GUID。</param>
        /// <returns>是否存在。</returns>
        public bool GUIDExists(string TableName, Guid guid)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionInfo))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand
                {
                    CommandText = "SELECT UID FROM " + TableName + " WHERE UID = @UID",
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@UID", guid.ToString());
                OleDbDataReader R = cmd.ExecuteReader();
                return R.HasRows;
            }
        }

        /// <summary>
        /// 返回指定表中该GUID的第一条记录。
        /// </summary>
        /// <param name="TableName">表名。</param>
        /// <param name="guid">要查询的GUID。</param>
        /// <returns>包含数据的记录行。</returns>
        public DataRow SelectByGUID(string TableName, Guid guid)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionInfo))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand
                {
                    CommandText = "SELECT * FROM " + TableName + " WHERE UID = @UID",
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@UID", guid.ToString());
                OleDbDataAdapter Adapter = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                Adapter.Fill(dt);
                return dt.Rows[0];
            }
        }

        /// <summary>
        /// 保存坐标转换数据到数据库。
        /// </summary>
        /// <param name="Data">要保存的数据。</param>
        /// <param name="ClearExistingRecord">是否清除已有记录。</param>
        /// <returns>操作结果。</returns>
        public bool SaveCoordConvertData(List<CoordConvert> Data, bool ClearExistingRecord = true)
        {
            if (Data.Count <= 0)
                return false;
            if (ClearExistingRecord)
            {
                using (OleDbConnection con = new OleDbConnection(ConnectionInfo))
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand
                    {
                        CommandText = "DELETE * FROM CoordConvert",
                        Connection = con
                    };
                    cmd.ExecuteNonQuery();
                }
            }
            foreach (CoordConvert c in Data)
            {
                c.SaveToDB();
            }
            return true;
        }

        /// <summary>
        /// 从数据库读取坐标转换数据。
        /// </summary>
        /// <returns>读取的列表。</returns>
        public List<CoordConvert> LoadCoordConvertData()
        {
            List<CoordConvert> Data = new List<CoordConvert>();
            using (OleDbConnection con = new OleDbConnection(ConnectionInfo))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand
                {
                    CommandText = "SELECT UID FROM CoordConvert",
                    Connection = con
                };
                OleDbDataAdapter Adapter = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                Adapter.Fill(dt);

                foreach (DataRow r in dt.Rows)
                {
                    Data.Add(new CoordConvert(Guid.Parse(r["UID"].ToString())));
                }
            }
            return Data;
        }

        /// <summary>
        /// 保存换带数据到数据库。
        /// </summary>
        /// <param name="Data">要保存的数据。</param>
        /// <param name="ClearExistingRecord">是否清除已有记录。</param>
        /// <returns>操作结果。</returns>
        public bool SaveZoneConvertData(List<ZoneConvert> Data, bool ClearExistingRecord = true)
        {
            if (Data.Count <= 0)
                return false;
            if (ClearExistingRecord)
            {
                using (OleDbConnection con = new OleDbConnection(ConnectionInfo))
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand
                    {
                        CommandText = "DELETE * FROM ZoneConvert",
                        Connection = con
                    };
                    cmd.ExecuteNonQuery();
                }
            }
            foreach (ZoneConvert c in Data)
            {
                c.SaveToDB();
            }
            return true;
        }

        /// <summary>
        /// 从数据库读取换带数据。
        /// </summary>
        /// <returns>读取的列表。</returns>
        public List<ZoneConvert> LoadZoneConvertData()
        {
            List<ZoneConvert> Data = new List<ZoneConvert>();
            using (OleDbConnection con = new OleDbConnection(ConnectionInfo))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand
                {
                    CommandText = "SELECT UID FROM ZoneConvert",
                    Connection = con
                };
                OleDbDataAdapter Adapter = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                Adapter.Fill(dt);

                foreach (DataRow r in dt.Rows)
                {
                    Data.Add(new ZoneConvert(Guid.Parse(r["UID"].ToString())));
                }
            }
            return Data;
        }

        /// <summary>
        /// 获取数据库中的表列表。
        /// </summary>
        /// <returns>数据库表结构的数据表。</returns>
        public DataTable GetTableList()
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionInfo))
            {
                con.Open();
                return con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
            }
        }

        /// <summary>
        /// 根据表名，从数据库中查询对应表并填充到数据表中。
        /// </summary>
        /// <param name="TableName">表名。</param>
        /// <returns>包含全部表内容的数据表。</returns>
        public DataTable GetTable(string TableName)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionInfo))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand
                {
                    CommandText = "SELECT * FROM " + TableName,
                    Connection = con
                };
                OleDbDataAdapter Adapter = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable
                {
                    TableName = TableName
                };

                Adapter.Fill(dt);

                return dt;
            }
        }

        /// <summary>
        /// 根据表名，从数据库中查询对应表并填充到数据集中。
        /// </summary>
        /// <param name="DS">数据集，需初始化。</param>
        /// <param name="TableName">表名。</param>
        /// <returns></returns>
        public bool GetTable(DataSet DS, string TableName)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionInfo))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand
                {
                    CommandText = "SELECT * FROM " + TableName,
                    Connection = con
                };
                OleDbDataAdapter Adapter = new OleDbDataAdapter(cmd);
                if (DS.Tables[TableName] != null)
                {
                    DS.Tables[TableName].Clear();
                }
                Adapter.Fill(DS, TableName);
                return true;
            }
        }

        /// <summary>
        /// 保存更改。
        /// </summary>
        /// <param name="DS">更改的数据集。</param>
        /// <param name="TableName">表名。</param>
        /// <returns></returns>
        public int SaveEdit(DataSet DS, string TableName)
        {
            using (OleDbConnection con = new OleDbConnection(ConnectionInfo))
            {
                con.Open();
                OleDbDataAdapter Adapter = new OleDbDataAdapter("SELECT * FROM " + TableName, con);
                OleDbCommandBuilder cb = new OleDbCommandBuilder(Adapter);
                Adapter.DeleteCommand = cb.GetDeleteCommand();
                Adapter.InsertCommand = cb.GetInsertCommand();
                Adapter.UpdateCommand = cb.GetUpdateCommand();
                return Adapter.Update(DS, TableName);
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
