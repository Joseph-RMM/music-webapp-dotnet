using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.BaseDatos;

namespace LogicaNaverMusic.Controllers
{
    public class ArtistaController
    {
        NaverMusicBDEntitiesAWS1 modelDb = new NaverMusicBDEntitiesAWS1();
        public void VoteArtist(int idUser, int idArtist, DateTime date)
        {
            VotoArtista votoArtista = new VotoArtista();

            votoArtista.idUser = idUser;
            votoArtista.idArtist = idArtist;
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
