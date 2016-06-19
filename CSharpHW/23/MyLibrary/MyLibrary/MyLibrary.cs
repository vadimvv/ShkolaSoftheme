﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{


    public class MyLibrary
    {
        public List<Book> books;
        public List<User> users;
        public MyLibrary()
        {

            books = new List<Book>();
        }

        public string Info()
        {
            return "Amount of books by genre:\n" + QuantityByGenre() +
                   "\n\nThe latest added book:\n" + LastBookInfo() +
                   "\n\nThe oldest book:\n" + FirstBookInfo() +
                   "\n\nThe most popular book:\n" + MostPopularBook();
        }
        public string FindByTitle(string title)
        {
            string result = "Not Found";
            var findBooks = books.Where(b => b.BookTitle.Contains(title)).Distinct();      //FirstOrDefault(b => b.BookTitle == title);
            if (!findBooks.Any())
                foreach (var b in findBooks)
                {
                    result += b.BookInfo() + "\n\n";
                }
            return result;
        }

        public string FindByAuthor(string author)
        {
            string result = "Not Found";
            var findBooks = books.Where(b => b.Author.Contains(author)).Distinct();//   FirstOrDefault(b => b.Author == author);
            if (!findBooks.Any())
                foreach (var b in findBooks)
                {
                    result += b.BookInfo() + "\n\n";
                }
            return result;
        }

        public string FindByAuthorAndTitle(string author, string title)
        {
            string result = "Not Found";
            var findBooks = books.Where(b => (b.Author + b.BookTitle).Contains(author + title)).Distinct(); // FirstOrDefault(b => b.Author + b.BookTitle == author + title);
            if (!findBooks.Any())
                foreach (var b in findBooks)
                {
                    result += b.BookInfo() + "\n\n";
                }
            return result;
        }

        public string QuantityByGenre()
        {
            string result = "";
            var genreGroups = from b in books.Distinct()
                              group b by b.Genre
                               into g
                              select new { Genre = g.Key, Amount = g.Count() }
                ;
            foreach (var g in genreGroups)
            {
                result += g.Genre + " - " + g.Amount + "\n";
            }
            return result;
        }

        public string LastBookInfo()
        {
            return books.LastOrDefault().BookInfo();
        }
        public string MostPopularBook()
        {
            return books.OrderBy(b => b.Popularity).LastOrDefault().BookInfo();
        }
        public string MostPopularBook(string genre)
        {
            return books.Where(b => b.Genre == genre).OrderBy(b => b.Popularity).LastOrDefault().BookInfo();
        }

        public string ShowAllGenres()
        {
            string result = "Genres:\n";
            int counter = 1;
            var genres = from b in books.Distinct()
                         group b by b.Genre
                into g
                         select new { Genre = g.Key, Amount = g.Count() };

            foreach (var g in genres)
            {
                result += counter + ". " + g.Genre + "\n";
                counter++;
            }

            return result;
        }





        public string GetLastOwners()
        {
            string resutl = "";
            int counter = 1;
            foreach (var b in books)
            {

                resutl += counter + ". " + b.Owner + "\n";
                counter++;
            }
            return resutl;
        }
        /*----------------------------------*/
        public List<string> GetGenresList()
        {
            List<string> result = new List<string>();
            var genres = from b in books.Distinct()
                         group b by b.Genre
                into g
                         select new { Genre = g.Key, Amount = g.Count() };

            foreach (var g in genres)
            {
                result.Add(g.Genre);
            }

            return result;
        }
        public List<Book> BookList()
        {
            List<Book> result = books.GroupBy(t => t.BookTitle)
                                  .Select(g => g.First())
                                  .ToList();
            return result;
        }
        public string AllTitles()
        {
            string result = "";
            int counter = 1;

            var TitleGroups = (from b in books
                               group b by b.BookTitle
                              into g
                               select new { Title = g.Key, Amount = g.Count() }
               );

            Console.WriteLine("We have next books:");
            foreach (var b in TitleGroups)
            {
                result += counter + ". " + b.Title + " (" + b.Amount + ")\n";
                counter++;
            }
            return result;
        }
        public string FirstBookInfo()
        {
            return books.FirstOrDefault().BookInfo();
        }
        public void Add(Book book, int amount)
        {
            if (amount == 1)
                books.Add((Book)book.Clone());
            else
            {
                for (int i = 0; i < amount; i++)
                {
                    books.Add(book);
                }
            }

        }
        public void Remove(Book book)
        {
            books.Remove(book);
        }
    }
}
