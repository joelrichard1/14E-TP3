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
            // Arrange & Act
            var tomato = new TomatoConditions();

            // Assert
            Assert.AreEqual(20, tomato.DayMinTemperature);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMaxTemperature()
        {
            // Arrange & Act
            var tomato = new TomatoConditions();

            // Assert
            Assert.AreEqual(27, tomato.DayMaxTemperature);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMinLux()
        {
            // Arrange & Act
            var tomato = new TomatoConditions();

            // Assert
            Assert.AreEqual(400, tomato.MinLux);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMaxLux()
        {
            // Arrange & Act
            var tomato = new TomatoConditions();

            // Assert
            Assert.AreEqual(1200, tomato.MaxLux);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMinHumidity()
        {
            // Arrange & Act
            var tomato = new TomatoConditions();

            // Assert
            Assert.AreEqual(60.0, tomato.MinHumidity);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMaxHumidity()
        {
            // Arrange & Act
            var tomato = new TomatoConditions();

            // Assert
            Assert.AreEqual(85.0, tomato.MaxHumidity);
        }
    }
}