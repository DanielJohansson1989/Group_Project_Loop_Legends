using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class Customer : User
    {
        private List<Account> _accountList = new List<Account>();
        private List<string> _historyList = new List<string>();
        private double _credit = 0;
        public Customer(string _name, string _password, int _logInTries) : base(_name, _password, _logInTries)
        {
        }
        public override void Menu()
        {
            
        }
        public void CreateNewAccount(Account newAccount)
        {
            _accountList.Add(newAccount);
        }
        public void SeeAccounts()
        {
            Console.WriteLine("Kontonamn\t\tSaldo\tValuta\t\n");
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
    }
}
