using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int totalScore = 0;

    static void Main()
    {
        string choice = "";
        while (choice != "6")
        {
            try { Console.Clear(); } catch { }

            Console.WriteLine($"You have {totalScore} points.\n");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string input = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (input)
        {
            case "1":
                goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("How many times to complete? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points upon completion: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetails()}");
        }
        Console.WriteLine();
        Console.ReadKey();
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Select a goal number to record: ");
        int i = int.Parse(Console.ReadLine()) - 1;
        int earned = goals[i].RecordEvent();
        totalScore += earned;
        Console.WriteLine($"You earned {earned} points! Total: {totalScore}");
        Console.ReadKey();
    }

    static void SaveGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(totalScore);
            foreach (Goal g in goals)
            {
                output.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved!");
        Console.ReadKey();
    }

    static void LoadGoals()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            totalScore = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] data = parts[1].Split(',');

                if (type == "SimpleGoal")
                    goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                else if (type == "EternalGoal")
                    goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                else if (type == "ChecklistGoal")
                    goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]),
                                                int.Parse(data[4]), int.Parse(data[3]), int.Parse(data[5])));
            }

            Console.WriteLine("Goals loaded!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
        Console.ReadKey();
    }
}
