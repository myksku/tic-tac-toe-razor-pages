using Xunit;
using TicTacToeWeb.Services;
using TicTacToeWeb.VM;

namespace TicTacToeWeb.Tests.Unit
{

    public class GameServiceTests
    {

        [Fact]
        public void InitializeNew_WhenPassedSize2_Throws()
        {
            GameService gService = new GameService();

            Assert.ThrowsAny<ArgumentException>(() => gService.InitializeNew(2));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(7)]
        [InlineData(11)]
        public void GetVM_RegardlessOfInitializedBoardSize_ReturnsVMWithCorespondingBoardSize(int boardSize)
        {
            GameService gService = new GameService();
            gService.InitializeNew(boardSize);

            GameVM gVM = gService.GetVM();

            Assert.Equal(boardSize, gVM.BoardSize);
        }

        [Fact]
        public void GetVM_PassedWithTwoChars_ReturnsFirstTagsPlayer()
        {
            GameService gService = new GameService();
            gService.InitializeNew(3,'x','o');

            GameVM gVM = gService.GetVM();

            Assert.Equal('x', gVM.CurrentPlayerValue);
        }

        [Fact]
        public void GetVM_After1Update_ReturnsSecondPlayersTag()
        {
            GameService gService = new GameService();
            gService.InitializeNew(3,'x','o');

            gService.Update(0,0);

            GameVM gVM = gService.GetVM();

            Assert.Equal('o', gVM.CurrentPlayerValue);
        }

    }
}