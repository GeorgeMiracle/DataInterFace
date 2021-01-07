using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataInterFace
{
    public static class clsGetID
    {
        // Fields
        private static SqlCommand cmd;
        private static SqlDataReader myDataReader1;
        private static SqlTransaction myTrans;
        private static string rq;
        private static string sql;

        // Methods
        static clsGetID()
        {

        }
        public static string getAutoId(string strConn, string table, string caccid, int iFlag)
        {
            string str;
            int num = 0;
            SqlConnection connection = new SqlConnection(strConn);
            connection.Open();
            cmd = connection.CreateCommand();
            myTrans = connection.BeginTransaction();
            cmd.Connection = connection;
            cmd.Transaction = myTrans;
            try
            {
                string[] textArray1 = new string[] { "select iFatherId,iChildId from UFSYSTEM..UA_Identity where cVouchType='", table, "' and cacc_id='", caccid, "'" };
                sql = string.Concat(textArray1);
                cmd.CommandText = sql;
                myDataReader1 = cmd.ExecuteReader();
                if (myDataReader1.Read())
                {
                    if (iFlag == 1)
                    {
                        num = clsDataConvert.ToInt32(myDataReader1.GetValue(0)) + 1;
                        myDataReader1.Close();
                        object[] objArray1 = new object[] { "update UFSYSTEM..UA_Identity set iFatherId=", num, " where cVouchType='", table, "' and cacc_id='", caccid, "'" };
                        sql = string.Concat(objArray1);
                    }
                    else
                    {
                        num = clsDataConvert.ToInt32(myDataReader1.GetValue(1)) + 1;
                        myDataReader1.Close();
                        object[] objArray2 = new object[] { "update UFSYSTEM..UA_Identity set iChildId=", num, " where cVouchType='", table, "' and cacc_id='", caccid, "'" };
                        sql = string.Concat(objArray2);
                    }
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                }
                else
                {
                    myDataReader1.Close();
                    num = 1;
                    sql = " INSERT INTO UFSYSTEM..UA_Identity  ( cAcc_Id,  cVouchType, iFatherId, iChildId )  VALUES ( ";
                    string[] textArray2 = new string[] { sql, "'", caccid, "','", table, "',1,1 )" };
                    sql = string.Concat(textArray2);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                    myDataReader1.Close();
                }
                str = "1" + num.ToString().PadLeft(9, '0');
            }
            catch (Exception)
            {
                try
                {
                    myTrans.Rollback();
                    str = "1000000001";
                }
                catch (Exception)
                {
                    str = "1000000001";
                }
                finally
                {
                    connection.Close();
                }
            }
            return str;

        }
        public static string getcode(string strConn, string cardnumber)
        {
            string str;
            SqlConnection connection = new SqlConnection(strConn);
            connection.Open();
            double num = 0.0;
            cmd = connection.CreateCommand();
            myTrans = connection.BeginTransaction();
            cmd.Connection = connection;
            cmd.Transaction = myTrans;
            try
            {
                rq = DateTime.Today.ToString("yyyyMMdd");
                sql = "select cNumber  From VoucherHistory  with (UPDLOCK)  Where  CardNumber='" + cardnumber + "' and cContent is NULL";
                cmd.CommandText = sql;
                myDataReader1 = cmd.ExecuteReader();
                if (myDataReader1.Read())
                {
                    num = clsDataConvert.ToInt32(myDataReader1.GetValue(0)) + 1;
                    myDataReader1.Close();
                    object[] objArray1 = new object[] { "update VoucherHistory set cNumber=", num, " Where  CardNumber='", cardnumber, "' and cContent is NULL" };
                    sql = string.Concat(objArray1);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                }
                else
                {
                    myDataReader1.Close();
                    num = 1.0;
                    sql = " INSERT INTO voucherhistory  ( cardnumber,cnumber,cContent,cSeed,cContentRule)  VALUES ( ";
                    sql = sql + "'" + cardnumber + "','1',null,null,null)";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                }
                str = num.ToString("0000000000");
            }
            catch (Exception)
            {
                try
                {
                    myTrans.Rollback();
                    str = "0";
                }
                catch (Exception)
                {
                    str = "0";
                }
                finally
                {
                    connection.Close();
                }
            }
            return str;

        }
    }


}
