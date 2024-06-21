using System;
using System.Collections;
using System.ComponentModel.Design;
using System.IO.Enumeration;
using System.Runtime.InteropServices;

/*
    Author: Richard Burgener    
    CLass: CSE 210
    Purpose: Create a program to encourage journaling
             by giving a daily prompt

    Exceeds: Cleared the console after each run to make the 
             UI a bit friendlier. Added a ReadKey(true) to the
             end of each line so the user and review the action 
             before going back to the menu. 
                
             Added methods to Entry to format them into delimited 
             strings for storage.

             Added static method to Entry to create an Entry object
             from a storage-formatting string. 

             Added a closing statement when the user is finished.
                
             Added a prompt if loading a journal while there's one
             already loaded. If user chooses 'y', clear the journal
             and load from file. 
                
             Prevented save and notified user if saving and there are 
             no entries. 

             Added exception handling to the menu so the program doesn't
             crash if the user enters something odd. 
*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        // Initialize the journal container
        Journal theJournal = new Journal();

        // Initialize the choice variable
        int choice = -1;

        // User menu loop
        while (choice != 5)
        {
            // Clear the console for a new run
            Console.Clear();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            try 
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Please pick a value between 1 and 5");
                // Console.WriteLine(ex);
                // Console.WriteLine(ex.Message);
                Console.ReadKey(true);
                continue;
            }
            catch (FormatException ex)  
            {
                Console.WriteLine("Please pick a value between 1 and 5");
                // Console.WriteLine(ex);
                // Console.WriteLine(ex.Message);
                Console.ReadKey(true);
                continue;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Please pick a value between 1 and 5");
                // Console.WriteLine(ex);
                // Console.WriteLine(ex.Message);
                Console.ReadKey(true);
                continue;
            }

            // Choice out of range
            if (choice <= 0 || choice > 5)
            {
                Console.WriteLine("Please pick a value between 1 and 5");
            }
            // Option 1: Write
            else if (choice == 1)
            {
                // Generate the prompt
                PromptGenerator generator = new PromptGenerator();
                string prompt = generator.GetRandomPrompt();

                // Display the prompt
                Console.WriteLine(prompt);
                Console.Write("> ");

                // Save the response
                string response = Console.ReadLine();

                // Create the date string
                DateTime now = DateTime.Now;
                string dateText = now.ToShortDateString();

                // Create the entry and add it to the journal
                Entry newEntry = new Entry(dateText, prompt, response);
                theJournal.AddEntry(newEntry);
            }

            // Option 2: Display
            else if (choice == 2)
            {
                theJournal.DisplayAll();
            }

            // Option 3: Load
            else if (choice == 3)
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
            }

            // Option 4: Save
            else if (choice == 4)
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
            }

            // Option 5: Quit
            else if (choice == 5)
            {
                Console.WriteLine("Thank you for using the Journal program!");
                return;
            }

            // Pause at the end of regular actions so user can review
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
        }
    }
}