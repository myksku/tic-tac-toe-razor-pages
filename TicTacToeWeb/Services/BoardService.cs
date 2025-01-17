// using TicTacToeWeb.Model;

// namespace TicTacToeWeb.Services
// {
//     public class BoardService : IBoardService
//     {
//         IBoardRepository _boardRepo;

//         public BoardService(IBoardRepository boardRepo) {
//             _boardRepo = boardRepo;
//         }
//         public int BoardSize { get => _boardRepo.BoardSize; set => _boardRepo.BoardSize = value; }
//         public Coordinate[,] Coordinates { get => _boardRepo.Coordinates; set => _boardRepo.Coordinates = value; }

//         public void UpdateFromCoordinates(int coordinateX, int coordinateY, char newValue)
//         {
//             foreach (Coordinate coordinate in _boardRepo.Coordinates)
//             {
//                 if (coordinate.X == coordinateX && coordinate.Y == coordinateY)
//                 {
//                     coordinate.Value = newValue;
//                 }
//             }
//         }

//         public void Restart()
//         {
//             _boardRepo.Coordinates = RefreshCoordinates();
//         }

//         public bool CheckWin()
//         {
//             if (CheckWinVertical())
//             {
//                 return true;
//             }
//             if (CheckWinHorizontal())
//             {
//                 return true;
//             }
//             if (CheckWinDiagonal())
//             {
//                 return true;
//             }

//             return false;
//         }

//         private Coordinate[,] RefreshCoordinates()
//         {
//             int boardSize = _boardRepo.BoardSize;
//             Coordinate[,] result = new Coordinate[boardSize, boardSize];

//             for (int i = 0; i < boardSize; i++)
//             {
//                 for (int j = 0; j < boardSize; j++)
//                 {
//                     result[i, j] = new Coordinate() { Value = '_', X = i, Y = j };
//                 }
//             }

//             return result;
//         }

//         /*Check if there collumns who are marked with same value*/
//         private bool CheckWinVertical()
//         {
//             char? temp = null;
//             for (int i = 0; i < _boardRepo.BoardSize; i++)
//             {
//                 if (_boardRepo.Coordinates[i, 0].Value == '_')
//                 {
//                     continue;
//                 }

//                 temp = _boardRepo.Coordinates[i, 0].Value;

//                 for (int j = 0; j < _boardRepo.BoardSize; j++)
//                 {
//                     //check last element
//                     if (i + 1 == _boardRepo.BoardSize)
//                     {
//                         if (temp == _boardRepo.Coordinates[i, j].Value)
//                         {
//                             return true;
//                         }
//                         else
//                         {
//                             continue;
//                         }
//                     }
//                     if (temp != _boardRepo.Coordinates[i, j].Value)
//                     {
//                         continue;
//                     }
//                 }

//             }

//             return false;
//         }

//         /*Check if there rows who are marked with same value*/
//         private bool CheckWinHorizontal()
//         {
//             char? temp = null;
//             for (int i = 0; i < _boardRepo.BoardSize; i++)
//             {
//                 if (_boardRepo.Coordinates[i, 0].Value == '_')
//                 {
//                     continue;
//                 }

//                 temp = _boardRepo.Coordinates[i, 0].Value;

//                 for (int j = 0; j < _boardRepo.BoardSize; j++)
//                 {
//                     //check last element
//                     if (j + 1 == _boardRepo.BoardSize)
//                     {
//                         if (temp == _boardRepo.Coordinates[i, j].Value)
//                         {
//                             return true;
//                         }
//                         else
//                         {
//                             continue;
//                         }
//                     }
//                     if (temp != _boardRepo.Coordinates[i, j].Value)
//                     {
//                         continue;
//                     }
//                 }

//             }

//             return false;
//         }

//         /*Check if there diagonals who are marked with same value*/
//         private bool CheckWinDiagonal()
//         {
//             return false;
//         }

//     }
// }
