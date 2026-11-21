using System;

namespace ManaChess.Core
{
    public readonly struct Move : IEquatable<Move>
    {
        // One chess move: from, to, how it moves (Kind) and an optional promotion. IsCapture covers both normal captures and en passant.
        // 一步棋：起点、终点、移动方式（Kind），以及可选的升变。IsCapture 同时涵盖普通吃子和吃过路兵。

        public Position From { get; }
        public Position To { get; }
        public MoveKind Kind { get; }
        public PieceType? PromoteTo { get; }

        public bool IsCapture => Kind == MoveKind.Capture || Kind == MoveKind.EnPassant;
        public bool IsPromotion => PromoteTo.HasValue;

        public Move(Position from, Position to, MoveKind kind, PieceType? promoteTo = null)
        {
            From = from;
            To = to;
            Kind = kind;
            PromoteTo = promoteTo;
        }

        public bool Equals(Move other)
        {
            return From == other.From 
                   && To == other.To 
                   && Kind == other.Kind 
                   && PromoteTo == other.PromoteTo;
        }

        public override bool Equals(object obj)
        {
            return obj is Move other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(From, To, Kind, PromoteTo);
        }

        public static bool operator ==(Move left, Move right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Move left, Move right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            string text = $"({From}-> {To}, {Kind})";

            if (IsPromotion)
            {
                text += $" =({PromoteTo})";
            }
            
            return text;
        }
    }
}