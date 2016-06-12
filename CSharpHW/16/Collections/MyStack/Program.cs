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
            MyStack<int> R = new MyStack<int>();
            R.Add(1);
            R.Add(2);
            R.Add(3);
            R.Add(4);
            R.Add(5);

            R.PrintAll();
            Console.ReadLine();
        }
    }
}
