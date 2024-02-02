public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear you mind and focus on your breathing.";
        _duration = 50;
    }
    
    public void Run()
    {
        DisplayStartingMessage();

        for (int i = 0; i < _duration; i +=10)
        {
            Console.Write("Breathe in...");
            ShowCountDown(5);
            Console.Write("Now breathe out...");
            ShowCountDown(5);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}