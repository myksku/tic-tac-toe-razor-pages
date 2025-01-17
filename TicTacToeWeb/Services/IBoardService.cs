using TicTacToeWeb.Model;

namespace TicTacToeWeb.Services
{
    public interface IBoardService
    {
        int BoardSize { get; set; }
        Coordinate[,] Coordinates { get; set; }

        void UpdateFromCoordinates(int coordinateX, int coordinateY,char newValue);

        bool CheckWin();
        void Restart();
    }
}