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
    public partial class BaseDialog : Form
    {
        private bool FCanClose = false;
        public bool CanClose
        {
            get { return FCanClose; }
            set { this.FCanClose = value; }
        }


        public BaseDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FCanClose = true;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void BaseDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (!FCanClose);
        }

    }
}
