﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RTS.Weds.DataAcess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RTSWedsEntities : DbContext
    {
        public RTSWedsEntities()
            : base("name=RTSWedsEntities")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Canditate_Personal> Canditate_Personal { get; set; }
        public virtual DbSet<AddressDetail> AddressDetails { get; set; }
        public virtual DbSet<BirthDetail> BirthDetails { get; set; }
        public virtual DbSet<EducationDetail> EducationDetails { get; set; }
        public virtual DbSet<ExpectationDetail> ExpectationDetails { get; set; }
        public virtual DbSet<FamilyDetail> FamilyDetails { get; set; }
    }
}
