using System;
using ManaChess.Core;
using NUnit.Framework;

namespace ManaChess.Tests.EditMode
{
    public class PieceInfoTests
    {
        [Test]
        public void Constructor_AllFields_StoresEachField()
        {
            var pieceId = new PieceId(1);
            PieceType pieceType = PieceType.Knight;
            Team team = Team.White;
            Position square = Squares.B1;
            int mana = 2;   
            
            var whiteKnight = new PieceInfo(pieceId, pieceType, team, square, mana);
            Assert.AreEqual(pieceId, whiteKnight.Id);
            Assert.AreEqual(pieceType, whiteKnight.Type);
            Assert.AreEqual(team, whiteKnight.Team);
            Assert.AreEqual(square, whiteKnight.Position);
            Assert.AreEqual(mana, whiteKnight.Mana);
            
        }

        [Test]
        public void Equals_SameFields_ReturnsTrue()
        {
            var piece = new PieceInfo(
                new PieceId(1), PieceType.Knight, Team.White, Squares.B1, 2);
            var samePiece = new PieceInfo(
                new PieceId(1), PieceType.Knight, Team.White, Squares.B1, 2);
            Assert.IsTrue(piece.Equals(samePiece));
            
        }

        [Test]
        public void Equals_DifferentMana_ReturnsFalse()
        {
            var piece = new PieceInfo(
                new PieceId(1), PieceType.Knight, Team.White, Squares.B1, 2);
            var differentPiece = new PieceInfo(
                new PieceId(1), PieceType.Knight, Team.White, Squares.B1, 3);
            Assert.IsFalse(piece.Equals(differentPiece));
        }

        [Test]
        public void ToString_Always_ReturnsReadableFormat()
        {
            var piece = new PieceInfo(
                new PieceId(1), PieceType.Knight, Team.White, Squares.B1, 2);
            Assert.AreEqual("Piece#1 White Knight (0, 1) mana=2", piece.ToString());
        }
    }
}