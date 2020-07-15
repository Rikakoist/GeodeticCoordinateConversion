using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace GeodeticCoordinateConversion
{
    class DBIO
    {
        //保存操作
        internal static void SaveToDB(string Insert, string DBPath)
        {
            string ConnectionInfo = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + DBPath;
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
        internal static void ReadFromDB(string TableName, string DBPath, DataGridView Datas)
        {
            string ConnectionInfo = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + DBPath;
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
        internal static void ReadFromDB(string TableName, string DBPath, string QueryCommand, DataGridView Datas)
        {
            string ConnectionInfo = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + DBPath;
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
        internal static DataSet ReadToDG(string TableName, string DBPath)
        {
            string ConnectionInfo = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + DBPath;
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
        internal static void DeleteFromDB(string TableName, string DBPath, DataGridView Datas, int RowIndex)
        {
            string ConnectionInfo = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + DBPath;
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
        internal static void InsertIntoDB(string TableName, string DBPath, DataGridView Datas, string Cols, string[] InputStringArray, int ColumnCount)
        {
            string ConnectionInfo = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + DBPath;
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
        internal static void UpdateDB(string TableName, string DBPath, DataGridView Datas, int ColumnIndex, int RowIndex)
        {
            string ConnectionInfo = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + DBPath;
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

        //检查数据库是否存在
        internal static void CheckDBExists(string DBPath)
        {
            //File exists?
            if (!File.Exists(DBPath))
            {
                //Need confirmation
                if (MessageBoxes.Confirm(DBPath + " 不存在，是否创建？") == "OK")
                {
                    System.Reflection.Assembly DBAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                    var DBStream = DBAssembly.GetManifestResourceStream("GeodeticCoordinateConversion.GeoConvertDB.mdb");
                    byte[] DBResource = new Byte[DBStream.Length];
                    DBStream.Read(DBResource, 0, (int)DBStream.Length);
                    var DBFileStream = new FileStream(DBPath, FileMode.Create);
                    DBFileStream.Write(DBResource, 0, (int)DBStream.Length);
                    DBFileStream.Close();
                }
                else
                {
                    throw new Exception("数据库创建操作被用户取消。");
                }
            }
        }

        //检查行列数
        internal static void CheckElementsAndCols(int ElementNums, int Cols)
        {
            if (ElementNums != Cols)
            {
                throw new Exception("要插入的元素数量不正确，应为" + ElementNums + "个。");
            }
        }
    }
}
