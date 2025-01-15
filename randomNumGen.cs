// Earl Lamier
// Humber NET 22 - Advance C# Cohort 7
// January 14, 2025

/* Requirements
Question 3
5 Points
Write a code which fulfills below requirements:
1)   A method which returns a random integer between 1 to 10000 using Func. This method should return the number. Use Lamba expressions.
2)   A method which could take in a Func<int> and return a string which outputs "The Generates Number is: {number"}
3)   Implement this using Task Factory and use ContinueWith to Chanin these two methods.
5)   Final result which is passed from the second method needs to be printed using Console.WriteLine
*/

using System;
using System.Threading.Tasks;

class Program
{
    // Method 1: Returns a random number between 1 and 10,000
    public static Func<int> GenerateRandomNumber = () =>
    {
        Random random = new Random();
        return random.Next(1, 10001); // Random number between 1 and 10,000
    };

    // Method 2: Takes a Func<int> and returns a formatted string
    public static Func<Func<int>, string> GenerateMessage = (generateNumber) =>
    {
        int number = generateNumber();
        return $"The generated number is: {number}";
    };

    static void Main(string[] args)
    {
        // Using Task Factory to chain methods
        Task.Factory.StartNew(() =>
        {
            // First method - Generate a random number
            return GenerateRandomNumber();
        })
        .ContinueWith(task =>
        {
            // Second method - Generate the message using the random number
            string result = GenerateMessage(GenerateRandomNumber);
            
            Console.WriteLine(result);
        }).Wait();
    }
}
