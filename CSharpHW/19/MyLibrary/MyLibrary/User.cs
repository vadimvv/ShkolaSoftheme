﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class User
    {
        public delegate void LibHandler(Book book, User user);
        public event LibHandler AddingBooks = null;
        private void OnAddingBooks(Book book, User user)
        {
            book.Owner = user.UserName;
        }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        private List<Book> userBooks;

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            userBooks = new List<Book>();
            AddingBooks += OnAddingBooks;
        }
        public void TakeBook(Book book)
        {
            userBooks.Add(book);
        }

        public void ReturnTheBook(Book book)
        {
            userBooks.Remove(book);
            AddingBooks.Invoke(book, this);
        }

        public void AddBookToLibrary(Book book, MyLibrary library)
        {
            library.Add(book,1);
        }

        public string ShowTakenBooks()
        {
            string result = "";
            int counter = 1;

            var TitleGroups = (from b in userBooks
                               group b by b.BookTitle
                              into g
                               select new { Title = g.Key, Amount = g.Count() }
               );

            Console.WriteLine("Your books:");
            foreach (var b in TitleGroups)
            {
                result += counter + ". " + b.Title + " (" + b.Amount + ")\n";
                counter++;
            }
            return result;
        }

        public List<Book> BookList()
        {
            return userBooks.Distinct().ToList();
        }
    }
}
