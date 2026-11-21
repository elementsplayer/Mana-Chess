using ManaChess.Core;
using NUnit.Framework;

namespace ManaChess.Tests.EditMode
{
    public class MoveCommandTests
    {
        [Test]
        public void Constructor_AllFields_StoresEachField()
        {
            Team issuer = Team.White;
            var whitePawnId = new PieceId(1);
            Position destination = Squares.E8;
            PieceType queen = PieceType.Queen;
            
            var command = new MoveCommand(issuer, whitePawnId, destination, queen);
            Assert.AreEqual(issuer, command.Issuer);
            Assert.AreEqual(whitePawnId, command.PieceId);
            Assert.AreEqual(destination, command.To);
            Assert.AreEqual(queen, command.PromoteTo);
        }

        [Test]
        public void Constructor_WithoutPromoteTo_PromoteToIsNull()
        {
            var command = new MoveCommand(
                Team.White, new PieceId(1), Squares.D5);
            Assert.IsNull(command.PromoteTo);
        }

        [Test]
        public void ToString_WithoutPromotion_DescribesMove()
        {
            var command = new MoveCommand(
                Team.White, new PieceId(3), Squares.E4);
            Assert.AreEqual("White moves Piece#3 to (3, 4)", command.ToString());
        }

        [Test]
        public void ToString_WithPromotion_AppendsPromoteTo()
        {
            var command = new MoveCommand(
                Team.White, new PieceId(3), Squares.E8, PieceType.Queen);
            Assert.AreEqual("White moves Piece#3 to (7, 4) =Queen", command.ToString());
        }
    }
}