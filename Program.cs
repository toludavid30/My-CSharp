using System;


namespace CodeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");
            // Console.WriteLine("");
            // Console.WriteLine("Another line added.");

            // Console.WriteLine("Enter your name:");
            // string userName = Console.ReadLine() ?? "Guest" ;
            // Console.WriteLine("Your name is: " + userName);
            // Console.WriteLine("Your number:");
            // long userNumber = long.Parse(Console.ReadLine() ?? "0");
            // Console.WriteLine("Your number is: " + userNumber);

            // string[] userNames = { "Alice", "Bob", "Charlie", "Diana" };
            // Console.WriteLine("User names in the array:");
            // foreach (string name in userNames)
            // {
            //     Console.WriteLine(name);
            // }

            // string[,] userDetails = {
            //     { "Alice", "25", "Engineer" },
            //     { "Bob", "30", "Designer" },
            //     { "Charlie", "28", "Teacher" },
            //     { "Diana", "22", "Student" }
            // };

            // Console.WriteLine("\nUser details in the 2D array:");
            // for (int i = 0; i < userDetails.GetLength(0); i++)
            // {
            //     for (int j = 0; j < userDetails.GetLength(1); j++)
            //     {                  
            //         Console.Write(userDetails[i, j] + "\t");
            //     }
            //     Console.WriteLine();
            // }

            // Console.WriteLine(userDetails[2, 0]);



            // List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };
            // Console.WriteLine("\nNumbers in the list:");
            // foreach (int number in numbers)
            // {
            //     Console.WriteLine(number);
            // }
            // Console.ReadKey();

            // Dictionary<int, string> userDict = new Dictionary<int, string>
            // {
            //     { 1001, "Alice" },
            //     { 1002, "Bob" },
            //     { 1003, "Charlie" },
            //     { 1004, "Diana" }
            // };
            // Console.WriteLine("\nUser dictionary contents:");
            // foreach (var kvp in userDict)
            // {
            //     Console.WriteLine("ID: " + kvp.Key + ", Name: " + kvp.Value);
            // }

            // List<int> activeUsers = userDict.Keys.ToList();
            // Console.WriteLine("\nActive user IDs:");
            // foreach (int id in activeUsers)
            // {
            //     Console.WriteLine(id);
            // }

            // HashSet<string> uniqueNames = new HashSet<string>(userDict.Values);
            // Console.WriteLine("\nUnique user names:");
            // foreach (string name in uniqueNames)
            // {
            //     Console.WriteLine(name);
            // }

            // HashSet<string> additionalUser = new HashSet<string>
            // {
            //     "Eve",
            //     "Frank",
            //     "Grace"
            // };
            // additionalUser.UnionWith(uniqueNames);
            // Console.WriteLine("\nAdditional user names after union:");
            // foreach (string name in additionalUser)
            // {
            //     Console.WriteLine(name);
            // }

            // Person person1 = new Person("Alice", 25);
            // Person person2 = new Person("Bob", 30);

            // person1.Introduce();
            // person2.Introduce();

            // BankAccount account = new BankAccount();
            // account.Deposit(500);
            // Console.WriteLine("Balance after deposit: " + account.Balance);
            // account.Withdraw(600);
            // Console.WriteLine("Balance after withdrawal: " + account.Balance);


            // BankTransactions transactionAccount = new BankTransactions();
            // transactionAccount.Deposit(1000);
            // Console.WriteLine("Transaction Account Balance after deposit: " + transactionAccount.Balance);
            // transactionAccount.Withdraw(300);
            // Console.WriteLine("Transaction Account Balance after withdrawal: " + transactionAccount.Balance);

            // Console.WriteLine("\nTransaction History:");
            // foreach (var transaction in transactionAccount.transactions)
            // {
            //     Console.WriteLine($"Transaction ID: {transaction.Key}, Type: {transaction.Value.Item1}, Amount: {transaction.Value.Item2} , Date: {transaction.Value.Item3}");
            // }

            
            SavingsAccount justSavings = new SavingsAccount("Alice", "SA123456", DateOnly.FromDateTime(DateTime.Now), 3.5m);
            justSavings.DisplayAccountInfo();

            // returnValues("John", "Doe");
            // returnValues(101, "Jane", "Smith");
        }

        // public class Person
        // {
            
        //     public string Name { get; set; }
        //     public int Age { get; set; }


        //     public Person(string name, int age)
        //     {
        //         Name = name;
        //         Age = age;
        //     }

        //     public void Introduce()
        //     {
        //         Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        //     }
        // }

        // static void returnValues( string firstName, string lastName)
        // {
        //     Console.WriteLine("First Name: " + firstName);
        //     Console.WriteLine("Last Name: " + lastName);
        // }
        // static void returnValues( int id, string firstName, string lastName)
        // {
        //     Console.WriteLine("ID: " + id);
        //     Console.WriteLine("First Name: " + firstName);
        //     Console.WriteLine("Last Name: " + lastName);
        // }
        
    }

    public class BankAccount
    {
        private decimal _balance;
        public decimal Balance { 
            get { return _balance; }
            private set { _balance = value; }
        }

        public virtual decimal Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            Balance += amount;
            return Balance;
        }


        public virtual decimal Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds for this withdrawal.");
            }
            Balance -= amount;
            return Balance;
        }
    }

     public class BankTransactions : BankAccount
    {
        public Dictionary<int, (string, decimal, DateOnly)> transactions = new Dictionary<int, (string, decimal, DateOnly)>();
        public override decimal Deposit(decimal amount )
        {
            // decimal balance = base.Deposit(amount);
            transactions.Add(transactions.Count + 1, ("Deposit", amount, DateOnly.FromDateTime(DateTime.Now)));
            return base.Deposit(amount);
            // return balance;
        }

        public override decimal Withdraw(decimal amount)
        {
            // decimal balance = base.Withdraw(amount);
            transactions.Add(transactions.Count + 1, ("Withdrawal", amount, DateOnly.FromDateTime(DateTime.Now)));
            return base.Withdraw(amount);
            // return balance;
        }
    }

    public abstract class BankAccountInfo
    {
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public DateOnly OpeningDate { get; set; }

        public BankAccountInfo( string accountHolderName, string accountNumber, DateOnly openingDate)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
            OpeningDate = openingDate;
        }

        public abstract void DisplayAccountInfo();

    }

    public class SavingsAccount : BankAccountInfo
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount(string accountHolderName, string accountNumber, DateOnly openingDate, decimal interestRate)
            : base(accountHolderName, accountNumber, openingDate)
        {
            InterestRate = interestRate;
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Opening Date: {OpeningDate}");
            Console.WriteLine($"Interest Rate: {InterestRate}%");
        }
    }
}



