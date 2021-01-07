using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFDB
{
    public class Voucher
    {
        public static readonly object vouchNumLock = new object();
        public static void Insert()
        {
            using (UFDataContext uf = new UFDataContext())
            {
                //uf.GL_accvouch.InsertOnSubmit();
            }
        }
        /// <summary>
        /// 获取凭证类别排序号
        /// </summary>
        /// <returns></returns>
        public static int? GetSignSeq(string sign,string Conn)
        {
           

            using (UFDataContext uf = new UFDataContext(Conn))
            {
                var Ret = uf.ExecuteQuery<int?>("select isignseq from dsign where csign='" + sign + "'").FirstOrDefault();

                return Ret;
            }
        }
        /// <summary>
        /// 获取币种名称
        /// </summary>
        /// <returns></returns>
        public static string GetExchangeName(string code, string Conn)
        {

            using (UFDataContext uf = new UFDataContext(Conn))
            {
                var Ret = uf.ExecuteQuery<string>("select cexch_name from Code where ccode='" + code + "'").FirstOrDefault();

                return Ret;
            }
        }
        /// <summary>
        /// 获取自动凭证号
        /// </summary>
        /// <returns></returns>
        public static int? GetVouchNum(int year,int period,string sign, string Conn)
        {
            
            using (UFDataContext uf = new UFDataContext(Conn))
            {
                var Ret = uf.ExecuteQuery<int?>("SELECT MAX(ino_id) + 1 FROM gl_accvouch WHERE iyear = "+year+" AND iperiod = "+period+" AND csign = '"+ sign + "'").FirstOrDefault();

                return Ret==null?1:Ret;
            }
        }
        public static string GetDepCodebyPersonCode(string personCode, string Conn)
        {

            using (UFDataContext uf = new UFDataContext(Conn))
            {
                var Ret = uf.ExecuteQuery<string>("select cdepcode from Person where cpersonCode='" + personCode + "'").FirstOrDefault();

                return Ret;
            }
        }
        public static double GetExchRate(int year, int period, string exchName, string Conn)
        {
            using (UFDataContext uf = new UFDataContext(Conn))
            {
                var Ret = uf.exch.FirstOrDefault(x => x.iYear == year && x.iperiod == period && x.cexch_name == exchName);

                return Ret == null ? 1 : Ret.nflat;
            }
        }
    }
}
