using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.BaseDatos;

namespace LogicaNaverMusic.Controllers
{
     public class CancionController
    {
        private NaverMusicBDEntitiesAWS1 modelDb = new NaverMusicBDEntitiesAWS1();
        public void VoteTrack(int idTrack, int idUser, DateTime date)
        {
            VotoCancion votoCancion = new VotoCancion();

            votoCancion.idTrack = idTrack;
            votoCancion.idUser = idUser;
            votoCancion.fecha = date;

            modelDb.VotoCancion.Add(votoCancion);
            modelDb.SaveChanges();
        }

        public proc_AddTracksToFavorite_Result AddTrackToFav(int idTrack, int idUser)
        {
            FavCancion favCancion = new FavCancion();

            favCancion.idCancion = idTrack;
            favCancion.idUser = idUser;

            proc_AddTracksToFavorite_Result add = new proc_AddTracksToFavorite_Result();
            add = modelDb.proc_AddTracksToFavorite(idTrack, idUser).FirstOrDefault();
            modelDb.SaveChanges();
            return add;
        }

        public void RemoveTrackToFav()
        {

        }

        public int GetVotesOfTrack(int idTrack)
        {
            int votos = 0;

            var track = (from d in modelDb.Cancion
                        where d.idCancion == idTrack
                         select d).FirstOrDefault<Cancion>();

            if (track != null)
            {
                votos = track.Votos_GeneralesC;
            }

            return votos;
        }
    }
}
