using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI
{
    public partial class fmCheckOldClockTime : Form
    {
        public fmCheckOldClockTime()
        {
            InitializeComponent();
            userControl11.insertClick += new EventHandler(insert);
            
            
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void OnButton_Click(Object senders, EventArgs arg) 
        {
            
        }

        private void insert(Object senders, EventArgs arg) 
        { 
            
        }

        private void fmCheckOldClockTime_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'hRDataSet.TB_HR_CLOCKTIME' 資料表。您可以視需要進行移動或移除。
            this.tB_HR_CLOCKTIMETableAdapter.Fill(this.hRDataSet.TB_HR_CLOCKTIME);

        }
    }
}
