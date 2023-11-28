namespace Group_Project_Loop_Legends
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Login.LogIn();
            //Bank.RunBank();
            CustomerManager c1 = new CustomerManager();

            c1.CreateInitialCustomers();
        }
    }
}