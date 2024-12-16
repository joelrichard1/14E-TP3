using NUnit.Framework;
using Automate.Models;
using Automate.Utils;
using NUnit.Framework.Constraints;

namespace AutomateTests.Utils
{
    [TestFixture]
    public class AdviceUtilsTests
    {
        private ICropConditions _tomato;
        private SystemStatus _statuses;
        private List<string> _advices;
        private GreenhouseCondition _condition;
        private DateTime dayTime = new DateTime(2024, 11, 26, 10, 0, 0);
        private DateTime nightTime = new DateTime(2024, 11, 26, 20, 0, 0);


        [SetUp]
        public void Setup()
        {
            _tomato = new TomatoConditions();
            _statuses = new SystemStatus();
            _advices = new();
            _condition = new GreenhouseCondition();
            _condition.Temperature = 22;
            _condition.Luminosity = 600;
            _condition.Humidity = 70;
            _condition.DateTime = dayTime;
        }

        [Test]
        public void EvaluateConditions_TurnOnHeating_WhenIsDayAndTemperatureIsTooLow()
        {
            _condition.Temperature = 17;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.TurnHeatingOn, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOnHeating_WhenIsNightAndTemperatureIsTooLow()
        {
            _condition.Temperature = 17;
            _condition.DateTime = nightTime;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.TurnHeatingOn, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffHeating_WhenIsDayAndTemperatureIsTooHigh()
        {
            _condition.Temperature = 28;
            _statuses.IsHeatingActive = true;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.TurnHeatingOff, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffHeating_WhenIsNightAndTemperatureIsTooHigh()
        {
            _condition.Temperature = 28;
            _condition.DateTime = nightTime;
            _statuses.IsHeatingActive = true;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.TurnHeatingOff, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOnLights_WhenLuxIsTooLow()
        {
            _condition.Luminosity = 200;
            _condition.DateTime = nightTime;
            _statuses.AreLightsActive = false;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.TurnLightsOn, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffLights_WhenLuxIsTooHigh()
        {
            _condition.Luminosity = 60000;
            _condition.DateTime = dayTime;
            _statuses.AreLightsActive = true;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.TurnLightsOff, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOnVentilation_WhenHumidityIsTooHigh()
        {
            _condition.Humidity = 90;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.TurnVentilationOn, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffVentilation_WhenHumidityIsTooLow()
        {
            _condition.Humidity = 50;
            _statuses.IsVentilationActive = true;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.TurnVentilationOff, _advices);
        }

        [Test]
        public void EvaluateConditions_OpenWindows_WhenIsDayAndTemperatureIsTooHigh()
        {
            _condition.Temperature = 28;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.OpenWindows, _advices);
        }

        [Test]
        public void EvaluateConditions_OpenWindows_WhenIsNightAndTemperatureIsTooHigh()
        {
            _condition.Temperature = 28;
            _condition.DateTime = nightTime;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.OpenWindows, _advices);
        }

        [Test]
        public void EvaluateConditions_CloseWindows_WhenIsDayAndTemperatureIsTooLow()
        {
            _condition.Temperature = 17;
            _statuses.AreWindowsActive = true;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.CloseWindows, _advices);
        }

        [Test]
        public void EvaluateConditions_CloseWindows_WhenIsNightAndTemperatureIsTooLow()
        {
            _condition.Temperature = 17;
            _condition.DateTime = nightTime;
            _statuses.AreWindowsActive = true;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.CloseWindows, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOnSprinklers_WhenHumidityIsTooLow()
        {
            _condition.Humidity = 50;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.TurnSprinklersOn, _advices);
        }

        [Test]
        public void EvaluateConditions_TurnOffSprinklers_WhenHumidityIsTooHigh()
        {
            _condition.Humidity = 90;
            _statuses.AreSprinklersActive = true;

            _advices = AdviceUtils.EvaluateConditions(_tomato, _statuses, _condition);

            Assert.Contains(AdviceUtils.TurnSprinklersOff, _advices);
        }
    }
}