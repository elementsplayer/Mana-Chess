namespace ManaChess.Core.Interface
{
    public interface ITurnQuery
    {
        // Team allowed to act now
        // 轮到当前行动的阵营
        Team CurrentTeam { get; }
    }
}