﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class MyLibrary
    {
        List<Book> books;


        public MyLibrary()
        {
            books = new List<Book>();
        }

        public void Add(Book book)
        {
            books.Add(book);
        }
    }
}