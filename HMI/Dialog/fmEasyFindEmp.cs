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
        public string finddata { get; set; }

        public fmEasyFindEmp()
        {
            InitializeComponent();
            comboBox1.Items.Add("人員");
            comboBox1.Items.Add("部門");
            comboBox1.Items.Add("職級");
            comboBox1.Items.Add("職務");
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                using (var en = new UOFEntities())
                { 
                    //if (dataGridView1.Rows.Count != 0 && dataGridView1.CurrentRow != null)
                    //{
                    //    string struser = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
                    //    finddata = en.TB_EB_USER.Where(p => p.ACCOUNT == struser).FirstOrDefault().ACCOUNT;
                    //    this.DialogResult = DialogResult.OK;
                    //    this.Close();
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnFliter_Click(object sender, EventArgs e)
        {
            try
            {
                using (var en = new UOFEntities())
                {
                    switch (comboBox1.SelectedItem.ToString())
                    {
                        case "人員":
                            dataGridView1.DataSource = (from q in en.TB_EB_USER
                                                        where q.ACCOUNT.Contains(textBox1.Text.Trim())
                                                        select new
                                                        {
                                                            id = q.ACCOUNT,
                                                            name = q.NAME
                                                        }).DefaultIfEmpty().ToList();
                            break;
                        case "職級":
                            dataGridView1.DataSource = (from q in en.TB_EB_JOB_TITLE
                                                        where q.TITLE_NAME.Contains(textBox1.Text.Trim())
                                                        select new { 
                                                            id = q.TITLE_NAME,
                                                            key = q.TITLE_ID
                                                        }).DefaultIfEmpty().ToList();
                            break;
                        case "部門":
                            dataGridView1.DataSource = (from q in en.TB_EB_GROUP
                                                        where q.GROUP_NAME.Contains(textBox1.Text.Trim())
                                                        select new {
                                                            id = q.GROUP_NAME,
                                                            key = q.GROUP_TYPE
                                                        }).DefaultIfEmpty().ToList();
                            break;
                        case "職務":
                            dataGridView1.DataSource = (from q in en.TB_EB_JOB_FUNC
                                                        where q.FUNC_NAME.Contains(textBox1.Text.Trim())
                                                        select new {
                                                            id = q.FUNC_NAME,
                                                            key = q.FUNC_ID
                                                        }).DefaultIfEmpty().ToList();
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
