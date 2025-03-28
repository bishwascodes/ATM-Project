namespace ATM_NS;


public enum ATMAction
{
    InsertCard,
    EnterPIN,
    RequestAmount,
    DispenseCash,
    EjectCard,
    CheckBalance
}

public class ATM
{
    public ATMAction currentAction = ATMAction.InsertCard;
    private bool cardInserted = false;
    private bool pinValidated = false;
    private bool transactionCompleted = false;

    private bool CashDispensed = false;
    private BankServer bankServer;
    private string currentCardNumber;

    public ATM(BankServer server)
    {
        bankServer = server;
        currentAction = ATMAction.InsertCard;
    }

    public void insertCard(string cardNumber)
    {
        if (bankServer.verifyCard(cardNumber))
        {
            cardInserted = true;
            currentCardNumber = cardNumber;
            Console.WriteLine("Card inserted successfully.");

            currentAction = getNextAction();
        }
        else
        {
            Console.WriteLine("Invalid card number.");
            currentAction = getNextAction();
        }
    }

    public void enterPIN()
    {
        if (!cardInserted)
        {
            Console.WriteLine("Please insert your card first.");
            return;
        }

        Console.Write("Enter PIN: ");
        if (int.TryParse(Console.ReadLine(), out int pin))
        {
            if (bankServer.verifyPIN(currentCardNumber, pin))
            {
                pinValidated = true;
                Console.WriteLine("PIN validated successfully.");
                // Automatically transition to the next action
                currentAction = getNextAction();
            }
            else
            {
                Console.WriteLine("Invalid PIN.");
            }
        }
        else
        {
            Console.WriteLine("Invalid PIN format.");
        }
    }

    public void requestAmount()
    {
        if (!pinValidated)
        {
            Console.WriteLine("Please validate your PIN first.");
            return;
        }

        Console.Write("Enter amount to withdraw: ");
        if (double.TryParse(Console.ReadLine(), out double amount))
        {
            if (bankServer.processTransaction(currentCardNumber, amount))
            {
                transactionCompleted = true;
                Console.WriteLine("Withdrawal successful.");
            }
            else
            {
                Console.WriteLine("Insufficient funds or transaction failed.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
        Thread.Sleep(3000);
        // Automatically transition to the next action
        currentAction = getNextAction();
    }

    public void ejectCard()
    {
        if (cardInserted)
        {
            cardInserted = false;
            currentCardNumber = "";
            transactionCompleted = false; // Reset transaction status to false huse 
            pinValidated = false; // Reset PIN validation status
            Console.WriteLine("Card ejected.");
            // Reset action as the session is now completed
            currentAction = ATMAction.InsertCard;
        }
        else
        {
            Console.WriteLine("No card to eject.");
        }
    }

    public void checkBalance()
    {
        if (!pinValidated)
        {
            Console.WriteLine("Please validate your PIN first.");
            return;
        }

        double balance = bankServer.checkBalance(currentCardNumber);
        Console.WriteLine($"Your balance is: {balance:C}");

        // Automatically transition to the next action
        currentAction = getNextAction();
    }

    public void dispenseCash()
    {
        CashDispensed = true;
        Console.WriteLine("Please Collect your cash");
        Thread.Sleep(3000);

        currentAction = getNextAction();
    }

    public ATMAction getNextAction()
    {
        if (!cardInserted)
        {
            return ATMAction.InsertCard;
        }
        else if (!pinValidated)
        {
            return ATMAction.EnterPIN;
        }
        else if (!transactionCompleted)
        {
            return ATMAction.RequestAmount;
        }
        else if (!CashDispensed)
        {
            return ATMAction.DispenseCash;
        }
        else
        {
            return ATMAction.EjectCard;
        }
    }

    // Additional method to run the ATM interaction in a loop could be added here.
}
