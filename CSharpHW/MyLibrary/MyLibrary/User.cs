using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        private List<Book> userBooks;

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            userBooks = new List<Book>();
        }

    }
}
