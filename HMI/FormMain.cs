using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HMI.IT;
using HMI.WashCar;
using HMI.HR;

namespace HMI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void 卡鐘資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckWindowOpened("fmSearchClockTime"))
            {
                fmSearchClockTime f1 = new fmSearchClockTime();
                f1.MdiParent = this;
                f1.Show();
            }
        }

        //判斷要開啟的視窗是否已經開啟
        //若視窗已開啟，將該視窗帶到最上層
        private bool CheckWindowOpened(string ChildWindowName)
        {
            bool Opened = true;
            for (int iChildren = 0; iChildren < MdiChildren.Length; iChildren++)
            {
                if (MdiChildren[iChildren].Name == ChildWindowName)
                {
                    //將視窗帶到到最上層
                    MdiChildren[iChildren].BringToFront();
                    Opened = false;
                }
            }
            return Opened;
        }

        private void brabrabraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckWindowOpened("Form2"))
            {
            }
        }

        private void 卡鐘舊資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckWindowOpened("fmCheckOldClockTime"))
            {
                
            }
        }

        private void 畫面掛載ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckWindowOpened("fmEipFormControl"))
            {
                fmEipFormControl fmEipFormControl = new fmEipFormControl();
                fmEipFormControl.MdiParent = this;
                fmEipFormControl.Show();
            }
        }

        private void 角色成員管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckWindowOpened("fmRoleMemberControl"))
            {
                fmRoleMemberControl fmRoleMemberControl = new fmRoleMemberControl();
                fmRoleMemberControl.MdiParent = this;
                fmRoleMemberControl.Show();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (CheckWindowOpened("fmTestSQLite"))
            {
                fmTestSQLite fmTestSQLite = new fmTestSQLite();
                fmTestSQLite.MdiParent = this;
                fmTestSQLite.Show();
            }
        }

        private void 加入業代店數ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckWindowOpened("fmKGPointAdd"))
            {
                fmKGPointAdd fmKGPointAdd = new fmKGPointAdd();
                fmKGPointAdd.MdiParent = this;
                fmKGPointAdd.Show();
            }
        }

        private void 延遲的卡鐘資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckWindowOpened("frmSearchDelayClockTime"))
            {
                frmSearchDelayClockTime frmSearchDelayClockTime = new frmSearchDelayClockTime();
                frmSearchDelayClockTime.MdiParent = this;
                frmSearchDelayClockTime.Show();
            }
        }

        
    }
}
