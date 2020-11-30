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
    public partial class ArtistPage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["artistViewID"] == null) {
                Response.Redirect("Inicio.aspx");
            } else {
                //Controladores
                int artistID = (int)Session["artistViewID"];
                APIDeezerController aPIDeezer = new APIDeezerController();
                ArtistaController artistaController = new ArtistaController();
                UserController userController = new UserController();
                Artist artist = aPIDeezer.GetArtist(artistID);
                UsuariosModels currentUser = (UsuariosModels)Session["userData"];
                int idUser = currentUser.idUsuario;

                //Mostrar datos
                artistImg.ImageUrl = artist.picture_big;
                lblNombre.Text = artist.name;
                btnVote.Text = "♥ " + artistaController.GetVotesOfArtist(artistID);
                btnFav.Text = (userController.VerifyFavoriteArtist(idUser, artistID)) ? "★" : "✩";

                //Buscar y mostrar álbumes
                List<Data> data = aPIDeezer.GetDataFromSearchDeezer(artist.name);
                List<AlbumModel> albums = new List<AlbumModel>();
                foreach (Data song in data) {
                    if (song.artist.id == artist.id) { //El album es del artista
                        bool add = true;
                        foreach (AlbumModel album in albums) {
                            if (song.album.id == album.id) {
                                add = false;
                            }
                        }
                        if (add) albums.Add(song.album);
                    }
                }
                foreach (AlbumModel album in albums) {
                    panelAlbumes.Controls.Add(createAlbumItem(album));
                }


            }
        }

        public Panel createAlbumItem(AlbumModel album) {
            return createAlbumItem(album.cover_medium, album.title, int.Parse(album.id));
        }

        public Panel createAlbumItem(string URLCover, string Title, int AlbumID) {
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
            wrapper.Controls.Add(ratefav);
            return wrapper;
        }



        public void RateClick(object sender, EventArgs e, int SongID, int type) {
            Button btnRate = (Button)sender;

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

                Response.Redirect("ArtistPage.aspx");
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
            Response.Redirect("ArtistPage.aspx");
        }

        public void ViewAlbum(object sender, ImageClickEventArgs e, int AlbumID) {
            Session["albumViewID"] = AlbumID;
            Response.Redirect("Album.aspx");
        }

        protected void btnFav_Click(object sender, EventArgs e) {
            UserController userController = new UserController();
            ArtistaController artistaController = new ArtistaController();
            UsuariosModels currentUser = (UsuariosModels)Session["userData"];
            int idUser = currentUser.idUsuario;
            int artistID = (int)Session["artistViewID"];
            bool isFav = userController.VerifyFavoriteArtist(idUser, artistID);
            if (isFav) {
                artistaController.AddArtistToFav(idUser, artistID);
            } else {
                artistaController.DeleteArtistToFavorites(idUser, artistID);
            }
            Response.Redirect("ArtistPage.aspx");
        }

        protected void btnVote_Click(object sender, EventArgs e) {
            VotoController votoController = new VotoController();
            UsuariosModels currentUser = (UsuariosModels)Session["userData"];
            int idUser = currentUser.idUsuario;
            proc_GetVotesByUser_Result proc = new proc_GetVotesByUser_Result();
            proc = votoController.GetVotesByUser(currentUser.idUsuario);
            int votosUsados = proc.total ?? 0;
            int votosRestantes = 100 - votosUsados;
            if (votosRestantes > 0) {
                int artistID = (int)Session["artistViewID"];
                DateTime fecha = DateTime.Now;
                bool voto = votoController.proc_VotarArtista(artistID, idUser, fecha);
                Response.Redirect("ArtistPage.aspx");
            } else {
                ClientScript.RegisterStartupScript(GetType(), "NoMoreVotes" + e.GetHashCode(), "alert('Has alcanzado tu límite de votos por  hoy\n¡Sigue votando mañana!');", true);
            }
        }
    }
}