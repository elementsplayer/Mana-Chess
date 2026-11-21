using System;

namespace ManaChess.Core
{
    
    // readonly == final 升级版, 只读，防止进一步修改
    // struct ~~ class, 复制份，更改不受影响，密封 ~~ 共享份，更改受影响，不密封
    // readonly struct 只可以读，死封的
    
    // 给整个棋盘设定最基础的2维移动方法，走横或直线
    // Define the most basic 2D movement method for the entire board
    // moving horizontally or in a straight line.
    
    public readonly struct Position : IEquatable<Position>
    {
        public int Row { get; }
        public int Col { get; }

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }
        
        // counting the right position
        public Position Offset(int deltaRow, int deltaCol)
        {
            return new Position(Row + deltaRow, Col + deltaCol);
        }
        
        public override bool Equals(object obj)
        {
            return obj is Position other && Equals(other);
        }
        
        public bool Equals(Position other)
        {
            return Row == other.Row && Col == other.Col;
        }
        
        // ghc == 指纹号，写/找 -> 生成号 -> 去该号抽屉
        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        }

        // operator, (left == right) -> left.row == right.row && left.col == right.col
        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"({Row}, {Col})";
        }
    }

}    