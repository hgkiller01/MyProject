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
    
    public partial class Article_D
    {
        public int Article_ID { get; set; }
        public string Lang { get; set; }
        public string Article_Title { get; set; }
        public string Article_Text { get; set; }
    
        public virtual Article_M Article_M { get; set; }
    }
}
