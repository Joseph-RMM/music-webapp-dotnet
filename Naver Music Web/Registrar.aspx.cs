using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Naver_Music_Web {
    public partial class Registrar : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e) {
            bool isCorrect = true;
            txbUsuario.CssClass = txbEmail.CssClass = txbContrasena.CssClass = txbRepetir.CssClass = "txb";
            if (txbContrasena.Text != txbRepetir.Text) {
                txbContrasena.CssClass = txbRepetir.CssClass = "txb error";
                lblInfo.Text = "Las contraseñas no coinciden";
                isCorrect = false;
            }
            if (txbRepetir.Text == "") {
                txbContrasena.CssClass = "txb error";
                lblInfo.Text = "Repita su contraseña";
                isCorrect = false;
            }
            if (txbContrasena.Text == "") {
                txbContrasena.CssClass = "txb error";
                lblInfo.Text = "Escriba una contraseña";
                isCorrect = false;
            }
            if(txbEmail.Text == "") {
                txbEmail.CssClass = "txb error";
                lblInfo.Text = "Escriba su e-mail";
                isCorrect = false;
            }
            if (txbUsuario.Text == "") {
                txbUsuario.CssClass = "txb error";
                lblInfo.Text = "Escriba un nombre de usuario";
                isCorrect = false;
            }
            if (isCorrect) {
                Session["user"] = txbUsuario.Text;
                Session["email"] = txbEmail.Text;
                Session["pass"] = txbContrasena.Text;
                Response.Redirect("Seleccion.aspx");
            }
        }
    }
}