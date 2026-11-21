using System;

namespace ManaChess.Core
{
    // every piece got their own identify number
    // 给每个棋附上编号
    public readonly struct PieceId : IEquatable<PieceId>
    {
        public int Value { get; }

        public PieceId(int value)
        {
            Value = value;
        }

        public bool Equals(PieceId other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is PieceId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(PieceId left, PieceId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PieceId left, PieceId right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Piece#{Value}";
        }
    }
}