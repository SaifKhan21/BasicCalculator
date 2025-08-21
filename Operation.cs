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
        Exit
    }

    // Abstract base class for operations
    public abstract class Operation
    {
        public abstract double Execute(double first, double second = 0);
        public abstract string Symbol { get; }
    }

    // Add both numbers together
    public class Addition : Operation
    {
        public override double Execute(double first, double second) => first + second;
        public override string Symbol => " + ";
    }

    // Subtract numbers with each other
    public class Subtraction : Operation
    {
        public override double Execute(double first, double second) => first - second;
        public override string Symbol => " - ";
    }

    // Multiply both numbers together
    public class Multiplication : Operation
    {
        public override double Execute(double first, double second) => first * second;
        public override string Symbol => " * ";
    }

    // Divide numbers with each other with divide by zero error handling
    public class Division : Operation
    {
        public override double Execute(double first, double second)
        {
            if (second == 0)
                throw new DivideByZeroException("Division failed, cannot divide by zero.");
            return first / second;
        }
        public override string Symbol => " / ";
    }

    // Raises the first number to the power of the second number
    public class Exponential : Operation
    {
        public override double Execute(double first, double second) => Math.Pow(first, second);
        public override string Symbol => "^";
    }

    // Square root the number (only the first number is used)
    public class SquareRoot : Operation
    {
        public override double Execute(double first, double second)
        {
            if (first < 0)
                throw new ArithmeticException("Square root failed, cannot square root a negative number.");
            return Math.Sqrt(first);
        }
        public override string Symbol => "√";
    }
}