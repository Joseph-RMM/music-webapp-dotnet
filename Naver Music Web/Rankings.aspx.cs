using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Naver_Music_Web {
    public partial class Rankings : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["RSelected"] == null) {
                Session["RSelected"] = "Diario";
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