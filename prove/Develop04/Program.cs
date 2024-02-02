using System;
/*
I succeeded meeting all regular requirements of the program.
As well as exceeding the requirements by adding a log of the amount of activities that
have been performed in total and displaying the amount to the user each time the menu 
comes up to ask the user about going again.
*/

class Program
{
    private static int _totalActivities = 0;
    static void Main(string[] args)
    {
        string answer = "5";

        do
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");

            Console.Write("Select a choice from the menu: ");
            answer = Console.ReadLine();
            Console.Clear();

            if (answer == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
                LogActivity();
            }
            else if (answer == "2")
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.Run();
                LogActivity();
            }
            else if (answer == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();
                LogActivity();
            }

            Console.WriteLine($"Total activities performed: {_totalActivities}");
        } while (answer != "4");
    }

    private static void LogActivity()
    {
        _totalActivities++;
    }
}