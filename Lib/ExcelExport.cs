using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Data;

namespace Lib
{
    public class ExcelExport
    {
        //傳入Excel上面的標頭名稱
        private string[] CNames;

        Microsoft.Office.Interop.Excel.Application xlApp;
        Microsoft.Office.Interop.Excel.Workbooks workbooks;
        Microsoft.Office.Interop.Excel.Workbook workbook;
        public Microsoft.Office.Interop.Excel.Worksheet worksheet;
        
        public ExcelExport() 
        {
            xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("無法建立Excel，可能您的電腦未安装Excel");
                return;
            }
            workbooks = xlApp.Workbooks;
            workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
        }

        public void ExportExcel(System.Data.DataTable p_dt)
        {
            try
            {

                //bool fileSaved = false;
                string saveFileName = "";
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xlsx";
                saveDialog.Filter = "Excel文件|*.xlsx";
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0)
                    return;
               
                //載入Excel Header Names
                for (int i = 0; i < CNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1] = CNames[i];
                }

                ////塞入數字
                for (int r = 0; r < p_dt.Rows.Count; r++)
                {
                    for (int i = 0; i < p_dt.Columns.Count; i++)
                    {
                        
                        //變顏色
                        //worksheet.Range["A1", "B4"].Interior.ColorIndex = 39;

                        worksheet.Cells[r + 2, i + 1] = p_dt.Rows[r][i].ToString();

                    }
                    System.Windows.Forms.Application.DoEvents();
                }

                worksheet.Columns.EntireColumn.AutoFit();//自動調整欄位

                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);

                        //fileSaved = true;
                    }
                    catch (Exception ex)
                    {
                        //fileSaved = false;
                        MessageBox.Show("匯出文件時出錯,EXCEL文件可能正在使用中！\n" + ex.Message);
                        throw ex;
                    }
                }

                else
                {
                    //fileSaved = false;
                }
                xlApp.Quit();
                GC.Collect();  //回收釋放建議是額外放在外面

                //判斷檔案條件是否都成立，沒問題就開啟EXCEL
                //if (fileSaved && System.IO.File.Exists(saveFileName))
                //    System.Diagnostics.Process.Start(saveFileName); //開啟EXCEL
                MessageBox.Show(saveFileName + "的資料匯出成功", "提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void ExportExcel(System.Data.DataTable p_dt, bool p_Multimode) 
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        //關於困難度 要把多從匯出寫成元件function有困難 擇日再戰
        public void MiltiExportExcel(List<System.Data.DataTable> p_dtL, string p_Sheetname)
        {
            try
            {
                //System.Data.DataTable dt1 = this.dt;

                //bool fileSaved = false;
                string saveFileName = "";
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xlsx";
                saveDialog.Filter = "Excel文件|*.xlsx";
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0)
                    return;

                

                saveFileName = saveFileName.Insert(saveFileName.LastIndexOf("."),"__0");

                //對List中的每個Datatable做匯出
                for (int i = 0; i < p_dtL.Count; i++)
                {
                    //變更檔案名稱(跳號)
                    saveFileName = saveFileName.Replace("__" + i, "__" + (i + 1));

                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    if (xlApp == null)
                    {
                        MessageBox.Show("無法建立Excel，可能您的電腦未安装Excel");
                        return;
                    }
                    Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

                    for (int n = 0; n < CNames.Length; n++)
                    {
                        worksheet.Cells[1, n + 1] = CNames[n];
                    }
                    worksheet.Name = p_Sheetname;

                    Microsoft.Office.Interop.Excel.Range range = worksheet.Range["C1", "C" + p_dtL[i].Rows.Count + 1];
                    Microsoft.Office.Interop.Excel.Range range1 = worksheet.Range["D1", "D" + p_dtL[i].Rows.Count + 1];

                    range.NumberFormat = "0000";
                    range1.NumberFormat = "00";


                    ////塞入數字
                    for (int r = 0; r < p_dtL[i].Rows.Count; r++)
                    {
                        for (int c = 0; c < p_dtL[i].Columns.Count; c++)
                        {
                            worksheet.Cells[r + 2, c + 1] = p_dtL[i].Rows[r][c].ToString();

                        }
                        System.Windows.Forms.Application.DoEvents();
                    }


                    worksheet.Columns.EntireColumn.AutoFit();//自動調整欄位

                    if (saveFileName != "")
                    {
                        try
                        {
                            workbook.Saved = true;
                            workbook.SaveCopyAs(saveFileName);

                            //fileSaved = true;
                        }
                        catch (Exception ex)
                        {
                            //fileSaved = false;
                            MessageBox.Show("匯出文件時出錯,EXCEL文件可能正在使用中！\n" + ex.Message);
                        }
                    }

                    else
                    {
                        //fileSaved = false;
                    }
                    xlApp.Quit();
                    GC.Collect();  //回收釋放建議是額外放在外面

                    //判斷檔案條件是否都成立，沒問題就開啟EXCEL
                    //if (fileSaved && System.IO.File.Exists(saveFileName))
                    //    System.Diagnostics.Process.Start(saveFileName); //開啟EXCEL
                    
                }
                MessageBox.Show(saveFileName + "的資料匯出成功", "提示", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetColumeName(string []p_Name) 
        {
            this.CNames = p_Name;
        }

        public void SetNumberFormat(string p_RangeStart, string p_RangeEnd, string p_FormatStr)
        {
            Microsoft.Office.Interop.Excel.Range range = worksheet.Range[p_RangeStart, p_RangeEnd];
            range.NumberFormat = p_FormatStr;
        }
    }
    
}
