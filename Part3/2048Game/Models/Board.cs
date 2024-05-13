using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Game2048.Models
{
    internal class Board
    {
        protected internal int[,] Data { get; protected set; } = new int[4, 4];

        internal void RandomStart()
        {
            Random rnd = new Random();
            PutRandom(2);
            PutRandom(4);

            void PutRandom(int numToPut)
            {
                int randomRow = rnd.Next(0, Data.GetLength(0));
                int randomColumn = rnd.Next(0, Data.GetLength(1));

                Data[randomRow,randomColumn] = numToPut;
            }
        }

        //private int Move()
        //{

        //}

        public void PrintBoard()
        {
            for (int i = 0; i < Data.GetLength(0); i++)
            {
                for (int j = 0; j < Data.GetLength(1); j++)
                {
                    int val = Data[i, j];

                    ConsoleColored.Write($"{val}\t", GetColor(val));
                }
                Console.WriteLine();
            }

            ConsoleColor GetColor(int val)
            {
                switch (val)
                {
                    case 2:
                        return ConsoleColor.White;

                    case 4:
                        return ConsoleColor.DarkGray;

                    case 8:
                        return ConsoleColor.DarkYellow;

                    case 16:
                        return ConsoleColor.Cyan;

                    case 32:
                        return ConsoleColor.DarkCyan;

                    case 64:
                        return ConsoleColor.Blue;

                    case 128:
                        return ConsoleColor.Yellow;

                    case 256:
                        return ConsoleColor.Red;

                    case 512:
                        return ConsoleColor.DarkRed;

                    case 1024:
                        return ConsoleColor.Green;

                    case 2048:
                        return ConsoleColor.Magenta;

                    default:
                        return ConsoleColor.Gray;
                }
            }
        }
    }
}
