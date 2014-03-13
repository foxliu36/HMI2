using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Factory;
using Lib.SimpleFactory;

namespace Lib.OfficialFactory
{
    public abstract class ADaoFactory
    {
        protected InterfaceDao IDao = null;
        
        public ADaoFactory(EDaoType p_Type) 
        {
            IDao = getInstance(p_Type);
        }

        public void SetConnectionString(string p_ConString) 
        {
            try
            {
                IDao.SetConnectionString(p_ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Data.DataTable Query(string p_Cmd)
        {
            try
            {
                return IDao.Query(p_Cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExcuteNonQuery(string p_Cmd)
        {
            try
            {
                return IDao.ExcuteNonQuery(p_Cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public abstract InterfaceDao getInstance(EDaoType p_Type);
    }
}
