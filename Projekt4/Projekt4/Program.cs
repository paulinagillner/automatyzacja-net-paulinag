using System;

namespace Zadanie4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("y = a * (x * x) + b * y + c");
            Console.Write("podaj wartośc a = ");
            var a = Convert.ToDouble(Console.ReadLine());

            Console.Write("podaj wartośc b = ");
            var b = Convert.ToDouble(Console.ReadLine());

            Console.Write("podaj wartośc c = ");
            var c = Convert.ToDouble(Console.ReadLine());

            Calculate(a, b, c);

            Console.WriteLine("Brawo! Czwarte zadanie zrobione :)");
            Console.WriteLine("Naciśnij jakikolwiek klawisz aby zakończyć...");
            Console.ReadKey();
        }

        private static void Calculate(double a, double b, double c)
        {
            double x1 = 0;
            double x2 = 0;

            double delta = (b * b) - 4 * a * c;
            Console.WriteLine("delta = "+delta);

            if (delta>0) // np a=-1 b=3 c=4
            {
                x1 = ((-b + Math.Sqrt(delta)) / (2*a));
                x2 = ((-b - Math.Sqrt(delta)) / (2*a));
                Console.WriteLine("Funkcja ma dwa miejsca zerowe:");
                Console.WriteLine("x1 = "+ x1);
                Console.WriteLine("x2 = "+ x2);

            }
            else if (delta==0) // np a=2 b=-4 c=2
            {   
                     x1 = -b / (2 * a);
                     Console.WriteLine("Funkcja ma jedno miejsce zerowe:");
                     Console.WriteLine("x1 = " + x1);
                 }
                 else
                 {   // delta<0  np a=-5 b=6 c=2
                     Console.WriteLine("Funkcja nie ma miejsc zerowych.");
                 }
            // napisz obliczanie rozwiązań (miejsc zerowych) funkcji kwadratowej 
            // jeśli nie pamiętasz jak to się liczy to tutaj jest ściąga
            // http://matma.prv.pl/kwadratowa.php
            // postaraj się napisac to samodzielnie a nie googlując implementację
            // powodzenia :)
           // Console.WriteLine(delta);
           // Console.WriteLine(x1);
           // Console.WriteLine(x2);
        }
    }
}