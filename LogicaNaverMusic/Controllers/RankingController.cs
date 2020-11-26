using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.BaseDatos;

namespace LogicaNaverMusic.Controllers
{
    public class RankingController
    {
        NaverMusicBDEntitiesAWS1 mddb = new NaverMusicBDEntitiesAWS1();

        /*PROCEDURE PARA OBTENER EL TOP DE CANCIONES MAS VOTADAS*/
        List<proc_topTenTracks_Result> proc = new List<proc_topTenTracks_Result>();
        public List<proc_topTenTracks_Result> TopTenTrack()
        {
            proc = mddb.proc_topTenTracks().ToList();
            return proc;
        }

        /*PROCEDURE PARA OBTENER EL TOP DE ARTISTAS MAS VOTADOS*/
        List<proc_topTenArtists_Result> proc2 = new List<proc_topTenArtists_Result>();
        public List<proc_topTenArtists_Result> TopTenArtists()
        {
            proc2 = mddb.proc_topTenArtists().ToList();
            return proc2;
        }

        /*PROCEDURE PARA OBTENER EL TOP DE ALBUM MAS VOTADOS*/
        List<proc_topTenAlbum_Result> proc3 = new List<proc_topTenAlbum_Result>();
        public List<proc_topTenAlbum_Result> TopTenAlbum()
        {
            proc3 = mddb.proc_topTenAlbum().ToList();
            return proc3;
        }

        //----SP´s PARA RANKING DIARIO, SEMANAL Y MENSUAL DE TRACKS----
        /*PROCEDURE PARA RANKING SEMANAL TRACKS*/
        List<proc_RankingSemanalTracks_Result> proc4 = new List<proc_RankingSemanalTracks_Result>();
        public List<proc_RankingSemanalTracks_Result> RankingSemanalTracks()
        {
            proc4 = mddb.proc_RankingSemanalTracks().ToList();
            return proc4;
        }

        /*PROCEDURE PARA RANKING MENSUAL TRACKS*/
        List<proc_RankingMensualTracks_Result> proc5 = new List<proc_RankingMensualTracks_Result>();
        public List<proc_RankingMensualTracks_Result> RankingMensualTracks()
        {
            proc5 = mddb.proc_RankingMensualTracks().ToList();
            return proc5;
        }

    }
}
