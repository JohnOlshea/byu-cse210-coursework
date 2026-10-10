using System;

// EXCEEDING REQUIREMENTS (creativity):
// 1. Leveling system: every 500 points is a new level, with a rank title
//    (Humble Seeker ... Ninja Unicorn ... Eternal Hero), a progress bar to the next
//    level, and a "LEVEL UP!" celebration when a recorded event crosses a level.
// 2. Fourth goal type, NegativeGoal: for bad habits. Recording a slip subtracts points
//    and counts how many times it happened. It is shown as [!] in the goal list.
// 3. Saving/loading covers score, all goal progress (including the negative goal's
//    slip count), uses a GoalFactory class, and handles missing/damaged files without crashing.
// 4. Input validation: numeric prompts re-ask until a valid whole number is entered.
class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}
