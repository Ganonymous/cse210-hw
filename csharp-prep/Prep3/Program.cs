using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber;
        string repeat;
        do
        {
            magicNumber = randomGenerator.Next(1, 100);
            int guess;
            int guessesMade = 0;

            do
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessesMade++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            } while (guess != magicNumber);

            Console.WriteLine($"It took you {guessesMade} tries.");

            Console.Write("Would you like to play again? ");
            repeat = Console.ReadLine();
        } while (repeat == "yes");
    }
}