using System;

// Models a single journal entry: the date, the prompt it answers, and
// the response text. Responsible only for holding and displaying itself.
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"{_date}: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine();
    }

    public string ToFileString()
    {
        return $"{_date}~|~{_promptText}~|~{_entryText}";
    }
}