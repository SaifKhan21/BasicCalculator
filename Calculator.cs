namespace BasicCalculator
{
    public class Calculator
    {
        // First user number with public getter and setter
        private double first = 0;
        public double First
        {
            get => first;
            set => first = value;
        }
        
        // Second user number with public getter and setter
        private double second = 0;
        public double Second
        {
            get => second;
            set => second = value;
        }

        // Store user's selected operation
        private OperationType selectedOp;
        // Store operation types
        public readonly Dictionary<OperationType, Operation?> operations;

        private History history;

        // Create an instance of the History class and dictionary of operations
        public Calculator()
        {
            history = new History();
            operations = new Dictionary<OperationType, Operation?>
            {
                { OperationType.Addition, new Addition() },
                { OperationType.Subtraction, new Subtraction() },
                { OperationType.Multiplication, new Multiplication() },
                { OperationType.Division, new Division() },
                { OperationType.Exponential, new Exponential() },
                { OperationType.SquareRoot, new SquareRoot() },
                { OperationType.History, null },
                { OperationType.Exit, null }
            };
        }

        public OperationType GetOperation()
        {
            while (true)
            {
                // Print out list of operations
                Console.WriteLine("\n1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exponential");
                Console.WriteLine("6. Square root");
                Console.WriteLine("7. Show history");
                Console.WriteLine("8. Exit application");

                // Prompt user for which operation to use
                Console.Write("Enter the number of the operation you wish to use: ");
                string? input = Console.ReadLine();
                // Try to convert input to integer and check if number is a valid operation type
                if (int.TryParse(input, out int operation) &&
                    Enum.IsDefined(typeof(OperationType), operation))
                {
                    // Set input as selected operation and return operation type
                    selectedOp = (OperationType)operation;
                    return selectedOp;
                }
                // If input is not a valid operation number, repeat loop
                else
                    Console.WriteLine("Input is not a valid operation type, please try again.");
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
                // Show history and return empty string
                if (selectedOp == OperationType.History)
                {
                    history.ShowHistory();
                    return "";
                }

                // Execute user-selected operation and obtain result
                Operation operation = operations[selectedOp]!;
                double result = operation.Execute(first, second);

                // Format string, different format required for square root
                string calculation;
                if (operation is SquareRoot)
                    calculation = $"{operation.Symbol}{first} = {result}";
                else
                    calculation = $"{first}{operation.Symbol}{second} = {result}";

                // Add entry to history and return it
                history.AddHistory(calculation);
                return calculation;
            }
            catch (Exception e)
            {
                // If mathematic exception occurs, print error message and return empty string
                Console.WriteLine(e.Message);
                return "";
            }
        }
    }
}