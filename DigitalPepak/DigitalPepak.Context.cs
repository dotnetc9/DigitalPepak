﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DigitalPepak
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class DigitalPepakEntities : DbContext
    {
        public DigitalPepakEntities()
            : base("name=DigitalPepakEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Kewan> Kewan { get; set; }
        public DbSet<Kuis> Kuis { get; set; }
        public DbSet<Tetuwuhan> Tetuwuhan { get; set; }
    
        public virtual ObjectResult<Nullable<int>> GetNewKewanId()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetNewKewanId");
        }
    
        public virtual ObjectResult<Nullable<int>> GetNewKuisId()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetNewKuisId");
        }
    
        public virtual ObjectResult<Nullable<int>> GetNewTetuwuhanId()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetNewTetuwuhanId");
        }
    }
}
