using System.Collections.Generic;
using ManaChess.Core;
using NUnit.Framework;
namespace ManaChess.Tests.EditMode
{
    public class PieceIdTests
    {
        [Test]
        public void Equals_SameValue_ReturnsTrue()
        {
            var pieceId = new PieceId(5);
            var samePieceId = new PieceId(5);
            Assert.IsTrue(pieceId.Equals(samePieceId));
        }

        [Test]
        public void Equals_DifferentValue_ReturnsFalse()
        {
            var pieceId = new PieceId(5);
            var differentPieceId = new PieceId(6);
            Assert.IsFalse(pieceId.Equals(differentPieceId));
        }

        [Test]
        public void EqualityOperator_SameValue_ReturnsTrue()
        {
            var pieceId = new PieceId(5);
            var samePieceId = new PieceId(5);
            Assert.IsTrue(pieceId == samePieceId);
        }

        [Test]
        public void InequalityOperator_DifferentValue_ReturnsTrue()
        {
            var pieceId = new PieceId(5);
            var differentPieceId = new PieceId(6);
            Assert.IsTrue(pieceId != differentPieceId);
        }

        [Test]
        public void Dictionary_NewInstanceWithSameValue_ReturnsStoredValue()
        {
            var dict = new Dictionary<PieceId, string>();
            dict[new PieceId(5)] = "Knight";
            
            bool found = dict.TryGetValue(new PieceId(5), out string storedPiece);
            Assert.IsTrue(found);
            Assert.AreEqual("Knight", storedPiece);
        }

        [Test]
        public void ToString_Always_ReturnsPieceHashFormat()
        {
            var pieceId = new PieceId(5);
            Assert.AreEqual("Piece#5", pieceId.ToString());
        }
    }
}