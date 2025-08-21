namespace BasicCalculator
{
    // Abstract base class for operations
    public abstract class Operation
    {
        public abstract double Execute(double first, double second);
    }

    // Add both numbers together
    public class Addition : Operation
    {
        public override double Execute(double first, double second) => first + second;
    }

    // Subtract numbers with each other
    public class Subtraction : Operation
    {
        public override double Execute(double first, double second) => first - second;
    }

    // Multiply both numbers together
    public class Multiplication : Operation
    {
        public override double Execute(double first, double second) => first * second;
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
    }
}