using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HMI
{
    public partial class fmLogin : HMI.BaseDialog
    {
        public fmLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GASServiceReference.GasServiceSoapClient l_Ws = new GASServiceReference.GasServiceSoapClient();

            GASServiceReference.CMessage l_ReturnMess = l_Ws.AuthByPassword(txtAcc.Text, txtPass.Text, "HMI");

            if (l_ReturnMess.l_Return)
            {
                MessageBox.Show(l_ReturnMess.l_Message);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show(l_ReturnMess.l_Message);
            }
        }


    }
}
