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
    
    public partial class HotelRoom_Set
    {
        public int HotelRoom_ID { get; set; }
        public System.DateTime Set_Date { get; set; }
        public decimal Set_Price { get; set; }
        public int Set_CurrentAmout { get; set; }
        public int Set_BookingAmout { get; set; }
        public bool Set_IsDinner { get; set; }
        public bool Set_IsBreakfast { get; set; }
        public int Set_LimitDay { get; set; }
        public bool Set_IsClose { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}
