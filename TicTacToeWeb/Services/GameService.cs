
using TicTacToeWeb.Model;
using TicTacToeWeb.VM;

namespace TicTacToeWeb.Services
{

    public class GameService : IGameService
    {
        public Game Game { get; set; } = new Game();


        public void InitializeNew(int size, params char[] tags)
        {
            if (size < 3)
            {
                throw new ArgumentException("Board size can't be less than 3");
            }
            
            try
            {
                Game.InitializeNew(size);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public void Update(int x, int y)
        {
            Game.Update(x,y);
        }

        public GameVM GetVM()
        {
            GameVM result = new GameVM()
            {
                Coordinates = Game?.Board.Coordinates,
                BoardSize = Game.Board.Coordinates.GetLength(0),
                CurrentPlayerValue = Game.CurrentPlayer.Tag,
                Winner = Game.Winner?.Tag
            };

            return result;
        }
    }
}