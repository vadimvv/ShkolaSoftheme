using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            DBUsers users = DefaultUsers();
            MyLibrary homeLibrary = DefaultBooks();
            DefaultUsers();
            bool isAuth = Auth(users);

            if (isAuth)
            {

                Console.WriteLine("1. Library info");
                Console.WriteLine("2. Find book");
                Console.WriteLine("3. The most popular book");
                Console.WriteLine("4. Take a book");
                Console.WriteLine("5. Вернуть книгу");
                Console.WriteLine("6. Add a book");
            }
            else
            {
                Console.WriteLine("1. Library info");
                Console.WriteLine("2. Find book");
                Console.WriteLine("3. The most popular book");
            }

            Console.ReadLine();
        }


        static bool Auth(DBUsers users)
        {
            Console.WriteLine("Do you want to log in?");
            Console.WriteLine("1. Yes      2.No");
            string answer = Console.ReadLine();
            if (answer != "1")
            {
                return false;
            }
            else
            {
                string userName, password;
                Console.Clear();
                Console.WriteLine("Authorization");
                Console.WriteLine("Enter your login:");
                userName = Console.ReadLine();

                Console.WriteLine("Enter your password:");
                password = Console.ReadLine();

                if (users.isExsist(new User(userName, password)))
                {
                    Console.Clear();
                    Console.WriteLine("Hello, " + userName);
                    return true;
                }
                Console.WriteLine("Wrong! Your status is 'unauthorized'");
                return false;
            }


        }

        static MyLibrary DefaultBooks()
        {
            MyLibrary homeLibrary = new MyLibrary();
            homeLibrary.Add(new Book("Сто лет одиночества", "Маркес Габриэль", "Современная проза", 1940, 92, 5));
            homeLibrary.Add(new Book("Приключения капитана врунгеля", "Некрасов Александр", "Детские приключения", 1979, 32, 4));
            homeLibrary.Add(new Book("Тореодори з Васюківки", "Нестайко Всеволод", "Детские приключения", 1990, 121, 8));
            homeLibrary.Add(new Book("Дети капитана Гранта", "Верн Жуль", "Путишествия", 1980, 155, 5));
            homeLibrary.Add(new Book("Одна минута и вся жизнь", "Полянская Алла", "Криминальные детективы", 2010, 67, 1));
            homeLibrary.Add(new Book("Последний рассвет", "Маринина Александра", "Детектив", 2001, 89, 3));
            homeLibrary.Add(new Book("Алгоритмы на Java", "Роберт Седжвик", "Научная литература", 2015, 848, 8));
            homeLibrary.Add(new Book("Программирование. Теоремы и задачи", "А.Шень", "Научная литература", 2004, 295, 10));
            return homeLibrary;


        }

        static DBUsers DefaultUsers()
        {
            DBUsers users = new DBUsers();
            users.Add(new User("zevas", "12345"));
            users.Add(new User("admin", "admin"));
            users.Add(new User("farafa", "qwerty"));
            return users;
        }

    }
}
