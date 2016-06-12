using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class OnlyForViewingAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var book = value as Book;
            if (book != null && book.BookTitle == "Сто лет одиночества" && book.Author == "Маркес Габриэль")
            {
                ErrorMessage = "You can't take this book!";
                return false;
            }
            return true;
        }
    }
}
