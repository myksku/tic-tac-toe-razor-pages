namespace TicTacToeWeb.Services
{
    public class PlayerService : IPlayerService
    {
        private char CurrentPlayerValue { get; set; } = 'x';
        public string CurrentPlayer { get => Char.ToString(CurrentPlayerValue); set => CurrentPlayerValue = Char.Parse(value); }

        public char ChangePlayerAndGetItsValue()
        {
            if(CurrentPlayerValue == 'x')
            {
                CurrentPlayerValue = 'o';
                return 'o';
            }
            else
            {
                CurrentPlayerValue = 'x';
                return 'x';
            }
        }
    }
}
