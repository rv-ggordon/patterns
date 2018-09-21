using System;
using Xunit;
using Moq;
using GangOfFour.Structural;

namespace Bridge.Tests
{
    public class BridgeTests 
    {
        [Fact]
        public void SwitchCallsSwitchAbstractOperation()
        {
            var switchAbstraction = new Mock<Switch>();
            switchAbstraction.Object.ON();
            switchAbstraction.Object.OFF();

            switchAbstraction.VerifyAll();
        }

        [Fact]
        public void SwitchCallsConcreteA()
        {
            var concreteA = new Mock<ConcreteA>();
            SwitchAbstraction sa = new SwitchAbstraction();
            sa.Implementer = concreteA.Object;
            sa.ON();

            concreteA.Verify(v => v.ON(), Times.AtLeastOnce);
            concreteA.Verify(v => v.OFF(), Times.Never);
        }

        [Fact]
        public void SwitchCallsConcreteB()
        {
            var concreteB = new Mock<ConcreteB>();
            SwitchAbstraction sa = new SwitchAbstraction();
            sa.Implementer = concreteB.Object;
            sa.ON();

            concreteB.Verify(v => v.ON(), Times.AtLeastOnce);
            concreteB.Verify(v => v.OFF(), Times.Never);
        }
    }
}
