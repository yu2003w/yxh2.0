using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace YXH.Common
{
    public sealed class DBUtility
    {
        public static int ScalarToInt(object scalar, int nullValue = 0)
        {
            if (scalar != null && scalar != DBNull.Value)
            {
                return Convert.ToInt32(scalar);
            }
            return nullValue;
        }

        public static int? ScalarToNullableInt(object scalar, int? nullValue = null)
        {
            if (scalar == null || scalar == DBNull.Value)
            {
                return nullValue;
            }
            return new int?(Convert.ToInt32(scalar));
        }

        public static long ScalarToLong(object scalar, long nullValue = 0L)
        {
            if (scalar != null && scalar != DBNull.Value)
            {
                return Convert.ToInt64(scalar);
            }
            return nullValue;
        }

        public static Guid ScalarToGuid(object scalar)
        {
            if (DBUtility.ScalarToString(scalar, "") == "")
            {
                return Guid.Empty;
            }
            return new Guid(DBUtility.ScalarToString(scalar, ""));
        }

        public static string ScalarToString(object scalar, string nullValue = "")
        {
            if (scalar != null && scalar != DBNull.Value)
            {
                return Convert.ToString(scalar);
            }
            return nullValue;
        }

        public static decimal ScalarToDecimal(object scalar, [DecimalConstant(0, 0, 0u, 0u, 0u)] decimal nullValue = default(decimal))
        {
            if (scalar != null && scalar != DBNull.Value)
            {
                return Convert.ToDecimal(scalar);
            }
            return nullValue;
        }

        public static decimal? ScalarToNullableDecimal(object scalar, decimal? nullValue = null)
        {
            if (scalar == null || scalar == DBNull.Value)
            {
                return nullValue;
            }
            return new decimal?(Convert.ToDecimal(scalar));
        }

        public static double ScalarToDouble(object scalar, double nullValue = 0.0)
        {
            if (scalar != null && scalar != DBNull.Value)
            {
                return Convert.ToDouble(scalar);
            }
            return nullValue;
        }

        public static DateTime ScalarToDateTime(object scalar)
        {
            if (scalar != null && scalar != DBNull.Value)
            {
                return DateTime.Parse(scalar.ToString());
            }
            return DateTime.MinValue;
        }

        public static bool ScalarToBool(object scalar)
        {
            return scalar != null && scalar != DBNull.Value && (DBUtility.ScalarToString(scalar, "") == "1" || DBUtility.ScalarToString(scalar, "").ToString().Equals("true", StringComparison.InvariantCultureIgnoreCase) || (!(DBUtility.ScalarToString(scalar, "") == "0") && !DBUtility.ScalarToString(scalar, "").ToString().Equals("false", StringComparison.InvariantCultureIgnoreCase) && bool.Parse(DBUtility.ScalarToString(scalar, ""))));
        }

        public static double? ScalarToNullableDouble(object scalar, double? nullValue = null)
        {
            if (scalar == null || scalar == DBNull.Value)
            {
                return nullValue;
            }
            return new double?(Convert.ToDouble(scalar));
        }

        public static float ScalarToSingle(object scalar, float nullValue = 0f)
        {
            if (scalar != null && scalar != DBNull.Value)
            {
                return Convert.ToSingle(scalar);
            }
            return nullValue;
        }

        public static float? ScalarToNullableSingle(object scalar, float? nullValue = null)
        {
            if (scalar == null || scalar == DBNull.Value)
            {
                return nullValue;
            }
            return new float?(Convert.ToSingle(scalar));
        }

        public static ulong ScalarToUInt64(object scalar, ulong nullValue = 0uL)
        {
            if (scalar != null && scalar != DBNull.Value)
            {
                return Convert.ToUInt64(scalar);
            }
            return nullValue;
        }

        public static uint ScalarToUInt32(object scalar, uint nullValue = 0u)
        {
            if (scalar != null && scalar != DBNull.Value)
            {
                return Convert.ToUInt32(scalar);
            }
            return nullValue;
        }

        public static ushort ScalarToUInt16(object scalar, ushort nullValue = 0)
        {
            if (scalar != null && scalar != DBNull.Value)
            {
                return Convert.ToUInt16(scalar);
            }
            return nullValue;
        }

        public static T ScalarToT<T>(object scalar, T emptyValue)
        {
            if (scalar == null || scalar == DBNull.Value || scalar.ToString() == string.Empty)
            {
                return emptyValue;
            }
            return (T)((object)Convert.ChangeType(scalar, typeof(T)));
        }

        public static string GetFormatedSQLError(Exception ex)
        {
            string result = ex.Message;
            if (ex.Message.Contains("唯一索引") || ex.Message.Contains("重复键"))
            {
                result = "不能添加重复值！";
            }
            else if (ex.Message.Contains("约束") || ex.Message.Contains("Relations"))
            {
                result = "数据约束错误！";
            }
            return result;
        }

        public static T ScalarToNullableT<T>(object scalar, T emptyValue)
        {
            if (scalar == null || scalar == DBNull.Value || scalar.ToString() == string.Empty)
            {
                return emptyValue;
            }
            return (T)((object)Convert.ChangeType(scalar, typeof(T)));
        }

        public static DataTable FillDataTable<T>(List<T> modelList)
        {
            if (modelList == null || modelList.Count == 0)
            {
                return null;
            }
            DataTable dataTable = DBUtility.CreateData<T>(modelList[0]);
            foreach (T current in modelList)
            {
                DataRow dataRow = dataTable.NewRow();
                PropertyInfo[] properties = typeof(T).GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo propertyInfo = properties[i];
                    if (propertyInfo.PropertyType == typeof(DateTime))
                    {
                        dataRow[propertyInfo.Name] = DBUtility.ScalarToDateTime(propertyInfo.GetValue(current, null));
                    }
                    else
                    {
                        dataRow[propertyInfo.Name] = propertyInfo.GetValue(current, null);
                    }
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        private static DataTable CreateData<T>(T model)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] properties = typeof(T).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo propertyInfo = properties[i];
                dataTable.Columns.Add(new DataColumn(propertyInfo.Name, propertyInfo.PropertyType));
            }
            return dataTable;
        }

        public static List<T> FillModel<T>(DataTable dt) where T : class, new()
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            List<T> list = new List<T>();
            foreach (DataRow dataRow in dt.Rows)
            {
                T t = Activator.CreateInstance<T>();
                PropertyInfo[] properties = typeof(T).GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo propertyInfo = properties[i];
                    t.GetType().GetProperty(propertyInfo.Name).SetValue(t, dataRow[propertyInfo.Name], null);
                }
                list.Add(t);
            }
            return list;
        }

        public static DataTable SelectDistinct(DataTable SourceTable, params string[] FieldNames)
        {
            if (FieldNames == null || FieldNames.Length == 0)
            {
                throw new ArgumentNullException("FieldNames");
            }
            object[] lastValues = new object[FieldNames.Length];
            DataTable dataTable = new DataTable();
            for (int i = 0; i < FieldNames.Length; i++)
            {
                string text = FieldNames[i];
                dataTable.Columns.Add(text, SourceTable.Columns[text].DataType);
            }
            DataRow[] array = SourceTable.Select("", string.Join(",", FieldNames));
            DataRow[] array2 = array;
            for (int j = 0; j < array2.Length; j++)
            {
                DataRow dataRow = array2[j];
                if (!DBUtility.fieldValuesAreEqual(lastValues, dataRow, FieldNames))
                {
                    dataTable.Rows.Add(DBUtility.createRowClone(dataRow, dataTable.NewRow(), FieldNames));
                    DBUtility.setLastValues(lastValues, dataRow, FieldNames);
                }
            }
            return dataTable;
        }

        private static bool fieldValuesAreEqual(object[] lastValues, DataRow currentRow, string[] fieldNames)
        {
            bool result = true;
            for (int i = 0; i < fieldNames.Length; i++)
            {
                if (lastValues[i] == null || !lastValues[i].Equals(currentRow[fieldNames[i]]))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private static DataRow createRowClone(DataRow sourceRow, DataRow newRow, string[] fieldNames)
        {
            for (int i = 0; i < fieldNames.Length; i++)
            {
                string columnName = fieldNames[i];
                newRow[columnName] = sourceRow[columnName];
            }
            return newRow;
        }

        private static void setLastValues(object[] lastValues, DataRow sourceRow, string[] fieldNames)
        {
            for (int i = 0; i < fieldNames.Length; i++)
            {
                lastValues[i] = sourceRow[fieldNames[i]];
            }
        }

        public List<string> GetSqlServerNames()
        {
            DataTable dataSources = SqlClientFactory.Instance.CreateDataSourceEnumerator().GetDataSources();
            DataColumn column = dataSources.Columns["InstanceName"];
            DataColumn column2 = dataSources.Columns["ServerName"];
            DataRowCollection rows = dataSources.Rows;
            List<string> list = new List<string>();
            string item = string.Empty;
            for (int i = 0; i < rows.Count; i++)
            {
                string text = rows[i][column2] as string;
                string text2 = rows[i][column] as string;
                if (text2 == null || text2.Length == 0 || "MSSQLSERVER" == text2)
                {
                    item = text;
                }
                else
                {
                    item = text + "\\" + text2;
                }
                list.Add(item);
            }
            list.Sort();
            return list;
        }

        public List<string> GetSqlDatabaseList(string connection)
        {
            List<string> list = new List<string>();
            string cmdText = "select name from sys.databases";
            SqlConnection sqlConnection = new SqlConnection(connection);
            SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                    IDataReader dataReader = sqlCommand.ExecuteReader();
                    list.Clear();
                    while (dataReader.Read())
                    {
                        list.Add(dataReader["name"].ToString());
                    }
                    dataReader.Close();
                }
            }
            catch (SqlException)
            {
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Dispose();
                }
            }
            return list;
        }

        public List<string> GetSqlTables(string connection)
        {
            List<string> list = new List<string>();
            SqlConnection sqlConnection = new SqlConnection(connection);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                    DataTable schema = sqlConnection.GetSchema("Tables");
                    foreach (DataRow dataRow in schema.Rows)
                    {
                        list.Add(dataRow[2].ToString());
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Dispose();
                }
            }
            return list;
        }

        public List<string> GetSqlColumnField(string connection, string TableName)
        {
            List<string> list = new List<string>();
            SqlConnection sqlConnection = new SqlConnection(connection);
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                SqlCommand sqlCommand = new SqlCommand("Select Name FROM SysColumns Where id=Object_Id('" + TableName + "')", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    list.Add(sqlDataReader[0].ToString());
                }
            }
            catch
            {
            }
            sqlConnection.Close();
            return list;
        }

        public static DataTable CloneTable(DataSet sourceDataSet, string tablename, int pageNo, int pageSize)
        {
            DataTable sourceDataTable = sourceDataSet.Tables[tablename];
            return DBUtility.CloneTable(sourceDataTable, pageNo, pageSize);
        }

        public static DataTable CloneTable(DataSet sourceDataSet, int pageNo, int pageSize)
        {
            DataTable sourceDataTable = sourceDataSet.Tables[0];
            return DBUtility.CloneTable(sourceDataTable, pageNo, pageSize);
        }

        public static DataTable CloneTable(DataTable sourceDataTable, int pageNo, int pageSize)
        {
            int num = pageSize * (pageNo - 1);
            int num2 = num + pageSize - 1;
            int count = sourceDataTable.Rows.Count;
            if (num >= count)
            {
                num = 0;
                num2 = num + pageSize;
            }
            if (num2 >= count)
            {
                num2 = count - 1;
            }
            DataTable dataTable = sourceDataTable.Clone();
            for (int i = num; i <= num2; i++)
            {
                dataTable.ImportRow(sourceDataTable.Rows[i]);
            }
            return dataTable;
        }

        public static DataSet CloneDataSetNew(DataSet ds)
        {
            DataSet dataSet = ds.Clone();
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                {
                    DataRow dataRow = dataSet.Tables[i].NewRow();
                    for (int k = 0; k < dataSet.Tables[i].Columns.Count; k++)
                    {
                        dataRow[k] = ds.Tables[i].Rows[j][k];
                    }
                    dataSet.Tables[i].Rows.Add(dataRow);
                }
            }
            return dataSet;
        }

        public static DataTable CloneNewTable(DataTable sourceTable)
        {
            DataTable dataTable = sourceTable.Clone();
            for (int i = 0; i < sourceTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    dataRow[j] = sourceTable.Rows[i][j];
                }
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        public static void AddIdentityToTable(DataTable sourceDataTable, string columnName)
        {
            sourceDataTable.Columns.Add(new DataColumn(columnName, typeof(int)));
            for (int i = 0; i < sourceDataTable.Rows.Count; i++)
            {
                sourceDataTable.Rows[i][columnName] = i + 1;
            }
            sourceDataTable.AcceptChanges();
        }

        public static bool InColleciton(string str, IList excludeFields)
        {
            if (excludeFields == null)
            {
                return false;
            }
            foreach (string text in excludeFields)
            {
                if (text.ToUpper() == str.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }

        public static void ImportDataRow(DataTable table, DataRow[] rows)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                DataRow row = rows[i];
                table.ImportRow(row);
            }
        }
    }
}
