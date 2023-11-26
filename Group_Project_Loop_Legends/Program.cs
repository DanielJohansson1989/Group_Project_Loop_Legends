namespace Group_Project_Loop_Legends
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating base users and accounts for initial use and testing
            Customer c1 = new Customer("Anton", "passwordA", 0);
            Customer c2 = new Customer("Daniel", "passwordD", 0);
            Customer c3 = new Customer("John", "passwordJ", 0);
            Customer c4 = new Customer("Rasmus", "passwordR", 0);

            List<Customer> customerList = new List<Customer>() { c1, c2, c3, c4};

            Admin a1 = new Admin("Pär", "passwordP", 0);
            Admin a2 = new Admin("Tobias", "passwordT", 0);

            List<Admin> adminList = new List<Admin> { a1, a2 };

            Account c1a1 = new Account(3000, "SEK", "Antons Lönekonto", "Anton");
            Account c1a2 = new Account(50000, "USD", "Antons Sparkonto", "Anton");

            c1.CreateNewAccount(c1a1);
            c1.CreateNewAccount(c1a2);

            User.LogIn(customerList, adminList);

            Console.ReadLine();
        }
    }
}