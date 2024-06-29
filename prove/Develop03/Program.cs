/// <summary>
///     Name: Richard Burgener
///     Project: Scripture Memorizer
///     
///     Exceeds: I created a Libary class to contain a library of scriptures
///              for memorization. To support the library, I added a startup
///              menu to choose to memorize or manage the library. 
///              
///              The menu has 7 options:
///                 1. Randomly pick a scripture to memorize
///                 2. Pick a specific scripture from a list of those in the library to memorize
///                 3. Load a scripture library from a .txt file
///                 4. Save the current scripture library to a .txt file
///                 5. Add a new scripture to the current library
///                 6. Remove a scripture from the current library
///                 7. Quit the program
///              
///              To facilitate code reuse, I also created a class for the 
///              memorizer portion of the program. 
///              
///              Finally, I updated the word hider to only hide words that are currently 
///              visible. This makes the hiding consistent across runs. 
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Initialize the library
        Library library = new Library();

        // Start the menu loop
        int menuOption = -1;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Scripture Memorizer program!");
            Console.WriteLine("\nPlease choose from the following options:");
            Console.WriteLine("\t1. Memorize a random scripture");
            Console.WriteLine("\t2. Memorize a specific scripture");
            Console.WriteLine("\t3. Load a scripture library from a file");
            Console.WriteLine("\t4. Save the current scripture library to a file");
            Console.WriteLine("\t5. Add a scripture to the current library");
            Console.WriteLine("\t6. Remove a scripture from the current library");
            Console.WriteLine("\t7. Quit the Scripture Memorizer program");
            try
            {
                Console.Write("Choose a menu option between 1 and 7: ");
                menuOption = int.Parse(Console.ReadLine());
                if (menuOption < 1 || menuOption > 7)
                {
                    throw new Exception("Invalid number chosen.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid entry. Please select a number between 1 and 7.");
                Console.WriteLine("Press any key to return to the menu.");
                Console.ReadKey(true);
            }

            switch (menuOption)
            {
                // Memorize a random scripture
                case 1:
                    {
                        Scripture scripture = library.RandomScripture();
                        Memorizer memorizer = new Memorizer(scripture);
                        memorizer.MemorizeScripture();
                        break;
                    }

                // Memorize a specific scripture
                case 2:
                    {
                        Scripture scripture = library.ChooseScripture();
                        Memorizer memorizer = new Memorizer(scripture);
                        memorizer.MemorizeScripture();
                        break;
                    }

                // Load a library from a file
                case 3:
                    {
                        library.ImportLibrary();
                        break;
                    }

                // Save a library to a file
                case 4:
                    {
                        library.ExportLibrary();
                        break;
                    }

                // Add a scripture to the library
                case 5:
                    {
                        Console.WriteLine("Please answer the following prompts.");
                        Console.Write("\tEnter the book name (e.g. 1 Nephi): ");
                        string book = Console.ReadLine();

                        // Exit function if no book name is given
                        if (String.IsNullOrEmpty(book))
                        {
                            Console.WriteLine("No book name given.");
                            Console.WriteLine("Press any key to return to the menu.");
                            Console.ReadKey(true);
                            break;
                        }

                        // Init variables before the try block
                        int chapter = 0;
                        int verse = 0;
                        int endVerse = 0;

                        try
                        {
                            Console.Write("\tEnter the Chapter number: ");
                            chapter = int.Parse(Console.ReadLine().Trim());

                            Console.Write("\tEnter the first (or only) verse number: ");
                            verse = int.Parse(Console.ReadLine().Trim());

                            Console.Write("\tEnter the ending verse number. If only one verse is being added, enter the verse number again: ");
                            endVerse = int.Parse(Console.ReadLine().Trim());
                        }
                        catch (Exception)
                        {
                            //Console.WriteLine ($"{ex.Message}");
                            Console.WriteLine("Entry needs to be a single number.");
                            Console.WriteLine("Press any key to return to the menu.");
                            Console.ReadKey(true);
                            break;
                        }

                        // Create a variable for the scripture. Solicit scripture one line at a time. 
                        string entry = "";

                        // Create a variable for each added line (to check if it's empty)
                        string newLine = "";
                        Console.WriteLine("Enter the verses. Press <enter> with no value to finish.");
                        do
                        {
                            newLine = Console.ReadLine();
                            // Add a space after the new line (in case of multiple entries)
                            entry += newLine + " ";
                        } while (!String.IsNullOrEmpty(newLine));

                        // Return if the entry is empty
                        if (String.IsNullOrEmpty(entry.Trim()))
                        {
                            Console.WriteLine("Cannot save blank scripture.");
                            Console.WriteLine("Press any key to return to the menu.");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            // Create the reference and text and put them together into a Scripture object
                            if (verse == endVerse)
                            {
                                Reference reference = new Reference(book, chapter, verse);
                                Scripture scripture = new Scripture(reference, entry);
                                library.AddScripture(reference, scripture);
                            }
                            else
                            {
                                Reference reference = new Reference(book, chapter, verse, endVerse);
                                Scripture scripture = new Scripture(reference, entry);
                                library.AddScripture(reference, scripture);
                            }

                            Console.WriteLine("Scripture added.");
                            Console.WriteLine("Press any key to return to the menu.");
                            Console.ReadKey(true);
                        }
                        break;
                    }

                // Remove a scripture from the current library
                case 6:
                    {
                        Scripture scripture = library.ChooseScripture();
                        library.RemoveScripture(scripture.GetReference());
                        break;
                    }
            }
        } while (menuOption != 7);

        Console.WriteLine("Thank you for using the Scipture Memorizer program. Goodbye. ");
    }
}