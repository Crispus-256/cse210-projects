using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal(); // In-memory journal to store entries
        PromptGenerator promptGenerator = new PromptGenerator(); // Generates prompts for entries

        bool running = true; // Controls the main program loop
        while (running)
        {
            // Display menu options
            Console.WriteLine("\n--- Journal Program ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a JSON file");
            Console.WriteLine("4. Load the journal from a JSON file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine(); // Read user menu selection

            switch (choice)
            {
                case "1":
                    string randomPrompt = promptGenerator.GetRandomPrompt(); // Get a random prompt
                    Console.WriteLine($"\nPrompt: {randomPrompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine(); // Read the user's journal text

                    // Create a new entry with current timestamp (Includes both date and time)
                    Entry newEntry = new Entry(DateTime.Now.ToString(), randomPrompt, response);
                    journal.AddEntry(newEntry); // Add the new entry to the journal
                    break;

                case "2":
                    journal.DisplayAll(); // Print all saved entries to the console
                    break;

                case "3":
                    Console.Write("Enter filename to save (e.g., journal.json): ");
                    string saveFile = Console.ReadLine(); // Filename to save JSON to
                    journal.SaveToJson(saveFile); // Persist entries to disk
                    Console.WriteLine("Journal saved successfully.");
                    break;

                case "4":
                    Console.Write("Enter filename to load (e.g., journal.json): ");
                    string loadFile = Console.ReadLine(); // Filename to load JSON from
                    journal.LoadFromJson(loadFile); // Load entries from disk into memory
                    Console.WriteLine("Journal loaded successfully.");
                    break;

                case "5":
                    running = false; // Exit the loop and end program
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again."); // Handle bad input
                    break;
            }
        }
    }
}