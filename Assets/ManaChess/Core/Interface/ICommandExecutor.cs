namespace ManaChess.Core.Interface
{
    public interface ICommandExecutor
    {
        // validates and runs a command. On failure the board is unchanged
        // 验证并执行指令，如果执行失败，棋盘状态保持不变
        CommandResult Execute(IGameCommand command);
    }
}