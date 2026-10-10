using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private GoalFactory _factory;

    private const int PointsPerLevel = 500;
    private static readonly string[] _titles =
    {
        "Humble Seeker", "Faithful Squire", "Diligent Pilgrim", "Ninja Unicorn",
        "Valiant Knight", "Mighty Champion", "Legendary Guardian", "Eternal Hero"
    };

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _factory = new GoalFactory();
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            choice = ReadInt("Select a choice from the menu: ");

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: Console.WriteLine("May your quest continue. Goodbye!"); break;
                default: Console.WriteLine("Please choose a number from 1 to 6."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        int level = GetLevel();
        int intoLevel = Math.Max(0, _score) % PointsPerLevel;
        int filled = intoLevel * 20 / PointsPerLevel;
        string bar = new string('#', filled) + new string('-', 20 - filled);

        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {level}: {GetTitle(level)}  [{bar}] {intoLevel}/{PointsPerLevel} to next level");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (bad habit)");
        int type = ReadInt("Which type of goal would you like to create? ");

        if (type < 1 || type > 4)
        {
            Console.WriteLine("That is not a valid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        switch (type)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, ReadInt("What is the amount of points associated with this goal? ")));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, ReadInt("What is the amount of points associated with this goal? ")));
                break;
            case 3:
                int points = ReadInt("What is the amount of points associated with this goal? ");
                int target = ReadInt("How many times does this goal need to be accomplished for a bonus? ");
                while (target < 1)
                {
                    target = ReadInt("The goal must be accomplished at least once. Enter a number of 1 or more: ");
                }
                int bonus = ReadInt("What is the bonus for accomplishing it that many times? ");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case 4:
                _goals.Add(new NegativeGoal(name, description, ReadInt("How many points are lost each time you slip? ")));
                break;
        }

        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet. Create one first.");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();
        int number = ReadInt("Which goal did you accomplish? ");

        if (number < 1 || number > _goals.Count)
        {
            Console.WriteLine("That is not a valid goal number.");
            return;
        }

        Goal goal = _goals[number - 1];

        if (goal.IsComplete())
        {
            Console.WriteLine("That goal is already complete.");
            return;
        }

        int oldLevel = GetLevel();
        int earned = goal.RecordEvent();
        _score += earned;

        if (earned >= 0)
        {
            Console.WriteLine($"Congratulations! You have earned {earned} points!");
        }
        else
        {
            Console.WriteLine($"Oh no! You lost {-earned} points. Tomorrow is a new chance!");
        }

        Console.WriteLine($"You now have {_score} points.");

        if (GetLevel() > oldLevel)
        {
            Console.WriteLine($"*** LEVEL UP! You are now Level {GetLevel()}: {GetTitle(GetLevel())} ***");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved.");
        }
        catch (Exception)
        {
            Console.WriteLine("The goals could not be saved. Check the filename and try again.");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename) || !File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            int loadedScore = int.Parse(lines[0]);
            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].Trim() != "")
                {
                    loadedGoals.Add(_factory.CreateFromString(lines[i]));
                }
            }

            _score = loadedScore;
            _goals = loadedGoals;
            Console.WriteLine("Goals loaded.");
        }
        catch (Exception)
        {
            Console.WriteLine("The file could not be read. It may be damaged.");
        }
    }

    private int GetLevel()
    {
        return Math.Max(0, _score) / PointsPerLevel + 1;
    }

    private string GetTitle(int level)
    {
        return _titles[Math.Min(level - 1, _titles.Length - 1)];
    }

    private int ReadInt(string prompt)
    {
        int value;
        Console.Write(prompt);
        string input = Console.ReadLine();
        while (!int.TryParse(input, out value))
        {
            if (input == null)
            {
                Environment.Exit(0);
            }

            Console.Write("Please enter a whole number: ");
            input = Console.ReadLine();
        }
        return value;
    }
}
