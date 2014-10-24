using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.OfficialFactory
{
    public class SqlServerDao : InterfaceDao
    {
        //第一：連結SQL資料庫
        SqlConnection con = new SqlConnection();

        SqlDataAdapter sda = new SqlDataAdapter();

        SqlCommand cmd = null;

        SqlTransaction myTrans = null;

        public SqlServerDao()
        {
            //con.ConnectionString = "";
            cmd = con.CreateCommand();
        }

        public SqlServerDao(string p_Constring)
        {
            con.ConnectionString = p_Constring;
            cmd = con.CreateCommand();
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

                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
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
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }

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

        public void BeginTransaction()
        {
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            myTrans = con.BeginTransaction();
            cmd.Transaction = myTrans;
        }

        public void Commit()
        {
            myTrans.Commit();
            con.Close();
        }

        public void RollBack()
        {
            myTrans.Rollback();
            myTrans.Dispose();
        }
    }
}
