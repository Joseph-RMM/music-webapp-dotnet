using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.BaseDatos;

namespace LogicaNaverMusic.Controllers
{
    
    public class VotoController
    {
        NaverMusicDBEntities modldb = new NaverMusicDBEntities();

        /*PROCEDURE PARA OBTENER NUMERO DE VOTOS DE USUARIO POR CANCION POR DIA*/
        proc_GetVotesByUser_Result proc = new proc_GetVotesByUser_Result();
        public proc_GetVotesByUser_Result GetVotesByUser(int iduser)
        {
            proc = modldb.proc_GetVotesByUser(iduser).FirstOrDefault();
            return proc;
        }

        /*PROCEDURE PARA INSERTAR VOTO CANCION*/
        public bool proc_VotarCancion(int idcancion, int iduser, DateTime fecha)
        {
            modldb.proc_VotarCancion(idcancion, iduser, fecha);
            return true;
        }


    }
}
