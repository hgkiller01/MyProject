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
    
    public partial class Banner
    {
        public int Banner_ID { get; set; }
        public int Banner_Type_ID { get; set; }
        public string Banner_Link { get; set; }
        public bool IsBlank { get; set; }
        public string Image_Path { get; set; }
        public bool IsEnable { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}
