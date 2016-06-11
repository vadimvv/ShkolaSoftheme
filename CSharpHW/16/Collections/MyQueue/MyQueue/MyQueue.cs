using System.Collections.Generic;


namespace MyQueue
{
    class MyQueue<T> 
    {
        private readonly Stack<T> Head;
        private readonly Stack<T> Tail;
        public MyQueue()
        {
            Head = new Stack<T>();
            Tail = new Stack<T>();
        }

        public void Push(T element)
        {
            Tail.Push(element);
            ToQueue();
        }

        public void ToQueue()
        {
            if (Head.Count != 0) return;
            while (Tail.Count>0)
            {
                Head.Push(Tail.Pop());
            }
        }

        public void Pop()
        {
            Head.Pop();
            ToQueue();
        }

        public T Peek()
        {
            
            return Head.Peek();
        }
    }
}
