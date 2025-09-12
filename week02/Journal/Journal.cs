using System; // Provides Console and basic system types
using System.Text.Json; // Provides JSON serialization/deserialization

class Journal // Manages a collection of journal entries
{
    private List<Entry> _entries = new List<Entry>(); // In-memory list of entries

    public void AddEntry(Entry newEntry) // Add a new entry to the journal
    {
        _entries.Add(newEntry); // Append the provided Entry object to the list
    }

    public void DisplayAll() // Display all entries to the console
    {
        if (_entries.Count == 0) // If there are no entries
        {
            Console.WriteLine("The journal is empty."); // Inform the user
            return; // Nothing to display
        }

        foreach (Entry entry in _entries) // Iterate over stored entries
        {
            entry.Display(); // Use Entry.Display() to print each entry
        }
    }

    public void SaveToJson(string filename) // Save all entries to a JSON file
    {
        // Serialize entries to a pretty-printed JSON string
        string jsonString = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
        // Write the JSON string to the specified file path
        File.WriteAllText(filename, jsonString);
    }

    public void LoadFromJson(string filename) // Load entries from a JSON file
    {
        if (!File.Exists(filename)) // If the file does not exist
        {
            Console.WriteLine("File not found."); // Inform the user
            return; // Do not attempt to read
        }

        // Read the entire file content as JSON
        string jsonString = File.ReadAllText(filename);
        // Deserialize JSON back into a list of Entry objects; fallback to empty list if null
        _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString) ?? new List<Entry>();
    }
}