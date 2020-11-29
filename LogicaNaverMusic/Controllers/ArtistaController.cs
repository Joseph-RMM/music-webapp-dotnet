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

        public proc_AddArtistToFavorite_Result AddArtistToFav(int idUser, int idArtist)
        {
            FavArtista favArtista = new FavArtista();

            favArtista.idUser = idUser;
            favArtista.idArtista = idArtist;

            proc_AddArtistToFavorite_Result add = new proc_AddArtistToFavorite_Result();
            add = modelDb.proc_AddArtistToFavorite(idArtist, idUser).FirstOrDefault();
            modelDb.SaveChanges();
            return add;
        }

        public void RemoveTrackToFav()
        {

        }

        public int GetVotesOfArtist(int idArtist)
        {
            int votos = 0;

            var artist = (from d in modelDb.Artista
                         where d.idArtista == idArtist
                         select d).FirstOrDefault<Artista>();

            if (artist != null)
            {
                votos = artist.Votos_GeneralesAr;
            }

            return votos;
        }
    }
}
