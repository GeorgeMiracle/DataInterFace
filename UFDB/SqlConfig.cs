using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace UFDB
{

    public class SqlConfig
    {
        public string IPAdress { get; set; }

        public string BaseName { get; set; }

        public string UserName { get; set; }

        public string Pwd { get; set; }
        
        public static void SetSqlConfig(SqlConfig Sqlconfig)
        {
            string sqlConn = GetSqlConnStr(Sqlconfig);
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["Conn"] != null)
            {
                config.AppSettings.Settings["Conn"].Value = sqlConn;

            }
            else
            {
                config.AppSettings.Settings.Add("Conn", sqlConn);

            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string LoadSqlConn()
        {
            return ConfigurationManager.AppSettings["Conn"] == null ? "" : ConfigurationManager.AppSettings["Conn"].ToString();
        }
        public static string GetSqlConnStr(SqlConfig sqlConfig)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Data Source={0};", sqlConfig.IPAdress));
            sb.Append(string.Format("Initial Catalog={0};", sqlConfig.BaseName));
            sb.Append(string.Format("Persist Security Info={0};", "True"));
            sb.Append(string.Format("User ID={0};", sqlConfig.UserName));
            sb.Append(string.Format("Password={0}", sqlConfig.Pwd));
            return sb.ToString();
        }

        public static SqlConfig GetSqlConnByStrConn(string Conn)
        {
            SqlConfig sqlConfig = new SqlConfig();
            string[] DataBaseObject = Conn.Split(';');
            foreach (var item in DataBaseObject)
            {
                var Key = item.Split('=')[0];
                switch (Key)
                {
                    case "Data Source":
                        sqlConfig.IPAdress = item.Split('=')[1];
                        break;
                    case "Initial Catalog":
                        sqlConfig.BaseName = item.Split('=')[1];
                        break;
                    case "User ID":
                        sqlConfig.UserName = item.Split('=')[1];
                        break;
                    case "Password":
                        sqlConfig.Pwd = item.Split('=')[1];
                        break;
                    default:
                        break;
                }
            }
            return sqlConfig;
        }
    }
}
