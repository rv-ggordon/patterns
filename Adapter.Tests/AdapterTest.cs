using System;
using Xunit;
using Moq;
using GangOfFour.Structural;

namespace Adapters.Tests
{
    public class AdapterTests 
    {
        [Fact]
        public void AdapterCalledDriveMethodSuccess()
        {
            var mockRatchet = new Mock<AdapterSocket>();
            mockRatchet.Object.Drive();

            mockRatchet.Verify(x => x.Drive(), Times.AtLeastOnce);
        }

        //TODO: how to verify that private Socket ChangeDrive was called 
    }
}
