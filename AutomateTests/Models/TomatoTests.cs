using NUnit.Framework;
using Automate.Models;

namespace AutomateTests.Tests
{
    [TestFixture]
    public class TomatoTests
    {
        [Test]
        public void Tomato_InitializesWithDefaultMinTemperature()
        {
            var tomato = new TomatoConditions();

            Assert.AreEqual(20, tomato.DayMinTemperature);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMaxTemperature()
        {
            var tomato = new TomatoConditions();

            Assert.AreEqual(27, tomato.DayMaxTemperature);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMinLux()
        {
            var tomato = new TomatoConditions();

            Assert.AreEqual(400, tomato.MinLux);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMaxLux()
        {
            var tomato = new TomatoConditions();

            Assert.AreEqual(1200, tomato.MaxLux);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMinHumidity()
        {
            var tomato = new TomatoConditions();

            Assert.AreEqual(60.0, tomato.MinHumidity);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMaxHumidity()
        {
            var tomato = new TomatoConditions();

            Assert.AreEqual(85.0, tomato.MaxHumidity);
        }
    }
}