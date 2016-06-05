using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber{ get; set; }
        public string AdditionalInfo{ get; set; }

        public User(string firstName, string lastName, string birthdate, string gender, string email, string phone, string additionalInfo)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthdate;
            Gender = gender;
            Email = email;
            PhoneNumber = phone;
            AdditionalInfo = additionalInfo;
        }

    }
}
