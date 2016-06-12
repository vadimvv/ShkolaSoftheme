using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            MyKeyValuePair<int, string> f = new MyKeyValuePair<int, string>();

            f.Add(1, "January");
            f.Add(2, "February");
            f.Add(3, "March");
            f.Add(4, "April");
            f.Add(5, "May");
            f.Add(6, "June");
            f.Add(7, "July");
            f.Add(8, "August");
            f.Add(9, "September");
            f.Add(10, "October");
            f.Add(11, "November");
            f.Add(12, "December");

            Console.WriteLine("Now is {0}", f.GetValueByKey(DateTime.Now.Month));



            Console.ReadLine();
        }
    }
}
