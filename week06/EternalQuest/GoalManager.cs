using System;
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private List<string> _badges;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _badges = new List<string>();
    }

    public void Start()
    {
        Console.WriteLine("Welcome to Eternal Quest!");
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Create New Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nScore: {_score}");
        Console.WriteLine($"Level: {_level}");

        // Update level based on score
        _level = (_score / 1000) + 1;

        Console.WriteLine("Badges Earned:");
        if (_badges.Count == 0)
        {
            Console.WriteLine("No badges yet. Keep working on your goals!");
        }
        else
        {
            foreach (var badge in _badges)
            {
                Console.WriteLine($"- {badge}");
            }
        }

        Console.WriteLine("Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {(_goals[i].IsComplete() ? "[X]" : "[ ]")} {(_goals[i].GetDetailsString())}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nWhat type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (Lose Points)");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Target: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? Enter the number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            goal.RecordEvent();

            if (goal is NegativeGoal negativeGoal)
            {
                _score -= negativeGoal.Points;
                Console.WriteLine($"You lost {negativeGoal.Points} points for '{negativeGoal.ShortName}'.");
            }
            else
            {
                _score += goal.Points;

                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
                {
                    _score += checklistGoal.Bonus;
                }

                // Award badges for milestones
                if (_score >= 1000 && !_badges.Contains("Level 1 Achiever"))
                {
                    _badges.Add("Level 1 Achiever");
                }
                if (_score >= 5000 && !_badges.Contains("Level 5 Achiever"))
                {
                    _badges.Add("Level 5 Achiever");
                }
                if (_score >= 10000 && !_badges.Contains("Master Quester"))
                {
                    _badges.Add("Master Quester");
                }

                Console.WriteLine("Event recorded!");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            foreach (var badge in _badges)
            {
                writer.WriteLine($"Badge:{badge}");
            }
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        _badges.Clear();
        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);

        int lineIndex = 2;
        while (lineIndex < lines.Length && lines[lineIndex].StartsWith("Badge:"))
        {
            _badges.Add(lines[lineIndex].Substring(6));
            lineIndex++;
        }

        for (; lineIndex < lines.Length; lineIndex++)
        {
            string line = lines[lineIndex];
            string[] parts = line.Split(':');
            string type = parts[0];
            string[] details = parts[1].Split(',');

            switch (type)
            {
                case "SimpleGoal":
                    var simpleGoal = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
                    simpleGoal.IsCompleteFlag = bool.Parse(details[3]);
                    _goals.Add(simpleGoal);
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                    break;
                case "ChecklistGoal":
                    var checklistGoal = new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[4]), int.Parse(details[5]));
                    checklistGoal.AmountCompleted = int.Parse(details[3]);
                    _goals.Add(checklistGoal);
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(details[0], details[1], int.Parse(details[2])));
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}