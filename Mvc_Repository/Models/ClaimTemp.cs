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
    
    public partial class ClaimTemp
    {
        public int ClaimTemp_ID { get; set; }
        public int ClaimTemp_LandMark_ID { get; set; }
        public string ClaimTemp_StoreName { get; set; }
        public string ClaimTemp_Phone { get; set; }
        public string ClaimTemp_Notifier { get; set; }
        public string ClaimTemp_Zip { get; set; }
        public string ClaimTemp_Address { get; set; }
        public string ClaimTemp_Email { get; set; }
        public string ClaimTemp_Password { get; set; }
        public System.Guid ClaimTemp_UID { get; set; }
        public string ClaimTemp_VerifyCode { get; set; }
        public string ClaimTemp_Status { get; set; }
        public bool IsClose { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}
