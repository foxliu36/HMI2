using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.OfficialFactory;

namespace HMI.IT
{
    public partial class fmTestSQLite : Form
    {
        //至於如何建立資料庫請參照testSQLite專案
        ADaoFactory AFac = new DaoFactory(EDaoType.SQLite);

        public fmTestSQLite()
        {
            InitializeComponent();
            //DataSource中間有空格
            //.db .sqlite檔案都可以讀,但是路徑好像沒辦法用相對路徑
            AFac.SetConnectionString(@"Data Source=C:\testdb.sqlite");
        }

        private void fmTestSQLite_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = AFac.Query(" SELECT * FROM favorite ");

                this.dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
