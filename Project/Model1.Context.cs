﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AuthorizationDBEntities6 : DbContext
    {
        public AuthorizationDBEntities6()
            : base("name=AuthorizationDBEntities6")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<collect> collect { get; set; }
        public virtual DbSet<JobTitle> JobTitle { get; set; }
        public virtual DbSet<Medicament> Medicament { get; set; }
        public virtual DbSet<MedicamentFirms> MedicamentFirms { get; set; }
        public virtual DbSet<OrderClient> OrderClient { get; set; }
        public virtual DbSet<Shipment> Shipment { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }
    }
}
