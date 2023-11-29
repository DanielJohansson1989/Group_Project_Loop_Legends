using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class Login
    {
        public static void LogIn(List<Customer> customerList, List<Admin> adminList)
        {
            Console.Clear();
            Console.WriteLine("   __   ____  ____  ___    __   ______________  _____  ____  ___  ___   _  ____ __\r" +
                "\n  / /  / __ \\/ __ \\/ _ \\  / /  / __/ ___/ __/ |/ / _ \\/ __/ / _ )/ _ | / |/ / //_/\r" +
                "\n / /__/ /_/ / /_/ / ___/ / /__/ _// (_ / _//    / // /\\ \\  / _  / __ |/    / ,<   \r" +
                "\n/____/\\____/\\____/_/    /____/___/\\___/___/_/|_/____/___/ /____/_/ |_/_/|_/_/|_|  \r" +
                "\n                                                                                 ");
            Console.WriteLine("Welcome to the Loop Legends Bank\n");
            Console.WriteLine("What would you like to log in as? (user arrow keys to navigate, then press Enter)");
            Console.WriteLine("\n     Admin\n     Customer");
            int y = 9;
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
                if (navigator.Key == ConsoleKey.UpArrow && y > 9)
                {
                    y--;
                }
                else if (navigator.Key == ConsoleKey.DownArrow && y < 10)
                {
                    y++;
                }
                Console.SetCursorPosition(0, y);
                Console.Write("-->");
            }

            Console.Clear();
            Console.CursorVisible = true;

            if (y == 9) // Log in Admin
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
            else if (y == 10) // Log in Customer
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
        }
    }
}
