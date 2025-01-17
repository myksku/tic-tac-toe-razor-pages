namespace TicTacToeWeb.Services
{
    public interface IPlayerService
    {
        char ChangePlayerAndGetItsValue();
        public string CurrentPlayer { get; set; }
    }
}