using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Factory;
using Lib.SimpleFactory;

namespace Lib.OfficialFactory
{
    public class DaoFactory : ADaoFactory
    {

        //這邊呼叫父類別的建構值,而他的建構值也會呼叫getInstance
        //這算是自己寫的一點變化
        public DaoFactory(EDaoType p_Type)
            : base(p_Type)
        {
            
        }

        //這class只負責定義getInstance 來設定得到想要的物件
        public override InterfaceDao getInstance(EDaoType p_Type)
        {

            switch (p_Type)
            {
                case EDaoType.SQLServer:
                    return new SqlServerDao();
                case EDaoType.SQLite:
                    return new SQLiteDao();
                default:
                    return null;
            }

        }
    }
}
