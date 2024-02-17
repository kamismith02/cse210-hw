using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Let's plan some fantastic events!\n");

        List<Event> events = new List<Event>();

        Address address1 = new Address("1122 Main St", "Big City", "UT", "USA");
        Lecture lecture = new Lecture("Software Development", "Introduction to C#", new DateTime(2024, 2, 20), new TimeSpan(14, 0, 0), address1, "Adam Carter", 50);
        events.Add(lecture);

        Address address2 = new Address("3344 Center St", "Small Town", "ON", "Canada");
        Reception reception = new Reception("Mark and Mary's Wedding", "Celebrating Mark and Mary", new DateTime(2024, 5, 20), new TimeSpan(18, 30, 0), address2, "rsvp@example.com");
        events.Add(reception);

        Address address3 = new Address("5566 State St", "Middle Metropolis", "VA", "USA");
        OutdoorGathering gathering = new OutdoorGathering("It's A....", "Gender Reveal for Daisy's Baby", new DateTime(2024, 3, 15), new TimeSpan(12, 0, 0), address3, "Sunny with a high of 80°F");
        events.Add(gathering);

        foreach (Event evt in events)
        {
            Console.WriteLine(evt.GenerateStandardMessage());
            Console.WriteLine();
            Console.WriteLine(evt.GenerateFullMessage());
            Console.WriteLine();
            Console.WriteLine(evt.GenerateShortDescription());
            Console.WriteLine("\n---------------------------------------");
            Console.WriteLine();
        }
    }
}