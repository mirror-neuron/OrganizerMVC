﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrganizerMVC.App_Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbEntities : DbContext
    {
        public DbEntities()
            : base("name=DbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<ContactsEmails> ContactsEmails { get; set; }
        public virtual DbSet<ContactsOthers> ContactsOthers { get; set; }
        public virtual DbSet<ContactsPhones> ContactsPhones { get; set; }
        public virtual DbSet<ContactsSkypes> ContactsSkypes { get; set; }
        public virtual DbSet<Events> Events { get; set; }
    }
}
