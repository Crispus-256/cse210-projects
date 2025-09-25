using System;

// Creativity and Exceeding Requirements:
// 1. The program hides multiple words at a time (3 words per iteration) instead of just one
//     and if there are fewer than 3 words left to hide, it hides all remaining words.
// 2. It ensures that only non-hidden words are selected for hiding, avoiding redundant operations.
// 3. The program could be extended to load scriptures from a file or a library of scriptures.
// 4. The design allows for easy addition of new features, such as tracking user progress or saving memorization sessions.

class Program
{

    static void Main(string[] args)
    {
        
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

    
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                break; 
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break; 
            }

            scripture.HideRandomWords(3); 
        }

        Console.WriteLine("All words are now hidden. Thank you for using the Scripture Memorizer!");
    }
}