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
    
    public partial class TB_EIP_BULLETIN
    {
        public string BULLETIN_GUID { get; set; }
        public string ANNOUNCER { get; set; }
        public string CLASS_GUID { get; set; }
        public string TOPIC { get; set; }
        public string CONTEXT { get; set; }
        public Nullable<System.DateTime> EXPIRE_DATE { get; set; }
        public string RM_ID { get; set; }
        public string FILE_GROUP_ID { get; set; }
        public System.DateTime CREATE_DATE { get; set; }
        public string MODIFY_USER { get; set; }
        public Nullable<System.DateTime> MODIFY_DATE { get; set; }
        public string PRINT { get; set; }
        public string PRINT_USER_SET { get; set; }
        public string MARQUEE { get; set; }
        public string SYNCMSG { get; set; }
        public string STATUS { get; set; }
        public string ATTACHMENT { get; set; }
        public string CREATE_USER { get; set; }
        public Nullable<System.DateTime> PUBLISH_DATE { get; set; }
        public Nullable<bool> IS_CLONE { get; set; }
        public string OUTER_BULLETION_ID { get; set; }
        public string OUTER_CLASS_GUID { get; set; }
        public string ANNOUNCER_DEP { get; set; }
        public string OUTER_BULLETION_READER { get; set; }
        public Nullable<bool> OUTER_BULLETION_ALLOW_PRINT { get; set; }
        public string OUTER_BULLETION_PRINT_USER { get; set; }
        public Nullable<bool> AUTO_PUBLISH_CONTROL { get; set; }
        public Nullable<System.DateTime> AUTO_PUBLISH_DATE { get; set; }
        public Nullable<bool> IS_DELETE_OUTER_BULL { get; set; }
    }
}
