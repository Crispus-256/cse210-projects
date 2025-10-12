using System;

public abstract class Goal
{
    // Private member variables
    private string _shortName;
    private string _description;
    private int _points;

    // Constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Public properties for encapsulation
    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;

    // Abstract methods
    public abstract void RecordEvent();
    public abstract bool IsComplete();

    // Virtual method for details string
    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    // Abstract method for saving/loading
    public abstract string GetStringRepresentation();
}