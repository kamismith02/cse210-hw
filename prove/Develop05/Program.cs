using System;
/*
I succeeded meeting all regular requirements of the program.
As well as exceeding the requirements by adding a level up function. The user will 
increase in points as regular and then level up after reaching 1000 points.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}