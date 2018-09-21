using System;
using Xunit;
using Moq;
using GangOfFour.Structural;

namespace Composited.Tests
{
    public class CompositeTests 
    {
        [Fact]
        public void CompositeCallsComponentAbstract()
        {
            var composite = new Mock<Composite>("root");
            composite.Object.Add(new Leaf("Test"));

            composite.Verify(x => x.Add(It.IsAny<ComponentAbstraction>()), Times.AtLeastOnce);
        }

        [Fact]
        public void CompositeCallsComponentAbstractAndName_IsValid()
        {
            var composite = new Mock<Composite>("root");
            composite.Object.Add(new Leaf("Test"));

            Assert.True(composite.Object.name.Equals("root"));  
        }

        [Fact]
        public void CompositeCallsFetchDepth() 
        {
            var composite = new Mock<Composite>("root");
            composite.Object.Add(new Leaf("Test"));
            composite.Object.FetchChildren(1);
            composite.Object.Remove(new Leaf("Test"));

            composite.Verify(m => m.FetchChildren(It.IsAny<int>()), Times.AtLeastOnce);
            composite.Verify(m => m.Add(It.IsAny<Leaf>()), Times.AtLeastOnce);
            composite.Verify(m => m.Remove(It.IsAny<Leaf>()), Times.AtLeastOnce);
        }
    }
}
