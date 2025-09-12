using System; 

class PromptGenerator // Generates random prompts for journal entries
{
    private List<string> _prompts = new List<string> // Predefined set of prompt questions
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt() // Return a single prompt chosen at random
    {
        // Create a Random instance (seeded from system time)
        // Note: creating a new Random per call can produce repeated values if called rapidly.
        Random random = new Random();
        int index = random.Next(_prompts.Count); // Pick a random index within the list
        return _prompts[index]; // Return the selected prompt string
    }
}