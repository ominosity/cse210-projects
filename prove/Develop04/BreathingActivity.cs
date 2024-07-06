public class BreathingActivity : Activity
{
    /// <summary>
    /// Create a Breathing Activity by using base constructor with name, description, and a default timing of 60 seconds
    /// </summary>
    public BreathingActivity() :
        base("Breathing"
           , "This activity will help you relax by walking you through breathing slowly. Clear your mind and focus on your breathing."
           , 60)
    {
        // Nothing to initialize
    }

    /// <summary>
    /// Walk the user through a number of slow breathing exercises. 
    /// </summary>
    public void Run()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");

            // If less than 4 seconds left, use up the time. Otherwise, 4 seconds for breathing in
            TimeSpan remaining = endTime.Subtract(DateTime.Now);
            if (remaining.Seconds < 4)
            {
                ShowCountDown(remaining.Seconds);
                Console.WriteLine();
                return;
            }
            else
            {
                ShowCountDown(4);
            }

            // If less than 6 seconds left, use up the time. Otherwise, 6 seconds for breathing out
            remaining = endTime.Subtract(DateTime.Now);
            Console.Write("\nNow breathe out...");
            if (remaining.Seconds < 6)
            {
                ShowCountDown(remaining.Seconds);
                Console.WriteLine();
                return;
            }
            else
            {
                ShowCountDown(6);
            }
            Console.WriteLine();
        }

    }
}