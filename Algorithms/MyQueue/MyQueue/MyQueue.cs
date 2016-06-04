using System.Collections.Generic;


namespace MyQueue
{
    class MyQueue<T> 
    {
        private readonly Stack<T> Top;
        private readonly Stack<T> Tail;
        private T newElement;
        public MyQueue()
        {
            Top = new Stack<T>();
            Tail = new Stack<T>();
        }

        public void Push(T element)
        {
            newElement = element;
            ToQueue();
        }

        public void ToQueue()
        {
            while(Top.Count!=0)
            {
                Tail.Push(Top.Pop());
            }
            Tail.Push(newElement);

            while (Tail.Count != 0)
            {
                Top.Push(Tail.Pop());
            }

        }

        public void Pop()
        {
            Top.Pop();
        }

        public T Peek()
        {
            return Top.Peek();
        }
    }
}
