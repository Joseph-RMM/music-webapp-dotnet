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
        NaverMusicBDEntitiesAWS1 modldb = new NaverMusicBDEntitiesAWS1();

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

        /*PROCEDURE PARA INSERTAR VOTO ARTISTA*/
        public bool proc_VotarArtista(int idartista, int iduser, DateTime fecha)
        {
            modldb.proc_VotarArtista(idartista, iduser, fecha);
            return true;
        }

        /*PROCEDURE PARA INSERTAR VOTO ALBUM*/
        public bool proc_VotarAlbum(int idalbum, int iduser, DateTime fecha)
        {
            modldb.proc_VotarAlbum(idalbum, iduser, fecha);
            return true;
        }
    }
}
