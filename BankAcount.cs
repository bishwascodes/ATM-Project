namespace ATM;

public class BankAccount
{
    private double Balance { get; set; }

    public BankAccount(double balance)
    {
        this.Balance = balance;
    }


    public bool hasSufficientFunds(double amount)
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

    public bool Withdraw(double amount)
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

    public double getBalance()
    {
        return Balance;
    }
}