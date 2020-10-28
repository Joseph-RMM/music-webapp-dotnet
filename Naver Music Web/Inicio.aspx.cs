using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Naver_Music_Web {
    public partial class Inicio : System.Web.UI.Page {
        //Simulacion de datos recuperados de la base de datos
        //TODO: Borrar cuando se implemente la base de datos
        static int VotesDB = 13455;
        static int VotesDB2 = 558;
        protected void Page_Load(object sender, EventArgs e) {
            //Simulacion de consulta a la API y llenado del panel
            panelMusic.Controls.Add(createMusicItem("https://pbs.twimg.com/media/DrEPUf1WsAIxCby.jpg", "POP/STARS", "K/DA", VotesDB, true, 1));
            panelMusic.Controls.Add(createMusicItem("https://cdns-images.dzcdn.net/images/cover/3eddd7a427f3b4debe681e88e0811298/350x350.jpg", "THE BADDEST", "K/DA", VotesDB2, false, 2));
        }

        public Panel createMusicItem(string URLCover, string SongName, string ArtistName, int Votos, bool isFav, int SongID) {

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
            //Buscar los votos de la cancion con el ID
            //TODO: Implementar codigo real y quitar if de simulacion
            if (SongID == 1) { //SELECT Votos FROM VotosCancion WHERE IDCancion = ##
                VotesDB++;
                Votes = VotesDB;
            } else {
                VotesDB2++;
                Votes = VotesDB2;
            }
            btnRate.Text = "♥ " + (Votes);
        }
    }
}