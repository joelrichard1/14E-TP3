using Automate.Models;
using Automate.Utils;
using Automate.ViewModels;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Windows.Input;

namespace Automate.Tests
{
    [TestFixture]
    public class GreenHouseViewModelTests
    {
        private GreenHouseViewModel _viewModel;

        [SetUp]
        public void Setup()
        {
            _viewModel = new GreenHouseViewModel();
        }

        [Test]
        public void Constructor_ShouldInitializeTemperature()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.AreEqual("20 °C", viewModel.Temperature);
        }

        [Test]
        public void Constructor_ShouldInitializeHumidity()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.AreEqual("50 %", viewModel.Humidity);
        }

        [Test]
        public void Constructor_ShouldInitializeLuminosity()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.AreEqual("600 LUX", viewModel.Luminosity);
        }

        [Test]
        public void Constructor_ShouldInitializeButtonTextToStartSimulation()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.AreEqual("Démarrer Simulation", viewModel.ButtonText);
        }

        [Test]
        public void Constructor_ShouldInitializeAdvicesAsNotNull()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.IsNotNull(viewModel.Advices);
        }

        [Test]
        public void Constructor_ShouldInitializeAdvices()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.AreEqual(1, viewModel.Advices.Count);
        }



        [Test]
        public void Constructor_ShouldInitializeSystemStatus()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.AreEqual(false, viewModel.systemStatus.IsVentilationActive);
        }

        [Test]
        public void Constructor_ShouldInitializeSystemStatusLights()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.AreEqual(false, viewModel.systemStatus.AreLightsActive);
        }

        [Test]
        public void Constructor_ShouldInitializeSystemStatusSprinklers()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.AreEqual(false, viewModel.systemStatus.AreSprinklersActive);
        }

        [Test]
        public void Constructor_ShouldInitializeSystemStatusWindows()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.AreEqual(false, viewModel.systemStatus.AreWindowsActive);
        }

        [Test]
        public void Constructor_ShouldInitializeSystemStatusHeating()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.AreEqual(false, viewModel.systemStatus.IsHeatingActive);
        }

        [Test]
        public void Constructor_ShouldInitializeSystemStatusVentilation()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.AreEqual(false, viewModel.systemStatus.IsVentilationActive);
        }

        [Test]
        public void UpdateCurrentConditions_ShouldUpdateConditionValues()
        {
            var initialTemperature = _viewModel.Temperature;

            _viewModel.UpdateCurrentConditions();

            Assert.AreNotEqual(initialTemperature, _viewModel.Temperature);
        }

        [Test]
        public void ToggleWindowCommand_ShouldToggleWindowStatus()
        {
            var initialStatus = _viewModel.WindowStatus;

            _viewModel.ToggleWindowCommand.Execute(null);

            Assert.AreNotEqual(initialStatus, _viewModel.WindowStatus);
        }

        [Test]
        public void ToggleFanCommand_ShouldToggleFanStatus()
        {
            var initialStatus = _viewModel.FanStatus;

            _viewModel.ToggleFanCommand.Execute(null);

            Assert.AreNotEqual(initialStatus, _viewModel.FanStatus);
        }

        [Test]
        public void ToggleIrrigationCommand_ShouldToggleIrrigationStatus()
        {
            var initialStatus = _viewModel.IrrigationStatus;

            _viewModel.ToggleIrrigationCommand.Execute(null);

            Assert.AreNotEqual(initialStatus, _viewModel.IrrigationStatus);
        }

        [Test]
        public void ToggleHeatingCommand_ShouldToggleHeatingStatus()
        {
            var initialStatus = _viewModel.HeatingStatus;

            _viewModel.ToggleHeatingCommand.Execute(null);

            Assert.AreNotEqual(initialStatus, _viewModel.HeatingStatus);
        }

        [Test]
        public void ToggleLightsCommand_ShouldToggleLightsStatus()
        {
            var initialStatus = _viewModel.LightsStatus;

            _viewModel.ToggleLightsCommand.Execute(null);

            Assert.AreNotEqual(initialStatus, _viewModel.LightsStatus);
        }
    }
}
