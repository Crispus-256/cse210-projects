using System;
// Cycling.cs
public class Cycling : Activity
{
    private double _speed; // Speed in mph or kph

    // Constructor
    public Cycling(string date, int lengthInMinutes, double speed) : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    // Override methods
    public override double GetDistance()
    {
        return (_speed * GetLengthInMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}