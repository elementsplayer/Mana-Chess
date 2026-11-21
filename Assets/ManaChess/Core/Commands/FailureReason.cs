namespace ManaChess.Core
{
    
    // Why a command was rejected. The UI maps each value to its own message text.
    // 指令被拒绝的原因。UI 会把每个值对应到自己的提示文字。
    public enum FailureReason
    {
        PieceNotFound = 0,
        NotYourPiece = 1,
        NotYourTurn = 2,
        IllegalMove = 3
    }
}