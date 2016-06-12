using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStackRealization<int> R = new MyStackRealization<int>();
            R.Push(1);
            R.Push(2);
            R.Push(3);
            R.Push(4);
            R.Push(5);

            Console.WriteLine(R.Pop());
            Console.WriteLine(R.Pop());
            Console.WriteLine(R.Pop());
            Console.WriteLine(R.Pop());
            Console.WriteLine(R.Pop());
            Console.ReadLine();
        }
    }
}
