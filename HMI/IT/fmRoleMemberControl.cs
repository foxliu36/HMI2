using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using HMI.Dialog;
using HMI.Entity;
using Lib;

namespace HMI.IT
{
    public partial class fmRoleMemberControl : Form
    {

        //紀錄各種角色範圍
        List<Auth> la = new List<Auth>();

        public fmRoleMemberControl()
        {
            InitializeComponent();
            cbAuthAdd.Items.Add("人員");
            cbAuthAdd.Items.Add("職級");
            cbAuthAdd.Items.Add("職務");
            cbAuthAdd.Items.Add("部門");
            cbAuthAdd.Items.Add("職級和部門");
            cbAuthAdd.Items.Add("職務和部門");
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
                //顯示全部角色
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
        /// 選取角色群組
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedmodule = lbModule.SelectedItem.ToString();

            using (var en = new UOFEntities())
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
        /// 選取角色
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

            listBox1.Items.Clear();
            var elementtype = from q in doc.Descendants("Element")
                              group q by q.Attribute("type").Value into g
                              select g.Key;
            foreach (var item in elementtype)
            {
                listBox1.Items.Add(item);
            }

            //取得人員
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

            //取得職級
            var jobtitlenode = from q in doc.Descendants("Element")
                               where q.Attribute("type").Value == "jobTitle"
                               select new Auth
                               {
                                   範圍種類 = "職級",
                                   範圍1 = getJobTitle(q.Descendants("jobTitleId").First().Value).TITLE_NAME,
                                   key1 = q.Descendants("jobTitleId").First().Value
                               };
            foreach (var item in jobtitlenode)
            {
                la.Add(item);
            }

            //取得部門
            var group = from q in doc.Descendants("Element")
                        where q.Attribute("type").Value == "group"
                        select new Auth
                        {
                            範圍種類 = "部門",
                            範圍1 = getGroup(q.Descendants("groupId").First().Value).GROUP_NAME,
                            key1 = q.Descendants("groupId").First().Value
                        };
            foreach (var item in group)
            {
                la.Add(item);
            }

            //取得職務
            var jobfunc = from q in doc.Descendants("Element")
                          where q.Attribute("type").Value == "jobFunction"
                          select new Auth 
                          {
                                範圍種類 = "職務",
                                範圍1 = getJobFunc(q.Descendants("jobFunctionId").First().Value).FUNC_NAME,
                                key1 = q.Descendants("jobFunctionId").First().Value
                          };
            foreach (var item in jobfunc)
            {
                la.Add(item);
            }

            //取得職級和部門
            var jobtitlegroupNodes = from q in doc.Descendants("Element")
                                     where q.Attribute("type").Value == "jobTitleOfGroup"
                                     select new Auth
                                     {
                                         範圍種類 = "職級和部門",
                                         範圍1 = getJobTitle(q.Descendants("jobTitleId").First().Value).TITLE_NAME,
                                         key1 = q.Descendants("jobTitleId").First().Value,
                                         範圍2 = getGroup(q.Descendants("groupId").First().Value).GROUP_NAME,
                                         key2 = q.Descendants("groupId").First().Value
                                     };
            foreach (var item in jobtitlegroupNodes)
            {
                la.Add(item);
            }

            //取得職務和部門
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

            dgvAuth.DataSource = la.ToList();
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
        /// 人員
        /// 部門
        /// 職級
        /// 職務和部門
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAuthAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbAuthAdd.SelectedItem.ToString())
            {
                case "人員":
                    lblDetail2.Enabled = false;
                    txtDetail2.Enabled = false;
                    break;
                case "部門":
                    lblDetail2.Enabled = false;
                    txtDetail2.Enabled = false;
                    break;
                case "職級":
                    lblDetail2.Enabled = false;
                    txtDetail2.Enabled = false;
                    break;
                case "職級和部門":
                    lblDetail2.Enabled = true;
                    txtDetail2.Enabled = true;
                    break;
                case "職務和部門":
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
            try
            {

            
            using (var en = new UOFEntities())
            {
                switch (cbAuthAdd.SelectedItem.ToString())
                {
                    case "人員":
                        var emp = (from q in en.TB_EB_USER
                                   where q.ACCOUNT.Equals(txtDetail1.Text)
                                   select new Auth
                                   {
                                       範圍種類 = "人員",
                                       範圍1 = q.NAME,
                                       key1 = q.USER_GUID
                                   }).First();
                        if (emp != null)
                        {
                            la.Add(emp);
                        }
                        break;
                    case "部門":
                        var group = (from q in en.TB_EB_GROUP
                                     where q.GROUP_NAME.Equals(txtDetail1.Text)
                                     select new Auth
                                     {
                                         範圍種類 = "部門",
                                         範圍1 = q.GROUP_NAME,
                                         key1 = q.GROUP_ID
                                     }).First();
                        if (group != null)
                        {
                            la.Add(group);
                        }
                        break;
                    case "職級":
                        var jobtitle = (from q in en.TB_EB_JOB_TITLE
                                        where q.TITLE_NAME.Equals(txtDetail1.Text)
                                        select new Auth
                                        {
                                            範圍種類 = "職級",
                                            範圍1 = q.TITLE_NAME,
                                            key1 = q.TITLE_ID
                                        }).First();
                        if (jobtitle != null)
                        {
                            la.Add(jobtitle);
                        }
                        break;
                    case "職務":
                        var jobfunc = (from q in en.TB_EB_JOB_FUNC
                                        where q.FUNC_NAME.Equals(txtDetail1.Text)
                                        select new Auth
                                        {
                                            範圍種類 = "職務",
                                            範圍1 = q.FUNC_NAME,
                                            key1 = q.FUNC_ID
                                        }).First();
                        if (jobfunc != null)
                        {
                            la.Add(jobfunc);
                        }
                        break;
                    case "職級和部門":
                        var d = (from q in en.TB_EB_JOB_TITLE
                                where q.TITLE_NAME.Equals(txtDetail1.Text)
                                select new 
                                {
                                    id = q.TITLE_NAME,
                                    key = q.TITLE_ID
                                }).First();

                        var d1 = (from q in en.TB_EB_GROUP
                                    where q.GROUP_NAME == txtDetail2.Text
                                    select new
                                    {
                                        id = q.GROUP_NAME,
                                        key = q.GROUP_ID
                                    }).First();
                        Auth temp = new Auth { 
                                        範圍種類 = "職級和部門", 
                                        範圍1 = d.id, 
                                        key1 = d.key,
                                        範圍2 = d1.id,
                                        key2 = d1.key
                                    };
                        if (d != null && d1 != null)
                        {
                            la.Add(temp);
                        }

                        break;
                    case "職務和部門":
                        var data = (from q in en.TB_EB_JOB_FUNC
                                     where q.FUNC_NAME == txtDetail1.Text
                                     select new
                                     {
                                         id = q.FUNC_NAME,
                                         key = q.FUNC_ID
                                     }).First();
                        var data2 = (from q in en.TB_EB_GROUP
                                   where q.GROUP_NAME == txtDetail2.Text
                                   select new
                                   {
                                       id = q.GROUP_NAME,
                                       key = q.GROUP_ID
                                   }).First();

                        
                        Auth temp1 = new Auth { 
                                        範圍種類 = "職務和部門", 
                                        範圍1 = data.id, 
                                        key1 = data.key,
                                        範圍2 = data2.id,
                                        key2 = data2.key
                                    };
                        if (data != null && data2 != null)
                        {
                            la.Add(temp1);
                        }
                        break;
                    default:
                        break;
                }

                dgvAuth.DataSource = la.ToList();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 刪除範圍
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRange_Click(object sender, EventArgs e)
        {
            la.RemoveAt(dgvAuth.SelectedRows[0].Index);
            dgvAuth.DataSource = la.ToList();
        }

        /// <summary>
        /// 更新XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRenewXml_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xmlDox = new XmlDocument();

                XElement xTree = new XElement("UserSet",
                                                from q in la
                                                where q.範圍種類.Equals("人員")
                                                select new XElement("Element", new XAttribute("type", "user"),
                                                    new XElement("userId", q.key1)
                                                ),
                                                from q in la
                                                where q.範圍種類.Equals("職級")
                                                select new XElement("Element", new XAttribute("type", "jobTitle"),
                                                    new XElement("jobTitleId", q.key1)
                                                ),
                                                from q in la
                                                where q.範圍種類.Equals("部門")
                                                select new XElement("Element", new XAttribute("type", "group"),
                                                    new XElement("groupId", q.key1)
                                                ),
                                                from q in la
                                                where q.範圍種類.Equals("職級和部門")
                                                select new XElement("Element", new XAttribute("type", "jobTitleOfGroup"), new XAttribute("isDepth", "True"),
                                                    new XElement("jobTitleId", q.key1),
                                                    new XElement("groupId", q.key2)
                                                ),
                                                from q in la
                                                where q.範圍種類.Equals("職務和部門")
                                                select new XElement("Element", new XAttribute("type", "jobFunctionOfGroup"), new XAttribute("isDepth", "True"),
                                                    new XElement("jobFunctionId", q.key1),
                                                    new XElement("groupId", q.key2)
                                                )
                                    );
                string outxml = xTree.ToString();

                using (UOFEntities en = new UOFEntities())
                {
                    string role = dataGridView1.SelectedRows[0].Cells["ROLE_ID"].Value.ToString();

                    var data = (from q in en.TB_EB_SEC_ROLE_MEMBER
                                where q.ROLE_ID.Equals(role)
                                select q).First();
                    data.USER_SET = outxml;
                    
                    en.SaveChanges();

                    //en.Log.Add(new Log { Id = 123,});
                    //en.Log.Remove(en.Log.Where(p => p.Id == 1).First());
                    //en.SaveChanges();
                }

                MessageBox.Show("更新成功");
                
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //角色範圍
        private class Auth
        {
            private string type;
            private string a1;
            private string k1;
            private string a2;
            private string k2;

            public string 範圍種類
            {
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
                TB_EB_USER user = en.TB_EB_USER.Where(p => p.USER_GUID == p_EmpGUID).FirstOrDefault();
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

        /// <summary>
        /// 新增範圍收尋正確名稱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            fmEasyFindEmp ea = new fmEasyFindEmp();
            ea.ShowDialog();
            if (ea.DialogResult == DialogResult.OK)
            {
                txtDetail1.Text = ea.finddata;
            }
        }

        

    }
}
