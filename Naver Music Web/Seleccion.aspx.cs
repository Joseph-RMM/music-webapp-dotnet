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
using System.Drawing;

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

            //Obtener  Imagen
            if (FileUpload1.HasFile) {
                int Size = FileUpload1.PostedFile.ContentLength;
                byte[] profileImage = new byte[Size];
                FileUpload1.PostedFile.InputStream.Read(profileImage, 0, Size);
                Bitmap bitImage = new Bitmap(FileUpload1.PostedFile.InputStream);

                //Redimensionar Imagen
                System.Drawing.Image imageThumbnail;
                int ThumbSize = 250;
                imageThumbnail = RedimencionarImg(bitImage, ThumbSize);
                byte[] bitImageThumb = new byte[ThumbSize];

                ImageConverter converter = new ImageConverter();
                bitImageThumb = (byte[])converter.ConvertTo(imageThumbnail, typeof(byte[]));

                string Data64 = "data:" + FileUpload1.PostedFile.ContentType + ";base64," + Convert.ToBase64String(bitImageThumb);

                string telefono = txbTelefono.Text;
                string sexo = RadioButtonList1.SelectedValue;

                //Enviar a la bd

                UserController userController = new UserController();
                bool userCreated = true;
                userCreated = userController.CreateUser(userName, pass, " ", " ", sexo, Data64, "No Premium", email, telefono);


                if (userCreated) { //Verificar la creación y logear al usuario
                    UsuariosModels currentUser = userController.LoginUser(email, pass);
                    if (currentUser.idUsuario != 0) {
                        Session["userData"] = currentUser;
                        if (chbAuto.Checked) {
                            Session.Timeout = 525600;
                        } else {
                            //Las variables de sessión tienen un timeout de 20 minutos por default, por lo que no se recordará al usuario
                        }
                        Response.Redirect("Inicio.aspx");
                    } else {
                        lblInfo.Text = "Error al registrar usuario";
                    }
                } else {
                    lblInfo.Text = "No se ha podido establecer conexión con la db";
                }
            } else {
                lblInfo.Text = "Por favor, seleccione una foto de perfil";
            }
        }

        public System.Drawing.Image RedimencionarImg(System.Drawing.Image image, int Alto) {
            /*double Ratio = (double)Alto / image.Height;
            int newAncho = (int)(image.Width * Ratio);
            int newAlto = (int)(image.Height * Ratio);*/
            var resized = new Bitmap(Alto,Alto);
            var drawer = Graphics.FromImage(resized);
            drawer.DrawImage(image, 0, 0, Alto,Alto);
            return resized;
        }
    }
}