using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class Login
    {
        public static void LogIn() // Make LogIn its own class instead of method in User? S in SOLID principles
        {
            ///////////////////////////////////////////////
            // Creating base users and accounts for initial use and testing
            Customer c1 = new Customer("Anton", "passwordA", 0);
            Customer c2 = new Customer("Daniel", "passwordD", 0);
            Customer c3 = new Customer("John", "passwordJ", 0);
            Customer c4 = new Customer("Rasmus", "passwordR", 0);

            List<Customer> customerList = new List<Customer>() { c1, c2, c3, c4 };

            Admin a1 = new Admin("Pär", "passwordP", 0);
            Admin a2 = new Admin("Tobias", "passwordT", 0);

            List<Admin> adminList = new List<Admin> { a1, a2 };

            Account c1a1 = new Account(3000, "SEK", "Antons Lönekonto", "Anton");
            Account c1a2 = new Account(50000, "USD", "Antons Sparkonto", "Anton");

            c1.CreateNewAccount(c1a1);
            c1.CreateNewAccount(c1a2);

            Account c2a1 = new Account(1000000, "SEK", "Daniels Lönekonto", "Daniel");
            Account c2a2 = new Account(40, "GBP", "Daniels Sparkonto", "Daniel");

            c2.CreateNewAccount(c2a1);
            c2.CreateNewAccount(c2a2);

            Account c3a1 = new Account(300000, "SEK", "Rasmus Lönekonto", "Rasmus");
            Account c3a2 = new Account(400, "JPY", "Rasmus Sparkonto", "Rasmus");

            c2.CreateNewAccount(c3a1);
            c2.CreateNewAccount(c3a2);

            Account c4a1 = new Account(1500000, "SEK", "Johns Lönekonto", "John");
            Account c4a2 = new Account(6000, "USD", "Johns Sparkonto", "John");

            c2.CreateNewAccount(c4a1);
            c2.CreateNewAccount(c4a2);
            /////////////////////////////////////////////////

            Console.Clear();
            Console.WriteLine("Welcome to the Loop Legends Bank\n");
            Console.WriteLine("What would you like to log in as? (user arrow keys to navigate, then press Enter)");
            Console.WriteLine("\n     Admin\n     Customer");
            int y = 4;
            Console.SetCursorPosition(0, y);
            Console.CursorVisible = false;
            Console.Write("-->");
            ConsoleKeyInfo navigator;
            navigator = Console.ReadKey();
            while (navigator.Key != ConsoleKey.Enter)
            {
                navigator = Console.ReadKey();
                Console.SetCursorPosition(0, y);
                Console.Write("   ");
                if (navigator.Key == ConsoleKey.UpArrow && y > 4)
                {
                    y--;
                }
                else if (navigator.Key == ConsoleKey.DownArrow && y < 5)
                {
                    y++;
                }
                Console.SetCursorPosition(0, y);
                Console.Write("-->");
            }

            Console.Clear();
            Console.CursorVisible = true;

            if (y == 4) // Log in Admin
            {
                for (int i = 3; i > 0;)
                {
                    Console.Clear();
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    Admin uCheck = adminList.Find(e => e._name == username);
                    
                    if (uCheck == null || uCheck._password != password)
                    {
                        Console.WriteLine("Invalid username or password. Please try again.");
                        i--;
                        Console.WriteLine($"{i} tries left");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Login successful . . .");
                        uCheck.Menu();
                        break;
                    }                                       
                }
            }
            else if (y == 5) // Log in Customer
            {
                for (int i = 3; i > 0;)
                {
                    Console.Clear();
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    Customer uCheck = customerList.Find(e => e._name == username);

                    if (uCheck == null || uCheck._password != password)
                    {
                        Console.WriteLine("Username and password did not match . . .");
                        i--;
                        Console.WriteLine($"{i} tries left");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Login successful . . .");
                        uCheck.Menu();
                        break;
                    }
                    
                }
            }
        }
    }
}
