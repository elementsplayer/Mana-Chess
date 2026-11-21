namespace ManaChess.Core
{
public interface IGameCommand
{
    
    // Common contract for every player action sent over the network. Every command records which team issued it.
    // 所有通过网络传送的玩家动作的共同合约。每个指令都记录是哪一方发出的。

    Team Issuer { get; }
}
}