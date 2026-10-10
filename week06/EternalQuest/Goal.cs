using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        // The "|" character is used as the save-file separator, so keep it out of user text.
        _shortName = (name ?? "").Replace("|", "/");
        _description = (description ?? "").Replace("|", "/");
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    // Records one event and returns the points earned (negative means points lost).
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}
