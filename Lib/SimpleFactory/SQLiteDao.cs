using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.Factory;
using System.Data.SQLite;
using System.Data;

namespace Lib.SimpleFactory
{
    //http://roach0426.pixnet.net/blog/post/965051-%E7%94%A8c%23%E4%BE%86%E8%AE%80%E6%94%9C%E5%B8%B6%E5%9E%8B%E8%B3%87%E6%96%99%E5%BA%ABsqlite
    //http://www.iteye.com/topic/114055
    //解決sqlite不能再.net framework 4.0執行請看下面
    //http://www.dotblogs.com.tw/sam319/archive/2010/06/04/15626.aspx
    public class SQLiteDao : InterfaceDao
    {
        private SQLiteConnection sqlite_con = new SQLiteConnection();
        private SQLiteDataAdapter sqlite_da = new SQLiteDataAdapter();

        public SQLiteDao()
        {

        }
        
        public void SetConnectionString(string p_ConString)
        {
            sqlite_con.ConnectionString = p_ConString;
        }

        public System.Data.DataTable Query(string p_Cmd)
        {
            try
            {
                DataSet ds = new DataSet();

                sqlite_con.Open();

                sqlite_da.SelectCommand = new SQLiteCommand(p_Cmd, sqlite_con);

                sqlite_da.Fill(ds);

                sqlite_con.Close();

                return ds.Tables[0];
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
                SQLiteCommand cmd = sqlite_con.CreateCommand();
                
                cmd.CommandText = p_Cmd;

                sqlite_con.Open();

                int effectrows = cmd.ExecuteNonQuery();

                sqlite_con.Close();

                return effectrows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
