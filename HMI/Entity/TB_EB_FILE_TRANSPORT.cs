//------------------------------------------------------------------------------
// <auto-generated>
//    這個程式碼是由範本產生。
//
//    對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//    如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMI.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_EB_FILE_TRANSPORT
    {
        public string FILE_ID { get; set; }
        public int SOURCE { get; set; }
        public int TARGET { get; set; }
        public int STATE { get; set; }
        public System.DateTime SEND_TIME { get; set; }
        public int TRY { get; set; }
        public string DOWNLOAD_COMPLETED_HANDLER { get; set; }
        public Nullable<System.DateTime> LAST_TRY_TIME { get; set; }
        public string ERROR { get; set; }
        public System.DateTime CREATE_TIME { get; set; }
        public string CREATE_USER { get; set; }
        public string CREATE_FROM { get; set; }
    }
}
