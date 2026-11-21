# ManaChess.Core — How to use

Core holds the shared contracts. Other modules only use what is here:
queries (read-only), commands (actions) and events (notifications).

## Rules
- `using ManaChess.Core;` is all you need. Every Core type is in this namespace.
- Create results only with `CommandResult.Success()` / `Failure(...)`. Never `new CommandResult()`.
- Coordinates: `Position(0, 0)` = a1 = White's bottom-left (dark square).

## 1. Draw the board (Chen Jay)
```csharp
foreach (PieceInfo piece in boardQuery.GetAllPieces())
{
    // spawn the sprite for piece.Type and piece.Team at piece.Position
}
```

## 2. Player selects a piece and sends a move
TODO：
- 选到棋子 → 调用 `moveQuery.GetLegalMoves(piece.Id)` → 高亮每个 `move.To`
- 点了目的地 → 检查它是不是在合法走法里 → `new MoveCommand(team, piece.Id, target)`
- 交给 Jin Fong 的送出函数

## 3. Run a move received from the network (Jin Fong)
TODO：
- `CommandResult result = executor.Execute(command);`
- 失败时看 `result.Reason`，触发重新同步
- 成功后用 `statusQuery.IsCheckmate(...)` 等判断胜负

## Events you can subscribe to
TODO：一个表格，每个 event 一行：什么时候发出、通常谁会听

## Who implements what
TODO：`IRandomSource`、`ITurnQuery` → Jin Fong；其他 interface → Eric