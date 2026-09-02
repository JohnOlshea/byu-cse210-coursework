using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    // Hides up to numberToHide words that are not already hidden, chosen at random.
    public void HideRandomWords(int numberToHide)
    {
        List<Word> candidates = _words.Where(w => !w.IsHidden()).ToList();

        if (candidates.Count == 0)
        {
            return;
        }

        Random random = new Random();
        int amountToHide = Math.Min(numberToHide, candidates.Count);
        List<Word> shuffled = candidates.OrderBy(w => random.Next()).ToList();

        for (int i = 0; i < amountToHide; i++)
        {
            shuffled[i].Hide();
        }
    }

    public string GetDisplayText()
    {
        string reference = _reference.GetDisplayText();
        string words = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{reference}\n{words}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    // Extra: lets the program show progress toward full memorization.
    public double PercentHidden()
    {
        if (_words.Count == 0)
        {
            return 0;
        }
        return (double)_words.Count(w => w.IsHidden()) / _words.Count * 100;
    }
}