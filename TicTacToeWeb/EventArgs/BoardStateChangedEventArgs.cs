using TicTacToeWeb.Model;

namespace TicTacToe
{
    public class BoardStateChangedEventArgs : EventArgs
    {
        public BoardStateChangedEventArgs(Board board)
        {
            Board = board;
        }
        public Board Board { get; set; }
    }
}