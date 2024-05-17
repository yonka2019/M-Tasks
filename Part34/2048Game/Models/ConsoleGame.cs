using Game2048.Enums;
using System;

namespace Game2048.Models
{
    internal class ConsoleGame
    {
        private Game game;

        internal void ExecuteGame()
        {
            ConsoleColored.WriteLine("-- --- Welcome to 2048 --- --", ConsoleColor.Blue);
            ConsoleColored.WriteLine("~ By yonka", ConsoleColor.Magenta);

            Console.WriteLine();
            Console.WriteLine("Press any key to start the game..");
            Console.ReadKey();

            Countdown();

            StartGame();
            Console.WriteLine("\nPress any key to continue..");
            Console.ReadKey();
        }

        private void Countdown()
        {
            ConsoleColor cc = ConsoleColor.Gray;

            for (int i = 3; i > 0; i--)
            {
                switch (i)
                {
                    case 3:
                        cc = ConsoleColor.Green; break;  // 3
                    case 2:
                        cc = ConsoleColor.Yellow; break;  // 2
                    case 1:
                        cc = ConsoleColor.Red; break;  // 1
                }

                Console.Clear();
                ConsoleColored.WriteLine("#########################", cc);
                ConsoleColored.WriteLine($"##### Starting in {i} #####", cc);
                ConsoleColored.WriteLine("#########################", cc);
                System.Threading.Thread.Sleep(500);
            }

            Console.Clear();
            ConsoleColored.WriteLine("#########################", ConsoleColor.Magenta);
            ConsoleColored.WriteLine($"##### > GOOD LUCK < #####", ConsoleColor.Magenta);
            ConsoleColored.WriteLine("#########################", ConsoleColor.Magenta);
            System.Threading.Thread.Sleep(500);
        }

        private void StartGame()
        {
            bool runningGame = true;
            game = new Game();  // initiallize game

            while (runningGame)
            {
                Console.Clear();

                ShowPoints();
                ShowBoard();

                if ((game.GameStatus == GameStatus.Win) ||
                    (game.GameStatus == GameStatus.Lose))
                {
                    ConsoleColored.WriteLine($"\nYou {game.GameStatus.ToString().ToUpper()} - Game Finished", game.GameStatus == GameStatus.Win ? ConsoleColor.Green : ConsoleColor.Red);

                    if (game.Points > Properties.Settings.Default.BestPoints)  // points best result beaten
                    {
                        Properties.Settings.Default.BestPoints = game.Points;
                        Properties.Settings.Default.Save();

                        ConsoleColored.WriteLine($"New points record have been beaten! ({game.Points} Points)", ConsoleColor.Magenta);
                    }
                    break;  // game finished
                }

                Direction? d = ParseKey(Console.ReadKey());
                if (d != null && d.HasValue)  // arrow move
                    game.Move(d.Value);

            }
        }

        private Direction? ParseKey(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                    return Direction.Up;

                case ConsoleKey.DownArrow:
                    return Direction.Down;

                case ConsoleKey.LeftArrow:
                    return Direction.Left;

                case ConsoleKey.RightArrow:
                    return Direction.Right;

                default:
                    return null;
            }
        }

        private void ShowPoints()
        {
            ConsoleColored.WriteLine($"~ Current Points: {game.Points} (Best result: {Properties.Settings.Default.BestPoints} Points)", ConsoleColor.Magenta);
            Console.WriteLine();
        }

        private void ShowBoard()
        {
            for (int i = 0; i < game.Board.Data.GetLength(0); i++)
            {
                for (int j = 0; j < game.Board.Data.GetLength(1); j++)
                {
                    int val = game.Board.Data[i, j];

                    ConsoleColored.Write($"{val}\t", GetColor(val));
                }
                Console.WriteLine();
            }

            ConsoleColor GetColor(int val)
            {
                switch (val)
                {
                    case 2:
                    case 4:
                        return ConsoleColor.Cyan;

                    case 8:
                    case 16:
                        return ConsoleColor.Blue;

                    case 32:
                    case 64:
                        return ConsoleColor.Green;

                    case 128:
                    case 256:
                        return ConsoleColor.Yellow;

                    case 512:
                    case 1024:
                        return ConsoleColor.Red;

                    case 2048:
                        return ConsoleColor.Magenta;

                    default:
                        return ConsoleColor.Gray;
                }
            }
        }

    }
}
