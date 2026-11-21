namespace ManaChess.Core
{
    public interface IRandomSource
    {
        // Random int in [0, maxExclusive). Online must use host's source
        // 生成一个 [0, maxExclusive) 范围内的随机整数。在联机模式下，必须使用主机端的随机源
        int Next(int maxExclusive);
    }
}