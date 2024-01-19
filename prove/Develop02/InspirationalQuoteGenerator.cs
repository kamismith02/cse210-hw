public class InspirationalQuoteGenerator
{
    private List<string> _quotes;

    public InspirationalQuoteGenerator()
    {
        // Initialize the list of inspirational quotes
        _quotes = new List<string>
        {
            "Believe you can and you're halfway there. -Theodore Roosevelt",
            "The only way to do great work is to love what you do. -Steve Jobs",
            "Your time is limited, don't waste it living someone else's life. -Steve Jobs",
            // Add more quotes as needed
        };
    }

    public string GetRandomQuote()
    {
        Random random = new Random();
        return _quotes[random.Next(_quotes.Count)];
    }
}