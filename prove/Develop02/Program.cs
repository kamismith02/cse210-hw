using System;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;

/* I was able to complete all the original requirements of the assignment.
I also exceed the requirements by... */

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        string answer = "6";

        do
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");
            answer = Console.ReadLine();
            
            if (answer == "1")
            {
                Entry newEntry = new Entry();
                journal.AddEntry(newEntry);
            }
            else if (answer == "2")
            {
                journal.DisplayAll();
            }
            else if (answer == "3")
            {
                Console.WriteLine("What is the filename? ");
                string loadFilename = Console.ReadLine();
                journal.LoadFromFile(loadFilename);
            }
            else if (answer == "4")
            {
                Console.WriteLine("What is the filename? ");
                string saveFilename = Console.ReadLine();
                journal.SaveToFile(saveFilename);
            }
        } while (answer != "5");
    }
}