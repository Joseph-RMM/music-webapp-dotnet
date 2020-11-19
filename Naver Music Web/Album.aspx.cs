using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Naver_Music_Web {
    public partial class Album : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            gvCanciones.DataSource = test();
            gvCanciones.DataBind();
            gvCanciones.Columns[1].Visible = false;
        }

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
        }

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