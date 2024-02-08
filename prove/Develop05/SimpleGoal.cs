public class SimpleGoal : Goal
{
    private bool _isComplete;
    
    public SimpleGoal(string name, string description, int points) :base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        
    }
    public override bool IsComplete()
    {
        throw new NotImplementedException();
    }
    public override string GetStringRepresentation()
    {
        throw new NotImplementedException();
    }
}