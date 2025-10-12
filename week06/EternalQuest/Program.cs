using System;

class Program
{
    static void Main(string[] args)
    {
        /*
         * This program implements the following features to exceed core requirements:
         * 1. A leveling system where users gain levels based on their score.
         * 2. Badges awarded for reaching specific milestones (e.g., Level 1 Achiever, Master Quester).
         * 3. Negative goals that deduct points for bad habits.
         */
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}