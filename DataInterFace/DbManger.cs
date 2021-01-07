using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataInterFace
{
    public class DbManager
    {
        public static string U8Conn = "Data Source=7.139.168.48;Initial Catalog=UFDATA_002_2020;Persist Security Info=True;User ID=sa;Password=1qaz@WSX!@#";

        public static string UserName = "test";//当前登陆人

        public static DateTime LoginDate;
        public static UFDataContext GetU8DbContext()
        {
            return new UFDataContext(U8Conn);
        }
    }
}
