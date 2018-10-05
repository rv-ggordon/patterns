using System;
using Xunit;
using Moq;
using GangOfFour.Structural;

namespace Facade.Tests
{
    public class FacadeTests 
    {
        [Fact]
        public void CustomerServiceMethodACalled()
        {
            var customerServiceFacade = new Mock<CustomerService>();
            customerServiceFacade.Object.MethodA();

            customerServiceFacade.Verify(x => x.MethodA(), Times.AtLeastOnce);
        }
    }
}
