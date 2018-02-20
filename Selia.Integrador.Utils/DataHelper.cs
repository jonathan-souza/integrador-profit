using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selia.Integrador.Utils
{
    public static class DataHelper
    {
        public static T ToGenericValue<T>(DataRow row, string column)
        {
            if (row[column] != DBNull.Value)
            {
                return (T)row[column];
            }
            else
                return default(T);
        }
    }
}
