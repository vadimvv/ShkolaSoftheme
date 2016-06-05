using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            int MyAge = 25;
            int YourAge = MyAge;
            MyAge++;

            Console.WriteLine("MyAge: "+MyAge);
            Console.WriteLine("YourAge: "+YourAge);
            Console.WriteLine("------------------------------");
            
            User FirstUser = new User("Alan", "Walker");
            User SecondUser = FirstUser;

            FirstUser.FirstName = "Martin";
            FirstUser.LastName = "Garrix";


            Console.WriteLine("FirstUser\n"+FirstUser.GetInfo());
            Console.WriteLine();
            Console.WriteLine("SecondUser\n" + SecondUser.GetInfo());

            Console.ReadLine();
        }
    }
}
