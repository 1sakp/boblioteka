using System;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using static System.Reflection.Metadata.BlobBuilder;

namespace bobliotek
{
    internal class biblo
    {
        static void Main()
        {

            start();

            static void start()
            {
                //remove whitespace and empty
                string fullPathbook = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";
                var lines = File.ReadAllLines(fullPathbook).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(fullPathbook, lines);

                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";
                var lineslog = File.ReadAllLines(fullPath).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(fullPath, lineslog);

                //login or signup
                Console.WriteLine("If you already have an account, Please write 'login'! To sign up write 'Sign up'!");
                string choise = Console.ReadLine();
                if (choise.ToLower() == "login")
                {
                    Console.WriteLine("To log-in please write, Username:");
                    string username_actual = Console.ReadLine();
                    Console.WriteLine("Pasword:");
                    string password_actual = Console.ReadLine();

                    string[] users = File.ReadAllLines(fullPath, Encoding.UTF8);

                    //check users
                    foreach (string user in users)
                    {
                        string[] splittemp = user.Split('!');
                        string uname = splittemp[0];
                        string pword = splittemp[1];
                        string admin = splittemp[3];

                        if (uname.ToLower() == username_actual.ToLower() && pword.ToLower() == password_actual.ToLower())
                        {
                            Console.WriteLine($"Welcome {uname} You have been logged in!");

                            if (admin == "user")
                            {
                                biblioacc();
                            }
                            else if (admin == "admin")
                            {
                                biblioacc_admin();
                            }
                        }
                    }
                    Console.WriteLine("Wrong useranme or password... press enter to continue...");
                    Console.ReadLine();
                    start();
                }
                else if (choise.ToLower() == "sign up");
                {
                    reg();
                }
            }

            static void reg() {
                //register
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";

                bool loop = true;
                while (loop == true)
                {
                    string choise = null;
                    Console.WriteLine("Do you want to continue to sign up? Y/N");
                    choise = Console.ReadLine();

                    if (choise.ToLower() == "y")
                    {
                        Console.WriteLine("Choose a Username:   ");
                        string Username = Console.ReadLine();
                        Console.WriteLine("Choose a Pasword:   ");
                        string Pasword = Console.ReadLine();
                        Console.WriteLine("Personal number:   ");
                        string pn = Console.ReadLine();

                        string apend = Username + "!" + Pasword + "!" + pn + "!" + "user";
                        string[] lines = { apend };

                        File.AppendAllLines(fullPath, lines);

                        Console.WriteLine("You have been registerd!");
                        start();
                    }
                    else
                    {
                        start();
                    }
                }
            }

            static void biblioacc_admin()
            {

                //choise
                string choise = null;
                Console.WriteLine("Do you want to add a book, ('add'), or list all users, ('list'), or remove book, ('remove'), register a user, ('register'), change user credentials ('change'), edit a book, ('edit'), or delete a user, ('delete')");
                choise = Console.ReadLine();

                //remove whitespace and empty
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";
                var lines = File.ReadAllLines(fullPath).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(fullPath, lines);

                string fullPathlog = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";
                var lineslog = File.ReadAllLines(fullPathlog).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(fullPathlog, lineslog);

                if (choise.ToLower() == "add")
                {
                    add();
                }

                else if (choise.ToLower() == "list")
                {
                    list();
                }

                else if (choise.ToLower() == "remove")
                {
                    remove();
                }

                else if (choise.ToLower() == "register")
                {
                    reg();
                }

                else if (choise.ToLower() == "change")
                {
                    change();
                }

                else if (choise.ToLower() == "edit")
                {
                    edit();
                }

                else if (choise.ToLower() == "delete")
                {
                    delete();
                }

                else
                {
                    biblioacc_admin();
                }
            }

            static void biblioacc()
            {
                //choise
                string choise = null;
                Console.WriteLine("Do you want to search for a book, ('search'), or do you want to see all books, ('view'), or rent, ('rent'), or logout('logout'), or return a book('return')");
                choise = Console.ReadLine();

                //remove whitespace and empty
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";
                var lines = File.ReadAllLines(fullPath).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(fullPath, lines);

                string fullPathlog = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";
                var lineslog = File.ReadAllLines(fullPathlog).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(fullPathlog, lineslog);

                if (choise.ToLower() == "search")
                {
                    search();
                }

                else if (choise.ToLower() == "view")
                {
                    view();
                }

                else if (choise.ToLower() == "logout")
                {
                    logout();
                }

                else if (choise.ToLower() == "rent")
                {
                    rent();
                }

                else if (choise.ToLower() == "return")
                {
                    return_book();
                }

                else
                {
                    biblioacc();
                }
            }

            static void delete()
            {
                Console.WriteLine("\n");

                //remove whitespace and empty
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";
                var lines = File.ReadAllLines(fullPath).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(fullPath, lines);

                string fullPathlog = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";
                var lineslog = File.ReadAllLines(fullPathlog).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(fullPathlog, lineslog);

                string[] login = File.ReadAllLines(fullPathlog);

                int i = 0;

                //show options
                foreach (string user in login)
                {
                    string[] Info = user.Split("!");
                    string name = Info[0];
                    string password = Info[1];
                    string personal_number = Info[2];
                    string rented = Info[4];

                    Console.WriteLine($"[{i}]\nName: {name}\nPassword: {password}\nPersonal number: {personal_number}\nWhat book numbers are rented: {rented}");
                    i++;
                }

                Console.WriteLine("Type number of the user you want to remove:  ");
                string choise = Console.ReadLine();

                //get int from choise
                int choise_int = 0;
                try
                {
                    choise_int = int.Parse(choise);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please type a number!\n\nPress enter to contniue!...");
                    Console.ReadLine();
                    remove();
                }

                //set selected to "" then remove "";
                login[choise_int] = "";
                File.WriteAllLinesAsync(fullPathlog, login);

                biblioacc_admin();
            }

            static void change()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";

                string[] login = File.ReadAllLines(fullPath);

                int i = 0;

                //get users
                foreach (string user in login)
                {
                    string[] Info = user.Split("!");
                    string name = Info[0];
                    string password = Info[1];
                    string personal_number = Info[2];
                    string rented = Info[4];

                    Console.WriteLine($"[{i}]\nName: {name}\nPassword: {password}\nPersonal number: {personal_number}\nWhat book numbers are rented: {rented}");
                    i++;
                }

                //choose admin
                Console.WriteLine("Number of user yoou want to admin: ");
                string choise = Console.ReadLine();
                int choise_int = 0;
                try
                {
                    choise_int = int.Parse(choise);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please type a number!\n\nPress enter to contniue!...");
                    Console.ReadLine();
                    biblioacc_admin();
                }

                //uppdate files
                string[] Info_ = login[choise_int].Split("!");

                string login_update = $"{Info_[0]}!{Info_[1]}!{Info_[2]}!admin!{Info_[4]}";
                
                login[choise_int] = login_update;

                File.WriteAllLines(fullPath, login);
            }

            static void list()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";

                string[] login = File.ReadAllLines(fullPath);

                int i = 0;
                //get users
                foreach (string user in login)
                {
                    string[] Info = user.Split("!");
                    string name = Info[0];
                    string password = Info[1];
                    string personal_number = Info[2];
                    string rented = Info[4];

                    Console.WriteLine($"\nName: {name}\nPassword: {password}\nPersonal number: {personal_number}\nWhat book numbers are rented: {rented}");
                    i++;
                }
                Console.WriteLine("Press 'Enter' button to continue!... ");
                string choise = Console.ReadLine();

                biblioacc_admin();
            }

            static void edit()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";
                string[] Books = File.ReadAllLines(fullPath);

                int i = 0;

                //show options
                foreach (string Book in Books)
                {
                    string[] Info = Book.Split("!");

                    Book_class obj = new Book_class(Info[0], Info[1], Info[2], Info[3], Info[4]);

                    Console.WriteLine($"[{i}]\nName: {obj.Book_Name_c}\nRelese Year: {obj.Relese_Year_c}\nNumber of Pages: {obj.Page_Num_c}\nAuthor: {obj.Author_c}\nRented: {obj.Rented}\n");
                    i++;
                }

                Console.WriteLine("Type number of the book you want to edit:  ");
                string choise = Console.ReadLine();

                //edit action
                int choise_int = 0;
                try
                {
                    choise_int = int.Parse(choise);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please type a number!\n\nPress enter to contniue!...");
                    Console.ReadLine();
                    edit();
                }
                
                //get new value
                Console.WriteLine("Book Name?:  ");
                string Book_Name = Console.ReadLine();
                Console.WriteLine("Year Releesed?:  ");
                string Relese_Year = Console.ReadLine();
                Console.WriteLine("Page Number?:  ");
                string Page_Num = Console.ReadLine();
                Console.WriteLine("Author?: ");
                string Author = Console.ReadLine();

                //attach and send to file
                string apend = Book_Name + "!" + Relese_Year + "!" + Page_Num + "!" + Author + "!False";
                Books[choise_int] = apend;

                File.WriteAllLines(fullPath, Books);

                biblioacc_admin();
            }

            static void remove()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";
                string[] Books = File.ReadAllLines(fullPath);

                int i = 0;

                //show options
                foreach (string Book in Books)
                {
                    string[] Info = Book.Split("!");

                    Book_class obj = new Book_class(Info[0], Info[1], Info[2], Info[3], Info[4]);

                    Console.WriteLine($"[{i}]\nName: {obj.Book_Name_c}\nRelese Year: {obj.Relese_Year_c}\nNumber of Pages: {obj.Page_Num_c}\nAuthor: {obj.Author_c}\nRented: {obj.Rented}\n");
                    i++;
                }

                Console.WriteLine("Type number of the book you want to remove:  ");
                string choise = Console.ReadLine();

                //get int from choise
                int choise_int = 0;
                try
                {
                    choise_int = int.Parse(choise);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please type a number!\n\nPress enter to contniue!...");
                    Console.ReadLine();
                    remove();
                }

                //set selected to "" then remove "";
                Books[choise_int] = "";
                File.WriteAllLinesAsync(fullPath, Books);

                Console.WriteLine("Press enter to continue");
                Console.ReadLine();

                var lines = File.ReadAllLines(fullPath).Where(arg => !string.IsNullOrWhiteSpace(arg));
                File.WriteAllLines(fullPath, lines);

                biblioacc_admin();
            }

            static void return_book()
            {
                //paths
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";

                string[] Books = File.ReadAllLines(fullPath);

                string logpath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";

                string[] login = File.ReadAllLines(logpath);

                Console.WriteLine("Write your personal number to return a book of your choosing:   ");
                string num = Console.ReadLine();

                //define and ticker
                int i = 0;
                string num_book = null;

                //identify user and set
                foreach (string Cred in login)
                {
                    string[] log_split = Cred.Split("!");

                    if (log_split[2] == num)
                    {
                        num_book = log_split[4];

                        string log_update = $"{log_split[0]}!{log_split[1]}!{log_split[2]}!{log_split[3]}!";

                        login[i] = log_update;

                        File.WriteAllLines(logpath, login);

                        break;
                    }
                    i++;
                }

                //def book content
                string Book = Books[int.Parse(num_book)];
                string[] Info = Book.Split("!");
                string Book_Name = Info[0];
                string Relese_Year = Info[1];
                string Page_Num = Info[2];
                string Author = Info[3];
                string Rent = Info[4];

                Book_class obj = new Book_class(Info[0], Info[1], Info[2], Info[3], Info[4]);

                Console.WriteLine($"[{i}]\nName: {obj.Book_Name_c}\nRelese Year: {obj.Relese_Year_c}\nNumber of Pages: {obj.Page_Num_c}\nAuthor: {obj.Author_c}\nRented: {obj.Rented}\n");
                
                //conferm
                Console.WriteLine($"Do you want to return: {obj.Book_Name_c} Y/N");
                string choise = Console.ReadLine();

                //set book to not rented
                string book_update = $"{Book_Name}!{Relese_Year}!{Page_Num}!{Author}!False";

                Books[int.Parse(num_book)] = book_update;

                File.WriteAllLines(fullPath, Books);


                //remove rented books
                foreach (string Cred in login)
                {
                    string[] log_split = Cred.Split("!");

                    if (log_split[2] == num)
                    {

                        string log_update = $"{log_split[0]}!{log_split[1]}!{log_split[2]}!{log_split[3]}!";

                        login[i] = log_update;

                        File.WriteAllLines(logpath, login);

                        break;
                    }
                }


                biblioacc();
            }

            static void logout()
            {
                //if confirmed go back to start
                Console.WriteLine("Confirm Y/N");
                string choise = Console.ReadLine();

                if (choise.ToLower() == "y")
                {
                    start();
                }
                else if (choise.ToLower() == "n")
                {
                    biblioacc();
                }
                else
                {
                    logout();
                }
            }

            static void rent()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";

                string[] Books = File.ReadAllLines(fullPath);

                string logpath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";

                string[] login = File.ReadAllLines(logpath);

                Console.WriteLine(Books);

                int i = 0;

                //rent menu
                foreach (string Book in Books)
                {
                    string[] Info = Book.Split("!");
                    string Book_Name = Info[0];
                    string Relese_Year = Info[1];
                    string Page_Num = Info[2];
                    string Author = Info[3];
                    string Rent = Info[4];

                    Book_class obj = new Book_class(Info[0], Info[1], Info[2], Info[3], Info[4]);

                    Console.WriteLine($"[{i}]\nName: {obj.Book_Name_c}\nRelese Year: {obj.Relese_Year_c}\nNumber of Pages: {obj.Page_Num_c}\nAuthor: {obj.Author_c}\nRented: {obj.Rented}\n");
                    i++;
                }
                Console.WriteLine("Type number of the book you want to rent:  ");
                string choise = Console.ReadLine();

                //Rent action
                int choise_int = 0;
                try
                {
                    choise_int = int.Parse(choise);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please type a number!\n\nPress enter to contniue!...");
                    Console.ReadLine();
                    rent();
                }

                string[] Inforent = Books[choise_int].Split("!");
                string Book_Name_rent = Inforent[0];
                string Relese_Year_rent = Inforent[1];
                string Page_Num_rent = Inforent[2];
                string Author_rent = Inforent[3];
                string Rent_acc = Inforent[4];

                //loop for check user
                if (Rent_acc == "False")
                {
                    Console.WriteLine("Please write your personal number to rent:   ");
                    string num = Console.ReadLine();

                    i = 0;

                    //loop for check user credentials and if true change
                    foreach (string Cred in login)
                    {
                        string[] log_split = Cred.Split("!");

                        if (log_split[2] == num)
                        {
                            string login_update = $"{log_split[0]}!{log_split[1]}!{log_split[2]}!{log_split[3]}!{choise_int.ToString()}";
                            login[i] = login_update;

                            File.WriteAllLines(logpath, login);

                            break;
                            Console.WriteLine("match!");
                        }
                        Console.WriteLine("Loop");
                        i++;
                    }


                    //write to file
                    string book_update = $"{Book_Name_rent}!{Relese_Year_rent}!{Page_Num_rent}!{Author_rent}!True";

                    Books[choise_int] = book_update;

                    File.WriteAllLines(fullPath, Books);


                }
                else
                {
                    Console.WriteLine("You can't rent this book it's already rented!\n\nPress enter to continue!...");
                    Console.ReadLine();
                    biblioacc();
                }



                //Console.WriteLine($"\nName: {obj_r.Book_Name_c}\nRelese Year: {obj_r.Relese_Year_c}\nNumber of Pages: {obj_r.Page_Num_c}\nAuthor: {obj_r.Author_c}\nRented: {obj_r.Rented}\n");
              


                biblioacc();
            }

            static void search()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";

                //define
                Console.WriteLine("Search:  ");
                string searchres = Console.ReadLine();
                string[] Books = File.ReadAllLines(fullPath);
                List<string> list = new List<string>();
                List<string> list1 = new List<string>();

                //searches all books
                foreach (string book in Books)
                {
                    if (book.ToLower().Contains(searchres.ToLower())){
                        
                        string[] Info = book.Split("!");
                        string Book_Name = Info[0].ToLower();
                        string Relese_Year = Info[1].ToLower();
                        string Page_Num = Info[2].ToLower();
                        string Author = Info[3].ToLower();
                        string Rent = Info[4];

                        Book_class obj = new Book_class(Info[0], Info[1], Info[2], Info[3], Info[4]);

                        Console.WriteLine($"\nName: {obj.Book_Name_c}\nRelese Year: {obj.Relese_Year_c}\nNumber of Pages: {obj.Page_Num_c}\nAuthor: {obj.Author_c}\nRented: {obj.Rented}\n");
                        
                        
                    }
                }
                Console.WriteLine("Press 'Enter' button to continue!... ");
                string choise = Console.ReadLine();

                biblioacc();

            }

            static void add()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";

                //get values
                Console.WriteLine("Book Name?:  ");
                string Book_Name = Console.ReadLine();
                Console.WriteLine("Year Releesed?:  ");
                string Relese_Year = Console.ReadLine();
                Console.WriteLine("Page Number?:  ");
                string Page_Num = Console.ReadLine();
                Console.WriteLine("Author?: ");
                string Author =Console.ReadLine();

                //save to variable and to file
                string apend = Book_Name + "!" + Relese_Year + "!" + Page_Num + "!" + Author + "!False";
                string[] lines = { apend };

                File.AppendAllLines(fullPath, lines);

                biblioacc();
            }

            static void view()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";

                string[] Books = File.ReadAllLines(fullPath);

                int i = 0;

                //get info of books and write
                foreach (string Book in Books)
                {
                    string[] Info = Book.Split("!");
                    string Book_Name = Info[0];
                    string Relese_Year = Info[1];
                    string Page_Num = Info[2];
                    string Author = Info[3];
                    string Rent = Info[4];

                    Book_class obj = new Book_class(Info[0], Info[1], Info[2], Info[3], Info[4]);

                    Console.WriteLine($"[{i}]\nName: {obj.Book_Name_c}\nRelese Year: {obj.Relese_Year_c}\nNumber of Pages: {obj.Page_Num_c}\nAuthor: {obj.Author_c}\nRented: {obj.Rented}\n");
                    i++;
                }
                Console.WriteLine("Press 'Enter' button to continue!... ");
                string choise = Console.ReadLine();

                biblioacc();
            }
        } 
    }
    public class Book_class
    {
        public string Book_Name_c;
        public string Relese_Year_c;
        public string Page_Num_c;
        public string Author_c;
        public string Rented;

        public Book_class(string name, string relese, string pnum, string author, string rented)
        {
            this.Book_Name_c = name;
            this.Relese_Year_c = relese;
            this.Page_Num_c = pnum;
            this.Author_c = author;
            this.Rented = rented;
        }
    }
}