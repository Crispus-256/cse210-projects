using System;

public class SimpleGoal : Goal
{
    // Private member variable
    private bool _isComplete;

    // Constructor
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Public property for completion status
    public bool IsCompleteFlag
    {
        get { return _isComplete; }
        set { _isComplete = value; }
    }

    // Override methods
    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{ShortName},{Description},{Points},{_isComplete}";
    }
}