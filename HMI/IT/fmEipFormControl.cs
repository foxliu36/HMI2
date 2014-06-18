using Lib.OfficialFactory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI.IT
{
    public partial class fmEipFormControl : Form
    {
        ADaoFactory dao = new DaoFactory(EDaoType.SQLServer);

        public fmEipFormControl()
        {
            InitializeComponent();
            userControl11.insertClick += new EventHandler(insertData);
            userControl11.deleteClick += new EventHandler(deleteData);
            userControl11.editClick += new EventHandler(EditData);
            userControl11.btnSave.Enabled = false;
            userControl11.btnCancel.Enabled = false;

        }

        private void RefreshData() 
        {
            string selected = cbGroup.SelectedItem.ToString();
            DataTable dt = getChild(selected);

            dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 畫面仔入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmEipFormControl_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = getMenuModule();

                var module = from q in dt.AsEnumerable()
                             select new
                             {
                                 moduleid = q.Field<string>("MENU_ID")
                             };

                foreach (var item in module)
                {
                    cbModule.Items.Add(item.moduleid);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 挑模組
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbModule.SelectedItem.ToString();
            DataTable dt = getChild(selected);

            var module = from q in dt.AsEnumerable()
                         select new
                         {
                             moduleid = q.Field<string>("MENU_ID")
                         };
            cbGroup.Items.Clear();
            foreach (var item in module)
            {
                cbGroup.Items.Add(item.moduleid);
            }
        }

        /// <summary>
        /// 挑Group
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// 取得模組
        /// </summary>
        /// <returns></returns>
        private DataTable getMenuModule()
        {
            try
            {
                return dao.Query(" select MENU_ID from TB_EB_MENU where TYPE = 'Module' ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return new DataTable();
            }
        }

        /// <summary>
        /// 取得子模組
        /// </summary>
        /// <param name="p_Parent"></param>
        /// <returns></returns>
        private DataTable getChild(string p_Parent) 
        {
            try
            {
                return dao.Query(" SELECT [t0].[MENU_ID], [t0].[PARENT_MENU_ID], [t0].[LINK_URL], [t0].[IS_NEW_WINDOW], [t0].[TYPE], [t0].[DATA_KEY], [t0].[ORDERS] " +
                                 "FROM [TB_EB_MENU] AS [t0] where PARENT_MENU_ID = '" + p_Parent + "' order by ORDERS");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return new DataTable();
            }
        }

        /// <summary>
        /// 點選DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtModule.Text = dataGridView1.SelectedRows[0].Cells["MENU_ID"].Value.ToString();
            txtParent.Text = dataGridView1.SelectedRows[0].Cells["PARENT_MENU_ID"].Value.ToString();
            txtURL.Text = dataGridView1.SelectedRows[0].Cells["LINK_URL"].Value.ToString();
            cboxOpen.Checked = (bool)dataGridView1.SelectedRows[0].Cells["IS_NEW_WINDOW"].Value;
            txtType.Text = dataGridView1.SelectedRows[0].Cells["TYPE"].Value.ToString();
            txtDataKey.Text = dataGridView1.SelectedRows[0].Cells["DATA_KEY"].Value.ToString();
            txtOrders.Text = dataGridView1.SelectedRows[0].Cells["ORDERS"].Value.ToString();
        }

        /// <summary>
        /// 點選DataGridView反應比上面好
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtModule.Text = dataGridView1.SelectedRows[0].Cells["MENU_ID"].Value.ToString();
            txtParent.Text = dataGridView1.SelectedRows[0].Cells["PARENT_MENU_ID"].Value.ToString();
            txtURL.Text = dataGridView1.SelectedRows[0].Cells["LINK_URL"].Value.ToString();
            cboxOpen.Checked = (bool)dataGridView1.SelectedRows[0].Cells["IS_NEW_WINDOW"].Value;
            txtType.Text = dataGridView1.SelectedRows[0].Cells["TYPE"].Value.ToString();
            txtDataKey.Text = dataGridView1.SelectedRows[0].Cells["DATA_KEY"].Value.ToString();
            txtOrders.Text = dataGridView1.SelectedRows[0].Cells["ORDERS"].Value.ToString();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void insertData(object sender, EventArgs e) 
        {
            try
            {
                dao.ExcuteNonQuery(" insert into TB_EB_MENU (MENU_ID, PARENT_MENU_ID, LINK_URL, IS_NEW_WINDOW, TYPE, DATA_KEY, ORDERS) "+
                                   " values ('"+ txtModule.Text +"', '"+ txtParent.Text +"', '"+ txtURL.Text +"', '"+ cboxOpen.Checked.ToString() 
                                   +"', '"+ txtType.Text +"', '"+ txtDataKey.Text +"', '"+ txtOrders.Text +"') ");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteData(object sender, EventArgs e) 
        {
            try
            {
                dao.ExcuteNonQuery(" delete from TB_EB_MENU where MENU_ID = '" + dataGridView1.SelectedRows[0].Cells["MENU_ID"].Value + "' ");

                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditData(object sender, EventArgs e)
        {
            try
            {
                dao.ExcuteNonQuery(" update TB_EB_MENU set MENU_ID = '" + txtModule.Text + "' , PARENT_MENU_ID = '" + txtParent.Text +
                                    "', LINK_URL = '" + txtURL.Text + "', IS_NEW_WINDOW = '" + cboxOpen.Checked + "', TYPE = '" + txtType.Text
                                    + "', DATA_KEY = '" + txtDataKey.Text + "', ORDERS = '" + txtOrders.Text + 
                                    "' where MENU_ID = '" + dataGridView1.SelectedRows[0].Cells["MENU_ID"].Value + "' ");

                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
