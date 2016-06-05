using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    class Car
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public Car()
        {
            Model = "Default";
            Year = 2016;
            Color = "Black";
        }

        public Car(string model, int year, string color)
        {
            Model = model;
            Year = year;
            Color = color;
        }

        public string GetInfo()
        {
            return "Model: " + Model + "\nYear: " + Year + "\nColor: " + Color;
        }
    }
}
