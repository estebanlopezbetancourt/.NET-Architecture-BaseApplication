﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseApplication.DAL.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SimceSampleDbConnection : DbContext
    {
        public SimceSampleDbConnection()
            : base("name=SimceSampleDbConnection")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comuna> Comuna { get; set; }
        public virtual DbSet<Examinador> Examinador { get; set; }
        public virtual DbSet<ExaminadorRol> ExaminadorRol { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
    }
}
