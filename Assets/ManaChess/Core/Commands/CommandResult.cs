namespace ManaChess.Core
{
    public readonly struct CommandResult
    {
        
        // The outcome of running a command: success, or failure with a reason. Create it only through Success() or Failure().
        // 执行指令后的结果：成功，或失败并附上原因。只能用 Success() 或 Failure() 建立。
        public bool IsSuccess { get; }
        public FailureReason? Reason { get; }

        private CommandResult(bool isSuccess, FailureReason? reason)
        {
            IsSuccess = isSuccess;
            Reason = reason;
        }

        public static CommandResult Success()
        {
            return new CommandResult(true, null);
        }

        public static CommandResult Failure(FailureReason reason)
        {
            return new CommandResult(false, reason);
        }
 
        public override string ToString()
        {   
            return IsSuccess ? "Success" : $"Failure: {Reason}";
        }
    }
}