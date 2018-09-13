using System;
using Xunit;
using Moq;
using GangOfFour.Creational;

namespace GangOfFour.Creational.Tests
{
    public class FactoryTests 
    {
        [Fact]
        public void BuildRoom_UsingBuildingHomeFactory()
        {
            var builidingHomeFactory = new Mock<BuildingHomeFactory>();
            var client = new Client(builidingHomeFactory.Object);

            builidingHomeFactory.Verify(m => m.CreateRoom(), Times.Once());
        }

        [Fact]
        public void BuildFloor_UsingBuildingHomeFactory()
        {
            var builidingHomeFactory = new Mock<BuildingHomeFactory>();
            var client = new Client(builidingHomeFactory.Object);

            builidingHomeFactory.Verify(m => m.CreateFloor(), Times.Once());
        }
    }
}