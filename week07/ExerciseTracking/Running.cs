using System;
// Running.cs
public class Running : Activity
{
    private double _distance; // Distance in miles or kilometers

    // Constructor
    public Running(string date, int lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    // Override methods
    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / _distance;
    }
}