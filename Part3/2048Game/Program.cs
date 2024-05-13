using Game2048.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board b= new Board();
            b.PrintBoard();
            b.RandomStart();
            Console.WriteLine();
            Console.WriteLine();
            b.PrintBoard();

            ConsoleColored.WriteLine("asd", ConsoleColor.Red);

            Console.ReadKey();
        }
    }
}
