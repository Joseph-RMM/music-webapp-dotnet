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
using System.Data;

namespace Naver_Music_Web {
    public partial class Rankings : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["RSelected"] == null) {
                Session["RSelected"] = "General";
            }
            int selection = 0;
            string RankingSeleccionado = (string) Session["RSelected"];
            switch (RankingSeleccionado) {
                case "Diario":
                    btnDiario.CssClass = "btn-selected";
                    selection = 1;
                    break;
                case "Semanal":
                    btnSemanal.CssClass = "btn-selected";
                    selection = 2;
                    break;
                case "Mensual":
                    btnMensual.CssClass = "btn-selected";
                    selection = 3;
                    break;
                case "General":
                    btnGeneral.CssClass = "btn-selected";
                    selection = 4;
                    break;
            }


            RankingController rankingController = new RankingController();
            //Top 10 Tracks
            List<int> IDs = new List<int>();
            List<int> votos = new List<int>();
            switch (selection) {
                case 1: //Diario
                    List<proc_RankingDiarioTracks_Result> proc = new List<proc_RankingDiarioTracks_Result>();
                    proc = rankingController.RankingDiarioTracks();
                    foreach (proc_RankingDiarioTracks_Result track in proc) {
                        IDs.Add(track.idTrack ?? 0);
                        votos.Add(track.total ?? 0);
                    }
                    break;
                case 2: //Semanal
                    List<proc_RankingSemanalTracks_Result> proc2 = new List<proc_RankingSemanalTracks_Result>();
                    proc2 = rankingController.RankingSemanalTracks();
                    foreach (proc_RankingSemanalTracks_Result track in proc2) {
                        IDs.Add(track.idTrack ?? 0);
                        votos.Add(track.total ?? 0);
                    }
                    break;
                case 3: //Mensual
                    List<proc_RankingMensualTracks_Result> proc3 = new List<proc_RankingMensualTracks_Result>();
                    proc3 = rankingController.RankingMensualTracks();
                    foreach (proc_RankingMensualTracks_Result track in proc3) {
                        IDs.Add(track.idTrack ?? 0);
                        votos.Add(track.total ?? 0);
                    }
                    break;
                case 4: //General
                    List<proc_topTenTracks_Result> proc4 = new List<proc_topTenTracks_Result>();
                    proc4 = rankingController.TopTenTrack();
                    foreach (proc_topTenTracks_Result track in proc4) {
                        IDs.Add(track.idTrack);
                        votos.Add(track.total ?? 0);
                    }
                    break;
            }
            //Crear un gridView para las canciones que no son top 3
            DataSet dataSetSongs = new DataSet();
            DataTable canciones = new DataTable("Songs");
            canciones.Columns.Add("id");
            canciones.Columns.Add("preview");
            canciones.Columns.Add("cover");
            canciones.Columns.Add("puesto");
            canciones.Columns.Add("tittle");
            canciones.Columns.Add("artist");
            canciones.Columns.Add("votes");
            for (int i = 0; i < IDs.Count; i++) {
                int songID = IDs[i];
                Data song = ObtenerCancion(songID);
                int Votos = votos[i];
                if (song.artist != null) {
                    if (i == 0) {//Top One
                        playSong1.ImageUrl = song.album.cover_medium;
                        playSong1.Click += delegate (object play, ImageClickEventArgs playArgs) { PlayMusic(play, playArgs, song.preview, song.album.cover_small, song.title_short, song.artist.name); };
                        lblSName1.Text = song.title_short;
                        lblSArtist1.Text = song.artist.name;
                        btnRateSong1.Text = "♥ " + Votos;
                        btnRateSong1.Click += delegate (object bs1, EventArgs es1) { RateClick(bs1, es1, songID, 1); };
                    } else {
                        if (i == 1) {//Top Two
                            playSong2.ImageUrl = song.album.cover_medium;
                            playSong2.Click += delegate (object play, ImageClickEventArgs playArgs) { PlayMusic(play, playArgs, song.preview, song.album.cover_small, song.title_short, song.artist.name); };
                            lblSName2.Text = song.title_short;
                            lblSArtist2.Text = song.artist.name;
                            btnRateSong2.Text = "♥ " + Votos;
                            btnRateSong2.Click += delegate (object bs2, EventArgs es2) { RateClick(bs2, es2, songID, 1); };
                        } else {
                            if (i == 2) {//Top Tres xd
                                playSong3.ImageUrl = song.album.cover_medium;
                                playSong3.Click += delegate (object play, ImageClickEventArgs playArgs) { PlayMusic(play, playArgs, song.preview, song.album.cover_small, song.title_short, song.artist.name); };
                                lblSName3.Text = song.title_short;
                                lblSArtist3.Text = song.artist.name;
                                btnRateSong3.Text = "♥ " + Votos;
                                btnRateSong3.Click += delegate (object bs3, EventArgs es3) { RateClick(bs3, es3, songID, 1); };
                            } else { //El resto
                                //Llenar el gridView
                                if (i < 10) {
                                    int Puesto = i + 1;
                                    canciones.Rows.Add(song.id, song.preview, song.album.cover_small, Puesto, song.title, song.artist.name, "♥ " + Votos);
                                }
                            }
                        }
                    }
                }
            }
            dataSetSongs.Tables.Add(canciones);
            gvCanciones.DataSource = dataSetSongs;
            gvCanciones.DataBind();
            gvCanciones.Columns[0].Visible = false;
            gvCanciones.Columns[1].Visible = false;
            gvCanciones.Columns[2].Visible = false;


            //Top 10 Albums
            List<int> IDsAlbum = new List<int>();
            List<int> votosAlbum = new List<int>();
            switch (selection) {
                case 1: //Diario
                    List<proc_RankingDiarioAlbum_Result> proc = new List<proc_RankingDiarioAlbum_Result>();
                    proc = rankingController.RankingDiarioAlbum();
                    foreach (proc_RankingDiarioAlbum_Result track in proc) {
                        IDsAlbum.Add(track.idAlbumm);
                        votosAlbum.Add(track.total ?? 0);
                    }
                    break;
                case 2: //Semanal
                    List<proc_RankingSemanalAlbum_Result> proc2 = new List<proc_RankingSemanalAlbum_Result>();
                    proc2 = rankingController.RankingSemanalAlbum();
                    foreach (proc_RankingSemanalAlbum_Result track in proc2) {
                        IDsAlbum.Add(track.idAlbumm);
                        votosAlbum.Add(track.total ?? 0);
                    }
                    break;
                case 3: //Mensual
                    List<proc_RankingMensualAlbum_Result> proc3 = new List<proc_RankingMensualAlbum_Result>();
                    proc3 = rankingController.RankingMensualAlbum();
                    foreach (proc_RankingMensualAlbum_Result track in proc3) {
                        IDsAlbum.Add(track.idAlbumm);
                        votosAlbum.Add(track.total ?? 0);
                    }
                    break;
                case 4: //General
                    List<proc_topTenAlbum_Result> proc4 = new List<proc_topTenAlbum_Result>();
                    proc4 = rankingController.TopTenAlbum();
                    foreach (proc_topTenAlbum_Result track in proc4) {
                        IDsAlbum.Add(track.idAlbumm);
                        votosAlbum.Add(track.total ?? 0);
                    }
                    break;
            }
            //Crear un gridView para las canciones que no son top 3
            DataSet dataSetAlbums = new DataSet();
            DataTable albums = new DataTable("Songs");
            albums.Columns.Add("id");
            albums.Columns.Add("puesto");
            albums.Columns.Add("tittle");
            albums.Columns.Add("artist");
            albums.Columns.Add("votes");
            for (int i = 0; i < IDsAlbum.Count; i++) {
                int AlbumID = IDsAlbum[i];
                int Votos = votosAlbum[i];
                AlbumModel album = ObtenerAlbum(AlbumID);
                if (album.artist != null) {
                    if(i == 0) {//Top One
                        albumCoverT1.ImageUrl = album.cover_medium;
                        albumCoverT1.Click += delegate (object obj, ImageClickEventArgs args) { ViewAlbum(obj,args,AlbumID); };
                        lblAlbumName1.Text = album.title;
                        lblAlbumArtist1.Text = album.artist.name;
                        btnRateAlbum1.Text = "♥ " + Votos;
                        btnRateAlbum1.Click += delegate (object ba1, EventArgs ea1) { RateClick(ba1, ea1, AlbumID, 2); };
                    } else {
                        if (i == 1) {//Numero d o s xd
                            albumCoverT2.ImageUrl = album.cover_medium;
                            albumCoverT2.Click += delegate (object obj, ImageClickEventArgs args) { ViewAlbum(obj, args, AlbumID); };
                            lblAlbumName2.Text = album.title;
                            lblAlbumArtist2.Text = album.artist.name;
                            btnRateAlbum2.Text = "♥ " + Votos;
                            btnRateAlbum2.Click += delegate (object ba2, EventArgs ea2) { RateClick(ba2, ea2, AlbumID, 2); };
                        } else {
                            if (i == 2) {//tres
                                albumCoverT3.ImageUrl = album.cover_medium;
                                albumCoverT3.Click += delegate (object obj, ImageClickEventArgs args) { ViewAlbum(obj, args, AlbumID); };
                                lblAlbumName3.Text = album.title;
                                lblAlbumArtist3.Text = album.artist.name;
                                btnRateAlbum3.Text = "♥ " + Votos;
                                btnRateAlbum3.Click += delegate (object ba3, EventArgs ea3) { RateClick(ba3, ea3, AlbumID, 2); };
                            } else { //El resto
                                //Llenar el gridView
                                if (i < 10) {
                                    int Puesto = i + 1;
                                    albums.Rows.Add(album.id, Puesto, album.title, album.artist.name, "♥ " + Votos);
                                }
                            }
                        }
                    }
                }
            }
            dataSetAlbums.Tables.Add(albums);
            gvAlbums.DataSource = dataSetAlbums;
            gvAlbums.DataBind();
            gvAlbums.Columns[0].Visible = false;


            //Top 10 Artists
            List<int> IDsArtista = new List<int>();
            List<int> votosArtista = new List<int>();
            switch (selection) {
                case 1: //Diario
                    List<proc_RankingDiarioArtistas_Result> proc = new List<proc_RankingDiarioArtistas_Result>();
                    proc = rankingController.RankingDiarioArtistas();
                    foreach (proc_RankingDiarioArtistas_Result artist in proc) {
                        IDsArtista.Add(artist.idArtist ?? 0);
                        votosArtista.Add(artist.total ?? 0);
                    }
                    break;
                case 2: //Semanal
                    List<proc_RankingSemanalArtistas_Result> proc2 = new List<proc_RankingSemanalArtistas_Result>();
                    proc2 = rankingController.RankingSemanalArtistas();
                    foreach (proc_RankingSemanalArtistas_Result artist in proc2) {
                        IDsArtista.Add(artist.idArtist ?? 0);
                        votosArtista.Add(artist.total ?? 0);
                    }
                    break;
                case 3: //Mensual
                    List<proc_RankingMensualArtistas_Result> proc3 = new List<proc_RankingMensualArtistas_Result>();
                    proc3 = rankingController.RankingMensualArtistas();
                    foreach (proc_RankingMensualArtistas_Result artist in proc3) {
                        IDsArtista.Add(artist.idArtist ?? 0);
                        votosArtista.Add(artist.total ?? 0);
                    }
                    break;
                case 4: //General
                    List<proc_topTenArtists_Result> proc4 = new List<proc_topTenArtists_Result>();
                    proc4 = rankingController.TopTenArtists();
                    foreach (proc_topTenArtists_Result artist in proc4) {
                        IDsArtista.Add(artist.idArtist);
                        votosArtista.Add(artist.total ?? 0);
                    }
                    break;
            }
            //Crear un gridView para las canciones que no son top 3
            DataSet dataSetArtistas = new DataSet();
            DataTable artistTable = new DataTable("Songs");
            artistTable.Columns.Add("id");
            artistTable.Columns.Add("puesto");
            artistTable.Columns.Add("artist");
            artistTable.Columns.Add("votes");
            for (int i = 0; i < IDsArtista.Count; i++) {
                int ArtistID = IDsArtista[i];
                int Votes = votosArtista[i];
                Artist artist = ObtenerArtista(ArtistID);
                if(artist.picture_medium != "" && artist.picture_medium!= "") {
                    if(i == 0) {
                        artistFoto1.ImageUrl = artist.picture_medium;
                        artistFoto1.Click += delegate (object obj, ImageClickEventArgs args) { ViewArtist(obj, args, ArtistID); };
                        lblArtistName1.Text = artist.name;
                        btnRateArtist1.Text = "♥ " + Votes;
                        btnRateArtist1.Click += delegate (object btn, EventArgs eventArgs) { RateClick(btn, eventArgs, ArtistID, 3); };
                    } else {
                        if (i == 1) {
                            artistFoto2.ImageUrl = artist.picture_medium;
                            artistFoto2.Click += delegate (object obj, ImageClickEventArgs args) { ViewArtist(obj, args, ArtistID); };
                            lblArtistName2.Text = artist.name;
                            btnRateArtist2.Text = "♥ " + Votes;
                            btnRateArtist2.Click += delegate (object btn, EventArgs eventArgs) { RateClick(btn, eventArgs, ArtistID, 3); };
                        } else {
                            if (i == 2) {
                                artistFoto3.ImageUrl = artist.picture_medium;
                                artistFoto3.Click += delegate (object obj, ImageClickEventArgs args) { ViewArtist(obj, args, ArtistID); };
                                lblArtistName3.Text = artist.name;
                                btnRateArtist3.Text = "♥ " + Votes;
                                btnRateArtist3.Click += delegate (object btn, EventArgs eventArgs) { RateClick(btn, eventArgs, ArtistID, 3); };
                            } else { //El resto
                                //Llenar el gridView
                                if (i < 10) {
                                    int Puesto = i + 1;
                                    artistTable.Rows.Add(artist.id, Puesto,artist.name, "♥ " + Votes);
                                }
                            }
                        }
                    }
                }
            }
            dataSetArtistas.Tables.Add(artistTable);
            gvArtistas.DataSource = dataSetArtistas;
            gvArtistas.DataBind();
            gvArtistas.Columns[0].Visible = false;
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

        protected Artist ObtenerArtista(int ID) {
            APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS
            Artist artist = new Artist();
            artist = aPIDeezer.GetArtist(ID);
            return artist;
        }

        protected void btnDiario_Click(object sender, EventArgs e) {
            Session["RSelected"] = "Diario";
            btnDiario.CssClass = "btn-selected";
            btnSemanal.CssClass = "btn-menu";
            btnMensual.CssClass = "btn-menu";
            btnGeneral.CssClass = "btn-menu";
            Response.Redirect("Rankings.aspx");
        }

        protected void btnSemanal_Click(object sender, EventArgs e) {
            Session["RSelected"] = "Semanal";
            btnDiario.CssClass = "btn-menu";
            btnSemanal.CssClass = "btn-selected";
            btnMensual.CssClass = "btn-menu";
            btnGeneral.CssClass = "btn-menu";
            Response.Redirect("Rankings.aspx");
        }

        protected void btnMensual_Click(object sender, EventArgs e) {
            Session["RSelected"] = "Mensual";
            btnDiario.CssClass = "btn-menu";
            btnSemanal.CssClass = "btn-menu";
            btnMensual.CssClass = "btn-selected";
            btnGeneral.CssClass = "btn-menu";
            Response.Redirect("Rankings.aspx");
        }

        protected void btnGeneral_Click(object sender, EventArgs e) {
            Session["RSelected"] = "General";
            btnDiario.CssClass = "btn-menu";
            btnSemanal.CssClass = "btn-menu";
            btnMensual.CssClass = "btn-menu";
            btnGeneral.CssClass = "btn-selected";
            Response.Redirect("Rankings.aspx");
        }


        protected void RateClick(object sender, EventArgs e, int SongID, int type) {
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
            Response.Redirect("Rankings.aspx");
        }

        protected void ViewAlbum(object sender, ImageClickEventArgs e, int AlbumID) {
            Session["albumViewID"] = AlbumID;
            Response.Redirect("Album.aspx");
        }

        protected void ViewArtist(object sender, EventArgs e, int ArtistID) {
            Session["artistViewID"] = ArtistID;
            Response.Redirect("ArtistPage.aspx");
        }

        protected void PlayMusic(object sender, ImageClickEventArgs e, string MP3URL, string URLCover, string SongName, string ArtistName) {
            Reproductor.Src = MP3URL;
            miniaturaCover.ImageUrl = URLCover;
            miniNombreCancion.Text = SongName;
            miniNombreArtista.Text = ArtistName;
        }


        protected void gvCanciones_RowCommand(object sender, GridViewCommandEventArgs e) {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Play") {
                gvCanciones.Columns[1].Visible = true;
                gvCanciones.Columns[2].Visible = true;
                gvCanciones.DataBind();

                //Reference the GridView Row.
                GridViewRow row = gvCanciones.Rows[rowIndex];
                miniaturaCover.ImageUrl = row.Cells[2].Text;
                miniNombreCancion.Text = row.Cells[4].Text;
                miniNombreArtista.Text = row.Cells[5].Text;
                Reproductor.Src = row.Cells[1].Text;
                gvCanciones.Columns[1].Visible = false;
                gvCanciones.Columns[2].Visible = false;
            } else {
                if (e.CommandName == "Vote") {
                    gvCanciones.Columns[0].Visible = true;
                    gvCanciones.DataBind();
                    UsuariosModels currentUser = (UsuariosModels)Session["userData"];
                    int iduser = currentUser.idUsuario;
                    VotoController votoController = new VotoController();
                    DateTime fecha = DateTime.Now;
                    GridViewRow row = gvCanciones.Rows[rowIndex];
                    int SongID = int.Parse(row.Cells[0].Text);
                    bool voto = votoController.proc_VotarCancion(SongID, iduser, fecha);
                    gvCanciones.Columns[0].Visible = false;
                    Response.Redirect("Rankings.aspx");
                }
            }
        }

        protected void gvAlbums_RowCommand(object sender, GridViewCommandEventArgs e) {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "View") {
                gvAlbums.Columns[0].Visible = true;
                gvAlbums.DataBind();

                //Reference the GridView Row.
                GridViewRow row = gvAlbums.Rows[rowIndex];
                int AlbumID = int.Parse(row.Cells[0].Text);
                Session["albumViewID"] = AlbumID;
                gvAlbums.Columns[0].Visible = false;
                Response.Redirect("Album.aspx");
            } else {
                if (e.CommandName == "Vote") {
                    gvAlbums.Columns[0].Visible = true;
                    gvAlbums.DataBind();
                    UsuariosModels currentUser = (UsuariosModels)Session["userData"];
                    int iduser = currentUser.idUsuario;
                    VotoController votoController = new VotoController();
                    DateTime fecha = DateTime.Now;
                    GridViewRow row = gvAlbums.Rows[rowIndex];
                    int AlbumID = int.Parse(row.Cells[0].Text);
                    bool voto = votoController.proc_VotarAlbum(AlbumID, iduser, fecha);
                    gvAlbums.Columns[0].Visible = false;
                    Response.Redirect("Rankings.aspx");
                }
            }
        }

        protected void gvArtistas_RowCommand(object sender, GridViewCommandEventArgs e) {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "View") {
                gvArtistas.Columns[0].Visible = true;
                gvArtistas.DataBind();

                //Reference the GridView Row.
                GridViewRow row = gvArtistas.Rows[rowIndex];
                int ArtistID = int.Parse(row.Cells[0].Text);
                Session["artistViewID"] = ArtistID;
                gvArtistas.Columns[0].Visible = false;
                Response.Redirect("ArtistPage.aspx");
            } else {
                if (e.CommandName == "Vote") {
                    gvArtistas.Columns[0].Visible = true;
                    gvArtistas.DataBind();
                    UsuariosModels currentUser = (UsuariosModels)Session["userData"];
                    int iduser = currentUser.idUsuario;
                    VotoController votoController = new VotoController();
                    DateTime fecha = DateTime.Now;
                    GridViewRow row = gvArtistas.Rows[rowIndex];
                    int ArtistID = int.Parse(row.Cells[0].Text);
                    bool voto = votoController.proc_VotarArtista(ArtistID, iduser, fecha);
                    gvArtistas.Columns[0].Visible = false;
                    Response.Redirect("Rankings.aspx");
                }
            }
        }
    }
}