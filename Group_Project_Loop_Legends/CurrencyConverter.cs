using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class CurrencyConverter
    {
        private static double _sEK = 1;
        private static double _uSD = 0.096;
        private static double _eURO = 0.088;
        private static double _gBP = 0.076;
        private static double _jPY = 14.31;

        public static double ConvertCurrency(Account account)
        {
            double baseValue = 0;

            switch (account.Currency)
            {
                case "SEK":
                    baseValue = account.Balance * _sEK;
                    break;
                case "USD":
                    baseValue = account.Balance * _uSD;
                    break;
                case "EURO":
                    baseValue = account.Balance * _eURO;
                    break;
                case "GBP":
                    baseValue = account.Balance * _gBP;
                    break;
                case "JPY":
                    baseValue = account.Balance * _jPY;
                    break;
                default:
                    throw new ArgumentException($"Unsupported currency: {account.Currency}");
            }
            Console.Clear();
            Console.WriteLine("What currency would you like to convert to?");
            Console.WriteLine("\n     SEK\n     USD\n     EURO\n     GBP\n     JPY\n");
            int y = 2;
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
                if (navigator.Key == ConsoleKey.UpArrow && y > 2)
                {
                    y--;
                }
                else if (navigator.Key == ConsoleKey.DownArrow && y < 6)
                {
                    y++;
                }
                Console.SetCursorPosition(0, y);
                Console.Write("-->");
            }

            Console.Clear();

            switch (y)
            {
                case 2:
                    Console.WriteLine("SEK");
                    return baseValue * _sEK;
                    
                case 3:
                    Console.WriteLine("USD");
                    return baseValue * _uSD;
                    
                case 4:
                    Console.WriteLine("Euro");
                    return baseValue * _eURO;
                    
                case 5:
                    Console.WriteLine("GBP");
                    return baseValue * _gBP;
                    
                case 6:
                    Console.WriteLine("JPY");
                    return baseValue * _jPY;

                default:
                    throw new ArgumentException($"Menu option {y} not available");
            }
        }

        public static double ConvertCurrency(Account transferFrom, Account transferTo)
        {
            double baseValue = 0;

            switch (transferFrom.Currency)
            {
                case "SEK":
                    baseValue = transferFrom.Balance * _sEK;
                    break;
                case "USD":
                    baseValue = transferFrom.Balance * _uSD;
                    break;
                case "EURO":
                    baseValue = transferFrom.Balance * _eURO;
                    break;
                case "GBP":
                    baseValue = transferFrom.Balance * _gBP;
                    break;
                case "JPY":
                    baseValue = transferFrom.Balance * _jPY;
                    break;
                default:
                    throw new ArgumentException($"Unsupported currency: {transferFrom.Currency}");
            }
            
            switch (transferTo.Currency)
            {
                case "SEK":
                    return baseValue * _sEK;
              
                case "USD":
                    return baseValue * _uSD;
                    
                case "EURO":
                    return baseValue * _eURO;
                    
                case "GBP":
                    return baseValue * _gBP;
                    
                case "JPY":
                    return baseValue * _jPY;

                default:
                    throw new ArgumentException($"Unsupported currency: {transferTo.Currency}");
            }
        }
        public double SEK
        {
            get { return _sEK; }
            set { _sEK = value;  }
        }
        public double USD
        {
            get { return _uSD; }
            set { _uSD = value;  }
        }
        public double EURO
        {
            get { return _eURO; }
            set { _eURO = value;  }
        }
        public double GBP
        {
            get { return _gBP; }
            set { _gBP = value;  }
        }
        public double JPY
        {
            get { return _jPY; }
            set { _jPY = value;  }
        }
    }
}
