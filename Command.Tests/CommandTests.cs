using System;
using Xunit;
using Moq;
using GangOfFour.Behaviorial;

namespace Command.Tests
{
    public class CommandTests 
    {
        [Fact]
        public void CookCanMakeOrder()
        {
            var cook = new Mock<Cook>();
            var order = new Mock<MakeOrder>(It.IsAny<Cook>());
            Waitress waitress = new Waitress();

            waitress.Build(order.Object);
            waitress.PlaceOrder();

            order.VerifyAll();
            cook.VerifyAll();
        }
    }
}
