using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Factory;
using Lib.SimpleFactory;

namespace Lib.OfficialFactory
{
    class SqlserverFactory : ADaoFactory
    {
        public InterfaceDao getInstance(EDaoType p_Type)
        {
            InterfaceDao IDao = null;

            switch (p_Type)
            {
                case EDaoType.SQLServer:

                    break;
                case EDaoType.SQLite:

                    break;
                default:
                    break;
            }
            
            return IDao;
        }
    }
}
