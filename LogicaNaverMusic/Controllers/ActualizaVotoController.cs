using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.BaseDatos;

namespace LogicaNaverMusic.Controllers
{
    public class ActualizaVotoController
    {
        NaverMusicBDEntitiesAWS1 modelDb = new NaverMusicBDEntitiesAWS1();

        public Sp_ProcesoDSMUpdate_By_Day_Result Update_By_Day()
        {
            Sp_ProcesoDSMUpdate_By_Day_Result update = new Sp_ProcesoDSMUpdate_By_Day_Result();
            update = modelDb.Sp_ProcesoDSMUpdate_By_Day().FirstOrDefault();
            modelDb.SaveChanges();
            return update;
        }

        public Sp_ProcesoDSMUpdate_By_Week_Result Update_By_Week()
        {
            Sp_ProcesoDSMUpdate_By_Week_Result update = new Sp_ProcesoDSMUpdate_By_Week_Result();
            update = modelDb.Sp_ProcesoDSMUpdate_By_Week().FirstOrDefault();
            modelDb.SaveChanges();
            return update;
        }
    }
}
