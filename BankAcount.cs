namespace ATM;

public class BankAccount
{
    private double Balance { get; set; }

    public BankAccount(double balance)
    {
        this.Balance = balance;
    }


    public static bool hasSufficientFunds(double amount)
    {
        if (amount <= getBalance())
        {
            // Console.WriteLine is removable if need be
            Console.WriteLine("Your account has sufficient funds for this transaction.");
            return true;
        }
        else
        {
            // Console.WriteLine is removable if need be
            Console.WriteLine("You do not have sufficient funds to make this transaction.");
            return false;
        }
    }

    public static bool Withdraw(double amount)
    {
        if (hasSufficientFunds(amount) == true)
        {
            // Console.WriteLine is removable if need be
            Console.WriteLine("Withdrawl successful.");
            return true;
        }
        else
        {
            // Console.WriteLine is removable if need be
            Console.WriteLine("Withdraw unsuccessful. Not sufficient funds.");
            return false;
        }
    }

    public static double getBalance()
    {
        return 1;
    }
}