using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou completed {_duration} seconds of the {_name}.\n");
        ShowSpinner(3);
    }

    protected int GetDuration()
    {
        return _duration;
    }

    protected void ShowSpinner(int seconds)
    {
        string[] symbols = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(symbols[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
