using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.GameLogic
{
    internal class Game
    {
        public void GameStart() 
        {
            Console.WriteLine("Welcome to number guessing game!\n\n");
            Console.WriteLine("I'm thinking of a number between 1 and 100.");
            Console.WriteLine("You have chances according to the difficulty chosen to guess the correct number.\n\n" +
                                "Please select the difficult level");

            int difficulty = GameDifficulty();
            ProcessPlays(difficulty);
        }

        private int GameDifficulty()
        {
            Console.WriteLine($"1. EASY: ({(int)DifficultyLevel.Easy} chances)\n" +
                    $"2. MEDIUM: ({(int)DifficultyLevel.Medium} chances)\n" +
                    $"3. HARD: ({(int)DifficultyLevel.Hard} chances)");

            Console.WriteLine("\n\nEnter your choice: ");

            int difficultyChosen = Convert.ToInt32(Console.ReadLine());

            int difficultyLevel = 0;

            switch (difficultyChosen)
            {
                case 1: difficultyLevel = (int)DifficultyLevel.Easy; break;
                case 2: difficultyLevel = (int)DifficultyLevel.Medium; break;
                case 3: difficultyLevel = (int)DifficultyLevel.Hard; break;
            }

            return difficultyLevel;
        }

        private void ProcessPlays(int difficulty)
        {
            Random random = new Random();
            int number = random.Next(1, 100);

            Console.WriteLine("Let's start the game!");

            int guessCounter = 1;
            bool isGuessed = false;
            while (difficulty >= guessCounter)
            {
                Console.WriteLine("Enter your guess: ");
                int myGuess = Convert.ToInt32(Console.ReadLine());

                if (myGuess == number)
                {
                    Console.WriteLine($"Congrat's! You guessed the correct number {number} in {guessCounter} atteempt(s)!");
                    isGuessed = true;
                    break;
                }
                else
                {
                    if (number > myGuess) Console.WriteLine($"Incorrect! The number is greater than {myGuess}.");
                    else Console.WriteLine($"Incorrect! The number is less than {myGuess}.");

                    guessCounter++;
                };
            }

            if (isGuessed == false) Console.WriteLine($"You are out of attempts! My number was {number}. Better luck next time!");
        }
    }
}
