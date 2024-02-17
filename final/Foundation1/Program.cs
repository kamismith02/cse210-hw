using System;
/* I am currently working on the Foundation 4 Final Project. I was able to 
complete the first two foundation programs and get them up and working. 
The first program holds details and comments for YouTube videos and displays 
the information to the user. The second program holds details for a product 
ordering system and displays order and customer information to the user. 
Everything should be accounted for that was in the project description. 
I will continue working to complete the final two programs in the coming week.
*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome! Let's watch some videos!");
        Console.WriteLine();

        List<Video> videos = new List<Video>();

        Video video1 = new Video("Demo Part 1", "Amy Berry", 15);
        video1.AddComment("Alice", "Great tutorial!");
        video1.AddComment("Bob", "Very helpful, thanks!");
        video1.AddComment("Charlie", "I learned a lot, thank you!");
        videos.Add(video1);

        Video video2 = new Video("Demo Part 2", "Charlie Dean", 45);
        video2.AddComment("Damon", "This was so good!");
        video2.AddComment("Ellie", "How did you do that last part?");
        video2.AddComment("Fred", "That makes so much more sense!");
        videos.Add(video2);

        Video video3 = new Video("Demo Part 3", "Emmett Fitz", 60);
        video3.AddComment("Greg", "Thanks for sharing!");
        video3.AddComment("Harley", "<3 <3 <3");
        video3.AddComment("Isaac", "Great job.");
        videos.Add(video3);

        Video video4 = new Video("Demo Part 4", "Grace Hughes", 25);
        video4.AddComment("Jacob", "So cool!");
        video4.AddComment("Kelsey", "Love it.");
        video4.AddComment("Lilly", "I'm still not quite getting it...");
        videos.Add(video4);

        foreach (Video video in videos)
        {
            video.DisplayInfo();
            Console.WriteLine("--------");
            Console.WriteLine();
        }

    }
}