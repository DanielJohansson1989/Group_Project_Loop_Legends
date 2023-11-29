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
                    AddAccount();
                    break;
                case 3:
                    //AccountHistory();
                    break;
                case 4:
                    TransferMoney(_accountList, _historyList);
                    break;
                case 5:
                    LoanMoney(_accountList);
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

            do
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
            } while (navigator.Key != ConsoleKey.Enter);
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
            Menu();
        }
        public void SeeAccounts()
        {
            Console.WriteLine("Kontonamn\t\tSaldo\tValuta\t\n");
            foreach (Account item in _accountList)
            {
                item.PrintAccounts();
            }
            Console.WriteLine("\nPress Enter to return to Menu");
            Console.ReadLine();
            Menu();
        }
        public void TransferMoney(List<Account> accounts, List<string> historyList)
        {
            Console.Clear();
            Console.WriteLine("     Transfer money between own accounts\n     Transfer money to extern accounts\n");
            int cursorPosition = 0;

            Console.SetCursorPosition(0, cursorPosition);
            Console.CursorVisible = false;
            Console.Write("-->");
            ConsoleKeyInfo navigator;

            do
            {
                navigator = Console.ReadKey();
                Console.SetCursorPosition(0, cursorPosition);
                Console.Write("   ");

                if (navigator.Key == ConsoleKey.UpArrow && cursorPosition > 0)
                {
                    cursorPosition--;
                }

                else if (navigator.Key == ConsoleKey.DownArrow && cursorPosition < 1)
                {
                    cursorPosition++;
                }

                Console.SetCursorPosition(0, cursorPosition);
                Console.Write("-->");
            } while (navigator.Key != ConsoleKey.Enter);
            Console.Clear();

            switch (cursorPosition)
            {
                case 0:   // Transfer between own accounts

                    // Selecting account to transfer from
                    Console.WriteLine("Select an account to transfer money FROM");
                    foreach (Account account in accounts)
                    {
                        Console.WriteLine($"     {account.AccountName}");
                    }
                    int fromAccountPosition = 1;

                    Console.SetCursorPosition(0, fromAccountPosition);
                    Console.CursorVisible = false;
                    Console.Write("-->");

                    do
                    {
                        navigator = Console.ReadKey();
                        Console.SetCursorPosition(0, fromAccountPosition);
                        Console.Write("   ");

                        if (navigator.Key == ConsoleKey.UpArrow && fromAccountPosition > 1)
                        {
                            fromAccountPosition--;
                        }

                        else if (navigator.Key == ConsoleKey.DownArrow && fromAccountPosition < accounts.Count)
                        {
                            fromAccountPosition++;
                        }

                        Console.SetCursorPosition(0, fromAccountPosition);
                        Console.Write("-->");
                    } while (navigator.Key != ConsoleKey.Enter);
                    Console.Clear();

                    // Selecting accounts to transfer to
                    Console.WriteLine("Select an account to transfer money TO");
                    foreach (Account account in accounts)
                    {
                        Console.WriteLine($"     {account.AccountName}");
                    }
                    int toAccountPosition = 1;

                    Console.SetCursorPosition(0, toAccountPosition);
                    Console.CursorVisible = false;
                    Console.Write("-->");

                    do
                    {
                        navigator = Console.ReadKey();
                        Console.SetCursorPosition(0, toAccountPosition);
                        Console.Write("   ");

                        if (navigator.Key == ConsoleKey.UpArrow && toAccountPosition > 1)
                        {
                            toAccountPosition--;
                        }

                        else if (navigator.Key == ConsoleKey.DownArrow && toAccountPosition < accounts.Count)
                        {
                            toAccountPosition++;
                        }

                        Console.SetCursorPosition(0, toAccountPosition);
                        Console.Write("-->");
                    } while (navigator.Key != ConsoleKey.Enter);
                    Console.Clear();

                    Console.WriteLine("How much money would you like to transfer?");
                    double amountToTransfer;

                    while (!double.TryParse(Console.ReadLine(), out amountToTransfer)) { Console.WriteLine("Incorrect value"); }

                    double amountInCorrectCurrency = CurrencyConverter.ConvertCurrency(accounts[fromAccountPosition - 1], accounts[toAccountPosition - 1], amountToTransfer);

                    accounts[fromAccountPosition - 1].Balance -= amountToTransfer; //OBS Stop user from wthdrawing more than available balance!!!
                    accounts[toAccountPosition - 1].Balance += amountInCorrectCurrency;

                    historyList.Add($"{amountToTransfer} {accounts[fromAccountPosition - 1].Currency} withdrawn from {accounts[fromAccountPosition - 1].AccountName}");
                    historyList.Add($"{amountInCorrectCurrency} {accounts[toAccountPosition - 1].Currency} deposited to {accounts[toAccountPosition - 1].AccountName}");
                    break;

                case 1: // Transfer between other users accounts
                    Console.WriteLine("Not implemented...\nPress any button to exit"); Console.ReadKey();
                    break;
            }
            Menu();
        }
        public static void LoanMoney(List<Account> accountList)
        {
            double totalAssetInSEK = CurrencyConverter.TotalAsset(accountList);
            Console.WriteLine($"Based on your total assets you can loan up to {(totalAssetInSEK/*-_credit... hur ska jag få in inloggad användares credit här*/) * 5} SEK");


            Console.ReadLine();
            // Must convert all assets on all accounts of the customer to base currency.
            // Create new method for this in CurrencyConverter class.
            // Then present how much SEK (only SEK?) they can loan (only 5 times of balance MINUS(!) credit something)
            // Then they can choose which account they want to put it it.
            // Then convert to the currency of that account and put the money into it.
            // Then add credit to the customer.
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
