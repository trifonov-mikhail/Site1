using System;
using System.Collections.Generic;
using System.Text;

namespace Erc.Apple.Data
{
    public static class NullableConverter
    {
        public static DateTime? ToDateTime(object o)
        {
            if (!Convert.IsDBNull(o))
                return Convert.ToDateTime(o);
            else
                return null;
        }
        public static int? ToInt32(object o)
        {
            if (!Convert.IsDBNull(o))
                return Convert.ToInt32(o);
            else
                return null;
        }
        public static float? ToSingle(object o)
        {
            if (!Convert.IsDBNull(o))
                return Convert.ToSingle(o);
            else
                return null;
        }
        public static double? ToDouble(object o)
        {
            if (!Convert.IsDBNull(o))
                return Convert.ToDouble(o);
            else
                return null;
        }
    }
}
