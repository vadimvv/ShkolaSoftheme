﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    //class Element<T>
    //{
    //    public T Data { get; set; }
    //    public int? Previous { get; set; }
    //    public int? Next { get; set; }
    //    public int? Current { get; set; }


    //    public Element(T data, int? previous, int? next)
    //    {
    //        Data = data;
    //        Previous = previous;
    //        Next = next;

    //    }
    //}
    //class MyLinkedList<T>
    //{
    //    private Element<T>[] Items;
    //    public MyLinkedList()
    //    {
    //    }

    //    public void Add(Element<T> element)
    //    {
    //        if (Items.Length == 0)
    //        {
    //            element.Previous = null;
    //            element.Current = 0;
    //            element.Next = null;
    //        }
    //        else
    //        {
    //            element.Previous = Items[Items.Length - 1].Current;
    //            element.Current = element.Previous++;
    //            element.Next = null;

    //            Items[Items.Length - 1].Next = element.Current;
    //        }
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList l = new MyLinkedList();

            l.Push_Back(5);
            l.Push_Back(4);
            l.Push_Back(3);
            l.Push_Back(2);

            Console.WriteLine(l.Pop_Front().Value);

            l.Display();
   
            
            Console.ReadLine();
        }
    }
}
