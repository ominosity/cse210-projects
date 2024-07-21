using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Create the event addresses
        Address lectureAddress = new Address("3203 SE Woodstock Blvd", "Portland", "Oregon", "97202", "USA");
        Address outdoorGatheringAddress = new Address("193 Beachside Dr", "Parksville", "British Columbia", "V9P 2S5", "Canada");
        Address receptionAddress = new Address("Via Trionfale, 151, Via Alberto Dadlolo, 121", "Roma", "Roma", "00136", "Italy");

        // Create the events
        Lecture lecture = new Lecture("The Importance of Maintaining Good Lung Function", "Come spend an evening with Dr. Wolfe, as he talks about the 'ones that got away' and how to prevent future loss.", "07/24/2024", "5:00pm", lectureAddress, "B. B. Wolfe", 3);

        OutdoorGathering outdoorGathering = new OutdoorGathering("Krampus for Kids", "With 45 booths, this is the one holiday gathering anyone with kids cannot afford to miss. See the stage presentation of 'Krampus Eats the Neighborhood Bully' and learn how to use bad children as holiday decorations.", "12/25/2024", "7:00pm", outdoorGatheringAddress, "Light snow flurries, temperature: 0C");

        Reception reception = new Reception("Brutus/Caesar Wedding", "Gaius and Aurelia Caesar are excited to announce the wedding of their daughter, Julia, to Marcus, son of Marcus and Servilia Brutus. This a high-class occasion is being held at the Villa Miana, and anyone who is anybody should be there. Please dress sharply - this will be an historic event worth dying for.", "03/15/2025", "5:00pm", receptionAddress, "email", 250);

        // List each event's short description and full details
        string separatorLine = "\n***********************************************\n";
        Console.Clear();
        Console.WriteLine("Upcoming Events:");
        Console.WriteLine($"\t{lecture.GetShortDescription()}");
        Console.WriteLine($"\t{outdoorGathering.GetShortDescription()}");
        Console.WriteLine($"\t{reception.GetShortDescription()}");
        Console.WriteLine();
        Console.WriteLine(separatorLine);
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(separatorLine);
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine(separatorLine);
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(separatorLine);
    }
}