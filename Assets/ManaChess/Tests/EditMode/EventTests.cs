using ManaChess.Core;
using NUnit.Framework;

namespace ManaChess.Tests.EditMode
{
    public class EventTests
    {
        [Test]
        public void PieceMoved_Constructor_StoresFromAndToInOrder()
        {
            var whitePawnId = new PieceId(1);
            Position from = Squares.E2;
            Position to = Squares.E4;
            
            var moved = new PieceMoved(whitePawnId, from, to);
            Assert.AreEqual(moved.From, from);
            Assert.AreEqual(moved.To, to);
        }

        [Test]
        public void PieceCaptured_Constructor_StoresEachField()
        {
            var blackBishopId = new PieceId(2);
            PieceType pieceType = PieceType.Bishop;
            Team team = Team.Black;
            Position at = Squares.E4;
            
            var pieceCaptured = new PieceCaptured(blackBishopId, pieceType, team, at);
            Assert.AreEqual(blackBishopId, pieceCaptured.PieceId);
            Assert.AreEqual(pieceType, pieceCaptured.Type);
            Assert.AreEqual(team, pieceCaptured.Team);
            Assert.AreEqual(at, pieceCaptured.At);
        }
    }
}