﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Cells;
using HMI.Entity;
using HMI.Model;
using Lib.OfficialFactory;

/*** Design by fox ***/
namespace HMI
{
    public partial class fmSearchClockTime : Form
    {

        List<ExportData> ShowList = new List<ExportData>();
        DataTable dtforExl = new DataTable();
        ADaoFactory dao = new DaoFactory(EDaoType.SQLServer);
        
        //匯出excel權限
        int process = 0;
        bool excelright = false;

        public fmSearchClockTime()
        {
            InitializeComponent();
            dao.SetConnectionString("Data Source = 172.26.100.8;Initial Catalog=UOF;User ID=sa;Password=hp1020.;");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //查詢
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                excelright = false;
                lockScreen();

                string dtstart  = dtpStart.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string dtend = dtpEnd.Value.ToString("yyyy-MM-dd")    + " 23:59:00";

                string cmdTxt = @"select c.*,u.NAME,g.GROUP_NAME ";
                cmdTxt += @"from TB_HR_CLOCKTIME c";
                cmdTxt += @" left join TB_EB_USER u on c.EMPLOYEE_EIP = u.ACCOUNT";
                cmdTxt += @" left join dbo.TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID ";
                cmdTxt += @" left join dbo.TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID ";
                cmdTxt += @" where c.EMPLOYEE_ID <> '0' ";//用戶未註冊不用看
                cmdTxt += @" and  c.DATE_TIME  >= '" + dtstart
                        + @"' and  c.DATE_TIME <='" + dtend + "'";
                if (txtEmpNo.Text != "")
                {
                    cmdTxt += @" and EMPLOYEE_EIP = '" + txtEmpNo.Text + "'";
                }

                DataTable dt = dao.Query(cmdTxt);

                var data = (from q in dt.AsEnumerable()
                           select new { 
                                部門 = q.Field<string>("GROUP_NAME"),
                                卡鐘員編 = q.Field<string>("EMPLOYEE_ID"),
                                EIP員編 = q.Field<string>("EMPLOYEE_EIP"),
                                名稱 = q.Field<string>("NAME"),
                                進出時間 = q.Field<DateTime>("DATE_TIME").ToString("yyyy/MM/dd HH:mm"),
                                門禁卡鐘 = q.Field<string>("TERMINAL_ID"),
                                進出方式 = q.Field<string>("VERIFICATION_SOURCE")
                           }).ToList();

                unlockScreen();

                dataGridView1.DataSource = data;
                lbRowCount.Text = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        //匯出
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                excelright = true;
                lockScreen();
                string dtstart = dtpStart.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                string dtend = dtpStart.Value.ToString("yyyy-MM-dd") + " 23:59:00";

                DataTable dt01 = checkExportData01(dtstart, dtend);
                DataTable dt02 = checkExportData02(dtstart, dtend);

                var data = (from q in dt01.AsEnumerable()

                            select new ExportData
                            {
                                員工卡號 = "#" + q.Field<string>("EMPLOYEE_ID").PadLeft(10, '0'),
                                刷卡日期 = q.Field<DateTime>("DATE_TIME_MIN").ToString("yyyy-MM-dd").Replace("-", ""),
                                刷卡時間 = q.Field<DateTime>("DATE_TIME_MIN").ToString("HH:mm").Replace(":", "").PadLeft(4, '0'),
                                進出別 = q.Field<string>("DATE_TIME_TYPE"),
                                員工編號 = q.Field<string>("EMPLOYEE_EIP")
                            }).Union(
                            from p in dt02.AsEnumerable()
                            select new ExportData
                            {
                                員工卡號 = "#" + p.Field<string>("EMPLOYEE_ID").PadLeft(10, '0'),
                                刷卡日期 = p.Field<DateTime>("DATE_TIME_MAX").ToString("yyyy-MM-dd").Replace("-", ""),
                                刷卡時間 = p.Field<DateTime>("DATE_TIME_MAX").AddMinutes(1).ToString("HH:mm").Replace(":", "").PadLeft(4, '0'),
                                進出別 = p.Field<string>("DATE_TIME_TYPE"),
                                員工編號 = p.Field<string>("EMPLOYEE_EIP")
                            });

                var databyEmpNo = from q in data
                                  where q.員工編號.Equals(txtEmpNo.Text.Trim().ToUpper())
                                  select q;

                 unlockScreen();
                if (txtEmpNo.Text == "")
                {
                    dataGridView1.DataSource = data.ToList<ExportData>();
                    this.ShowList = data.ToList<ExportData>();
                    this.dtforExl = ConvertToDataTable<ExportData>(
                                                                    data.Select(p => new ExportData { 
                                                                        員工卡號 = p.員工卡號, 
                                                                        刷卡日期 = p.刷卡日期, 
                                                                        刷卡時間 = p.刷卡時間, 
                                                                        進出別 = p.進出別 
                                                                    }).ToList<ExportData>()
                                                                    );
                }
                else {
                    dataGridView1.DataSource = databyEmpNo.ToList<ExportData>();
                    this.ShowList = databyEmpNo.ToList<ExportData>();
                    this.dtforExl = ConvertToDataTable<ExportData>(
                                                                    databyEmpNo
                                                                    .Select(p => new ExportData { 
                                                                        員工卡號 = p.員工卡號, 
                                                                        刷卡日期 = p.刷卡日期, 
                                                                        刷卡時間 = p.刷卡時間, 
                                                                        進出別 = p.進出別 
                                                                    }).ToList<ExportData>()
                                                                    );
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //單人匯出
        private void btnPersonalCheck_Click(object sender, EventArgs e)
        {
            if (txtEmpNo.Text.Equals(""))
            {
                MessageBox.Show("請輸入員編");
                return;
            }
            lockScreen();
            
            List<TB_HR_JOBTIME> lJobtime = new List<TB_HR_JOBTIME>();

            //查詢是否排休
            using(var en = new UOFEntities())
            {
                lJobtime = (from q in en.TB_HR_JOBTIME
                            where txtEmpNo.Text.Equals(q.SMID)
                            select q).ToList<TB_HR_JOBTIME>();
            }

            List<DateTime> lvacation = new List<DateTime>();

            foreach (var item in lJobtime)
            {
                lvacation.Add(new DateTime(Convert.ToInt16(item.JOB_YEAR), Convert.ToInt16(item.JOB_MONTH), Convert.ToInt16(item.JOB_DAY)));
            }

            if (txtEmpNo.Text != "")
            {

                DateTime dtstart = dtpStart.Value.Date;
                DateTime dtend = dtpEnd.Value.Date;

                List<PernalData> totalList = new List<PernalData>();
                while (dtstart <= dtend)
                {
                    string startdate = dtstart.ToString("yyyy-MM-dd");

                    DataTable dt = checkPersonalData(startdate);

                    var data = (from q in dt.AsEnumerable()
                                select new PernalData
                                {

                                    原編 = q.Field<string>("EMPLOYEE_EIP"),
                                    部門單位 = q.Field<string>("GROUP_NAME") + " " + q.Field<string>("TITLE_NAME"),
                                    刷卡日期 = q.Field<DateTime>("DATE_TIME_MIN").ToString("yyyy/MM/dd"),
                                    上班時間 = q.Field<DateTime>("DATE_TIME_MIN").ToString("HH:mm").Replace(":", ""),
                                    下班時間 = q.Field<DateTime>("DATE_TIME_MAX").ToString("HH:mm").Replace(":", ""),

                                }).ToList();

                    foreach (PernalData item in data)
                    {
                        totalList.Add(item);

                        //檢查有沒有休假
                        int check = lvacation.Where(p => p.Equals(DateTime.Parse(item.刷卡日期))).Count();

                        if (cbvacation.Checked && check > 0)
                        {
                            totalList.Remove(item);
                        }
                    }

                    dtstart = dtstart.AddDays(1);
                }
                unlockScreen();

                dataGridView1.DataSource = totalList;
                dtforExl = ConvertToDataTable<PernalData>(totalList);

            }
            else
            {
                MessageBox.Show("一定要輸入員工編號");
                unlockScreen();
            }
            
        }

        //ListToDataTable
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        //轉成和泰格式
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //如果要匯出的不只一天
                if (excelright)
                {
                    lockScreen();

                    Lib.ExcelExport ex = new Lib.ExcelExport();
                    ex.SetColumeName(new string[] { "員工卡號", "刷卡日期", "刷卡時間", "進出別" });
                    ex.SetNumberFormat("C1", "C" + dtforExl.Rows.Count + 1, "0000");
                    ex.SetNumberFormat("D1", "D" + dtforExl.Rows.Count + 1, "00");
                    //ex.myDGV = dataGridView1;
                    ex.ExportExcel(this.dtforExl);

                    unlockScreen();
                    
                }
                else
                {
                    MessageBox.Show("請先點匯出資料");
                    unlockScreen();
                }

                
            }
            catch (Exception ex)
            {
                unlockScreen();
                MessageBox.Show(ex.ToString());
            }
        }

        //多日轉成和泰格式
        private void btnToMultiExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpStart.Value != dtpEnd.Value)
                {
                    lockScreen();

                    List<DataTable> dtList = new List<DataTable>();

                    DateTime dtstart = dtpStart.Value.Date;
                    DateTime dtend = dtpEnd.Value.Date;
                    while (dtstart <= dtend)
                    {

                        string strstart = dtstart.ToString("yyyy-MM-dd") + " 00:00:00";
                        string strend = dtstart.ToString("yyyy-MM-dd") + " 23:59:00";

                        DataTable dt01 = checkExportData01(strstart, strend);
                        DataTable dt02 = checkExportData02(strstart, strend);

                        var data = (from q in dt01.AsEnumerable()

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

                        dtList.Add(ConvertToDataTable<ExportData>(data.ToList<ExportData>()));
                        dtstart = dtstart.AddDays(1);
                    }

                    Lib.ExcelExport ex = new Lib.ExcelExport();
                    ex.SetColumeName(new string[] { "員工卡號", "刷卡日期", "刷卡時間", "進出別" });
                    ex.MiltiExportExcel(dtList, "出勤_管理者");
                    
                    unlockScreen();
                }
                else
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                unlockScreen();
            }
        }

        //個人出缺勤匯出Excel
        private void btnPersonalToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ////宣告EXCEL工具
                //MemoryStream ms = new MemoryStream(Resources.Aspose.Aspose_Excel_License);
                //Aspose.Cells.License license = new Aspose.Cells.License();
                //license.SetLicense(ms);
                //Workbook newWbookNur = new Workbook();

                ////載入樣板資料
                //newWbookNur.Open(Request.MapPath("~/CDS/HR/HRAttendance/HTreport/HTReport.xls"));

                //string sheetNameNur = string.Format("{0}{1}", "出勤", "_管理者");
                //newWbookNur.Worksheets.Add();
                //newWbookNur.Worksheets[0].Name = sheetNameNur;//設定頁籤名稱

                //Cells cellsA = newWbookNur.Worksheets[0].Cells;//頁籤1的CELL
                //cellsA.Clear();
                //cellsA.ImportDataTable(dtcopy, true, 0, 0, dtcopy.Rows.Count, dtcopy.Columns.Count);
                ////產生檔案
                //MemoryStream stream = new MemoryStream();
                //newWbookNur.Save(stream, FileFormatType.Default);
                #region "aspose.dll"
               
                //Workbook newbook = new Workbook();

                //newbook.Open(Application.StartupPath +"\\HTReport.xls");

                //newbook.Worksheets.Add();
                //newbook.Worksheets[0].Name = "個人出勤";

                //Cells cellA = newbook.Worksheets[0].Cells;
                //cellA.Clear();
                //cellA.ImportDataTable(dtforExl, true, 0, 0, dtforExl.Rows.Count, dtforExl.Columns.Count);

               

                //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //saveFileDialog1.Filter = "(*.xls)";

                //if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                //    MemoryStream stream = new MemoryStream();
                //    //newbook.Save(stream, FileFormatType.Default);
                //    newbook.Save(saveFileDialog1.FileName, FileFormatType.Default);

                //    //System.Diagnostics.Process.Start(saveFileDialog1.FileName);
                //}
                #endregion

                lockScreen();

                Lib.ExcelExport ex = new Lib.ExcelExport();
                ex.SetColumeName(new string[] { "刷卡日期", "原編", "部門單位", "上班時間", "下班時間" });
                //ex.worksheet.Name = "123456";
                ex.SetNumberFormat("D1", "D" + dtforExl.Rows.Count + 1, "0000");
                ex.SetNumberFormat("E1", "E" + dtforExl.Rows.Count + 1, "0000");
                //ex.myDGV = dataGridView1;
                ex.ExportExcel(this.dtforExl);

                unlockScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private DataTable checkExportData01(string p_DateStart, string p_DateEnd)
        {

            string cmdTxt = @" select EMPLOYEE_ID,EMPLOYEE_EIP,MIN(DATE_TIME) as DATE_TIME_MIN, '01'  as DATE_TIME_TYPE ";
            cmdTxt += @" from dbo.TB_HR_CLOCKTIME ";
            cmdTxt += @" where EMPLOYEE_ID <> '0' ";//用戶未註冊不用看
            cmdTxt += @" and  DATE_TIME  >= '" + p_DateStart + @"' and  DATE_TIME <='" + p_DateEnd + "'";
            cmdTxt += @" group by EMPLOYEE_ID,EMPLOYEE_EIP";
            DataTable dt01 = dao.Query(cmdTxt);
            return dt01;
        }

        private DataTable checkExportData02(string p_DateStart, string p_DateEnd)
        {

            string cmdTxt = "";
            cmdTxt = @" select EMPLOYEE_ID,EMPLOYEE_EIP, MAX(DATE_TIME) as DATE_TIME_MAX ,'02'  as DATE_TIME_TYPE";
            cmdTxt += @" from dbo.TB_HR_CLOCKTIME ";
            cmdTxt += @" where EMPLOYEE_ID <> '0' ";//用戶未註冊不用看
            cmdTxt += @" and  DATE_TIME  >= '" + p_DateStart + @"' and  DATE_TIME <='" + p_DateEnd + "'";
            cmdTxt += @" group by EMPLOYEE_ID,EMPLOYEE_EIP";
            DataTable dt02 = dao.Query(cmdTxt);
            return dt02;
        }

        private DataTable checkPersonalData(string p_StartDate) 
        {
            string cmdTxt = " select a.*,b.DATE_TIME_MAX ,g.GROUP_NAME, t.TITLE_NAME from ";
            cmdTxt += @" (select EMPLOYEE_ID,EMPLOYEE_EIP,MIN(DATE_TIME) as DATE_TIME_MIN ";
            cmdTxt += @" from dbo.TB_HR_CLOCKTIME ";
            cmdTxt += @" where EMPLOYEE_ID <> ''  ";
            cmdTxt += @" and EMPLOYEE_EIP = '" + txtEmpNo.Text.Trim().ToUpper() + "' ";

            cmdTxt += @" and  DATE_TIME  >= '" + p_StartDate + " 00:00:00" + "' and DATE_TIME  <='" + p_StartDate + " 23:59:00" + "' ";
            cmdTxt += @" group by EMPLOYEE_ID,EMPLOYEE_EIP ) a ";
            cmdTxt += @" join ";
            cmdTxt += @" (select EMPLOYEE_ID,EMPLOYEE_EIP,MAX(DATE_TIME) as DATE_TIME_MAX ";
            cmdTxt += @" from dbo.TB_HR_CLOCKTIME ";
            cmdTxt += @" where EMPLOYEE_ID <> '' ";
            cmdTxt += @" and EMPLOYEE_EIP = '" + txtEmpNo.Text.Trim().ToUpper() + "' ";
            cmdTxt += @" and  DATE_TIME  >= '" + p_StartDate + " 00:00:00" + "' and DATE_TIME  <='" + p_StartDate + " 23:59:00" + "' ";
            cmdTxt += @" group by EMPLOYEE_ID,EMPLOYEE_EIP) b ";
            cmdTxt += @" on a.EMPLOYEE_ID = b.EMPLOYEE_ID ";
            cmdTxt += @" join TB_EB_USER u on b.EMPLOYEE_EIP = u.ACCOUNT ";
            cmdTxt += @" join TB_EB_EMPL_DEP d on u.USER_GUID = d.USER_GUID ";
            cmdTxt += @" join TB_EB_GROUP g	on d.GROUP_ID = g.GROUP_ID ";
            cmdTxt += @" join TB_EB_JOB_TITLE t	on d.TITLE_ID = t.TITLE_ID ";
            cmdTxt += @"  ";

            DataTable dt = dao.Query(cmdTxt);
            return dt;
        }

        
        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.Value = dtpStart.Value;
        }

        public void lockScreen()
        {
            this.Enabled = false;
            process = 0;
            progressBar1.Value = 0;
            backgroundWorker1.RunWorkerAsync();

        }

        public void unlockScreen()
        {
            process = 100;
            this.Enabled = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (process <= 99)
            {
                if (process < 50)
                {
                    Thread.Sleep(new Random().Next(50, 100));
                }
                else
                {
                    Thread.Sleep(new Random().Next(200, 300));
                }
                backgroundWorker1.ReportProgress(process);

                process++;
            }

            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(500);
            //    backgroundWorker1.ReportProgress(i);
            //}
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lbStatus.Text = string.Format("完成進度...... {0}", e.ProgressPercentage);
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbStatus.Text = string.Format("完成進度...... {0}", 100);
            progressBar1.Value = 100;
        }

    }
}
