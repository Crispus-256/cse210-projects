using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("Please select an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflecting Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Exit");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            BreathingActivity breathingActivity = new BreathingActivity();
            breathingActivity.Run();
        }
        else if (choice == "2")
        {
            ReflectingActivity reflectingActivity = new ReflectingActivity();
            reflectingActivity.Run();
        }
        else if (choice == "3")
        {
            ListingActivity listingActivity = new ListingActivity();
            listingActivity.Run();
        }
        else if (choice == "4")
        {
            Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
        }
        else
        {
            Console.WriteLine("Invalid choice. Please restart the program and select a valid option.");
        }
    }
}