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
    
    public partial class Event_Data
    {
        public int Event_ID { get; set; }
        public int Event_Hotel_ID { get; set; }
        public int Event_Hotel_Room_ID { get; set; }
        public int Event_Type { get; set; }
        public System.DateTime Event_Day { get; set; }
        public string Event_Name { get; set; }
        public string Event_Email { get; set; }
        public string Event_Phone { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}