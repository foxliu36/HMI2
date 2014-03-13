using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Factory;

namespace Lib
{
    public static class DaoFactory 
    {

        public static InterfaceDao getDaoInstance(string type) 
        {
            InterfaceDao IDao = null;
            if (type == "")
            {
                IDao = new SqlServerDao();
                return IDao;
            }
            return IDao;
        }
    }
}
