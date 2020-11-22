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
        NaverMusicDBEntities mddb = new NaverMusicDBEntities();

        List<proc_topTenTracks_Result> proc = new List<proc_topTenTracks_Result>();
        public List<proc_topTenTracks_Result> TopTrack()
        {
            proc = mddb.proc_topTenTracks().ToList();
            return proc;
        }
    }
}
