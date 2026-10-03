using System;
using System.Collections.Generic;
using System.IO;

// Extra Activity to exceed requirements - Gratitude Activity
public class GratitudeActivity : Activity
{
    private List<string> _prompts;
    private Random _random;
    private List<string> _usedPrompts;

    public GratitudeActivity() : base(
        "Gratitude Activity",
        "This activity will help you cultivate gratitude by focusing on blessings and positive moments in your life. Recognizing good things can improve your overall well-being."
    )
    {
        _random = new Random();
        _usedPrompts = new List<string>();
        _prompts = new List<string>
        {
            "Think of a recent moment that made you smile.",
            "Think of a person who has positively impacted your life recently.",
            "Think of a challenge that taught you something valuable.",
            "Think of a small everyday blessing you often overlook.",
            "Think of a place that brings you peace.",
            "Think of an accomplishment you are proud of, no matter how small."
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine("Ponder the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("Take a moment to think. You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        List<string> entries = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> What are you grateful for in this moment? ");
            string entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
            {
                entries.Add(entry);
                Console.WriteLine("  Thank you for sharing. Keep going...");
                ShowSpinner(2);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Beautiful! You recorded {entries.Count} gratitude items.");
        ShowSpinner(2);

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts.Clear();
        }
        List<string> available = _prompts.FindAll(p => !_usedPrompts.Contains(p));
        int index = _random.Next(available.Count);
        string selected = available[index];
        _usedPrompts.Add(selected);
        return selected;
    }
}
