using TicTacToeWeb.Utilities;
using System.Linq;
using TicTacToe;

namespace TicTacToeWeb.Model
{
    public class Board
    {
        internal Action<object?, EventArgs> PlayerCompletedMove;
        internal Func<Coordinate[,], Coordinate, bool> CustomLogicCheck;
        public Coordinate[,] Coordinates { get; private set; } = DefaultCoordinates(3);
        public WinLogicManager WinLogicManager { get; set; }
        public int WinNumber { get; set; } = 3;

        public event EventHandler<WinnerSetEventArgs> WinnerSet;
        protected virtual void OnWinnerSet(WinnerSetEventArgs args)
        {
            WinnerSet?.Invoke(this, args);
        }

        public void InitializeNew(int size)
        {
            if (size < 3)
            {
                throw new ArgumentException("cannot initialize board with size less 3");
            }
            WinLogicManager = new WinLogicManager();
            Coordinates = DefaultCoordinates(size);
        }

        public void Update(int x, int y, Player p)
        {

            if (Coordinates[x, y].Value == '_')
            {
                Coordinates[x, y].Value = p.Tag;

                WinType winType = WinLogicManager.CheckWin(Coordinates);

                if (winType == WinType.Custom)
                {
                    OnWinnerSet(new WinnerSetEventArgs(p));
                }
                else if (winType == WinType.Draw)
                {
                    OnWinnerSet(new WinnerSetEventArgs(new Player() { Tag = 'd' }));
                }
                else if (winType != WinType.None)
                {
                    OnWinnerSet(new WinnerSetEventArgs(p));
                }

            }
            else
            {
                throw new ArgumentException("Cannot set already set Coordinate");
            }

            PlayerCompletedMove(this, new EventArgs());

        }

        public WinType CheckWin()
        {
            return WinLogicManager.CheckWin(Coordinates);
        }
        private void PrintBoard()
        {
            for (int i = 0; i < Coordinates.GetLength(0); i++)
            {
                for (int j = 0; j < Coordinates.GetLength(1); j++)
                {
                    Console.WriteLine($"{Coordinates[i, j].Value}");
                }
                Console.WriteLine("\n");
            }
        }

        private static Coordinate[,] DefaultCoordinates(int size)
        {
            Coordinate[,] result = new Coordinate[size, size];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    // _ char indicates empty space
                    result[i, j] = new Coordinate() { Value = '_', X = i, Y = j };
                }
            }
            return result;
        }

    }
}

