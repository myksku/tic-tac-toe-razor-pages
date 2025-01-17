using TicTacToeWeb.Model;

namespace TicTacToe
{
    public class WinnerSetEventArgs : EventArgs
    {
        public WinnerSetEventArgs(Player winner)
        {
            Winner = winner;
        }
        public Player Winner { get; set; }
    }
}