//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TSVSite_Admin.ef
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_ContactUS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_ContactUS()
        {
            this.tbl_ContactUS_Revert = new HashSet<tbl_ContactUS_Revert>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string BusinessWebsite { get; set; }
        public string Subject { get; set; }
        public string BusinessMessage { get; set; }
        public Nullable<bool> hasReplied { get; set; }
        public Nullable<System.DateTime> ReplySentOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ContactUS_Revert> tbl_ContactUS_Revert { get; set; }
    }
}