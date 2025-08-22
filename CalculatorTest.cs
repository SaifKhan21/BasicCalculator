namespace BasicCalculator
{
    class CalculatorTest
    {
        // Track number of tests passed and failed
        private int testsPassed = 0;
        private int testsFailed = 0;
        private Calculator calculator;

        public CalculatorTest()
        {
            calculator = new Calculator();

            // Test operations with integers and decimals and error handling
            TestHistory(0);
            TestAddition(25, 22, 47);
            TestAddition(7.2m, 5.6m, 12.8m);
            TestSubtraction(67, 9, 58);
            TestSubtraction(7.2m, 5.6m, 1.6m);
            TestMultiplication(82, 4, 328);
            TestMultiplication(5.2m, 2.33m, 12.116m);
            TestDivision(408, 8, 51);
            TestDivision(244, 7, (decimal)(244.0 / 7));
            TestExponential(7, 3, 343);
            TestExponential(23, 3.2m, (decimal)Math.Pow(23, 3.2));
            TestSquareRoot(25, 5);
            TestSquareRoot(20, (decimal)Math.Sqrt(20));
            TestLetterInputs("asdf");
            TestZeroDivision(19);
            TestNegativeSquareRoot(-10);
            TestHistory(10);

            Console.WriteLine($"Tests passed: {testsPassed}");
            Console.WriteLine($"Tests failed: {testsFailed}");
        }

        // Assertion function to check if expected and actual values are equal
        void AssertEqual(decimal expected, decimal actual, string test)
        {
            if (actual == expected)
            {
                Console.WriteLine($"[PASS] {test} - Expected {expected}, got {actual}\n");
                testsPassed++;
            }
            else
            {
                Console.WriteLine($"[FAIL] {test} - Expected {expected}, got {actual}\n");
                testsFailed++;
            }
        }

        // Assertion function to check if expected and actual strings are equal
        void AssertStringEqual(string expected, string actual, string test)
        {
            if (actual == expected)
            {
                Console.WriteLine($"[PASS] {test}\n");
                testsPassed++;
            }
            else
            {
                Console.WriteLine($"[FAIL] {test} - Expected {expected}, got {actual}\n");
                testsFailed++;
            }
        }

        // Assertion function to check if the actual string contains the expected string
        void AssertStringContains(string expected, string actual, string test, bool reverse = false)
        {
            bool result = actual.Contains(expected);
            if (reverse)
                result = !result;
            
            if (result)
            {
                Console.WriteLine($"[PASS] {test}\n");
                testsPassed++;
            }
            else
            {
                Console.WriteLine($"[FAIL] {test} - Should contain {expected}, got {actual}\n");
                testsFailed++;
            }
        }

        // Test for history length count
        void TestHistory(int expected)
        {
            AssertEqual(expected, calculator.History.Count, "History Count");
        }

        // Test if addition operation functions correctly
        void TestAddition(decimal first, decimal second, decimal expected)
        {
            Console.WriteLine($"TEST: {first} + {second}");
            calculator.First = first;
            calculator.Second = second;
            calculator.SelectedOp = OperationType.Addition;
            calculator.Execute();
            AssertEqual(expected, calculator.Result, "Addition");
        }

        // Test if subtraction operation functions correctly
        void TestSubtraction(decimal first, decimal second, decimal expected)
        {
            Console.WriteLine($"TEST: {first} - {second}");
            calculator.First = first;
            calculator.Second = second;
            calculator.SelectedOp = OperationType.Subtraction;
            calculator.Execute();
            AssertEqual(expected, calculator.Result, "Subtraction");
        }

        // Test if multiplication operation functions correctly
        void TestMultiplication(decimal first, decimal second, decimal expected)
        {
            Console.WriteLine($"TEST: {first} * {second}");
            calculator.First = first;
            calculator.Second = second;
            calculator.SelectedOp = OperationType.Multiplication;
            calculator.Execute();
            AssertEqual(expected, calculator.Result, "Multiplication");
        }

        // Test if division operation functions correctly
        void TestDivision(decimal first, decimal second, decimal expected)
        {
            Console.WriteLine($"TEST: {first} / {second}");
            calculator.First = first;
            calculator.Second = second;
            calculator.SelectedOp = OperationType.Division;
            calculator.Execute();
            AssertEqual(expected, calculator.Result, "Division");
        }

        // Test if exponential operation functions correctly
        void TestExponential(decimal first, decimal second, decimal expected)
        {
            Console.WriteLine($"TEST: {first}^{second}");
            calculator.First = first;
            calculator.Second = second;
            calculator.SelectedOp = OperationType.Exponential;
            calculator.Execute();
            AssertEqual(expected, calculator.Result, "Exponential");
        }

        // Test if square root operation functions correctly
        void TestSquareRoot(decimal first, decimal expected)
        {
            Console.WriteLine($"TEST: √{first}");
            calculator.First = first;
            calculator.SelectedOp = OperationType.SquareRoot;
            calculator.Execute();
            AssertEqual(expected, calculator.Result, "Square Root");
        }

        // Test if letters in both operation and number inputs are handled correctly
        void TestLetterInputs(string input)
        {
            Console.WriteLine($"TEST: Enter letters (\"{input}\") into operation and number inputs");
            // Second line of input so that program is not stuck in function loop
            input += "\n3\n";

            // Record the original console reader and writer
            TextReader originalReader = Console.In;
            TextWriter originalWriter = Console.Out;

            // Create a string reader that reads from the input string
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);
            // Create a string writer to capture the console output
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            // Run the input operation function and get the results
            calculator.GetOperation();
            Console.SetOut(originalWriter);
            AssertStringContains("Input is not a valid operation type, please try again.", stringWriter.ToString(), "Letter in Operation Input");

            // Create a new string reader with the same input and flush the string writer
            stringReader = new StringReader(input);
            Console.SetIn(stringReader);
            stringWriter.Flush();
            Console.SetOut(stringWriter);

            // Run the input number function and get the results
            string prompt = "Get a number: ";
            calculator.GetNumber(prompt);
            Console.SetIn(originalReader);
            Console.SetOut(originalWriter);
            AssertStringContains("Input is not a valid number, please try again.", stringWriter.ToString(), "Letter in Number Input");
        }

        // Test if divison operation handles division by zero error correctly
        void TestZeroDivision(decimal first)
        {
            Console.WriteLine($"TEST: {first} / 0");
            calculator.First = first;
            calculator.Second = 0;
            calculator.SelectedOp = OperationType.Division;
            string result = calculator.Execute();
            // Check if calculation execution function returns error message
            AssertStringEqual("Division failed, cannot divide by zero.", result, "Divide By Zero");
        }
        
        // Test if square root operation handles negative square root correctly
        void TestNegativeSquareRoot(decimal input)
        {
            Console.WriteLine($"TEST: √{input}");
            calculator.First = input;
            calculator.SelectedOp = OperationType.SquareRoot;
            string result = calculator.Execute();
            // Check if calculation execution function returns error message
            AssertStringEqual("Square root failed, cannot square root a negative number.", result, "Negative Square Root");
        }
    }
}