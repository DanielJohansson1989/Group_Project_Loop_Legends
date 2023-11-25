using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class User
    {
        private string _name;
        private string _password;
        private int _logInTries;
        // private string _loggedInUser; // Include or not? / JP
        public User(string name, string password, int logInTries)
        {
            this._name = name;
            this._password = password;
            this._logInTries = logInTries;
        }
        public static void LogIn()
        {

        }

        public virtual void Menu()
        {

        }
    }
}
