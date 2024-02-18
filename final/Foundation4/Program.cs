using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Time to exercise! Let's get moving!");

        Activity runningActivity = new Running(new DateTime(2024, 2, 20), 20, 3.1);
        Activity cyclingActivity = new Cycling(new DateTime(2024, 5, 2), 40, 10);
        Activity swimmingActivity = new Swimming(new DateTime(2024, 8, 15), 60, 50);

        Activity[] activities = { runningActivity, cyclingActivity, swimmingActivity };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }

    }
}