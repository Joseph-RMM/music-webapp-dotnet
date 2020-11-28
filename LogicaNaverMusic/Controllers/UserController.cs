using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.BaseDatos;
using LogicaNaverMusic.Helper;
using LogicaNaverMusic.Models;

namespace LogicaNaverMusic.Controllers
{
    public class UserController
    {
        private NaverMusicBDEntitiesAWS1 modelDb = new NaverMusicBDEntitiesAWS1();
        public bool CreateUser(string username, string password, string nombre, string apellido, string sexo,
            string foto, string status, string correo, string telefono)
        {
            bool creado = false;

            if (!CompareUser(username))
            {
                Usuarios user = new Usuarios();

                user.username = username;
                user.passsword = HashHelper.GetSHA256(password);
                user.nombre = nombre;
                user.apellido = apellido;
                user.sexo = sexo;
                user.foto = foto;
                user.estatus = status;
                user.correo = correo;
                user.telefono = telefono;

                modelDb.Usuarios.Add(user);
                modelDb.SaveChanges();

                creado = true;
            }
            

            return creado;
        }

        private bool CompareUser(string username)
        {
            bool exist = false;

            var user = (from d in modelDb.Usuarios
                        where d.username == username
                        select d).FirstOrDefault<Usuarios>();

            if (user != null)
            {
                exist = true;
            }

            return exist;
        }

        public UsuariosModels LoginUser(string correo, string password)
        {
            UsuariosModels currentUser = new UsuariosModels();

            var user = (from u in modelDb.Usuarios
                       where u.correo == correo
                       select u).FirstOrDefault<Usuarios>();

            if (user != null)
            {
                string passHash = HashHelper.GetSHA256(password).Trim();

                if (passHash.Equals(user.passsword.Trim()))
                {
                    currentUser.idUsuario = user.idUsuario;
                    currentUser.nombre = user.nombre;
                    currentUser.apellido = user.apellido;
                    currentUser.correo = user.correo;
                    currentUser.estatus = user.estatus;
                    currentUser.foto = user.foto;
                    currentUser.sexo = user.sexo;
                    currentUser.telefono = user.telefono;
                    currentUser.username = user.username;
                }
            }
            return currentUser;
        }

        public List<int> GetFavoritesTracks(int idUser)
        {
            List<int> favoritesTracks = new List<int>();

            IEnumerable<int> lst = from u in modelDb.FavCancion
                                    where u.idUser == idUser
                                    select u.idCancion;

            if (lst != null)
            {
                favoritesTracks = lst.ToList();
            }

            return favoritesTracks;
        }

        public List<int> GetFavoritesAlbums(int idUser)
        {
            List<int> favoritesAlbums = new List<int>();

            IEnumerable<int> lst = from u in modelDb.FavAlbum
                                   where u.idUser == idUser
                                   select u.idAlbum;

            if (lst != null)
            {
                favoritesAlbums = lst.ToList();
            }

            return favoritesAlbums;
        }

        public List<int> GetFavoritesArtist(int idUser)
        {
            List<int> favoritesArtist = new List<int>();

            IEnumerable<int> lst = from u in modelDb.FavArtista
                                   where u.idUser == idUser
                                   select u.idArtista;

            if (lst != null)
            {
                favoritesArtist = lst.ToList();
            }

            return favoritesArtist;
        }
    }
}
