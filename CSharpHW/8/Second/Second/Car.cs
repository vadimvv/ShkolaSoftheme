using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class Car
    {
        public Color _Color { get; set; }
        public Engine _Engine { get; set; }
        public Transmission _Transmission { get; set; }


        public Car(Color color, Engine engine, Transmission transmission)
        {
            _Color = (Color)color.Clone();
            _Engine = (Engine)engine.Clone();
            _Transmission = (Transmission)transmission.Clone();
        }

        public Car(Engine engine)
        {
            _Engine = (Engine) engine.Clone();
        }

        public string GetInfo()
        {
            return "Color: " + _Color._Color + "\nEngine: " + _Engine.Model + "; " +_Engine.Volume + "\nTransmission: " + _Transmission.ControlMethod + "; "+_Transmission.Gear;
        }
    }
}
