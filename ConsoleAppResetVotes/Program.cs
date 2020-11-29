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
            Thread t = new Thread(PrintX);
            t.Start();
            t.Join();
            //Console.ReadLine();
                
        }

        static void PrintX()
        {
            bool b = true;
            string date;
            char c = '/';

            while (b)
            {
                Console.WriteLine(date = DateTime.Now.ToShortDateString());
                Thread.Sleep(1000);
            }
        }
    }
}
