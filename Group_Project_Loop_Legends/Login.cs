using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class Login
    {
        public static void LogIn(List<Customer> customerList, List<Admin> adminList) // Make LogIn its own class instead of method in User? S in SOLID principles
        {
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

            }
            else if (y == 5) // Log in Customer
            {

            }
        }
    }
}
