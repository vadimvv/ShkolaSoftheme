using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MainParameters
            Color color = new Color("Black");
            Engine engine = new Engine("Model A", 2);
            Transmission transmission = new Transmission("Automatic", 5);
            #endregion

            #region new Item, GetInfo
            Car Mazda = CarCounstructor.Construct(color, engine, transmission);
            Console.WriteLine(Mazda.GetInfo());
            #endregion

            #region ChangeMainParameters
            color._Color = "White";
            engine.Volume = 44;
            transmission.Gear = 100000;
            Console.WriteLine();
            #endregion

            #region Reconstruct,GetInfo
            CarCounstructor.Reconstruct(ref Mazda);
            Console.WriteLine(Mazda.GetInfo());
            #endregion

            

            Console.ReadLine();

        }
    }
}
