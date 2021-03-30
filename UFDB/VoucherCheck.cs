using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UFDB
{
    public class VoucherCheck
    {
        /// <summary>
        /// 凭证在u8中是否存在
        /// </summary>
        /// <returns></returns>
        public static bool ExistsVouch(string date, string sign, string num,string Conn)
        {
            UFDataContext uF = new UFDataContext(Conn);

            int Count = uF.ExecuteQuery<int>("select count(*) from gl_accvouch where iyear="+Convert.ToDateTime(date).Year+" and iperiod="+ Convert.ToDateTime(date).Month + "  and csign='" + sign + "' and ino_id=" + num + " ").FirstOrDefault();
            if (Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 科目是否存在某种属性
        /// </summary>
        /// <param name="checkProp">属性字段名</param>
        /// <returns></returns>
        private static bool ExistsProp(string code, string checkProp,string Conn)
        {
            UFDataContext uF = new UFDataContext(Conn);

            int? Count = uF.ExecuteQuery<int>("select count(*) from code where ccode='" + code + "' and " + checkProp + "=1").FirstOrDefault();
            if (Count == null || Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 科目是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool IsCodeExists(string code,string Conn)
        {
            using (UFDataContext uf = new UFDataContext(Conn))
            {
                int? count = uf.ExecuteQuery<int>("select count(*) from code where ccode='" + code + "'").FirstOrDefault();
                if (count == null || count < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// 科目是否末级
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool bCodeEnd(string code, string Conn)
        {
            using (UFDataContext uf = new UFDataContext(Conn))
            {
                int? count = uf.ExecuteQuery<int>("select count(*) from code where ccode='" + code + "' and bend=1").FirstOrDefault();
                if (count == null || count < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        /// <summary>
        /// 部门是否存在某种属性
        /// </summary>
        /// <returns></returns>
        public static bool bDep(string code,string Conn)
        {
            return ExistsProp(code, "bdept",Conn);
        }



        /// <summary>
        /// 人员是否存在
        /// </summary>
        /// <returns></returns>
        public static bool bPerson(string code,string Conn)
        {
            return ExistsProp(code, "bperson",Conn);
        }
        /// <summary>
        ///客户员是否存在
        /// </summary>
        /// <returns></returns>
        public static bool bCus(string code,string Conn)
        {
            return ExistsProp(code, "bcus",Conn);
        }
        /// <summary>
        ///供应商是否存在
        /// </summary>
        /// <returns></returns>
        public static bool bVen(string code,string Conn)
        {
            return ExistsProp(code, "bsup",Conn);
        }
        /// <summary>
        ///项目是否存在
        /// </summary>
        /// <returns></returns>
        public static bool bItem(string code,string Conn)
        {
            return ExistsProp(code, "bitem",Conn);
        }
        /// <summary>
        /// 检查档案编码是否存在
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="code">检测列名</param>
        /// <returns></returns>
        public static bool ArchiveExists(string tableName, string checkColName, string code,string Conn)
        {
            using (UFDataContext uf = new UFDataContext(Conn))
            {
                var count = uf.ExecuteQuery<int>("select count(*) from " + tableName + " where " + checkColName + "='" + code + "'").FirstOrDefault();
                if (count < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 部门是否存在
        /// </summary>
        public static bool DepExists(string code,string Conn)
        {
            return ArchiveExists("Department", "cdepCode", code,Conn);
        }
        /// <summary>
        /// 存货是否存在
        /// </summary>
        public static bool InvExists(string code, string Conn)
        {
            return ArchiveExists("Inventory", "cinvcode", code, Conn);
        }
        /// <summary>
        /// 存货是否存在
        /// </summary>
        public static bool InvExistsByName(string cinvname, string Conn)
        {
            return ArchiveExists("Inventory", "cinvname", cinvname, Conn);
        }
        /// <summary>
        /// 部门是末级
        /// </summary>
        public static bool bDepEnd(string code, string Conn)
        {
            using (UFDataContext uf = new UFDataContext(Conn))
            {
                var count = uf.ExecuteQuery<int>("select count(*) from department where cdepCode='" + code + "' and bdepEnd=1").FirstOrDefault();
                if (count < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 应收是否结账
        /// </summary>
        public static bool bArEnd(string Conn,int year,int period)
        {
            using (UFDataContext uf = new UFDataContext(Conn))
            {
                var count = uf.ExecuteQuery<int>("select count(*) from gl_mend where bflag_ar=1 and iyear="+year+" and iperiod="+period+"").FirstOrDefault();
                if (count < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 人员是否存在
        /// </summary>
        public static bool PersonExists(string code,string Conn)
        {
            return ArchiveExists("Person", "cPersonCode", code,Conn);
        }
        /// <summary>
        /// 客户是否存在
        /// </summary>
        public static bool CusExists(string code,string Conn)
        {
            return ArchiveExists("Customer", "ccusCode", code,Conn);
        }
       
        /// <summary>
        /// 供应商是否存在
        /// </summary>
        public static bool VenExists(string code,string Conn)
        {
            return ArchiveExists("Vendor", "cVenCode", code,Conn);
        }
        /// <summary>
        /// 项目大类是否存在
        /// </summary>
        public static bool ItemClassExists(string code, out string tbName,string Conn)
        {
            var bExists = ArchiveExists("fitemclass", "citem_class", code,Conn);
            if (!bExists)
            {
                tbName = "";
                return false;
            }
            else
            {
                using (UFDataContext uf = new UFDataContext(Conn))
                {
                    var itemClassTB = uf.ExecuteQuery<string>("select cTable from fitemclass where citem_class='" + code + "'").FirstOrDefault();
                    if (string.IsNullOrEmpty(itemClassTB))
                    {
                        tbName = "";
                        return false;
                    }
                    else
                    {
                        tbName = itemClassTB;
                        return true;
                    }
                }
            }
        }

        public static bool ItemexistsByName(string itemName, string tbname, string Conn)
        {
            using (UFDataContext uf = new UFDataContext(Conn))
            {
                var sysid = uf.ExecuteQuery<int>("select count(1) from sys.objects where name='" + tbname + "'").FirstOrDefault();
                if (sysid < 1)
                {
                    return false;
                }
                else
                {
                    var Count = uf.ExecuteQuery<int>("select count(1) from " + tbname + " where citemname='" + itemName + "'").FirstOrDefault();
                    if (Count < 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        public static bool Itemexists(string code, string tbname,string Conn)
        {
            using (UFDataContext uf = new UFDataContext(Conn))
            {
                var sysid = uf.ExecuteQuery<int>("select count(1) from sys.objects where name='" + tbname + "'").FirstOrDefault();
                if (sysid < 1)
                {
                    return false;
                }
                else
                {
                    var Count = uf.ExecuteQuery<int>("select count(1) from " + tbname + " where citemcode='" + code + "'").FirstOrDefault();
                    if (Count < 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        /// <summary>
        /// 现金流量项目是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool CashItemCode(string code,string Conn)
        {
            using (UFDataContext uf = new UFDataContext(Conn))
            {

                var Count = uf.ExecuteQuery<int>("select count(1) from fitemss98 where citemcode='" + code + "'").FirstOrDefault();
                if (Count < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
