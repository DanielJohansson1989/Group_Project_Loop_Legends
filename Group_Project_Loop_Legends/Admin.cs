using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class Admin : User
    {
        public Admin(string _name, string _password) : base(_name, _password)
        {
            
        }     
        public override void Menu()
        {
            Console.Clear();
            Console.WriteLine($"Welcome, {_name}! Choose an option:");
            Console.WriteLine("    1.Set New Currency");
            Console.WriteLine("    2.Create New Customer");
            Console.WriteLine("    3.Log Out");

            int cursorPos = 1;

            Console.SetCursorPosition(0, cursorPos);
            Console.CursorVisible = false;
            Console.Write("-->");
            ConsoleKeyInfo navigator;
            navigator = Console.ReadKey();

            while (navigator.Key != ConsoleKey.Enter)
            {
                navigator = Console.ReadKey();
                Console.SetCursorPosition(0, cursorPos);
                Console.Write("   ");

                if (navigator.Key == ConsoleKey.UpArrow && cursorPos > 1)
                {
                    cursorPos--;
                }

                else if (navigator.Key == ConsoleKey.DownArrow && cursorPos < 3)
                {
                    cursorPos++;
                }

                Console.SetCursorPosition(0, cursorPos);
                Console.Write("-->");
            }

            Console.Clear();
            switch (cursorPos)
            {
                case 1:
                    SetNewCurrency();
                    break;
                case 2:
                    UserManager.AddCustomer("Name", "password");
                    break;
                case 3:
                    LogOut();
                    break;
            }


        }
        public void SetNewCurrency()
        {
            Console.WriteLine("Enter the currency to update: SEK, USD, EURO, GBP, or JPY");
            Console.Write(": ");
            string currency = Console.ReadLine().ToUpper(); 

            double currentRate = 0.0; 
            switch (currency)
            {
                case "SEK":
                    currentRate = CurrencyConverter._sekRate;
                    break;
                case "USD":
                    currentRate = CurrencyConverter._usdRate;
                    break;
                case "EURO":
                    currentRate = CurrencyConverter._euroRate;
                    break;
                case "GBP":
                    currentRate = CurrencyConverter._gbpRate;
                    break;
                case "JPY":
                    currentRate = CurrencyConverter._jpyRate;
                    break;
                default:
                    Console.WriteLine($"Currency not supported: {currency}");
                    Console.WriteLine("\nPress Enter to return to the menu");
                    Console.ReadKey();
                    Menu();
                    return;
            }

            Console.WriteLine($"\nCurrent exchange rate for {currency}: {currentRate}");
            Console.WriteLine("\nEnter the new exchange rate");
            Console.Write(": ");

            double newRate;
            while (!double.TryParse(Console.ReadLine(), out newRate))
            {
                Console.WriteLine("Invalid input. Please enter a valid number for the new rate:");
            }

            switch (currency)
            {
                case "SEK":
                    CurrencyConverter._sekRate = newRate;
                    break;
                case "USD":
                    CurrencyConverter._usdRate = newRate;
                    break;
                case "EURO":
                    CurrencyConverter._euroRate = newRate;
                    break;
                case "GBP":
                    CurrencyConverter._gbpRate = newRate;
                    break;
                case "JPY":
                    CurrencyConverter._jpyRate = newRate;
                    break;
            }

            Console.WriteLine($"\nExchange rate for {currency} has been updated from {currentRate} to {newRate}");
            Console.WriteLine("\nPress Enter to return to the menu");
            Console.ReadKey();
            Menu();
        }

        public static void LogOut()
        {
            Console.WriteLine("Logging out...");
            Thread.Sleep(1500);
            Console.Clear();
        }
    }
}
