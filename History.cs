namespace BasicCalculator
{
    public class History
    {
        // Store history of calculations
        private readonly Queue<string> history = new Queue<string>();
        // Public getter for history count
        public int Count => history.Count;

        // Store only the last 10 calculation histories
        public void AddHistory(string entry)
        {
            while (history.Count >= 10)
                history.Dequeue();

            history.Enqueue(entry);
        }

        // Display list of calculation histories
        public void ShowHistory()
        {
            if (history.Count == 0)
                Console.WriteLine("Calculation history is empty.");
            else
            {
                Console.WriteLine("\n--- Last 10 Calculations ---");
                foreach (string entry in history)
                    Console.WriteLine(entry);
                Console.WriteLine("-----------------------------");
            }
        }
    }
}