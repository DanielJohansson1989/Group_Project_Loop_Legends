namespace Group_Project_Loop_Legends
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating base users for initial use
            List<Account> accountList = new List<Account>();
            List<string> historyList = new List<string>();
            Customer c1 = new Customer("Anton", "password", 0, accountList, historyList, 0);
            Customer c2 = new Customer("Daniel", "password", 0, accountList, historyList, 0);
            Customer c3 = new Customer("John", "password", 0, accountList, historyList, 0);
            Customer c4 = new Customer("Rasmus", "password", 0, accountList, historyList, 0);
            Admin a1 = new Admin("Pär", "password", 0);
        }
    }
}