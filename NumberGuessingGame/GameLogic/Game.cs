using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using NumberGuessingGame.Models;

namespace NumberGuessingGame.GameLogic
{
    internal class Game
    {
        private int _difficultyLevel;
        private int _gameMode;
        private int _guessCounter;
        private int _hintsAvailable = 2;
        public void GameStart() 
        {
            Console.WriteLine("Welcome to number guessing game!");
            Console.WriteLine("I'm thinking of a number between 1 and 100.");

            ChosenGameMode();
            
            if (_gameMode == (int)Enums.GameMode.ModeOne)
            {
                Console.WriteLine("You have chances according to the difficulty chosen to guess the correct number.\n\n" +
                    "Please select the difficult level");

                GameDifficulty();
            }

            ProcessPlays();
            
            Console.WriteLine("Now that the game came to an end, tell us your name: ");
            var name = Console.ReadLine();

            // var playerStatus = SetPlayerStats(name);
            // Console.WriteLine(playerStatus);
            // Console.WriteLine("\nPress any key to continue...");
        }

        private void ChosenGameMode()
        {
            Console.WriteLine("You have two ways of playing the game:\n" +
                            "1: You will have chances according to the difficulty chosen. When you get out of chances, the game finishes.\n" +
                            "2: You decide when to stop.\n\n" +
                            "So, which way you want to play? (Please, type 1 or 2): ");
            _gameMode = Int32.Parse(Console.ReadLine());

            while (_gameMode is < 1 or > 2)
            {
                Console.WriteLine("Invalid option. Please, you have to chose option 1 or 2: ");

                _gameMode = Int32.Parse(Console.ReadLine());
            }
        }

        private void GameDifficulty()
        {
            Console.WriteLine($"1. EASY: ({(int)Enums.DifficultyLevel.Easy} chances)\n" +
                    $"2. MEDIUM: ({(int)Enums.DifficultyLevel.Medium} chances)\n" +
                    $"3. HARD: ({(int)Enums.DifficultyLevel.Hard} chances)");

            Console.WriteLine("\n\nEnter your choice: ");

            int difficultyChosen = Convert.ToInt32(Console.ReadLine());

            while(difficultyChosen is > 3 or < 1)
            {
                Console.WriteLine("\nInvalid option. Please type 1 for easy, 2 for medium or 3 for hard.\n" +
                    "Enter your choice: ");

                difficultyChosen = Convert.ToInt32(Console.ReadLine());
            }

            switch (difficultyChosen)
            {
                case 1: this._difficultyLevel = (int)Enums.DifficultyLevel.Easy; break;
                case 2: this._difficultyLevel = (int)Enums.DifficultyLevel.Medium; break;
                case 3: this._difficultyLevel = (int)Enums.DifficultyLevel.Hard; break;
            }
        }

        private void ProcessPlays()
        {
            Random random = new Random();
            int number = random.Next(1, 100);

            Console.WriteLine("Let's start the game!");
            var time = Stopwatch.StartNew();
            
            bool isGuessed = false;
            var stop = false;
            string choiceToStop, hint = "";

            while (_gameMode == (int)Enums.GameMode.ModeOne ? 
                this._difficultyLevel >= _guessCounter
                                    : !stop)
            {
                Console.WriteLine("Enter your guess: ");
                int myGuess = Convert.ToInt32(Console.ReadLine());

                while (myGuess < 1 || myGuess > 100)
                {
                    Console.WriteLine("Invalid number. The number must be from 1 to 100.\n" +
                        "Enter your guess: ");
                    myGuess = Convert.ToInt32(Console.ReadLine());
                }

                if (myGuess == number)
                {
                    time.Stop();
                    int timeToGuess = (int)time.Elapsed.TotalSeconds;

                    Console.WriteLine($"Congrat's! You guessed the correct number {number} in {_guessCounter} atteempt(s)!" +
                                        $"It took {timeToGuess} seconds for you to guess the number.");
                    isGuessed = true;
                    break;
                }
                else
                {
                    if (number > myGuess) Console.WriteLine($"Incorrect! The number is greater than {myGuess}.");
                    else Console.WriteLine($"Incorrect! The number is less than {myGuess}.");

                    if (_hintsAvailable > 0)
                    {
                        Console.WriteLine("Do you want a hint?\n" +
                                            "YES: Press h\n" +
                                            "NO: Just press anything?");

                        hint = Console.ReadLine().ToLower();

                        if (hint == "h")
                            Hints(number, myGuess);
                    }

                    if (_gameMode == 2)
                    {
                        Console.WriteLine("Do you want to stop? If so type Y/y: ");
                        choiceToStop = Console.ReadLine()!.ToLower();

                        if (choiceToStop == "y") stop = true;
                    }

                    _guessCounter++;
                };
            }

            if (isGuessed == false) Console.WriteLine($"You are out of attempts! My number was {number}. Better luck next time!");
        }

        private void Hints(int rightNumber, int chosenNumber)
        {
            if (_hintsAvailable == 2)
            {
                if (rightNumber > 0 && rightNumber <= 50)
                    Console.WriteLine("My number is between 1 and 50");
                else Console.WriteLine("My number is between 51 and 100");

                _hintsAvailable--;
            }

            else if (_hintsAvailable == 1)
            {
                if (rightNumber > 0 && rightNumber <= 25) Console.WriteLine("My number is among the first 25% of the total numbers.");
                else if (rightNumber > 25 && rightNumber <= 50) Console.WriteLine("My number is in the bottom middle.");
                else if (rightNumber > 50 && rightNumber <= 75) Console.WriteLine("My number is in the upper middle.");
                else Console.WriteLine("My number is among the last 25% of the total numbers.");
            }

        }

        private string SetPlayerStats(string name)
        {
            var playerStats = new PlayerStats
            {
                PlayerName = name,
                DifficultyLevel = _difficultyLevel,
                Attempts = _guessCounter,
                DatePlayed = DateTime.Now
            };
            
            var data = JsonSerializer.Serialize(playerStats);

            return data;
        }  
    }
}
