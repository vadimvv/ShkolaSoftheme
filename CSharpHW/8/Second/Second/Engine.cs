using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class Engine:ICloneable
    {
        public string Model { get; set; }
        public double Volume { get; set; }

        public Engine(string model, double volume)
        {
            Model = model;
            Volume = volume;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
