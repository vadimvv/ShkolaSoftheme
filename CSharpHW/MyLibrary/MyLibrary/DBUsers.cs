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
        }

        public void Add(User user)
        {
            users.Add(user);
        }

        public bool isExsist(User user)
        {

            return users.Any(u => u.UserName == user.UserName && u.Password == user.Password);
        }

    }
}
