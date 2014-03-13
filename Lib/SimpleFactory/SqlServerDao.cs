using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Factory
{
    public class SqlServerDao : InterfaceDao
    {
        public System.Data.DataTable Query(string p_Cmd)
        {
            throw new NotImplementedException();
        }

        public int ExcuteNonQuery(string p_Cmd)
        {
            throw new NotImplementedException();
        }
    }
}
