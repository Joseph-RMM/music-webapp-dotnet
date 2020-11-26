﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LogicaNaverMusic;
using LogicaNaverMusic.Controllers; //CONTROLADORES DE LOGICA NEGOCIOS
using LogicaNaverMusic.Models;      //MODELOS DE LOGICA NEGOCIOS     

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


                //Lenar la información
                lblTitulo.Text = album.title;
                lblArtistas.Text = album.artist.name;
                albumCover.ImageUrl = album.cover_big;

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
                    canciones.Rows.Add(current.id,current.preview,current.title,current.artist.name, "♥ 121", "☆");
                }

                dataSet.Tables.Add(canciones);
                gvCanciones.DataSource = dataSet;
                gvCanciones.DataBind();
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
            if (e.CommandName == "Play") {
                gvCanciones.Columns[1].Visible = true;
                gvCanciones.DataBind();
                miniaturaCover.ImageUrl = albumCover.ImageUrl;

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                
                //Reference the GridView Row.
                GridViewRow row = gvCanciones.Rows[rowIndex];
                miniNombreCancion.Text = row.Cells[2].Text;
                miniNombreArtista.Text = row.Cells[3].Text;
                Reproductor.Src = row.Cells[1].Text;
                gvCanciones.Columns[1].Visible = false;
            }
        }
    }
}