namespace ManaChess.Core
{
    public interface IGameStatusQuery
    {
        // check does king was attacked
        // 检查国王是不是“被将军”状态
        bool IsInCheck(Team team);
        
        // In check with no legal move (normal moves only, abilities ignored)
        // 检查是不是“被将军”且无合法走法的状态（仅考虑常规走法，忽略特殊能力）
        
        bool IsCheckmate(Team team);
        
        // Not in check but no legal move
        // 判断是否处于“未被将军”但无合法走法的状态（即“逼和”）
        bool IsStalemate(Team team);    
    }
}