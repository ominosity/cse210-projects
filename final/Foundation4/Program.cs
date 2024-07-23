class Program
{
    static void Main(string[] args)
    {
        // Create the various activity details, to make instantiation cleaner
        DateTime cyclingDateTime = new DateTime(2024, 07, 22, 5, 15, 00);
        DateTime runningDateTime = new DateTime(2024, 07, 23, 18, 00, 00);
        DateTime swimmingDateTime = new DateTime(2024, 07, 24, 7, 15, 30);

        int cyclingMinutes = 30;
        int runningMinutes = 30;
        int swimmingMinutes = 30;

        double cyclingSpeed = 6;
        double runningDistance = 3;
        int swimmingLaps = 96;

        // Create the three activities
        CyclingActivity cyclingActivity = new CyclingActivity(cyclingDateTime, cyclingMinutes, cyclingSpeed);

        RunningActivity runningActivity = new RunningActivity(runningDateTime, runningMinutes, runningDistance);

        SwimmingActivity swimmingActivity = new SwimmingActivity(swimmingDateTime, swimmingMinutes, swimmingLaps);

        // Put the activities into a List<Activity>
        List<Activity> activities= new List<Activity>();
        activities.Add(cyclingActivity);
        activities.Add(runningActivity);
        activities.Add(swimmingActivity);

        // Iterate through the list, printing the summary to a cleared console
        Console.Clear();
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
        Console.WriteLine("");
    }
}