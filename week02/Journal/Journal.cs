using System;
using System.Collections.Generic;
using System.IO;

// Models a journal: a collection of entries, with the ability to add,
// display, save, and load them.
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileString());
            }
        }
    }

    public void LoadFromFile(string file)
    {
        _entries = new List<Entry>();
        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~", StringSplitOptions.None);

            Entry entry = new Entry();
            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];

            _entries.Add(entry);
        }
    }

    // Exceeds requirements: search entries by keyword.
    public void Search(string keyword)
    {
        foreach (Entry entry in _entries)
        {
            if (entry._entryText.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                entry.Display();
            }
        }
    }
}