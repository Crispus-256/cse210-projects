using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("What is your magic number?");
        //int magicNumber = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        HashSet<string> guessedNumbers = new HashSet<string>();

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.WriteLine("What is your guess?");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("lower");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
            guessedNumbers.Add(guess.ToString());
            Console.WriteLine("You have guessed: " + string.Join(", ", guessedNumbers));
        }
        
    }
}