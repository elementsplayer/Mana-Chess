namespace ManaChess.Core
{
    
    // Published when a pawn turns into another piece. NewType is the piece it became.
    // 兵升变成其他棋子时发出。NewType 是变成的兵种。
    
    public readonly struct PiecePromoted
    {
        public PieceId PieceId { get; }
        public PieceType NewType { get; }

        public PiecePromoted(PieceId pieceId, PieceType newType)
        {
            PieceId = pieceId;
            NewType = newType;
        }
    }
}