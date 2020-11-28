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
                                    "9 ver rank semanal tracks\n   " +
                                    "10 ver rank mensual tracks\n   " +
                                    "15 ranking semanal artista \n   " +
                                    "16 ranking mensual artista \n\n" +
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
                                    "19 para agregar album a favoritos\n\n" +
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
    }
}
