using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Factory
{
    interface InterfaceConnectionFactory
    {
        //查詢
        virtual DataTable Query(string p_Cmd);

        //執行新刪修
        virtual int ExcuteNonQuery(string p_Cmd);
    }
}
