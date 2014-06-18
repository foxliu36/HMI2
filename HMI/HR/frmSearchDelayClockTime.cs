using HMI.Common;
using HMI.Entity;
using HMI.Model;
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


namespace HMI.HR
{
    public partial class frmSearchDelayClockTime : Form
    {
        ADaoFactory daodoor = new DaoFactory(EDaoType.SQLServer);
        
        ADaoFactory dao = new DaoFactory(EDaoType.SQLServer);

        DataTable dtforExl = new DataTable();


        public frmSearchDelayClockTime()
        {
            InitializeComponent();
            daodoor.SetConnectionString(@"Data Source = SOFTFW_SYSLOG\SQLEXPRESS;Initial Catalog=chiyu;User ID=sa;Password=hp1020.;");
        }

        private void btnFindMissing_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = FindMissPerson();

                List<ExportData> exportall = new List<ExportData>();

                var data = from q in dt.AsEnumerable()
                                 select new ExportData {
                                     員工編號 = Tool.轉換員編(q.Field<string>("UserID")),
                                     刷卡日期 = q.Field<DateTime>("DateTime").ToString("yyyy-MM-dd"),
                                 };

                foreach (var item in data)
                {
                    DataTable dt01 = checkExportData01(item.刷卡日期 + " 00:00:00", item.刷卡日期 + " 23:59:00", item.員工編號);
                    DataTable dt02 = checkExportData02(item.刷卡日期 + " 00:00:00", item.刷卡日期 + " 23:59:00", item.員工編號);

                    var exportdata = (from q in dt01.AsEnumerable()
                                        select new ExportData
                                        {
                                            員工卡號 = "#" + q.Field<string>("EMPLOYEE_ID").PadLeft(10, '0'),
                                            刷卡日期 = q.Field<DateTime>("DATE_TIME_MIN").ToString("yyyy-MM-dd").Replace("-", ""),
                                            刷卡時間 = q.Field<DateTime>("DATE_TIME_MIN").ToString("HH:mm").Replace(":", "").PadLeft(4, '0'),
                                            進出別 = q.Field<string>("DATE_TIME_TYPE"),
                                        }).Union(
                                        from p in dt02.AsEnumerable()
                                        select new ExportData
                                        {
                                            員工卡號 = "#" + p.Field<string>("EMPLOYEE_ID").PadLeft(10, '0'),
                                            刷卡日期 = p.Field<DateTime>("DATE_TIME_MAX").ToString("yyyy-MM-dd").Replace("-", ""),
                                            刷卡時間 = p.Field<DateTime>("DATE_TIME_MAX").AddMinutes(1).ToString("HH:mm").Replace(":", "").PadLeft(4, '0'),
                                            進出別 = p.Field<string>("DATE_TIME_TYPE"),
                                        });

                    foreach (var exitem in exportdata.ToList<ExportData>())
                    {
                        exportall.Add(exitem);
                    }
                }

                this.dataGridView1.DataSource = exportall;

                dtforExl = Tool.ConvertToDataTable<ExportData>(exportall);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnMakeExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Lib.ExcelExport ex = new Lib.ExcelExport();
                ex.SetColumeName(new string[] { "員工卡號", "刷卡日期", "刷卡時間", "進出別" });
                ex.SetNumberFormat("C1", "C" + dtforExl.Rows.Count + 1, "0000");
                ex.SetNumberFormat("D1", "D" + dtforExl.Rows.Count + 1, "00");
                //ex.myDGV = dataGridView1;
                ex.ExportExcel(this.dtforExl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //找到缺少的資料
        public DataTable FindMissPerson() 
        {
            StringBuilder sb = new StringBuilder();

            //這個月第一天
            DateTime firstdate = DateTime.Now.AddDays(-DateTime.Now.Day + 1).AddHours(-DateTime.Now.Hour);

            sb.Append(" SELECT * ");
            sb.Append(" FROM [DoorLog] AS [t0] ");
            sb.Append(" WHERE ((CONVERT(BigInt,(((CONVERT(BigInt,DATEDIFF(DAY, [t0].[DateTime], [t0].[LogArrivalDateTime]))) * 86400000) + DATEDIFF(MILLISECOND, DATEADD(DAY, DATEDIFF(DAY, [t0].[DateTime], [t0].[LogArrivalDateTime]), [t0].[DateTime]), [t0].[LogArrivalDateTime])) * 10000)) >864000000000) AND ([t0].[DateTime] > '" + firstdate.ToString("yyyy-MM-dd HH:mm:ss") + "') ");
            

            DataTable dt = daodoor.Query(sb.ToString());

            return dt;
        }

        private DataTable checkExportData01(string p_DateStart, string p_DateEnd, string p_EmpID)
        {

            string cmdTxt = @" select EMPLOYEE_ID,EMPLOYEE_EIP,MIN(DATE_TIME) as DATE_TIME_MIN, '01'  as DATE_TIME_TYPE ";
            cmdTxt += @" from dbo.TB_HR_CLOCKTIME ";
            cmdTxt += @" where EMPLOYEE_ID <> '0' ";//用戶未註冊不用看
            cmdTxt += @" and  DATE_TIME  >= '" + p_DateStart + @"' and  DATE_TIME <='" + p_DateEnd + "'";
            cmdTxt += @" and EMPLOYEE_EIP = '" + p_EmpID + "' ";
            cmdTxt += @" group by EMPLOYEE_ID,EMPLOYEE_EIP";
            DataTable dt01 = dao.Query(cmdTxt);
            return dt01;
        }

        private DataTable checkExportData02(string p_DateStart, string p_DateEnd, string p_EmpID)
        {

            string cmdTxt = "";
            cmdTxt = @" select EMPLOYEE_ID,EMPLOYEE_EIP, MAX(DATE_TIME) as DATE_TIME_MAX ,'02'  as DATE_TIME_TYPE";
            cmdTxt += @" from dbo.TB_HR_CLOCKTIME ";
            cmdTxt += @" where EMPLOYEE_ID <> '0' ";//用戶未註冊不用看
            cmdTxt += @" and  DATE_TIME  >= '" + p_DateStart + @"' and  DATE_TIME <='" + p_DateEnd + "'";
            cmdTxt += @" and EMPLOYEE_EIP = '" + p_EmpID + "' ";
            cmdTxt += @" group by EMPLOYEE_ID,EMPLOYEE_EIP";
            DataTable dt02 = dao.Query(cmdTxt);
            return dt02;
        }

    }

}
