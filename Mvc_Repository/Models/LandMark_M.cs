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
    
    public partial class LandMark_M
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LandMark_M()
        {
            this.LandMark_D = new HashSet<LandMark_D>();
            this.LandMark_Estimate = new HashSet<LandMark_Estimate>();
        }
    
        public int LandMark_ID { get; set; }
        public string LandMark_SiteID { get; set; }
        public string LandMark_Type { get; set; }
        public Nullable<int> Icon_ID { get; set; }
        public string LandMark_Tel { get; set; }
        public string LandMark_Url { get; set; }
        public int LandMark_Position { get; set; }
        public Nullable<int> LandMark_CityCode { get; set; }
        public string LandMark_ZipCode { get; set; }
        public string LandMark_Gps_X { get; set; }
        public string LandMark_Gps_Y { get; set; }
        public Nullable<int> LandMark_Agoda_ID { get; set; }
        public string LandMark_3_checkin { get; set; }
        public string LandMark_3_checkout { get; set; }
        public int LandMark_PageView { get; set; }
        public Nullable<int> MinPrice { get; set; }
        public Nullable<int> MaxPrice { get; set; }
        public bool IsActivity { get; set; }
        public string ActivityUrl { get; set; }
        public bool IsDiscount { get; set; }
        public string Discount { get; set; }
        public string PdfFile { get; set; }
        public bool IsClaim { get; set; }
        public bool IsEnable { get; set; }
        public bool IsOfficial { get; set; }
        public bool IsOpen { get; set; }
        public bool IsProcess { get; set; }
        public Nullable<int> CreateMember_ID { get; set; }
        public string CreateIP { get; set; }
        public System.DateTime CreateDate { get; set; }
        public double Estimate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LandMark_D> LandMark_D { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LandMark_Estimate> LandMark_Estimate { get; set; }
    }
}