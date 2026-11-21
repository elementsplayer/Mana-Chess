using System;

namespace ManaChess.Core
{
    
    // A read-only snapshot of a piece for the UI and other modules. Changing it never changes the board.
    // 棋子的只读快照，给 UI 和其他模块使用。修改它不会影响棋盘
    
    public readonly struct PieceInfo : IEquatable<PieceInfo>
    {
        public PieceId Id { get; }
        public PieceType Type { get; }
        public Team Team { get; }
        public Position Position { get; }
        public int Mana { get; }

        public PieceInfo(PieceId id, PieceType type, Team team, Position position, int mana)
        {
            Id = id;
            Type = type;
            Team = team;
            Position = position;
            Mana = mana;
        }

        public bool Equals(PieceInfo other)
        {
            return Id == other.Id
                && Type == other.Type
                && Team == other.Team
                && Position == other.Position
                && Mana == other.Mana;
        }

        public override bool Equals(object obj)
        {
            return obj is PieceInfo other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Type, Team, Position, Mana);
        }

        public static bool operator ==(PieceInfo left, PieceInfo right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PieceInfo left, PieceInfo right)
        {
            return ! (left == right);
        }

        public override string ToString()
        {
            return $"{Id} {Team} {Type} {Position} mana={Mana}";
        }
    }
}