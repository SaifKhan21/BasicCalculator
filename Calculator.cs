namespace BasicCalculator
{
    public class Calculator
    {
        // First user number with public getter and setter
        private double first;
        public double First
        {
            get { return first; }
            set { first = value; }
        }
        
        // Second user number with public getter and setter
        private double second;
        public double Second
        {
            get { return second; }
            set { second = value; }
        }

        // Integer to store user's selected operation
        private int selectedOp;

        // Dictionary to store operation types
        public readonly Dictionary<int, Operation?> operations;
        public Calculator()
        {
            operations = new Dictionary<int, Operation?>
            {
                { 1, new Addition() },
                { 2, new Subtraction() },
                { 3, new Multiplication() },
                { 4, new Division() },
                { 5, null }
            };
        }

        public int GetOperation()
        {
            while (true)
            {
                // Print out list of operations
                Console.WriteLine("\n1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exit application");

                // Prompt user for which operation to use
                Console.Write("Enter the number of the operation you wish to use: ");
                string? input = Console.ReadLine();
                // Try to convert input to integer and check if number is for a valid operation
                if (int.TryParse(input, out int operation) &&
                    operations.ContainsKey(operation))
                {
                    // Set input as selected operation and return number
                    selectedOp = operation;
                    return selectedOp;
                }
                // If input is not a valid operation number, repeat loop
                else
                    Console.WriteLine("Input is not a valid operation number, please try again.");
            }
        }

        public double GetNumber(string prompt)
        {
            while (true)
            {
                // Print out specified prompt and get input number from user
                Console.Write(prompt);
                string? input = Console.ReadLine();

                // Try to convert input to double and return it
                if (double.TryParse(input, out double number))
                    return number;
                // If input is not a valid number, repeat loop
                else
                    Console.WriteLine("Input is not a valid number, please try again.");
            }
        }

        public string Execute()
        {
            try
            {
                // Execute user-selected operation and return result as string
                double result = operations[selectedOp]!.Execute(first, second);
                return result.ToString();
            }
            catch (DivideByZeroException e)
            {
                // If divide by zero exception occurs, print error message and return empty string
                Console.WriteLine(e.Message);
                return "";
            }
        }
    }
}