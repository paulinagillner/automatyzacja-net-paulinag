using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!!!");
            string tekst = "";
            while (tekst != "exit")
            {
                Console.WriteLine("Napisz 'exit' i naciśnij klawisz 'Enter', żeby zamknąć aplikację");
                tekst = Console.ReadLine();
            }
        }
    }
}