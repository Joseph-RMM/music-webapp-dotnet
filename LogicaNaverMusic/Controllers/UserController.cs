using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.BaseDatos;
using LogicaNaverMusic.Helper;

namespace LogicaNaverMusic.Controllers
{
    public class UserController
    {
        private NaverMusicBDEntitiesAWS1 modelDb = new NaverMusicBDEntitiesAWS1();
        public bool CreateUser(string username, string password, string nombre, string apellido, string sexo,
            string foto, string status, string correo, string telefono)
        {
            Usuarios user = new Usuarios();

            user.username = username;
            user.passsword = HashHelper.GetSHA256(password);
            user.nombre = nombre;
            user.apellido = apellido;
            user.sexo = sexo;
            user.foto = foto;
            user.estatus = status;
            user.correo = correo;
            user.telefono = telefono;

            modelDb.Usuarios.Add(user);
            modelDb.SaveChanges();

            return true;

        }
    }
}
