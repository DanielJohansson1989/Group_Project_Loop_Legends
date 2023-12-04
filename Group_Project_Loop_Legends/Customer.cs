using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
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
        public override void Menu(List<Customer> customerList)
        {
            bool isRunning = true;

            while (isRunning)
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
                        AccountHistory();
                        break;
                    case 4:
                        TransferMoney(customerList, _accountList, _historyList);
                        break;
                    case 5:
                        LoanMoney(_accountList, _credit, _historyList);
                        break;
                    case 6:
                        LogOut(); isRunning = false;
                        break;
                    default:
                        throw new ArgumentException($"Menu option {cursorPos} not available");


                }
            }
        }


        ///////////////////////////////// 1. See Your Accounts //////////////////////////////////////////////////////
        

        public void SeeAccounts()
        {
            Console.WriteLine("Kontonamn                Saldo          Valuta\n");
            foreach (Account item in _accountList)
            {
                item.PrintAccounts();
            }
            Console.WriteLine("\nPress Enter to return to Menu");
            Console.ReadLine();
        }



        ////////////////////////////////// 2. Create New Account /////////////////////////////////////////////////////


        public void AddAccount()
        {
            Console.Clear();
            Console.WriteLine("Name of the account (max 23 characters):");
            string accountName = Console.ReadLine();

            while (accountName.Length > 23 || accountName.Length < 1)
            {
                Console.WriteLine("Please Enter a name shorter than 24 characters and longer than zero characters");
                accountName = Console.ReadLine();
            }

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
        }


        ///////////////////////////////////////// 3. Show Account History ///////////////////////////////////////////


        public void AccountHistory()
        {
            Console.Clear();
            Console.WriteLine("SUM               ACTION          ACCOUNT\n");
            foreach (string transaction in _historyList)
            {
                Console.WriteLine(transaction);
            }
            Console.WriteLine("\nPress Enter to return to Menu");
            Console.ReadLine();
        }



        ////////////////////////////////////////// 4. Transfer Money ////////////////////////////////////////////////


        public void TransferMoney(List<Customer> customerList, List<Account> accounts, List<string> historyList)
        {
            // Prints menu of functionality 
            Console.Clear();
            Console.WriteLine("     Transfer money between own accounts\n     Transfer money to extern accounts\n");

            // Let user select an functionality
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
                case 0:   // Functionality: Transfer between own accounts

                    // Print menu of account to transfer from - only accounts with balance > 0 are visible
                    Console.WriteLine("Select an account to transfer money FROM");

                    List<Account> temporaryAccounts = new List<Account>();

                    foreach (Account account in accounts)
                    {
                        if (account.Balance > 0)
                        {
                            Console.WriteLine($"     {account.AccountName}");

                            // Put available accounts in a new list with correct index according to user selection
                            temporaryAccounts.Add(account);
                        }
                    }

                    // Return the user to customer meny if no accounts av balance > 0
                    if (temporaryAccounts.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You do not have any money! Returning to menu...");
                        Thread.Sleep(3000);
                        break;
                    }

                    // Let user select account from menu
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

                        else if (navigator.Key == ConsoleKey.DownArrow && fromAccountPosition < temporaryAccounts.Count)
                        {
                            fromAccountPosition++;
                        }

                        Console.SetCursorPosition(0, fromAccountPosition);
                        Console.Write("-->");
                    } while (navigator.Key != ConsoleKey.Enter);
                    Console.Clear();

                    // Print available accounts to transfer to
                    Console.WriteLine("Select an account to transfer money TO");
                    foreach (Account account in accounts)
                    {
                        Console.WriteLine($"     {account.AccountName}");
                    }

                    // Let user select an account
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

                    // Let user enter amount to transfer
                    double amountToTransfer;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("How much money would you like to transfer?");
                        while (!double.TryParse(Console.ReadLine(), out amountToTransfer))
                        {
                            Console.Clear();
                            Console.WriteLine("Incorrect value");
                            Thread.Sleep(1500);
                            Console.Clear();
                            Console.WriteLine("How much money would you like to transfer?");
                        }

                        // Check if there is enough balance in account to transfer from - Prints message if not
                        if (temporaryAccounts[fromAccountPosition - 1].Balance - amountToTransfer < 0)
                        {
                            Console.WriteLine("The amount exceeds current balance!\nPlease enter a lower amount");
                            Thread.Sleep(1500);
                        }

                    } while (temporaryAccounts[fromAccountPosition - 1].Balance - amountToTransfer < 0);

                    // Convert the amount to correct currency
                    double amountInCorrectCurrency = CurrencyConverter.ConvertCurrency(temporaryAccounts[fromAccountPosition - 1], accounts[toAccountPosition - 1], amountToTransfer);

                    // Find correct index on the account where money is withdrawn from
                    int fromAccountIndex = accounts.IndexOf(temporaryAccounts[fromAccountPosition - 1]);

                    // Do the actual transfer
                    accounts[fromAccountIndex].Balance -= amountToTransfer;
                    accounts[toAccountPosition - 1].Balance += amountInCorrectCurrency;


                    // historyList.Add($"SEK {wantLoan,-15:N2}" + "loaned into" + $"          {accountList[cursorPosition - 4].AccountName}");

                    // Saving transaction as history
                    historyList.Add($"{accounts[fromAccountIndex].Currency}{amountToTransfer, -15:N2}withdrawn from          {accounts[fromAccountIndex].AccountName}");
                    historyList.Add($"{accounts[toAccountPosition - 1].Currency} {amountInCorrectCurrency, -15:N2}deposited to          {accounts[toAccountPosition - 1].AccountName}");
                    break;

                case 1: // Transfer between other users accounts
                    // Print menu with available customers
                    Console.WriteLine("Select recipient");

                    foreach (Customer customer in customerList)
                    {
                        Console.WriteLine($"     {customer._name}");
                    }

                    // Let user select recipient/customer
                    cursorPosition = 1;
                    Console.SetCursorPosition(0, cursorPosition);
                    Console.CursorVisible = false;
                    Console.Write("-->");

                    do
                    {
                        navigator = Console.ReadKey();
                        Console.SetCursorPosition(0, cursorPosition);
                        Console.Write("   ");

                        if (navigator.Key == ConsoleKey.UpArrow && cursorPosition > 1)
                        {
                            cursorPosition--;
                        }

                        else if (navigator.Key == ConsoleKey.DownArrow && cursorPosition < customerList.Count)
                        {
                            cursorPosition++;
                        }

                        Console.SetCursorPosition(0, cursorPosition);
                        Console.Write("-->");
                    } while (navigator.Key != ConsoleKey.Enter);
                    Console.Clear();

                    // Print menu of this users account to transfer from - only accounts with balance > 0 are visible
                    Console.WriteLine("Select an account to transfer money FROM");

                    temporaryAccounts = new List<Account>();

                    foreach (Account account in accounts)
                    {
                        if (account.Balance > 0)
                        {
                            Console.WriteLine($"     {account.AccountName}");

                            // Put available accounts in a new list with correct index according to user selection
                            temporaryAccounts.Add(account);
                        }
                    }

                    // Return the user to customer meny if no accounts av balance > 0
                    if (temporaryAccounts.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You do not have any money! Returning to menu...");
                        Thread.Sleep(2000);
                        break;
                    }

                    // Let user select account from menu
                    fromAccountPosition = 1;
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

                        else if (navigator.Key == ConsoleKey.DownArrow && fromAccountPosition < temporaryAccounts.Count)
                        {
                            fromAccountPosition++;
                        }

                        Console.SetCursorPosition(0, fromAccountPosition);
                        Console.Write("-->");
                    } while (navigator.Key != ConsoleKey.Enter);
                    Console.Clear();

                    // Print recipient's available accounts
                    Console.WriteLine("Select an account to transfer money TO");
                    foreach (Account account in customerList[cursorPosition - 1]._accountList)
                    {
                        Console.WriteLine($"     {account.AccountName}");
                    }

                    // Let user select an account
                    toAccountPosition = 1;
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

                        else if (navigator.Key == ConsoleKey.DownArrow && toAccountPosition < customerList[cursorPosition - 1]._accountList.Count)
                        {
                            toAccountPosition++;
                        }

                        Console.SetCursorPosition(0, toAccountPosition);
                        Console.Write("-->");
                    } while (navigator.Key != ConsoleKey.Enter);

                    // Let user enter amount to transfer
                    // double amountToTransfer; // This is declared in case 0
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("How much money would you like to transfer?");
                        while (!double.TryParse(Console.ReadLine(), out amountToTransfer))
                        {
                            Console.Clear();
                            Console.WriteLine("Incorrect value");
                            Thread.Sleep(1500);
                            Console.Clear();
                            Console.WriteLine("How much money would you like to transfer?");
                        }

                        // Check if there is enough balance in account to transfer from - Prints message if not
                        if (temporaryAccounts[fromAccountPosition - 1].Balance - amountToTransfer < 0)
                        {
                            Console.WriteLine("The amount exceeds current balance!\nPlease enter a lower amount");
                            Thread.Sleep(1500);
                        }

                    } while (temporaryAccounts[fromAccountPosition - 1].Balance - amountToTransfer < 0);

                    // Convert the amount to correct currency
                    amountInCorrectCurrency = CurrencyConverter.ConvertCurrency(temporaryAccounts[fromAccountPosition - 1], customerList[cursorPosition - 1]._accountList[toAccountPosition - 1], amountToTransfer);

                    // Find correct index on the account where money is withdrawn from
                    fromAccountIndex = accounts.IndexOf(temporaryAccounts[fromAccountPosition - 1]);

                    // Do the actual transfer
                    accounts[fromAccountIndex].Balance -= amountToTransfer;
                    customerList[cursorPosition - 1]._accountList[toAccountPosition - 1].Balance += amountInCorrectCurrency;

                    // Saving transaction as history
                    historyList.Add($"{amountToTransfer} {accounts[fromAccountIndex].Currency} withdrawn from {accounts[fromAccountIndex].AccountName}");
                    historyList.Add($"{amountInCorrectCurrency} {customerList[cursorPosition - 1]._accountList[toAccountPosition - 1].Currency} deposited to {customerList[cursorPosition - 1]._accountList[toAccountPosition - 1].AccountName}");

                    break;
            }
        }


        ////////////////////////////////////////////// 5. Loan Money //////////////////////////////////////////////
        
        
        public void LoanMoney(List<Account> accountList, double credit, List<string> historyList)
        {
            Console.CursorVisible = true;
            ConsoleKeyInfo navigator;
            double wantLoan = 0;
            double totalAssetInSEK = CurrencyConverter.TotalAsset(accountList);
            double maxLoan = (totalAssetInSEK - credit) * 5 - credit;

            if(maxLoan > 1)
            {
                Console.WriteLine($"Based on your total assets ({totalAssetInSEK:N2} SEK) and your credit ({credit} SEK) you can loan up to {maxLoan:N2} SEK.");

                while (true)
                {
                    Console.Write("\nHow much do you want to loan? ");
                    try
                    {
                        wantLoan = Convert.ToDouble(Console.ReadLine());
                        if(wantLoan > 0)
                            break;
                        else
                            Console.WriteLine("You can not loan a negative amount.");
                    }
                    catch
                    {
                        Console.WriteLine("\nInvalid input. Try again.");
                    }
                }
                while (wantLoan > maxLoan)
                {
                    Console.WriteLine("\nYou can not loan that much.");
                    Console.Write("Request a lower amount: ");
                    try
                    {
                        wantLoan = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input. Try again.\n");
                    }
                }

                Console.Clear();
                Console.WriteLine($"We currently have an interest rate of 4,9%. There will be a yearly fee of {wantLoan * 0.049:N2} SEK for your loan.\n");
                Console.WriteLine("To which account do you want to insert the loan?\n");

                foreach (Account account in accountList) // Possible improvement: also print out the balance and currency of the accounts
                {
                    Console.WriteLine($"     {account.AccountName}");
                }
                int cursorPosition = 4;

                Console.SetCursorPosition(0, cursorPosition);
                Console.CursorVisible = false;
                Console.Write("-->");

                do
                {
                    navigator = Console.ReadKey();
                    Console.SetCursorPosition(0, cursorPosition);
                    Console.Write("   ");

                    if (navigator.Key == ConsoleKey.UpArrow && cursorPosition > 4)
                    {
                        cursorPosition--;
                    }

                    else if (navigator.Key == ConsoleKey.DownArrow && cursorPosition < accountList.Count + 3)
                    {
                        cursorPosition++;
                    }

                    Console.SetCursorPosition(0, cursorPosition);
                    Console.Write("-->");
                } while (navigator.Key != ConsoleKey.Enter);

                Console.Clear();
                Credit += wantLoan;
                Account bankLoan = new Account(wantLoan, "SEK", "bankLoanTempAccount", "Loop Legends Bank"); // Had to create a new account to use the ConvertCurrency method.

                double balanceBeforeLoan = accountList[cursorPosition - 4].Balance;
                accountList[cursorPosition - 4].Balance += CurrencyConverter.ConvertCurrency(bankLoan, accountList[cursorPosition - 4], wantLoan); ;

                historyList.Add($"SEK {wantLoan, -15:N2}loaned into          {accountList[cursorPosition - 4].AccountName}");
                
                Console.WriteLine($"You have now loaned {wantLoan} SEK and inserted it into {accountList[cursorPosition - 4].AccountName}");
                Console.WriteLine($"\nBalance before loan: {balanceBeforeLoan} {accountList[cursorPosition - 4].Currency}");
                Console.WriteLine($"Balance after loan : {accountList[cursorPosition - 4].Balance:N2} {accountList[cursorPosition - 4].Currency}");

            }
            else
            {
                Console.WriteLine("We're sorry to inform you that you can not loan money from us. Either you have 0 total assets with us, or you've already loaned up to the maximum amount.");
            }

            Console.WriteLine("\nPress Enter to return to Menu.");
            Console.ReadLine();
        }


        //////////////////////////////////////////// 6. Log Out /////////////////////////////////////////////////


        public static void LogOut()
        {
            Console.WriteLine("Logging out...");
            Thread.Sleep(1500);
            Console.Clear();
            //Login.LogIn();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public void CreateNewAccount(Account newAccount)
        {
            _accountList.Add(newAccount);
        }
        public double Credit
        {
            get { return _credit; }
            set { _credit = value; }
        }
    }
}
