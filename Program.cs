namespace BasicCalculator
{
    class Program
    {
        static void Main()
        {
            // Welcoming message
            Console.WriteLine("Welcome to the Basic Calculator program!");
            Console.WriteLine("You can use this to perform simple calculations.");

            while (true)
            {
                Calculator calculator = new Calculator();
                // Get operation that user wishes to use
                int operation = calculator.GetOperation();
                // Exit program if they have chosen to stop using it
                if (calculator.operations[operation] == null)
                {
                    Console.WriteLine("Thank you for using the Basic Calculator! Goodbye.\n");
                    break;
                }

                // Get input numbers from user
                calculator.First = calculator.GetNumber("Enter your first number: ");
                calculator.Second = calculator.GetNumber("Enter your second number: ");
                // Execute operation and print out result
                Console.WriteLine(calculator.Execute());
            }
        }
    }
}
