using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What could you learn from this?",
        "What did you learn about yourself?",
        "How can you keep this in mind in the future?"
    };

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience.") {}

    public void Run()
    {
        DisplayStartingMessage();

        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("Reflect on the following questions:");

        int elapsed = 0;
        int total = GetDuration();

        while (elapsed < total)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.Write($"> {question} ");
            ShowSpinner(5);
            elapsed += 6;
        }

        DisplayEndingMessage();
    }
}
