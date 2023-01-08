using System;


public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;


    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;

    }
    public String getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
       return balance;
    }
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[]args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options .. ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw ");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw ");
            double withdraw = Double.Parse(Console.ReadLine());
            //Check if the user has enough money
            if(currentUser.getBalance() < withdraw)
            {
                Console.WriteLine("insufficient balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("You're good to go! Thank you!");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532772818527395", 1234, "Daniel", "Reyes", 150.32));
        cardHolders.Add(new cardHolder("4532772818749578", 4321, "Ximena", "Montecino", 1550.32));
        cardHolders.Add(new cardHolder("4532772818284014", 5678, "Patricia", "Nancupil", 2150.32));
        cardHolders.Add(new cardHolder("4532772818975402", 9876, "Lorena", "Reyes", 5150.32));

        //Prompt User

        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum= Console.ReadLine();
                //Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recongnized, Please try again!"); }
            }
            catch { Console.WriteLine("Card not recongnized, Please try again!"); }
        }
        Console.WriteLine("Please enter your pin!");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again."); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again!"); }
        }
        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            {
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
        }
        while (option != 4);
        Console.WriteLine("Thank you! have a nice day :)");
        
        }
    }
    

