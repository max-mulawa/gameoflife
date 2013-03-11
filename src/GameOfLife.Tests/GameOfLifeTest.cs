using NSubstitute;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GameOfLifeTest
    {
         [Test]
         public void Play()
         {
             var game = new GameOfLife();
             var lifeBootstraper = Substitute.For<ILifeBootstraper>();
             var lifeFactory = Substitute.For<ILifeFactory>();
             var life = new Life(10);
             lifeFactory.Create().Returns(life);
             game.LifeBootstraper = lifeBootstraper;
             game.LifeFactory = lifeFactory;
             game.Play();
             lifeFactory.Received().Create();
             lifeBootstraper.Received().Initialize(life);
         }
    }
}