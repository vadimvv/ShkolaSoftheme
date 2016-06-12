using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    public class Item<T>
    {
        public T Data { get; set; }

        public Item<T> Next { get; set; }

        public Item(T d)
        {
            Data = d;
        }

        public void AddNextItem(T d)
        {
            Item<T> item = this;
            Item<T> newIteme = new Item<T>(d);

            while (item.Next != null)
            {
                item = item.Next;
            }

            item.Next = newIteme;
        }
    }

    /*------------------------------*/

    public class MyStackRealization<T>
    {
        private Item<T> top;
        public int Count { get; private set; }

        public MyStackRealization()
        {
            Count = 0;
        }

        public void Push(T elem)
        {
            Item<T> newItem = new Item<T>(elem);

            if (top == null)
                top = newItem;
            else
            {
                Item<T> temp = top;
                top = newItem;
                top.Next = temp;
            }
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            Item<T> elemToPop = top;
            top = top.Next;
            Count--;

            return elemToPop.Data;
        }

        public T Peek()
        {
            return top.Data;
        }
    }
}
