﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal class CustomerManager
    {
        List<Customer> customerList { get; } = new List<Customer>();

        public void CreateInitialCustomers ()
        {
            Customer c1 = new Customer("Anton", "passwordA");
            Customer c2 = new Customer("Daniel", "passwordD");
            Customer c3 = new Customer("John", "passwordJ");
            Customer c4 = new Customer("Rasmus", "passwordR");

            customerList.Add(c1);
            customerList.Add(c2);
            customerList.Add(c3);
            customerList.Add(c4);

            Account c1a1 = new Account(3000, "SEK", "Antons Lönekonto", "Anton");
            Account c1a2 = new Account(50000, "USD", "Antons Sparkonto", "Anton");

            c1.CreateNewAccount(c1a1);
            c1.CreateNewAccount(c1a2);

            Account c2a1 = new Account(1000000, "SEK", "Daniels Lönekonto", "Daniel");
            Account c2a2 = new Account(40, "GBP", "Daniels Sparkonto", "Daniel");

            c2.CreateNewAccount(c2a1);
            c2.CreateNewAccount(c2a2);

            Account c3a1 = new Account(1500000, "SEK", "Johns Lönekonto", "John");
            Account c3a2 = new Account(6000, "USD", "Johns Sparkonto", "John");

            c3.CreateNewAccount(c3a1);
            c3.CreateNewAccount(c3a2);

            Account c4a1 = new Account(300000, "SEK", "Rasmus Lönekonto", "Rasmus");
            Account c4a2 = new Account(400, "JPY", "Rasmus Sparkonto", "Rasmus");

            c4.CreateNewAccount(c4a1);
            c4.CreateNewAccount(c4a2);
        }
        public void AddCustomer()
        {

        }

        public Customer CustomerLogin(string username, string password)
        {
            return customerList.Find(e => e._name == username && e._password == password);

            
        }
    }
}