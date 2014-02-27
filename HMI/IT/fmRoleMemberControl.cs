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
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProfile_Click(object sender, EventArgs e)
        {
            string xml = dataGridView1.SelectedRows[0].Cells["USER_SET"].Value.ToString();

            XDocument doc = XDocument.Parse(xml);

            IEnumerable<XElement> targetNodes = from q in doc.Descendants("userId")
                                                select q;


            var targetNodess = from q in doc.Descendants("Element")
                               where q.Attribute("type").Value == "jobFunctionOfGroup"
                               select new {
                                   jobFunctionId = q.Descendants("jobFunctionId"),
                                   groupId = q.Descendants("groupId")
                               };


            #region 失敗的方法
            //XmlProfile proxml = new XmlProfile(xml, "");
            //紀錄上一個節點名稱
            //string NodeName = "";
            //記錄不同節點的值
            //List<string> Userid = new List<string>();
            //List<string> Groupid = new List<string>();
            //List<string> JobTitleid = new List<string>();
            //List<string> JobTitleOfGroup = new List<string>();

            // <userId> = [TB_EB_USER].USER_GUID    員工主檔
            // <jobTitleId> = [TB_EB_JOB_TITLE].[TITLE_ID]  職級主檔
            //下面兩個要再一起
            // <jobFunctionId> = [TB_EB_JOB_FUNC].[FUNC_ID]  職務主檔
            // <groupId> = [TB_EB_GROUP].[GROUP_ID] 部門主檔


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

        private void bra() 
        {
        
        }
    }
}
