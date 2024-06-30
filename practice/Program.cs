using System;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                Console.WriteLine("Welcome to the Number Guessing Game!");
                Console.WriteLine("Choose a difficulty level:");
                Console.WriteLine("1. Easy (1-50)");
                Console.WriteLine("2. Medium (1-100)");
                Console.WriteLine("3. Hard (1-200)");

                int maxNumber = 100;
                switch (Console.ReadLine())
                {
                    case "1":
                        maxNumber = 50;
                        break;
                    case "2":
                        maxNumber = 100;
                        break;
                    case "3":
                        maxNumber = 200;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Defaulting to Medium.");
                        break;
                }

                Random random = new Random();
                int numberToGuess = random.Next(1, maxNumber + 1);
                int userGuess = 0;
                int numberOfGuesses = 0;

                Console.WriteLine($"I have selected a number between 1 and {maxNumber}. Try to guess it!");

                while (userGuess != numberToGuess)
                {
                    Console.Write("Enter your guess: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out userGuess))
                    {
                        numberOfGuesses++;

                        switch (userGuess.CompareTo(numberToGuess))
                        {
                            case -1:
                                Console.WriteLine("Too low! Try again.");
                                break;
                            case 1:
                                Console.WriteLine("Too high! Try again.");
                                break;
                            case 0:
                                Console.WriteLine($"Congratulations! You guessed the number in {numberOfGuesses} attempts.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }

                Console.WriteLine("Do you want to play again? (y/n)");
                playAgain = Console.ReadLine().ToLower() == "y";
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
