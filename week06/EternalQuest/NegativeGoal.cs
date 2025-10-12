using System;

public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // No state change needed; just deduct points.
    }

    public override bool IsComplete()
    {
        return false; // Negative goals are never "complete"
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{ShortName},{Description},{Points}";
    }
}