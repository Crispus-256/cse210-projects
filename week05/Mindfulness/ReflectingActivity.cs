using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    
    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
        _prompts = new List<string>();
        _questions = new List<string>();
    }

    public void Run()
    {
        
    }

    private string GetRandomPrompt()
    {
        return ""; 
    }

    private string GetRandomQuestion()
    {
        return ""; 
    }

    private void DisplayQuestions()
    {
        
    }
}