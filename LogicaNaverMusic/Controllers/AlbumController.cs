using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.BaseDatos;

namespace LogicaNaverMusic.Controllers
{
    public class AlbumController
    {
        NaverMusicBDEntitiesAWS1 modelDb = new NaverMusicBDEntitiesAWS1();

        public void VoteAlbum(int idUser, int idAlbum, DateTime date)
        {
            VotoAlbum votoAlbum = new VotoAlbum();

            votoAlbum.idAlbumm = idAlbum;
            votoAlbum.idUser = idUser;
            votoAlbum.fecha = date;

            modelDb.VotoAlbum.Add(votoAlbum);
            modelDb.SaveChanges();
        }

        public void AddAlbumToFav(int idUser, int idAlbum)
        {
            FavAlbum favAlbum = new FavAlbum();

            favAlbum.idAlbum = idAlbum;
            favAlbum.idUser = idUser;

            modelDb.FavAlbum.Add(favAlbum);
            modelDb.SaveChanges();
        }

        public int GetVotesOfAlbum(int idAlbum)
        {
            int votos = 0;

            var album = (from d in modelDb.Album
                          where d.idAlbum == idAlbum
                          select d).FirstOrDefault<Album>();

            if (album != null)
            {
                votos = album.Votos_GeneralesAl;
            }

            return votos;
        }
    }
}
