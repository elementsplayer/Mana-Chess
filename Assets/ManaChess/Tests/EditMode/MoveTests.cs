using System.Collections.Generic;
using ManaChess.Core;
using NUnit.Framework;

namespace ManaChess.Tests.EditMode
{
    public class MoveTests
    {
        [Test]
        public void Constructor_WithoutPromoteTo_PromoteToIsNull()
        {   
            MoveKind moveKind = MoveKind.Normal;
            var move = new Move(Squares.E7, Squares.E8, moveKind);
            Assert.IsNull(move.PromoteTo);
        } 

        [Test]
        public void IsCapture_CaptureKind_ReturnsTrue()
        {
            MoveKind moveKind = MoveKind.Capture;
            var move = new Move(Squares.E4, Squares.D5, moveKind);
            Assert.IsTrue(move.IsCapture);
        }

        [Test]
        public void IsCapture_EnPassantKind_ReturnsTrue()
        {
            MoveKind moveKind = MoveKind.EnPassant;
            var move = new Move(Squares.E5, Squares.D6, moveKind);
            Assert.IsTrue(move.IsCapture);
        }

        [Test]
        public void IsCapture_NormalKind_ReturnsFalse()
        {
            MoveKind moveKind = MoveKind.Normal;
            var move = new Move(Squares.E7, Squares.E8, moveKind);
            Assert.IsFalse(move.IsCapture);
        }

        [Test]
        public void IsPromotion_WithPromoteTo_ReturnsTrue()
        {
            MoveKind moveKind = MoveKind.Normal;
            PieceType pieceType = PieceType.Queen;
            var move = new Move(Squares.E7, Squares.E8, moveKind, pieceType);
            Assert.IsTrue(move.IsPromotion);
        }

        [Test]
        public void Equals_SameFields_ReturnsTrue()
        {
            MoveKind moveKind = MoveKind.Normal;
            PieceType pieceType = PieceType.Bishop;
            
            var bishopMove = new Move(Squares.E7, Squares.E8, moveKind, pieceType);
            var sameBishopMove = new Move(Squares.E7, Squares.E8, moveKind, pieceType);
            Assert.IsTrue(bishopMove.Equals(sameBishopMove));
        }

        [Test]
        public void Equals_DifferentPromoteTo_ReturnsFalse()
        {
            MoveKind moveKind = MoveKind.Normal;
            PieceType bishop = PieceType.Bishop;
            PieceType queen = PieceType.Queen;
            
            var bishopMove = new Move(Squares.E7, Squares.E8, moveKind, bishop);
            var queenMove = new Move(Squares.E7, Squares.E8, moveKind, queen);
            Assert.IsFalse(bishopMove.Equals(queenMove));
        }

        [Test]
        public void HashSet_NewInstanceWithSameFields_IsFound()
        {
            MoveKind moveKind = MoveKind.Normal;
            PieceType bishop = PieceType.Bishop;

            var set = new HashSet<Move>();
            set.Add(new Move(Squares.E7, Squares.E8, moveKind, bishop));
            
            bool found = set.Contains(new Move(Squares.E7, Squares.E8, moveKind, bishop));
            Assert.IsTrue(found);
            
        }

        [Test]
        public void ToString_WithPromotion_AppendsPromoteTo()
        {
            MoveKind moveKind = MoveKind.Normal;
            PieceType queen = PieceType.Queen;
            
            var move = new Move(Squares.E7, Squares.E8, moveKind, queen);
            Assert.AreEqual("((6, 4)-> (7, 4), Normal) =(Queen)", move.ToString());
        }

        [Test]
        public void ToString_WithoutPromotion_HasNoPromoteSuffix()
        {
            MoveKind moveKind = MoveKind.Normal;
            
            var move = new Move(Squares.E2, Squares.E4, moveKind);
            Assert.AreEqual("((1, 4)-> (3, 4), Normal)", move.ToString());
        }
    }
}