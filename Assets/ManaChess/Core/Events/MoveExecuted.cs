namespace ManaChess.Core
{
    public readonly struct MoveExecuted
    {
        
        // Published once after a player's move is completed. Carries the full Move for mana, history and capture handling.
        // 玩家的一步棋执行完毕后发出一次。带着完整的 Move，供 mana、历史纪录和吃子处理使用。
        public Team Mover { get; }
        public PieceId PieceId { get; }
        public Move Move { get; }

        public MoveExecuted(Team mover, PieceId pieceId, Move move)
        {
            Mover = mover;
            PieceId = pieceId;
            Move = move;
        }
    }
}