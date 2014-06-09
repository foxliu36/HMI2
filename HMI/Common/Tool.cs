using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI.Common
{
    public class Tool
    {

        public static DataTable ConvertToDataTable<T>(IList<T> data)
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


        public static string 轉換員編(string p_EmployeeID)
        {
            string l_strNumBer = "";
            string l_strChar = "";
            if (p_EmployeeID.Length == 5)//員編五碼者不變
            {
                return p_EmployeeID.Trim();
            }
            else if (p_EmployeeID.Length == 6)//員編五碼者轉換成英文 990465 > A9904
            {
                l_strNumBer = p_EmployeeID.Substring(0, 4);
                l_strChar = p_EmployeeID.Substring(4, 2);
                l_strChar = 數字轉英文(l_strChar, p_EmployeeID.Length);

            }
            else if (p_EmployeeID.Length == 7)//員編五碼者轉換成英文 990465 > A9904
            {
                l_strNumBer = p_EmployeeID.Substring(2, 3);
                l_strChar = p_EmployeeID.Substring(5, 2);
                l_strChar = 數字轉英文(l_strChar, p_EmployeeID.Length);

            }
            p_EmployeeID = l_strChar + l_strNumBer;
            return p_EmployeeID;
        }

        private static string 數字轉英文(string p_str, int p_strLenth)
        {
            if (p_strLenth == 6)
            {
                switch (p_str)
                {
                    case "65": return "A";
                    case "66": return "B";
                    case "67": return "C";
                    case "68": return "D";
                    case "69": return "E";
                    case "70": return "F";
                    case "71": return "G";
                    case "72": return "H";
                    case "73": return "I";
                    case "74": return "J";
                    case "75": return "K";
                    case "76": return "L";
                    case "77": return "M";
                    case "78": return "N";
                    case "79": return "O";
                    case "80": return "P";
                    case "81": return "Q";
                    default: return "XX";
                }
            }
            else if (p_strLenth == 7)
            {
                switch (p_str)
                {
                    case "65": return "AA";
                    case "66": return "BA";
                    case "67": return "CA";
                    case "68": return "DA";
                    case "69": return "EA";
                    case "70": return "FA";
                    case "71": return "GA";
                    case "72": return "HA";
                    case "73": return "IA";
                    case "74": return "JA";
                    case "75": return "KA";
                    case "76": return "LA";
                    case "80": return "P";
                    default: return "XX";
                }
            }
            else if (p_strLenth == 4)
            {
                switch (p_str)
                {
                    case "78": return "W";
                    default: return "XX";
                }
            }
            else
            {
                return "XX";
            }
        }
    }
}
