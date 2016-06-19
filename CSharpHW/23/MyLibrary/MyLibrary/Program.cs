using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.IO.Compression;
using System.Xml;
using System.Xml.Linq;

namespace MyLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Book>));
            XmlSerializer userFormatter = new XmlSerializer(typeof(List<User>));

            XmlTextReader reader = new XmlTextReader(@"books.xml");
            reader.WhitespaceHandling = WhitespaceHandling.None;

            XDocument doc = XDocument.Load("books.xml");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("books.xml");

            User user;
            DBUsers users = new DBUsers();
            MyLibrary homeLibrary = new MyLibrary();

            string startPath = Environment.CurrentDirectory;
            string zipPath = @"c:\SaveFolder";
            string endPath = @"c:\New_Folder\MyLibrary";
            bool writed = false;

            using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                homeLibrary.books = (List<Book>)formatter.Deserialize(fs);
            }

            using (FileStream fs = new FileStream("users.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                users.userList = (List<User>)userFormatter.Deserialize(fs);
            }

            bool isAuth = Auth(users, out user);
            string userFile = user.UserName + ".xml";
            using (FileStream fs = new FileStream(userFile, FileMode.OpenOrCreate, FileAccess.Read))
            {
                try
                {
                    user.UserBooks = (List<Book>)formatter.Deserialize(fs);
                }
                catch (Exception ex)
                {

                }
            }


            string userAnswer = "";
            do
            {
                Menu(isAuth);
                userAnswer = Console.ReadLine();

                #region LibraryInfo (1)

                if (userAnswer == "1")
                {
                    Console.Clear();
                    Console.WriteLine(homeLibrary.Info());
                    PressEnter();
                }
                #endregion

                #region Find book (2)
                else if (userAnswer == "2")
                {
                    Console.Clear();
                    Console.WriteLine("1. Find by title\n" +
                                      "2. Find by author\n" +
                                      "3. Find by author and title");
                    string result = Console.ReadLine();
                    string author, title;
                    switch (result)
                    {
                        case "1":
                            Console.Write("Enter the title: ");
                            title = Console.ReadLine();
                            Console.WriteLine("\n" + homeLibrary.FindByTitle(title));
                            break;
                        case "2":
                            Console.Write("Enter the author:");
                            author = Console.ReadLine();
                            Console.WriteLine("\n" + homeLibrary.FindByAuthor(author));
                            break;
                        case "3":
                            Console.Write("Enter the author:");
                            author = Console.ReadLine();
                            Console.Write("Enter the title: ");
                            title = Console.ReadLine();
                            Console.WriteLine("\n" + homeLibrary.FindByAuthorAndTitle(author, title));
                            break;
                        default:
                            Console.WriteLine("Wrong number!");
                            break;
                    }
                    PressEnter();
                }
                #endregion

                #region Most popular book by genre (3)

                else if (userAnswer == "3")
                {
                    Console.Clear();
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
                    PressEnter();
                }
                #endregion

                #region TakeBook(4)

                else if (userAnswer == "4" && isAuth)
                {
                    Console.Clear();
                    if (homeLibrary.BookList().Count == 0)
                        Console.WriteLine("We haven't any book");
                    else
                    {
                        Console.WriteLine(homeLibrary.AllTitles());

                        int result;
                        int.TryParse(Console.ReadLine(), out result);

                        if (result != 0 && homeLibrary.BookList().Count > result - 1)
                        {
                            var book = homeLibrary.BookList()[result - 1];


                            var results = new List<ValidationResult>();
                            var context = new ValidationContext(book);

                            if (!Validator.TryValidateObject(book, context, results, true))
                            {
                                foreach (var error in results)
                                {
                                    Console.WriteLine(error.ErrorMessage);
                                }
                            }
                            else
                            {
                                foreach (var b in homeLibrary.books.Where(b => b.BookTitle == book.BookTitle))
                                {
                                    b.Popularity++;
                                }


                                user.TakeBook(book);
                                homeLibrary.Remove(book);
                            }
                        }
                        else
                            Console.WriteLine("Wrong number!");
                    }
                    PressEnter();
                }
                #endregion

                #region ReturnTheBook (5)

                else if (userAnswer == "5" && isAuth)
                {
                    Console.Clear();
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
                    PressEnter();

                }
                #endregion

                #region Add a book (6)

                else if (userAnswer == "6" && isAuth)
                {
                    Console.Clear();

                    string title, author, genre;
                    int year, pages;

                    #region Enter the details of a book

                    while (true)
                    {
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

                        Book book = new Book(title, author, genre, year, pages, 0);

                        #region CheckAttributes
                        var results = new List<ValidationResult>();
                        var context = new ValidationContext(book);

                        if (!Validator.TryValidateObject(book, context, results, true))
                        {
                            foreach (var error in results)
                            {
                                Console.WriteLine(error.ErrorMessage);
                            }
                        }
                        else
                        {
                            user.AddBookToLibrary(book, homeLibrary);
                            break;
                        }
                        #endregion

                        PressEnter();
                    }
                    #endregion
                }

                #endregion

                #region Find last owner (7)
                else if (userAnswer == "7" && isAuth)
                {
                    Console.Clear();
                    Console.WriteLine(homeLibrary.GetLastOwners());
                    Console.ReadLine();
                }
                #endregion

                #region XML_Find (9)
                else if (userAnswer == "9" && isAuth)
                {
                    Console.WriteLine("Enter book title:");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    string result = Console.ReadLine();
                    Console.ResetColor();

                    while (reader.Read())
                    {
                        if (reader.Name == "Book")
                        {
                            reader.Read();
                            string BookTitle = reader.ReadElementContentAsString();
                            string Author = reader.ReadElementContentAsString();
                            string Genre = reader.ReadElementContentAsString();
                            int Year,Pages,Popularity;
                            Int32.TryParse(reader.ReadElementContentAsString(),out Year);
                            Int32.TryParse(reader.ReadElementContentAsString(),out Pages);
                            Int32.TryParse(reader.ReadElementContentAsString(),out Popularity);
                            if (BookTitle.Contains(result))
                            {
                                Console.WriteLine(new Book(BookTitle, Author, Genre, Year, Pages, Popularity).BookInfo());
                                Console.WriteLine();
                            }
                        }
                    }
                    reader.Close();
                    PressEnter();
                }
                #endregion

                #region Select (10)
                else if (userAnswer == "10" && isAuth)
                {
                    Console.WriteLine("Authors: Shen and Vern");
                    var b1 = doc.Descendants("Book").
               Where(b => b.Elements("Author").Any(f => (string)f == "А.Шень"));

                    var b2 = doc.Descendants("Book").
                        Where(b => b.Elements("Author").Any(f => (string)f == "Верн Жуль"));

                    var books = b1.Concat(b2);
                    foreach (var q in books)
                        Console.WriteLine(q);
                    PressEnter();
                }
                #endregion

                #region XML_Insert (11)
                else if (userAnswer == "11" && isAuth)
                {
                    XElement elem = new XElement("Book",
                        new XElement("BookTitle", "XML_Added_Title"),
                        new XElement("Author", "XML_Added_Author"),
                        new XElement("Genre", "XML_Added_Genre"),
                        new XElement("Year", 2016),
                        new XElement("Pages", 999),
                        new XElement("Popularity", 6));


                    doc.Root.FirstNode.AddAfterSelf(elem);
                    doc.Save("books.xml");
                    using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate, FileAccess.Read))
                    {
                        homeLibrary.books = (List<Book>)formatter.Deserialize(fs);
                    }
                    Console.WriteLine("Added to XML file");
                    PressEnter();
                }
                #endregion




                #region Save (S)

                else if (userAnswer == "s" && user.UserName == "admin")
                {
                    if (Directory.Exists(startPath) && Directory.Exists(zipPath))
                        ZipFile.CreateFromDirectory(startPath, zipPath + @"\MyLibrary.zip");
                    else
                    {
                        Directory.CreateDirectory(zipPath);
                        ZipFile.CreateFromDirectory(startPath, zipPath + @"\MyLibrary.zip");
                    }
                    Console.WriteLine("Saved");
                    PressEnter();
                }
                #endregion

                #region Load (L)

                else if (userAnswer == "l" && user.UserName == "admin")
                {
                    if (Directory.Exists(endPath))
                        ZipFile.CreateFromDirectory(zipPath + @"\MyLibrary.zip", endPath);
                    else if (!Directory.Exists(zipPath))
                    {
                        Console.WriteLine("File didn't save before");
                    }
                    else
                    {
                        Directory.CreateDirectory(endPath);
                        ZipFile.ExtractToDirectory(zipPath + @"\MyLibrary.zip", endPath);
                        Console.WriteLine("Loaded");
                    }
                    PressEnter();

                }
                #endregion

                #region Exit (q)

                else if (userAnswer == "q")
                    break;

                #endregion
            }

            while (userAnswer != "exit");
            WriteLibraryToXMLDocument(homeLibrary);

            using (FileStream fs = new FileStream(userFile, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                serializer.Serialize(fs, user.BookList());

            }

            using (FileStream fs = new FileStream("users.xml", FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                serializer.Serialize(fs, users.userList);

            }

        }

        private static void WriteLibraryToXMLDocument(MyLibrary homeLibrary)
        {
            using (FileStream fs = new FileStream("books.xml", FileMode.Create, FileAccess.Write))
            {

                XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                serializer.Serialize(fs, homeLibrary.books);
            }
        }

        #region Methods
        /*-------------------------------------------Methods------------------------------------*/

        static void Menu(bool auth)
        {
            Console.Clear();
            if (auth)
            {
                Console.WriteLine("                 Menu: ");
                Console.WriteLine("1. Library info");
                Console.WriteLine("2. Find book");
                Console.WriteLine("3. The most popular book by genre");
                Console.WriteLine("4. Take a book");
                Console.WriteLine("5. Вернуть книгу");
                Console.WriteLine("6. Add a book");
                Console.WriteLine();
                Console.WriteLine("9. Search in xml file");
                Console.WriteLine("10. Select");
                Console.WriteLine("11. Add to XML file default book");
                Console.WriteLine();
                Console.WriteLine("s. Save (admin)");
                Console.WriteLine("l. Load (admin)");
                Console.WriteLine("q. Exit");
            }
            else
            {
                Console.WriteLine("                 Menu: ");
                Console.WriteLine("1. Library info");
                Console.WriteLine("2. Find book");
                Console.WriteLine("3. The most popular book by genre");
                Console.WriteLine();
                Console.WriteLine("q. Exit");
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

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Authorization");
                    Console.WriteLine("Enter your login:");
                    userName = Console.ReadLine().ToLower();

                    Console.WriteLine("Enter your password:");
                    password = Console.ReadLine();
                    User isAuthUser = new User(userName, password);

                    var results = new List<ValidationResult>();
                    var context = new ValidationContext(isAuthUser);

                    if (!Validator.TryValidateObject(isAuthUser, context, results, true))
                    {
                        foreach (var error in results)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }
                    else
                    {
                        if (users.isExsist(isAuthUser))
                        {
                            break;
                        }
                        Console.WriteLine("Wrong data");
                    }


                    PressEnter();
                }


                Console.Clear();
                Console.WriteLine("Hello, " + userName);
                user = users.FindUser(userName, password);
                return true;


            }


        }

        static void PressEnter()
        {
            Console.WriteLine();
            Console.WriteLine("Please, press Enter");
            Console.ReadLine();
        }
        #endregion
    }
}
