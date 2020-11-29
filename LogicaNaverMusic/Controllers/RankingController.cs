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

        //----SP´s PARA RANKING DIARIO--- 
        /*PROCEDURE PARA RANKING DIARIO TRACKS */ 
        List<proc_RankingDiarioTracks_Result> proc8 = new List<proc_RankingDiarioTracks_Result>();
        public List<proc_RankingDiarioTracks_Result> RankingDiarioTracks()
        {
            proc8 = mddb.proc_RankingDiarioTracks().ToList();
            return proc8;
        }
        /*PROCEDURE PARA RANKING DIARIO ARTISTA */
        List<proc_RankingDiarioArtistas_Result> proc9 = new List<proc_RankingDiarioArtistas_Result>();
        public List<proc_RankingDiarioArtistas_Result> RankingDiarioArtistas()
        {
            proc9 = mddb.proc_RankingDiarioArtistas().ToList();
            return proc9;
        }
        /*PROCEDURE PARA RANKING DIARIO ALBUM */
        List<proc_RankingDiarioAlbum_Result> proc10 = new List<proc_RankingDiarioAlbum_Result>();
        public List<proc_RankingDiarioAlbum_Result> RankingDiarioAlbum()
        {
            proc10 = mddb.proc_RankingDiarioAlbum().ToList();
            return proc10;
        }

        //----SP´s PARA RANKING SEMANAL Y MENSUAL----

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

        /*PROCEDURE PARA RANKING SEMANAL ARTISTAS*/
        List<proc_RankingSemanalArtistas_Result> proc6 = new List<proc_RankingSemanalArtistas_Result>();
        public List<proc_RankingSemanalArtistas_Result> RankingSemanalArtistas()
        {
            proc6 = mddb.proc_RankingSemanalArtistas().ToList();
            return proc6;
        }

        /*PROCEDURE PARA RANKING MENSUAL ARTISTAS*/
        List<proc_RankingMensualArtistas_Result> proc7 = new List<proc_RankingMensualArtistas_Result>();
        public List<proc_RankingMensualArtistas_Result> RankingMensualArtistas()
        {
            proc7 = mddb.proc_RankingMensualArtistas().ToList();
            return proc7;
        }

        /*PROCEDURE PARA RANKING SEMANAL ALBUM */
        List<proc_RankingSemanalAlbum_Result> proc11 = new List<proc_RankingSemanalAlbum_Result>();
        public List<proc_RankingSemanalAlbum_Result> RankingSemanalAlbum()
        {
            proc11 = mddb.proc_RankingSemanalAlbum().ToList();
            return proc11;
        }

        /*PROCEDURE PARA RANKING MENSUAL ALBUM */
        List<proc_RankingMensualAlbum_Result> proc12 = new List<proc_RankingMensualAlbum_Result>();
        public List<proc_RankingMensualAlbum_Result> RankingMensualAlbum()
        {
            proc12 = mddb.proc_RankingMensualAlbum().ToList(); 
            return proc12;
        }
    }
}
