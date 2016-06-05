using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            var Vadym = new Human("Vadym", "Ivashyn", new DateTime(1995, 03, 13));
            var Alana = new Human("Alana", "Blanchard", new DateTime(1990, 3, 5));
            var X = new Human("Name", "Surname");
            var Y = new Human("Name","Surname");

            Console.WriteLine(Vadym.FirstName + ": " + Vadym.age);
            Console.WriteLine(Alana.FirstName + ": " + Alana.age);

            Console.WriteLine();

            Console.WriteLine(X.FirstName + ": " + X.age);
            Console.WriteLine(Y.FirstName + ": " + Y.age);

            if (X.IsEqual(Y))
                Console.WriteLine("The same!");
            Console.ReadLine();
        }
    }
}
