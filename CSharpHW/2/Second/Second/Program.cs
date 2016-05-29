using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Plus 2.Minus 3.Multiply 4.Divide");
            string n = Console.ReadLine();
            Console.Write("a = ");
            double a = 0, b = 0;

            try
            {
                a = Convert.ToDouble(Console.ReadLine());
                Console.Write("b = ");
                b = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not number! (You should use ',')");
            }

            switch (n)
            {
                case "1":
                    Console.WriteLine("a + b = {0}", a + b);
                    break;
                case "2":
                    Console.WriteLine("a - b = {0}", a - b);
                    break;
                case "3":
                    Console.WriteLine("a * b = {0}", a * b);
                    break;
                case "4":
                    if (b == 0)
                    {
                        Console.WriteLine("You can not divide by zero");
                        break;
                    }
                    Console.WriteLine("a / b = {0}", a / b);
                    break;
                default:
                    Console.WriteLine("I don't know this sign -", n);
                    break;
            }
            Console.ReadLine();
        }
    }
}
