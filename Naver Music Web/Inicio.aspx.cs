using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using LogicaNaverMusic;
using LogicaNaverMusic.Controllers; //CONTROLADORES DE LOGICA NEGOCIOS
using LogicaNaverMusic.Models;      //MODELOS DE LOGICA NEGOCIOS     


namespace Naver_Music_Web {
    public partial class Inicio : System.Web.UI.Page {
        //Simulacion de datos recuperados de la base de datos
        //TODO: Borrar cuando se implemente la base de datos
        static int VotesDB = 13455;
        static int VotesDB2 = 558;
        static int VotesDB3 = 210;
        
        protected void Page_Load(object sender, EventArgs e) {
            List<Data> data = (List <Data>) Session["busqueda"];
            panelResultados.Controls.Clear();
            if (data != null) {
                foreach (Data song in data) {
                    panelResultados.Controls.Add(createMusicItem(song));
                }
                divBuscar.Visible = true;
            }
            //Simulacion de consulta a la API y llenado del panel
            APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS

            AlbumModel album = new AlbumModel();
            album = aPIDeezer.GetAlbum(178519722);
            panelMusic.Controls.Add(createAlbumItem(album));
            panelMusic.Controls.Add(createMusicItem("https://cdns-images.dzcdn.net/images/cover/0019510a69161d7af10e25493dc6d544/250x250-000000-80-0-0.jpg", "POP/STARS", "K/DA", VotesDB, true, 1, "https://cdns-preview-d.dzcdn.net/stream/c-d7aac13016a945052b62f48d33edfc55-5.mp3"));
            panelMusic.Controls.Add(createMusicItem("https://cdns-images.dzcdn.net/images/cover/3eddd7a427f3b4debe681e88e0811298/250x250-000000-80-0-0.jpg", "THE BADDEST", "K/DA", VotesDB2, false, 2, "https://cdns-preview-7.dzcdn.net/stream/c-7e6dd799aaedf824a6594afb7d6d0b51-3.mp3"));
            panelMusic.Controls.Add(createMusicItem("https://cdns-images.dzcdn.net/images/cover/a06a47a2b7c23bdba9099053302cb35c/250x250-000000-80-0-0.jpg", "MORE", "K/DA", VotesDB3, false, 3, "https://cdns-preview-4.dzcdn.net/stream/c-4c33ef6d1f98034b98cc9a5688d29bd0-2.mp3"));
        }


        public Panel createMusicItem(Data song) {
            return createMusicItem(song.album.cover_medium, song.title_short, song.artist.name, int.Parse(song.rank), false, int.Parse(song.id), song.preview);
        }

        public Panel createMusicItem(string URLCover, string SongName, string ArtistName, int Votos, bool isFav, int SongID, string MP3) {

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
            Label artist = new Label {
                Text = ArtistName,
                CssClass = "artistname"
            };
            //Crear el wrapper-ratefav
            Panel ratefav = new Panel { CssClass = "wrapper-ratefav" };
            Button btnRate = new Button {
                CssClass = "btn rate",
                Text = "♥ " + Votos
            };
            btnRate.Click += delegate (object sender, EventArgs e) { RateClick(sender, e, SongID,1); };
            Button btnFav = new Button {
                CssClass = "btn fav",
                Text = isFav ? "★" : "✩"
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
            return createAlbumItem(album.cover_medium, album.title, album.artist.name, 123, false, int.Parse(album.id));
        }

        public Panel createAlbumItem(string URLCover, string Title, string ArtistName, int Votes, bool isFav, int AlbumID) {
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
            Label artist = new Label {
                Text = ArtistName,
                CssClass = "artistname"
            };
            //Crear el wrapper-ratefav
            Panel ratefav = new Panel { CssClass = "wrapper-ratefav" };
            Button btnRate = new Button {
                CssClass = "btn rate",
                Text = "♥ " + Votes
            };
            btnRate.Click += delegate (object sender, EventArgs e) { RateClick(sender, e, AlbumID, 2); };
            Button btnFav = new Button {
                CssClass = "btn fav",
                Text = isFav ? "★" : "✩"
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
            int Votes = 0;
            //Buscar los votos de la cancion con el ID
            //TODO: Implementar codigo real y quitar if de simulacion
            if (SongID == 1) { //SELECT Votos FROM VotosCancion WHERE IDCancion = ##
                VotesDB++;
                Votes = VotesDB;
            } else { 
                if(SongID == 2) {
                    VotesDB2++;
                    Votes = VotesDB2;
                } else {
                    VotesDB3++;
                    Votes = VotesDB3;
                }
                
            }
            btnRate.Text = "♥ " + (Votes);
            Response.Redirect("Inicio.aspx");
        }

        public void FavClick(object sender, EventArgs e, int SongID, int type) {
            Button btnFav = (Button)sender;
            btnFav.Text = (btnFav.Text == "✩") ? "★" : "✩";
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