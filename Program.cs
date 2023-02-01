using System;
using System.Text;

namespace bobliotek
{
    internal class biblo
    {
        static void Main()
        {

            start();

            static void start()
            {

                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";
                
                Console.WriteLine("If you already have an account, Please write 'login'! To sign up write 'Sign up'!");
                string choise = Console.ReadLine();
                if (choise.ToLower() == "login")
                {
                    bool login = false;
                    Console.WriteLine("To log-in please write, Username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Pasword:");
                    string password = Console.ReadLine();

                    string[] check = File.ReadAllLines(fullPath, Encoding.UTF8);
                    for (int i = 0; i < check.Length; i++)
                    {
                        if (check[i].Contains(username.ToLower()) && check[i].Contains(password.ToLower()) && check[i].Any(x => !char.IsLetter(x)));
                        {
                            Console.WriteLine("You have been logged in!");
                            login = true;
                        }
                    }

                    if (login == false)
                    {
                        Console.WriteLine("wrong Username or pasword!");
                    }

                    if (login == true)
                    {
                        biblioacc();
                    }
                }
                else if (choise.ToLower() == "sign up") ;
                {
                    reg();
                }
            }

            static void reg(){
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";

                bool loop = true;
                while (loop == true)
                {
                    string choise = null;
                    Console.WriteLine("Do you want to sign up? Y/N");
                    choise = Console.ReadLine();

                    if (choise.ToLower() == "y")
                    {
                        Console.WriteLine("Choose a Username:   ");
                        string Username = Console.ReadLine();
                        Console.WriteLine("Choose a Pasword:   ");
                        string Pasword = Console.ReadLine();
                        Console.WriteLine("Personal number:   ");
                        string pn = Console.ReadLine();

                        string apend = Username + " " + Pasword + " " + pn;
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

            static void biblioacc()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";
                string choise = null;
                Console.WriteLine("Do you want to search for a book, ('search') or add a book, ('add') or do you want to see all books?, ('view'), or logout('logout')");
                choise = Console.ReadLine();

                if (choise.ToLower() == "search")
                {
                    search();
                }

                if (choise.ToLower() == "add")
                {
                    add();
                }

                if (choise.ToLower() == "view")
                {
                    view();
                }

                if (choise.ToLower() == "logout")
                {
                    logout();
                }
            }

            static void logout()
            {
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

            static void search()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";

                Console.WriteLine("What do you want to search for?: Author?('author'), Book Name?('name')?...   ");
                string searchres = Console.ReadLine();
                string[] Books = File.ReadAllLines(fullPath);
                List<string> list = new List<string>();
                List<string> list1 = new List<string>();

                foreach (string Book in Books)
                {
                    string[] auth = Book.Split("!");
                    
                    list.Add(auth[3]);
                    list.Add(auth[0]);

                }
                string[] Authors = list.ToArray();
                string[] Names = list1.ToArray();

                if (searchres.ToLower() == "author")
                {

                }
                else if (searchres.ToLower() == "name")
                {

                }
                else
                {
                    search();
                }
            }

            static void add()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";

                Console.WriteLine("Book Name?:  ");
                string Book_Name = Console.ReadLine();
                Console.WriteLine("Year Releesed?:  ");
                string Relese_Year = Console.ReadLine();
                Console.WriteLine("Page Number?:  ");
                string Page_Num = Console.ReadLine();
                Console.WriteLine("Author?: ");
                string Author =Console.ReadLine();

                string apend = Book_Name + "!" + Relese_Year + "!" + Page_Num + "!" + Author;
                string[] lines = { apend };

                File.AppendAllLines(fullPath, lines);

                biblioacc();
            }

            static void view()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\books.txt";

                string[] Books = File.ReadAllLines(fullPath);
                Console.WriteLine(Books);

                int i = 0;

                foreach (string Book in Books)
                {
                    string[] Info = Book.Split("!");
                    string Book_Name = Info[0];
                    string Relese_Year = Info[1];
                    string Page_Num = Info[2];
                    string Author = Info[3];

                    Book_class obj = new Book_class(Info[0], Info[1], Info[2], Info[3]);

                    Console.WriteLine($"[{i}]\nName: {obj.Book_Name_c}\nRelese Year: {obj.Relese_Year_c}\nNumber of Pages: {obj.Page_Num_c}\nAuthor: {obj.Author_c}\n");
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

        public Book_class(string name, string relese, string pnum, string author)
        {
            this.Book_Name_c = name;
            this.Relese_Year_c = relese;
            this.Page_Num_c = pnum;
            this.Author_c = author;
        }


    }
}