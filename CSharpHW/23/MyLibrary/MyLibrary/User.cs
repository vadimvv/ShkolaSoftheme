using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    [Serializable]
    public class User
    {
        
        public delegate void LibHandler(Book book, User user);

        public event LibHandler AddingBooks = null;
        public void OnAddingBooks(Book book, User user)
        {
            book.Owner = user.UserName;
        }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public List<Book> UserBooks { get; set; }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            UserBooks = new List<Book>();
            AddingBooks += OnAddingBooks;
        }

        public User()
        {

        }
        public void TakeBook(Book book)
        {
            UserBooks.Add(book);
        }

        public void ReturnTheBook(Book book)
        {
            UserBooks.Remove(book);
            AddingBooks.Invoke(book, this);
        }

        public void AddBookToLibrary(Book book, MyLibrary library)
        {
            library.Add(book, 1);
        }

        public string ShowTakenBooks()
        {
            string result = "";
            int counter = 1;

            var TitleGroups = (from b in UserBooks
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
            return UserBooks.Distinct().ToList();
        }
    }
}
