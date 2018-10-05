using System;
using Xunit;
using Moq;
using GangOfFour.Structural;

namespace Proxies.Tests
{
    public class ProxyTests 
    {
        [Fact]
        public void CallProxyToMakeRealDeposit()
        {
            var proxy = new Mock<Proxy>();
            proxy.Object.Deposit();

            proxy.Verify();

        }
    }
}
