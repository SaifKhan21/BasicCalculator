namespace BasicCalculator
{
    public enum OperationType
    {
        Addition = 1,
        Subtraction,
        Multiplication,
        Division,
        Exponential,
        SquareRoot,
        History,
        Test,
        Exit
    }

    // Abstract base class for operations
    public abstract class Operation
    {
        public abstract decimal Execute(decimal first, decimal second = 0);
        public abstract string Symbol { get; }
    }

    // Add both numbers together
    public class Addition : Operation
    {
        public override decimal Execute(decimal first, decimal second) => (decimal)((double)first + (double)second);
        public override string Symbol => " + ";
    }

    // Subtract numbers with each other
    public class Subtraction : Operation
    {
        public override decimal Execute(decimal first, decimal second) => (decimal)((double)first - (double)second);
        public override string Symbol => " - ";
    }

    // Multiply both numbers together
    public class Multiplication : Operation
    {
        public override decimal Execute(decimal first, decimal second) => (decimal)((double)first * (double)second);
        public override string Symbol => " * ";
    }

    // Divide numbers with each other with divide by zero error handling
    public class Division : Operation
    {
        public override decimal Execute(decimal first, decimal second)
        {
            if (second == 0)
                throw new DivideByZeroException("Division failed, cannot divide by zero.");
            return (decimal)((double)first / (double)second);
        }
        public override string Symbol => " / ";
    }

    // Raises the first number to the power of the second number
    public class Exponential : Operation
    {
        public override decimal Execute(decimal first, decimal second) => (decimal)Math.Pow((double)first, (double)second);
        public override string Symbol => "^";
    }

    // Square root the number (only the first number is used) with negative number error handling
    public class SquareRoot : Operation
    {
        public override decimal Execute(decimal first, decimal second)
        {
            if (first < 0)
                throw new ArithmeticException("Square root failed, cannot square root a negative number.");
            return (decimal)Math.Sqrt((double)first);
        }
        public override string Symbol => "√";
    }
}