using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class DBUsers
    {
        public List<User> userList;

        public DBUsers()
        {
            userList = new List<User>();
        }

        public void Add(User user)
        {
            userList.Add(user);
        }

        public bool isExsist(User user)
        {
            return userList.Any(u => u.UserName == user.UserName && u.Password == user.Password);
        }

        public User FindUser(string userName, string password)
        {
            return userList.Find(u => u.UserName == userName && u.Password == password);
        }

        public List<User> GetUsers()
        {
            return userList;
        }

    }
}
