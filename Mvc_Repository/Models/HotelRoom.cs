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
    
    public partial class HotelRoom
    {
        public int HotelRoom_ID { get; set; }
        public int LandMark_ID { get; set; }
        public string Room_Name_TW { get; set; }
        public string Room_Name_CN { get; set; }
        public bool Room_IsBooking { get; set; }
        public int Room_Amount { get; set; }
        public int LimitPeople { get; set; }
        public int Hotel_Bed_ID { get; set; }
        public Nullable<int> RoomArea { get; set; }
        public decimal Default_Pricing { get; set; }
        public decimal Default_UsualPrice { get; set; }
        public decimal Default_HolidayPrice { get; set; }
        public bool Default_IsDinner { get; set; }
        public bool Default_IsBreakfast { get; set; }
        public int Default_CancelPolicy { get; set; }
        public string Room_Desc_TW { get; set; }
        public string Room_Desc_CN { get; set; }
        public string Room_Image_Default { get; set; }
        public string Room_Image_2 { get; set; }
        public string Room_Image_3 { get; set; }
        public string Room_Image_4 { get; set; }
        public string Room_Image_5 { get; set; }
        public int Room_Sort { get; set; }
        public bool IsEnable { get; set; }
        public System.DateTime CreateDate { get; set; }
    }
}
