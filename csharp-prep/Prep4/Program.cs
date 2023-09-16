using System;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        List<int> numbers = new List<int>();
        int nextNumber;

        do
        {
            Console.Write("Enter a number: ");
            nextNumber = int.Parse(Console.ReadLine());
            if (nextNumber != 0)
            {
                numbers.Add(nextNumber);
            }
        } while (nextNumber != 0);

        if (numbers.Count != 0)
        {
            numbers.Sort(); //sorting early to guarantee least-to-greatest order
            int sum = 0;
            int smallestPositive = 0;
            bool smallestPositiveFound = false;

            foreach (int number in numbers)
            {
                sum += number;

                if (number > 0 && !smallestPositiveFound)
                {
                    smallestPositive = number;
                    smallestPositiveFound = true;
                }
            }
            float average = (float)sum / (float)numbers.Count;
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {numbers.Last()}");
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

        }
    }
}