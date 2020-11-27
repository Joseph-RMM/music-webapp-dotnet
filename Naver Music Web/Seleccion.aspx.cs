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
    public partial class Seleccion : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["user"] == null || Session["email"] == null || Session["pass"] == null) {
                Response.Redirect("Registrar.aspx");
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e) {
            //Recuperar info
            string userName = (string)Session["user"];
            string email = (string)Session["email"];
            string pass = (string)Session["pass"];

            int Size = FileUpload1.PostedFile.ContentLength;
            byte[] profileImage = new byte[Size];
            FileUpload1.PostedFile.InputStream.Read(profileImage, 0, Size);
            string Data64 = "data:" + FileUpload1.PostedFile.ContentType + ";base64," + Convert.ToBase64String(profileImage);

            string telefono = txbTelefono.Text;

            //Enviar a la bd

            UserController userController = new UserController();
            bool userCreated;
            userCreated = userController.CreateUser(userName, pass, " ", " ", "M", "img simulation", "No Premium", email, telefono);

            if (userCreated) {
                Response.Redirect("Inicio.aspx");
            } else {
                lblInfo.Text = "Aprende a programar porfa xd";
            }
        }
    }
}