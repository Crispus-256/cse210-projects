using System;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can.")
    {
        _count = 0;
        _prompts = new List<string>();
    }

    public void Run()
    {
        
    }

    private string GetRandomPrompt()
    {
        return ""; 
    }

    private List<string> GetListFromUser()
    {
        return new List<string>(); 
    }
}