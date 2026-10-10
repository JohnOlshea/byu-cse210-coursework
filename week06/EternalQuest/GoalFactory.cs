using System;

public class GoalFactory
{
    // Rebuilds a goal from a line produced by Goal.GetStringRepresentation().
    public Goal CreateFromString(string line)
    {
        string[] typeAndData = line.Split(":", 2);
        string type = typeAndData[0];
        string[] parts = typeAndData[1].Split("|");

        string name = parts[0];
        string description = parts[1];
        int points = int.Parse(parts[2]);

        switch (type)
        {
            case "SimpleGoal":
                return new SimpleGoal(name, description, points, bool.Parse(parts[3]));
            case "EternalGoal":
                return new EternalGoal(name, description, points);
            case "ChecklistGoal":
                return new ChecklistGoal(name, description, points,
                    int.Parse(parts[4]), int.Parse(parts[3]), int.Parse(parts[5]));
            case "NegativeGoal":
                return new NegativeGoal(name, description, points, int.Parse(parts[3]));
            default:
                throw new FormatException($"Unknown goal type: {type}");
        }
    }
}
