using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public int Popularity { get; set; }

        public Book(string name,string author, string genre, int year, int pages, int popularity)
        {
            Name = name;
            Author = author;
            Genre = genre;
            Year = year;
            Pages = pages;
            Popularity = popularity;
        }
    }
}
