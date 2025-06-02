using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") {}

    public void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration();
        int cycleTime = 6;
        int cycles = duration / cycleTime;

        for (int i = 0; i < cycles; i++)
        {
            Console.Write("\nBreathe in... ");
            Countdown(3);
            Console.Write("\nBreathe out... ");
            Countdown(3);
        }

        DisplayEndingMessage();
    }
}
