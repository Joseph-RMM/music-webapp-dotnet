using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.BaseDatos;

namespace LogicaNaverMusic.Controllers
{
    class AlbumController
    {
        NaverMusicDBEntities modelDb = new NaverMusicDBEntities();

        public void VoteAlbum(int idUser, int idAlbum, DateTime date)
        {
            VotoAlbum votoAlbum = new VotoAlbum();

            votoAlbum.idAlbum = idAlbum;
            votoAlbum.idUser = idUser;
            votoAlbum.fecha = date;

            modelDb.VotoAlbum.Add(votoAlbum);
            modelDb.SaveChanges();
        }

        public void AddAlbumToFav(int idUser, int idAlbum)
        {
            VotoAlbum votoAlbum = new VotoAlbum();

            votoAlbum.idAlbum = idAlbum;
            votoAlbum.idUser = idUser;

            modelDb.VotoAlbum.Add(votoAlbum);
            modelDb.SaveChanges();
        }
    }
}
