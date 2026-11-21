using System;

namespace ManaChess.Core
{
    public interface IEventBus
    {
        // Contract for subscribing to and publishing game events. Depend on this instead of EventBus so modules stay decoupled.
        // 订阅和发送游戏 event 的合约。依赖它而不是 EventBus，模块之间才能保持解耦。

        // 泛型<T> 方法名和处理流程相同，数据类型可以替换
        // Exp: text(string name), text(int name) -> text<T>(T name) T为类型参数，代替所有方法相同但传参类型不同的方法
        
        // T 泛型类型， Action<T>泛型方法，只要符合泛型类型+没有void的方法可以传入
        void Subscribe<T>(Action<T> handler) where T : struct;
        void Unsubscribe<T>(Action<T> handler) where T : struct;
        
        // where T struct，传入不同类型，但结构必须限定
        void Publish<T>(T gameEvent) where T : struct;
    }
}