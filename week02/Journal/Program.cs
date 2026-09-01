using System;

class Program
{
    // Exceeds core requirements: added a "Search" menu option that lets
    // the user find past entries containing a keyword, on top of the
    // required write/display/save/load functionality.
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = prompt;
                newEntry._entryText = response;

                journal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                Console.Write("What word would you like to search for? ");
                string keyword = Console.ReadLine();
                journal.Search(keyword);
            }
            else if (choice == "6")
            {
                keepRunning = false;
            }
            else
            {
                Console.WriteLine("Please choose a valid option.");
            }
        }
    }
}