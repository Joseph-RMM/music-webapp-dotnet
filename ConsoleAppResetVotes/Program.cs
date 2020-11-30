using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppResetVotes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread t = new Thread(PrintX);
            //t.Start();
            //t.Join();
            //Console.ReadLine();
            MasterReset();


        }

        static void PrintX()
        {
            bool b = true;
            DateTime date;
            char c = '/';

            while (b)
            {
                
                string fecha = DateTime.Now.ToShortDateString();
                date = Convert.ToDateTime("28/11/2020");
                byte dayWeek = (byte)date.DayOfWeek;
                string[] splitDate = fecha.Split(c);
                string dia = splitDate[0];
                string mes = splitDate[1];
                int diaWeek = (int)dayWeek;


                Console.WriteLine("Dia: " + dia + "\nMes: " + mes + "\ndia de la semana: " + diaWeek + "\n");
                Thread.Sleep(1000);
            }
        }

        static void MasterReset()
        {
            bool b = true;

            while (b)
            {
                string hoy = DateTime.Now.ToShortDateString();

                DateTime date = Convert.ToDateTime(hoy);
                int dayWeek = (int)date.DayOfWeek;
                int month = (int)date.Month;

                Thread.Sleep(1000);

                if (CheckDay(dayWeek))
                {
                    CheckWeek(dayWeek);
                    CheckMonth(month);
                }
                else
                {
                    Console.WriteLine("dia: " + dayWeek + "\n mes: " + month + "\n sin cambios");
                }
            }
        }

        static bool CheckDay(int day)
        {
            bool change = false;

            DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            int dayWeek = (int)date.DayOfWeek;

            if (dayWeek != day)
            {
                change = true;
                Console.WriteLine("Dia actualizado");
            }

            return change;
        }

        static void CheckWeek(int day)
        {
            if (day == 0)
            {
                Console.WriteLine("Semana actualizada");
            }
        }

        static void CheckMonth(int month)
        {

            DateTime date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            int currentMonth = (int)date.DayOfWeek;

            if (currentMonth != month)
            {
                Console.WriteLine("Mes actualizado");
            }
        }
    }
}
