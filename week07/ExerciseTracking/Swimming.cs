using System;
// Swimming.cs
public class Swimming : Activity
{
    private int _laps; // Number of laps

    // Constructor
    public Swimming(string date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    // Override methods
    public override double GetDistance()
    {
        // Each lap is 50 meters (0.05 km or 0.031 miles)
        return _laps * 50 / 1000; // Distance in kilometers
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / GetDistance();
    }
}