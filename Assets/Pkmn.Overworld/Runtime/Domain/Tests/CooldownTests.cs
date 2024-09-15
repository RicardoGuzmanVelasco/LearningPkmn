using NUnit.Framework;

namespace Pkmn.Overworld.Runtime.Domain.Tests
{
    public class CooldownTests
    {
        [Test]
        public void IsNotUp_ByDefault()
        {
            var sut = new Cooldown(1);
            Assert.IsFalse(sut.IsUp);
        }

        [Test]
        public void IsUp_AfterOneCycle()
        {
            var sut = new Cooldown(period: 1);
            sut.Tick();
            Assert.IsTrue(sut.IsUp);
        }
    }
}