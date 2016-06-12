using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            MobileOperator Djuice = new MobileOperator();
            MobileAccount Vadym = new MobileAccount("Vadym", "+380968590222");
            MobileAccount Roger = new MobileAccount("Roger", "+380968589111");
            MobileAccount George = new MobileAccount("George", "+380966120653");


            Djuice.Add(Vadym);
            Djuice.Add(Roger);
            Djuice.Add(George);


            Vadym.MakeCall(Roger);
            George.SendSMS(Vadym,"Hello");

            Console.ReadLine();
        }
    }
}
