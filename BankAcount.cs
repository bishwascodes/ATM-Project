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
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool Withdraw(double amount)
    {
        if (hasSufficientFunds(amount) == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static double getBalance()
    {
        return 1;
    }
}