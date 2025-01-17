using Xunit;
using TicTacToeWeb.Model;
using TicTacToeWeb.Utilities;

namespace TicTacToeWeb.Tests.Unit;

public class BoardTests
{
    // // [Fact]
    // // public void WinnerIsSet_AfterThreeXInARow()
    // // {
    // //     Board board = new Board();
    // //     board.InitializeNew(3);
    // //     Player p = new Player() { Tag = 'x' };

    // //     board.Update(0, 0, p);
    // //     board.Update(0, 1, p);
    // //     board.Update(0, 2, p);

    // //     Assert.IsEqual(board.Winner,p);
    // // }

    [Fact]
    public void Constructor_BoardHasXYPropsInitialized()
    {
        Board board = new Board();

        int xYZeroCount = 0;
        foreach (Coordinate c in board.Coordinates)
        {
            if (c.X == 0 && c.Y == 0)
            {
                xYZeroCount++;
                if (xYZeroCount > 1)
                {
                    throw new Exception();
                }
            }
        }
    }

    [Fact]
    public void InitializeNew_BoardHasXYPropsInitialized()
    {
        Board board = new Board();
        board.InitializeNew(3);

        int xYZeroCount = 0;

        foreach (Coordinate c in board.Coordinates)
        {
            if (c.X == 0 && c.Y == 0)
            {
                xYZeroCount++;
                if (xYZeroCount > 1)
                {
                    throw new Exception();
                }
            }
        }
    }
    [Fact]
    public void InitializeNew_WhenPassedSize2_Throws()
    {
        Board board = new Board();

        Assert.ThrowsAny<Exception>(() => board.InitializeNew(2));
    }

    [Fact]
    public void CheckWin_WithoutASingleUpdate_ReturnsWinTypeNone()
    {
        Board board = new Board();
        board.InitializeNew(3);

        Assert.Equal(WinType.None, board.CheckWin());
    }

    [Fact]
    public void CheckWin_With2Updates_ReturnsWinTypeNone()
    {
        Board board = new Board();
        board.InitializeNew(3);
        Player p = new Player() { Tag = 'x' };

        board.Update(0, 0, p);
        board.Update(0, 1, p);

        Assert.Equal(WinType.None, board.CheckWin());
    }

    [Fact]
    public void Update_WhenCalledWithTooBigIndex_ThrowsIndexOutOfRangeIfTooBigIndex()
    {
        Board board = new Board();
        board.InitializeNew(3);
        Player p = new Player() { Tag = 'x' };

        Assert.ThrowsAny<Exception>(() => board.Update(3, 0, p));
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(11)]
    public void CheckWin_After3InARowRegardlesOfSize_ReturnTrue(int boardSize)
    {
        Board board = new Board();
        board.InitializeNew(boardSize);
        Player p = new Player() { Tag = 'x' };

        board.Update(0, 0, p);//x
        board.Update(0, 1, p);//x
        board.Update(0, 2, p);//x - winner

        Assert.Equal(WinType.Player, board.CheckWin());
    }


    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(11)]
    public void CheckWin_After3InAColumnRegardlesOfSize_ReturnTrue(int boardSize)
    {
        Board board = new Board();
        board.InitializeNew(boardSize);
        Player p = new Player() { Tag = 'x' };

        board.Update(0, 0, p);//x
        board.Update(1, 0, p);//x
        board.Update(2, 0, p);//x - winner

        Assert.Equal(WinType.Player, board.CheckWin());
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(11)]
    public void CheckWin_After3InAColumnFrom01PositionRegardlesOfSize_ReturnTrue(int boardSize)
    {
        Board board = new Board();
        board.InitializeNew(boardSize);
        Player p = new Player() { Tag = 'x' };

        board.Update(0, 1, p);//x
        board.Update(1, 1, p);//x
        board.Update(2, 1, p);//x - winner

        Assert.Equal(WinType.Player, board.CheckWin());
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(7)]
    [InlineData(11)]
    public void CheckWin_After3InADiagonalRegardlesOfSize_ReturnWinTypePlayer(int boardSize)
    {
        Board board = new Board();
        board.InitializeNew(boardSize);
        Player p = new Player() { Tag = 'x' };

        board.Update(0, 0, p);//x
        board.Update(1, 1, p);//x
        board.Update(2, 2, p);//x - winner

        Assert.Equal(WinType.Player, board.CheckWin());
    }

    [Fact]
    public void CheckWin_AfterDrawCondition_ReturnsWintTypeDraw()
    {
        Board board = new Board();
        board.InitializeNew(3);
        Player p1 = new Player() { Tag = 'x' };
        Player p2 = new Player() { Tag = 'o' };

        board.Update(0, 0, p1);//x
        board.Update(1, 0, p2);//o
        board.Update(1, 1, p1);//x
        board.Update(0, 1, p2);//o
        board.Update(0, 2, p1);//x
        board.Update(2, 2, p2);//o
        board.Update(2, 1, p1);//x
        board.Update(2, 0, p2);//o
        board.Update(1, 2, p1);//x

        Assert.Equal(WinType.Draw, board.CheckWin());
    }

    //Custom logic of 'hollow cross shape' for x
    [Fact]
    public void WinnerProp_AfterCustomLogicWin_IsSet()
    {
        throw new NotImplementedException();
        
        Game game = new Game();

        game.InitializeNew(3);

        game.RegisterCustomLogicWin((cs, c) =>
        {
            if (cs[c.X, c.Y + 1].Value == 'x')
            {
                if (cs[c.X, c.Y - 1].Value == 'x')
                {
                    if (cs[c.X - 1, c.Y].Value == 'x')
                    {
                        if (cs[c.X + 1, c.Y].Value == 'x')
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        });

        /*
            _|x|_
            x|_|x
            _|x|_
        */
        game.Board.Update(1, 0, game.CurrentPlayer);
        game.Board.Update(1, 1, game.CurrentPlayer);
        game.Board.Update(1, 2, game.CurrentPlayer);
        game.Board.Update(0, 1, game.CurrentPlayer);
        game.Board.Update(2, 1, game.CurrentPlayer);

        Assert.Equal('x', game.Winner.Tag);
    }



}