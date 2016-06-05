using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class Human
    {
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public readonly int age;
        public DateTime Birthday { get; set; }


        public Human(string firstName, string lastName)
            : this(firstName, lastName, DateTime.Today)
        {
        }


        public Human(string firstName, string lastName, DateTime birthDay)
        {
            FirstName = firstName;
            LasttName = lastName;

            if (birthDay.DayOfYear > DateTime.Today.DayOfYear)
                age = DateTime.Today.Year - birthDay.Year - 1;
            else
                age = DateTime.Today.Year - birthDay.Year;
        }


        public bool IsEqual(Human human)
        {
            if (FirstName == human.FirstName && LasttName == human.LasttName && Birthday == human.Birthday)
                return true;
            return false;
        }
    }
}
