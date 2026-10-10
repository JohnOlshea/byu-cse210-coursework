using System;

public class NegativeGoal : Goal
{
    private int _timesSlipped;

    public NegativeGoal(string name, string description, int penalty)
        : base(name, description, Math.Abs(penalty))
    {
        _timesSlipped = 0;
    }

    public NegativeGoal(string name, string description, int penalty, int timesSlipped)
        : base(name, description, Math.Abs(penalty))
    {
        _timesSlipped = timesSlipped;
    }

    public override int RecordEvent()
    {
        _timesSlipped++;
        return -_points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[!] {_shortName} ({_description}) -- Penalty: -{_points}, slipped {_timesSlipped} time(s)";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName}|{_description}|{_points}|{_timesSlipped}";
    }
}
