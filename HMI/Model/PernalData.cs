using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI.Model
{
    class PernalData
    {
        private string _Eip;
        private string _GName;
        private string _Date;
        private string _MinD;
        private string _MaxD;


        public string 刷卡日期
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public string 原編
        {
            get { return _Eip; }
            set { _Eip = value; }
        }
        public string 部門單位
        {
            get { return _GName; }
            set { _GName = value; }
        }
        public string 上班時間
        {
            get { return _MinD; }
            set { _MinD = value; }
        }

        public string 下班時間
        {
            get { return _MaxD; }
            set { _MaxD = value; }
        }
    }
}
