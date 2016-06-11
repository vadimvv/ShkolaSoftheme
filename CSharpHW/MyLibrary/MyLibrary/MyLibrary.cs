using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net.Sockets;
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
            this.Add(new Book("Сто лет одиночества", "Маркес Габриэль", "Современная проза", 1940, 92, 5), 5);
            this.Add(new Book("Приключения капитана врунгеля", "Некрасов Александр", "Детские приключения", 1979, 32, 4), 3);
            this.Add(new Book("Тореодори з Васюківки", "Нестайко Всеволод", "Детские приключения", 1990, 121, 8), 6);
            this.Add(new Book("Дети капитана Гранта", "Верн Жуль", "Путишествия", 1980, 155, 5), 2);
            this.Add(new Book("Одна минута и вся жизнь", "Полянская Алла", "Криминальные детективы", 2010, 67, 1), 7);
            this.Add(new Book("Последний рассвет", "Маринина Александра", "Детектив", 2001, 89, 3), 1);
            this.Add(new Book("Алгоритмы на Java", "Роберт Седжвик", "Научная литература", 2015, 848, 12), 1);
            this.Add(new Book("Программирование. Теоремы и задачи", "А.Шень", "Научная литература", 2004, 295, 10), 3);

        }

       
        public bool FindByTitle(string title)
        {
            var book = books.Where(b => b.BookTitle.Contains(title));
            if (book != null)
                return true;

            return false;
        }

        public string Info()
        {
            return "Amount of books by genre:\n" + QuantityByGenre() +
                   "\n\nThe latest added book:\n" + LastBookInfo() +
                   "\n\nThe oldest book:\n" + FirstBookInfo() +
                   "\n\nThe most popular book:\n" + MostPopularBook();
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
            return books.Distinct().ToList();
            //string result = "";
            //int counter = 1;
            //foreach (var b in books.Distinct())
            //{
            //    result += counter + ". " + b.BookTitle + "\n";
            //    counter++;
            //}
            //return result;
        }
        public string AllBooks()
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
            for (int i = 0; i < amount; i++)
            {
                books.Add(book);
            }

        }
        public void Remove(Book book)
        {
            books.Remove(book);
        }
        public int Amount()
        {
            return books.Count;
        }
    }
}
