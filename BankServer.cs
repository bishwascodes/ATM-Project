namespace ATM;



public class BankServer
{
    private Dictionary<string, (int pin, BankAccount account)> validCards = new();

    public BankServer(Dictionary<string, (int pin, BankAccount account)> initialCards)
    {
        validCards = initialCards;
    }

    public bool VerifyCard(string cardNumber)
    {
        if (!validCards.ContainsKey(cardNumber))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool VerifyPIN(string cardNumber, int pin)
    {
        if (VerifyCard(cardNumber))
        {
            if (validCards[cardNumber].pin == pin)
            {
                return true;
            }
        }
        return false;
    }
  
    public bool ProcessTransaction(string cardNumber, double amount)
    {
        if (validCards[cardNumber].account.hasSufficientFunds(amount))
        {
            bool transactionSuccessful = validCards[cardNumber].account.Withdraw(amount);
            return transactionSuccessful;
        }
        return false;
    }

    public double CheckBalance(string cardNumber)
    {
        if (validCards.ContainsKey(cardNumber))
        {
            return validCards[cardNumber].account.getBalance();
        }
        return -1;
    }
}
