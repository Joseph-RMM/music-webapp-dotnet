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
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
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
    
        public virtual ObjectResult<proc_topTenTracks_Result> proc_topTenTracks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_topTenTracks_Result>("proc_topTenTracks");
        }
    
        public virtual ObjectResult<proc_topTenArtists_Result> proc_topTenArtists()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_topTenArtists_Result>("proc_topTenArtists");
        }
    
        public virtual ObjectResult<proc_topTenAlbum_Result> proc_topTenAlbum()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_topTenAlbum_Result>("proc_topTenAlbum");
        }
    
        public virtual ObjectResult<proc_RankingSemanalTracks_Result> proc_RankingSemanalTracks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_RankingSemanalTracks_Result>("proc_RankingSemanalTracks");
        }
    }
}
