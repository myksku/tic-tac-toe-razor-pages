using TicTacToeWeb.Model;

namespace TicTacToeWeb.VM
{

    public class GameVM
    {
        public Coordinate[,] Coordinates { get; set; }
        public char CurrentPlayerValue { get; set; }
        public int BoardSize { get; set; }
        public char? Winner { get; set; }
    }

}
