using Game2048.Models;
using System;

namespace Game2048
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleGame cg = new ConsoleGame();
            cg.ExecuteGame();

            Console.ReadKey();
        }
    }
}
