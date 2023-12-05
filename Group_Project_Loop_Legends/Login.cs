﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class Login
    {
        static int TriesLeft = 3;
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
            if (TriesLeft == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nNo more login tries left. . .");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
            int y = 9;           
            Console.SetCursorPosition(0, y);
            Console.CursorVisible = false;
            Console.Write("-->");
            ConsoleKeyInfo navigator;            
            do
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
            } while (navigator.Key != ConsoleKey.Enter);

            Console.Clear();
            Console.CursorVisible = true;

            if (y == 9 && TriesLeft != 0) // Log in Admin
            {
                for (TriesLeft = 3; TriesLeft > 0;)
                {
                    Console.Clear();
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    Admin uCheck = adminList.Find(e => e._name == username);
                    
                    if (uCheck == null || uCheck._password != password)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid username or password. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        TriesLeft--;
                        Console.WriteLine($"{TriesLeft} tries left");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Login successful . . .");
                        Console.ForegroundColor = ConsoleColor.White;
                        TriesLeft = 3;
                        uCheck.Menu();
                        break;
                    }                                       
                }
            }
            else if (y == 10 && TriesLeft != 0) // Log in Customer
            {
                for (TriesLeft = 3; TriesLeft > 0;)
                {
                    Console.Clear();
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    Customer uCheck = customerList.Find(e => e._name == username);

                    if (uCheck == null || uCheck._password != password)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid username or password. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        TriesLeft--;
                        Console.WriteLine($"{TriesLeft} tries left");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Login successful . . .");
                        Console.ForegroundColor = ConsoleColor.White;
                        TriesLeft = 3;
                        uCheck.Menu(customerList);
                        break;
                    }

                }
            }
        }
    }
}
