using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroondasDataProvider.Helpers
{
    public static class Extensions
    {
        public static bool IsNull(this string source)
        {
            return source == null || source.Trim().Length == 0;
        }

        public static bool HasPositiveValue(this int? source)
        {
            return source.HasValue ? source.Value > 0 : !source.HasValue;
        }

        public static int? ParseIntOrDefault(this string source, int? defValue = null)
        {
            if (int.TryParse(source, out int num))
            {
                return num;
            }
            return defValue;
        }
    }
}
