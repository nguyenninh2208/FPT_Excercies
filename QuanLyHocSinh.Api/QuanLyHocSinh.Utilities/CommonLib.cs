using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinh.Utilities
{
    public class CommonLib
    {
        public static bool IsStringEmpty(object val)
        {
            return IsStringEmpty(IsNullString(val));
        }

        public static bool IsStringEmpty(string val)
        {
            return string.IsNullOrEmpty(val);
        }

        public static string IsNullString(object val)
        {
            if (val == null)
                return string.Empty;
            return val.ToString().Trim();
        }

        public static string IsNullString(object val, object defaultValue)
        {
            if (val == null)
                return defaultValue != null ? defaultValue.ToString() : string.Empty;
            return val.ToString().Trim();
        }

        public static string IsNullString(object val, object defaultValue, string format)
        {
            if (!IsNull(val))
            {
                return string.Format(format, val);
            }
            return string.Format(format, defaultValue);
        }

        public static int IsNullInt32(object val)
        {
            try
            {
                if (string.IsNullOrEmpty(IsNullString(val)))
                    return 0;
                return Convert.ToInt32(val);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static float IsNullFloat(object val)
        {
            try
            {
                if (string.IsNullOrEmpty(IsNullString(val)))
                    return 0;
                return Convert.ToSingle(val);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int IsNullInt32(object val, int defaultValue)
        {
            try
            {
                if (string.IsNullOrEmpty(IsNullString(val)))
                    return defaultValue;
                return Convert.ToInt32(val);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static long IsNullInt64(object val)
        {
            try
            {
                if (string.IsNullOrEmpty(IsNullString(val)))
                    return 0;

                return Convert.ToInt64(val);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static long IsNullInt64(object val, long defaultValue)
        {
            try
            {
                if (string.IsNullOrEmpty(IsNullString(val)))
                    return defaultValue;

                return Convert.ToInt64(val);
            }
            catch (Exception)
            {
                return defaultValue;
            }

        }

        public static DateTime IsNullDateTime(object val)
        {
            try
            {
                if (string.IsNullOrEmpty(IsNullString(val)))
                    return new DateTime(1900, 1, 1, 0, 0, 0);

                return Convert.ToDateTime(val);
            }
            catch (Exception)
            {
                return new DateTime(1900, 1, 1, 0, 0, 0);
            }

        }

        public static DateTime IsNullDateTime(object val, DateTime defaultValue)
        {
            try
            {
                if (string.IsNullOrEmpty(IsNullString(val)))
                {
                    if (defaultValue == null)
                        return new DateTime(1900, 1, 1, 0, 0, 0);
                    return defaultValue;
                }
                return Convert.ToDateTime(val);
            }
            catch (Exception)
            {
                return new DateTime(1900, 1, 1, 0, 0, 0);
            }
        }

        public static double IsNullDouble(object val)
        {
            try
            {
                if (string.IsNullOrEmpty(IsNullString(val)))
                    return 0;

                return Convert.ToDouble(val);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static double IsNullDouble(object val, double defaultValue)
        {
            try
            {
                if (string.IsNullOrEmpty(IsNullString(val)))
                    return defaultValue;

                return Convert.ToDouble(val);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static decimal IsNullDecimal(object val)
        {
            try
            {
                if (string.IsNullOrEmpty(IsNullString(val)))
                    return 0;

                return Convert.ToDecimal(val);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static decimal IsNullDecimal(object val, decimal defaultValue)
        {
            try
            {
                if (string.IsNullOrEmpty(IsNullString(val)))
                    return defaultValue;

                return Convert.ToDecimal(val);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public static Guid IsNullGuid(object val)
        {
            try
            {
                if (val == null)
                    return Guid.Empty;
                return (Guid)val;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        public static Guid IsNullGuid(object val, Guid defaultValue)
        {
            try
            {
                if (val == null)
                    return defaultValue;
                return (Guid)val;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        public static bool IsNullBool(object val)
        {
            try
            {
                if (string.IsNullOrEmpty(IsNullString(val)))
                    return false;
                return Convert.ToBoolean(val);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsNullBool(object val, bool defaultValue)
        {
            if (!string.IsNullOrEmpty(IsNullString(val)))
            {
                try
                {
                    return Convert.ToBoolean(val);
                }
                catch
                {
                }
            }
            return defaultValue;
        }

        public static bool IsNull(object val)
        {
            if (val != null)
                return Convert.IsDBNull(val);
            return true;
        }
        public static string FormatDate(object date)
        {
            if (date != null)
                return ((DateTime)date).ToString("dd/MM/yyyy");
            else return "N/A";
        }



    }
}
