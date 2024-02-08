using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessUtilities
{
    public static class ConstansDb
    {
        public static object IsNull(this object value)
        {
            return value ?? DBNull.Value;
        }
    }
}
