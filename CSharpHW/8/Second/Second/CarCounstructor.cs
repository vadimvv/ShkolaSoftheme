using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    static class CarCounstructor
    {
        public static Car Construct(Color color, Engine engine, Transmission transmission)
        {
            return new Car((Color)color.Clone(), (Engine)engine.Clone(), (Transmission)transmission.Clone());
        }

        public static void Reconstruct(ref Car ThisCar)
        {
            ThisCar._Engine = new Engine("New " + ThisCar._Engine.Model, ThisCar._Engine.Volume);
        }
    }
}
