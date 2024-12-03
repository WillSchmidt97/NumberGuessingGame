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
                                "But you run your tries to zero, I win. So, let's get started?\n\n");

            Console.WriteLine("Type 1 if you want you want it easier, 2 if you want to play the medium level" +
                                "or 3 if you want more challenge: ");

            int difficultyChosen = Convert.ToInt32(Console.ReadLine());

            int difficultyLevel;

            switch (difficultyChosen)
            {
                case 1: difficultyLevel = (int)DifficultyLevel.Easy; break;
                case 2: difficultyLevel= (int)DifficultyLevel.Medium; break;
                case 3: difficultyLevel=(int)DifficultyLevel.Hard; break;
            }
        }
    }
}