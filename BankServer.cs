namespace ATM;



public class BankServer
{
   private Dictionary<string, (int pin, BankAccount account)> validCards = new();

   public BankServer(Dictionary<string, (int pin, BankAccount account)> initialCards)
   {
    validCards = initialCards;
   }

public bool verifyCard(string cardNumber)
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

public bool verifyPIN(string cardNumber, int pin)
{
    if (verifyCard(cardNumber))
    {
        if (validCards[cardNumber].pin == pin){
            return true;
        }
    }
    return false; 
}

public bool processTransaction(string cardNumber, double amount)
{
    if (validCards[cardNumber].account.hasSufficientFunds(amount))
    {
        
    }
}

public double checkBalance(string cardNumber)
{
    throw new NotImplementedException();
    int x = 0;
}

}



public class BankAccount();