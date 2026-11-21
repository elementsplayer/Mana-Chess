namespace ManaChess.Core
{
    public readonly struct CheckGiven
    {
        
        // Published when a piece puts the enemy king in check. Used for the check warning UI and to give the checking piece +1 mana.
        // 有棋子将军对方国王时发出。用来显示将军提示，并给发出将军的棋子 +1 mana。

        public Team CheckedTeam { get; }
        public PieceId CheckingPieceId { get; }

        public CheckGiven(Team checkTeam, PieceId checkPiece)
        {
            CheckedTeam = checkTeam;
            CheckingPieceId = checkPiece;
        }
    }
}