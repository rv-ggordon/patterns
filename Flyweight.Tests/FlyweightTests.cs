using System;
using Xunit;
using Moq;
using GangOfFour.Structural;

namespace Flyweight.Tests
{
    public class FlyweightTests 
    {
        [Fact]
        public void CanCreateTheSameMarioSprite_WhenPowerIsChanged()
        {
            var marioFactory = new Mock<MarioCharacterFactory>();
            var m1 = marioFactory.Object.GetMario("Fire");
            m1.changeInto("Fire");

            var marioFactory2 = new Mock<MarioCharacterFactory>();
            var m2 = marioFactory.Object.GetMario("Fire");
            m2.changeInto("Super");

            Assert.True(m1.character.Equals(m2.character));
        }

        [Fact]
        public void UniqueMarioSpriteCharacter_IsNotTheSameAsSuperMarioSprite()
        {
            var marioFactory = new Mock<MarioCharacterFactory>();
            var m1 = marioFactory.Object.GetMario("Fire");
            m1.changeInto("Fire");

            UniqueMarioSprite ums = new UniqueMarioSprite();
            ums.changeInto("Fire");

            Assert.False(m1.character.Equals(ums.character));
            Assert.True(ums.character.Equals("Mario-UN-Plot-1"));
            Assert.True(m1.character.Equals("Mario-V2"));
        }

    }
}
