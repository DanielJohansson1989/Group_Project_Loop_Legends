using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class Customer : User
    {
        private List<Account> _accountList = new List<Account>();
        private List<string> _historyList = new List<string>();
        private double _credit = 0;
        public Customer(string _name, string _password) : base(_name, _password)
        {
        }
        public override void Menu()
        {
            Console.Clear();
            Console.WriteLine($"Welcome, {_name}! Choose an option:");
   
            Console.WriteLine("    1.See Your Accounts");
            Console.WriteLine("    2.Create New Account");
            Console.WriteLine("    3.Show Account History");
            Console.WriteLine("    4.Transfer Money");
            Console.WriteLine("    5.Loan Money");
            Console.WriteLine("    6.Log Out ");

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

                else if (navigator.Key == ConsoleKey.DownArrow && cursorPos < 6)
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
                    SeeAccounts();
                    break;
                case 2:
                    //CreateNewAccount();
                    break;
                case 3:
                    //AccountHistory();
                    break;
                case 4:
                    TransferMoney();
                    break;
                case 5:
                    //LoanMoney();
                    break;              
                case 6:
                    LogOut();
                    break;
                default:
                    throw new ArgumentException($"Menu option {cursorPos} not available");


            }

        }
        public void CreateNewAccount(Account newAccount)
        {
            _accountList.Add(newAccount);
        }
        public void AddAccount()
        {
            Console.Clear();
            Console.Write("Name of the account: ");
            string accountName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("What currency would you like your account to have?");
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

            string currency;
            switch (cursorPosition)
            {
                case 2:
                    currency = "SEK";
                    break;
                case 3:
                    currency = "USD";
                    break;
                case 4:
                    currency = "EURO";
                    break;
                case 5:
                    currency = "GBP";
                    break;
                case 6:
                    currency = "JPY";
                    break;
                default:
                    throw new ArgumentException($"Menu option {cursorPosition} not available");
            }

            Account newAccount = new Account(0, currency, accountName, _name);

            _accountList.Add(newAccount);
        }
        public void SeeAccounts()
        {
            Console.WriteLine("Kontonamn\t\tSaldo\tValuta\t\n");
            Console.ReadKey();
            foreach (Account item in _accountList)
            {
                item.PrintAccounts();
            }
        }
        public static void TransferMoney()
        {

        }
        public static void LoanMoney(List<Account> accountList)
        {
            
        }
        public static void LogOut() //Should we have a LogOut Method? // AH.
        {
            Console.WriteLine("Logging out...");
            Thread.Sleep(1500);
            Console.Clear();
            //Login.LogIn();
        }
    }
}
