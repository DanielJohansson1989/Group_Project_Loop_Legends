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
        private List<Account> _accountList;
        private List<string> _historyList;
        private double _credit;
        public Customer(string _name, string _password, int _logInTries, List<Account> accountList, List<string> historyList, double credit) : base(_name, _password, _logInTries)
        {
            this._accountList = accountList;
            this._historyList = historyList;
            this._credit = credit;
        }
        public override void Menu()
        {
            
        }
        public static void CreateNewAccount()
        {

        }
        public static void TransferMoney()
        {

        }
        public static void LoanMoney(List<Account> accountList)
        {
            
        }
    }
}
