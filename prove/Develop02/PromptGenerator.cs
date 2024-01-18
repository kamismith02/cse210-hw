public class PromptGenerator
{
    public List<string> _prompts= new List<string>
    {
        "Who was the most interesting person I interacted with today?", 
        "What am I grateful for today?",
        "How did I see the hand of the Lord in my life today?",
        "What was the most challenging thing I faced today?",
        "What was the weather like today?",
        "How can I make tomorrow even better?"
    };

    public string GetRandomPrompt()
    {
        var random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        return prompt;
    }
}