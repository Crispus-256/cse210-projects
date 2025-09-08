using System;

class Program
{
    static void Main(string[] args)
    {

        List<int> numbers = new List<int>();


        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();


            if (int.TryParse(input, out int number))
            {
                if (number == 0)
                {
                    break;
                }
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }


        if (numbers.Count > 0)
        {

            int sum = numbers.Sum();
            Console.WriteLine($"The sum is: {sum}");


            double average = numbers.Average();
            Console.WriteLine($"The average is: {average}");


            int max = numbers.Max();
            Console.WriteLine($"The largest number is: {max}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }


        if (numbers.Count > 0)
        {

            int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(0).Min();
            if (smallestPositive > 0)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }
            else
            {
                Console.WriteLine("There are no positive numbers in the list.");
            }


            List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();
            Console.WriteLine("The sorted list is:");
            foreach (int num in sortedNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}