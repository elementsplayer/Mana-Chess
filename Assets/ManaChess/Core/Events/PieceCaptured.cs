namespace ManaChess.Core
{
    
    // Published when a piece is captured. It carries the type and team because the piece is already off the board; At can differ from the move's destination (en passant).
    // 棋子被吃时发出。因为棋子已经离开棋盘，所以附上兵种和阵营；At 可能和走法终点不同（吃过路兵）。
    public readonly struct PieceCaptured
    { 
        public PieceId PieceId { get; }
        public PieceType Type { get; }
        public Team Team { get; }
        public Position At { get; }
        
        
        public PieceCaptured(PieceId pieceId, PieceType pieceType, Team team, Position at)
        { 
            PieceId = pieceId;
            Type = pieceType;
            Team = team;
            At = at;
             
        }
        
    }
}