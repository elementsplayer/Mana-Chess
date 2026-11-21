using System.Collections.Generic;

namespace ManaChess.Core
{
    public interface IBoardQuery
    {
        // gets the piece on a square. False if empty or off the board
        // 获取该位置放的棋子。若该位置为空或超出棋盘范围返回 false
        bool TryGetPieceAt(Position position, out PieceInfo piece);
        
        // take  both teams all pieces on the board
        // 获得包括双方的场上所有棋
        IReadOnlyList<PieceInfo> GetAllPieces();
    }
}