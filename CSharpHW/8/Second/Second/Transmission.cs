using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class Transmission : ICloneable
    {
        public string ControlMethod { get; set; }
        public int Gear { get; set; }

        public Transmission(string controlMethod, int gear)
        {
            ControlMethod = controlMethod;
            Gear = gear;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
