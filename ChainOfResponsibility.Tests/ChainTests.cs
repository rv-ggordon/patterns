using System;
using Xunit;
using Moq;
using GangOfFour.Behavorial;

namespace ChainOfResponsibility.Tests
{
    public class ChainOfResponsibilityTests 
    {
        [Fact]
        public void CallsHandleRequestForCoinQuaterSorter()
        {
            var quaterSorter = new Mock<SortQuaters>();
            quaterSorter.Object.SetSuccessor(It.IsAny<NoSort>());
            quaterSorter.Object.HandleRequest(It.IsAny<double>());

            quaterSorter.Verify(x => x.HandleRequest(It.IsAny<double>()));
        }

        [Fact]
        public void CallsHandleRequestForDimeSorter()
        {
            var dimeSorter = new Mock<SortDimes>();
            dimeSorter.Object.SetSuccessor(It.IsAny<SortQuaters>());
            dimeSorter.Object.HandleRequest(It.IsAny<double>());

            dimeSorter.Verify(x => x.HandleRequest(It.IsAny<double>()));
        }

        [Fact]
        public void CallsHandleRequestForNickleSorter()
        {
            var nickleSorter = new Mock<SortNickles>();
            nickleSorter.Object.SetSuccessor(It.IsAny<SortDimes>());
            nickleSorter.Object.HandleRequest(It.IsAny<double>());

            nickleSorter.Verify(x => x.HandleRequest(It.IsAny<double>()));
        }

        [Fact]
        public void CallsHandleRequestForNoSorter()
        {
            var noSorter = new Mock<NoSort>();
            noSorter.Object.HandleRequest(It.IsAny<double>());

            noSorter.Verify(x => x.HandleRequest(It.IsAny<double>()));
        }
    }
}
