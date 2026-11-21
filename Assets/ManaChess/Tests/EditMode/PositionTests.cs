using System.Collections.Generic;
using ManaChess.Core;
using NUnit.Framework;

namespace ManaChess.Tests.EditMode
{
    public class PositionTests
    {
        [Test]
        public void Offset_KnightJumpFromB1_ReturnsC3()
        {
            var knightStart = new Position(0,1);
            Position destination = knightStart.Offset(2, 1);
            Assert.AreEqual(new Position(2, 2), destination);
        }

        [Test]
        public void Offset_AnyDelta_DoesNotModifyOriginal()
        {
            var original = new Position(0,1);
            original.Offset(2, 1);
            Assert.AreEqual(new Position(0, 1), original);
        }

        [Test]
        public void Equals_SameRowAndCol_ReturnsTrue()
        {
            var position = new Position(3,4);
            var samePosition = new Position(3,4);
            Assert.IsTrue(position.Equals(samePosition));
        }

        [Test]
        public void Equals_DifferentCol_ReturnsFalse()
        {
            var position = new Position(3,4);
            var differentColPosition = new Position(3,5);
            Assert.IsFalse(position.Equals(differentColPosition));
        }

        [Test]
        public void EqualityOperator_SameValues_ReturnsTrue()
        {
            var position = new Position(3,4);
            var samePosition = new Position(3,4);
            Assert.IsTrue(position == samePosition);
        }

        [Test]
        public void InequalityOperator_DifferentValues_ReturnsTrue()
        {
            var position = new Position(3,4);
            var differentColPosition = new Position(3,5);
            Assert.IsTrue(position != differentColPosition);
        }

        [Test]
        public void HashSet_NewInstanceWithSameValues_IsFound()
        {
            var set = new HashSet<Position>();
            set.Add(new Position(2,2));
            
            bool found = set.Contains(new Position(2,2));
            Assert.IsTrue(found);
        }

        [Test]
        public void Dictionary_NewInstanceWithSameValues_ReturnsStoredValue()
        {
            var dict = new Dictionary<Position, string>();
            dict[new Position(2, 2)] = "Knight";
            
            bool found = dict.TryGetValue(new Position(2,2), out string storePiece);
            Assert.IsTrue(found);
            Assert.AreEqual("Knight", storePiece);
            
        }

        [Test]
        public void ToString_Always_ReturnsRowColFormat()
        {
            var position = new Position(2,2);
            Assert.AreEqual("(2, 2)", position.ToString());
        }
    }
}