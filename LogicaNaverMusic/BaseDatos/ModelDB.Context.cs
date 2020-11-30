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
    
    public partial class NaverMusicBDEntitiesAWS1 : DbContext
    {
        public NaverMusicBDEntitiesAWS1()
            : base("name=NaverMusicBDEntitiesAWS1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Album> Album { get; set; }
        public DbSet<Artista> Artista { get; set; }
        public DbSet<Cancion> Cancion { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<VotoAlbum> VotoAlbum { get; set; }
        public DbSet<VotoArtista> VotoArtista { get; set; }
        public DbSet<VotoCancion> VotoCancion { get; set; }
        public DbSet<FavAlbum> FavAlbum { get; set; }
        public DbSet<FavArtista> FavArtista { get; set; }
        public DbSet<FavCancion> FavCancion { get; set; }
    
        public virtual ObjectResult<proc_RankingDiarioArtistas_Result> proc_RankingDiarioArtistas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_RankingDiarioArtistas_Result>("proc_RankingDiarioArtistas");
        }
    
        public virtual ObjectResult<proc_RankingDiarioTracks_Result> proc_RankingDiarioTracks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_RankingDiarioTracks_Result>("proc_RankingDiarioTracks");
        }
    
        public virtual ObjectResult<proc_RankingMensualArtistas_Result> proc_RankingMensualArtistas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_RankingMensualArtistas_Result>("proc_RankingMensualArtistas");
        }
    
        public virtual ObjectResult<proc_RankingMensualTracks_Result> proc_RankingMensualTracks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_RankingMensualTracks_Result>("proc_RankingMensualTracks");
        }
    
        public virtual ObjectResult<proc_RankingSemanalArtistas_Result> proc_RankingSemanalArtistas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_RankingSemanalArtistas_Result>("proc_RankingSemanalArtistas");
        }
    
        public virtual ObjectResult<proc_RankingSemanalTracks_Result> proc_RankingSemanalTracks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_RankingSemanalTracks_Result>("proc_RankingSemanalTracks");
        }
    
        public virtual ObjectResult<proc_topTenAlbum_Result> proc_topTenAlbum()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_topTenAlbum_Result>("proc_topTenAlbum");
        }
    
        public virtual ObjectResult<proc_topTenArtists_Result> proc_topTenArtists()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_topTenArtists_Result>("proc_topTenArtists");
        }
    
        public virtual ObjectResult<proc_topTenTracks_Result> proc_topTenTracks()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_topTenTracks_Result>("proc_topTenTracks");
        }
    
        public virtual int proc_VotarCancion(Nullable<int> idCancion, Nullable<int> idUser, Nullable<System.DateTime> fecha)
        {
            var idCancionParameter = idCancion.HasValue ?
                new ObjectParameter("idCancion", idCancion) :
                new ObjectParameter("idCancion", typeof(int));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_VotarCancion", idCancionParameter, idUserParameter, fechaParameter);
        }
    
        public virtual ObjectResult<proc_GetVotesByUser_Result> proc_GetVotesByUser(Nullable<int> idUser)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_GetVotesByUser_Result>("proc_GetVotesByUser", idUserParameter);
        }
    
        public virtual int proc_VotarArtista(Nullable<int> idArtista, Nullable<int> idUser, Nullable<System.DateTime> fecha)
        {
            var idArtistaParameter = idArtista.HasValue ?
                new ObjectParameter("idArtista", idArtista) :
                new ObjectParameter("idArtista", typeof(int));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_VotarArtista", idArtistaParameter, idUserParameter, fechaParameter);
        }
    
        public virtual int proc_VotarAlbum(Nullable<int> idAlbum, Nullable<int> idUser, Nullable<System.DateTime> fecha)
        {
            var idAlbumParameter = idAlbum.HasValue ?
                new ObjectParameter("idAlbum", idAlbum) :
                new ObjectParameter("idAlbum", typeof(int));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_VotarAlbum", idAlbumParameter, idUserParameter, fechaParameter);
        }
    
        public virtual ObjectResult<proc_AddAlbumToFavorite_Result> proc_AddAlbumToFavorite(Nullable<int> idAlbum, Nullable<int> idUser)
        {
            var idAlbumParameter = idAlbum.HasValue ?
                new ObjectParameter("idAlbum", idAlbum) :
                new ObjectParameter("idAlbum", typeof(int));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_AddAlbumToFavorite_Result>("proc_AddAlbumToFavorite", idAlbumParameter, idUserParameter);
        }
    
        public virtual ObjectResult<proc_AddArtistToFavorite_Result> proc_AddArtistToFavorite(Nullable<int> idArtist, Nullable<int> idUser)
        {
            var idArtistParameter = idArtist.HasValue ?
                new ObjectParameter("idArtist", idArtist) :
                new ObjectParameter("idArtist", typeof(int));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_AddArtistToFavorite_Result>("proc_AddArtistToFavorite", idArtistParameter, idUserParameter);
        }
    
        public virtual ObjectResult<proc_AddTracksToFavorite_Result> proc_AddTracksToFavorite(Nullable<int> idTrack, Nullable<int> idUser)
        {
            var idTrackParameter = idTrack.HasValue ?
                new ObjectParameter("idTrack", idTrack) :
                new ObjectParameter("idTrack", typeof(int));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_AddTracksToFavorite_Result>("proc_AddTracksToFavorite", idTrackParameter, idUserParameter);
        }
    
        public virtual ObjectResult<proc_RankingDiarioAlbum_Result> proc_RankingDiarioAlbum()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_RankingDiarioAlbum_Result>("proc_RankingDiarioAlbum");
        }
    
        public virtual ObjectResult<proc_RankingMensualAlbum_Result> proc_RankingMensualAlbum()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_RankingMensualAlbum_Result>("proc_RankingMensualAlbum");
        }
    
        public virtual ObjectResult<proc_RankingSemanalAlbum_Result> proc_RankingSemanalAlbum()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_RankingSemanalAlbum_Result>("proc_RankingSemanalAlbum");
        }
    
        public virtual ObjectResult<proc_DeleteAlbumToFavorites_Result> proc_DeleteAlbumToFavorites(Nullable<int> idAlbum, Nullable<int> idUser)
        {
            var idAlbumParameter = idAlbum.HasValue ?
                new ObjectParameter("idAlbum", idAlbum) :
                new ObjectParameter("idAlbum", typeof(int));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_DeleteAlbumToFavorites_Result>("proc_DeleteAlbumToFavorites", idAlbumParameter, idUserParameter);
        }
    
        public virtual ObjectResult<proc_DeleteArtistToFavorites_Result> proc_DeleteArtistToFavorites(Nullable<int> idArtist, Nullable<int> idUser)
        {
            var idArtistParameter = idArtist.HasValue ?
                new ObjectParameter("idArtist", idArtist) :
                new ObjectParameter("idArtist", typeof(int));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_DeleteArtistToFavorites_Result>("proc_DeleteArtistToFavorites", idArtistParameter, idUserParameter);
        }
    
        public virtual ObjectResult<proc_DeleteTrackToFavorites_Result> proc_DeleteTrackToFavorites(Nullable<int> idTrack, Nullable<int> idUser)
        {
            var idTrackParameter = idTrack.HasValue ?
                new ObjectParameter("idTrack", idTrack) :
                new ObjectParameter("idTrack", typeof(int));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_DeleteTrackToFavorites_Result>("proc_DeleteTrackToFavorites", idTrackParameter, idUserParameter);
        }
    }
}
