using System;
using System.IO;

/*
 * W05 Project: Mindfulness Program - Exceeding Requirements Report
 * 
 * To exceed the core requirements (93% -> 100%), I implemented the following:
 * 
 * 1. NO REPEAT UNTIL ALL USED: In ListingActivity, ReflectingActivity, and GratitudeActivity,
 *    I track used prompts and questions in _usedPrompts / _usedQuestions lists. Once all
 *    prompts have been shown, the list clears and repeats only then. This prevents repetition
 *    in a single session until all options are exhausted.
 * 
 * 2. ACTIVITY LOG / STATISTICS: Added a log file "mindfulness_log.txt" that records each
 *    activity completion with timestamp, activity name, and duration. On program start,
 *    it displays how many times activities have been performed (read from log).
 *    This satisfies "Keeping a log of how many times activities were performed" and
 *    "Saving and loading a log file".
 * 
 * 3. ADDITIONAL ACTIVITY: Added a 4th activity called GratitudeActivity which follows the
 *    same pattern as the other activities (inherits from Activity) but focuses on gratitude.
 *    This shows extensibility of the inheritance hierarchy.
 * 
 * 4. ENHANCED ANIMATIONS:
 *    - BreathingActivity now includes a growing/shrinking dot animation (.... -> ...) combined
 *      with countdown to simulate breathing expansion/contraction more visually.
 *    - Spinner and Countdown use proper backspace erasing as required (\b \b).
 * 
 * 5. INPUT VALIDATION: Added validation for duration to ensure positive integer input.
 * 
 * 6. DESIGN PRINCIPLES MET:
 *    - Abstraction: Each class only contains its own responsibilities.
 *    - Encapsulation: All member variables are private with _underscoreCamelCase.
 *    - Inheritance: All activities derive from Activity base class. Shared members _name,
 *      _description, _duration and shared behaviors DisplayStartingMessage, DisplayEndingMessage,
 *      ShowSpinner, ShowCountDown are in base class.
 */

class Program
{
    static void Main(string[] args)
    {
        string logFile = "mindfulness_log.txt";

        // Display stats from log
        if (File.Exists(logFile))
        {
            string[] lines = File.ReadAllLines(logFile);
            Console.WriteLine($"Welcome back! You have completed {lines.Length} mindfulness sessions so far.");
            Console.WriteLine();
        }

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude activity (EXTRA)");
            Console.WriteLine("  5. Show activity log");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    LogActivity(logFile, "Breathing Activity", breathing.GetDuration());
                    break;
                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    LogActivity(logFile, "Reflecting Activity", reflecting.GetDuration());
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    LogActivity(logFile, "Listing Activity", listing.GetDuration());
                    break;
                case "4":
                    GratitudeActivity gratitude = new GratitudeActivity();
                    gratitude.Run();
                    LogActivity(logFile, "Gratitude Activity", gratitude.GetDuration());
                    break;
                case "5":
                    ShowLog(logFile);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1-6.");
                    Thread.Sleep(1500);
                    break;
            }
        }

        Console.WriteLine("Goodbye! Stay mindful.");
    }

    static void LogActivity(string file, string activityName, int duration)
    {
        string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {activityName} | Duration: {duration} seconds";
        File.AppendAllText(file, entry + Environment.NewLine);
    }

    static void ShowLog(string file)
    {
        Console.Clear();
        Console.WriteLine("=== Mindfulness Activity Log ===\n");
        if (!File.Exists(file))
        {
            Console.WriteLine("No sessions logged yet.");
        }
        else
        {
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine($"\nTotal sessions: {lines.Length}");
        }
        Console.WriteLine("\nPress enter to return to menu...");
        Console.ReadLine();
    }
}
