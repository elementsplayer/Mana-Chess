namespace ManaChess.Core
{
    public sealed class MoveCommand : IGameCommand
    {
        // A player's request to move a piece to a square, sent over the network. The engine decides whether it is legal and what kind of move it is.
        // 玩家要求把某颗棋子走到某格的请求，通过网络传送。合不合法、属于哪种走法，由引擎决定。

        public Team Issuer { get; }
        public PieceId PieceId { get; }
        public Position To { get; }
        public PieceType? PromoteTo { get; }

        public MoveCommand(Team issuer, PieceId pieceId, Position to, PieceType? promoteTo = null)
        {
            Issuer = issuer;
            PieceId = pieceId;
            To = to;
            PromoteTo = promoteTo;
        }

        public override string ToString()
        {   
            string text = $"{Issuer} moves {PieceId} to {To}";
            
            if (PromoteTo.HasValue)
            {
                text += $" ={PromoteTo}";
            }
            
            return text;
        }
    }
}