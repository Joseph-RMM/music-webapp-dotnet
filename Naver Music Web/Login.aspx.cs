using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Naver_Music_Web {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnLogin_Click(object sender, EventArgs e) {
            txbEmail.CssClass = txbContrasena.CssClass = "txb";
            bool isCorrect = true;
            if(txbEmail.Text == "") {
                lblInfo.Text = "Escriba su e-mail";
                txbEmail.CssClass = "txb error";
                isCorrect = false;
            }
            if (txbContrasena.Text == "") {
                lblInfo.Text = "Escriba su contraseña";
                txbContrasena.CssClass = "txb error";
                isCorrect = false;
            }
            if (isCorrect) Response.Redirect("Inicio.aspx");
        }
    }
}