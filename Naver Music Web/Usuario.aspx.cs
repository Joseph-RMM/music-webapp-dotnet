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
    public partial class Usuario : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["userData"] != null) {
                UsuariosModels currentUser = (UsuariosModels)Session["userData"];
                userImage.ImageUrl = currentUser.foto;
                userName.Text = currentUser.username;
                lblCorreo.Text = "E-mail: "+currentUser.correo;
                lblTelefono.Text = "Tel: " + currentUser.telefono;
                lblSexo.Text = "Sexo: " + currentUser.sexo;
                lblEstatus.Text = "Tipo de usuario: " + currentUser.estatus;
                VotoController votoController = new VotoController();
                proc_GetVotesByUser_Result proc = new proc_GetVotesByUser_Result();
                proc = votoController.GetVotesByUser(currentUser.idUsuario);
                int votosUsados = proc.total ?? 0;
                int votosRestantes = 100 - votosUsados;
                lblVotos.Text = "Hoy has usado ♥ "+votosUsados+" votos y te quedan ♥ "+votosRestantes;
            }
        }

        protected void btnCerrarSesión_Click(object sender, EventArgs e) {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
    }
}