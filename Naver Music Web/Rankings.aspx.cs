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


            RankingController rankingController = new RankingController();
            //Top 10 Tracks

            List<proc_topTenTracks_Result> proc = new List<proc_topTenTracks_Result>();
            proc = rankingController.TopTenTrack();
            for (int i = 0; i < proc.Count; i++) {
                proc_topTenTracks_Result topSong = proc[i];
                int songID = topSong.idTrack;
                Data song = ObtenerCancion(songID);
                int Votos = topSong.total ?? 0;
                if (song.artist != null) {
                    if (i == 0) {//Top One
                        playSong1.ImageUrl = song.album.cover_medium;
                        lblSName1.Text = song.title_short;
                        lblSArtist1.Text = song.artist.name;
                        btnRateSong1.Text = "♥ " + Votos;
                    } else {
                        if (i == 1) {//Top Two
                            playSong2.ImageUrl = song.album.cover_medium;
                            lblSName2.Text = song.title_short;
                            lblSArtist2.Text = song.artist.name;
                            btnRateSong2.Text = "♥ " + Votos;
                        } else {
                            if (i == 2) {//Top Tres xd
                                playSong3.ImageUrl = song.album.cover_medium;
                                lblSName3.Text = song.title_short;
                                lblSArtist3.Text = song.artist.name;
                                btnRateSong3.Text = "♥ " + Votos;
                            }
                        }
                    }
                }
            }

            //Top 10 Albums
            List<proc_topTenAlbum_Result> procAlbum = new List<proc_topTenAlbum_Result>();
            procAlbum = rankingController.TopTenAlbum();
            for (int i = 0; i < procAlbum.Count; i++) {
                proc_topTenAlbum_Result topAlbum = procAlbum[i];
                int AlbumID = topAlbum.idAlbumm;
                int Votos = topAlbum.total ?? 0;
                AlbumModel album = ObtenerAlbum(AlbumID);
                if (album.artist != null) {
                    if(i == 0) {//Top One
                        albumCover1.ImageUrl = album.cover_medium;
                        lblAlbumName1.Text = album.title;
                        lblAlbumArtist1.Text = album.artist.name;
                        btnRateAlbum1.Text = "♥ " + Votos;
                    } else {
                        if (i == 1) {//Numero d o s xd
                            albumCover2.ImageUrl = album.cover_medium;
                            lblAlbumName2.Text = album.title;
                            lblAlbumArtist2.Text = album.artist.name;
                            btnRateAlbum2.Text = "♥ " + Votos;
                        } else {
                            if (i == 2) {//tres
                                albumCover3.ImageUrl = album.cover_medium;
                                lblAlbumName3.Text = album.title;
                                lblAlbumArtist3.Text = album.artist.name;
                                btnRateAlbum3.Text = "♥ " + Votos;
                            }
                        }
                    }
                }


            }

            foreach (proc_topTenAlbum_Result current in procAlbum) {
                Console.WriteLine(current.idAlbumm + " " + current.total + "\n");
            }
        }

        protected Data ObtenerCancion(int ID) {
            APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS
            Data track = new Data();
            track = aPIDeezer.GetTrack(ID);
            return track;
        }

        protected AlbumModel ObtenerAlbum(int ID) {
            APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS
            AlbumModel album = new AlbumModel();
            album = aPIDeezer.GetAlbum(ID);
            return album;
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