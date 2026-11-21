using ManaChess.Core;
using NUnit.Framework;

namespace ManaChess.Tests.EditMode
{
    public class CommandResultTests
    {
        [Test]
        public void Success_Always_IsSuccessIsTrue()
        {
            CommandResult result = CommandResult.Success();
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void Success_Always_ReasonIsNull()
        {
            CommandResult result = CommandResult.Success();
            Assert.IsNull(result.Reason);
        }

        [Test]
        public void Failure_WithReason_IsSuccessIsFalse()
        {
            CommandResult result = CommandResult.Failure(FailureReason.IllegalMove);
            Assert.IsFalse(result.IsSuccess);
        }

        [Test]
        public void Failure_WithReason_StoresReason()
        {   
            CommandResult result = CommandResult.Failure(FailureReason.IllegalMove);
            Assert.AreEqual(FailureReason.IllegalMove, result.Reason);
        }

        [Test]
        public void ToString_Success_ReturnsSuccess()
        {
            CommandResult result = CommandResult.Success();
            Assert.AreEqual("Success", result.ToString());
        }

        [Test]
        public void ToString_Failure_IncludesReason()
        {
            CommandResult result = CommandResult.Failure(FailureReason.IllegalMove);
            Assert.AreEqual("Failure: IllegalMove", result.ToString());
        }
    }
}