enum PieceType { Pawn, Knight, Bishop, Rook, Queen, King }
class ChessBoard
{
    private static Piece[,] board;
    private static List<Tuple<int, int>> attackedSquares;
    private static bool isWhiteTurn;
    public class Piece
    {
        public PieceType Type { get; private set; }
        public bool IsWhite { get; private set; }
        public bool HasMoved { get; set; }
        public Piece(PieceType type, bool isWhite)
        {
            Type = type;
            IsWhite = isWhite;
            HasMoved = false;
        }
        public bool IsValidMove(int srcRow, int srcCol, int destRow, int destCol, bool isCapture, bool isEnPassant, bool isCastle, ChessBoard chessBoard)
        {
            int rowOffset = Math.Abs(destRow - srcRow);
            int colOffset = Math.Abs(destCol - srcCol);

            switch (Type)
            {
                case PieceType.Pawn:
                    return IsValidPawnMove(srcRow, srcCol, destRow, destCol, rowOffset, colOffset, isCapture, isEnPassant);
                case PieceType.Knight:
                    return IsValidKnightMove(rowOffset, colOffset);
                case PieceType.Bishop:
                    return IsValidBishopMove(rowOffset, colOffset);
                case PieceType.Rook:
                    return IsValidRookMove(rowOffset, colOffset);
                case PieceType.Queen:
                    return IsValidQueenMove(rowOffset, colOffset);
                case PieceType.King:
                    return IsValidKingMove(srcRow, srcCol, destRow, destCol, rowOffset, colOffset, isCastle, chessBoard);
                default:
                    return false;
            }
        }

        private bool IsValidPawnMove(int srcRow, int srcCol, int destRow, int destCol, int rowOffset, int colOffset, bool isCapture, bool isEnPassant)
        {
            int direction = IsWhite ? -1 : 1;
            if (!isCapture)
            {
                // Moving forward
                if (colOffset == 0 && rowOffset == 1)
                {
                    if (srcCol == destCol && destRow == srcRow + direction)
                        return true;
                    else if (srcCol == destCol && srcRow == (IsWhite ? 6 : 1) && destRow == srcRow + (2 * direction))
                        return true;
                }
            }
            else
            {
                // Capturing diagonally or en passant
                if (colOffset == 1 && rowOffset == 1)
                {
                    if (isEnPassant && srcRow == (IsWhite ? 3 : 4) && destRow == srcRow + direction)
                        return true;
                    else if (srcRow + direction == destRow && Math.Abs(srcCol - destCol) == 1)
                        return true;
                }
            }

            return false;
        }

        private bool IsValidKnightMove(int rowOffset, int colOffset)
        {
            return (rowOffset == 2 && colOffset == 1) || (rowOffset == 1 && colOffset == 2);
        }

        private bool IsValidBishopMove(int rowOffset, int colOffset)
        {
            return rowOffset == colOffset;
        }

        private bool IsValidRookMove(int rowOffset, int colOffset)
        {
            return rowOffset == 0 || colOffset == 0;
        }

        private bool IsValidQueenMove(int rowOffset, int colOffset)
        {
            return IsValidRookMove(rowOffset, colOffset) || IsValidBishopMove(rowOffset, colOffset);
        }

        private bool IsValidKingMove(int srcRow, int srcCol, int destRow, int destCol, int rowOffset, int colOffset, bool isCastle, ChessBoard chessBoard)
        {
            if (isCastle)
            {
                // Castling
                if (rowOffset == 0 && colOffset == 2 && !HasMoved)
                {
                    int rookSrcCol, rookDestCol;
                    if (destCol > srcCol)
                    {
                        // Kingside castle
                        rookSrcCol = 7;
                        rookDestCol = 5;
                    }
                    else
                    {
                        // Queenside castle
                        rookSrcCol = 0;
                        rookDestCol = 3;
                    }

                    // Check if the rook is present and hasn't moved
                    Piece rook = chessBoard.GetPiece(srcRow, rookSrcCol);
                    if (rook != null && rook.Type == PieceType.Rook && !rook.HasMoved)
                    {
                        // Check if the path between king and rook is clear
                        int colStep = destCol > srcCol ? 1 : -1;
                        for (int col = srcCol + colStep; col != rookSrcCol; col += colStep)
                        {
                            if (chessBoard.GetPiece(srcRow, col) != null)
                                return false;
                        }

                        // Check if the king is not in check and won't pass through attacked squares
                        int direction = destCol > srcCol ? 1 : -1;
                        for (int col = srcCol; col != destCol; col += direction)
                        {
                            if (chessBoard.IsSquareAttacked(srcRow, col, !IsWhite))
                                return false;
                        }

                        return true;
                    }
                }

                return false;
            }
            else
            {
                return rowOffset <= 1 && colOffset <= 1;
            }
        }

        public override string ToString()
        {
            string color = IsWhite ? "White" : "Black";
            string typeName = Enum.GetName(typeof(PieceType), Type);
            return $"{color} {typeName}";
        }
    }
    public ChessBoard()
    {
        board = new Piece[8, 8];
        attackedSquares = new List<Tuple<int, int>>();
        isWhiteTurn = true;
        InitializeBoard();
    }
    private void InitializeBoard()
    {
        // Initialize the board with null (empty spaces)
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                board[row, col] = null;
            }
        }

        // Place the pieces on the board
        board[0, 0] = new Piece(PieceType.Rook, true);
        board[0, 1] = new Piece(PieceType.Knight, true);
        board[0, 2] = new Piece(PieceType.Bishop, true);
        board[0, 3] = new Piece(PieceType.Queen, true);
        board[0, 4] = new Piece(PieceType.King, true);
        board[0, 5] = new Piece(PieceType.Bishop, true);
        board[0, 6] = new Piece(PieceType.Knight, true);
        board[0, 7] = new Piece(PieceType.Rook, true);

        for (int col = 0; col < 8; col++)
        {
            board[1, col] = new Piece(PieceType.Pawn, true);
        }

        board[7, 0] = new Piece(PieceType.Rook, false);
        board[7, 1] = new Piece(PieceType.Knight, false);
        board[7, 2] = new Piece(PieceType.Bishop, false);
        board[7, 3] = new Piece(PieceType.Queen, false);
        board[7, 4] = new Piece(PieceType.King, false);
        board[7, 5] = new Piece(PieceType.Bishop, false);
        board[7, 6] = new Piece(PieceType.Knight, false);
        board[7, 7] = new Piece(PieceType.Rook, false);

        for (int col = 0; col < 8; col++)
        {
            board[6, col] = new Piece(PieceType.Pawn, false);
        }
    }
    public Piece GetPiece(int row, int col)
    {
        if (row < 0 || row >= 8 || col < 0 || col >= 8)
            return null;

        return board[row, col];
    }
    public bool IsSquareAttacked(int row, int col, bool isWhite)
    {
        foreach (Tuple<int, int> attackedSquare in attackedSquares)
        {
            if (attackedSquare.Item1 == row && attackedSquare.Item2 == col)
                return true;
        }
        return false;
    }
    private static void AddAttackedSquare(int row, int col)
    {
        attackedSquares.Add(new Tuple<int, int>(row, col));
    }
    private static void ClearAttackedSquares()
    {
        attackedSquares.Clear();
    }
    public bool IsValidMove(int srcRow, int srcCol, int destRow, int destCol, ChessBoard chessBoard)
    {
        Piece piece = board[srcRow, srcCol];
        if (piece != null)
        {
            bool isCapture = board[destRow, destCol] != null;
            bool isEnPassant = IsEnPassantCapture(srcRow, srcCol, destRow, destCol);
            bool isCastle = IsCastleMove(srcRow, srcCol, destRow, destCol);
            return piece.IsValidMove(srcRow, srcCol, destRow, destCol, isCapture, isEnPassant, isCastle, chessBoard);
        }
        return false;
    }
    private bool IsEnPassantCapture(int srcRow, int srcCol, int destRow, int destCol)
    {
        Piece pawn = board[srcRow, srcCol];
        if (pawn != null && pawn.Type == PieceType.Pawn)
        {
            int direction = pawn.IsWhite ? -1 : 1;
            if (srcCol != destCol && board[destRow, destCol] == null && board[srcRow, destCol] != null)
            {
                Piece adjacentPawn = board[srcRow, destCol];
                return adjacentPawn.Type == PieceType.Pawn && adjacentPawn.IsWhite != pawn.IsWhite && adjacentPawn.HasMoved;
            }
        }
        return false;
    }
    private bool IsCastleMove(int srcRow, int srcCol, int destRow, int destCol)
    {
        Piece king = board[srcRow, srcCol];
        if (king != null && king.Type == PieceType.King)
        {
            int rowOffset = Math.Abs(destRow - srcRow);
            int colOffset = Math.Abs(destCol - srcCol);

            if (rowOffset == 0 && colOffset == 2)
            {
                int rookSrcCol, rookDestCol;
                if (destCol > srcCol)
                {
                    // Kingside castle
                    rookSrcCol = 7;
                    rookDestCol = 5;
                }
                else
                {
                    // Queenside castle
                    rookSrcCol = 0;
                    rookDestCol = 3;
                }

                // Check if the rook is present and hasn't moved
                Piece rook = board[srcRow, rookSrcCol];
                if (rook != null && rook.Type == PieceType.Rook && !rook.HasMoved)
                {
                    // Check if the path between king and rook is clear
                    int colStep = destCol > srcCol ? 1 : -1;
                    for (int col = srcCol + colStep; col != rookSrcCol; col += colStep)
                    {
                        if (board[srcRow, col] != null)
                            return false;
                    }

                    // Check if the king is not in check and won't pass through attacked squares
                    int direction = destCol > srcCol ? 1 : -1;
                    for (int col = srcCol; col != destCol; col += direction)
                    {
                        if (IsSquareAttacked(srcRow, col, !king.IsWhite))
                            return false;
                    }

                    return true;
                }
            }
        }

        return false;
    }
    public void MakeMove(int srcRow, int srcCol, int destRow, int destCol)
    {
        Piece piece = board[srcRow, srcCol];
        board[destRow, destCol] = piece;
        board[srcRow, srcCol] = null;

        // Handle special moves
        HandleEnPassant(srcRow, srcCol, destRow, destCol);
        HandleCastle(srcRow, srcCol, destRow, destCol);

        // Update piece's movement flag
        if (piece != null)
        {
            piece.HasMoved = true;

            // Check if the moved piece is a pawn reaching the end of the board
            if (piece.Type == PieceType.Pawn && (destRow == 0 || destRow == 7))
            {
                // Promote the pawn to a queen
                board[destRow, destCol] = new Piece(PieceType.Queen, piece.IsWhite);
            }
        }

        // Switch turn to the other player
        isWhiteTurn = !isWhiteTurn;
    }
    private void HandleEnPassant(int srcRow, int srcCol, int destRow, int destCol)
    {
        Piece pawn = board[srcRow, srcCol];
        if (pawn != null && pawn.Type == PieceType.Pawn)
        {
            int direction = pawn.IsWhite ? -1 : 1;
            if (IsEnPassantCapture(srcRow, srcCol, destRow, destCol))
            {
                board[srcRow, destCol] = null; // Remove the captured pawn
            }
        }
    }
    private void HandleCastle(int srcRow, int srcCol, int destRow, int destCol)
    {
        Piece king = board[srcRow, srcCol];
        if (king != null && king.Type == PieceType.King)
        {
            int rowOffset = Math.Abs(destRow - srcRow);
            int colOffset = Math.Abs(destCol - srcCol);

            if (rowOffset == 0 && colOffset == 2)
            {
                int rookSrcCol, rookDestCol;
                if (destCol > srcCol)
                {
                    // Kingside castle
                    rookSrcCol = 7;
                    rookDestCol = 5;
                }
                else
                {
                    // Queenside castle
                    rookSrcCol = 0;
                    rookDestCol = 3;
                }

                Piece rook = board[srcRow, rookSrcCol];
                board[srcRow, rookDestCol] = rook;
                board[srcRow, rookSrcCol] = null;
                rook.HasMoved = true;
            }
        }
    }
    public void UpdateAttackedSquares()
    {
        ClearAttackedSquares();

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                Piece piece = board[row, col];
                if (piece != null)
                {
                    int direction = piece.IsWhite ? -1 : 1;
                    switch (piece.Type)
                    {
                        case PieceType.Pawn:
                            AddAttackedSquare(row + direction, col - 1);
                            AddAttackedSquare(row + direction, col + 1);
                            break;
                        case PieceType.Knight:
                            AddAttackedSquare(row - 2, col - 1);
                            AddAttackedSquare(row - 2, col + 1);
                            AddAttackedSquare(row - 1, col - 2);
                            AddAttackedSquare(row - 1, col + 2);
                            AddAttackedSquare(row + 1, col - 2);
                            AddAttackedSquare(row + 1, col + 2);
                            AddAttackedSquare(row + 2, col - 1);
                            AddAttackedSquare(row + 2, col + 1);
                            break;
                        case PieceType.Bishop:
                            AddDiagonalAttackedSquares(row, col);
                            break;
                        case PieceType.Rook:
                            AddStraightAttackedSquares(row, col);
                            break;
                        case PieceType.Queen:
                            AddStraightAttackedSquares(row, col);
                            AddDiagonalAttackedSquares(row, col);
                            break;
                        case PieceType.King:
                            AddAttackedSquare(row - 1, col - 1);
                            AddAttackedSquare(row - 1, col);
                            AddAttackedSquare(row - 1, col + 1);
                            AddAttackedSquare(row, col - 1);
                            AddAttackedSquare(row, col + 1);
                            AddAttackedSquare(row + 1, col - 1);
                            AddAttackedSquare(row + 1, col);
                            AddAttackedSquare(row + 1, col + 1);
                            break;
                    }
                }
            }
        }
    }
    private void AddStraightAttackedSquares(int row, int col)
    {
        for (int r = row - 1; r >= 0; r--)
        {
            if (board[r, col] != null)
            {
                AddAttackedSquare(r, col);
                break;
            }
            AddAttackedSquare(r, col);
        }

        for (int r = row + 1; r < 8; r++)
        {
            if (board[r, col] != null)
            {
                AddAttackedSquare(r, col);
                break;
            }
            AddAttackedSquare(r, col);
        }

        for (int c = col - 1; c >= 0; c--)
        {
            if (board[row, c] != null)
            {
                AddAttackedSquare(row, c);
                break;
            }
            AddAttackedSquare(row, c);
        }

        for (int c = col + 1; c < 8; c++)
        {
            if (board[row, c] != null)
            {
                AddAttackedSquare(row, c);
                break;
            }
            AddAttackedSquare(row, c);
        }
    }
    private void AddDiagonalAttackedSquares(int row, int col)
    {
        for (int i = 1; row - i >= 0 && col - i >= 0; i++)
        {
            if (board[row - i, col - i] != null)
            {
                AddAttackedSquare(row - i, col - i);
                break;
            }
            AddAttackedSquare(row - i, col - i);
        }

        for (int i = 1; row - i >= 0 && col + i < 8; i++)
        {
            if (board[row - i, col + i] != null)
            {
                AddAttackedSquare(row - i, col + i);
                break;
            }
            AddAttackedSquare(row - i, col + i);
        }

        for (int i = 1; row + i < 8 && col - i >= 0; i++)
        {
            if (board[row + i, col - i] != null)
            {
                AddAttackedSquare(row + i, col - i);
                break;
            }
            AddAttackedSquare(row + i, col - i);
        }

        for (int i = 1; row + i < 8 && col + i < 8; i++)
        {
            if (board[row + i, col + i] != null)
            {
                AddAttackedSquare(row + i, col + i);
                break;
            }
            AddAttackedSquare(row + i, col + i);
        }
    }
    public void DrawBoard()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                Piece piece = board[row, col];
                string cellContent = piece != null ? piece.ToString() : "Empty";
                Console.Write(cellContent.PadRight(19));
            }
            Console.WriteLine();
        }
    }
}