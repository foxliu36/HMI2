using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Factory;

namespace Lib
{
    class ConnectionFactory : InterfaceConnectionFactory
    {



        System.Data.DataTable InterfaceConnectionFactory.Query(string p_Cmd)
        {
            throw new NotImplementedException();
        }

        int InterfaceConnectionFactory.ExcuteNonQuery(string p_Cmd)
        {
            throw new NotImplementedException();
        }
    }
}
