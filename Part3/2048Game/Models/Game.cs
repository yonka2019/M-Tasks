using Game2048.Enums;
using Game2048.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048
{
    internal class Game
    {
        private Board board { get; set; }
        private GameStatus gameStatus { get; set; }
        protected internal int Point { get; protected set; }

        private void Move(Direction d)
        {
            if (gameStatus == GameStatus.Lose)
                return;

            switch (d)
            {
                case Direction.Up:
                    break;

                case Direction.Down:
                    break;

                case Direction.Right:
                    break;

                case Direction.Left:
                    break;
            }
        }

    }
}
