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

            Console.WriteLine($"EASY: {(int)DifficultyLevel.Easy} chances to guess the number\n" +
                                $"MEDIUM: {(int)DifficultyLevel.Medium} chances to guess the number\n" +
                                $"HARD: {(int)DifficultyLevel.Hard} chances to guess the number.");

            Console.WriteLine("If you guess the number before you are out of tries, you win." +
                                " But you run your tries to zero, I win. So, let's get started?\n\n");

            Console.WriteLine("Type 1 if you want you want it easier, 2 if you want to play the medium level" +
                                " or 3 if you want more challenge: ");

            int difficultyChosen = Convert.ToInt32(Console.ReadLine());

            int difficultyLevel = 0;

            switch (difficultyChosen)
            {
                case 1: difficultyLevel = (int)DifficultyLevel.Easy; break;
                case 2: difficultyLevel = (int)DifficultyLevel.Medium; break;
                case 3: difficultyLevel = (int)DifficultyLevel.Hard; break;
            }

            Random random = new Random();
            int number = random.Next(1, 100);

            Console.WriteLine("Let's get started!");

            int guessCounter = 1;
            bool isGuessed = false;
            while(difficultyLevel >= guessCounter)
            {
                Console.WriteLine("Type your guess: ");
                int myGuess = Convert.ToInt32(Console.ReadLine());

                if (myGuess == number)
                {
                    Console.WriteLine($"Congrat's! You guessed the number {number} using {guessCounter} atteempt(s)!");
                    isGuessed = true;
                    break;
                }
                else guessCounter++;
            }

            if (isGuessed == false) Console.WriteLine($"You are out of attempts! My number was {number}. Better luck next time!");
        }
    }
}