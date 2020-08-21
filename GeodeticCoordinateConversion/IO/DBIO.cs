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
using System.Resources;
using System.Reflection;

namespace GeodeticCoordinateConversion
{
    public static class DBIO
    {
        /// <summary>
        /// 全局唯一ID。
        /// </summary>
        public static readonly Guid UID = Guid.NewGuid();
        /// <summary>
        /// 数据库文件存放的目录（私有）。
        /// </summary>
        public static string dbPath = new Settings().WorkFolder;
        /// <summary>
        /// 数据库文件名称（私有）。
        /// </summary>
        public static string dbName = new Settings().DBName;
        /// <summary>
        /// 数据库文件存放的完整路径。
        /// </summary>
        public static string DBPath
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
                    DBPathChanged?.Invoke(DBPath, null);
                }
                catch (Exception err)
                {
                    throw new DBPathException(ErrMessage.DB.SetDBPathFailed, err);
                }
            }
        }
        public static string ConnectionInfo { get => "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + DBPath; }
        public static OleDbConnection con = new OleDbConnection(ConnectionInfo);

        public delegate void DBPathChangedEventHander(object sender, EventArgs e);
        public static event DBPathChangedEventHander DBPathChanged;

        /// <summary>
        /// 检查数据库是否存在，不存在则创建。
        /// </summary>
        public static void CheckDBExists()
        {
            if (!File.Exists(DBPath))
            {
                #region Create database using ADOX
                Catalog C = new Catalog();
                C.Create(ConnectionInfo);

                ADODB.Connection Conn = new ADODB.Connection();
                Conn.Open(ConnectionInfo);
                C.ActiveConnection = Conn;

                //坐标转换数据表
                Table CoordTab = new Table
                {
                    Name = nameof(CoordConvert),
                    ParentCatalog = C
                };
                CoordTab.Columns.Append(nameof(UIDClass.UID), DataTypeEnum.adGUID);
                CoordTab.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, nameof(UIDClass.UID), null, null);
                CoordTab.Columns.Append(nameof(DataStatus.Selected), DataTypeEnum.adBoolean);
                CoordTab.Columns.Append(nameof(DataStatus.Dirty), DataTypeEnum.adBoolean);
                CoordTab.Columns.Append(nameof(DataStatus.Calculated), DataTypeEnum.adBoolean);
                CoordTab.Columns.Append(nameof(DataStatus.Error), DataTypeEnum.adBoolean);
                CoordTab.Columns.Append(nameof(CoordConvert.BL), DataTypeEnum.adGUID);
                CoordTab.Columns.Append(nameof(CoordConvert.Gauss), DataTypeEnum.adGUID);

                CoordTab.Columns[nameof(UIDClass.UID)].Properties["Description"].Value = DBStr.CoordConvert.UID;
                CoordTab.Columns[nameof(DataStatus.Selected)].Properties["Description"].Value = DBStr.DataStatus.Selected;
                CoordTab.Columns[nameof(DataStatus.Dirty)].Properties["Description"].Value = DBStr.DataStatus.Dirty;
                CoordTab.Columns[nameof(DataStatus.Calculated)].Properties["Description"].Value = DBStr.DataStatus.Calculated;
                CoordTab.Columns[nameof(DataStatus.Error)].Properties["Description"].Value = DBStr.DataStatus.Error;
                CoordTab.Columns[nameof(CoordConvert.BL)].Properties["Description"].Value = DBStr.CoordConvert.BL;
                CoordTab.Columns[nameof(CoordConvert.Gauss)].Properties["Description"].Value = DBStr.CoordConvert.Gauss;
                C.Tables.Append(CoordTab);

                //换带数据表
                Table ZoneTab = new Table
                {
                    Name = nameof(ZoneConvert),
                    ParentCatalog = C
                };
                ZoneTab.Columns.Append(nameof(UIDClass.UID), DataTypeEnum.adGUID);
                ZoneTab.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, nameof(UIDClass.UID), null, null);
                ZoneTab.Columns.Append(nameof(DataStatus.Selected), DataTypeEnum.adBoolean);
                ZoneTab.Columns.Append(nameof(DataStatus.Dirty), DataTypeEnum.adBoolean);
                ZoneTab.Columns.Append(nameof(DataStatus.Calculated), DataTypeEnum.adBoolean);
                ZoneTab.Columns.Append(nameof(DataStatus.Error), DataTypeEnum.adBoolean);
                ZoneTab.Columns.Append(nameof(ZoneConvert.Gauss6), DataTypeEnum.adGUID);
                ZoneTab.Columns.Append(nameof(ZoneConvert.Gauss3), DataTypeEnum.adGUID);

                ZoneTab.Columns[nameof(UIDClass.UID)].Properties["Description"].Value = DBStr.ZoneConvert.UID;
                ZoneTab.Columns[nameof(DataStatus.Selected)].Properties["Description"].Value = DBStr.DataStatus.Selected;
                ZoneTab.Columns[nameof(DataStatus.Dirty)].Properties["Description"].Value = DBStr.DataStatus.Dirty;
                ZoneTab.Columns[nameof(DataStatus.Calculated)].Properties["Description"].Value = DBStr.DataStatus.Calculated;
                ZoneTab.Columns[nameof(DataStatus.Error)].Properties["Description"].Value = DBStr.DataStatus.Error;
                ZoneTab.Columns[nameof(ZoneConvert.Gauss6)].Properties["Description"].Value = DBStr.ZoneConvert.Gauss6;
                ZoneTab.Columns[nameof(ZoneConvert.Gauss3)].Properties["Description"].Value = DBStr.ZoneConvert.Gauss3;
                C.Tables.Append(ZoneTab);

                //高斯坐标表
                Table GaussTab = new Table
                {
                    Name = nameof(GaussCoord),
                    ParentCatalog = C
                };
                GaussTab.Columns.Append(nameof(UIDClass.UID), DataTypeEnum.adGUID);
                GaussTab.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, nameof(UIDClass.UID), null, null);
                GaussTab.Columns.Append(nameof(GaussCoord.X), DataTypeEnum.adDouble);
                GaussTab.Columns.Append(nameof(GaussCoord.Y), DataTypeEnum.adDouble);
                GaussTab.Columns.Append(nameof(Ellipse.EllipseType), DataTypeEnum.adInteger);
                GaussTab.Columns.Append(nameof(GaussCoord.ZoneType), DataTypeEnum.adInteger);
                GaussTab.Columns.Append(nameof(GaussCoord.Zone), DataTypeEnum.adInteger);

                GaussTab.Columns[nameof(GaussCoord.UID)].Properties["Description"].Value = DBStr.GaussCoord.UID;
                GaussTab.Columns[nameof(GaussCoord.X)].Properties["Description"].Value = DBStr.GaussCoord.X;
                GaussTab.Columns[nameof(GaussCoord.Y)].Properties["Description"].Value = DBStr.GaussCoord.Y;
                GaussTab.Columns[nameof(Ellipse.EllipseType)].Properties["Description"].Value = DBStr.GaussCoord.EllipseType;
                GaussTab.Columns[nameof(GaussCoord.ZoneType)].Properties["Description"].Value = DBStr.GaussCoord.ZoneType;
                GaussTab.Columns[nameof(GaussCoord.Zone)].Properties["Description"].Value = DBStr.GaussCoord.Zone;
                C.Tables.Append(GaussTab);

                //地理经纬度表
                Table GEOBLTab = new Table
                {
                    Name = nameof(GEOBL),
                    ParentCatalog = C
                };
                GEOBLTab.Columns.Append(nameof(UIDClass.UID), DataTypeEnum.adGUID);
                GEOBLTab.Keys.Append("PrimaryKey", KeyTypeEnum.adKeyPrimary, nameof(UIDClass.UID), null, null);
                GEOBLTab.Columns.Append(nameof(GEOBL.B), DataTypeEnum.adVarWChar);
                GEOBLTab.Columns.Append(nameof(GEOBL.L), DataTypeEnum.adVarWChar);
                GEOBLTab.Columns.Append(nameof(Ellipse.EllipseType), DataTypeEnum.adInteger);
                GEOBLTab.Columns.Append(nameof(GEOBL.ZoneType), DataTypeEnum.adInteger);

                GEOBLTab.Columns[nameof(GEOBL.UID)].Properties["Description"].Value = DBStr.GEOBL.UID;
                GEOBLTab.Columns[nameof(GEOBL.B)].Properties["Description"].Value = DBStr.GEOBL.B;
                GEOBLTab.Columns[nameof(GEOBL.L)].Properties["Description"].Value = DBStr.GEOBL.L;
                GEOBLTab.Columns[nameof(Ellipse.EllipseType)].Properties["Description"].Value = DBStr.GEOBL.EllipseType;
                GEOBLTab.Columns[nameof(GEOBL.ZoneType)].Properties["Description"].Value = DBStr.GEOBL.ZoneType;
                C.Tables.Append(GEOBLTab);

                Conn.Close();
                #endregion

                //Add table description using DAO.
                DAO.Database DB = new DAO.DBEngine().OpenDatabase(DBPath);
                DAO.TableDef CoordDef =DB.TableDefs[nameof(CoordConvert)];
                CoordDef.Properties.Append(CoordDef.CreateProperty("Description", DAO.DataTypeEnum.dbText, DBStr.CoordConvert.Description));
                DAO.TableDef ZoneDef = DB.TableDefs[nameof(ZoneConvert)];
                ZoneDef.Properties.Append(ZoneDef.CreateProperty("Description", DAO.DataTypeEnum.dbText, DBStr.ZoneConvert.Description));
                DAO.TableDef GaussDef = DB.TableDefs[nameof(GaussCoord)];
                GaussDef.Properties.Append(GaussDef.CreateProperty("Description", DAO.DataTypeEnum.dbText, DBStr.GaussCoord.Description));
                DAO.TableDef BLDef = DB.TableDefs[nameof(GEOBL)];
                BLDef.Properties.Append(BLDef.CreateProperty("Description", DAO.DataTypeEnum.dbText, DBStr.GEOBL.Description));
            }
        }

        /// <summary>
        /// 开启连接。
        /// </summary>
        /// <returns>操作结果。</returns>
        public static bool OpenConnection()
        {
            try
            {
                con.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 关闭连接。
        /// </summary>
        /// <returns>操作结果。</returns>
        public static bool CloseConnection()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 检查GUID在对应表中是否存在。
        /// </summary>
        /// <param name="TableName">表名。</param>
        /// <param name="guid">要检查的GUID。</param>
        /// <returns>是否存在。</returns>
        public static bool GUIDExists(string TableName, Guid guid)
        {
            OleDbCommand cmd = new OleDbCommand
            {
                CommandText = "SELECT UID FROM " + TableName + " WHERE UID = @UID",
                Connection = con
            };
            cmd.Parameters.AddWithValue("@UID", guid.ToString());
            OleDbDataReader R = cmd.ExecuteReader();
            return R.HasRows;
        }

        /// <summary>
        /// 返回指定表中该GUID的第一条记录。
        /// </summary>
        /// <param name="TableName">表名。</param>
        /// <param name="guid">要查询的GUID。</param>
        /// <returns>包含数据的记录行。</returns>
        public static DataRow SelectByGUID(string TableName, Guid guid)
        {
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

        /// <summary>
        /// 保存坐标转换数据到数据库。
        /// </summary>
        /// <param name="Data">要保存的数据。</param>
        /// <param name="ClearExistingRecord">是否清除已有记录。</param>
        /// <returns>操作结果。</returns>
        public static bool SaveCoordConvertData(List<CoordConvert> Data, bool ClearExistingRecord = true)
        {
            if (Data.Count <= 0)
                return false;
            if (ClearExistingRecord)
            {
                OleDbCommand cmd = new OleDbCommand
                {
                    CommandText = "DELETE * FROM CoordConvert",
                    Connection = con
                };
                cmd.ExecuteNonQuery();
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
        public static List<CoordConvert> LoadCoordConvertData()
        {
            List<CoordConvert> Data = new List<CoordConvert>();
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
                try
                {
                    Data.Add(new CoordConvert(Guid.Parse(r["UID"].ToString())));
                }
                catch (Exception)
                {
                    continue;
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
        public static bool SaveZoneConvertData(List<ZoneConvert> Data, bool ClearExistingRecord = true)
        {
            if (Data.Count <= 0)
                return false;
            if (ClearExistingRecord)
            {
                OleDbCommand cmd = new OleDbCommand
                {
                    CommandText = "DELETE * FROM ZoneConvert",
                    Connection = con
                };
                cmd.ExecuteNonQuery();
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
        public static List<ZoneConvert> LoadZoneConvertData()
        {
            List<ZoneConvert> Data = new List<ZoneConvert>();
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
                try
                {
                    Data.Add(new ZoneConvert(Guid.Parse(r["UID"].ToString())));
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return Data;
        }

        /// <summary>
        /// 获取数据库中的表列表。
        /// </summary>
        /// <returns>数据库表结构的数据表。</returns>
        public static DataTable GetTableList()
        {
            return con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
        }

        /// <summary>
        /// 根据表名，从数据库中查询对应表并填充到数据表中。
        /// </summary>
        /// <param name="TableName">表名。</param>
        /// <returns>包含全部表内容的数据表。</returns>
        public static DataTable GetTable(string TableName)
        {
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

        /// <summary>
        /// 根据表名，从数据库中查询对应表并填充到数据集中。
        /// </summary>
        /// <param name="DS">数据集，需初始化。</param>
        /// <param name="TableName">表名。</param>
        /// <returns></returns>
        public static bool GetTable(DataSet DS, string TableName)
        {
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

        /// <summary>
        /// 保存更改。
        /// </summary>
        /// <param name="DS">更改的数据集。</param>
        /// <param name="TableName">表名。</param>
        /// <returns></returns>
        public static int SaveEdit(DataSet DS, string TableName)
        {
            OleDbDataAdapter Adapter = new OleDbDataAdapter("SELECT * FROM " + TableName, con);
            OleDbCommandBuilder cb = new OleDbCommandBuilder(Adapter);
            Adapter.DeleteCommand = cb.GetDeleteCommand();
            Adapter.InsertCommand = cb.GetInsertCommand();
            Adapter.UpdateCommand = cb.GetUpdateCommand();
            return Adapter.Update(DS, TableName);
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
