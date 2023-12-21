# Group_Project_Loop_Legends

INTRODUCTION

This program simulates a bank. It has most of the common customer services of an actual bank, like creating new accounts, transfer money, take loans etc. There is also a log in for an admin who can set exchange rates for diffirent currencys and create new customers.


CLASSES

Initializer<br>
This is where the program starts. The InitializerMethod() creates intitial bank customers and admins by creating an object of the UserManager class and calling its CreateInitialUsers() method.

UserManager<br>
This is where initial customer and admin objects are directly created. These initial customers and admins enables actual use and testing of the program. "Real" customers can be created in a later stage of the program. The initial customers are given bank accounts. Customers and admins are added to their respectie lists. At last, UserManager directs the program to the next class, Login.

Login<br>
This is where the Login menu is presented. The user of the program can either log in as a customer, or an admin, using the usernames and password provided in the previous class. If the login is successfull, the user is taken to the corresponding menu. If the user inserts incorrect password three times, further log in tries are blocked and the program has to be restarted.

Customer<br>
This class inherits from User class and declares more fields given to Customer objects. And here the user is presented with several menu options. 
1. See Your Accounts. The SeeAccounts() method is called to present the customers all accounts, their balance and their currency.
2. Create New Account. Takes the user to the AddAccount() method in which, you guessed it, lets the user create a new account. The user needs to name the new account and set currency. Then the account is added to the customers accountList.
3. Show Account History. Calls AccountHistory() method that shows all transactions and loans made by the customer.
4. Transfer Money. The most exstensive method of the program. Enables the customer to send money to any other account of the bank, automatically converting currency between accounts, and adds the transaction as a string into a historyList.
5. Loan Money. In the LoanMoney() method the customer is offered a loan of up to five times the total asset of that customer minus the credit of previous loans.
6. Settings. The customer can choose to recieve a warning when his or her total asset in the bank falls below a set limit. The customer can here also choose to to add further security by adding an extra step in the log in method.
7. Log Out. Sends the user back to the original menu.

User<br>
This class sets common fields shared by its inheritors Customer and Admin

Admin<br>
Admin inherits fields from User. In the Admin class. The logged in admin is presented with a menu.
1. Set New Currency. Calls the SetNewCurrency() method which, through the CurrencyConverter class, enables the admin to set any exchange rate for any currency available within the program.
2. Create New Customer. The admin sets parameters for the creation of a new Customer object.
3. See Total Assets. Provides information on the total balance of all bank accounts and loans.
4. See All Transactions. All Customer objects holds a list of all their transactions and loans, they are all printed through this menu choice.

CurrencyConverter<br>
All currencies are declared in this class. This class contains methods for currency conversion when taking loans and transfering money between different accounts.

AuthenticationClass<br>
This class handles the extra security of the log in method that the user can choose to include. It sets like an extra password as an anwser to one of a set of questions the customer can choose from.



SPECIAL FEATURES

Menu Arrow
The usual console application navigation solution is having the user press a number for each menu choice. Like "Press 1 to Create new Account" or "Press 6 to Log out". But we are using an arrow, pointing at the diffirent selections available for the user, navigating the arrow with the arrow keys. It's easy to comprehend, easy to use, and can not break because of incorrect user input.

Delayed Transaction<br>
All transaction requests input by customers are actually enforced only every 15 minutes. The transactions are added to a Task class referring to a HandleTransaction() method. This method makes the transaction happen only if the computer clock minutes can be divided by 15. So transactions will take place .00 .15 .30 and .45 minutes of the hour.
