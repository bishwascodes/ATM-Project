using ATM_NS;
class Program
{
    public static void Main(string[] args)
    {
        // Initial Bank Cards
        Dictionary<string, (int pin, BankAccount account)> initialCards = new Dictionary<string, (int pin, BankAccount account)>();
        initialCards.Add("5566556655665566", (1234, new BankAccount(20)));
        initialCards.Add("1234567890123456", (1111, new BankAccount(10)));
        initialCards.Add("1111111122222222", (2222, new BankAccount(150)));

        ATM ourATM = new ATM(new BankServer(initialCards));
        while (true)
        {
            Console.Clear();
            switch (ourATM.currentAction)
            {
                case ATMAction.InsertCard:
                    Console.WriteLine("Welcome to the SNOW ATM!");
                    string cardNumber = getString(prompt: "Please insert your ATM Card: ");
                    ourATM.insertCard(cardNumber);
                    break;
                case ATMAction.EnterPIN:
                    ourATM.enterPIN();
                    break;
                case ATMAction.RequestAmount:
                    ourATM.requestAmount();
                    break;
                case ATMAction.DispenseCash:
                    ourATM.dispenseCash();
                    break;
                case ATMAction.EjectCard:
                    ourATM.ejectCard();
                    break;
                case ATMAction.CheckBalance:
                    ourATM.checkBalance();
                    break;
                default:
                    Console.WriteLine("Sorry! the ATM is under maintenance. Please visit later.");
                    break;
            }


        }
    }

    // Getting the int from USER
    public static int getInt(int min = int.MinValue, int max = int.MaxValue, string prompt = "Enter your choice: ")
    {
        int inputValue;

        bool isInvalid = false;
        while (true)
        {
            if (isInvalid)
            {
                Console.Write("Invalid Input. Please try again. ");
            }
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out inputValue))
            {
                if (inputValue >= min && inputValue <= max)
                {
                    return inputValue;
                }
                else
                {
                    isInvalid = true;
                }
            }
            else
            {
                isInvalid = true;
            }
        }

    }

    // Getting the string from USER
    public static string getString(string prompt = "Please write anything: ")
    {
        string myString = "";

        bool isInvalid = false;
        while (true)
        {
            if (isInvalid)
            {
                Console.Write("Invalid Input. Please try again. ");
            }
            Console.Write(prompt);
            myString = Console.ReadLine();
            if (!string.IsNullOrEmpty(myString))
            {
                return myString;
            }
            else
            {
                isInvalid = true;
            }
        }
    }

    public static void PressAnyKeyToContinue()
    {
        Console.Write("Press any key to continue... ");
        Console.ReadKey();
    }
}
