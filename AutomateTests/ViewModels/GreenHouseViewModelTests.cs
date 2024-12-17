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
        [Test]
        public void Constructor_ShouldInitializeTemperature()
        {
            var viewModel = new GreenHouseViewModel();

            Assert.AreEqual("21 °C", viewModel.Temperature);
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
        public void ToggleWindowCommand_ShouldToggleWindowStatus()
        {
            var viewModel = new GreenHouseViewModel();
            var initialStatus = viewModel.WindowStatus;

            viewModel.ToggleWindowCommand.Execute(null);

            Assert.AreNotEqual(initialStatus, viewModel.WindowStatus);
        }

        [Test]
        public void ToggleFanCommand_ShouldToggleFanStatus()
        {
            var viewModel = new GreenHouseViewModel();
            var initialStatus = viewModel.FanStatus;

            viewModel.ToggleFanCommand.Execute(null);

            Assert.AreNotEqual(initialStatus, viewModel.FanStatus);
        }

        [Test]
        public void ToggleIrrigationCommand_ShouldToggleIrrigationStatus()
        {
            var viewModel = new GreenHouseViewModel();
            var initialStatus = viewModel.IrrigationStatus;

            viewModel.ToggleIrrigationCommand.Execute(null);

            Assert.AreNotEqual(initialStatus, viewModel.IrrigationStatus);
        }

        [Test]
        public void ToggleHeatingCommand_ShouldToggleHeatingStatus()
        {
            var viewModel = new GreenHouseViewModel();
            var initialStatus = viewModel.HeatingStatus;

            viewModel.ToggleHeatingCommand.Execute(null);

            Assert.AreNotEqual(initialStatus, viewModel.HeatingStatus);
        }

        [Test]
        public void ToggleLightsCommand_ShouldToggleLightsStatus()
        {
            var viewModel = new GreenHouseViewModel();
            var initialStatus = viewModel.LightsStatus;

            viewModel.ToggleLightsCommand.Execute(null);

            Assert.AreNotEqual(initialStatus, viewModel.LightsStatus);
        }
    }
}
