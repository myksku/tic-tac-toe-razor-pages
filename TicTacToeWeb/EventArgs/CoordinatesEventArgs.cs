namespace TicTacToeWeb.Model
{
    public class CoordinatesEventArgs : EventArgs
    {
        public Coordinate[,] Coordinates { get; set; }
        public Func<Coordinate,bool> CustomWinCheck;
        public CoordinatesEventArgs(Coordinate[,] coordinates, Func<Coordinate,bool> customWinCheck)
        {
            Coordinates = coordinates;
            CustomWinCheck = customWinCheck;
        }
    }
}