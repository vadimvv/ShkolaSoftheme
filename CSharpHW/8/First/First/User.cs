using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
    class User
    {
        public readonly int Id=0;
        public string FirstName { get; set; }
        public  string LastName { get; set; }

        public User(string firstName, string lastName)
        {
            Id++;
            FirstName = firstName;
            LastName = lastName;
        }

        public string GetInfo()
        {
            return "UserId: "+Id+"\nFirstName: "+FirstName + "\nLastName: "+LastName;
        }
    }
}
