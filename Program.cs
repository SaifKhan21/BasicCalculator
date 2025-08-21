namespace BasicCalculator
{
    class Program
    {
        static void Main()
        {
            // Welcoming message
            Console.WriteLine("Welcome to the Basic Calculator program!");
            Console.WriteLine("You can use this to perform simple calculations.\n");

            Calculator calculator = new Calculator();
            // Get input numbers from user and store the values
            calculator.First = calculator.GetInput("Enter your first number: ");
            calculator.Second = calculator.GetInput("Enter your second number: ");

            // Print out sum of values
            Console.WriteLine(calculator.Addition());
        }
    }
}
