using System;

namespace ChessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWhiteTurn = true;
            Console.WriteLine("Welcome to 2D Chess");
            bool gameRun = true;
            while (gameRun)
            {
                ChessBoard chessBoard = new ChessBoard();
                chessBoard.DrawBoard();
                bool insidegame = true;
                while (insidegame)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{(isWhiteTurn ? "White" : "Black")}'s turn");
                    Console.WriteLine("Enter the piece name and number (e.g., Pawn 6, Bishop 2, King):");
                    string input = Console.ReadLine();
                    try
                    {
                        string[] splitInput = input.Split(' ');
                        if (splitInput.Length == 2)
                        {
                            string pieceName = splitInput[0].ToLower();
                            int pieceNumber;
                            bool isNumberValid = int.TryParse(splitInput[1], out pieceNumber);

                            if (isNumberValid && pieceNumber >= 1 && pieceNumber <= 8)
                            {
                                PieceType pieceType;
                                switch (pieceName)
                                {
                                    case "pawn":
                                        pieceType = PieceType.Pawn;
                                        break;
                                    case "knight":
                                        pieceType = PieceType.Knight;
                                        break;
                                    case "bishop":
                                        pieceType = PieceType.Bishop;
                                        break;
                                    case "rook":
                                        pieceType = PieceType.Rook;
                                        break;
                                    case "queen":
                                        pieceType = PieceType.Queen;
                                        break;
                                    case "king":
                                        pieceType = PieceType.King;
                                        break;
                                    default:
                                        throw new Exception("Invalid piece name!");
                                }
                                int pieceCount = 0;
                                bool isValidPiece = false;
                                int spacesToMove = 0;

                                for (int row = 0; row < 8; row++)
                                {
                                    for (int col = 0; col < 8; col++)
                                    {
                                        ChessBoard.Piece piece = chessBoard.GetPiece(row, col);
                                        if (piece != null && piece.Type == pieceType && piece.IsWhite == isWhiteTurn)
                                        {
                                            pieceCount++;
                                            if (pieceCount == pieceNumber)
                                            {
                                                isValidPiece = true;

                                                Console.WriteLine("Enter the number of spaces to move:");
                                                spacesToMove = Convert.ToInt32(Console.ReadLine());

                                                int srcRow = row;
                                                int srcCol = col;
                                                int destRow = row;
                                                int destCol = col;

                                                switch (pieceType)
                                                {
                                                    case PieceType.Pawn:
                                                        destRow += (isWhiteTurn ? -spacesToMove : spacesToMove);
                                                        break;
                                                    case PieceType.Knight:
                                                        Console.WriteLine("Enter the direction to move (e.g., 1, 2):");
                                                        int direction = Convert.ToInt32(Console.ReadLine());
                                                        if (direction == 1)
                                                        {
                                                            destRow += 2;
                                                            destCol += 1;
                                                        }
                                                        else if (direction == 2)
                                                        {
                                                            destRow += 1;
                                                            destCol += 2;
                                                        }
                                                        else if (direction == 3)
                                                        {
                                                            destRow -= 1;
                                                            destCol += 2;
                                                        }
                                                        else if (direction == 4)
                                                        {
                                                            destRow -= 2;
                                                            destCol += 1;
                                                        }
                                                        else if (direction == 5)
                                                        {
                                                            destRow -= 2;
                                                            destCol -= 1;
                                                        }
                                                        else if (direction == 6)
                                                        {
                                                            destRow -= 1;
                                                            destCol -= 2;
                                                        }
                                                        else if (direction == 7)
                                                        {
                                                            destRow += 1;
                                                            destCol -= 2;
                                                        }
                                                        else if (direction == 8)
                                                        {
                                                            destRow += 2;
                                                            destCol -= 1;
                                                        }
                                                        else
                                                        {
                                                            throw new Exception("Invalid direction!");
                                                        }
                                                        break;
                                                    case PieceType.Bishop:
                                                        Console.WriteLine("Enter the direction to move (e.g., 1, 2, 3, 4):");
                                                        int diagonalDirection = Convert.ToInt32(Console.ReadLine());
                                                        if (diagonalDirection == 1)
                                                        {
                                                            destRow += spacesToMove;
                                                            destCol += spacesToMove;
                                                        }
                                                        else if (diagonalDirection == 2)
                                                        {
                                                            destRow += spacesToMove;
                                                            destCol -= spacesToMove;
                                                        }
                                                        else if (diagonalDirection == 3)
                                                        {
                                                            destRow -= spacesToMove;
                                                            destCol += spacesToMove;
                                                        }
                                                        else if (diagonalDirection == 4)
                                                        {
                                                            destRow -= spacesToMove;
                                                            destCol -= spacesToMove;
                                                        }
                                                        else
                                                        {
                                                            throw new Exception("Invalid direction!");
                                                        }
                                                        break;
                                                    case PieceType.Rook:
                                                        Console.WriteLine("Enter the direction to move (e.g., 1, 2, 3, 4):");
                                                        int straightDirection = Convert.ToInt32(Console.ReadLine());
                                                        if (straightDirection == 1)
                                                        {
                                                            destRow += spacesToMove;
                                                        }
                                                        else if (straightDirection == 2)
                                                        {
                                                            destRow -= spacesToMove;
                                                        }
                                                        else if (straightDirection == 3)
                                                        {
                                                            destCol += spacesToMove;
                                                        }
                                                        else if (straightDirection == 4)
                                                        {
                                                            destCol -= spacesToMove;
                                                        }
                                                        else
                                                        {
                                                            throw new Exception("Invalid direction!");
                                                        }
                                                        break;
                                                    case PieceType.Queen:
                                                        Console.WriteLine("Enter the direction to move (e.g., 1-8):");
                                                        int queenDirection = Convert.ToInt32(Console.ReadLine());
                                                        if (queenDirection == 1)
                                                        {
                                                            destRow += spacesToMove;
                                                            destCol += spacesToMove;
                                                        }
                                                        else if (queenDirection == 2)
                                                        {
                                                            destRow += spacesToMove;
                                                            destCol -= spacesToMove;
                                                        }
                                                        else if (queenDirection == 3)
                                                        {
                                                            destRow -= spacesToMove;
                                                            destCol += spacesToMove;
                                                        }
                                                        else if (queenDirection == 4)
                                                        {
                                                            destRow -= spacesToMove;
                                                            destCol -= spacesToMove;
                                                        }
                                                        else if (queenDirection == 5)
                                                        {
                                                            destRow += spacesToMove;
                                                        }
                                                        else if (queenDirection == 6)
                                                        {
                                                            destRow -= spacesToMove;
                                                        }
                                                        else if (queenDirection == 7)
                                                        {
                                                            destCol += spacesToMove;
                                                        }
                                                        else if (queenDirection == 8)
                                                        {
                                                            destCol -= spacesToMove;
                                                        }
                                                        else
                                                        {
                                                            throw new Exception("Invalid direction!");
                                                        }
                                                        break;
                                                    case PieceType.King:
                                                        Console.WriteLine("Enter the direction to move (e.g., 1-8):");
                                                        int kingDirection = Convert.ToInt32(Console.ReadLine());
                                                        if (kingDirection == 1)
                                                        {
                                                            destRow += spacesToMove;
                                                            destCol += spacesToMove;
                                                        }
                                                        else if (kingDirection == 2)
                                                        {
                                                            destRow += spacesToMove;
                                                            destCol -= spacesToMove;
                                                        }
                                                        else if (kingDirection == 3)
                                                        {
                                                            destRow -= spacesToMove;
                                                            destCol += spacesToMove;
                                                        }
                                                        else if (kingDirection == 4)
                                                        {
                                                            destRow -= spacesToMove;
                                                            destCol -= spacesToMove;
                                                        }
                                                        else if (kingDirection == 5)
                                                        {
                                                            destRow += spacesToMove;
                                                        }
                                                        else if (kingDirection == 6)
                                                        {
                                                            destRow -= spacesToMove;
                                                        }
                                                        else if (kingDirection == 7)
                                                        {
                                                            destCol += spacesToMove;
                                                        }
                                                        else if (kingDirection == 8)
                                                        {
                                                            destCol -= spacesToMove;
                                                        }
                                                        else
                                                        {
                                                            throw new Exception("Invalid direction!");
                                                        }
                                                        break;
                                                    default:
                                                        throw new Exception("Invalid piece type!");
                                                }
                                                if (chessBoard.IsValidMove(srcRow, srcCol, destRow, destCol,chessBoard))
                                                {
                                                    chessBoard.MakeMove(srcRow, srcCol, destRow, destCol);
                                                    chessBoard.UpdateAttackedSquares();
                                                    chessBoard.DrawBoard();
                                                    insidegame = false;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }

                                if (!isValidPiece)
                                {
                                    throw new Exception("Invalid piece number!");
                                }
                            }
                            else
                            {
                                throw new Exception("Invalid piece number!");
                            }
                        }
                        else
                        {
                            throw new Exception("Invalid input format!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
                Console.WriteLine($"{(isWhiteTurn ? "Black" : "White")} wins");
                Console.WriteLine("Press any key to start a new game or press 'Q' to quit");
                string playAgainInput = Console.ReadLine();
                if (playAgainInput?.ToLower() == "q")
                {
                    gameRun = false;
                    break;
                }
                Console.Clear();
            }
        }
    }
}
