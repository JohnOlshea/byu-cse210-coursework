using System;
using System.Collections.Generic;

/*
 * EXCEEDING CORE REQUIREMENTS
 * ----------------------------
 * This program exceeds the core requirements in the following ways:
 *
 * 1. Scripture Library: Rather than memorizing a single hard-coded scripture,
 *    the program stores a small library of scriptures (BuildLibrary) and
 *    randomly selects one each time it runs, so practice is different
 *    every session.
 *
 * 2. Smart Word Selection (stretch challenge): When hiding words, the
 *    program only chooses from words that are not already hidden
 *    (see Scripture.HideRandomWords), instead of allowing an already-hidden
 *    word to be picked again. This makes progress toward full memorization
 *    steady and predictable rather than random and repetitive.
 *
 * 3. Progress Indicator: Each time the scripture is displayed, the program
 *    shows the percentage of words currently hidden, so the user can see
 *    how close they are to having the whole passage hidden.
 *
 * 4. Robust Input Handling: The "quit" command is checked case-insensitively
 *    and with surrounding whitespace trimmed, so "Quit", "QUIT", or
 *    "  quit  " all work as expected.
 */

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = BuildLibrary();

        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine($"({scripture.PercentHidden():0}% hidden)");
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press enter to continue, or type 'quit' to end: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }

    static List<Scripture> BuildLibrary()
    {
        List<Scripture> library = new List<Scripture>();

        library.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, " +
            "that whosoever believeth in him should not perish, but have everlasting life."));

        library.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart, and lean not unto thine own understanding. " +
            "In all thy ways acknowledge him, and he shall direct thy paths."));

        library.Add(new Scripture(
            new Reference("Philippians", 4, 13),
            "I can do all things through Christ which strengtheneth me."));

        library.Add(new Scripture(
            new Reference("Joshua", 1, 9),
            "Have not I commanded thee? Be strong and of a good courage; be not afraid, " +
            "neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest."));

        return library;
    }
}