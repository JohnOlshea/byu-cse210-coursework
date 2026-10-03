using System;
using System.Collections.Generic;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
    )
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            // Creative: growing animation
            for (int i = 1; i <= 4; i++)
            {
                Console.Write(new string('.', i));
                Thread.Sleep(1000);
                for (int j = 0; j < i; j++) Console.Write("\b \b");
            }
            ShowCountDown(4);

            if (DateTime.Now >= endTime) break;

            Console.WriteLine();
            Console.Write("Now breathe out... ");
            for (int i = 4; i >= 1; i--)
            {
                Console.Write(new string('.', i));
                Thread.Sleep(1000);
                for (int j = 0; j < i; j++) Console.Write("\b \b");
            }
            ShowCountDown(6);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
