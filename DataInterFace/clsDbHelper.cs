namespace DataInterFace
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public abstract class clsDbHelperSQL
    {
        protected clsDbHelperSQL()
        {
        }

        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        public static int ExecuteSql(string strConn, string strSQL)
        {
            int num2;
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                SqlCommand command = new SqlCommand(strSQL, connection);
                try
                {
                    connection.Open();
                    return Convert.ToInt32(command.ExecuteNonQuery());
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }
            return num2;
        }

        public static int ExecuteSql(string strConn, string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(SQLString, connection))
                {
                    int num;
                    SqlParameter parameter = new SqlParameter("@content", SqlDbType.NText)
                    {
                        Value = content
                    };
                    command.Parameters.Add(parameter);
                    try
                    {
                        connection.Open();
                        num = command.ExecuteNonQuery();
                    }
                    catch (SqlException exception)
                    {
                        throw new Exception(exception.Message);
                    }
                    return num;
                }
            }
        }

        public static int ExecuteSql(string strConn, string SQLString, params SqlParameter[] cmdParms)
        {
            int num2;
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    connection.Open();
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    int num = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return num;
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return num2;
        }

        public static int ExecuteSqlInsertImg(string strConn, string strSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand(strSQL, connection))
                {
                    int num;
                    SqlParameter parameter = new SqlParameter("@fs", SqlDbType.Image)
                    {
                        Value = fs
                    };
                    command.Parameters.Add(parameter);
                    try
                    {
                        connection.Open();
                        num = command.ExecuteNonQuery();
                    }
                    catch (SqlException exception)
                    {
                        throw new Exception(exception.Message);
                    }
                    return num;
                }
            }
        }

        public static bool ExecuteSqlTran(string strConn, ArrayList SQLStringList)
        {
            bool flag = false;
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    SqlTransaction transaction = connection.BeginTransaction();
                    command.Transaction = transaction;
                    try
                    {
                        for (int i = 0; i < SQLStringList.Count; i++)
                        {
                            string str = SQLStringList[i].ToString();
                            if (str.Trim().Length > 1)
                            {
                                command.CommandText = str;
                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        flag = true;
                    }
                    catch (SqlException exception)
                    {
                        transaction.Rollback();
                        throw new Exception(exception.Message);
                    }
                    return flag;
                }
            }
        }

        public static bool ExecuteSqlTran(string strConn, Hashtable SQLStringList)
        {
            bool flag;
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        foreach (DictionaryEntry entry in SQLStringList)
                        {
                            string cmdText = entry.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])entry.Value;
                            PrepareCommand(cmd, connection, transaction, cmdText, cmdParms);
                            int num = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                    finally
                    {
                        if (cmd != null)
                        {
                            cmd.Dispose();
                        }
                    }
                }
            }
            return flag;
        }

        public static bool Exists(string strConn, string strSql, params SqlParameter[] cmdParms)
        {
            int num;
            object objA = GetSingle(strConn, strSql, cmdParms);
            if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
            {
                num = 0;
            }
            else
            {
                num = int.Parse(objA.ToString());
            }
            if (num == 0)
            {
                return false;
            }
            return true;
        }

        public static bool Exists(string strConn, string _strTable, string _strFiled, string _strValue)
        {
            bool flag = false;
            try
            {
                string[] textArray1 = new string[] { "SELECT * FROM  ", _strTable, " WHERE ", _strFiled, " = '", _strValue, "' " };
                DataTable table = Query(strConn, string.Concat(textArray1)).Tables[0];
                if ((table != null) && (table.Rows.Count > 0))
                {
                    flag = true;
                }
            }
            catch
            {
            }
            return flag;
        }

        public static int GetMaxID(string strConn, string FieldName, string TableName)
        {
            object single = GetSingle(strConn, "select max(" + FieldName + ")+1 from " + TableName);
            if (single == null)
            {
                return 1;
            }
            return int.Parse(single.ToString());
        }

        public static object GetSingle(string strConn, string SQLString)
        {
            object obj3;
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                SqlCommand command = new SqlCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    object objA = command.ExecuteScalar();
                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }
                    return objA;
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            }
            return obj3;
        }

        public static object GetSingle(string strConn, string SQLString, params SqlParameter[] cmdParms)
        {
            object obj3;
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    connection.Open();
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    object objA = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if (object.Equals(objA, null) || object.Equals(objA, DBNull.Value))
                    {
                        return null;
                    }
                    return objA;
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Dispose();
                    }
                }
            }
            return obj3;
        }

        public static string GetValue(string _strConn, string _strSql, string _strFiled)
        {
            string str = string.Empty;
            try
            {
                DataTable table = Query(_strConn, _strSql).Tables[0];
                if ((table != null) && (table.Rows.Count > 0))
                {
                    str = table.Rows[0][_strFiled].ToString();
                }
            }
            catch
            {
            }
            return str;
        }

        public static DataTable GetValue(string _strConn, string _strTable, string _strValue, string _strFiled, string _strReturn)
        {
            try
            {
                string[] textArray1 = new string[] { "SELECT ", _strReturn, " FROM  ", _strTable, " WHERE ", _strFiled, " = '", _strValue, "' " };
                return Query(_strConn, string.Concat(textArray1)).Tables[0];
            }
            catch
            {
                return null;
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        public static DataSet Query(string strConn, string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    new SqlDataAdapter(SQLString, connection).Fill(dataSet, "ds");
                }
                catch (SqlException exception)
                {
                    throw new Exception(exception.Message);
                }
                return dataSet;
            }
        }

        public static DataSet Query(string strConn, string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    PrepareCommand(command, connection, null, SQLString, cmdParms);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        try
                        {
                            adapter.Fill(dataSet, "ds");
                            command.Parameters.Clear();
                        }
                        catch (SqlException exception)
                        {
                            throw new Exception(exception.Message);
                        }
                        return dataSet;
                    }
                }
            }
        }

        public static string RunProc(string strConn, string storedProcName, IDataParameter[] parameters, string getParam)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();
                SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                command.ExecuteNonQuery();
                return (string)command.Parameters[getParam].Value;
            }
        }

        public static SqlDataReader RunProcedure(string strConn, SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            connection = new SqlConnection(strConn);
            connection.Open();
            using (SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters))
            {
                command.CommandType = CommandType.StoredProcedure;
                return command.ExecuteReader();
            }
        }

        public static DataSet RunProcedure(string strConn, string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                new SqlDataAdapter { SelectCommand = BuildQueryCommand(connection, storedProcName, parameters) }.Fill(dataSet, tableName);
                return dataSet;
            }
        }

        public static int RunProcedure(string strConn, string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                return (int)command.Parameters["ReturnValue"].Value;
            }
        }

        public static DataSet RunProcedure(string strConn, string storedProcName, IDataParameter[] parameters, string tableName, ref string TotalRecordCount, ref string PageCount)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter
                {
                    SelectCommand = BuildQueryCommand(connection, storedProcName, parameters)
                };
                adapter.Fill(dataSet, tableName);
                TotalRecordCount = adapter.SelectCommand.Parameters["@TotalRecordCount"].Value.ToString();
                PageCount = adapter.SelectCommand.Parameters["@PageCount"].Value.ToString();
                return dataSet;
            }
        }
    }
}
