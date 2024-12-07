using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingGame.GameLogic
{
    internal class Game
    {
        private int difficultyLevel;
        public void GameStart() 
        {
            Console.WriteLine("Welcome to number guessing game!");
            Console.WriteLine("I'm thinking of a number between 1 and 100.");

            var gameMode = GameMode();
            
            if (gameMode == 1)
            {
                Console.WriteLine("You have chances according to the difficulty chosen to guess the correct number.\n\n" +
                    "Please select the difficult level");

                GameDifficulty();
            }

            ProcessPlays(gameMode);
        }

        public int GameMode()
        {
            Console.WriteLine("Yuou have two ways of playing the game:\n" +
                            "1: You will have changes according to the difficulty chosen. When you get out of chances, the game finishes." +
                            "2: You decide when to stop.\n\n" +
                            "So, which way you want to play? (Please, type 1 or 2): ");
            var gameMode = Int32.Parse(Console.ReadLine());

            return gameMode;
        }

        private void GameDifficulty()
        {
            Console.WriteLine($"1. EASY: ({(int)DifficultyLevel.Easy} chances)\n" +
                    $"2. MEDIUM: ({(int)DifficultyLevel.Medium} chances)\n" +
                    $"3. HARD: ({(int)DifficultyLevel.Hard} chances)");

            Console.WriteLine("\n\nEnter your choice: ");

            int difficultyChosen = Convert.ToInt32(Console.ReadLine());

            switch (difficultyChosen)
            {
                case 1: this.difficultyLevel = (int)DifficultyLevel.Easy; break;
                case 2: this.difficultyLevel = (int)DifficultyLevel.Medium; break;
                case 3: this.difficultyLevel = (int)DifficultyLevel.Hard; break;
            }
        }

        private void ProcessPlays(int gameMode)
        {
            Random random = new Random();
            int number = random.Next(1, 100);

            Console.WriteLine("Let's start the game!");

            int guessCounter = 1;
            bool isGuessed = false;
            var stop = false;
            string choiceToStop = "";
            while (gameMode == 1 ? 
                this.difficultyLevel >= guessCounter
                                    : !stop)
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

                    if (gameMode == 2)
                    {
                        Console.WriteLine("Do you want to stop? If so type Y/y: ");
                        choiceToStop = Console.ReadLine().ToLower();

                        if (choiceToStop == "y") stop = true;
                    }

                    guessCounter++;
                };
            }

            if (isGuessed == false) Console.WriteLine($"You are out of attempts! My number was {number}. Better luck next time!");
        }
    }
}
