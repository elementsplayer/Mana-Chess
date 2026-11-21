namespace ManaChess.Core
{
    // Published for every piece that physically moves, so castling publishes it twice (king and rook). Use it for move animations.
    // 每颗实际移动的棋子各发一次，所以易位会发两次（王和车）。用来播放移动动画。
    public readonly struct PieceMoved
    {
        public PieceId PieceId { get; }
        public Position From { get; }
        public Position To { get; }

        public PieceMoved(PieceId pieceId, Position from, Position to)
        {
            PieceId = pieceId;
            From = from;
            To = to;
        }
    }

    
}