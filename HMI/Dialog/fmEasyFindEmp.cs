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

namespace HMI.Dialog
{
    public partial class fmEasyFindEmp : Form
    {
        public Entity.TB_EB_USER user { get; set; }

        public fmEasyFindEmp()
        {
            InitializeComponent();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnFliter_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count != 0 && dataGridView1.CurrentRow != null)
                {
                    //this.user = 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
