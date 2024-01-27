using System;
using System.Formats.Asn1;

/*I succeeded meeting all regular requirments of the program.
As well as exceeding the requirements by adding a random scripture generator so the 
program chooses a random scripture from a list to display. I also updated it so it
only hides words that weren't already hidden.*/

class Program
{
    static void Main(string[] args)
    {
        ScriptureGenerator scriptureGenerator = new ScriptureGenerator();

        // Getting a random scripture
        Scripture randomScripture = scriptureGenerator.GetRandomScripture();

        while (!randomScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(randomScripture.GetDisplayText());
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "quit")
                break;

            randomScripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(randomScripture.GetDisplayText());
    }
}