using System;


namespace MyQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new MyQueue<int>();

            for (int i = 0; i < 150; i++)
            {
                queue.Push(i);
            }
            for (int i = 0; i < 150; i++)
            {
                Console.WriteLine(queue.Peek());
                queue.Pop();
            }

            Console.ReadLine();
        }
    }
}
