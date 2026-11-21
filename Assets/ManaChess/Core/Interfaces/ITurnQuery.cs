namespace ManaChess.Core
{
    public interface ITurnQuery
    {
        // Team allowed to act now
        // 轮到当前行动的阵营
        Team CurrentTeam { get; }
    }
}