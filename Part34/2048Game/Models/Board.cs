using Game2048.Enums;
using System;

namespace Game2048.Models
{
    internal class Board
    {
        protected internal int[,] Data { get; protected set; }

        internal Board(int size = 4)
        {
            Data = new int[size, size];
        }

        internal void RandomStart()
        {
            PutRandomNumber();
            PutRandomNumber();
        }

        internal int Move(Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    return MoveUp();

                case Direction.Down:
                    return MoveDown();

                case Direction.Right:
                    return MoveRight();

                case Direction.Left:
                    return MoveLeft();

                default:
                    return 0;
            }
        }

        /// <summary>
        /// Checks if the given cell may be moved to any place 
        /// </summary>
        internal bool Moveable(int i, int j)
        {
            int upNum = -1, downNum = -1, rightNum = -1, leftNum = -1;

            if (i - 1 > 0)
                upNum = Data[i - 1, j];

            if (i + 1 < Data.GetLength(0))
                downNum = Data[i + 1, j];

            if (j + 1 < Data.GetLength(1))
                rightNum = Data[i, j + 1];

            if (j - 1 > 0)
                leftNum = Data[i, j - 1];

            return upNum == 0 || downNum == 0 || rightNum == 0 || leftNum == 0 ||
                   Data[i, j] == upNum || Data[i, j] == downNum || Data[i, j] == rightNum || Data[i, j] == leftNum;
        }

        internal void PutRandomNumber()
        {
            if (ArrayContains(Data, 0))  // there is any empty place?
            {
                bool done = false;
                int randomRow, randomCol;
                Random rnd = new Random();

                int numToPut = rnd.Next(1, 3);

                while (!done)
                {
                    randomRow = rnd.Next(0, Data.GetLength(0));
                    randomCol = rnd.Next(0, Data.GetLength(1));

                    if (Data[randomRow, randomCol] == 0)  // put only at empty place
                    {
                        Data[randomRow, randomCol] = numToPut * 2; // 1 * 2 (2)  |  2 * 2 (4)
                        done = true;
                    }
                }
            }

            bool ArrayContains<T>(T[,] array, T key)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j].Equals(key))
                            return true;
                    }
                }

                return false;
            }
        }

        private int MoveRight()
        {
            {
                MoveItems();
                int points = MergeItems();
                MoveItems();

                return points;
            }

            int MergeItems()
            {
                int points = 0;
                bool lastMerged = false;

                for (int i = 0; i < Data.GetLength(0); i++)  // row
                {
                    for (int j = Data.GetLength(1) - 1; j > 0; j--)  // column
                    {
                        if (!lastMerged)
                        {
                            if (Data[i, j] == Data[i, j - 1])  // [A, B, C, D] (A ==? B)
                            {
                                if (Data[i, j] != 0)  // skip if 0 - 0 
                                {
                                    Data[i, j] *= 2;
                                    Data[i, j - 1] = 0;
                                    points += Data[i, j];

                                    lastMerged = true;  // avoid situations like:  [2, 2, 4, 0] ; 2 & 2 merged => [0, 4, 4, 0] (4 & 4 SHOULDN'T be merged)
                                }
                            }
                        }
                        else
                            lastMerged = false;  // reset lastMerged
                    }
                }
                return points;
            }
            void MoveItems()
            {
                for (int c = 0; c < 3; c++)
                {
                    for (int i = 0; i < Data.GetLength(0); i++)  // row
                    {
                        for (int j = 0; j < Data.GetLength(1) - 1; j++)  // column
                        {
                            if (Data[i, j + 1] == 0)  // there is empty place to move
                            {
                                Data[i, j + 1] = Data[i, j];  // (move value)
                                Data[i, j] = 0;  // reset (moved)
                            }
                        }
                    }
                }
            }
        }

        private int MoveLeft()
        {
            {
                MoveItems();
                int points = MergeItems();
                MoveItems();

                return points;
            }

            int MergeItems()
            {
                int points = 0;
                bool lastMerged = false;

                for (int i = 0; i < Data.GetLength(0); i++)  // row
                {
                    for (int j = 0; j < Data.GetLength(1) - 1; j++)  // column
                    {
                        if (!lastMerged)
                        {
                            if (Data[i, j] == Data[i, j + 1])
                            {
                                if (Data[i, j] != 0)  // skip if 0 - 0 
                                {
                                    Data[i, j] *= 2;
                                    Data[i, j + 1] = 0;
                                    points += Data[i, j];

                                    lastMerged = true;
                                }
                            }
                        }
                        else
                            lastMerged = false;  // reset lastMerged
                    }
                }
                return points;
            }
            void MoveItems()
            {
                for (int c = 0; c < 3; c++)
                {
                    for (int i = 0; i < Data.GetLength(0); i++)  // row
                    {
                        for (int j = Data.GetLength(1) - 1; j > 0; j--)  // column
                        {
                            if (Data[i, j - 1] == 0)  // there is empty place to move
                            {
                                Data[i, j - 1] = Data[i, j];  // (move value)
                                Data[i, j] = 0;  // reset (moved)
                            }
                        }
                    }
                }
            }
        }

        private int MoveUp()
        {
            {
                MoveItems();
                int points = MergeItems();
                MoveItems();

                return points;
            }

            int MergeItems()
            {
                int points = 0;
                bool lastMerged = false;

                for (int j = 0; j < Data.GetLength(1); j++)  // column
                {
                    for (int i = 0; i < Data.GetLength(0) - 1; i++)  // row
                    {
                        if (!lastMerged)
                        {
                            if (Data[i, j] == Data[i + 1, j])
                            {
                                if (Data[i, j] != 0)  // skip if 0 - 0 
                                {
                                    Data[i, j] *= 2;
                                    Data[i + 1, j] = 0;
                                    points += Data[i, j];

                                    lastMerged = true;
                                }
                            }
                        }
                        else
                            lastMerged = false;  // reset lastMerged
                    }
                }
                return points;
            }
            void MoveItems()
            {
                for (int c = 0; c < 3; c++)
                {
                    for (int i = Data.GetLength(0) - 1; i > 0; i--)  // row
                    {
                        for (int j = 0; j < Data.GetLength(1); j++)  // column
                        {
                            if (Data[i - 1, j] == 0)  // there is empty place to move
                            {
                                Data[i - 1, j] = Data[i, j];  // (move value)
                                Data[i, j] = 0;  // reset (moved)
                            }
                        }
                    }
                }
            }
        }

        private int MoveDown()
        {
            {
                MoveItems();
                int points = MergeItems();
                MoveItems();

                return points;
            }

            int MergeItems()
            {
                int points = 0;
                bool lastMerged = false;

                for (int j = 0; j < Data.GetLength(1); j++)  // column
                {
                    for (int i = Data.GetLength(0) - 1; i > 0; i--)  // row
                    {
                        if (!lastMerged)
                        {
                            if (Data[i, j] == Data[i - 1, j])
                            {
                                if (Data[i, j] != 0)  // skip if 0 - 0 
                                {
                                    Data[i, j] *= 2;
                                    Data[i - 1, j] = 0;
                                    points += Data[i, j];

                                    lastMerged = true;
                                }
                            }
                        }
                        else
                            lastMerged = false;  // reset lastMerged
                    }
                }
                return points;
            }
            void MoveItems()
            {
                for (int c = 0; c < 3; c++)
                {
                    for (int i = 0; i < Data.GetLength(0) - 1; i++)  // row
                    {
                        for (int j = 0; j < Data.GetLength(1); j++)  // column
                        {
                            if (Data[i + 1, j] == 0)  // there is empty place to move
                            {
                                Data[i + 1, j] = Data[i, j];  // (move value)
                                Data[i, j] = 0;  // reset (moved)
                            }
                        }
                    }
                }
            }
        }
    }
}
