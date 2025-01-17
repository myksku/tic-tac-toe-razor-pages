using TicTacToeWeb.Utilities;

namespace TicTacToeWeb.Model
{
    public class WinLogicManager
    {

        private WinType CheckCustomLoginWin(int x, int y,Coordinate[,] coordinates)
        {
            try
            {
                if (CustomLogicCheck(coordinates, coordinates[x, y]))
                    return WinType.Custom;
            }
            catch (System.Exception e)
            {
                return WinType.None;
            }
            return WinType.None;
        }

        private bool CustomLogicCheck(object coordinates, object value)
        {
            throw new NotImplementedException();
        }

        public WinType CheckWin(Coordinate[,] coordinates)
        {
            foreach (Coordinate c in coordinates)
            {
                if (c.Value != '_')
                {
                    Coordinate checkedCoordinate = c;

                    if (CheckDraw(coordinates))
                    {
                        return WinType.Draw;
                    }
                    else if (CheckRight(c,coordinates))
                    {
                        return WinType.Player;
                    }
                    else if (CheckUp(c,coordinates))
                    {
                        return WinType.Player;
                    }
                    else if (CheckDown(c,coordinates))
                    {
                        return WinType.Player;
                    }
                    else if (CheckUpLeft(c,coordinates))
                    {
                        return WinType.Player;
                    }
                    else if (CheckUpRight(c,coordinates))
                    {
                        return WinType.Player;
                    }
                    else if (CheckDownLeft(c,coordinates))
                    {
                        return WinType.Player;
                    }
                    else if (CheckDownRight(c,coordinates))
                    {
                        return WinType.Player;
                    }
                    else if (CheckLeft(c,coordinates))
                    {
                        return WinType.Draw;
                    }

                }
            }
            return WinType.None;

        }

        private bool CheckUpLeft(Coordinate c,Coordinate[,] coordinates)
        {
            int valueCount = 0;
            int WinNumber = 3;
            int x = c.X;
            int y = c.Y;
            // traversing up and to the right
            while ((x < coordinates.GetLength(0) && y < coordinates.GetLength(1)) && (x >= 0 && y >= 0))
            {
                if (coordinates[x--, y++].Value == c.Value)
                {
                    valueCount++;
                    if (valueCount == WinNumber)
                    {
                        return true;
                    }
                }
                // if ecounteres other value, stop counting, indicate no win in this direction
                else
                {
                    return false;
                }
            }
            return false;
        }

        bool CheckUpRight(Coordinate c,Coordinate[,] coordinates)
        {
            int valueCount = 0;
            int WinNumber = 3;
            int x = c.X;
            int y = c.Y;
            // traversing up and to the right
            while ((x < coordinates.GetLength(0) && y < coordinates.GetLength(1)) && (x >= 0 && y >= 0))
            {
                if (coordinates[x++, y++].Value == c.Value)
                {
                    valueCount++;
                    if (valueCount == WinNumber)
                    {
                        return true;
                    }
                }
                // if ecounteres other value, stop counting, indicate no win in this direction
                else
                {
                    return false;
                }
            }
            return false;
        }

        bool CheckDownLeft(Coordinate c,Coordinate[,] coordinates)
        {
            int valueCount = 0;
            int WinNumber = 3;
            int x = c.X;
            int y = c.Y;
            // traversing up and to the right
            while ((x < coordinates.GetLength(0) && y < coordinates.GetLength(1)) && (x >= 0 && y >= 0))
            {
                if (coordinates[x--, y--].Value == c.Value)
                {
                    valueCount++;
                    if (valueCount == WinNumber)
                    {
                        return true;
                    }
                }
                // if ecounteres other value, stop counting, indicate no win in this direction
                else
                {
                    return false;
                }
            }
            return false;
        }

        bool CheckDownRight(Coordinate c,Coordinate[,] coordinates)
        {
            int valueCount = 0;
            int WinNumber = 3;
            int x = c.X;
            int y = c.Y;
            // traversing up and to the right
            while ((x < coordinates.GetLength(0) && y < coordinates.GetLength(1)) && (x >= 0 && y >= 0))
            {
                if (coordinates[x++, y--].Value == c.Value)
                {
                    valueCount++;
                    if (valueCount == WinNumber)
                    {
                        return true;
                    }
                }
                // if ecounteres other value, stop counting, indicate no win in this direction
                else
                {
                    return false;
                }
            }
            return false;
        }

        bool CheckUp(Coordinate c,Coordinate[,] coordinates)
        {
            int valueCount = 0;
            int WinNumber = 3;
            int x = c.X;
            int y = c.Y;
            // traversing up
            while ((x < coordinates.GetLength(0) && y < coordinates.GetLength(1)) && (x >= 0 && y >= 0))
            {
                if (coordinates[x, y++].Value == c.Value)
                {
                    valueCount++;
                    if (valueCount == WinNumber)
                    {
                        return true;
                    }
                }
                // if ecounteres other value, stop counting, indicate no win in this direction
                else
                {
                    return false;
                }
            }
            return false;
        }
        bool CheckDown(Coordinate c,Coordinate[,] coordinates)
        {
            int valueCount = 0;
            int WinNumber = 3;
            int x = c.X;
            int y = c.Y;
            // traversing down
            while ((x < coordinates.GetLength(0) && y < coordinates.GetLength(1)) && (x >= 0 && y >= 0))
            {
                if (coordinates[x, y--].Value == c.Value)
                {
                    valueCount++;
                    if (valueCount == WinNumber)
                    {
                        return true;
                    }
                }
                // if ecounteres other value, stop counting, indicate no win in this direction
                else
                {
                    return false;
                }
            }
            return false;
        }
        bool CheckLeft(Coordinate c,Coordinate[,] coordinates)
        {
            int valueCount = 0;
            int WinNumber = 3;
            int x = c.X;
            int y = c.Y;
            // traversing up and to the right
            while ((x < coordinates.GetLength(0) && y < coordinates.GetLength(1)) && (x >= 0 && y >= 0))
            {
                if (coordinates[x--, y].Value == c.Value)
                {
                    valueCount++;
                    if (valueCount == WinNumber)
                    {
                        return true;
                    }
                }
                // if ecounteres other value, stop counting, indicate no win in this direction
                else
                {
                    return false;
                }
            }
            return false;
        }
        bool CheckRight(Coordinate c,Coordinate[,] coordinates)
        {
            int valueCount = 0;
            int WinNumber = 3;
            int x = c.X;
            int y = c.Y;
            // traversing to the right
            while ((x < coordinates.GetLength(0) && y < coordinates.GetLength(1)) && (x >= 0 && y >= 0))
            {
                if (coordinates[x++, y].Value == c.Value)
                {
                    valueCount++;
                    if (valueCount == WinNumber)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private bool CheckDraw(Coordinate[,] coordinates)
        {
            foreach (Coordinate c in coordinates)
            {
                if (c.Value == '_')
                {
                    return false;
                }
            }
            return true;
        }
    }
}