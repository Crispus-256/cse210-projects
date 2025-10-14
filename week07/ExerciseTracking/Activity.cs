using System;
// Activity.cs
public abstract class Activity
{
    // Private member variables
    private string _date;
    private int _lengthInMinutes;

    // Constructor
    public Activity(string date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    // Getter for date
    public string GetDate()
    {
        return _date;
    }

    // Getter for length in minutes
    public int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance(); // Distance in miles or kilometers
    public abstract double GetSpeed();    // Speed in mph or kph
    public abstract double GetPace();     // Pace in min/mile or min/km

    // Summary method defined in the base class
    public string GetSummary(bool useMetric)
    {
        string unit = useMetric ? "km" : "miles";
        string speedUnit = useMetric ? "kph" : "mph";

        return $"{_date} {GetType().Name} ({_lengthInMinutes} min)- Distance {GetDistance():F1} {unit}, Speed {GetSpeed():F1} {speedUnit}, Pace: {GetPace():F2} min per {unit}";
    }
}