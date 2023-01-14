using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, String firstName, String lastName, double balance)
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

    public String getFirstName() 
    {
        return firstName;
    }

    public String getLastName() 
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

    public void setFirstName(String newFirstName) 
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following oprionts...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser) 
        {
            Console.WriteLine("How mush $$ would you like to withdraw: ");
            double withdraw = double.Parse(Console.ReadLine());
            //Check if the user has enough money
            if (currentUser.getBalance() > withdraw)  
            {
                Console.WriteLine("Insufficient Funds: ");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() + withdraw);
                Console.WriteLine(" Thank you, Have a great day!: ");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>
        {
            new cardHolder("5416293791893520", 3203, "Carlos", "Medina", 345.77),
            new cardHolder("3783305835313352", 1977, "Amanda", "Medina", 189345.99),
            new cardHolder("3541274987156594", 1982, "Luciano", "Caballero", 1345.87),
            new cardHolder("4479065023733567", 6666, "Marisol", "Castro", 25000.50),
            new cardHolder("2720049792658835", 2567, "Pepper", "Medina", 22000.31)
        };

        //Promt user
        Console.WriteLine("Welcome to TheAtm");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);   
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(s: Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again."); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try agian"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + "!");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine()); 
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }

        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a great day!");
    }

}
