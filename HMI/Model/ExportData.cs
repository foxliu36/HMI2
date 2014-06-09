using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI.Model
{
    //顯示物件為中文是因為要讓datagridview 上面的header是中文的,如果使用增加datagridview column 點選第一次顯示正常
    //再點其他功能後再點回去就會變回原來的英文
    public class ExportData
    {
        private string _EmpCNo;
        private string _Date;
        private string _Time;
        private string _Type;
        private string _EmpNo;

        public string 員工卡號
        {
            get { return _EmpCNo; }
            set { _EmpCNo = value; }
        }

        public string 刷卡日期
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public string 刷卡時間
        {
            get { return _Time; }
            set { _Time = value; }
        }

        public string 進出別
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public string 員工編號
        {
            get { return _EmpNo; }
            set { _EmpNo = value; }
        }
    }
}
