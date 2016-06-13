using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MyLibrary
{
    [OnlyForViewing]
    class Book : ICloneable
    {
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Pages { get; set; }
        public int Popularity { get; set; }

        public string Owner { get; set; }

        public Book(string bookTitle, string author, string genre, int year, int pages, int popularity)
        {
            BookTitle = bookTitle;
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

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
