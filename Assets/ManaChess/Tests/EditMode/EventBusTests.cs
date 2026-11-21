using System;
using System.Collections.Generic;
using ManaChess.Core;
using NUnit.Framework;

namespace ManaChess.Tests.EditMode
{
    public class EventBusTests
    {
        [Test]
        public void Publish_WithSubscriber_InvokesHandlerWithEvent()
        {
            var bus = new EventBus();
            bool wasCalled = false;
            PieceMoved received = default;
            bus.Subscribe<PieceMoved> (moved =>
            {
                wasCalled = true;
                received = moved;
            });
            
            bus.Publish(new PieceMoved(new PieceId(1), Squares.E2, Squares.E4));
            Assert.IsTrue(wasCalled);
            Assert.AreEqual(new PieceId(1), received.PieceId);
            Assert.AreEqual(Squares.E2, received.From);
            Assert.AreEqual(Squares.E4, received.To);
        }

        [Test]
        public void Publish_WithoutSubscriber_DoesNotThrow()
        {
            var bus = new EventBus();
            bool wasCalled = false;
            Assert.DoesNotThrow(() => bus.Publish(
                new PieceMoved(new PieceId(1), Squares.E2, Squares.E4)));
            Assert.IsFalse(wasCalled);
        }

        [Test]
        public void Publish_MultipleSubscribers_InvokesInSubscriptionOrder()
        {
            var bus = new EventBus();
            var order = new List<string>();
            bus.Subscribe<PieceMoved>(moved => { order.Add("First"); });
            bus.Subscribe<PieceMoved>(moved => { order.Add("Second"); });
            bus.Publish(new PieceMoved());
            Assert.AreEqual("First", order[0]);
            Assert.AreEqual("Second", order[1]);
        }

        [Test]
        public void Publish_DifferentEventType_DoesNotInvokeHandler()
        {
            var bus = new EventBus();
            bool wasCalled = false;
            bus.Subscribe<PieceMoved>(moved => { wasCalled = true; });
            bus.Publish(new PiecePromoted());
            Assert.IsFalse(wasCalled);
            
        }

        [Test]
        public void Unsubscribe_AfterSubscribe_HandlerIsNotInvoked()
        {
            var bus = new EventBus();
            PieceMoved received = default;
            bool wasCalled = false;
            Action<PieceMoved> handler = moved =>
            {
                wasCalled = true;
                received = moved;
            };
            
            bus.Subscribe(handler);
            bus.Unsubscribe(handler);
            
            bus.Publish(new PieceMoved(new PieceId(1), Squares.E2, Squares.E4));
            Assert.IsFalse(wasCalled);
        }

        [Test]
        public void Publish_HandlerUnsubscribesItself_DoesNotThrow()
        {
            var bus = new EventBus();
            Action<PieceMoved> handler = null;
            bool wasCalled = false;
            handler = moved =>
            {
                wasCalled = true;
                bus.Unsubscribe(handler);
            };
            bus.Subscribe(handler);
            Assert.DoesNotThrow(() => bus.Publish(new PieceMoved()));
            Assert.IsTrue(wasCalled);
        }
    }
}