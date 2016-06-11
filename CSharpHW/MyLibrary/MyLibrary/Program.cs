using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            User user;
            DBUsers users = new DBUsers();
            MyLibrary homeLibrary = new MyLibrary();

            bool isAuth = Auth(users, out user);


            string userAnswer = "";
            do
            {
                Menu(isAuth);
                userAnswer = Console.ReadLine();

                #region LibraryInfo (1)
                if (userAnswer == "1")
                    Console.WriteLine(homeLibrary.Info());
                #endregion

                #region Most popular book by genre (3)
                else if (userAnswer == "3")
                {
                    if (homeLibrary.BookList().Count == 0)
                        Console.WriteLine("We haven't any book");
                    else
                    {
                        Console.WriteLine(homeLibrary.ShowAllGenres());
                        int returnResult;
                        int.TryParse(Console.ReadLine(), out returnResult);
                        if (returnResult != 0 && homeLibrary.GetGenresList().Count > returnResult - 1)
                        {
                            var genre = homeLibrary.MostPopularBook(homeLibrary.GetGenresList()[returnResult - 1]);
                            Console.WriteLine(genre);
                        }
                        else
                            Console.WriteLine("Wrong number");
                    }
                }
                #endregion

                #region TakeBook(4)
                else if (userAnswer == "4" && isAuth)
                {

                    if (homeLibrary.BookList().Count == 0)
                        Console.WriteLine("We haven't any book");
                    else
                    {
                        Console.WriteLine(homeLibrary.AllBooks());



                        int result;
                        int.TryParse(Console.ReadLine(), out result);

                        if (result != 0 && homeLibrary.BookList().Count > result - 1)
                        {
                            var book = homeLibrary.BookList()[result - 1];
                            book.Popularity++;
                            user.TakeBook(book);
                            homeLibrary.Remove(book);
                        }
                        else
                            Console.WriteLine("Wrong number!");
                    }
                }
                #endregion

                #region ReturnTheBook (5)
                else if (userAnswer == "5" && isAuth)
                {
                    if (user.BookList().Count == 0)
                        Console.WriteLine("You haven't any book");
                    else
                    {
                        Console.WriteLine(user.ShowTakenBooks());

                        int returnResult;
                        int.TryParse(Console.ReadLine(), out returnResult);
                        if (returnResult != 0 && user.BookList().Count > returnResult - 1)
                        {
                            var book = user.BookList()[returnResult - 1];
                            homeLibrary.Add(book, 1);
                            user.ReturnTheBook(book);
                        }
                        else
                            Console.WriteLine("Wrong number");
                    }

                }
                #endregion

                #region Add a book (6)
                else if (userAnswer == "6" && isAuth)
                {
                    string title, author, genre;
                    int year, pages;
                    #region Enter the details of a book
                    Console.WriteLine("Еnter the details of a book");
                    Console.Write("Title: ");
                    title = Console.ReadLine();
                    Console.Write("Author: ");
                    author = Console.ReadLine();
                    Console.Write("Genre: ");
                    genre = Console.ReadLine();
                    Console.Write("Year: ");
                    int.TryParse(Console.ReadLine(), out year);
                    Console.Write("Pages: ");
                    int.TryParse(Console.ReadLine(), out pages);
                    #endregion
                    Book book = new Book(title,author,genre,year,pages,0);
                    user.AddBookToLibrary(book,homeLibrary);


                }

                #endregion

                #region Exit (7)
                else if (userAnswer == "7")
                    break;
                #endregion
            }

            while (userAnswer != "exit");
        }

        static void Menu(bool auth)
        {
            if (auth)
            {
                Console.WriteLine("                 Menu: ");
                Console.WriteLine("1. Library info");
                Console.WriteLine("2. Find book");
                Console.WriteLine("3. The most popular book by genre");
                Console.WriteLine("4. Take a book");
                Console.WriteLine("5. Вернуть книгу");
                Console.WriteLine("6. Add a book");
                Console.WriteLine("7. Exit");
            }
            else
            {
                Console.WriteLine("                 Menu: ");
                Console.WriteLine("1. Library info");
                Console.WriteLine("2. Find book");
                Console.WriteLine("3. The most popular book by genre");
                Console.WriteLine();
                Console.WriteLine("7. Exit");
            }
        }


        static bool Auth(DBUsers users, out User user)
        {
            Console.WriteLine("Do you want to log in?");
            Console.WriteLine("1. Yes      2.No");
            string answer = Console.ReadLine();
            if (answer != "1")
            {
                user = new User("Unregistered", "12345");
                return false;
            }
            else
            {
                string userName, password;
                Console.Clear();
                Console.WriteLine("Authorization");
                Console.WriteLine("Enter your login:");
                userName = Console.ReadLine().ToLower();

                Console.WriteLine("Enter your password:");
                password = Console.ReadLine();

                if (users.isExsist(new User(userName, password)))
                {
                    Console.Clear();
                    Console.WriteLine("Hello, " + userName);
                    user = users.GetUser(userName, password);
                    return true;
                }
                Console.WriteLine("Wrong! Your status is 'unauthorized'");
                user = new User("Unregistered", "12345");
                return false;
            }


        }


    }
}
