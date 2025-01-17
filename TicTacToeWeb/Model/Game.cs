using System.Security.Cryptography;
using TicTacToe;
using TicTacToeWeb.Utilities;
using TicTacToeWeb.VM;

namespace TicTacToeWeb.Model
{
    public class Game
    {
        public Board? Board { get; private set; } = new Board();
        public Player Player1 { get; private set; } = new Player() { Tag = 'x' };
        public Player Player2 { get; private set; } = new Player() { Tag = 'o' };
        public Player? CurrentPlayer { get; private set; } = new Player() { Tag = 'x' };
        public bool IsInitialized { get; private set; } = false;
        
        // d - char stands for draw if winner is set to d then the game is a draw.
        public Player? Winner { get; private set; }
        public void InitializeNew(int size, params char[] tags)
        {
            if (!tags.All(t => (t != 'D' && t != 'd')))
            {
                throw new ArgumentException("Player cannot have a tag with 'd' or 'D', because it's a reserved character");
            }

            if (tags.Length == 0)
            {
                tags = new char[2];
                tags[0] = 'x';
                tags[1] = 'o';
            }

            Board = new Board();

            Board.InitializeNew(size);

            Board.WinnerSet += SetWinner;

            Board.PlayerCompletedMove += SwitchPlayerTurn;

            Player1 = new Player() { Tag = tags[0] };
            Player2 = new Player() { Tag = tags[1] };
            CurrentPlayer = Player1;
            Winner = null;
            IsInitialized = true;
        }

        // PLUGIN DELEGATE
        public void RegisterCustomLogicWin(Func<Coordinate[,], Coordinate, bool> IsCustomWin)
        {
            Board.CustomLogicCheck += IsCustomWin;
        }


        public void Update(int x, int y)
        {

            if (IsInitialized == false)
                throw new InvalidOperationException("Can't update game because Game Hasn't been initialized yet");

            if (Winner != null)
                throw new InvalidOperationException("Can't update game because Winner is already set");


            Board.Update(x, y, CurrentPlayer);
        }

        private void SetWinner(object? sender, WinnerSetEventArgs e)
        {
            Winner = e.Winner;
        }

        private void SwitchPlayerTurn(object? sender, EventArgs e)
        {
            if (CurrentPlayer == Player1)
            {
                CurrentPlayer = Player2;
            }
            else if (CurrentPlayer == Player2)
            {
                CurrentPlayer = Player1;
            }

        }

    }
}
