using System;
using System.Text;

namespace bobliotek
{
    internal class biblo
    {
        static void Main()
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

                string check = File.ReadAllText(fullPath, Encoding.UTF8);
                string[] checkarr = check.Split(Environment.NewLine);
                for (int i = 0; i < checkarr.Length; i++)
                {
                    if (checkarr[i].Contains(username) && checkarr[i].Contains(password))
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
            else if (choise.ToLower() == "sign up");
            {
                bob();
            }

            static void bob(){
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

                        Main();
                    }
                    
                    else 
                    {
                        Main();
                    }
                }
            }

            static void biblioacc()
            {
                string fullPath = "C:\\Users\\isak.palsson1\\source\\repos\\boblioteka\\login.txt";
                string choise = null;
            }
        }
    }
}   