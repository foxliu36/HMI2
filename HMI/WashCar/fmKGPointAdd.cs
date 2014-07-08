using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMI.Entity;
using Lib.OfficialFactory;

namespace HMI.WashCar
{
    public partial class fmKGPointAdd : Form
    {

        ADaoFactory dao = new DaoFactory(EDaoType.SQLServer);

        public fmKGPointAdd()
        {
            dao.SetConnectionString("Data Source = KDSQL;Initial Catalog=KG;User ID=96002;Password=s0953039382;");
            InitializeComponent();
            ShowData();
        }

        public void ShowData() 
        {
            try
            {
                DataTable dt = dao.Query(" select * from tbKGPoint");
                this.dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //新增
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("確定新增業代 " + txtEmpNo.Text + " ??",
                        "Confirm Delete!!",
                        MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    string empno = txtEmpNo.Text;
                    string empname = txtEmpName.Text;

                    dao.ExcuteNonQuery(" insert into tbKGPoint ([f_Smid],[f_Name],[f_Point]) values ('" + empno + "','" + empname + "','0') ");
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string cmd = " select * from tbKGPoint where 1=1 ";
                if (txtEmpNo.Text != "")
                {
                    cmd += "and f_Smid = '" + txtEmpNo.Text + "' ";
                }
                DataTable dt = dao.Query(cmd);

                this.dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
