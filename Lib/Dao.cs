using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace HMI
{
    public class Dao
    {
        //第一：連結SQL資料庫
        SqlConnection con = new SqlConnection();

        SqlDataAdapter sda = new SqlDataAdapter();

        public Dao() {
            con.ConnectionString = "Data Source = 172.26.100.8;Initial Catalog=UOF;User ID=sa;Password=hp1020.;";
        }

        public Dao(string p_Con) {
            con.ConnectionString = p_Con;
        }

        //查詢
        public DataTable Query(string command) {
            SqlCommand cmd = new SqlCommand();
            try
            {
                DataSet ds = new DataSet();
                con.State.ToString();
                //SqlDataAdapter會自己開啟關閉con
                //con.Open();
                string sqlstr = command;

                cmd = new SqlCommand(sqlstr, con);

                sda.SelectCommand = cmd;

                sda.Fill(ds);
                //con.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                cmd.Cancel();
            }
        }

        //修改(新刪修)
        public void ExcuteNonQuery(string command) {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd = con.CreateCommand();
                cmd.Connection.Open();
                cmd.CommandText = command;

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                cmd.Cancel();
            }
            
        }

    }
}
