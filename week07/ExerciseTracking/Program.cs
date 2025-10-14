// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold activities
        List<Activity> activities = new List<Activity>();

        // Add activities to the list
        activities.Add(new Running("03 Nov 2022", 30, 3.0)); // Distance in miles
        activities.Add(new Cycling("04 Nov 2022", 45, 12.0)); // Speed in mph
        activities.Add(new Swimming("05 Nov 2022", 60, 40)); // Number of laps

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary(false)); // Use imperial units
            Console.WriteLine(activity.GetSummary(true));  // Use metric units
        }
    }
}