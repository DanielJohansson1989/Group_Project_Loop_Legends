namespace Group_Project_Loop_Legends
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating base users and accounts for initial use and testing
            Customer c1 = new Customer("Anton", "password", 0, 0);
            Customer c2 = new Customer("Daniel", "password", 0, 0);
            Customer c3 = new Customer("John", "password", 0, 0);
            Customer c4 = new Customer("Rasmus", "password", 0, 0);
            Admin a1 = new Admin("Pär", "password", 0);

            Account c1a1 = new Account(3000, "SEK", "Antons Lönekonto", "Anton");
            Account c1a2 = new Account(50000, "USD", "Antons Sparkonto", "Anton");

            c1.CreateNewAccount(c1a1);
            c1.CreateNewAccount(c1a2);

            c1.SeeAccounts();

            Console.ReadLine();
        }
    }
}