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
        private Advice _advice;

        [SetUp]
        public void Setup()
        {
            _tomato = new TomatoConditions();
            _statuses = new SystemStatus();
            _advice = new Advice();
        }

        [Test]
        public void EvaluateConditions_TurnOnHeating_WhenTemperatureIsTooLow()
        {
            // Arrange
            double currentTemperature = 17.0;

            // Act
            AdviceUtils.EvaluateConditions(_advice, _tomato, _statuses, currentTemperature, 30000, 70.0);

            // Assert
            Assert.Contains("Allumer le chauffage", _advice.Advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffHeating_WhenTemperatureIsTooHigh()
        {
            // Arrange
            double currentTemperature = 28.0;
            _statuses.IsHeatingActive = true;

            // Act
            AdviceUtils.EvaluateConditions(_advice, _tomato, _statuses, currentTemperature, 30000, 70.0);

            // Assert
            Assert.Contains("Éteindre le chauffage", _advice.Advices);
        }

        [Test]
        public void EvaluateConditions_TurnOnLights_WhenLuxIsTooLow()
        {
            // Arrange
            int currentLux = 20000;

            // Act
            AdviceUtils.EvaluateConditions(_advice, _tomato, _statuses, 22.0, currentLux, 70.0);

            // Assert
            Assert.Contains("Allumer les lumières", _advice.Advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffLights_WhenLuxIsTooHigh()
        {
            // Arrange
            int currentLux = 60000;
            _statuses.AreLightsActive = true;

            // Act
            AdviceUtils.EvaluateConditions(_advice, _tomato, _statuses, 22.0, currentLux, 70.0);

            // Assert
            Assert.Contains("Éteindre les lumières", _advice.Advices);
        }

        [Test]
        public void EvaluateConditions_TurnOnVentilation_WhenHumidityIsTooHigh()
        {
            // Arrange
            double currentHumidity = 90.0;

            // Act
            AdviceUtils.EvaluateConditions(_advice, _tomato, _statuses, 22.0, 30000, currentHumidity);

            // Assert
            Assert.Contains("Allumer la ventilation", _advice.Advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffVentilation_WhenHumidityIsTooLow()
        {
            // Arrange
            double currentHumidity = 50.0;
            _statuses.IsVentilationActive = true;

            // Act
            AdviceUtils.EvaluateConditions(_advice, _tomato, _statuses, 22.0, 30000, currentHumidity);

            // Assert
            Assert.Contains("Éteindre la ventilation", _advice.Advices);
        }

        [Test]
        public void EvaluateConditions_OpenWindows_WhenTemperatureIsTooHigh()
        {
            // Arrange
            double currentTemperature = 28.0;

            // Act
            AdviceUtils.EvaluateConditions(_advice, _tomato, _statuses, currentTemperature, 30000, 70.0);

            // Assert
            Assert.Contains("Ouvrir les fenêtres", _advice.Advices);
        }

        [Test]
        public void EvaluateConditions_CloseWindows_WhenTemperatureIsTooLow()
        {
            // Arrange
            double currentTemperature = 17.0;
            _statuses.AreWindowsActive = true;

            // Act
            AdviceUtils.EvaluateConditions(_advice, _tomato, _statuses, currentTemperature, 30000, 70.0);

            // Assert
            Assert.Contains("Fermer les fenêtres", _advice.Advices);
        }

        [Test]
        public void EvaluateConditions_TurnOnSprinklers_WhenHumidityIsTooLow()
        {
            // Arrange
            double currentHumidity = 50.0;

            // Act
            AdviceUtils.EvaluateConditions(_advice, _tomato, _statuses, 22.0, 30000, currentHumidity);

            // Assert
            Assert.Contains("Allumer les arroseurs", _advice.Advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffSprinklers_WhenHumidityIsTooHigh()
        {
            // Arrange
            double currentHumidity = 90.0;
            _statuses.AreSprinklersActive = true;

            // Act
            AdviceUtils.EvaluateConditions(_advice, _tomato, _statuses, 22.0, 30000, currentHumidity);

            // Assert
            Assert.Contains("Éteindre les arroseurs", _advice.Advices);
        }
    }
}