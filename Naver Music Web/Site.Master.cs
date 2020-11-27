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
    public partial class Site : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["userData"] != null) {
                //Display user info
                UsuariosModels currentUser = (UsuariosModels) Session["userData"];
                username.Text = currentUser.username;
                try {
                    userimg.ImageUrl = currentUser.foto;
                } catch (Exception exception) {
                    userimg.ImageUrl = "/assets/nouser.png";
                }
                VotoController votoController = new VotoController();
                proc_GetVotesByUser_Result proc = new proc_GetVotesByUser_Result();
                proc = votoController.GetVotesByUser(currentUser.idUsuario);
                int votosUsados = proc.total ?? 0;
                int votosRestantes = 100 - votosUsados;
                lblVotosRestantes.Text = "♥ " + votosRestantes;
            } else {
                Response.Redirect("Default.aspx");
            }
        }
    }
}