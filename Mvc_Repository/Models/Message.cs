//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mvc_Repository.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int Message_ID { get; set; }
        public int Member_ID { get; set; }
        public string Target_Type { get; set; }
        public int Obj_ID { get; set; }
        public string Message_Text { get; set; }
        public string Message_Gps_X { get; set; }
        public string Message_Gps_Y { get; set; }
        public bool IsEnable { get; set; }
        public string CreateIP { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}