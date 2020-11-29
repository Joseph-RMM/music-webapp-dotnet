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
    public partial class Inicio : System.Web.UI.Page {
        //Simulacion de datos recuperados de la base de datos
        //TODO: Borrar cuando se implemente la base de datos
        static int VotesDB = 13455;
        static int VotesDB2 = 558;
        static int VotesDB3 = 210;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["userData"] != null) {
                //Display user info
                UsuariosModels currentUser = (UsuariosModels)Session["userData"];
                try {
                    mobileUserImg.ImageUrl = currentUser.foto;
                } catch (Exception exception) {
                    mobileUserImg.ImageUrl = "/assets/nouser.png";
                }
                List<Data> data = (List<Data>)Session["busqueda"];
                panelResultados.Controls.Clear();
                if (data != null) {
                    List<AlbumModel> listaAlbums = albumsInData(data);
                    foreach (AlbumModel albumModel in listaAlbums) {
                        panelResultAlbums.Controls.Add(createAlbumItem(albumModel));
                    }
                    foreach (Data song in data) {
                        panelResultados.Controls.Add(createMusicItem(song));
                    }
                    divBuscar.Visible = true;
                }
                //Simulacion de consulta a la API y llenado del panel
                APIDeezerController aPIDeezer = new APIDeezerController();
                AlbumModel album = new AlbumModel();
                album = aPIDeezer.GetAlbum(178519722);
                panelMusic.Controls.Add(createAlbumItem(album));
                /*
                panelMusic.Controls.Add(createMusicItem("https://cdns-images.dzcdn.net/images/cover/0019510a69161d7af10e25493dc6d544/250x250-000000-80-0-0.jpg", "POP/STARS", "K/DA", true, 1, "https://cdns-preview-d.dzcdn.net/stream/c-d7aac13016a945052b62f48d33edfc55-5.mp3"));
                panelMusic.Controls.Add(createMusicItem("https://cdns-images.dzcdn.net/images/cover/3eddd7a427f3b4debe681e88e0811298/250x250-000000-80-0-0.jpg", "THE BADDEST", "K/DA", false, 2, "https://cdns-preview-7.dzcdn.net/stream/c-7e6dd799aaedf824a6594afb7d6d0b51-3.mp3"));
                panelMusic.Controls.Add(createMusicItem("https://cdns-images.dzcdn.net/images/cover/a06a47a2b7c23bdba9099053302cb35c/250x250-000000-80-0-0.jpg", "MORE", "K/DA", false, 3, "https://cdns-preview-4.dzcdn.net/stream/c-4c33ef6d1f98034b98cc9a5688d29bd0-2.mp3"));*/
            } 
        }


        public List<AlbumModel> albumsInData (List<Data> data) {
            List<AlbumModel> listaAlbums = new List<AlbumModel>();
            foreach (Data song in data) {
                bool add = true;
                foreach (AlbumModel album in listaAlbums) {
                    if (song.album.title == album.title) {
                        add = false;
                    }
                }
                if (add) {
                    AlbumModel toAdd = song.album;
                    toAdd.artist = song.artist;
                    listaAlbums.Add(toAdd);
                }
            }
            return listaAlbums;
        }

        public Panel createMusicItem(Data song) {
            return createMusicItem(song.album.cover_medium, song.title_short, song.artist.name, int.Parse(song.artist.id), int.Parse(song.id), song.preview);
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
            play.Click += delegate (object sender, ImageClickEventArgs e) { PlayMusic(sender, e, MP3,URLCover,SongName,ArtistName); };
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
            btnFav.Click += delegate (object sender, EventArgs e) { FavClick(sender, e, SongID,1); };
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
            return createAlbumItem(album.cover_medium, album.title, album.artist.name, int.Parse(album.artist.id),int.Parse(album.id));
        }

        public Panel createAlbumItem(string URLCover, string Title, string ArtistName, int artistID, int AlbumID) {
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
            artist.Click += delegate (object sender, EventArgs e) { ViewArtist(sender, e, artistID); };
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

        

        public void RateClick(object sender, EventArgs e, int SongID, int type) {
            Button btnRate = (Button)sender;

            UsuariosModels currentUser = (UsuariosModels)Session["userData"];
            int iduser = currentUser.idUsuario;
            VotoController votoController = new VotoController();
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
           
            Response.Redirect("Inicio.aspx");
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

                }
            } 
            if (type == 2) {
                AlbumController albumController = new AlbumController();
                bool isFav = userController.VerifyFavoriteAlbum(idUser, SongID);
                if (!isFav) { //Add
                    albumController.AddAlbumToFav(idUser, SongID);
                } else { //Remove

                }
            }
            Response.Redirect("Inicio.aspx");
        }

        public void PlayMusic(object sender, ImageClickEventArgs e, string MP3URL, string URLCover, string SongName, string ArtistName) {
            Reproductor.Src = MP3URL;
            miniaturaCover.ImageUrl = URLCover;
            miniNombreCancion.Text = SongName;
            miniNombreArtista.Text = ArtistName;
        }

        public void ViewAlbum(object sender, ImageClickEventArgs e, int AlbumID) {
            Session["albumViewID"] = AlbumID;
            Response.Redirect("Album.aspx");
        }

        protected void ViewArtist(object sender, EventArgs e, int ArtistID) {
            Session["artistViewID"] = ArtistID;
            Response.Redirect("ArtistPage.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e) {
            APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS
            List<Data> data = new List<Data>();
            data = aPIDeezer.GetDataFromSearchDeezer(txbBuscar.Text);
            Session["busqueda"] = data;
            divBuscar.Visible = true;
            Response.Redirect("Inicio.aspx");
        }

    }
}