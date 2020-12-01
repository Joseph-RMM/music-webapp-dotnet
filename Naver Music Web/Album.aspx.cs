using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LogicaNaverMusic;
using LogicaNaverMusic.Controllers; //CONTROLADORES DE LOGICA NEGOCIOS
using LogicaNaverMusic.Models;      //MODELOS DE LOGICA NEGOCIOS     
using LogicaNaverMusic.BaseDatos;   //MODELOS DE BASE DE DATOS  

namespace Naver_Music_Web {
    public partial class Album : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["albumViewID"] == null) {
                Response.Redirect("Inicio.aspx");
            } else {
                int albumID = (int) Session["albumViewID"];

                //Consultar a la lógica la información
                APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS

                AlbumModel album = new AlbumModel();
                album = aPIDeezer.GetAlbum(albumID);

                AlbumController albumController = new AlbumController();
                UserController userController = new UserController();
                UsuariosModels currentUser = (UsuariosModels)Session["userData"];
                int idUser = currentUser.idUsuario;

                //Lenar la información
                lblTitulo.Text = album.title;
                btnArtistas.Text = album.artist.name;
                albumCover.ImageUrl = album.cover_big;
                btnVote.Text = "♥ "+albumController.GetVotesOfAlbum(albumID);
                btnFav.Text = (userController.VerifyFavoriteAlbum(idUser, albumID)) ? "★" : "✩";

                //Crear un gridView para las canciones
                DataSet dataSet = new DataSet();
                DataTable canciones = new DataTable("Songs");
                canciones.Columns.Add("id");
                canciones.Columns.Add("preview");
                canciones.Columns.Add("tittle");
                canciones.Columns.Add("artist");
                canciones.Columns.Add("votes");
                canciones.Columns.Add("favs");

                //Llenar el gridView
                foreach (Data current in album.tracks.data) {
                    //Obtener votos
                    CancionController cancionController = new CancionController();
                    int Votos = cancionController.GetVotesOfTrack(int.Parse(current.id));
                    string Fav = userController.VerifyFavoriteTrack(idUser, int.Parse(current.id)) ? "★" : "✩";
                    canciones.Rows.Add(current.id,current.preview,current.title,current.artist.name, "♥ "+Votos, Fav);
                }

                dataSet.Tables.Add(canciones);
                gvCanciones.DataSource = dataSet;
                gvCanciones.DataBind();
                gvCanciones.Columns[0].Visible = false;
                gvCanciones.Columns[1].Visible = false;
            }
        }
        /*
        public DataSet test () {
            DataSet respuesta = new DataSet();
            DataTable canciones = new DataTable("Songs");
            canciones.Columns.Add("id");
            canciones.Columns.Add("preview");
            canciones.Columns.Add("tittle");
            canciones.Columns.Add("artist");
            canciones.Columns.Add("votes");
            canciones.Columns.Add("favs");

            canciones.Rows.Add(123, "https://cdns-preview-8.dzcdn.net/stream/c-8a60e99f17e12d336bf7ce74fe78dfd8-6.mp3", "MORE", "K/DA", "♥ 34,304", "☆");
            canciones.Rows.Add(123, "https://cdns-preview-8.dzcdn.net/stream/c-8a60e99f17e12d336bf7ce74fe78dfd8-6.mp3", "TestSong", "Test Artist", "♥ 123", "☆");

            respuesta.Tables.Add(canciones);
            return respuesta;
        }*/

        protected void gvCanciones_RowCommand(object sender, GridViewCommandEventArgs e) {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Play") {
                gvCanciones.Columns[1].Visible = true;
                gvCanciones.DataBind();
                miniaturaCover.ImageUrl = albumCover.ImageUrl;

                //Reference the GridView Row.
                GridViewRow row = gvCanciones.Rows[rowIndex];
                miniNombreCancion.Text = row.Cells[2].Text;
                miniNombreArtista.Text = row.Cells[3].Text;
                Reproductor.Src = row.Cells[1].Text;
                gvCanciones.Columns[1].Visible = false;
            } else {
                if (e.CommandName == "Vote") {
                    UsuariosModels currentUser = (UsuariosModels)Session["userData"];
                    int iduser = currentUser.idUsuario;
                    VotoController votoController = new VotoController();
                    gvCanciones.Columns[0].Visible = true;
                    gvCanciones.DataBind();
                    DateTime fecha = DateTime.Now;
                    GridViewRow row = gvCanciones.Rows[rowIndex];
                    int SongID = int.Parse(row.Cells[0].Text);
                    bool voto = votoController.proc_VotarCancion(SongID, iduser, fecha);
                    gvCanciones.Columns[0].Visible = false;
                    Response.Redirect("Album.aspx");
                } else {
                    if (e.CommandName == "Fav") {
                        gvCanciones.Columns[0].Visible = true;
                        gvCanciones.DataBind();
                        UsuariosModels currentUser = (UsuariosModels)Session["userData"];
                        int iduser = currentUser.idUsuario;
                        GridViewRow row = gvCanciones.Rows[rowIndex];
                        int SongID = int.Parse(row.Cells[0].Text);
                        UserController userController = new UserController();
                        CancionController cancionController = new CancionController();
                        bool isFav = userController.VerifyFavoriteTrack(iduser, SongID);
                        if (!isFav) { //Add
                            cancionController.AddTrackToFav(SongID, iduser);
                        } else { //Remove

                        }
                        gvCanciones.Columns[0].Visible = false;
                        Response.Redirect("Album.aspx");
                    }
                }
            }
        }

        protected void btnVote_Click(object sender, EventArgs e) {
            UsuariosModels currentUser = (UsuariosModels)Session["userData"];
            int iduser = currentUser.idUsuario;
            VotoController votoController = new VotoController();
            DateTime fecha = DateTime.Now;
            int albumID = (int)Session["albumViewID"];
            bool voto = votoController.proc_VotarAlbum(albumID, iduser, fecha);
            Response.Redirect("Album.aspx");
        }

        protected void btnFav_Click(object sender, EventArgs e) {
            UserController userController = new UserController();
            UsuariosModels currentUser = (UsuariosModels)Session["userData"];
            int iduser = currentUser.idUsuario;
            int albumID = (int)Session["albumViewID"];
            bool isFav = userController.VerifyFavoriteAlbum(iduser, albumID);
            AlbumController albumController = new AlbumController();
            if (!isFav) { //Add
                albumController.AddAlbumToFav(iduser, albumID);
            } else { //Remove
                albumController.DeleteAlbumToFavorites(iduser, albumID);
            }
            Response.Redirect("Album.aspx");
        }

        protected void btnArtistas_Click(object sender, EventArgs e) {
            int albumID = (int)Session["albumViewID"];
            //Consultar a la lógica la información
            APIDeezerController aPIDeezer = new APIDeezerController();  
            AlbumModel album = new AlbumModel();
            album = aPIDeezer.GetAlbum(albumID);
            Session["artistViewID"] = int.Parse(album.artist.id);
            Response.Redirect("ArtistPage.aspx");
        }
    }
}