using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class MyLinkedList<T>
    {
        private Element<T> First;
        private Element<T> Current;
        private Element<T> Last;
        private uint size;
        public bool isEmpty
        {
            get
            {
                return size == 0;
            }
        }
        public uint Count
        {
            get { return size; }
            set { size = value; }
        }

        public MyLinkedList()
        {
            size = 0;
            First = Current = Last = null;
        }



        public void Insert_Index(T newElement, uint index)
        {
            if (index < 1 || index > size) 
            {
                throw new InvalidOperationException();
            }
            else if (index == 1) 
            {
                Push_Front(newElement);
            }
            else if (index == size)
            {
                Push_Back(newElement);
            }
            else 
            {
                uint count = 1;
                Current = First;
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }
                Element<T> newElem = new Element<T>(newElement);
                Current.Prev.Next = newElem;
                newElem.Prev = Current.Prev;
                Current.Prev = newElem;
                newElem.Next = Current;
            }
        }
        public void DeleteElement(uint index)
        {
            if (index < 1 || index > size)
            {
                throw new InvalidOperationException();
            }
            else if (index == 1)
            {
                Pop_Front();
            }
            else if (index == size)
            {
                Pop_Back();
            }
            else
            {
                uint count = 1;
                Current = First;
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }
                Current.Prev.Next = Current.Next;
                Current.Next.Prev = Current.Prev;
            }
        }


        public void Push_Front(T newElement)
        {
            Element<T> newElem = new Element<T>(newElement);

            if (First == null)
            {
                First = Last = newElem;
            }
            else
            {
                newElem.Next = First;
                First = newElem; 
                newElem.Next.Prev = First;
            }
            Count++;
        }
        public void Push_Back(T newElement)
        {
            Element<T> newElem = new Element<T>(newElement);

            if (First == null)
            {
                First = Last = newElem;
            }
            else
            {
                Last.Next = newElem;
                newElem.Prev = Last;
                Last = newElem;
            }
            Count++;
        }


        public Element<T> Pop_Front()
        {
            if (First == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Element<T> temp = First;
                if (First.Next != null)
                {
                    First.Next.Prev = null;
                }
                First = First.Next;
                Count--;
                return temp;
            }
        }
        public Element<T> Pop_Back()
        {
            if (Last == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Element<T> temp = Last;
                if (Last.Prev != null)
                {
                    Last.Prev.Next = null;
                }
                Last = Last.Prev;
                Count--;
                return temp;
            }
        }


        public void ClearList()
        {
            while (!isEmpty)
            {
                Pop_Front();
            }
        }
        public void Display()
        {
            if (First == null)
            {
                Console.WriteLine("Doubly Linked List is empty");
                return;
            }
            Current = First;
            uint count = 1;
            while (Current != null)
            {
                Console.WriteLine("Element " + count.ToString() + " : " + Current.Value.ToString());
                count++;
                Current = Current.Next;
            }
        }



        public Element<T> FindElem(T Data)
        {
            Current = First;
            while (Current != null)
            {
                Current = Current.Next;
            }
            return Current;
        }

    }
}




