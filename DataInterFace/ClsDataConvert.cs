
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataInterFace
{
    public class clsDataConvert
    {
        public static bool ToBoolean(object s)
        {
            bool flag = false;
            if (((s != null) && (s != DBNull.Value)) && !string.IsNullOrEmpty(s.ToString()))
            {
                if (s.ToString().Equals("True", StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
                if (s.ToString().Equals("False", StringComparison.CurrentCultureIgnoreCase))
                {
                    return false;
                }
                if (s.ToString().Equals("1"))
                {
                    return true;
                }
                if (s.ToString().Equals("1"))
                {
                    flag = false;
                }
            }
            return flag;
        }

        public static string ToDateStr(object s, string format)
        {
            DateTime result = new DateTime(1, 1, 1);
            if (((s != null) && (s != DBNull.Value)) && !string.IsNullOrEmpty(s.ToString()))
            {
                DateTime.TryParse(s.ToString(), out result);
            }
            else
            {
                return string.Empty;
            }
            return result.ToString(format);
        }

        public static DateTime ToDateTime(object s)
        {
            DateTime result = new DateTime(1, 1, 1);
            if (((s != null) && (s != DBNull.Value)) && !string.IsNullOrEmpty(s.ToString()))
            {
                DateTime.TryParse(s.ToString(), out result);
            }
            return result;
        }

        public static decimal ToDecimal(object s)
        {
            decimal result = new decimal();
            if (((s != null) && (s != DBNull.Value)) && !string.IsNullOrEmpty(s.ToString()))
            {
                decimal.TryParse(s.ToString(), out result);
            }
            return result;
        }

        public static double ToDouble(object s)
        {
            double result = 0.0;
            if (((s != null) && (s != DBNull.Value)) && !string.IsNullOrEmpty(s.ToString()))
            {
                double.TryParse(s.ToString(), out result);
            }
            return result;
        }

        public static float ToFloat(object s)
        {
            float result = 0f;
            if (((s != null) && (s != DBNull.Value)) && !string.IsNullOrEmpty(s.ToString()))
            {
                float.TryParse(s.ToString(), out result);
            }
            return result;
        }

        public static int ToInt32(object s)
        {
            int result = 0;
            if (((s != null) && (s != DBNull.Value)) && !string.IsNullOrEmpty(s.ToString()))
            {
                if (s.ToString().Equals("True", StringComparison.CurrentCultureIgnoreCase))
                {
                    return 1;
                }
                if (s.ToString().Equals("False", StringComparison.CurrentCultureIgnoreCase))
                {
                    return 0;
                }
                int.TryParse(s.ToString(), out result);
            }
            return result;
        }

        public static string ToString(object s)
        {
            if ((s == null) || string.IsNullOrEmpty(s.ToString()))
            {
                return string.Empty;
            }
            return s.ToString();
        }
    }
}
