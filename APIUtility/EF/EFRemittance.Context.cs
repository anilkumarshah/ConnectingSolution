﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIUtility.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EF_TranServEntities : DbContext
    {
        public EF_TranServEntities()
            : base("name=EF_TranServEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<tbl_FileUpload> tbl_FileUpload { get; set; }
        public virtual DbSet<tbl_RemittanceAgentDetails> tbl_RemittanceAgentDetails { get; set; }
        public virtual DbSet<tbl_StateMaster> tbl_StateMaster { get; set; }
    
        public virtual ObjectResult<GetAgentDetails_Result> GetAgentDetails()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAgentDetails_Result>("GetAgentDetails");
        }
    }
}
