public class Cycling : Activity
{
    private double _speed;
    
    public Cycling(DateTime date, int durationInMinutes, double speed) : base(date, durationInMinutes)
    {
        _speed = speed;
    }
    public override double GetSpeed()
    {
        return _speed;
    }
    public override double GetPace()
    {
        return 60 / _speed;
    }
    public override string GetSummary()
    {
        return base.GetSummary() + $" - Speed: {_speed:F1} mph, Pace: {GetPace():F1} min per mile";
    }
}