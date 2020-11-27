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


            if (isCorrect) {
                UserController userController = new UserController();
                UsuariosModels currentUser = userController.LoginUser(txbEmail.Text, txbContrasena.Text);
                if (currentUser.idUsuario != 0) {
                    Session["userData"] = currentUser;
                    if (chbAuto.Checked) {
                        Session.Timeout = 525600;
                    } else {
                        //Las variables de sessión tienen un timeout de 20 minutos por default, por lo que no se recordará al usuario
                    }
                    Response.Redirect("Inicio.aspx");
                } else {
                    lblInfo.Text = "Usuario no registrado";
                }
            }
        }
    }
}