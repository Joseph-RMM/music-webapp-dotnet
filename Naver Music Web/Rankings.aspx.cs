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
    public partial class Rankings : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["RSelected"] == null) {
                Session["RSelected"] = "General";
            }
            string RankingSeleccionado = (string) Session["RSelected"];
            switch (RankingSeleccionado) {
                case "Diario":
                    btnDiario.CssClass = "btn-selected";
                    break;
                case "Semanal":
                    btnSemanal.CssClass = "btn-selected";
                    break;
                case "Mensual":
                    btnMensual.CssClass = "btn-selected";
                    break;
                case "General":
                    btnGeneral.CssClass = "btn-selected";
                    break;
            }


            //Top 10 Tracks
            RankingController rankingController = new RankingController();

            List<proc_topTenTracks_Result> proc = new List<proc_topTenTracks_Result>();
            proc = rankingController.TopTenTrack();
            for (int i = 0; i < proc.Count; i++) {
                proc_topTenTracks_Result topOne = proc[i];
                int songID = topOne.idTrack;
                Data song = ObtenerCancion(songID);
                if (song.artist != null) {
                    CancionController cancionController = new CancionController();
                    int Votos = cancionController.GetVotesOfTrack(int.Parse(song.id));
                    if (i == 0) {//Top One
                        playSong1.ImageUrl = song.album.cover_medium;
                        lblSName1.Text = song.title_short;
                        lblSArtist1.Text = song.artist.name;
                        btnRateSong1.Text = "♥ " + Votos;
                    }
                    if (i == 1) {//Top Two
                        playSong2.ImageUrl = song.album.cover_medium;
                        lblSName2.Text = song.title_short;
                        lblSArtist2.Text = song.artist.name;
                        btnRateSong2.Text = "♥ " + Votos;
                    }
                    if (i == 2) {//Top Tres xd
                        playSong3.ImageUrl = song.album.cover_medium;
                        lblSName3.Text = song.title_short;
                        lblSArtist3.Text = song.artist.name;
                        btnRateSong3.Text = "♥ " + Votos;
                    }
                }
            }
        }

        protected Data ObtenerCancion(int ID) {
            APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS
            Data track = new Data();
            track = aPIDeezer.GetTrack(ID);
            return track;
        }

        protected void btnDiario_Click(object sender, EventArgs e) {
            Session["RSelected"] = "Diario";
            btnDiario.CssClass = "btn-selected";
            btnSemanal.CssClass = "btn-menu";
            btnMensual.CssClass = "btn-menu";
            btnGeneral.CssClass = "btn-menu";
        }

        protected void btnSemanal_Click(object sender, EventArgs e) {
            Session["RSelected"] = "Semanal";
            btnDiario.CssClass = "btn-menu";
            btnSemanal.CssClass = "btn-selected";
            btnMensual.CssClass = "btn-menu";
            btnGeneral.CssClass = "btn-menu";
        }

        protected void btnMensual_Click(object sender, EventArgs e) {
            Session["RSelected"] = "Mensual";
            btnDiario.CssClass = "btn-menu";
            btnSemanal.CssClass = "btn-menu";
            btnMensual.CssClass = "btn-selected";
            btnGeneral.CssClass = "btn-menu";
        }

        protected void btnGeneral_Click(object sender, EventArgs e) {
            Session["RSelected"] = "General";
            btnDiario.CssClass = "btn-menu";
            btnSemanal.CssClass = "btn-menu";
            btnMensual.CssClass = "btn-menu";
            btnGeneral.CssClass = "btn-selected";
        }
    }
}