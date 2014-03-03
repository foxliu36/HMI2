using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using HMI.Entity;
using Lib;

namespace HMI.IT
{
    public partial class fmRoleMemberControl : Form
    {

        //紀錄各種腳色範圍
        List<Auth> la = new List<Auth>();

        public fmRoleMemberControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fmRoleMemberControl_Load(object sender, EventArgs e)
        {
            using (var en = new UOFEntities())
            {
                //顯示全部腳色
                var rolemodule = (from q in en.TB_EB_SEC_ROLE
                            select q)
                            .GroupBy(p => p.MODULE_ID)
                            .Select(q => q.Key);

                foreach (var item in rolemodule)
                {
                    lbModule.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// 選取腳色群組
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedmodule = lbModule.SelectedItem.ToString();

            using(var en = new UOFEntities())
	        {
                //先清除
                lbRoleID.Items.Clear();
                var roles = from q in en.TB_EB_SEC_ROLE
                            where q.MODULE_ID == selectedmodule
                            select q;

                foreach (var item in roles)
                {
                    lbRoleID.Items.Add(item.ROLE_ID);
                }
	        }
        }

        /// <summary>
        /// 選取腳色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbRoleID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedrole = lbRoleID.SelectedItem.ToString();
            
            using (var en = new UOFEntities())
            {
                var member = from q in en.TB_EB_SEC_ROLE_MEMBER
                             where q.ROLE_ID == selectedrole
                             select q;

                dataGridView1.DataSource = member.ToList();
            }
        }

        /// <summary>
        /// 解析
        // <userId> = [TB_EB_USER].USER_GUID    員工主檔
        // <jobTitleId> = [TB_EB_JOB_TITLE].[TITLE_ID]  職級主檔
        // <jobFunctionId> = [TB_EB_JOB_FUNC].[FUNC_ID]  職務主檔
        // <groupId> = [TB_EB_GROUP].[GROUP_ID] 部門主檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProfile_Click(object sender, EventArgs e)
        {
            la.Clear();

            string xml = dataGridView1.SelectedRows[0].Cells["USER_SET"].Value.ToString();

            XDocument doc = XDocument.Parse(xml);

            var elementtype = from q in doc.Descendants("Element")
                              group q by q.Attribute("type").Value into g
                              select g.Key;
                              

            //取得userid
            var usernode = from q in doc.Descendants("userId")
                           select new Auth
                           {
                               範圍種類 = "人員",
                               範圍1 = getUser(q.Value).NAME,
                               key1 = q.Value
                           };

            foreach (var item in usernode)
            {
                la.Add(item);
            }
            
            //取得jobTitle
            var jobtitlenode = from q in doc.Descendants("jobTitleId")
                               select new Auth
                               {
                                   範圍種類 = "職級",
                                   範圍1 = getJobTitle(q.Value).TITLE_NAME,
                                   key1 = q.Value
                               };
            foreach (var item in jobtitlenode)
            {
                la.Add(item);
            }

            var jobfuncgroupNodes = from q in doc.Descendants("Element")
                               where q.Attribute("type").Value == "jobFunctionOfGroup"
                               select new Auth
                               {
                                   範圍種類 = "職務和部門",
                                   範圍1 = getJobFunc(q.Descendants("jobFunctionId").First().Value).FUNC_NAME,
                                   key1 = q.Descendants("jobFunctionId").First().Value,
                                   範圍2 = getGroup(q.Descendants("groupId").First().Value).GROUP_NAME,
                                   key2 = q.Descendants("groupId").First().Value
                               };
            foreach (var item in jobfuncgroupNodes)
            {
                la.Add(item);
            }

            dgvAuth.DataSource = (from q in la
                                 select new {
                                     權限名稱 = q.範圍種類,
                                     範圍1 = q.範圍1,
                                     範圍2 = q.範圍2,
                                 }).ToList();
            #region 失敗的方法
            //XmlProfile proxml = new XmlProfile(xml, "");
            //紀錄上一個節點名稱
            //string NodeName = "";
            //記錄不同節點的值
            //List<string> Userid = new List<string>();
            //List<string> Groupid = new List<string>();
            //List<string> JobTitleid = new List<string>();
            //List<string> JobTitleOfGroup = new List<string>();

            //while (proxml.GetXmlReader().Read())
            //{
            //    //使用節點屬性分類
            //    switch (proxml.GetXmlReader().NodeType)
            //    {
            //        //取得節點
            //        case System.Xml.XmlNodeType.Element:

            //            textBox1.Text += "<" + proxml.GetXmlReader().Name + "> \n";
            //            NodeName = proxml.GetXmlReader().Name;
            //            if (NodeName == "Element")
            //            {
            //                textBox1.Text += proxml.GetXmlReader().GetAttribute("type");
            //            }
            //            break;

            //        //取得值
            //        case System.Xml.XmlNodeType.Text:

            //            textBox1.Text += proxml.GetXmlReader().Value + " \n";
            //            if (NodeName == "userId")
            //            {
            //                Userid.Add(proxml.GetXmlReader().Value);
            //            }
            //            if (NodeName == "groupId")
            //            {
            //                Groupid.Add(proxml.GetXmlReader().Value);
            //            }
            //            if (NodeName == "jobTitleId")
            //            {
            //                JobTitleid.Add(proxml.GetXmlReader().Value);
            //            }
            //            if (NodeName == "jobTitleId")
            //            {
            //                JobTitleOfGroup.Add(proxml.GetXmlReader().Value);
            //            }
            //            break;

            //        case System.Xml.XmlNodeType.EndElement:
            //            textBox1.Text += "</" + proxml.GetXmlReader().Name + ">";
            //            break;

            //        default:
            //            break;
            //    }
            //}
            #endregion
            
        }

        /// <summary>
        /// 選擇新增的範圍總類
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAuthAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbAuthAdd.SelectedItem.ToString())
            {
                case "人員":
                    lblDetail1.Text = "員編";
                    lblDetail2.Enabled = false;
                    txtDetail2.Enabled = false;
                    break;
                case "部門":
                    lblDetail1.Text = "部門";
                    lblDetail2.Enabled = false;
                    txtDetail2.Enabled = false;
                    break;
                case "職級":
                    lblDetail1.Text = "職級";
                    lblDetail2.Enabled = false;
                    txtDetail2.Enabled = false;
                    break;
                case "職務和部門":
                    lblDetail1.Text = "職務和部門";
                    lblDetail2.Enabled = true;
                    txtDetail2.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        //查詢新增範圍資料
        private void btnDetailCheck_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 新增範圍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAuthAdd_Click(object sender, EventArgs e)
        {

        }

        

        //腳色範圍
        private class Auth
        {
            private string type;
            private string a1;
            private string k1;
            private string a2;
            private string k2;

            public string 範圍種類 {
                get { return type; }
                set { type = value; }
            }

            public string 範圍1
            {
                get { return a1; }
                set { a1 = value; }
            }

            public string key1
            {
                get { return k1; }
                set { k1 = value; }
            }

            public string 範圍2
            {
                get { return a2; }
                set { a2 = value; }
            }

            public string key2
            {
                get { return k2; }
                set { k2 = value; }
            }
        }

        //職務配部門的範圍
        private class JobFunctionOfGroupAuth 
        {
            public XElement jobfuncid { set; get; }
            public XElement groupid { set; get; }
        }

        //找人
        private TB_EB_USER getUser(string p_EmpGUID) 
        {
            using (var en = new UOFEntities())
            {
                TB_EB_USER user = en.TB_EB_USER.Where(p => p.USER_GUID == p_EmpGUID).First();
                return user;
            }
        }
        
        //找職級 ex:專員
        private TB_EB_JOB_TITLE getJobTitle(string p_TITLE_ID) 
        {
            using (var en = new UOFEntities())
            {
                TB_EB_JOB_TITLE title = en.TB_EB_JOB_TITLE.Where(p => p.TITLE_ID == p_TITLE_ID).First();
                return title;
            }
        }

        //找職務 ex:廠長
        private TB_EB_JOB_FUNC getJobFunc(string p_FuncID) 
        {
            using (var en = new UOFEntities())
            {
                TB_EB_JOB_FUNC jfunc = en.TB_EB_JOB_FUNC.Where(p => p.FUNC_ID == p_FuncID).First();
                return jfunc;
            }
        }

        //找部門 ex:青年廠
        private TB_EB_GROUP getGroup(string p_GroupID) 
        {
            using (var en = new UOFEntities())
            {
                TB_EB_GROUP group = en.TB_EB_GROUP.Where(p => p.GROUP_ID == p_GroupID).First();
                return group;
            }
        }

        

        

        
    }
}
