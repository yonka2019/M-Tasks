using Game2048.Enums;
using Game2048.Models;

namespace Game2048
{
    internal class Game
    {
        private const int WIN_NUM = 2048;

        internal Board Board { get; private set; }
        internal GameStatus GameStatus { get; private set; } = GameStatus.Idle;
        protected internal int Points { get; protected set; }

        internal Game()
        {
            Board = new Board();
            Board.RandomStart();
        }


        internal void Move(Direction d)
        {
            if (GameStatus == GameStatus.Lose)
                return;

            switch (d)
            {
                case Direction.Up:
                    Points += Board.Move(Direction.Up);
                    break;

                case Direction.Down:
                    Points += Board.Move(Direction.Down);
                    break;

                case Direction.Right:
                    Points += Board.Move(Direction.Right);
                    break;

                case Direction.Left:
                    Points += Board.Move(Direction.Left);
                    break;
            }
            Board.PutRandomNumber();

            GameStatus = GetGameStatus();
        }

        private GameStatus GetGameStatus()
        {
            bool movePossible = false;

            for (int i = 0; i < Board.Data.GetLength(0); i++)
            {
                for (int j = 0; j < Board.Data.GetLength(1); j++)
                {
                    if (Board.Data[i, j] == WIN_NUM)  // got the WIN NUM
                        return GameStatus.Win;

                    else if (Board.Moveable(i, j))
                        movePossible = true;
                }
            }

            if (!movePossible) // there is no any possible move (lose)
                return GameStatus.Lose;
            else
                return GameStatus.Idle;
        }
    }
}
