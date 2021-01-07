using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace UFDB
{

    public class SQLDB
    {
        public static string Conn = SqlConfig.LoadSqlConn();

        public static string User = "";

        public static string Pwd = "";

        public static string Catelog = "";


        /// <summary>
        /// 根据账套号配置u8数据库链接
        /// </summary>
        /// <param name="AccId">账套号</param>

        public static void SetCateLog(int AccId, string Year)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UFDATA_");
            sb.Append(AccId.ToString());
            sb.Append("_");
            sb.Append(Year.ToString());
            Catelog = sb.ToString();
        }

        public static void ExcuteSqlTran(string sql)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Conn))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlConnection.BeginTransaction();
                sqlCommand.CommandText = sql;
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    sqlCommand.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public static DataTable GetTable(string sql)
        {
            SqlConnection sqlConnection = new SqlConnection(Conn);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = sql;
            SqlDataAdapter sqlDataReader = new SqlDataAdapter(sqlCommand);
            DataSet Ds = new DataSet();
            sqlDataReader.Fill(Ds);
            return Ds.Tables[0];
        }
        public static DataTable GetTable(string Conn, string sql)
        {
            SqlConnection sqlConnection = new SqlConnection(Conn);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = sql;
            SqlDataAdapter sqlDataReader = new SqlDataAdapter(sqlCommand);
            DataSet Ds = new DataSet();
            sqlDataReader.Fill(Ds);
            return Ds.Tables[0];
        }

        public static List<string> GetBaseCateLog()
        {
            DataTable dt = GetTable("SELECT name FROM master..sysdatabases");

            List<string> listBase = new List<string>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listBase.Add(dt.Rows[i]["name"].ToString());
                }
            }
            return listBase;
        }
        public static List<string> GetBaseCateLog(string Conn)
        {
            DataTable dt = GetTable(Conn, "SELECT name FROM master..sysdatabases");

            List<string> listBase = new List<string>();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listBase.Add(dt.Rows[i]["name"].ToString());
                }
            }
            return listBase;
        }
        /// <summary>
        /// 测试链接
        /// </summary>
        /// <param name="Conn"></param>
        public static void TestConn(string Conn)
        {
            SqlConnection sqlConnection = new SqlConnection(Conn);

            sqlConnection.Open();

            sqlConnection.Close();
        }
        /// <summary>
        /// 语法检查
        /// </summary>
        /// <param name="sql"></param>
        public static void GrammaCheck(string sql)
        {
            SqlConnection conn = new SqlConnection(Conn);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction sqlTransaction = conn.BeginTransaction();

            cmd.Connection = conn;
            try
            {
                cmd.CommandText = sql;
                sqlTransaction.Commit();
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                sqlTransaction.Rollback();
                conn.Close();
            }

        }
    }
}
