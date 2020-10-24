using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic.BaseDatos;

namespace LogicaNaverMusic.Controllers
{
    class UserController
    {
        private NaverMusicDBEntities modelDb = new NaverMusicDBEntities();
        public bool CreateUser(string username, string password, string nombre, string apellido, string sexo,
            string foto, string status, string correo, string telefono)
        {
            Usuarios user = new Usuarios();

            user.username = username;
            user.passsword = password;
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
