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

        public double GetInput(string prompt)
        {
            while (true)
            {
                // Print out specified prompt and get input number from user
                Console.Write(prompt);
                string input = Console.ReadLine();

                // Convert input to double and return it
                if (double.TryParse(input, out double number))
                    return number;
                // If input is not a valid number, repeat loop
                else
                    Console.WriteLine("Input is not a valid number, please try again.");
            }
        }

        // Add both user numbers together and return value as string
        public string Addition() { return (first + second).ToString(); }
    }
}