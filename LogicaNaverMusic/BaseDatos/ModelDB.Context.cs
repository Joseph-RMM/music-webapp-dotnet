﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogicaNaverMusic.BaseDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NaverMusicDBEntities : DbContext
    {
        public NaverMusicDBEntities()
            : base("name=NaverMusicDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<FavAlbum> FavAlbum { get; set; }
        public DbSet<FavArtista> FavArtista { get; set; }
        public DbSet<FavCancion> FavCancion { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<VotoAlbum> VotoAlbum { get; set; }
        public DbSet<VotoArtista> VotoArtista { get; set; }
        public DbSet<VotoCancion> VotoCancion { get; set; }
    }
}