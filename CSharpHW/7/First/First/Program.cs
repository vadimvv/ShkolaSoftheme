using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            Car Toyota = new Car();
            TuningAtelier.TuneCar(ref Toyota);
            Console.WriteLine(Toyota.GetInfo());
            Console.ReadLine();
        }
    }
}
