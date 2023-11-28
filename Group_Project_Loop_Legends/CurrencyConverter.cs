using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class CurrencyConverter
    {
        private static double _sekRate = 1;
        private static double _usdRate = 0.096;
        private static double _euroRate = 0.088;
        private static double _gbpRate = 0.076;
        private static double _jpyRate = 14.31;

        public static void ConvertCurrency(Account account)
        {
            double baseValue = 0;

            switch (account.Currency)
            {
                case "SEK":
                    baseValue = account.Balance / _sekRate;
                    break;
                case "USD":
                    baseValue = account.Balance / _usdRate;
                    break;
                case "EURO":
                    baseValue = account.Balance / _euroRate;
                    break;
                case "GBP":
                    baseValue = account.Balance / _gbpRate;
                    break;
                case "JPY":
                    baseValue = account.Balance / _jpyRate;
                    break;
                default:
                    throw new ArgumentException($"Unsupported currency: {account.Currency}");
            }

            Console.Clear();
            Console.WriteLine("What currency would you like to convert to?");
            Console.WriteLine("\n     SEK\n     USD\n     EURO\n     GBP\n     JPY\n");

            int cursorPosition = 2;

            Console.SetCursorPosition(0, cursorPosition);
            Console.CursorVisible = false;
            Console.Write("-->");
            ConsoleKeyInfo navigator;
            navigator = Console.ReadKey();

            while (navigator.Key != ConsoleKey.Enter)
            {
                navigator = Console.ReadKey();
                Console.SetCursorPosition(0, cursorPosition);
                Console.Write("   ");

                if (navigator.Key == ConsoleKey.UpArrow && cursorPosition > 2)
                {
                    cursorPosition--;
                }

                else if (navigator.Key == ConsoleKey.DownArrow && cursorPosition < 6)
                {
                    cursorPosition++;
                }

                Console.SetCursorPosition(0, cursorPosition);
                Console.Write("-->");
            }

            Console.Clear();

            switch (cursorPosition)  // Not certain if this method should return a value or balance should be set inside method. /DJ
            {
                case 2:
                    account.Currency = "SEK";
                    /*return*/
                    account.Balance = baseValue * _sekRate;
                    break;
                case 3:
                    account.Currency = "USD";
                    /*return*/
                    account.Balance = baseValue * _usdRate;
                    break;
                case 4:
                    account.Currency = "EURO";
                    /*return*/
                    account.Balance = baseValue * _euroRate;
                    break;
                case 5:
                    account.Currency = "GBP";
                    /*return*/
                    account.Balance = baseValue * _gbpRate;
                    break;
                case 6:
                    account.Currency = "JPY";
                    /*return*/
                    account.Balance = baseValue * _jpyRate;
                    break;
                default:
                    throw new ArgumentException($"Menu option {cursorPosition} not available");
            }
        }
        public static double ConvertCurrency(Account currentAccount, Account receivingAccount, double amount)
        {
            double baseValue = 0;

            switch (currentAccount.Currency)
            {
                case "SEK":
                    baseValue = amount / _sekRate;
                    break;
                case "USD":
                    baseValue = amount / _usdRate;
                    break;
                case "EURO":
                    baseValue = amount / _euroRate;
                    break;
                case "GBP":
                    baseValue = amount / _gbpRate;
                    break;
                case "JPY":
                    baseValue = amount / _jpyRate;
                    break;
                default:
                    throw new ArgumentException($"Unsupported currency: {currentAccount.Currency}");
            }

            switch (receivingAccount.Currency)
            {
                case "SEK":
                    return baseValue * _sekRate;

                case "USD":
                    return baseValue * _usdRate;

                case "EURO":
                    return baseValue * _euroRate;

                case "GBP":
                    return baseValue * _gbpRate;

                case "JPY":
                    return baseValue * _jpyRate;

                default:
                    throw new ArgumentException($"Unsupported currency: {receivingAccount.Currency}");
            }
        }
        public static double TotalAsset(List<Account> accountList)
        {
            double totalAssetValue = 0;

            foreach (Account item in accountList)
            {
                switch (item.Currency)
                {
                    case "SEK":
                        totalAssetValue +=  item.Balance / _sekRate;
                        break;

                    case "USD":
                        totalAssetValue += item.Balance / _usdRate;
                        break;

                    case "EURO":
                        totalAssetValue += item.Balance / _euroRate;
                        break;

                    case "GBP":
                        totalAssetValue += item.Balance / _gbpRate;
                        break;

                    case "JPY":
                        totalAssetValue += item.Balance / _jpyRate;
                        break;

                    default:
                        // Throw new exception something "no valid currency admitted".
                        break;
                }
            }
            return totalAssetValue * _sekRate;
        }
        public double SEKRate
        {
            get { return _sekRate; }
            set { _sekRate = value;  }
        }
        public double USDRate
        {
            get { return _usdRate; }
            set { _usdRate = value;  }
        }
        public double EuroRate
        {
            get { return _euroRate; }
            set { _euroRate = value;  }
        }
        public double GBPRate
        {
            get { return _gbpRate; }
            set { _gbpRate = value;  }
        }
        public double JPYRate
        {
            get { return _jpyRate; }
            set { _jpyRate = value;  }
        }
    }
}
