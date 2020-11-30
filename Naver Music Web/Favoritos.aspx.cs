using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LogicaNaverMusic;
using LogicaNaverMusic.Controllers; //CONTROLADORES DE LOGICA NEGOCIOS
using LogicaNaverMusic.Models;      //MODELOS DE LOGICA NEGOCIOS      
using LogicaNaverMusic.BaseDatos;   //MODELOS DE BASE DE DATOS  

namespace Naver_Music_Web {
    public partial class Favoritos : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["userData"] != null) {
                UsuariosModels currentUser = (UsuariosModels)Session["userData"];
                int UserID = currentUser.idUsuario;
                //Checar si el usuario tiene canciones favoritas
                List<Data> favCanciones = GetFavSongs(UserID);
                if (favCanciones.Count > 0) {
                    //Añadir items 
                    foreach (Data song in favCanciones) {
                        panelCanciones.Controls.Add(createMusicItem(song));
                    }
                } else {
                    Label info = new Label {
                        Text = "Añade tus canciones favoritas dando clic en ✩ para encontrarlas aquí",
                        CssClass = "lblPanelInfo"
                    };
                    panelCanciones.Controls.Add(info);
                }
                favCanciones.Clear();

                //Albumes favoritos
                List<AlbumModel> favAlbums = GetFavAlbums(UserID);
                if (favAlbums.Count > 0) {
                    //Añadir items 
                    foreach (AlbumModel album in favAlbums) {
                        panelAlbumes.Controls.Add(createAlbumItem(album));
                    }
                } else {
                    Label info = new Label {
                        Text = "Añade tus álbumes favoritos dando clic en ✩ para encontrarlos aquí",
                        CssClass = "lblPanelInfo"
                    };
                    panelAlbumes.Controls.Add(info);
                }
                favAlbums.Clear();

                //Artistas favoritos
                List<Artist> favArtists = GetFavArtists(UserID);
                if (favArtists.Count > 0) {
                    //Añadir items 
                    foreach (Artist artist in favArtists) {
                        panelArtistas.Controls.Add(createArtistItem(artist));
                    }
                } else {
                    Label info = new Label {
                        Text = "Añade tus artistas favoritos dando clic en ✩ para encontrarlos aquí",
                        CssClass = "lblPanelInfo"
                    };
                    panelArtistas.Controls.Add(info);
                }
            }
        }

        //METODOS DE OBTENCION DE DATOS

        //Placeholder para el método real de la LN
        public List<Data> checkforInfo(string type) => null;

        public List<Data> GetFavSongs(int IDUsuario) {
            UserController userController = new UserController();
            List<int> favoritesTracks = userController.GetFavoritesTracks(IDUsuario);
            List<Data> favList = new List<Data>();
            foreach (int currentID in favoritesTracks) {
                //Buscar la info de la canción
                APIDeezerController aPIDeezer = new APIDeezerController();  
                favList.Add(aPIDeezer.GetTrack(currentID));
            }
            return favList;
        }

        public List<AlbumModel> GetFavAlbums(int IDUsuario) {
            UserController userController = new UserController();
            List<int> favoritesAlbums = userController.GetFavoritesAlbums(IDUsuario);
            List<AlbumModel> favList = new List<AlbumModel>();
            foreach (int currentID in favoritesAlbums) {
                //Buscar info del album
                APIDeezerController aPIDeezer = new APIDeezerController(); 
                favList.Add(aPIDeezer.GetAlbum(currentID));
            }
            return favList;
        }

        public List<Artist> GetFavArtists(int IDUsuario) {
            UserController userController = new UserController();
            List<int> favoritesArtist = userController.GetFavoritesArtist(IDUsuario);
            List<Artist> favList = new List<Artist>();
            foreach (int currentID in favoritesArtist) {
                //Buscar artista
                APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS
                favList.Add(aPIDeezer.GetArtist(currentID));
            }
            return favList;
        }

        //METODOS DE DIBUJO
        public Panel createMusicItem(Data song) {
            return createMusicItem(song.album.cover_medium, song.title_short, song.artist.name,int.Parse(song.artist.id), int.Parse(song.id), song.preview);
        }

        public Panel createMusicItem(string URLCover, string SongName, string ArtistName, int artistID, int SongID, string MP3) {

            Panel wrapper = new Panel {
                CssClass = "wrappermusicitem"
            };
            //Div para los elementos del cover music
            Panel playMusic = new Panel { CssClass = "wrapper-playmusic" };
            ImageButton cover = new ImageButton {
                ImageUrl = URLCover,
                CssClass = "imgcovermusic"
            };
            cover.Click += delegate (object sender, ImageClickEventArgs e) { PlayMusic(sender, e, MP3, URLCover, SongName, ArtistName); };
            ImageButton play = new ImageButton {
                ImageUrl = "assets/playcover.png",
                CssClass = "imgplaymusic"
            };
            play.Click += delegate (object sender, ImageClickEventArgs e) { PlayMusic(sender, e, MP3, URLCover, SongName, ArtistName); };
            playMusic.Controls.Add(cover);
            playMusic.Controls.Add(play);
            Label nombre = new Label {
                Text = SongName,
                CssClass = "songname"
            };
            Button artist = new Button {
                Text = ArtistName,
                CssClass = "btn artistname"
            };
            artist.Click += delegate (object sender, EventArgs e) { ViewArtist(sender, e, artistID); };
            //Crear el wrapper-ratefav
            Panel ratefav = new Panel { CssClass = "wrapper-ratefav" };
            //Obtener votos
            CancionController cancionController = new CancionController();
            int Votos = cancionController.GetVotesOfTrack(SongID);
            Button btnRate = new Button {
                CssClass = "btn rate",
                Text = "♥ " + Votos
            };
            btnRate.Click += delegate (object sender, EventArgs e) { RateClick(sender, e, SongID, 1); };
            //Verificar Favorito
            UserController userController = new UserController();
            UsuariosModels currentUser = (UsuariosModels)Session["userData"];
            int idUser = currentUser.idUsuario;
            Button btnFav = new Button {
                CssClass = "btn fav",
                Text = userController.VerifyFavoriteTrack(idUser, SongID) ? "★" : "✩"
            };
            btnFav.Click += delegate (object sender, EventArgs e) { FavClick(sender, e, SongID, 1); };
            //Añadirlos al mini div
            ratefav.Controls.Add(btnRate);
            ratefav.Controls.Add(btnFav);
            //Añadir todo al wrapper (panel) principal para devolverlo
            wrapper.Controls.Add(playMusic);
            wrapper.Controls.Add(nombre);
            wrapper.Controls.Add(artist);
            wrapper.Controls.Add(ratefav);
            return wrapper;
        }

        public Panel createAlbumItem(AlbumModel album) {
            return createAlbumItem(album.cover_medium, album.title, album.artist.name, int.Parse(album.artist.id), int.Parse(album.id));
        }

        public Panel createAlbumItem(string URLCover, string Title, string ArtistName, int ArtistID, int AlbumID) {
            Panel wrapper = new Panel {
                CssClass = "wrappermusicitem"
            };
            ImageButton cover = new ImageButton {
                ImageUrl = URLCover,
                CssClass = "imgcovermusic"
            };
            cover.Click += delegate (object sender, ImageClickEventArgs e) { ViewAlbum(sender, e, AlbumID); };
            Label nombre = new Label {
                Text = Title,
                CssClass = "songname"
            };
            Button artist = new Button {
                Text = ArtistName,
                CssClass = "btn artistname"
            };
            artist.Click += delegate (object sender, EventArgs e) { ViewArtist(sender, e, ArtistID ); };
            //Crear el wrapper-ratefav
            Panel ratefav = new Panel { CssClass = "wrapper-ratefav" };
            AlbumController albumController = new AlbumController();
            Button btnRate = new Button {
                CssClass = "btn rate",
                Text = "♥ " + albumController.GetVotesOfAlbum(AlbumID)
            };
            btnRate.Click += delegate (object sender, EventArgs e) { RateClick(sender, e, AlbumID, 2); };
            //Verificar Favoritos
            UserController userController = new UserController();
            UsuariosModels currentUser = (UsuariosModels)Session["userData"];
            int idUser = currentUser.idUsuario;
            Button btnFav = new Button {
                CssClass = "btn fav",
                Text = (userController.VerifyFavoriteAlbum(idUser, AlbumID)) ? "★" : "✩"
            };
            btnFav.Click += delegate (object sender, EventArgs e) { FavClick(sender, e, AlbumID, 2); };
            //Añadirlos al mini div
            ratefav.Controls.Add(btnRate);
            ratefav.Controls.Add(btnFav);
            //Añadir todo al wrapper (panel) principal para devolverlo
            wrapper.Controls.Add(cover);
            wrapper.Controls.Add(nombre);
            wrapper.Controls.Add(artist);
            wrapper.Controls.Add(ratefav);
            return wrapper;
        }

        public Panel createArtistItem(Artist artist) {
            return createArtistItem(artist.picture_medium, artist.name, int.Parse(artist.id) );
        }

        public Panel createArtistItem(string URLCover, string ArtistName, int ArtistID) {
            Panel wrapper = new Panel {
                CssClass = "wrappermusicitem"
            };
            ImageButton cover = new ImageButton {
                ImageUrl = URLCover,
                CssClass = "imgcovermusic"
            };
            cover.Click += delegate (object sender, ImageClickEventArgs e) { ViewArtist(sender, e, ArtistID); };
            Label nombre = new Label {
                Text = ArtistName,
                CssClass = "songname"
            };
            //Crear el wrapper-ratefav
            Panel ratefav = new Panel { CssClass = "wrapper-ratefav" };
            ArtistaController artistaController = new ArtistaController();
            Button btnRate = new Button {
                CssClass = "btn rate",
                Text = "♥ " + artistaController.GetVotesOfArtist(ArtistID)
            };
            btnRate.Click += delegate (object sender, EventArgs e) { RateClick(sender, e, ArtistID, 3); };
            //Verificar Favoritos
            UserController userController = new UserController();
            UsuariosModels currentUser = (UsuariosModels)Session["userData"];
            int idUser = currentUser.idUsuario;
            Button btnFav = new Button {
                CssClass = "btn fav",
                Text = (userController.VerifyFavoriteArtist(idUser,ArtistID)) ? "★" : "✩"
            };
            btnFav.Click += delegate (object sender, EventArgs e) { FavClick(sender, e, ArtistID, 3); };
            //Añadirlos al mini div
            ratefav.Controls.Add(btnRate);
            ratefav.Controls.Add(btnFav);
            //Añadir todo al wrapper (panel) principal para devolverlo
            wrapper.Controls.Add(cover);
            wrapper.Controls.Add(nombre);
            wrapper.Controls.Add(ratefav);
            return wrapper;
        }


        public void RateClick(object sender, EventArgs e, int SongID, int type) {
            UsuariosModels currentUser = (UsuariosModels)Session["userData"];
            int iduser = currentUser.idUsuario;
            VotoController votoController = new VotoController();
            proc_GetVotesByUser_Result proc = new proc_GetVotesByUser_Result();
            proc = votoController.GetVotesByUser(currentUser.idUsuario);
            int votosUsados = proc.total ?? 0;
            int votosRestantes = 100 - votosUsados;
            if (votosRestantes > 0) {
                DateTime fecha = DateTime.Now;
                bool voto = false;
                if (type == 1) { //Cancion
                    voto = votoController.proc_VotarCancion(SongID, iduser, fecha);
                } else {
                    if (type == 2) { //Album
                        voto = votoController.proc_VotarAlbum(SongID, iduser, fecha);
                    } else {
                        if (type == 3) { //Artista
                            voto = votoController.proc_VotarArtista(SongID, iduser, fecha);
                        }
                    }
                }

                Response.Redirect("Favoritos.aspx");
            } else {
                ClientScript.RegisterStartupScript(GetType(), "NoMoreVotes" + e.GetHashCode(), "alert('Has alcanzado tu límite de votos por  hoy\n¡Sigue votando mañana!');", true);
            }
        }

        public void FavClick(object sender, EventArgs e, int SongID, int type) {
            //Verificar Favorito
            UserController userController = new UserController();
            UsuariosModels currentUser = (UsuariosModels)Session["userData"];
            int idUser = currentUser.idUsuario;
            if (type == 1) {
                CancionController cancionController = new CancionController();
                bool isFav = userController.VerifyFavoriteTrack(idUser, SongID);
                if (!isFav) { //Add
                    cancionController.AddTrackToFav(SongID, idUser);
                } else { //Remove
                    cancionController.DeleteTrackToFavorites(SongID, idUser);
                }
            }
            if (type == 2) {
                AlbumController albumController = new AlbumController();
                bool isFav = userController.VerifyFavoriteAlbum(idUser, SongID);
                if (!isFav) { //Add
                    albumController.AddAlbumToFav(idUser, SongID);
                } else { //Remove
                    albumController.DeleteAlbumToFavorites(idUser, SongID);
                }
            }
            if (type == 3) {
                ArtistaController artistaController = new ArtistaController();
                bool isFav = userController.VerifyFavoriteArtist(idUser, SongID);
                if (!isFav) { //Add
                    artistaController.AddArtistToFav(idUser,SongID);
                } else { //Remove
                    artistaController.DeleteArtistToFavorites(idUser, SongID);
                }
            }
            Response.Redirect("Favoritos.aspx");
        }

        public void PlayMusic(object sender, ImageClickEventArgs e, string MP3URL, string URLCover, string SongName, string ArtistName) {
            Reproductor.Src = MP3URL;
            miniaturaCover.ImageUrl = URLCover;
            miniNombreCancion.Text = SongName;
            miniNombreArtista.Text = ArtistName;
        }

        protected void ViewAlbum(object sender, ImageClickEventArgs e, int AlbumID) {
            Session["albumViewID"] = AlbumID;
            Response.Redirect("Album.aspx");
        }

        protected void ViewArtist(object sender, EventArgs e, int ArtistID) {
            Session["artistViewID"] = ArtistID;
            Response.Redirect("ArtistPage.aspx");
        }
    }
}