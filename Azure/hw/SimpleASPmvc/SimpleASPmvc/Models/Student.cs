using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleASPmvc.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Group { get; set; }
        public string Course { get; set; }
    }
}