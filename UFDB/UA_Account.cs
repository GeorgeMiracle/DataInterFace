using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFDB
{
    public  class SYSAcc
    {
        public static string GetDataBaseString(string accid,int year)
        {
            using (UFsysDataContext us = new UFsysDataContext(GetUFSysSqlConn()))
            {
                var Ret = us.UA_AccountDatabase.FirstOrDefault(x => x.cAcc_Id == accid && x.iBeginYear <= year && (x.iEndYear == null ?Convert.ToInt16( DateTime.Now.Year): x.iEndYear) >= year);

                return Ret == null ? null : Ret.cDatabase;
            }
        }
        
        /// <summary>
        /// 获取u8数据库连接
        /// </summary>
        /// <param name="server">服务器地址</param>
        /// <param name="year">年度</param>
        /// <param name="Acc">账套号</param>
        /// <returns></returns>
        public static string GetUFSqlConn(string CateLog)
        {
            string Conn= SqlConfig.LoadSqlConn();

            return Conn.Replace(Conn.Split(';')[1], "Initial Catalog="+ CateLog + "" );
        }
        /// <summary>
        /// 获取u8 System库数据库连接
        /// </summary>
        /// <param name="server">服务器地址</param>
        /// <param name="year">年度</param>
        /// <param name="Acc">账套号</param>
        /// <returns></returns>
        public static string GetUFSysSqlConn()
        {
            string Conn = SqlConfig.LoadSqlConn();

            return Conn.Replace(Conn.Split(';')[1], "Initial Catalog=UFSystem");
        }
    }
}
