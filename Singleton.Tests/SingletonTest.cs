using System;
using Xunit;
using Moq;
using GangOfFour.Creational;

namespace Singleton.Tests
{
    public class SingletonTests 
    {
        [Fact]
        public void LazyInitializationSingletonTestForUpcommingElection_Winner_IsTheSameInAllElections()
        {
            var lazyElection1 = Election.LazyWinner();
            var lazyElection2 = Election.LazyWinner();

            Assert.True(lazyElection1.Equals(lazyElection2));
        }

        [Fact]
        public void SingleTestForUpcommingElection_WinnersDidNotChange()
        {

            var electionWinner1 = Election.Winner();
            var electionWinner2 = Election.Winner();

            Assert.True(electionWinner1.Equals(electionWinner2));
        }

    }
}
