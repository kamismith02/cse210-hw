using System.Configuration.Assemblies;
using System.Globalization;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private const int _pointsPerLevel = 1000;
    
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    exit = true;
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points and you're at level {_level}.");
        Console.WriteLine();
    }
    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        int number = 0;
        foreach (var goal in _goals)
        {
            number += 1;
            Console.WriteLine($"{number}. {goal.GetShortName()}");
        }
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are: ");
        
        int number = 0;
        foreach (var goal in _goals)
        {
            number += 1;
                Console.Write($"{number}. ");

            string complete = "";

            if (goal.IsComplete() == true)
            {
                complete = "X";
            }
            else
            {
                complete = " ";
            }

            Console.WriteLine($"[{complete}] {goal.GetShortName()} ({goal.GetDescription()}) {goal.GetDetailsString()}");
        }

        Console.WriteLine();
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string amount = Console.ReadLine();
        int points = int.Parse(amount);

        switch (goalType)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }

        Console.WriteLine();
    }
    public void RecordEvent()
    {
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        string goalDone = Console.ReadLine();
        int done = int.Parse(goalDone) - 1;
        Goal goal = _goals[done];

        goal.RecordEvent();
        _score += goal.GetPoints();
        int earned = goal.GetPoints();

        if (goal is ChecklistGoal && goal.IsComplete())
        {
            _score += (goal as ChecklistGoal).GetBonus(); // Add bonus points if the checklist goal is complete
            earned += (goal as ChecklistGoal).GetBonus();
        }

        Console.WriteLine($"Congratulations! You have earned {earned} points!");

        // Check for level up
        int newLevel = _score / _pointsPerLevel + 1; // Add 1 to start at level 1
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"Congratulations! You've reached level {_level}!");
        }

        Console.WriteLine($"You now have {_score} points.");
        Console.WriteLine();
    }
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (var goal in _goals)
            {
                // Concatenate goal properties into a single string
                string goalInfo = goal.GetStringRepresentation();
                // Write the string to the file
                writer.WriteLine(goalInfo);
            }
        }

        Console.WriteLine();
    }
    public void LoadGoals()
    {
        _goals.Clear(); // Clear existing goals before loading
        Console.Write("What is the filename for the goal file? ");
        string file = Console.ReadLine();

        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':'); // Split the line at the colon
                string type = parts[0]; // Extract the goal type
                string[] goalInfo = parts[1].Split(','); // Split the goal information
                string name = goalInfo[0];
                string description = goalInfo[1];
                int points = int.Parse(goalInfo[2]);
                bool isComplete = goalInfo[3] == "True";

                Goal goal;
                switch (type)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(name, description, points);
                        if (isComplete)
                        {
                            ((SimpleGoal)goal).RecordEvent(); // Mark as completed
                        }
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(name, description, points);
                        break;
                    case "ChecklistGoal":
                        int bonus = int.Parse(goalInfo[3]);
                        int target = int.Parse(goalInfo[4]);
                        int amountCompleted = int.Parse(goalInfo[5]);
                        goal = new ChecklistGoal(name, description, points, target, bonus);
                        ((ChecklistGoal)goal).RecordEvent(); // Record the amount completed
                        for (int i = 1; i < amountCompleted; i++)
                        {
                            ((ChecklistGoal)goal).RecordEvent(); // Record additional completions
                        }
                        break;
                    default:
                        goal = null;
                        break;
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }
    }
}