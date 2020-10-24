using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.BaseDatos;

namespace LogicaNaverMusic.Controllers
{
    class ArtistaController
    {
        NaverMusicDBEntities modelDb = new NaverMusicDBEntities();
        public void VoteArtist(int idUser, int idArtist, DateTime date)
        {
            VotoArtista votoArtista = new VotoArtista();

            votoArtista.idUser = idUser;
            votoArtista.idArtista = idArtist;
            votoArtista.fecha = date;

            modelDb.VotoArtista.Add(votoArtista);
            modelDb.SaveChanges();
        }

        public void AddArtistToFav(int idUser, int idArtist)
        {
            FavArtista favArtista = new FavArtista();

            favArtista.idUser = idUser;
            favArtista.idArtista = idArtist;

            modelDb.FavArtista.Add(favArtista);
            modelDb.SaveChanges();
        }

        public void RemoveTrackToFav()
        {

        }
    }
}
