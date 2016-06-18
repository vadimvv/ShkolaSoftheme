using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class DBUsers
    {
        List<User> users;

        public DBUsers()
        {
            users = new List<User>();
            users.Add(new User("zevas", "12345"));
            users.Add(new User("admin", "admin"));
            users.Add(new User("farafa", "qwerty"));
        }

        public void Add(User user)
        {
            users.Add(user);
        }

        public bool isExsist(User user)
        {
            return users.Any(u => u.UserName == user.UserName && u.Password == user.Password);
        }

        public User FindUser(string userName, string password)
        {
            return users.Find(u => u.UserName == userName && u.Password == password);
        }

        public List<User> GetUsers()
        {
            return users;
        }

    }
}
