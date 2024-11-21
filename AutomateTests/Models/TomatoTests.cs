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
            var tomato = new Tomato();

            // Assert
            Assert.AreEqual(18.5, tomato.MinTemperature);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMaxTemperature()
        {
            // Arrange & Act
            var tomato = new Tomato();

            // Assert
            Assert.AreEqual(26.5, tomato.MaxTemperature);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMinLux()
        {
            // Arrange & Act
            var tomato = new Tomato();

            // Assert
            Assert.AreEqual(25000, tomato.MinLux);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMaxLux()
        {
            // Arrange & Act
            var tomato = new Tomato();

            // Assert
            Assert.AreEqual(50000, tomato.MaxLux);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMinHumidity()
        {
            // Arrange & Act
            var tomato = new Tomato();

            // Assert
            Assert.AreEqual(60.0, tomato.MinHumidity);
        }

        [Test]
        public void Tomato_InitializesWithDefaultMaxHumidity()
        {
            // Arrange & Act
            var tomato = new Tomato();

            // Assert
            Assert.AreEqual(85.0, tomato.MaxHumidity);
        }
    }
}