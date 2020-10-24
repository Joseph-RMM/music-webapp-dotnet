﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.BaseDatos;

namespace LogicaNaverMusic.Controllers
{
    class CancionController
    {
        private NaverMusicDBEntities modelDb = new NaverMusicDBEntities();
        public void VoteTrack(int idTrack, int idUser, DateTime date)
        {
            VotoCancion votoCancion = new VotoCancion();

            votoCancion.idTrack = idTrack;
            votoCancion.idUser = idUser;
            votoCancion.fecha = date;

            modelDb.VotoCancion.Add(votoCancion);
            modelDb.SaveChanges();
        }

        public void AddTrackToFav(int idTrack, int idUser)
        {
            FavCancion favCancion = new FavCancion();

            favCancion.idCancion = idTrack;
            favCancion.idUser = idUser;

            modelDb.FavCancion.Add(favCancion);
            modelDb.SaveChanges();
        }

        public void RemoveTrackToFav()
        {

        }
    }
}
