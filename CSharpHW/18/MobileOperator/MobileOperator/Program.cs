using System;


namespace MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            MobileOperator Djuice = new MobileOperator();
            MobileAccount Vadym = new MobileAccount("+380968590222","Vadym");
            MobileAccount Roger = new MobileAccount("+380968589111","Roger");
            MobileAccount George = new MobileAccount("+380966120653", "George");

            Djuice.Add(Vadym);
            Djuice.Add(Roger);
            Djuice.Add(George);

            Vadym.AddContact("+380968589111", "Roger - Developer");
            Vadym.AddContact("+380966120653", "Brother");


            Roger.MakeCall(Vadym);
            George.SendSMS(Vadym,"Hello");

            Console.ReadLine();
        }
    }
}
