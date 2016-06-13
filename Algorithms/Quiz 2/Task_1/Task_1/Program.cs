using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int a = 0; a < 10; a++)
            {
                for (int b = 0; b < 10; b++)
                {
                    for (int c = 0; c < 10; b++)
                    {
                        for (int d = 0; d < 10; b++)
                        {
                            if (Math.Pow(a, 3)+Math.Pow(b,3)== Math.Pow(c, 3) + Math.Pow(d, 3))
                                Console.WriteLine(" "+ " "+a+" " + b+ " "+c + " "+d);
                        }
                    }
                }
            }

            
                

            Console.ReadLine();
        }
    }
}
