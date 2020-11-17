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
    public partial class Favoritos : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //Checar si el usuario tiene canciones favoritas
            List<Data> favCanciones = checkforInfo("Canciones");
            if (favCanciones != null) {
                //Añadir items 
                foreach (Data song in favCanciones) {
                    panelCanciones.Controls.Add(createMusicItem(song.album.cover_medium, song.title_short, song.artist.name, int.Parse(song.rank), false, int.Parse(song.id), song.preview));
                }
            } else {
                Label info = new Label {
                    Text = "Añade tus canciones favoritas dando clic en ✩ para encontrarlas aquí",
                    CssClass = "lblPanelInfo"
                };
                panelCanciones.Controls.Add(info);
            }
            if (checkforInfo("Albumes") != null) {
                //Añadir items 

            } else {
                Label info = new Label {
                    Text = "Añade tus álbumes favoritos dando clic en ✩ para encontrarlos aquí",
                    CssClass = "lblPanelInfo"
                };
                panelAlbumes.Controls.Add(info);
            }
            if (checkforInfo("Artistas") != null) {
                //Añadir items 

            } else {
                Label info = new Label {
                    Text = "Añade tus artistas favoritos dando clic en ✩ para encontrarlos aquí",
                    CssClass = "lblPanelInfo"
                };
                panelArtistas.Controls.Add(info);
            }
        }

        //Placeholder para el método real de la LN
        public List<Data> checkforInfo(string type) => null;



        //Metodos para canciones
        public Panel createMusicItem(string URLCover, string SongName, string ArtistName, int Votos, bool isFav, int SongID, string MP3) {

            Panel wrapper = new Panel {
                CssClass = "wrappermusicitem"
            };
            //Div para los elementos del cover music
            Panel playMusic = new Panel { CssClass = "wrapper-playmusic" };
            Image cover = new Image {
                ImageUrl = URLCover,
                CssClass = "imgcovermusic"
            };
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
            btnRate.Click += delegate (object sender, EventArgs e) { RateClick(sender, e, SongID); };
            Button btnFav = new Button {
                CssClass = "btn fav",
                Text = isFav ? "★" : "✩"
            };
            btnFav.Click += delegate (object sender, EventArgs e) { FavClick(sender, e, SongID); };
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


        public void RateClick(object sender, EventArgs e, int SongID) {
            Button btnRate = (Button)sender;
            int Votes = 0;
            btnRate.Text = "♥ " + (Votes);
            Response.Redirect("Favoritos.aspx");
        }

        public void FavClick(object sender, EventArgs e, int SongID) {
            Button btnFav = (Button)sender;
            btnFav.Text = (btnFav.Text == "✩") ? "★" : "✩";
            Response.Redirect("Favoritos.aspx");
        }
        
        public void PlayMusic(object sender, ImageClickEventArgs e, string MP3URL, string URLCover, string SongName, string ArtistName) {
            Reproductor.Src = MP3URL;
            miniaturaCover.ImageUrl = URLCover;
            miniNombreCancion.Text = SongName;
            miniNombreArtista.Text = ArtistName;
        }
    }
}