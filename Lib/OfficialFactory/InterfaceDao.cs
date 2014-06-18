using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.OfficialFactory
{
    public interface InterfaceDao
    {
        //設定連線字串
        void SetConnectionString(string p_ConString);

        //查詢
        DataTable Query(string p_Cmd);

        //執行新刪修
        int ExcuteNonQuery(string p_Cmd);
    }
}
