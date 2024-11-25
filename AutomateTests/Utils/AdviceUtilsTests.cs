using NUnit.Framework;
using Automate.Models;
using Automate.Utils;

namespace AutomateTests.Utils
{
    [TestFixture]
    public class AdviceUtilsTests
    {
        private TomatoConditions _tomato;
        private SystemStatus _statuses;
        private List<string> _advices;

        [SetUp]
        public void Setup()
        {
            _tomato = new TomatoConditions();
            _statuses = new SystemStatus();
            _advices = new();
        }

        [Test]
        public void EvaluateConditions_TurnOnHeating_WhenTemperatureIsTooLow()
        {
            // Arrange
            int currentTemperature = 17;

            // Act
            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, currentTemperature, 30000, 70);

            // Assert
            Assert.Contains(AdviceUtils.TurnHeatingOn, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffHeating_WhenTemperatureIsTooHigh()
        {
            // Arrange
            int currentTemperature = 28;
            _statuses.IsHeatingActive = true;

            // Act
            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, currentTemperature, 30000, 70);

            // Assert
            Assert.Contains(AdviceUtils.TurnHeatingOff, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOnLights_WhenLuxIsTooLow()
        {
            // Arrange
            int currentLux = 200;

            // Act
            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, 22, currentLux, 70);

            // Assert
            Assert.Contains(AdviceUtils.TurnLightsOn, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffLights_WhenLuxIsTooHigh()
        {
            // Arrange
            int currentLux = 60000;
            _statuses.AreLightsActive = true;

            // Act
            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, 22, currentLux, 70);

            // Assert
            Assert.Contains(AdviceUtils.TurnLightsOff, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOnVentilation_WhenHumidityIsTooHigh()
        {
            // Arrange
            int currentHumidity = 90;

            // Act
            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, 22, 30000, currentHumidity);

            // Assert
            Assert.Contains(AdviceUtils.TurnVentilationOn, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffVentilation_WhenHumidityIsTooLow()
        {
            // Arrange
            int currentHumidity = 50;
            _statuses.IsVentilationActive = true;

            // Act
            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, 22, 30000, currentHumidity);

            // Assert
            Assert.Contains(AdviceUtils.TurnVentilationOff, _advices);
        }

        [Test]
        public void EvaluateConditions_OpenWindows_WhenTemperatureIsTooHigh()
        {
            // Arrange
            int currentTemperature = 28;

            // Act
            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, currentTemperature, 30000, 70);

            // Assert
            Assert.Contains(AdviceUtils.OpenWindows, _advices);
        }

        [Test]
        public void EvaluateConditions_CloseWindows_WhenTemperatureIsTooLow()
        {
            // Arrange
            int currentTemperature = 17;
            _statuses.AreWindowsActive = true;

            // Act
            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, currentTemperature, 30000, 70);

            // Assert
            Assert.Contains(AdviceUtils.CloseWindows, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOnSprinklers_WhenHumidityIsTooLow()
        {
            // Arrange
            int currentHumidity = 50;

            // Act
            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, 22, 30000, currentHumidity);

            // Assert
            Assert.Contains(AdviceUtils.TurnSprinklersOn, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffSprinklers_WhenHumidityIsTooHigh()
        {
            // Arrange
            int currentHumidity = 90;
            _statuses.AreSprinklersActive = true;

            // Act
            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, 22, 30000, currentHumidity);

            // Assert
            Assert.Contains(AdviceUtils.TurnSprinklersOff, _advices);
        }
    }
}