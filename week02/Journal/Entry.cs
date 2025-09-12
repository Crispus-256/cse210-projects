using System;
class Entry // Represents a single journal entry
{
    public string Timestamp { get; set; } // Includes both date and time
    public string PromptText { get; set; } // Prompt that generated this journal entry
    public string EntryText { get; set; } // The user's response or journal content

    public Entry(string timestamp, string promptText, string entryText) // Initialize properties from parameters
    {
        // Set the timestamp, prompt, and entry text from constructor parameters
        Timestamp = timestamp; // Includes both date and time
        PromptText = promptText; // Prompt for this entry
        EntryText = entryText; // Content of the entry
    }

    public void Display() // Write entry details to the console
    {
        // Display the stored timestamp, prompt, and response to the console
        Console.WriteLine($"Timestamp: {Timestamp}"); // Includes both date and time
        Console.WriteLine($"Prompt: {PromptText}"); // Shows the prompt used
        Console.WriteLine($"Response: {EntryText}"); // Shows the entry text
        Console.WriteLine(); // Blank line to separate entries when displaying multiple
    }
}