using System;

using MyLib_Age_Zodiac;

namespace First
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckAge_And_ZodiacSign myClass = new CheckAge_And_ZodiacSign();

            Console.WriteLine(myClass.GetInfo());
            Console.ReadLine();
        }
    }
}
