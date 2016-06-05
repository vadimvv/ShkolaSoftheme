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
            int[] mass = new[] { 6, 5, 3, 1, 8, 7, 2, 4 };
            mass=InsertionSort(mass);
            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine(mass[i]);
            }
            Console.ReadLine();
        }

        private static int[] InsertionSort(int[] mass)
        {
            int[] result = new int[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                int j = i;
                while (j > 0 && result[j - 1] > mass[i])
                {
                    result[j] = result[j - 1];
                    j--;
                }
                result[j] = mass[i];
            }
            return result;
        }
    }
}
