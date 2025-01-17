using TicTacToeWeb.Model;
using TicTacToeWeb.Pages.Game;
using TicTacToeWeb.VM;

namespace TicTacToeWeb.Services
{
    public interface IGameService
    {
        public void InitializeNew(int size,params char[] tags);
        public void Update(int x,int y);
        public GameVM GetVM();
    }
}