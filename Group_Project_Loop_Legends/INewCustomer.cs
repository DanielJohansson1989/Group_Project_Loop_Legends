using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Group_Project_Loop_Legends
{
    internal interface INewCustomer
    {
        public static void CreateNewCustomer()
        {
            Console.WriteLine("Creating new customer . . .");
            Console.WriteLine("Customer name: ");
            string newCName = Console.ReadLine();
            Console.WriteLine("Customer password: ");
            string newCPass = Console.ReadLine();

            Customer c5 = new Customer(newCName, newCPass, 0);

            customerList.Add(c5);
        }
    }
}
