using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic;
using LogicaNaverMusic.Controllers; //CONTROLADORES DE LOGICA NEGOCIOS
using LogicaNaverMusic.Models;      //MODELOS DE LOGICA NEGOCIOS     
using LogicaNaverMusic.BaseDatos;   //MODELOS DE BASE DE DATOS   

namespace ConsoleAppTest
{
    class Program
    {

        static void Main(string[] args)
        {
            int eleccion = 0;
            bool login = false;

            while (!login)
            {
                Console.WriteLine("NAVER MUSIC\n1 Login\n2 Crear Usuario");
                eleccion = int.Parse(Console.ReadLine());

                switch (eleccion)
                {
                    case 1:
                        login = LogearUser();
                        break;
                    case 2:
                        CreateUser();
                        break;
                }
            }
            

            while (eleccion != 10)
            {
                Console.WriteLine("BUSQUEDAS\n   " +
                                    "1 para busqueda general\n   " +
                                    "3 para buscar cancion\n   " +
                                    "4 para buscar album\n   " +
                                    "5 para buscar artista\n\n" +
                                  "TOP TEN\n   " +
                                    "6 para ver top ten tracks\n   " +
                                    "7 para ver top ten artistas\n   " +
                                    "8 para ver top ten album\n\n" +
                                  "RANKINS\n   " +
                                    "31 ver rank diario tracks\n   " +
                                    "32 ver rank diario artista\n   " +
                                    "33 ver rank diario album\n   " +
                                    "9 ver rank semanal tracks\n   " +
                                    "10 ver rank mensual tracks\n   " +
                                    "15 ranking semanal artista \n   " +
                                    "16 ranking mensual artista \n   " +
                                    "34 ranking semanal album \n   " +
                                    "35 ranking mensual album \n\n   " +
                                  "VOTOS\n   " +
                                    "11 consulta votos de user por dia\n   " +
                                    "12 votar por cancion\n   " +
                                    "13 votar por artista\n   " +
                                    "14 votar por album \n   " +
                                    "20 obtener votos por cancion\n   " +
                                    "21 obtener votos por artista\n   " +
                                    "22 obtener votos por album\n\n" +
                                  "FAVORITOS\n   " +
                                    "17 agregar cancion a favoritos\n   " +
                                    "18 para agregar artista a favoritos\n   " +
                                    "19 para agregar album a favoritos\n   " +
                                    "23 para obtener canciones favoritar de usuario\n   " +
                                    "24 para obtener albumes favoritos de usuario\n   " +
                                    "25 para obtener artistas favoritos de usuario\n   " +
                                    "26 para buscar cancion en lista de favoritos de usuario\n   " +
                                    "27 para buscar album en lista de favoritos de usuario\n   " +
                                    "28 para buscar artista en lista de favoritos de usuario\n" +
                                    "36 agregar a favoritos cancion (regresa el valor de 1 si ya esta en fav o 0 si aun no esta en fav)\n   " +
                                    "37 agregar a favoritos artista (regresa el valor de 1 si ya esta en fav o 0 si aun no esta en fav)\n   " +
                                    "38 agregar a favoritos album (regresa el valor de 1 si ya esta en fav o 0 si aun no esta en fav)\n   " +
                                    "39 quitar de favoritos cancion (regresa el valor de 1 si fue eliminada de fav)\n   " +
                                    "40 quitar de favoritos artista (regresa el valor de 1 si fue eliminada de fav)\n   " +
                                    "41 quitar de favoritos album (regresa el valor de 1 si fue eliminada de fav)\n\n" +
                                   "ACTUALIZACIONES DE VOTOS\n   " +
                                    "51 actualizar votos de artista, cancion, album por dia (regresa el valor 1 si la actualizacion fue exitosa)\n   " +
                                    "52 actualizar votos de artista, cancion, album por semana (regresa el valor 1 si la actualizacion fue exitosa)\n   " +
                                    "SALIR\n   " +
                                    "100 para salir");
                eleccion = (int.Parse(Console.ReadLine()));

                switch (eleccion)
                {
                    case 1:
                        SearchInAPI();
                        break;
                    case 2:
                        //CreateUser();
                        break;
                    case 3:
                        SearchTrack();
                        break;
                    case 4:
                        SearchAlbum();
                        break;
                    case 5:
                        SearchArtist();
                        break;
                    case 6:
                        TopTenTrack();
                        break;
                    case 7:
                        TopTenArtists();
                        break;
                    case 8:
                        TopTenAlbum();
                        break;
                    case 9:
                        RankingSemanalTracks();
                        break;
                    case 10:
                        RankingMensualTracks();
                        break;
                    case 11:
                        GetVotesByUser();
                        break;
                    case 12:
                        proc_VotarCancion();
                        break;
                    case 13:
                        proc_VotarArtista();
                        break;
                    case 14:
                        proc_VotarALBUM();
                        break;
                    case 15:
                        RankingSemanalArtistas();
                        break;
                    case 16:
                        RankingMensualArtistas();
                        break;
                    case 17:
                        AddTrackToFavorites();
                        break;
                    case 18:
                        AddArtistToFavorites();
                        break;
                    case 19:
                        AddAlbumToFavorites();
                        break;
                    case 20:
                        GetVotesByTrack();
                        break;
                    case 21:
                        GetVotesByArtist();
                        break;
                    case 22:
                        GetVotesByAlbum();
                        break;
                    case 23:
                        GetFavoritesTracks();
                        break;
                    case 24:
                        GetFavoritesAlbums();
                        break;
                    case 25:
                        GetFavoritesArtist();
                        break;
                    case 26:
                        VerifyFavoriteTrack();
                        break;
                    case 27:
                        VerifyFavoriteAlbum();
                        break;
                    case 28:
                        VerifyFavoriteArtist();
                        break;
                    case 31:
                        RankingDiarioTracks();
                        break;
                    case 32:
                        RankingDiarioArtistas();
                        break;
                    case 33:
                        RankingDiarioAlbum();
                        break;
                    case 34:
                        RankingSemanalAlbum();
                        break;
                    case 35:
                        RankingMensualAlbum();
                        break;
                    case 36:
                        AddTrackToFav();
                        break;
                    case 39:
                        DeleteTrackToFavorites();
                        break;
                    case 37:
                        AddArtistToFav();
                        break;
                    case 40:
                        DeleteArtistToFavorites();
                        break;
                    case 38:
                        AddAlbumToFav();
                        break;
                    case 41:
                        DeleteAlbumToFavorites();
                        break;
                    case 51:
                        Update_By_Day();
                        break;
                    case 52:
                        Update_By_Week();
                        break;
                    case 100:
                        Environment.Exit(0);
                        break;

                }
            }
        }

        static void SearchInAPI()
        {
            Console.WriteLine("Introduzca busqueda");

            string busqueda = (Console.ReadLine());

            APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS

            List<Data> data = new List<Data>();
            data = aPIDeezer.GetDataFromSearchDeezer(busqueda);

            foreach (Data current in data)
            {
                Console.WriteLine(current.artist.name + " " + current.album.title + " " + current.title_short + "\n");
            }
        }

        static void CreateUser()
        {
            Console.WriteLine("CREAR USUARIO");
            Console.WriteLine("Username: ");
            string username = (Console.ReadLine());
            Console.WriteLine("Password: ");
            string password = (Console.ReadLine());
            Console.WriteLine("Nombre: ");
            string nombre = (Console.ReadLine());
            Console.WriteLine("Apellido: ");
            string apellido = (Console.ReadLine());
            Console.WriteLine("Sexo: ");
            string sexo = (Console.ReadLine());
            Console.WriteLine("Foto: ");
            string foto = (Console.ReadLine());
            Console.WriteLine("Estatus: ");
            string estatus = (Console.ReadLine());
            Console.WriteLine("Correo: ");
            string correo = (Console.ReadLine());
            Console.WriteLine("Telefono: ");
            string telefono = (Console.ReadLine());

            UserController userController = new UserController();

            bool userCreate = userController.CreateUser(username, password, nombre, apellido, sexo, foto, estatus, correo,
                telefono);

            if (userCreate)
            {
                Console.WriteLine("USUARIO CREADO");
            }
            else
            {
                Console.WriteLine("ERROR");
            }

        }

        static void SearchTrack()
        {
            Console.WriteLine("Introduzca Id de la cancion");

            string busqueda = (Console.ReadLine());

            APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS

            Data track = new Data();
            track = aPIDeezer.GetTrack(int.Parse(busqueda));

            Console.WriteLine(track.artist.name + " " + track.album.title + " " + track.title_short + "\n");

        }

        static void SearchAlbum()
        {
            Console.WriteLine("Introduzca Id del Album");

            string busqueda = (Console.ReadLine());

            APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS

            AlbumModel album = new AlbumModel();
            album = aPIDeezer.GetAlbum(int.Parse(busqueda));

            Console.WriteLine(album.artist.name + " " + album.title + "\n CANCIONES: \n");

            foreach (Data current in album.tracks.data)
            {
                Console.WriteLine(current.title_short);
            }

            //comentario de prueba


        }

        static void SearchArtist()
        {
            Console.WriteLine("Introduzca Id del Artista");

            string busqueda = (Console.ReadLine());

            APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS

            Artist artist = new Artist();
            artist = aPIDeezer.GetArtist(int.Parse(busqueda));

            Console.WriteLine(artist.name + "\n");
        }

        static void TopTenTrack()
        {
            RankingController rankingController = new RankingController();

            List<proc_topTenTracks_Result> proc = new List<proc_topTenTracks_Result>();
            proc = rankingController.TopTenTrack();

            foreach (proc_topTenTracks_Result current in proc)
            {
                Console.WriteLine(current.idTrack + " " + current.total + "\n");
            }
        }

        static void TopTenArtists()
        {
            RankingController rankingController = new RankingController();

            List<proc_topTenArtists_Result> proc = new List<proc_topTenArtists_Result>();
            proc = rankingController.TopTenArtists();

            foreach (proc_topTenArtists_Result current in proc)
            {
                Console.WriteLine(current.idArtist + " " + current.total + "\n");
            }
        }

        static void TopTenAlbum()
        {
            RankingController rankingController = new RankingController();

            List<proc_topTenAlbum_Result> proc = new List<proc_topTenAlbum_Result>();
            proc = rankingController.TopTenAlbum();

            foreach (proc_topTenAlbum_Result current in proc)
            {
                Console.WriteLine(current.idAlbumm + " " + current.total + "\n");
            }
        }

        static void RankingSemanalTracks()
        {
            RankingController rankingController = new RankingController();

            List<proc_RankingSemanalTracks_Result> proc = new List<proc_RankingSemanalTracks_Result>();
            proc = rankingController.RankingSemanalTracks();

            foreach (proc_RankingSemanalTracks_Result current in proc)
            {
                Console.WriteLine(current.idTrack + " " + current.total + "\n");
            }
        }

        static void RankingMensualTracks()
        {
            RankingController rankingController = new RankingController();

            List<proc_RankingMensualTracks_Result> proc = new List<proc_RankingMensualTracks_Result>();
            proc = rankingController.RankingMensualTracks();

            foreach (proc_RankingMensualTracks_Result current in proc)
            {
                Console.WriteLine(current.idTrack + " " + current.total + "\n");
            }
        }

        static void GetVotesByUser()
        {
            VotoController votoController = new VotoController();

            Console.WriteLine("Ingrese el ID del usuario");
            int id = int.Parse(Console.ReadLine());

            proc_GetVotesByUser_Result proc = new proc_GetVotesByUser_Result();
            proc = votoController.GetVotesByUser(id);
            Console.WriteLine(proc.total + "");
        }

        static void proc_VotarCancion()
        {
            VotoController votoController = new VotoController();

            Console.WriteLine("Ingresa el id cancion");
            int idcancion = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el id user");
            int iduser = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa la fecha");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            bool voto = votoController.proc_VotarCancion(idcancion, iduser, fecha);

            if (voto)
            {
                Console.WriteLine("se ha votado la cancion");
            }
            else
                Console.WriteLine("error, no se ha votado la cancion");
        }

        static bool LogearUser()
        {
            bool login = false;

            UserController userController = new UserController();

            Console.WriteLine("Introduzca correo electronico");
            string correo = Console.ReadLine();
            Console.WriteLine("Introduzca password");
            string password = Console.ReadLine();

            UsuariosModels currentUser = userController.LoginUser(correo, password);

            if (currentUser.idUsuario != 0)
            {
                Console.WriteLine("BIENVENIDO " + currentUser.username);
                login = true;
            }
            else
            {
                Console.WriteLine("Usuario o contrasenia incorrecta");
            }

            return login;
        }

        static void proc_VotarArtista()
        {
            VotoController votoController = new VotoController();

            Console.WriteLine("Ingresa el id artista");
            int idartista = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el id user");
            int iduser = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa la fecha");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            bool voto = votoController.proc_VotarArtista(idartista, iduser, fecha);

            if (voto)
            {
                Console.WriteLine("se ha votado el artista");
            }
            else
                Console.WriteLine("error, no se ha votado el artista");
        }

        static void proc_VotarALBUM()
        {
            VotoController votoController = new VotoController();

            Console.WriteLine("Ingresa el id album");
            int idalbum = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa el id user");
            int iduser = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa la fecha");
            DateTime fecha = DateTime.Parse(Console.ReadLine());

            bool voto = votoController.proc_VotarAlbum(idalbum, iduser, fecha);

            if (voto)
            {
                Console.WriteLine("se ha votado el album");
            }
            else
                Console.WriteLine("error, no se ha votado el album");
        }

        static void RankingSemanalArtistas()
        {
            RankingController rankingController = new RankingController();

            List<proc_RankingSemanalArtistas_Result> proc = new List<proc_RankingSemanalArtistas_Result>();
            proc = rankingController.RankingSemanalArtistas();

            foreach (proc_RankingSemanalArtistas_Result current in proc)
            {
                Console.WriteLine(current.idArtist + " " + current.total + "\n");
            }
        }

        static void RankingMensualArtistas()
        {
            RankingController rankingController = new RankingController();

            List<proc_RankingMensualArtistas_Result> proc = new List<proc_RankingMensualArtistas_Result>();
            proc = rankingController.RankingMensualArtistas();

            foreach (proc_RankingMensualArtistas_Result current in proc)
            {
                Console.WriteLine(current.idArtist + " " + current.total + "\n");
            }
        }

        static void AddTrackToFavorites()
        {
            CancionController cancionController = new CancionController();

            Console.WriteLine("Insertar ID Cancion");
            int idTrack = int.Parse(Console.ReadLine());

            Console.WriteLine("Insertar ID Ususario");
            int idUser = int.Parse(Console.ReadLine());

            cancionController.AddTrackToFav(idTrack, idUser);

            Console.WriteLine("Cancion " + idTrack + " agregada a favoritos");

        }

        static void AddArtistToFavorites()
        {
            ArtistaController artistaController = new ArtistaController();

            Console.WriteLine("Insertar ID Artista");
            int idArtist = int.Parse(Console.ReadLine());

            Console.WriteLine("Insertar ID Ususario");
            int idUser = int.Parse(Console.ReadLine());

            artistaController.AddArtistToFav(idUser, idArtist);

            Console.WriteLine("Artista " + idArtist + " agregada a favoritos");

        }

        static void AddAlbumToFavorites()
        {
            AlbumController albumController = new AlbumController();

            Console.WriteLine("Insertar ID Album");
            int isAlbum = int.Parse(Console.ReadLine());

            Console.WriteLine("Insertar ID Ususario");
            int idUser = int.Parse(Console.ReadLine());

            albumController.AddAlbumToFav(idUser, isAlbum);

            Console.WriteLine("Album " + isAlbum + " agregada a favoritos");
        }

        static void GetVotesByTrack()
        {
            CancionController cancionController = new CancionController();

            Console.WriteLine("Inserte ID Cancion");
            int idTrack = int.Parse(Console.ReadLine());

            Console.WriteLine("La cancion " + idTrack + " tiene " + cancionController.GetVotesOfTrack(idTrack) + 
                " votos");
        }

        static void GetVotesByArtist()
        {
            ArtistaController artistaController = new ArtistaController();

            Console.WriteLine("Inserte ID Artista");
            int idArtist = int.Parse(Console.ReadLine());

            Console.WriteLine("El artista " + idArtist + " tiene " + artistaController.GetVotesOfArtist(idArtist) +
                " votos");
        }

        static void GetVotesByAlbum()
        {
            AlbumController albumController = new AlbumController();

            Console.WriteLine("Inserte ID Album");
            int idAlbum = int.Parse(Console.ReadLine());

            Console.WriteLine("El album " + idAlbum + " tiene " + albumController.GetVotesOfAlbum(idAlbum) +
                " votos");
        }

        static void GetFavoritesTracks()
        {
            UserController userController = new UserController();

            Console.WriteLine("Insertar ID Usuario");

            int idUsuario = int.Parse(Console.ReadLine());

            List<int> favoritesTracks = userController.GetFavoritesTracks(idUsuario);

            Console.WriteLine("FAVORITES TRACKS");

            foreach (int current in favoritesTracks)
            {
                Console.WriteLine(current + "\n");
            }
        }

        static void GetFavoritesAlbums()
        {
            UserController userController = new UserController();

            Console.WriteLine("Insertar ID Usuario");

            int idUsuario = int.Parse(Console.ReadLine());

            List<int> favoritesAlbums = userController.GetFavoritesAlbums(idUsuario);

            Console.WriteLine("FAVORITES ALBUMS");

            foreach (int current in favoritesAlbums)
            {
                Console.WriteLine(current + "\n");
            }
        }

        static void GetFavoritesArtist()
        {
            UserController userController = new UserController();

            Console.WriteLine("Insertar ID Usuario");

            int idUsuario = int.Parse(Console.ReadLine());

            List<int> favoritesArtist = userController.GetFavoritesArtist(idUsuario);

            Console.WriteLine("FAVORITES ARTIST");

            foreach (int current in favoritesArtist)
            {
                Console.WriteLine(current + "\n");
            }
        }

        static void VerifyFavoriteTrack()
        {
            UserController userController = new UserController();

            Console.WriteLine("Insertar ID Usuario");
            int idUser = int.Parse(Console.ReadLine());

            Console.WriteLine("Insertar ID Track");
            int idTrack = int.Parse(Console.ReadLine());

            if (userController.VerifyFavoriteTrack(idUser,idTrack))
            {
                Console.WriteLine("Cancion " + idTrack + " ya ha sido agregada a favoritas");
            }
            else
            {
                Console.WriteLine("Cancion " + idTrack + " no ha sido agregada a favoritas");
            }
        }

        static void VerifyFavoriteAlbum()
        {
            UserController userController = new UserController();

            Console.WriteLine("Insertar ID Usuario");
            int idUser = int.Parse(Console.ReadLine());

            Console.WriteLine("Insertar ID Album");
            int idAlbum = int.Parse(Console.ReadLine());

            if (userController.VerifyFavoriteAlbum(idUser, idAlbum))
            {
                Console.WriteLine("Album " + idAlbum + " ya ha sido agregada a favoritos");
            }
            else
            {
                Console.WriteLine("Album " + idAlbum + " no ha sido agregada a favoritos");
            }
        }

        static void VerifyFavoriteArtist()
        {
            UserController userController = new UserController();

            Console.WriteLine("Insertar ID Usuario");
            int idUser = int.Parse(Console.ReadLine());

            Console.WriteLine("Insertar ID Artist");
            int idArtist = int.Parse(Console.ReadLine());

            if (userController.VerifyFavoriteArtist(idUser, idArtist))
            {
                Console.WriteLine("Artista " + idArtist + " ya ha sido agregado a favoritos");
            }
            else
            {
                Console.WriteLine("Artista " + idArtist + " no ha sido agregado a favoritos");
            }
        }

        static void RankingDiarioTracks()
        {
            RankingController rankingController = new RankingController();

            List<proc_RankingDiarioTracks_Result> proc = new List<proc_RankingDiarioTracks_Result>();
            proc = rankingController.RankingDiarioTracks();

            foreach (proc_RankingDiarioTracks_Result current in proc)
            {
                Console.WriteLine(current.idTrack + " " + current.total + "\n");
            }
        }

        static void RankingDiarioArtistas()
        {
            RankingController rankingController = new RankingController();

            List<proc_RankingDiarioArtistas_Result> proc = new List<proc_RankingDiarioArtistas_Result>();
            proc = rankingController.RankingDiarioArtistas();

            foreach (proc_RankingDiarioArtistas_Result current in proc)
            {
                Console.WriteLine(current.idArtist + " " + current.total + "\n");
            }
        }

        static void RankingDiarioAlbum()
        {
            RankingController rankingController = new RankingController();

            List<proc_RankingDiarioAlbum_Result> proc = new List<proc_RankingDiarioAlbum_Result>();
            proc = rankingController.RankingDiarioAlbum();

            foreach (proc_RankingDiarioAlbum_Result current in proc)
            {
                Console.WriteLine(current.idAlbumm + " " + current.total + "\n");
            }
        }

        static void RankingSemanalAlbum()
        {
            RankingController rankingController = new RankingController();

            List<proc_RankingSemanalAlbum_Result> proc = new List<proc_RankingSemanalAlbum_Result>();
            proc = rankingController.RankingSemanalAlbum();

            foreach (proc_RankingSemanalAlbum_Result current in proc)
            {
                Console.WriteLine(current.idAlbumm + " " + current.total + "\n");
            }
        }

        static void RankingMensualAlbum()
        {
            RankingController rankingController = new RankingController();

            List<proc_RankingMensualAlbum_Result> proc = new List<proc_RankingMensualAlbum_Result>();
            proc = rankingController.RankingMensualAlbum();

            foreach (proc_RankingMensualAlbum_Result current in proc)
            {
                Console.WriteLine(current.idAlbumm + " " + current.total + "\n");
            }
        }

        ///
        /// ///////////////////////////////////////////////
        /// 
        static void AddTrackToFav()
        {
            CancionController cancionController = new CancionController();

            Console.WriteLine("Ingrese el ID de cancion");
            int idcancion = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID de usuario");
            int iduser = int.Parse(Console.ReadLine());

            proc_AddTracksToFavorite_Result proc = new proc_AddTracksToFavorite_Result();
            proc = cancionController.AddTrackToFav(idcancion, iduser);
            Console.WriteLine(proc.total + "");
        }
        static void DeleteTrackToFavorites()
        {
            CancionController cancionController = new CancionController();

            Console.WriteLine("Ingrese el ID de cancion");
            int idcancion = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID de usuario");
            int iduser = int.Parse(Console.ReadLine());

            proc_DeleteTrackToFavorites_Result proc = new proc_DeleteTrackToFavorites_Result();
            proc = cancionController.DeleteTrackToFavorites(idcancion, iduser);
            Console.WriteLine(proc.total + "");
        }

        static void AddArtistToFav()
        {
            ArtistaController artistaController = new ArtistaController();

            Console.WriteLine("Ingrese el ID de artista");
            int idartista = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID de usuario");
            int iduser = int.Parse(Console.ReadLine());

            proc_AddArtistToFavorite_Result proc = new proc_AddArtistToFavorite_Result();
            proc = artistaController.AddArtistToFav(iduser, idartista);
            Console.WriteLine(proc.total + "");
        }
        static void DeleteArtistToFavorites()
        {
            ArtistaController artistaController = new ArtistaController();

            Console.WriteLine("Ingrese el ID de artista");
            int idartista = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID de usuario");
            int iduser = int.Parse(Console.ReadLine());

            proc_DeleteArtistToFavorites_Result proc = new proc_DeleteArtistToFavorites_Result();
            proc = artistaController.DeleteArtistToFavorites(iduser, idartista);
            Console.WriteLine(proc.total + "");
        }

        static void AddAlbumToFav()
        {
            AlbumController albumController = new AlbumController();

            Console.WriteLine("Ingrese el ID de album");
            int idalbum = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID de usuario");
            int iduser = int.Parse(Console.ReadLine());

            proc_AddAlbumToFavorite_Result proc = new proc_AddAlbumToFavorite_Result();
            proc = albumController.AddAlbumToFav(iduser, idalbum);
            Console.WriteLine(proc.total + "");
        }
        static void DeleteAlbumToFavorites()
        {
            AlbumController albumController = new AlbumController();

            Console.WriteLine("Ingrese el ID de album");
            int idalbum = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID de usuario");
            int iduser = int.Parse(Console.ReadLine());

            proc_DeleteAlbumToFavorites_Result proc = new proc_DeleteAlbumToFavorites_Result();
            proc = albumController.DeleteAlbumToFavorites(iduser, idalbum);
            Console.WriteLine(proc.total + "");
        }

        static void Update_By_Day()
        {
            ActualizaVotoController actualizaVotoController = new ActualizaVotoController();

            Sp_ProcesoDSMUpdate_By_Day_Result sp = new Sp_ProcesoDSMUpdate_By_Day_Result();
            sp = actualizaVotoController.Update_By_Day();
            if (sp.total == 1)
            {
                Console.WriteLine("se ha actualizado exitosamente: " + sp.total);
            }
            else
            {
                Console.WriteLine("no se actualizo");
            }
        }

        static void Update_By_Week()
        {
            ActualizaVotoController actualizaVotoController = new ActualizaVotoController();

            Sp_ProcesoDSMUpdate_By_Week_Result sp = new Sp_ProcesoDSMUpdate_By_Week_Result();
            sp = actualizaVotoController.Update_By_Week();
            if (sp.total == 1)
            {
                Console.WriteLine("se ha actualizado exitosamente: " + sp.total);
            }
            else
            {
                Console.WriteLine("no se actualizo");
            }
        }
    }
}
