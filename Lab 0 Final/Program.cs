using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_0_Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
        double num1, num2;

        // User input for num1 that has to be greater than 0
        num1 = GetUserInput("Enter a Small number: ", x => x > 0);

        // Get user input for num2 which has to be greater than num1
        num2 = GetUserInput("Enter a Large number (greater than num1): ", x => x > num1);

        Console.WriteLine("The difference between the numbers is: " + (num2 - num1));

            // Create a List to hold all the numbers between num1 and num2
            List<double> numbersList = new List<double>();
            for (double i = num1; i <= num2; i++)
            {
                numbersList.Add(i);
            }

    // Write the numbers to the "numbers.txt" file in reverse order
    WriteNumbersToFile(numbersList, "numbers.txt");

    // Read the numbers including and between the users input values and calculates the sum
    double sum = ReadNumbersFromFileAndCalculateSum("numbers.txt");
    Console.WriteLine("The sum of numbers read from 'numbers.txt' is: " + sum);

            // This prints the prime numbers between the users input values
            Console.WriteLine("Prime numbers between " + num1 + " and " + num2 + ":");
            foreach (double num in numbersList)
            {
                if (IsPrime(num))
                {
                    Console.WriteLine(num);
                }
            }
        }

        // Method to get and validate correct user input
        static double GetUserInput(string prompt, Func<double, bool> validate)
{
    double input;
    while (true)
    {
        Console.Write(prompt);
        if (double.TryParse(Console.ReadLine(), out input) && validate(input))
        {
            return input;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}

// Method to write numbers to the numbers text file in reverse order
static void WriteNumbersToFile(List<double> numbers, string fileName)
{
    using (StreamWriter writer = new StreamWriter(fileName))
    {
        for (int i = numbers.Count - 1; i >= 0; i--)
        {
            writer.WriteLine(numbers[i]);
        }
    }
    Console.WriteLine("Numbers have been written to '" + fileName + "' in reverse order.");
}

// Method to read numbers from the numbers text file and calculate their sum
static double ReadNumbersFromFileAndCalculateSum(string fileName)
{
    double sum = 0;
    using (StreamReader reader = new StreamReader(fileName))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            if (double.TryParse(line, out double number))
            {
                sum += number;
            }
        }
    }
    return sum;
}

// Method to check if a number is prime
static bool IsPrime(double number)
{
    if (number <= 1)
    {
        return false;
    }
    for (int i = 2; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0)
        {
            return false;
        }
    }
    return true;
}
    }
}