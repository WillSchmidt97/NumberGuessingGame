using NumberGuessingGame.GameLogic;

namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to number guessing game!\n\n");
            Console.WriteLine("Let's make it simple, I will think about a number from 1 to 100 and you will have to guess the number I chose.");
            Console.WriteLine("We have three levels of difficulty: \n");

            Console.WriteLine($"HARD: {DifficultyLevel.Easy} chances to guess the number\n" +
                                $"MEDIUM: {DifficultyLevel.Medium} chances to guess the number\n" +
                                $"HARD: {DifficultyLevel.Hard} chances to guess the number.");

            Console.WriteLine("If you guess the number before you are out of tries, you win." +
                                "But you ");
        }
    }
}