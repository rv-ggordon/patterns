using System;
using Xunit;
using Moq;
using GangOfFour.Structural;

namespace Decorator.Tests
{
    public class DecoratorTests 
    {
        [Fact]
        public void FrameCallsPictureAbstract()
        {
            var picture = new Mock<Picture>();
            var frame = new Frame();
            picture.Object.Hang();
            frame.SetComponent(picture.Object);
            frame.BuildFrame();

            picture.Verify(x => x.Hang(), Times.AtLeastOnce);
        }

        [Fact]
        public void FrameSolid_HangFrame()
        {
            var picture = new Picture();
            var frameSolid = new Mock<FrameSolid>();
            picture.Hang();
            frameSolid.Object.Hang();

            //TODO: need to test add behavior but can't with current non virtual functions

            frameSolid.VerifyAll();
        }
    }
}
