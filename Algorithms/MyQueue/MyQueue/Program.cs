using System;


namespace MyQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var MyStack = new MyQueue<int>();

            for (int i = 0; i < 150; i++)
            {
                MyStack.Push(i);
            }
            for (int i = 0; i < 150; i++)
            {
                Console.WriteLine(MyStack.Peek());
                MyStack.Pop();
            }
            
            Console.ReadLine();
        }
    }
}
