using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNaverMusic.Models
{
    public class UsuariosModels
    {
        public int idUsuario { get; set; }
        public string username { get; set; }
        public string passsword { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string foto { get; set; }
        public string estatus { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
    }
}
