namespace ManaChess.Core
{
    
    // black and white team
    //黑白两方
    public enum Team
    {
        White = 0,
        Black = 1
    }
    
    public enum PieceType
    {
        Pawn = 0,
        Knight = 1,
        Bishop = 2,
        Rook = 3,
        Queen = 4,
        King = 5
    }
    
    // Card rarity
    // 卡牌稀有度
    public enum Rarity
    {
        Common = 0,
        Rare = 1,
        Epic = 2,
        Legendary = 3
    }
    
    // Ability cards target a piece， tactic cards change global rules
    // Ability 卡作用于棋子；Tactic 卡改变全局规则。
    public enum CardType
    {
        Ability = 0,  
        Tactic = 1
    }
    
    public enum MoveKind
    {
        Normal = 0, 
        Capture = 1, 
        Castle = 2, 
        EnPassant = 3
    }
     
    public enum GameResult
    {
        Ongoing = 0,
        WhiteWins = 1,
        BlackWins = 2,
        Draw = 3
    }
}