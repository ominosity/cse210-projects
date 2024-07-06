
/// <summary>
///     Name: Richard Burgener
///     Project: Mindfulness Activities
///     
///     Exceeds: I updated the countdown timer to handle any int-range number, not just 9 seconds.
///              
///              I updated the spinner and countdown to hide the cursor while animating.
///              
///              I set up the prompts to keep track of whether or not they've been used, so they
///              only repeat after all of them have been used once. 
///              
///              I did the same with the question prompts on the reflecting activity.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        /**************/
        /* Unit tests */
        /**************/
        // Activity activity= new Activity("Testing", "Practicing", 20);
        // activity.ShowSpinner(5);
        // activity.ShowCountDown(5);

        // BreathingActivity breathingActivity = new BreathingActivity();
        // breathingActivity.DisplayStartingMessage();
        // breathingActivity.Run();
        // breathingActivity.DisplayEndingMessage();

        // ReflectingActivity reflectingActivity = new ReflectingActivity();
        // reflectingActivity.DisplayStartingMessage();
        // reflectingActivity.Run();
        // reflectingActivity.DisplayEndingMessage();

        // ListingActivity listingActivity = new ListingActivity();
        //ingActivity.DisplayStartingMessage();
        // listingActivity.Run();
        // listingActivity.DisplayEndingMessage(); list

        // Instantiate the three activity types. Doing it here persists data between runs
        BreathingActivity breathingActivity = new BreathingActivity(); 
        ReflectingActivity reflectingActivity = new ReflectingActivity();
        ListingActivity listingActivity = new ListingActivity();

        // Start the menu loop
        int choice = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Start breathing activity");
            Console.WriteLine("\t2. Start reflecting activity");
            Console.WriteLine("\t3. Start listing activity");
            Console.WriteLine("\t4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            // Deal with invalid responses
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid response. Please pick a number between 1 and 4");
                Console.WriteLine("Press any key to try again.");
                Console.ReadKey(true);
                continue;
            }

            // Choose. But choose wisely...
            switch (choice)
            {
                // Option 1 - Breathing Activity
                case 1:
                {
                    breathingActivity.DisplayStartingMessage();
                    breathingActivity.Run();
                    breathingActivity.DisplayEndingMessage();
                    Console.WriteLine("Press any key to return to menu.");
                    Console.ReadKey(true);
                    break;
                }

                // Option 2 - Reflecting Activity
                case 2:
                {
                    reflectingActivity.DisplayStartingMessage();
                    reflectingActivity.Run();
                    reflectingActivity.DisplayEndingMessage();
                    Console.WriteLine("Press any key to return to menu.");
                    Console.ReadKey(true);
                    break;
                }

                // Option 3 - Listing Activity
                case 3:
                {
                    listingActivity.DisplayStartingMessage();
                    listingActivity.Run();
                    listingActivity.DisplayEndingMessage();
                    Console.WriteLine("Press any key to return to menu.");
                    Console.ReadKey(true);
                    break;
                }
            }
        } while (choice != 4);

        Console.WriteLine("Thank you for using the Mindfulness Program!");
        Console.WriteLine("Have a serene and wonderful day.");
    }
}