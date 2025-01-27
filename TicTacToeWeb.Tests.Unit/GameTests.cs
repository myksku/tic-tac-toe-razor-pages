using Xunit;
using TicTacToeWeb.Model;

namespace TicTacToeWeb.Tests.Unit;

public class GameTests
{
    /*
        Requirements:
        ~ 1 Setting of Winner:
            1. Game's Winner prop is set after x win row(3) - done 
            2. Game's Winner prop is set after after x win column(3) 
            3. Game's Winner prop is set after after x win diagonal(3)
            4. !!! Game returns draw in a certain condition, add a new 'win' check rule 'checkDraw' 
        ~ 2 Dynamic Board Size:
            0. Game.InitializeNew(2) returns exception if int size is less than 3
            1. Board is set to 3x3 when Game is called with InitializeNew(3)
            1. Board is set to 4x4 when Game is called with InitializeNew(4)
            1. Board is set to 7x7 when Game is called with InitializeNew(7)
            1. Board is set to 11x11 when Game is called with InitializeNew(11)
        ~ 3  Winner is set regardless of the size of the board
            2. Board size 3x3 test any x win
            2. Board size 4x4 test any x win
            2. Board size 7x7 test any x win
            2. Board size 11x11 test any x win
    */



    [Fact]
    public void InitializeNew_WhenCalledMoreThanOnce_InitializedToTheLatestCall()
    {
        Game game = new Game();
        game.InitializeNew(4);
        game.InitializeNew(7);

        //if it reaches here no exceptions were thrown as expected
        Assert.Equal(7, game.Board.Coordinates.GetLength(0));

    }

    [Fact]
    public void GameSetsItsOwnPlayerIfNotProvided_Success()
    {
        Game game = new Game();

        game.InitializeNew(3);

        game.Update(0, 0);

        //if it reaches here no exceptions were thrown as expected
        Assert.Equal('o', game.CurrentPlayer.Tag);

    }

    [Fact]
    public void CannotInitializeAPlayerWithADLetter_Success()
    {
        Game game = new Game();

        Assert.ThrowsAny<Exception>(() => game.InitializeNew(3, 'x', 'd'));
        Assert.ThrowsAny<Exception>(() => game.InitializeNew(3, 'D', 'o'));
    }

    [Fact]
    public void Update_AfterWinnerIsSet_Throws()
    {
        Game game = new Game();
        game.InitializeNew(3);
        Player shouldBeWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(0, 1);//x
        game.Update(1, 1);
        game.Update(0, 2);//x - winner

        Assert.Equal(shouldBeWinner, game.Winner);

        Assert.ThrowsAny<Exception>(() => game.Update(1, 2));
    }

    [Fact]
    public void CannotUpdateGameWithoutFirstIntializingIt_Success()
    {
        Game game = new Game();

        Assert.ThrowsAny<Exception>(() => game.Update(0, 0));
    }

    [Fact]
    public void CurrentPlayerChangesAfter1Update_Success()
    {
        Game game = new Game();
        game.InitializeNew(3);
        Player currentP = game.CurrentPlayer;

        game.Update(0, 0);
        Player nextP = game.CurrentPlayer;

        Assert.NotEqual(currentP, nextP);
    }

    [Fact]
    public void CurrentPlayerIsTheSameAfter2Updates_Success()
    {
        Game game = new Game();
        game.InitializeNew(3);
        Player currentP = game.CurrentPlayer;

        game.Update(0, 0);
        game.Update(0, 1);
        Player nextP = game.CurrentPlayer;

        Assert.Equal(currentP, nextP);
    }

    [Fact]
    public void SameCoordinateCannotBeMarkedTwice_Success()
    {
        Game game = new Game();
        game.InitializeNew(3);
        game.Update(0, 0);

        Assert.ThrowsAny<ArgumentException>(() => game.Update(0, 0));
    }

    [Fact]
    public void AfterWinnerIsSetNoMoreUpdatesArePossible_ExpectedFailure()
    {

        Game game = new Game();
        game.InitializeNew(3);
        Player shouldBeWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(0, 1);//x
        game.Update(1, 1);
        game.Update(0, 2);//x - winner
        Assert.Equal(shouldBeWinner, game.Winner);

        Assert.ThrowsAny<Exception>(() => game.Update(1, 2));
    }

    //~ 1 Setting of Winner:
    //row
    [Fact]
    public void SetWinnerAfter3InARow_Success()
    {

        Game game = new Game();
        game.InitializeNew(3);
        Player shouldBeWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(0, 1);//x
        game.Update(1, 1);
        game.Update(0, 2);//x - winner

        Assert.Equal(shouldBeWinner, game.Winner);
    }

    [Fact]
    public void WinnerNotSetAfter2InARow_ExpectedFailure()
    {
        Game game = new Game();
        game.InitializeNew(3);

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(0, 1);//x - not winner

        Assert.Null(game.Winner);
    }

    //column

    [Fact]
    public void SetWinnerAfter3InAColumn_()
    {
        Game game = new Game();
        game.InitializeNew(3);
        Player shouldBeWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(0, 1);
        game.Update(1, 0);//x
        game.Update(1, 1);
        game.Update(2, 0);//x - winner

        Assert.Equal(shouldBeWinner, game.Winner);
    }
    [Fact]
    public void WinnerNotSetAfter2InAColumn_()
    {
        Game game = new Game();
        game.InitializeNew(3);

        game.Update(0, 0);//x
        game.Update(0, 1);
        game.Update(1, 0);//x - not winner

        Assert.Null(game.Winner);
    }

    //diagonal

    [Fact]
    public void SetWinnerAfter3InDiagonal_Success()
    {
        Game game = new Game();
        game.InitializeNew(3);
        Player shouldBeWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(1, 1);//x
        game.Update(0, 1);
        game.Update(2, 2);//x - winner

        Assert.Equal(shouldBeWinner, game.Winner);
    }

    [Fact]
    public void WinnerNotSetAfter2InDiagonal_Success()
    {
        Game game = new Game();
        game.InitializeNew(3);
        Player shouldBeWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(1, 1);//x - not winner

        Assert.Null(game.Winner);
    }

    //draw

    [Fact]
    public void SetWinnerToDrawAfterDrawCondition_Success()
    {
        Game game = new Game();
        game.InitializeNew(3);
        Player shouldBeWinner = new Player() { Tag = 'd' };

        game.Update(0, 0);//x
        game.Update(1, 0);//o
        game.Update(1, 1);//x
        game.Update(0, 1);//o
        game.Update(0, 2);//x
        game.Update(2, 2);//o
        game.Update(2, 1);//x
        game.Update(2, 0);//o
        game.Update(1, 2);//x

        Assert.Equal('d', game.Winner.Tag);
    }

    //~ 2 Dynamic Board Size:
    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(11)]
    public void GameInitializedBoardWithCorrectSize_Success(int boardSize)
    {
        // Is Board property should be public on the Game?
        Game game = new Game();
        game.InitializeNew(boardSize);

        Assert.True(game.Board.Coordinates.GetLength(0) == boardSize);
        Assert.True(game.Board.Coordinates.GetLength(1) == boardSize);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(1)]
    public void BoardCantBeInitializedWithSizeLessThan2_ExpecteFailure(int boardSize)
    {
        Game game = new Game();

        Assert.ThrowsAny<Exception>(() => game.InitializeNew(boardSize));
    }

    //~ 3  Winner is set regardless of the size of the board
    //row
    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(11)]
    public void WinnerIsSetAfterThreeInARowRegardlessOfBoardSize(int boardSize)
    {
        Game game = new Game();
        game.InitializeNew(boardSize);
        Player expectedWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(0, 1);//x
        game.Update(1, 1);
        game.Update(0, 2);//x - winner

        Assert.Equal(expectedWinner, game.Winner);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(11)]
    public void WinnerIsNotSetAfterTwoInARowRegardlessOfBoardSize(int boardSize)
    {
        Game game = new Game();
        game.InitializeNew(boardSize);
        Player expectedWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(0, 1);//x - not winner

        Assert.Null(game.Winner);
    }

    // board size less than 5 is not applicable to this test
    [Theory]
    [InlineData(7)]
    [InlineData(11)]
    public void WinnerProp_AfterThreeInTheSameRowButNotSequentely_WinnerIsNotSet(int boardSize)
    {

        Game game = new Game();

        game.InitializeNew(boardSize);

        Player expectedNotWinner = game.CurrentPlayer;

        // x0x0x
        // -----
        // -----
        // -----
        // -----

        game.Update(0, 0);//x
        game.Update(0, 1);//o
        game.Update(0, 2);//x
        game.Update(0, 3);//o
        game.Update(0, 4);//x - not winner

        Assert.Null(game.Winner);
    }

    //column

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(11)]
    public void WinnerIsSetAfterThreeInAColumnRegardlessOfBoardSize(int boardSize)
    {
        Game game = new Game();
        game.InitializeNew(boardSize);
        Player expectedWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(0, 1);//x
        game.Update(1, 1);
        game.Update(0, 2);//x - winner

        Assert.Equal(expectedWinner, game.Winner);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(11)]
    public void WinnerIsNotSetAfterTwoInAColumnRegardlessOfBoardSize(int boardSize)
    {
        Game game = new Game();
        game.InitializeNew(boardSize);
        Player expectedWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(0, 1);//x - not winner

        Assert.Null(game.Winner);
    }

    //diagonal

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(11)]
    public void WinnerIsSetAfterThreeInADiagonalRegardlessOfBoardSize(int boardSize)
    {
        Game game = new Game();
        game.InitializeNew(boardSize);
        Player expectedWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(0, 1);//x
        game.Update(1, 1);
        game.Update(0, 2);//x - winner

        Assert.Equal(expectedWinner, game.Winner);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(11)]
    public void WinnerIsNotSetAfterTwoInADiagonalRegardlessOfBoardSize(int boardSize)
    {
        Game game = new Game();
        game.InitializeNew(boardSize);
        Player expectedWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(0, 1);//x - not winner

        Assert.Null(game.Winner);
    }

    //draw
    [Fact]
    public void DrawIsSetAfter()
    {
        Game game = new Game();
        game.InitializeNew(3);

        game.Update(0, 0);//x
        game.Update(1, 0);//o
        game.Update(1, 1);//x
        game.Update(0, 1);//o
        game.Update(0, 2);//x
        game.Update(2, 2);//o
        game.Update(2, 1);//x
        game.Update(2, 0);//o
        game.Update(1, 2);//x

        Assert.Equal('d', game.Winner.Tag);
    }


    [Fact]
    public void WinnerIsNotSetAfterInitializeNewIsCalled()
    {
        Game game = new Game();
        game.InitializeNew(3);
        Player shouldBeWinner = game.CurrentPlayer;

        game.Update(0, 0);//x
        game.Update(1, 0);
        game.Update(0, 1);//x
        game.Update(1, 1);
        game.Update(0, 2);//x - winner

        Assert.NotNull(game.Winner);
        game.InitializeNew(3);
        Assert.Null(game.Winner);
    }




}