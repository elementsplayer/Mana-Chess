using System.Collections.Generic;

namespace ManaChess.Core
{
    public interface IMoveQuery
    {
        // Legal moves for a piece(own-king-in-check moves excluded). Empty if none or piece not found
        // 获取该棋子合法走法（排除会导致己方国王被“将军”的走法）。如果没有合法走法或找不到该棋子，则返回空列表
        IReadOnlyList<Move> GetLegalMoves(PieceId pieceId);
    }
}