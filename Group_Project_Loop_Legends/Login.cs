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
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreateInitialCustomers();
            Admin a1 = new Admin("Pär", "passwordP");
            Admin a2 = new Admin("Tobias", "passwordT");

            List<Admin> adminList = new List<Admin> { a1, a2 };
           

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

                    Customer uCheck = customerManager.CustomerLogin(username, password);

                    if (uCheck == null)
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
