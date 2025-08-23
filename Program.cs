namespace BasicCalculator
{
    class Program
    {
        static void Main()
        {
            // Welcoming message
            Console.WriteLine("Welcome to the Basic Calculator program!");
            Console.WriteLine("You can use this to perform simple calculations.");
            Calculator calculator = new Calculator();

            while (true)
            {
                // Get operation that user wishes to use
                OperationType operation = calculator.GetOperation();
                // Execute calculator code to show history or do testing and skip rest of the loop
                if (operation == OperationType.History || operation == OperationType.Test)
                {
                    calculator.Execute();
                    continue;
                }
                // Exit program if they have chosen to exit
                else if (operation == OperationType.Exit)
                {
                    Console.WriteLine("Thank you for using the Basic Calculator! Goodbye.\n");
                    break;
                }

                // Get input numbers from user
                calculator.first = calculator.GetNumber("Enter your first number: ");
                // Skip second number if the selected operation is square root
                if (operation != OperationType.SquareRoot)
                    calculator.second = calculator.GetNumber("Enter your second number: ");
                
                // Execute operation and print out result
                Console.WriteLine(calculator.Execute());
            }
        }
    }
}
