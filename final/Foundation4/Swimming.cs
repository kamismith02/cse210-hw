using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

public class Swimming : Activity
{
    private int _laps;
    
    public Swimming(DateTime date, int durationInMinutes, int laps) : base(date, durationInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000;
    }
    public override double GetSpeed()
    {
        return base.GetDuration() / GetDistance();
    }
    public override double GetPace()
    {
        return 60 / GetSpeed();
    }
    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance: {GetDistance():F2} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}