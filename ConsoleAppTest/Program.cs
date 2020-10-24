using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNaverMusic;
using LogicaNaverMusic.Controllers; //CONTROLADORES DE LOGICA NEGOCIOS
using LogicaNaverMusic.Models;      //MODELOS DE LOGICA NEGOCIOS     

namespace ConsoleAppTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int eleccion = 0;
            while (eleccion != 10)
            {
                Console.WriteLine("1 para busqueda, 2 para crear usuario, 10 para salir");
                eleccion = (int.Parse(Console.ReadLine()));

                switch (eleccion)
                {
                    case 1:
                        SearchInAPI();
                        break;
                    case 2:
                        CreateUser();
                        break;
                    case 10:
                        Environment.Exit(0);
                        break;

                }
            }
        }

        static void SearchInAPI()
        {
            Console.WriteLine("Introduzca busqueda");

            string busqueda = (Console.ReadLine());

            APIDeezerController aPIDeezer = new APIDeezerController();  //CLASE DE LOGICA NEGOCIOS

            List<Data> data = new List<Data>();
            data = aPIDeezer.GetDataFromSearchDeezer(busqueda);

            foreach (Data current in data)
            {
                Console.WriteLine(current.artist.name + " " + current.album.title + " " + current.title_short);
            }
        }

        static void CreateUser()
        {
            Console.WriteLine("CREAR USUARIO");
            Console.WriteLine("Username: ");
            string username = (Console.ReadLine());
            Console.WriteLine("Password: ");
            string password = (Console.ReadLine());
            Console.WriteLine("Nombre: ");
            string nombre = (Console.ReadLine());
            Console.WriteLine("Apellido: ");
            string apellido = (Console.ReadLine());
            Console.WriteLine("Sexo: ");
            string sexo = (Console.ReadLine());
            Console.WriteLine("Foto: ");
            string foto = (Console.ReadLine());
            Console.WriteLine("Estatus: ");
            string estatus = (Console.ReadLine());
            Console.WriteLine("Correo: ");
            string correo = (Console.ReadLine());
            Console.WriteLine("Telefono: ");
            string telefono = (Console.ReadLine());

            UserController userController = new UserController();

            bool userCreate = userController.CreateUser(username,password,nombre,apellido,sexo,foto,estatus,correo,
                telefono);

            if (userCreate)
            {
                Console.WriteLine("USUARIO CREADO");
            }
            else
            {
                Console.WriteLine("ERROR");
            }

        }
    }
}
