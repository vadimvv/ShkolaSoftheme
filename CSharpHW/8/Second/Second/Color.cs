using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class Color : ICloneable
    {
        public string _Color { get; set; }

        public Color(string color)
        {
            _Color = color;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
