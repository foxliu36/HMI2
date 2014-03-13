using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Factory
{
    public class SqlServerDao : InterfaceDao
    {
        //第一：連結SQL資料庫
        SqlConnection con = new SqlConnection();

        SqlDataAdapter sda = new SqlDataAdapter();



        public SqlServerDao()
        {
            con.ConnectionString = "Data Source = 172.26.100.8;Initial Catalog=UOF;User ID=sa;Password=hp1020.;";
        }

        public SqlServerDao(string p_Constring)
        {
            con.ConnectionString = p_Constring;
        }

        public void SetConnectionString(string p_ConString)
        {
            con.ConnectionString = p_ConString;
        }

        public System.Data.DataTable Query(string p_Cmd)
        {
            try
            {
                DataSet ds = new DataSet();
                con.State.ToString();
                con.Open();
                string sqlstr = p_Cmd;

                sda.SelectCommand = new SqlCommand(sqlstr, con);

                sda.Fill(ds);
                con.Close();
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
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection.Open();
                cmd.CommandText = p_Cmd;

                int effectrows = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return effectrows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
