using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class Book
    {
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public int Popularity { get; set; }

        public Book(string title,string author, string genre, int year, int pages, int popularity)
        {
            BookTitle = title;
            Author = author;
            Genre = genre;
            Year = year;
            Pages = pages;
            Popularity = popularity;
        }

        public string BookInfo()
        {
            string result = "";

            result += "Book title: " + BookTitle +
                      "\nGenre: " + Genre +
                      "\nAuthor: " + Author +
                      "\nAmount of pages: " + Pages +
                      "\nYear: " + Year +
                      "\nPopularity: " + Popularity;
            return result;
        }
    }
}
