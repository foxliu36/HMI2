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

        public void ExportExcel(System.Data.DataTable p_dt)
        {
            try
            {
                System.Data.DataTable dt1 = p_dt;


                //bool fileSaved = false;
                string saveFileName = "";
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xlsx";
                saveDialog.Filter = "Excel文件|*.xlsx";
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0)
                    return;
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("無法建立Excel，可能您的電腦未安装Excel");
                    return;
                }

                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                worksheet.Name = "123";

                //載入Excel Header Names
                for (int i = 0; i < CNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1] = CNames[i];
                }


                Microsoft.Office.Interop.Excel.Range rangeinfo = worksheet.Range["C1", "C" + dt1.Rows.Count + 1];
                Microsoft.Office.Interop.Excel.Range rangeinfo2 = worksheet.Range["D1", "D" + dt1.Rows.Count + 1];
                rangeinfo.NumberFormat = "0000";
                rangeinfo2.NumberFormat = "00";
                ////塞入數字
                for (int r = 0; r < dt1.Rows.Count; r++)
                {
                    for (int i = 0; i < dt1.Columns.Count; i++)
                    {
                        
                        //變顏色
                        //worksheet.Range["A1", "B4"].Interior.ColorIndex = 39;
                       
                        worksheet.Cells[r + 2, i + 1] = dt1.Rows[r][i].ToString();

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
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("無法建立Excel，可能您的電腦未安装Excel");
                    return;
                }

                saveFileName = saveFileName.Insert(saveFileName.LastIndexOf("."),"__0");

                //對List中的每個Datatable做匯出
                for (int i = 0; i < p_dtL.Count; i++)
                {
                    //變更檔案名稱(跳號)
                    saveFileName = saveFileName.Replace("__" + i, "__" + (i + 1));

                    Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                    Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                    worksheet.Name = p_Sheetname;

                    for (int n = 0; n < CNames.Length; n++)
                    {
                        worksheet.Cells[1, n + 1] = CNames[n];
                    }

                    Microsoft.Office.Interop.Excel.Range rangeinfo = worksheet.Range["C1", "C" + p_dtL[i].Rows.Count + 1];
                    Microsoft.Office.Interop.Excel.Range rangeinfo2 = worksheet.Range["D1", "D" + p_dtL[i].Rows.Count + 1];
                    rangeinfo.NumberFormat = "0000";
                    rangeinfo2.NumberFormat = "00";
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
        
    }
    
}
