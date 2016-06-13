using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder();
            StringBuilder output = new StringBuilder();
            input.Append("aabccccaaa");

            int counter = 1;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    counter = counter + 1;
                    if (i != input.Length - 2)
                        continue;
                }
                output.Append(input[i] + "" + counter);
                counter = 1;
            }

            if (input.Length <= output.Length)
                Console.WriteLine(input);
            else
                Console.WriteLine(output);


            Console.ReadLine();
        }
    }
}
