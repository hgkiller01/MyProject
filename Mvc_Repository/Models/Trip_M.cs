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
    
    public partial class Trip_M
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trip_M()
        {
            this.Trip_D = new HashSet<Trip_D>();
        }
    
        public int Trip_ID { get; set; }
        public int Member_ID { get; set; }
        public string Trip_Name { get; set; }
        public int Trip_Days { get; set; }
        public Nullable<int> Trip_Start { get; set; }
        public Nullable<System.DateTime> Trip_Start_Date { get; set; }
        public Nullable<int> Trip_End { get; set; }
        public Nullable<System.DateTime> Trip_End_Date { get; set; }
        public int Trip_PageView { get; set; }
        public bool IsOpen { get; set; }
        public bool IsOfficial { get; set; }
        public int DownLoad { get; set; }
        public bool IsEnable { get; set; }
        public string CreateIP { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trip_D> Trip_D { get; set; }
    }
}