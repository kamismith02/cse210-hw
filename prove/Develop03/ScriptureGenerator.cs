public class ScriptureGenerator
{
    private List<Scripture> _scriptures;

    public ScriptureGenerator()
    {
        // Initialize the list of scriptures
        _scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world..."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
            // Add more scriptures as needed
        };
    }

        public Scripture GetRandomScripture()
    {
        Random random = new Random();
        return _scriptures[random.Next(_scriptures.Count)];
    }
}